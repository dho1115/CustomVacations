using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationCart
    {
        public ICollection<VacationModelVacationCart> VacationModelVacationCarts;
        //Here, instead of making it into an array, we will say it's anything that will be an ICollection because we want to get this out of the database. NOTE: Example was using <BeachProduct>. <> is more flexible than [] to help move to database.

        public VacationCart()
        {
            this.VacationModelVacationCarts = new HashSet<VacationModelVacationCart>();
        } 

        //Will do a simple composite. 
        public int id { get; set; }

        public DateTime? DateLastModified { get; set; }
        public DateTime? DateCreated { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Applicationuserid { get; set; }
    }
}
