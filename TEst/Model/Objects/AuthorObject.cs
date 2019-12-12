using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    class AuthorObject
    {

        public AuthorObject(SmallAuthorObject SmallAuthorObject)
        {
            Id = SmallAuthorObject.Id;
            FirstName = SmallAuthorObject.FirstName;
            LastName = SmallAuthorObject.LastName;
        }
        public int Id{ get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Born { get; }
        public string Died { get; }
        public Place Domicile { get; }
        public Place BirthPlace { get; }
        public string Job { get; }
        public string SororityJoin { get; }
        public string Memo { get; }
    }
}
