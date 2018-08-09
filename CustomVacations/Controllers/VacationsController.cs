using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomVacations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CustomVacations.Controllers
{
    public class VacationsController : Controller
    {
        public IActionResult Index(string USA)
        {
            //Make sure you have "using" for List.
            List<VacationModel> vacationmodel = new List<VacationModel>();
           
            //Regarding the If/Else: This is for the "USA" under the _Layout.cshtml. So, basically, if the user enters nothing, the program will "Get all vacation options" and even though I did not program this in, it will display all vacations.

            //BUT... if the user enters "Las Vegas" or "Reno", then it will return the word "Las Vegas" or "Reno" depending upon the user's input.

            //The problem: What if there are 1,795,358 possible options? That is A LOT of If/Else and this is where SQL will eventually come in.

            if (string.IsNullOrEmpty(USA))
            {
                Console.WriteLine("Get all vacation options");

                vacationmodel.Add(new VacationModel
                {
                    CustomerName = "Jamie (from vacationscontroller.cs)",
                    email = "Jamie@someemail.com",
                    phoneNumber = 3124567890,
                    DreamDestination = "Reno",
                    budget = 2500,
                    DestinationDescription = "Wanna go to Reno."
                });

                vacationmodel.Add(new VacationModel
                {
                    CustomerName = "Kelley (from vacationscontroller.cs)",
                    email = "KelleyZ@someemail.com",
                    phoneNumber = 3334445567,
                    DreamDestination = "South Beach, Miami, Florida",
                    budget = 2500,
                    DestinationDescription = "Wanna go to SouthBeach."
                });

                vacationmodel.Add(new VacationModel
                {
                    CustomerName = "AJ (from vacationscontroller.cs)",
                    email = "AlexJay@someemail.com",
                    phoneNumber = 3334445567,
                    DreamDestination = "New York, NY",
                    budget = 3000,
                    DestinationDescription = "Wanna go to NYC."
                });
            }

            else if(USA.ToLowerInvariant() == "Las_Vegas")
            {
                ViewData["Title"] = "Las_Vegas";
                Console.WriteLine("WELCOME TO VEGAS, BABY!!!");
            } 

            else if(USA.ToLowerInvariant() == "Reno")
            {
                ViewData["Title"] = "Reno";
                Console.WriteLine("RENO REALLY ROCKS!!!");                
            } 

            /*
            else if(USA.ToLowerInvariant() == "books")
            {

            } 
            */
            return View(vacationmodel);
        } 
                       
        public IActionResult Details(int? id)
        {
            VacationModel vacationmodel = new VacationModel
            {
                ID = 1,
                CustomerName = "Jamie",
                email = "JamieIII@email.com",
                phoneNumber = 1234567,
                DreamDestination = "New Orleans",
                budget = 1750,
                DestinationDescription = "Wanna go to New Orleans"
            };

            return View(vacationmodel);
        } 

        /*
        [HttpPost]
        public IActionResult Details(int? id, int quantity, string color)
        {
            Console.WriteLine("User selected " + id.ToString()); //This Console.Writeline is used as a "confirmation" to indicate that your piece of code works. If it did work and it did capture the client's information, then this console.WriteLine should display the id.ToString() of what the user selected. If it did not, then it would not show anything. Depending on how complicatied this is, this could be done via a form.

            return RedirectToAction("Index", "Cart"); //So, when the user goes to the cart, this sends a piece of code to update the cart in the database. This happens as a POST rather than a GET.
        } 
        */

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(CheckoutModel modelinfo, int? id) //This code will check to see if the user actually entered the correct email address.
        {
            if(string.IsNullOrEmpty(modelinfo.email))
            {
                return View();
            }
            
            else
            {
                return RedirectToAction("Index", "Receipt", new Guid(id = new Guid.NewGuid()));
            }
        } 
        */
    } 

}