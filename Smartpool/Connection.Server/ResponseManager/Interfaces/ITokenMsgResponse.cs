using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server
{
    public interface ITokenMsgResponse
    {
        Message HandleTokenMsg(Message message, string messageString, ITokenKeeper tokenKeeper);
    }
}