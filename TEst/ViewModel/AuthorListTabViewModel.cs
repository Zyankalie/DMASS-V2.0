using Caliburn.Micro;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMASS
{
    class AuthorListTabViewModel:BaseViewModel
    {
        public ObservableCollection<SmallAuthorObject> Authors { get; set; }
        public SmallAuthorObject SelectedAuthor { get; set; }
        public ICommand RunSelectCommand { get; set; }
        public ICommand DoubleClickEvent { get; set; }
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
            DoubleClickEvent = new ActionCommand(p => On_DoubleClick());
        }

        private void On_DoubleClick()
        {
            Console.WriteLine(this.SelectedAuthor.FirstName + this.SelectedAuthor.LastName);
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
