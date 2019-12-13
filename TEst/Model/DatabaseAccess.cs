using Caliburn.Micro;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    public class DatabaseAccess
    {
        public static List<SmallAuthorObject> SelectAuthorList(string FirstName, string LastName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SmallAuthorObject>("SELECT * FROM AUTHOR WHERE (FIRSTNAME LIKE '%" + FirstName + "%') AND (LASTNAME LIKE '%" + LastName + "%')");
                return output.ToList();
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
