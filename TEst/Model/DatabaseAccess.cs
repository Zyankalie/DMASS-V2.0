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

        public static SelectionResult[] SelectAuthor(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                AuthorInformationObject AInformation = cnn.QuerySingle<AuthorInformationObject>("SELECT "
                                                                                               + "ID as Id, "
                                                                                               + "Born as Born, "
                                                                                               + "Died as Died, "
                                                                                               + "Job as Job, "
                                                                                               + "SororityJoin as SororityJoin, "
                                                                                               + "Memo as Memo "
                                                                                               + "FROM AUTHORINFORMATION "
                                                                                               + "WHERE AUTHOR = " + id
                                                                                               );
                Place Dom = cnn.QuerySingle<Place>("SELECT "
                                                 + "P.Id as Place_Id, "
                                                 + "P.Country as Country, "
                                                 + "P.Region as Region, "
                                                 + "P.City as City, "
                                                 + "P.Zip as Zip, "
                                                 + "P.Street as Street, "
                                                 + "P.Housenumber as HouseNumber "
                                                 + "FROM AuthorInformation AI "
                                                 + "JOIN LinkAuthorInformationPlace LAIP "
                                                 + "ON AI.ID = LAIP.AuthorInformation_ID "
                                                 + "JOIN Place P "
                                                 + "ON LAIP.Place_ID = P.ID "
                                                 + "WHERE LAIP.Type ='Domicile' "
                                                 + "AND AI.ID = " + AInformation.Id
                                                 );
                Place Birth = cnn.QuerySingle<Place>("SELECT "
                                                 + "P.Id as Place_Id, "
                                                 + "P.Country as Country, "
                                                 + "P.Region as Region, "
                                                 + "P.City as City, "
                                                 + "P.Zip as Zip, "
                                                 + "P.Street as Street, "
                                                 + "P.Housenumber as HouseNumber "
                                                 + "FROM AuthorInformation AI "
                                                 + "JOIN LinkAuthorInformationPlace LAIP "
                                                 + "ON AI.ID = LAIP.AuthorInformation_ID "
                                                 + "JOIN Place P "
                                                 + "ON LAIP.Place_ID = P.ID "
                                                 + "WHERE LAIP.Type ='Birthplace' "
                                                 + "AND AI.ID = " + AInformation.Id
                                                 );


                return new SelectionResult[3] { AInformation, Dom, Birth };
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
