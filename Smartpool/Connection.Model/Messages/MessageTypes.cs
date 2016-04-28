namespace Smartpool.Connection.Model
{
    public enum MessageTypes
    {
        //Client messages
        LoginRequest,
        AddUserRequest,
        ResetPasswordRequest,
        //Client messages for users already logged in
            //User messages
            ChangePasswordRequest,
            LogoutRequest,
            AllowAccessToPoolDataRequest, //Takes poolname and username/email for receiver
            
            //Pool messages
            AddPoolRequest,
            UpdatePoolRequest,
            RemovePoolRequest,
            AddPoolPictureRequest,

            GetPoolDataRequest, //Get all data about pool + latest sensor values
            GetAllPoolNamesRequest, //Quick get for program startup
            GetPoolHistoryRequest,
            //Monitor Unit messages
            AddMonitorUnitRequest,
            UpdateMonitorUnitRequest,
            RemoveMonitorUnitRequest,
            ChangeSensorTargetValueRequest, //Takes poolname and array of sensor name/number

        //Non createable client message
        TokenMsg,

        //Server messages
        LoginResponse,
        GeneralResponse,

        //Not implemented
        GetPoolDataResponse, //get poolinfo + latest sensor values
        GetAllPoolNamesResponse, //get name + alert bool
        GetPoolHistoryResponse,
    }
}