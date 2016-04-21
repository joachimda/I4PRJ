namespace Smartpool.Connection.Model
{

    public interface IClientMessager
    {
        /// <summary>
		/// Method for sending a message to the server
		/// </summary>
        Message SendMessage(Message message);
    }
}