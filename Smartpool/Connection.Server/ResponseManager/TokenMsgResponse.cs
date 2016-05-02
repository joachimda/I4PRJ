using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server
{
    public class TokenMsgResponse : ITokenMsgResponse
    {
        private readonly ISmartpoolDB _smartpoolDb;
        public TokenMsgResponse(ISmartpoolDB smartpoolDb)
        {
            _smartpoolDb = smartpoolDb;
        }
        public Message HandleTokenMsg(Message message, string messageString, ITokenKeeper tokenKeeper)
        {
            switch (message.MsgType)
            {
                //Pool messages
                case MessageTypes.AddPoolRequest:
                    var apMsg = JsonConvert.DeserializeObject<AddPoolMsg>(messageString);
                    return new GeneralResponseMsg(true, _smartpoolDb.PoolAccess.AddPool(apMsg.Username, apMsg.Name, apMsg.Volume));

                case MessageTypes.UpdatePoolRequest:
                    var upiMsg = JsonConvert.DeserializeObject<UpdatePoolInfoMsg>(messageString);
                    return new GeneralResponseMsg(true, false); // _smartpoolDb.PoolAccess.UpdatePoolInfo(upiMsg.OldPoolName, upiMsg.NewPoolAddress, upiMsg.NewPoolName, upiMsg.NewPoolVolume)

                case MessageTypes.RemovePoolRequest:
                    var rpMsg = JsonConvert.DeserializeObject<RemovePoolMsg>(messageString);
                    return new GeneralResponseMsg(true, _smartpoolDb.PoolAccess.RemovePool(rpMsg.Username, rpMsg.PoolName)); 

                case MessageTypes.AddPoolPictureRequest:
                    return new GeneralResponseMsg(true, false);

               case MessageTypes.GetPoolDataRequest:
                   return new Message("Not implemented"); //new GetPoolDataResponseMsg()

                case MessageTypes.GetAllPoolNamesRequest:
                    return new Message("Not implemented"); //new GetAllPoolNamesResponseMsg()

                case MessageTypes.GetPoolHistoryRequest:
                    return new Message("Not implemented"); //new GetPoolHistoryResponseMsg()

                //User messages
                case MessageTypes.ChangePasswordRequest:
                    var cpMsg = JsonConvert.DeserializeObject<ChangePasswordMsg>(messageString);
                    return new GeneralResponseMsg(true, false);

                case MessageTypes.LogoutRequest:
                    var loMsg = JsonConvert.DeserializeObject<LogoutMsg>(messageString);
                    tokenKeeper.RemoveToken(loMsg.Username);
                    return new GeneralResponseMsg(true, true);
                
                case MessageTypes.AllowAccessToPoolDataRequest:
                    return new GeneralResponseMsg(true, false);
                //Monitor unit messages

                //Default
                default:
                    return new GeneralResponseMsg(true, false);
            }
        }
    }
}