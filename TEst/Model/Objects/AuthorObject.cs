using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    public class AuthorObject
    {

        public AuthorObject()
        {
        }
        public SmallAuthorObject Author { get; set; }
        public AuthorInformationObject Information { get; set; }
        public Place Domicile { get; set; }
        public Place BirthPlace { get; set; }

    }
}
