namespace Smartpool.Connection.Model
{
    public class TokenResponseMsg : ServerMsg
    {
        public bool TokenStillActive { get; set; }

        public TokenResponseMsg()
        {
            MsgType = MessageTypes.TokenResponse;
        }

        public TokenResponseMsg(bool tokenStillActive)
        {
            TokenStillActive = tokenStillActive;
            MsgType = MessageTypes.TokenResponse;
        }
    }

    public class AddPoolResponseMsg : TokenResponseMsg
    {
        public bool PoolAdded { get; set; }

        public AddPoolResponseMsg(bool tokenStillActive, bool poolAdded)
        {
            TokenStillActive = tokenStillActive;
            PoolAdded = poolAdded;
            MsgType = MessageTypes.AddPoolResponse;
        }
    }
}