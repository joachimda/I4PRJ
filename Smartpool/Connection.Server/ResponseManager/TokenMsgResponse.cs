using Newtonsoft.Json;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server
{
    public class TokenMsgResponse : ITokenMsgResponse
    {
        private readonly ISmartpoolDB _smartpoolDb;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        public TokenMsgResponse(ISmartpoolDB smartpoolDb)
        {
            _smartpoolDb = smartpoolDb;
        }
        public Message HandleTokenMsg(Message message, string messageString, ITokenKeeper tokenKeeper)
        {
            var tokenMsg = JsonConvert.DeserializeObject<TokenMsg>(messageString, _jsonSettings);
            switch (tokenMsg.SubMsgType)
            {
                //Pool messages
                case TokenSubMessageTypes.AddPoolRequest:
                    var apMsg = JsonConvert.DeserializeObject<AddPoolRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, _smartpoolDb.PoolAccess.AddPool(apMsg.Username, apMsg.Name, apMsg.Volume)); 

                case TokenSubMessageTypes.UpdatePoolRequest:
                    var upMsg = JsonConvert.DeserializeObject<UpdatePoolRequestMsg>(messageString);
                    var newNameSuccess = true;
                    var newVolumeSuccess = true;
                    if (upMsg.NewPoolName != "")
                    {
                        newNameSuccess = _smartpoolDb.PoolAccess.EditPoolName(upMsg.Username, upMsg.OldPoolName, upMsg.NewPoolName);
                    }
                    if (upMsg.NewPoolVolume != 0)
                    {
                        newVolumeSuccess = _smartpoolDb.PoolAccess.EditPoolVolume(upMsg.Username, upMsg.OldPoolName, upMsg.NewPoolVolume);
                    }
                    if (newVolumeSuccess && newNameSuccess)
                    return new GeneralResponseMsg(true, true);
                    else
                    {
                        return new GeneralResponseMsg(true, false) {MessageInfo = "An error happened. Data was not saved"};
                    }

                case TokenSubMessageTypes.RemovePoolRequest:
                    var rpMsg = JsonConvert.DeserializeObject<RemovePoolRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, _smartpoolDb.PoolAccess.RemovePool(rpMsg.Username, rpMsg.PoolName)); 

                case TokenSubMessageTypes.AddPoolPictureRequest:
                    var appMsg = JsonConvert.DeserializeObject<AddPoolPictureRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, false) { MessageInfo = "Not implemented" };

                case TokenSubMessageTypes.GetPoolDataRequest:
                    var gpdMsg = JsonConvert.DeserializeObject<GetPoolDataRequestMsg>(messageString);
                    return new GetPoolDataResponseMsg() { MessageInfo = "Not implemented"};  

                //User messages
                case TokenSubMessageTypes.ChangePasswordRequest:
                    var cpMsg = JsonConvert.DeserializeObject<ChangePasswordRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, false);

                case TokenSubMessageTypes.LogoutRequest:
                    var loMsg = JsonConvert.DeserializeObject<LogoutRequestMsg>(messageString);
                    tokenKeeper.RemoveToken(loMsg.Username);
                    return new GeneralResponseMsg(true, true);
                
                case TokenSubMessageTypes.AllowAccessToPoolDataRequest:
                    return new GeneralResponseMsg(true, false);
                //Monitor unit messages

                //Default
                default:
                    return new GeneralResponseMsg(true, false);
            }
        }
    }
}