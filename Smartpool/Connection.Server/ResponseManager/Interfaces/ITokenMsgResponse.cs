using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public interface ITokenMsgResponse
    {
        Message HandleTokenMsg(Message message, string messageString);
    }
}