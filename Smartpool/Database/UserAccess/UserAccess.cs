namespace Smartpool
{
    public class UserAccess : IUserAccess
    {
        public bool AddUser(string fullname, string email, string password)
        {
            string[] names = fullname.Split(' ');

            User user = new User() { Firstname = names[0], Lastname = names[names.Length], Email = email, Password = password };
            
            using (var db = new DatabaseContext())
            {

            }

            return false;
        }

        public User FindUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}