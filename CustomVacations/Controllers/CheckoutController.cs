using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomVacations.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Receipt", new { id = Guid.NewGuid() }); 
                //guid = global unique id.
            }
        }
        
    }
}