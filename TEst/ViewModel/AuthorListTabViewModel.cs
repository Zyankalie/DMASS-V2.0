using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    class AuthorListTabViewModel
    {
        public BindableCollection<SmallAuthorObject> Authors { get; set; }
        public string Info { get; set; }
        public AuthorListTabViewModel()
        {
            Info = "asd";
            //Authors = new BindableCollection<SmallAuthorObject>(DatabaseAccess.Test());
        }
    }
}
