namespace Smartpool
{
    public interface IUserAccess
    {
        bool AddUser(string fullname, string email, string password);
        User FindUserByEmail(string email);
        bool EmailUsed(string email);
        bool RemoveUser(string email);
        void DeleteAllUsers();
    }
}