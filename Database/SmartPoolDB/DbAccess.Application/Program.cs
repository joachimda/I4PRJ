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
        }
    }
}
