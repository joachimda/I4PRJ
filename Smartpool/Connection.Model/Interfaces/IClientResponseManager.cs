namespace Smartpool.Connection.Model
{
    public interface IClientResponseManager
    {
        Message HandleMessage(string message);
    }
}