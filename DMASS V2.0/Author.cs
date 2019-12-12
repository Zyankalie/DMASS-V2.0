using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS_V2._0
{
    class Author
    {
        private int Id { get; }
        private string FirstName { get; }
        private string LastName { get; }

        public Author()
        {
        }

        public Author(int AuthorId)
        {
        }

        public bool SelectAuthor(int AuthorId)
        {
            return true;
        }
    }

    class DetailedAuthor : Author
    {
        private int Iid { get; }
        private DateTime Born { get; }
        private DateTime Died { get; }
        private Location Domicile { get; }
        private Location PlaceOfBirth { get; }
        private string Job { get; }
        private string ShortInformation { get; }

        public DetailedAuthor()
        {

        }

        public DetailedAuthor(int AuthorId)
        { 
            /** SELECT * FROM Autor A JOIN AutorInformationen AI
                ON A.ID = AI.Autor
                JOIN ORT O 
                ON AI.Wohnort = O.ID
                WHERE ID = ?             
             */
        }

        public bool NewSelectAuthor(int AuthorId)
        {
            return true;
        }
    }
}
