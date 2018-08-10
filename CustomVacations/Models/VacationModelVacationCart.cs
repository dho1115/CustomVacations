using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationModelVacationCart
    {
        public int id { get; set; }
        public VacationCart vacationCart { get; set; }
        public int VacationCartId { get; set; }
        public VacationModel vacationModel { get; set; }
        public int vacationModelId { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
