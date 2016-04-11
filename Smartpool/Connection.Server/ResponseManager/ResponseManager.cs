using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Smartpool.Connection.Server.Token;
using Smartpool;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public class ResponseManager : IResponseManager
    {
        private ITokenStringGenerator _tokenStringGenerator;
        private readonly ITokenKeeper _tokenKeeper;
        private string temporaryPoolInfo = "25,60";
        private SmartpoolDB _smartpoolDb = new SmartpoolDB(new UserAccess(), new PoolAccess());

        JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public ResponseManager()
        {
            _tokenStringGenerator = new TokenStringGenerator();
            _tokenKeeper = new TokenKeeper(_tokenStringGenerator, 10);
        }

        public ResponseManager(ITokenStringGenerator tokenStringGenerator, ITokenKeeper tokenKeeper)
        {
            _tokenStringGenerator = tokenStringGenerator;
            _tokenKeeper = tokenKeeper;
        }

        public string Respond(string content)
        {
            var receivedString = content.TrimEnd(content[content.Length-5]);
            
            var recievedMessage = JsonConvert.DeserializeObject<Message>(receivedString, JsonSettings);

            switch (recievedMessage.MsgType)
            {
                case MessageTypes.Login:
                    var loginMessage = JsonConvert.DeserializeObject<LoginMsg>(receivedString);
                    if (_smartpoolDb.UserAccess.ValidatePassword(loginMessage.Username, loginMessage.Password))
                    {
                        var tokenString = _tokenKeeper.CreateNewToken(loginMessage.Username);
                        return "Login";
                        //return "Login,"+tokenString;
                    }
                        
                    else
                    {
                        return "Login failed";
                    }
                case MessageTypes.GetInfo:
                    {
                        if  (_tokenKeeper.TokenActive(receivedString, receivedString))
                            return "Temperature in pool is 25 degrees";

                        else
                        {
                            return "Session Expired";
                        }
                    }
                    
                case MessageTypes.GetPoolInfo:
                    {
                        if (_tokenKeeper.TokenActive(receivedString, receivedString))
                            return JsonConvert.SerializeObject(temporaryPoolInfo);
                        else
                        {
                            return "Session Expired";
                        }
                    }
                default:
                    return "The server did not recognize your request";
            }
        }
    }
}