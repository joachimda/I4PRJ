using System;

namespace SmartPoolDatabase
{
    public class UserControl : IUserControl
    {
        public void Add(string firstName, string middleName, string lastName, string password, string email)
        {
            Name name = new Name {FirstName = firstName, MiddleName = middleName, LastName = lastName};
            User user = new User {Name = name, Email = email, Password = password};

            using (var db = new SmartPoolModelNewContainer())
            {
                //Need check for existing email
                db.UserSet.Add(user);
            }
        }

        public void Remove(string email, string password)
        {
            using (var db = new SmartPoolModelNewContainer())
            {
                throw new NotImplementedException();
            }
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}