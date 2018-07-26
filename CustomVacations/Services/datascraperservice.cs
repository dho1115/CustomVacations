using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CustomVacations.Services
{
    public class datascraperservice
    {
        public static void scrape()
        {
            string serviceURL = "https://datakick.org/api/items";
            System.Net.WebRequest req = System.Net.WebRequest.Create(serviceURL);
            System.Net.WebResponse response = req.GetResponse();
            Stream s = response.GetResponseStream();

            //Now, you want to convert stream to JSON data.
            /*
            Newtonsoft.Json.JsonTextReader jsontextreader = new Newtonsoft.Json.JsonTextReader(sr);
            var serializer = new Newtonsoft.Json.JsonSerializer();
            object result;

            Newtonsoft.Json.JsonConvert.DeserializeObject() {

            } 
            */
        } 

        public class DataClickObject
        {
            public string gtin14 { get; set; }
            public string name { get; set; }
            public string author { get; set; }
            public string format { get; set; }
            public int? pages { get; set; }
        }
    }
}
