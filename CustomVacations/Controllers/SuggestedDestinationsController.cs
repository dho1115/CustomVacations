using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomVacations.Models;

namespace CustomVacations.Controllers
{
    public class SuggestedDestinationsController : Controller
    {
        List<VacationSuggestions> vacationideas = new List<VacationSuggestions>();

        public IActionResult Index(string USA)
        {
            vacationideas.Add(new VacationSuggestions { Destination = "Reno", Attractions = "Lake Tahoe, Virginia City, SilverLegacy Hotel" });

            vacationideas.Add(new VacationSuggestions { Destination = "Las Vegas", Attractions = "Cirque Du Soleil, Grand Canyon, #1 Nightlife!" });

            vacationideas.Add(new VacationSuggestions { Destination = "South Beach", Attractions = "Ocean Drive, Beaches, food!" });

            vacationideas.Add(new VacationSuggestions { Destination = "Costa Rica", Attractions = "nature, Amazon rainforest, food" });

            vacationideas.Add(new VacationSuggestions { Destination = "Peru", Attractions = "Amazon, wildlife, tours" });

            vacationideas.Add(new VacationSuggestions { Destination = "France", Attractions = "Eiffel Tower, Paris, nightlife." });

            vacationideas.Add(new VacationSuggestions { Destination = "Japan", Attractions ="Anime, technology hub, #1 friendliest people" });

           return View(vacationideas);
        }
    }
}