using Smartpool.Factories;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartpool.SmartpoolDB SmartPoolDB = new Smartpool.SmartpoolDB(new StdAccessFactory());

            SmartPoolDB.UserAccess.DeleteAllUsers();
        }
    }
}
