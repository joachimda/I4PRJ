namespace DBAccessV1
{
    public class DBAccess
    {
        public UserAccess UserAccess { get; } = new UserAccess();
    }

    public class UserAccess
    {
        #region AddUser methods

        public void AddUser(string firstname, string lastname, string email, string password)
        {
            // make temp user
            User tempUser = new User(firstname, lastname, email, password);

            // add user to db
        }

        public void AddUser(string firstname, string middelname, string lastname, string email, string password)
        {
            // make temp user
            User tempUser = new User(firstname, middelname, lastname, email, password);

            // add user to db
        }

        #endregion

        public User FindUser(string email)
        {
            // find user with that email in db

            // return user
            return new User("John", "Doe", "Derp@gmail.com", "ILikeBoobz");
        }
    }
}
