using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public class TokenMsgResponse : ITokenMsgResponse
    {
        public string HandleTokenMsg(Message message)
        {
            return new Message("not implemented").SerializedMessage;
        }
    }

    public interface ITokenMsgResponse
    {
        string HandleTokenMsg(Message message);
    }
}