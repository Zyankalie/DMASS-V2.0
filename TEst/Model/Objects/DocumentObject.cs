using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    class DocumentObject : SelectionResult
    {
        public int Id { get; }
        public string Title { get; }
        public string Category { get; }
        public string Filepath { get; }
        public string AuthorFirstName { get; }
        public string AuthorLastName { get; }
        public string CreationDate { get; }
    }
}
