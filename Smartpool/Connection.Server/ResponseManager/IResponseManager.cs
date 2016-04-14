using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public interface IResponseManager
    {
        Message Respond(string content);
    }
}