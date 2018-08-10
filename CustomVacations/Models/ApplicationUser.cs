using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CustomVacations.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public VacationCart VacationCart { get; set; }

        public ApplicationUser() : base()
        {
            this.VacationCart = new VacationCart();
        }

        public ApplicationUser(string userName) : base(userName)
        {
            this.VacationCart = new VacationCart();
        }
    }
}
