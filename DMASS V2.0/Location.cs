using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASS_V2._0
{
    class Location
    {
        private string Country { get; }
        private string Region { get; }
        private string City { get; }
        private string ZipCode { get; }
        private string Street { get; }
        private string HouseNumber { get; }

        public Location(string Country, string Region, string City, string ZipCode, string Street, string HouseNumber)
        { 
            this.Country=Country;
            this.Region=Region;
            this.City=City;
            this.ZipCode=ZipCode;
            this.Street=Street;
            this.HouseNumber=HouseNumber;
        }
    }
}
