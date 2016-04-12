using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.ResponseManager
{
    public interface IResponseManager
    {
        string Respond(string content);
    }
}