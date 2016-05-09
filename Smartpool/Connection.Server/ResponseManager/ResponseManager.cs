using System;
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
        }

        public ResponseManager(ITokenKeeper tokenKeeper, ITokenMsgResponse tokenMsgResponse, ISmartpoolDB smartpoolDb)
        {
            _tokenKeeper = tokenKeeper;
            _tokenMsgResponse = tokenMsgResponse;
            _smartpoolDb = smartpoolDb;
        }

        public Message Respond(string receivedString)
        {
            var receivedMessage = JsonConvert.DeserializeObject<Message>(receivedString, _jsonSettings);

            switch (receivedMessage.MsgType)
            {
                case MessageTypes.LoginRequest:
                    var loginMessage = JsonConvert.DeserializeObject<LoginRequestMsg>(receivedString);


                    var task = Task.Run(() => _smartpoolDb.UserAccess.ValidatePassword(loginMessage.Username, loginMessage.Password));
                    if (task.Wait(TimeSpan.FromSeconds(3)))
                        return new LoginResponseMsg(_tokenKeeper.CreateNewToken(loginMessage.Username), task.Result);
                    else
                        return new LoginResponseMsg("Login timedout. Please try again later", false);
                    
                case MessageTypes.TokenMsg:
                    var tokenMessage = JsonConvert.DeserializeObject<TokenMsg>(receivedString);
                    if (_tokenKeeper.TokenActive(tokenMessage.Username, tokenMessage.TokenString))
                        return _tokenMsgResponse.HandleTokenMsg(receivedMessage, receivedString, _tokenKeeper);
                    else return new GeneralResponseMsg(false, false);

                case MessageTypes.AddUserRequest:
                    var addUserMessage = JsonConvert.DeserializeObject<AddUserRequestMsg>(receivedString);
                    return new GeneralResponseMsg(false, _smartpoolDb.UserAccess.AddUser(addUserMessage.Fullname, addUserMessage.Username, addUserMessage.Password));

                case MessageTypes.ResetPasswordRequest:
                    var resetPasswordMessage = JsonConvert.DeserializeObject<ResetPasswordRequestMsg>(receivedString);
                    return new GeneralResponseMsg(false, false); //_smartpoolDb.UserAccess.ResetPassword(resetPasswordMessage)

                default:
                    return new Message("The server did not recognize your request");
            }
        }
    }
}