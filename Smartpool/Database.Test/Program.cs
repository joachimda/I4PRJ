using Smartpool.Factories;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartpool.Database database = new Smartpool.Database(new DefaultAccessFactory());

            database.UserAccess.AddUser("John Derp Smith", "john@smith.com", "johnpass123");
        }
    }
}
