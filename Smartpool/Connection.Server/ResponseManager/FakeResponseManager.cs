using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public class FakeResponseManager
    {
        public string Respond(string content)
        {
            var receivedStrings = content.Split('¤');

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var message = JsonConvert.DeserializeObject<Message>(receivedStrings[0], settings);

            switch (message.MsgType)
            {
                case MessageTypes.Login:
                    var fullMessage = JsonConvert.DeserializeObject<LoginMsg>(receivedStrings[0]);
                    if (fullMessage.Username == "Joachim" && fullMessage.Password == "1234")
                        return "Login";
                    else
                    {
                        return "Login failed";
                    }
                case MessageTypes.GetInfo:
                    return "Temperature in pool is 25 degrees";
                default:
                    return "The server did not recognize your request";
            }
        }
    }
}