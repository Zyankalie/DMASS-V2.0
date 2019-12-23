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
        public string _Born
        {
            get { return Born.ToShortDateString(); }
        }
        public string _Died
        {
            get { return Died.ToShortDateString(); }
        }
        public string _SororityJoin
        {
            get { return SororityJoin.ToShortDateString(); }
        }
        public DateTime Born;
        public DateTime Died;
        public string Job { get; }
        public DateTime SororityJoin { get; }
        public string Memo { get; }
    }
}
