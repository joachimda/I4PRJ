namespace Smartpool
{
    public interface IUserAccess
    {
        bool AddUser(string fullname, string email, string password);
        User FindUserByEmail(string email);
        bool IsEmailInUse(string email);
        bool ValidatePassword(string email, string password);
        void RemoveUser(string email);
        void DeleteAllUsers();
        bool EditUser(string emailOfUser, string propertyToChange, string newValue);
    }
}