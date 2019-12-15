using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS
{
    public class Place : SelectionResult
    {
        public int Place_Id { get; }
        public string Country { get; }
        public string Region { get; }
        public string City { get; }
        public string Zip { get; }
        public string Street { get; }
        public string HouseNumber { get; }
    }
}
