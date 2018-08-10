using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class DestinationDetails
    {
        public int id { get; set; }
        public string DreamDestination { get; set; }
        public decimal budget { get; set; }
        public string DestinationDescription { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
