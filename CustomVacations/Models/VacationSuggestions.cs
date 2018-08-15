using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Models
{
    public class VacationSuggestions
    {
        public int id { get; set; }
        public string Destination { get; set; }
        public string Attractions { get; set; }
        public string BestTimeToGo { get; set; }

        public string VacationCategoryName { get; set; } //This will be used as a KEY that will be used to return to the VIEW, all of the CATEGORIES of vacations users are interested in seeing. So, for instance: If the user wants to see all the "US" vacations, the user enters "US" in SuggestedDestinations Controller and out pops the "US" destinations.
    }
}
