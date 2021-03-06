namespace Smartpool.Connection.Model
{
    public class GeneralResponseMsg : ServerMsg
    {
        public bool TokenStillActive { get; set; }
        public bool RequestExecutedSuccesfully { get; set; }
        public GeneralResponseMsg(bool tokenStillActive, bool requestExecutedSuccesfully)
        {
            TokenStillActive = tokenStillActive;
            RequestExecutedSuccesfully = requestExecutedSuccesfully;
            MsgType = MessageTypes.GeneralResponse;
        }
    }
}