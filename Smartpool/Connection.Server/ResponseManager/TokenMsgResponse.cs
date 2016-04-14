using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public class TokenMsgResponse : ITokenMsgResponse
    {
        public Message HandleTokenMsg(Message message)
        {
            return new Message("not implemented");
        }
    }

    public interface ITokenMsgResponse
    {
        Message HandleTokenMsg(Message message);
    }
}