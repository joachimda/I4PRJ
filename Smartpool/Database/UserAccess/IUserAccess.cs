namespace Smartpool.UserAccess
{
    public interface IUserAccess
    {
        bool AddUser(string fullname, string email, string password);
        User FindUserByEmail(string email);
        bool IsEmailInUse(string email);
        bool ValidatePassword(string email, string password);
        bool RemoveUser(string email);
        void DeleteAllUsers();
    }
}