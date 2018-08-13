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
    }
}
