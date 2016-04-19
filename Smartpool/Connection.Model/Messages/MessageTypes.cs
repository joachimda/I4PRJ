namespace Smartpool.Connection.Model
{
    public enum MessageTypes
    {
        //Client messages
        LoginRequest,
        AddUserRequest,
        ResetPasswordRequest,
        //Client messages for users already logged in
        TokenRequest,
        ChangePasswordRequest,
        LogoutRequest,
        AddPoolRequest,
        UpdatePoolInfoRequest,
        RemovePoolRequest,

        //Server messages
        LoginResponse,
        GeneralResponse,
    }
}