using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMASS
{
    class AuthorListTabViewModel:BaseViewModel
    {
        
        public ObservableCollection<SmallAuthorObject> Authors { get; set; }
        
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
            Authors = new ObservableCollection<SmallAuthorObject>();
            
        }

        private void RunSelect()
        {
            Authors.Clear();
            ObservableCollection<SmallAuthorObject> tmp = new ObservableCollection<SmallAuthorObject>(DatabaseAccess.SelectAuthorList(FirstName, LastName));
            foreach (var item in tmp)
            {
                Authors.Add(item);
            }
        }
    }
}
