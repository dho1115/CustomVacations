using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationOrderDestinationDetails
    {
        public Guid id { get; set; }
        public VacationOrder VacationOrder { get; set; }
        public Guid VacationOrderId { get; set; }
        public string destination { get; set; }
        public string destinationdescription { get; set; }
        public decimal Budget { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
