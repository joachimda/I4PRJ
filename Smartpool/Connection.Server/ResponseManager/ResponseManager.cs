using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server
{
    public class ResponseManager : IResponseManager
    {
        private readonly ITokenKeeper _tokenKeeper;
        private readonly ISmartpoolDB _smartpoolDb;
        private readonly ITokenMsgResponse _tokenMsgResponse;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public ResponseManager(ISmartpoolDB smartpoolDb)
        {
            _tokenKeeper = new TokenKeeper(new TokenStringGenerator(), 10);
            _smartpoolDb = smartpoolDb;
            _tokenMsgResponse = new TokenMsgResponse(_smartpoolDb);
            try
            {
                //_smartpoolDb.UserAccess.IsEmailInUse("qa"); //error with first call to db taking an excess amount of time
            }
            catch (Exception)
            {
                Console.WriteLine("Could not connect to database. Make sure VPN is active");
            }
            
        }

        public ResponseManager(ITokenKeeper tokenKeeper, ITokenMsgResponse tokenMsgResponse, ISmartpoolDB smartpoolDb)
        {
            _tokenKeeper = tokenKeeper;
            _tokenMsgResponse = tokenMsgResponse;
            _smartpoolDb = smartpoolDb;
        }

        public Message Respond(string receivedString)
        {
            try
            {
                var receivedMessage = JsonConvert.DeserializeObject<Message>(receivedString, _jsonSettings);

                switch (receivedMessage.MsgType)
                {
                    case MessageTypes.LoginRequest:
                        var loginMessage = JsonConvert.DeserializeObject<LoginRequestMsg>(receivedString);
                        return HandleLoginRequest(loginMessage);

                    case MessageTypes.TokenMsg:
                        var tokenMessage = JsonConvert.DeserializeObject<TokenMsg>(receivedString);
                        if (_tokenKeeper.TokenActive(tokenMessage.Username, tokenMessage.TokenString))
                            return _tokenMsgResponse.HandleTokenMsg(receivedMessage, receivedString, _tokenKeeper);
                        else return new GeneralResponseMsg(false, false);

                    case MessageTypes.AddUserRequest:
                        var addUserMessage = JsonConvert.DeserializeObject<AddUserRequestMsg>(receivedString);
                        return new GeneralResponseMsg(false,
                            _smartpoolDb.UserAccess.AddUser(addUserMessage.Fullname, addUserMessage.Username,
                                addUserMessage.Password));

                    case MessageTypes.ResetPasswordRequest:
                        var resetPasswordMessage = JsonConvert.DeserializeObject<ResetPasswordRequestMsg>(receivedString);
                        return new GeneralResponseMsg(false, false);
                    //_smartpoolDb.UserAccess.ResetPassword(resetPasswordMessage)

                    default:
                        return new GeneralResponseMsg(false, false)
                        {
                            MessageInfo = "The server did not recognize your request"
                        };
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                if (e.InnerException is SqlException)
                {
                    return new GeneralResponseMsg(false, false) {MessageInfo = "Please contact helpdesk: CodeDbError40"};
                }
                return new GeneralResponseMsg(false, false) {MessageInfo = "Please check internet connection and braincells for tissue damage"};
            }
        }

        private LoginResponseMsg HandleLoginRequest(LoginRequestMsg loginMsg)
        {
            try
            {
                var task = Task.Run(() => _smartpoolDb.UserAccess.ValidatePassword(loginMsg.Username, loginMsg.Password));
                if (task.Wait(TimeSpan.FromSeconds(15))) //if task is completed within time limit
                {
                    return task.Result ? new LoginResponseMsg(_tokenKeeper.CreateNewToken(loginMsg.Username), true) : new LoginResponseMsg("", false) {MessageInfo = "Username or password was incorrect"};
                }
                else
                    return new LoginResponseMsg("", false) {MessageInfo = "Login timed out. Please try again later"};
            }
            catch (Exception e)
            {
                if (e.InnerException is UserNotFoundException)
                {
                    return new LoginResponseMsg("", false) { MessageInfo = "User not found. Please try again" };
                }

                Console.Write(e.ToString());
                return new LoginResponseMsg("", false)
                {
                    MessageInfo = "Failed to login.\nPlease try again or contact helpdesk"
                };
            }
        }
    }
}