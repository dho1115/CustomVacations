using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationOrder
    {
        public Guid id { get; set; }
        public string email { get; set; }
        public string streetaddress { get; set; }
        public ICollection<VacationOrderDestinationDetails> VacationOrderDestinationDetails { get; set; }
        public VacationOrder()
        {
            this.VacationOrderDestinationDetails = new HashSet<VacationOrderDestinationDetails>();
        }

    }
}
