using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public class FakeResponseManager
    {
        public string Respond(string content)
        {
            var receivedStrings = content.Split(',');

            var message = JsonConvert.DeserializeObject<ClientMsg>(receivedStrings[0]);

            switch (message.MsgType)
            {
                case "Login":
                    var fullMessage = JsonConvert.DeserializeObject<LoginMsg>(receivedStrings[0]);
                    if (fullMessage.Username == "Joachim" && fullMessage.Password == "1234")
                        return "Login";
                    else
                    {
                        return "Login failed";
                    }
                case "GetPoolInfo":
                    return "Temperature in pool is 25 degrees";
                default:
                    return "The server did not recognize your request";
            }
        }
    }
}