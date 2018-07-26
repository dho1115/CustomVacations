using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomVacations.Models
{
    public class CheckoutModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-z,0-9._%+-] + [a-z,0-9.-]+\.[a-z]{2,3}$")]
        [Display(Name = "Email Address")]
        [MinLength(10)]
        public string email { get; set; }
    }
}
