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
        private SmartpoolDB _smartpoolDb = new SmartpoolDB(new UserAccess(), new PoolAccess());
        private readonly TokenMsgResponse _tokenMsgResponse = new TokenMsgResponse();
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        
        public ResponseManager()
        {
            _tokenKeeper = new TokenKeeper(new TokenStringGenerator(), 10);
        }

        public ResponseManager(ITokenKeeper tokenKeeper)
        {
            _tokenKeeper = tokenKeeper;
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
                    return _tokenKeeper.TokenActive(tokenMessage.Username, tokenMessage.TokenString) ? _tokenMsgResponse.HandleTokenMsg(tokenMessage) : new TokenResponseMsg(false);
                    
                default:
                    return new Message("The server did not recognize your request");
            }
        }
    }
}