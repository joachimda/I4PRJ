using Newtonsoft.Json;


namespace Smartpool.Connection.Model
{
    public class ClientResponseManager : IClientResponseManager
    {
        public Message HandleMessage(string messageString)
        {
            var receivedMessage = JsonConvert.DeserializeObject<Message>(messageString);

            switch (receivedMessage.MsgType)
            {
                case MessageTypes.LoginResponse:
                    return JsonConvert.DeserializeObject<LoginResponseMsg>(messageString);
                case MessageTypes.GeneralResponse:
                    return JsonConvert.DeserializeObject<GeneralResponseMsg>(messageString);
                case MessageTypes.GetPoolDataResponse:
                    return JsonConvert.DeserializeObject<GetPoolDataResponseMsg>(messageString);

                default:
                    if (receivedMessage.MessageInfo != null)
                        return new Message(receivedMessage.MessageInfo);
                    else
                    {
                        return new Message("An unknown error occured");
                    }
            }
        }
    }
}
