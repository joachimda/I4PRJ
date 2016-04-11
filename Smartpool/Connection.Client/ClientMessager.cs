using Newtonsoft.Json;
using Smartpool.Application.Model;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Client
{
    public class ClientMessager : IClientMessager
    {
        private readonly SynchronousSocketClient _client = new SynchronousSocketClient();

        public string SendMessage(string messageType, Message message)
        {
            var serializedMessage = JsonConvert.SerializeObject(message);
            return _client.StartClient(messageType + "," + serializedMessage + "<EOF>");
        }
    }
}