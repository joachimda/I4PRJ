using Smartpool.Factories;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartpool.SmartpoolDB SmartPoolDB = new Smartpool.SmartpoolDB(new StdAccessFactory());

            //SmartPoolDB.UserAccess.DeleteAllUsers();
            SmartPoolDB.UserAccess.AddUser("Joachim Dam Andersen", "jokke@norgaard-andersen.tech", "herropree");
            SmartPoolDB.UserAccess.AddUser("Bjørn Nørgaaard Sørensen", "bjorn@norgaard-andersen.tech", "helloyou");
            SmartPoolDB.UserAccess.AddUser("Signe Satan", "signe@hotmail.com", "signespassword");
            SmartPoolDB.UserAccess.AddUser("Nanna Derps", "derp@gmail.com", "monstersikkerdk");
        }
    }
}
