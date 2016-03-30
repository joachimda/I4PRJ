using DbAccess = DbAccess.Access.DbAccess;

namespace global::DbAccess.Access.DbAccess.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            DbAccess access = new DbAccess();
            access.FuckAll();

        }
    }
}
