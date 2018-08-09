using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomVacations.Models;

namespace CustomVacations.Controllers
{
    //NOTE: May want to delete the other cart controller.
    public class CartControllerController : Controller
    {
        public IActionResult Index()
        {
            VacationCart cart = new VacationCart
            {
                id = 1,

            };

            return View();
            /*
                 BeachCart model = new BeachCart //NOTE: BeachCart was generated as a new class.
                 {
                     id = 1;
                     products = new BeachCart[]{
                     new BeachProduct(
                     id=1;
                     nameof = "red Umbrella",
                     Price: 12.99,
                     Description: 
                     ImagePath: 
                     );

                     new BeachProduct(
                     );
                     }

                 }

                 To remove a product: 
                 Public IActionResult Remove(int id) {}

                 NEXT: Below the table, do a checkout button but it won't work until you build a CHECKOUT CONTROLLER and a VIEW.
                 */

            //How to render out your composite model:
            //Under the index.cshtml: @if(model.Products.Count == 0) {"You have nothing in your cart."}. Else {
            //<table>@foreach(var product in Model.Products) {<tr><td>@(product.Name)</td></tr>, @(product.Price).toString...</table>

        


            
        }
    }
}