namespace Smartpool.Connection.Model
{
    public class AddPoolPictureRequestMsg : TokenMsg
    {
        public AddPoolPictureRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            SubMsgType = TokenSubMessageTypes.AddPoolPictureRequest;
        }
    }
}