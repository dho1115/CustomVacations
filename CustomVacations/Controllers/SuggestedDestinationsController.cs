using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomVacations.Models;
using CustomVacations.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CustomVacations.Controllers
{
    public class SuggestedDestinationsController : Controller 
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public SuggestedDestinationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        
        public async Task<IActionResult> Index(string category)
        {
            if(await _context.GetVacationSuggestions.CountAsync() == 0)
            {
                List<VacationSuggestions> vacationideas = new List<VacationSuggestions>();

                vacationideas.Add(new VacationSuggestions { Destination = "Reno", Attractions = "Lake Tahoe, Virginia City, SilverLegacy Hotel", BestTimeToGo = "Spring" });               

                vacationideas.Add(new VacationSuggestions { Destination = "Las Vegas", Attractions = "Cirque Du Soleil, Grand Canyon, #1 Nightlife!", BestTimeToGo = "November/Early December when you get the best deals!" });

                vacationideas.Add(new VacationSuggestions { Destination = "South Beach", Attractions = "Ocean Drive, Beaches, food!", BestTimeToGo = "January" });

                vacationideas.Add(new VacationSuggestions { Destination = "Costa Rica", Attractions = "nature, Amazon rainforest, food", BestTimeToGo = "December to April" });

                vacationideas.Add(new VacationSuggestions { Destination = "Peru", Attractions = "Amazon, wildlife, tours", BestTimeToGo = "May to September" });

                vacationideas.Add(new VacationSuggestions { Destination = "France", Attractions = "Eiffel Tower, Paris, nightlife.", BestTimeToGo = "April-June" });

                vacationideas.Add(new VacationSuggestions { Destination = "Japan", Attractions = "Anime, technology hub, #1 friendliest people", BestTimeToGo = "September to November" });

                return View(vacationideas);                
            }

            ViewBag.selectedCategory = category;
            List<VacationSuggestions> model;

            if(string.IsNullOrEmpty(category))
            {
                model = await this._context.GetVacationSuggestions.ToListAsync(); //What this means is, if the user has no idea where to go, the string category will be either null or empty and if that happens, it will generate the above list of vacations.
            }
            /*
            else
            {
                model = await this._context.GetVacationSuggestions.Where(x => x.VacationCategoryName == category)
            } 
            */

            return Content("Category Not Found");
        }

        List<VacationSuggestions> vacationideas = new List<VacationSuggestions>();        
    }
}