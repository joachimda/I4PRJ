using Newtonsoft.Json;

namespace Smartpool.Connection.Model
{
    public class ClientMessager : IClientMessager
    {
        private readonly IClient _client;

        

        public ClientMessager(IClient client)
        {
            _client = client;
        }

        public string SendMessage(Message message)
        {
            return _client.StartClient(message.SerializedMessage + "<EOF>");
        }
    }
}