using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMASS
{
    class AuthorTabViewModel : BaseViewModel
    {
        public ICommand Back { get; set; }
        public AuthorObject Author { get; set; }
        public string OldSearchFirstName { get; set; }
        public string OldSearchLastName { get; set; }
        public MainWindowViewModel Parent { get; set; }

        public AuthorTabViewModel(string FirstName, string LastName, SmallAuthorObject SmallAuthorObject, MainWindowViewModel Parent)
        {
            OldSearchFirstName = FirstName;
            OldSearchLastName = LastName;
            this.Parent = Parent;
            Back = new ActionCommand(p => OneBack());
            InitAuthor(SmallAuthorObject);
        }

        private void InitAuthor(SmallAuthorObject smallAuthor)
        {
            SelectionResult[] tmp = DatabaseAccess.SelectAuthor(smallAuthor.Id);
            Author = new AuthorObject() { Author = smallAuthor, Information = (AuthorInformationObject)tmp[0], Domicile = (Place)tmp[1], BirthPlace = (Place)tmp[2] };
        }

        private void OneBack()
        {

            //this.Parent.NewAuthorListTab(OldSearchFirstName, OldSearchLastName, this);
        }
    }
}
