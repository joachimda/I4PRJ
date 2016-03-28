using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAccess = DBAccess_v1._0.Access.DbAccess;

namespace DbAccess.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAccess_v1._0.Access.DbAccess access = new DBAccess_v1._0.Access.DbAccess();
            access.FuckAll();

        }
    }
}
