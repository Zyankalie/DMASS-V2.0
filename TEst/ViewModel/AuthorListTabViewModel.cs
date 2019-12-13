using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMASS
{
    class AuthorListTabViewModel:BaseViewModel
    {
        public BindableCollection<SmallAuthorObject> Authors { get; set; }
        public ICommand RunSelectCommand { get; set; }
        public string Info { get; set; }
        private string _FirstName { get; set; }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
            }
        }

        private string _LastName { get; set; }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
            }
        }

        public AuthorListTabViewModel()
        {
            RunSelectCommand = new ActionCommand(p => RunSelect());
            Authors = new BindableCollection<SmallAuthorObject>();
        }

        private void RunSelect()
        {
            Authors = null;
            Authors.Refresh();
            //Authors = new BindableCollection<SmallAuthorObject>(DatabaseAccess.SelectAuthorList(FirstName, LastName));           
        }
    }
}
