using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Braintree;
using CustomVacations.Data;
using CustomVacations.Models;
using CustomVacations.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomVacations.Controllers
{
    public class CheckoutController : Controller
    {        
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;
        private IBraintreeGateway _braintreeGateway;

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, IBraintreeGateway braintreeGateway)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
            _braintreeGateway = braintreeGateway;
        }

        public async Task<IActionResult> Index()
        {
            CheckoutModel model = new CheckoutModel();

            if(User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                model.email = currentUser.Email;
            }

            ViewBag.ClientAuthorization = await _braintreeGateway.ClientToken.GenerateAsync();

            return View(model);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutModel model)
        {
            //Here is how it works: Javascript sends the information TO Braintree and Braintree sends the "nonce" back.
            if (ModelState.IsValid)
            {
                VacationOrder order = new VacationOrder
                {
                    email = model.email
                };

                VacationCart cart = null;

                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    cart = _context.VacationCarts.Include(x => x.VacationModelVacationCarts).ThenInclude(x => x.vacationModel).Single(x => x.Applicationuserid == currentUser.Id);
                }

                else if (Request.Cookies.ContainsKey("cart_id"))
                {
                    int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                    cart = _context.VacationCarts.Include(x => x.VacationModelVacationCarts).ThenInclude(x => x.vacationModel).FirstOrDefault(x => x.id == existingCartID); //So, if there is a cookie attached to the cart, then set cart to = the cart, the product AND the existing ID?
                }

                foreach (var item in cart.VacationModelVacationCarts)
                {
                    order.VacationOrderDestinationDetails.Add(new VacationOrderDestinationDetails
                    {
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now,
                        Quantity = item.Quantity,
                        destinationdescription = item.vacationModel.DestinationDescription,
                        destination = item.vacationModel.DreamDestination
                    });
                }

                _context.VacationModelCarts.RemoveRange(cart.VacationModelVacationCarts);

                _context.VacationCarts.Remove(cart); //So, after we listed the items in the foreach, we don't need the cart anymore. We empty they products and disengage the model from the cart (???).

                var result = await _braintreeGateway.Transaction.SaleAsync(new TransactionRequest
                {
                    Amount = order.VacationOrderDestinationDetails.Sum(x => x.Quantity * x.Budget),

                    /* ERROR -- FIX.
                    PaymentMethodNonce = model.Nonce,
                    LineItems = order.VacationOrderDestinationDetails.Select(x => new TransactionLineItemRequest
                    {
                        Description = x.destinationdescription,
                        Name = x.destination,
                        Quantity = x.Quantity,
                        UnitAmount = x.Budget,
                        TotalAmount = x.Budget * x.Quantity
                    })

                    await _emailSender.SendEmailAsync(model.email, " your order " + order.id + " Thank you for ordering!");*/
                });

            }
        return View();
        }                

        //Added new material into checkout controller 8/13/2018.
        //Added new code that will send a confirmation to your email saying , "From Admin: you purchased...".
    }
}