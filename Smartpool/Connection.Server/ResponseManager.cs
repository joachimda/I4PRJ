using Newtonsoft.Json;
using Smartpool.Connection.Server.Token;
using Smartpool.Factories;

namespace Smartpool.Connection.Server
{
    public class ResponseManager : IResponseManager
    {
        private ITokenStringGenerator _tokenStringGenerator;
        private readonly ITokenKeeper _tokenKeeper;
        private string temporaryPoolInfo = "25,60";
        private SmartpoolDB _smartpoolDb = new SmartpoolDB(new StdAccessFactory());

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
            var receivedStrings = content.Split(',');
            
            switch (receivedStrings[0])
            {
                case "Login":
                    if (_smartpoolDb.UserAccess.ValidatePassword(receivedStrings[1], receivedStrings[2]))
                    {
                        var tokenString = _tokenKeeper.CreateNewToken(receivedStrings[1]);
                        return "Login";
                        //return "Login,"+tokenString;
                    }
                        
                    else
                    {
                        return "Login failed";
                    }
                case "GetTemp":
                    {
                        if  (_tokenKeeper.TokenActive(receivedStrings[1], receivedStrings[2]))
                            return "Temperature in pool is 25 degrees";

                        else
                        {
                            return "Session Expired";
                        }
                    }
                    
                case "GetPoolInfo":
                    {
                        if (_tokenKeeper.TokenActive(receivedStrings[1], receivedStrings[2]))
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