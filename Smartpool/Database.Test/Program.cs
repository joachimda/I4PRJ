using Smartpool.Factories;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartpool.SmartpoolDB smartpoolDb = new Smartpool.SmartpoolDB(new StdAccessFactory());

            smartpoolDb.UserAccess.AddUser("John Derp Smith", "john@smith.com", "johnpass123");
        }
    }
}
