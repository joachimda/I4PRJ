namespace Smartpool
{
    public interface IUserAccess
    {
        bool AddUser(string name, string email, string password);
        User FindUser(string email);
        bool RemoveUser(string email);
        bool DeleteAllUsers();
    }
}