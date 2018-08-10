using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string email { get; set; }
        public double phoneNumber { get; set; }
        public string DreamDestination { get; set; }
        public decimal budget { get; set; }
        public string DestinationDescription { get; set; }
        public VacationCategory VacationCategory { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public string VacationModelName { get; set; } //This is the key lookup column.

        public ICollection<VacationModelVacationCart> VacationModelVacationCarts { get; set; }

        public VacationModel()
        {
            this.VacationModelVacationCarts = new HashSet<VacationModelVacationCart>();
        }
               
    }
}
