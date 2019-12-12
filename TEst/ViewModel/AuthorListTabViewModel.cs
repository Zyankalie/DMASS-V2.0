using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMASS
{
    class AuthorListTabViewModel
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
                RaisePropertyChanged("firstname");
            }
        }

        private string _LastName { get; set; }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                RaisePropertyChanged("lastname");
            }
        }

        private void RaisePropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public AuthorListTabViewModel()
        {
            RunSelectCommand = new ActionCommand(p => RunSelect());
            //Authors = new BindableCollection<SmallAuthorObject>(DatabaseAccess.Test());
        }

        private void RunSelect()
        {
            //Authors = new BindableCollection<SmallAuthorObject>(DatabaseAccess.SelectAuthorList(FirstName, LastName));
            Console.WriteLine("yoyo");
        }
    }
}
