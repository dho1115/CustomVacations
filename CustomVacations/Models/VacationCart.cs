using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationCart
    {
        public VacationCart()
        {
            this.Products = new HashSet<VacationModel>();
        } 

        //Will do a simple composite. 
        public int id { get; set; }

        public ICollection<VacationModel>Products { get; set; } 
        //Here, instead of making it into an array, we will say it's anything that will be an ICollection because we want to get this out of the database. NOTE: Example was using <BeachProduct>. <> is more flexible than [] to help move to database.
    }
}
