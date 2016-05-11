namespace Smartpool.Connection.Model
{
    public enum MessageTypes
    {
        //Client messages
        LoginRequest,
        AddUserRequest,
        ResetPasswordRequest,
        TokenMsg, //subcategory for all messages when a user is logged in

        //Server messages
        LoginResponse,
        GeneralResponse,
        GetPoolDataResponse, //Get all pool names or all data from one pool
        GetPoolInfoResponse, //Get information about a pool
    }

    public enum TokenSubMessageTypes
    {
        //Client messages for users already logged in
        //User messages
        ChangePasswordRequest,
        LogoutRequest,
        AllowAccessToPoolDataRequest, //Takes poolname and username/email for receiver

        //Pool messages
        AddPoolPictureRequest,
        AddPoolRequest,
        GetPoolDataRequest, //Get all pool names or all data from one pool
        GetPoolInfoRequest, //Get information about a pool
        RemovePoolRequest,
        UpdatePoolRequest,
        
        //Monitor Unit messages
        ChangeSensorTargetValueRequest, //Takes poolname and array of sensor name/number
    }
}