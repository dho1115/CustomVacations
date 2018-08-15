using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomVacations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CustomVacations.Data;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CustomVacations.Controllers
{
    public class VacationsController : Controller 
    {        
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public VacationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        
        //[Microsoft.AspNetCore.Authorization.Authorize] - This will direct the user to either the login page or to whatever page we want to direct them to.


        public async Task <IActionResult> Index(string category = "USA")
        {
            if (_context.VacationModels.Count() == 0) //Adds data to table (?).
            {
                List<VacationModel> CanadaTrip = new List<VacationModel>();

                CanadaTrip.Add(new VacationModel { ID = 1, CustomerName = "Jamie Smith", DreamDestination = "Canada", DestinationDescription = "Would love to go to Canada.", budget = 3500, email = "Jamie@email.com", phoneNumber = 3134567890 });

                _context.vacationCategories.Add(new VacationCategory { CategoryName = "Canada", VacationModels = CanadaTrip });

                List<VacationModel> RenoTrip = new List<VacationModel>();
                RenoTrip.Add(new VacationModel { ID = 2, CustomerName = "AJ", DreamDestination = "Reno", budget = 2700, email = "AJ@someemail.com", phoneNumber = 3121578901 });

                _context.vacationCategories.Add(new VacationCategory { CategoryName = "United States", VacationModels = RenoTrip });

                List<VacationModel> ItalyTrip = new List<VacationModel>();
                ItalyTrip.Add(new VacationModel { ID = 3, CustomerName = "Marian", DreamDestination = "Rome, Italy", budget = 7500, email = "Marian@someemail.com", phoneNumber = 3121578907 });

                _context.vacationCategories.Add(new VacationCategory { CategoryName = "Europe", VacationModels = ItalyTrip });

                await _context.SaveChangesAsync();
            }

            ViewBag.selectedCategory = category;

            if(string.IsNullOrEmpty(category))
            {
                return RedirectToAction("SuggestedDestinations", "Index");
            } 

            //GO TO VIEWS/VACATIONS/INDEX            

            return Content("Thank you! Now, just sit back and relax as out agents review your request!"); //<= After the form is completed?
        }
        
        
        public async Task<IActionResult> Details(int? id)
        {
            VacationModel model = await _context.VacationModels.FindAsync(id);

            return View(model);
        }
                
        [HttpPost]
        public async Task<IActionResult> Details(int? id, int quantity, string color)
        {
            VacationCart cart = null;

            if(User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                
                //cart = await _context.VacationCarts.Include(x => x.VacationModelVacationCarts).FirstOrDefault(x => x.Applicationuserid == currentUser.Id);                

                if (cart == null)
                {
                    cart = new VacationCart();
                    cart.Applicationuserid = currentUser.Id;
                    cart.DateCreated = DateTime.Now;
                    cart.DateLastModified = DateTime.Now;
                    _context.VacationCarts.Add(cart);
                }
            } 

            else
            {
                if(Request.Cookies.ContainsKey("cart_id")) //All future cookie references MUST have this!!!
                {
                    int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                    cart = _context.VacationCarts.Include(x => x.VacationModelVacationCarts).FirstOrDefault(x => x.id == existingCartID);
                    cart.DateLastModified = DateTime.Now;
                } 

                if (cart == null)
                {
                    cart = new VacationCart
                    {
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now,                      
                    };

                    _context.VacationCarts.Add(cart);
                } 

            }

            VacationModelVacationCart product = cart.VacationModelVacationCarts.FirstOrDefault(x => x.vacationModelId == id);

            if(product == null)
            {
                product = new VacationModelVacationCart
                {
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    vacationModelId = id ?? 0,
                    Quantity = 0
                };

                cart.VacationModelVacationCarts.Add(product);
            }
            
            product.Quantity += quantity;
            product.DateLastModified = DateTime.Now;

            _context.SaveChanges();

            if(!User.Identity.IsAuthenticated)
            {
                Response.Cookies.Append("cart_id", cart.id.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(9)
                });
            }

            return RedirectToAction("index", "CartController");
        }

    }

}

    
 //[authorize] => allow anyone to log in.
        //[Authorize(Roles = "Administrator")] => only administrators can log in.


        //Make sure you have "using" for List.


        //Regarding the If/Else: This is for the "USA" under the _Layout.cshtml. So, basically, if the user enters nothing, the program will "Get all vacation options" and even though I did not program this in, it will display all vacations.

        //BUT... if the user enters "Las Vegas" or "Reno", then it will return the word "Las Vegas" or "Reno" depending upon the user's input.

        //The problem: What if there are 1,795,358 possible options? That is A LOT of If/Else and this is where SQL will eventually come in.


        /*
        else if(USA.ToLowerInvariant() == "books")
        {

        } 
        */
    
                

       
    

