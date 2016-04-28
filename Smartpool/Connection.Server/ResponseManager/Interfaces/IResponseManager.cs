using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server
{
    public interface IResponseManager
    {
        Message Respond(string content);
    }
}