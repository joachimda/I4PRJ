
namespace Smartpool.Connection.Model
{
    public class Message
    {
        public string MessageInfo { get; set; }
        public MessageTypes MsgType { get; set; }

        public Message()
        {
            
        }

        public Message(string messageInfo)
        {
            MessageInfo = messageInfo;
        }
    }
}

