namespace Smartpool.Connection.Model
{
    public class TokenResponseMsg : ServerMsg
    {
        public bool TokenStillActive { get; set; }

        public TokenResponseMsg(bool tokenStillActive)
        {
            TokenStillActive = tokenStillActive;
        }
    }
}