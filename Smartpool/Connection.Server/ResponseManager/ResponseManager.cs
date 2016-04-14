using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Smartpool.Connection.Server.Token;
using Smartpool;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public class ResponseManager : IResponseManager
    {
        private readonly ITokenKeeper _tokenKeeper;
        private readonly ISmartpoolDB _smartpoolDb;
        private readonly ITokenMsgResponse _tokenMsgResponse;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        
        public ResponseManager()
        {
            _tokenKeeper = new TokenKeeper(new TokenStringGenerator(), 10);
            _tokenMsgResponse = new TokenMsgResponse();
            _smartpoolDb = new SmartpoolDB(new UserAccess(), new PoolAccess());
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
                case MessageTypes.Login:
                    var loginMessage = JsonConvert.DeserializeObject<LoginMsg>(receivedString);
                    return _smartpoolDb.UserAccess.ValidatePassword(loginMessage.Username, loginMessage.Password) ? new LoginResponseMsg(_tokenKeeper.CreateNewToken(loginMessage.Username), true) : new LoginResponseMsg("", false);

                case MessageTypes.Token:
                    var tokenMessage = JsonConvert.DeserializeObject<TokenMsg>(receivedString);
                    if (_tokenKeeper.TokenActive(tokenMessage.Username, tokenMessage.TokenString))
                        return _tokenMsgResponse.HandleTokenMsg(tokenMessage);
                    else return new TokenResponseMsg(false);

                case MessageTypes.AddUser:
                    var addUserMessage = JsonConvert.DeserializeObject<AddUserMsg>(receivedString);
                    return new AddUserResponseMsg(_smartpoolDb.UserAccess.AddUser(addUserMessage.Fullname, addUserMessage.Username, addUserMessage.Password));
                default:
                    return new Message("The server did not recognize your request");
            }
        }
    }
}