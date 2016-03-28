using System.Data.Entity.Core.Common.CommandTrees;

namespace SmartPoolDatabase
{
    public interface IUserControl
    {
        void Add(string firstName, string middleName, string lastName, string password, string email);
        void Remove(string email, string password);
        void RemoveAll();
        void Edit(User user);

        
    }
}