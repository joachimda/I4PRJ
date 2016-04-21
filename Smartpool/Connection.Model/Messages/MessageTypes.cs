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
            //Pool messages
            AddPoolRequest,
            GetPoolRequest,
            UpdatePoolRequest,
            RemovePoolRequest,
            AddPoolPictureRequest,
            //Monitor Unit messages
            AddMonitorUnitRequest,
            GetMonitorUnitRequest,
            UpdateMonitorUnitRequest,
            RemoveMonitorUnitRequest,

        //Not implemented
        GetAllPoolNames, //Quick get for program startup
        GetAllDataRequest, //For program startup
        AllowAccessToPoolDataRequest, //Takes poolname/address and username/email for receiver
        ChangeSensorTargetValueRequest, //Takes poolname and array of sensor name/number
        GetSensorValueRequest, //Takes poolname and array of sensor name/number

        //Non createable client message
        TokenMsg,

        //Server messages
        LoginResponse,
        GeneralResponse,

        //Not implemented
        GetPoolResponse,
        GetMonitorUnitResponse,
        GetAllPoolNamesResponse,
        GetAllDataResponse,
        GetSensorValueResponse,
    }
}