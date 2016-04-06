using DbAccess.Database_model;

namespace DbAccess
{
    public interface IUserAccess
    {
        void AddUser(string firstname, string lastname, string email, string password);
        void AddUser(string firstname, string middelname, string lastname, string email, string password);
        void DeleteAllUserData();
        User FindUserByEmail(string email);
    }
}