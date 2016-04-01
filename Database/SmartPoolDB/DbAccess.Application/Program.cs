namespace DbAccess.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            DbAccess dbAccess = new DbAccess();

            dbAccess.UserAccess.AddUser("Hans", "Peter", "Jensen", "peter@jensen.com", "petersPassword");
            dbAccess.UserAccess.AddUser("Lars", "Peter", "Jensen", "lars@jensen.com", "larssPassword");
            dbAccess.UserAccess.AddUser("Signe", "Jensen", "signe@jensen.com", "signesPassword");
            dbAccess.UserAccess.AddUser("Nanna", "Petersen", "nanna@petersen.com", "nannasPassword");

            //dbAccess.UserAccess.RemoveUser("peter@jensen.com");
            //dbAccess.PoolAccess.AddPool(dbAccess.UserAccess.FindUserByEmail("peter@jensen.com").ElementAt(0), "Baghave", 3, 4, 2);
            //dbAccess.PoolAccess.AddPool(dbAccess.UserAccess.FindUserByEmail("peter@jensen.com").ElementAt(0), "Sommerhus", 3, 4, 2);

            //dbAccess.DeleteAllData();

            //foreach (var user in dbAccess.UserAccess.FindUserByEmail("peter@jensen.com"))
            //{
            //    Console.WriteLine(user.Firstname);
            //}
        }
    }
}
