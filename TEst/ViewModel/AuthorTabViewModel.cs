using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMASS
{
    class AuthorTabViewModel:BaseViewModel
    {
        public ICommand Back { get; set; }
        public AuthorObject Author { get; set; }        
        public string OldSearchFirstName { get; set; }
        public string OldSearchLastName { get; set; }
        public MainWindowViewModel Parent { get; set; }

        public AuthorTabViewModel(string FirstName, string LastName, SmallAuthorObject SmallAuthorObject, MainWindowViewModel Parent)
        {
            Author = new AuthorObject(SmallAuthorObject);
            OldSearchFirstName = FirstName;
            OldSearchLastName = LastName;
            this.Parent = Parent;
            Back = new ActionCommand(p=>OneBack());
        }

        private void OneBack()
        {
            Console.WriteLine("yoyo");
            this.Parent.NewAuthorListTab(OldSearchFirstName, OldSearchLastName, this);
        }
    }
}
