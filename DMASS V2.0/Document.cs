using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS_V2._0
{
    class Document
    {
        private int Id { get; }
        private string Title { get; }
        private string Category { get; }
        private string Author { get; }
        private DateTime CreationDate { get; }
        private string FilePath { get; }

        public Document()
        { 
        }

        public Document(int ID)
        { 
        }

        public bool selectDocument()
        {
            return true;
        }        
    }
}
