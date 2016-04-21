using Newtonsoft.Json;

namespace Smartpool.Connection.Model
{
    public class ClientMessager : IClientMessager
    {
        private readonly IClient _client;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        private readonly ClientResponseManager _clientResponseManager = new ClientResponseManager();
        

        public ClientMessager(IClient client)
        {
            _client = client;
        }

        public Message SendMessage(Message message)
        {
            return _clientResponseManager.HandleMessage(_client.StartClient(JsonConvert.SerializeObject(message, _jsonSettings) + "<EOF>"));
        }
    }
}