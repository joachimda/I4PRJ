namespace Smartpool
{
    public interface IUserAccess
    {
        bool AddUser(string fullname, string email, string password);
        User FindUserByEmail(string email);
        bool IsEmailUsed(string email);
        bool RemoveUser(string email);
        bool DeleteAllUsers();
    }
}