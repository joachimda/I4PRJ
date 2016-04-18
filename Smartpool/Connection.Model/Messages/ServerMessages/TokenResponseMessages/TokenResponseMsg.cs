namespace Smartpool.Connection.Model
{
    public class TokenResponseMsg : ServerMsg
    {
        public bool TokenStillActive { get; set; }

        public TokenResponseMsg()
        {
            
        }

        public TokenResponseMsg(bool tokenStillActive)
        {
            TokenStillActive = tokenStillActive;
        }
    }

    public class AddPoolResponseMsg : TokenResponseMsg
    {
        public bool PoolAdded { get; set; }

        public AddPoolResponseMsg(bool tokenStillActive, bool poolAdded)
        {
            TokenStillActive = tokenStillActive;
            PoolAdded = poolAdded;
        }
    }
}