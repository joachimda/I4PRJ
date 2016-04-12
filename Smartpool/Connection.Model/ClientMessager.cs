using Newtonsoft.Json;

namespace Smartpool.Connection.Model
{
    public class ClientMessager : IClientMessager
    {
        private readonly IClient _client;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public ClientMessager(IClient client)
        {
            _client = client;
        }

        public string SendMessage(Message message)
        {
            return _client.StartClient(JsonConvert.SerializeObject(message, _jsonSettings) + "<EOF>");
        }
    }
}