using Newtonsoft.Json;

namespace Smartpool.Connection.Model
{
    public class ClientMessager : IClientMessager
    {
        private readonly IClient _client;

        JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public ClientMessager(IClient client)
        {
            _client = client;
        }

        public string SendMessage(Message message)
        {
            var serializedMessage = JsonConvert.SerializeObject(message, JsonSettings);
            return _client.StartClient(serializedMessage + "<EOF>");
        }
    }
}