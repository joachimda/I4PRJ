using System.Runtime.InteropServices.WindowsRuntime;

namespace SPDatabase
{
    enum AccessLevel
    {
        Spectator = 1, 
        User,
        Admin
    }

    public class User
    {
        RealName _realName = new RealName();

        public User(string fN, string mN, string lN)
        {
            _realName.FirstName = fN;
            _realName.MiddleName = mN;
            _realName.SurName = lN;
        }
    }
}
