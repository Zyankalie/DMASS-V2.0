using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    public class AuthorInformationObject : SelectionResult
    {
        public int Id { get; set; }
        public DateTime Born { get; }
        public DateTime Died { get; }
        public string Job { get; }
        public DateTime SororityJoin { get; }
        public string Memo { get; }
    }
}
