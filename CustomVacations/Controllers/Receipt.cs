using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomVacations.Data;
using CustomVacations.Models;

namespace CustomVacations.Controllers
{
    public class Receipt : Controller
    {
        private readonly ApplicationDbContext _context;

        public Receipt(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receipt
        public async Task<IActionResult> Index() //This will go to the VIEW Receipt/Index and display the items on the receipt.
        {
            return View(await _context.VacationOrder.ToListAsync());
        }

        // GET: Receipt/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationOrder = await _context.VacationOrder.Include(x => x.VacationOrderDestinationDetails)
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationOrder == null)
            {
                return NotFound();
            }

            return View(vacationOrder);
        }

        // GET: Receipt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receipt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,email,streetaddress")] VacationOrder vacationOrder)
        {
            if (ModelState.IsValid)
            {
                vacationOrder.id = Guid.NewGuid();
                _context.Add(vacationOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacationOrder);
        }

        // GET: Receipt/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationOrder = await _context.VacationOrder.SingleOrDefaultAsync(m => m.id == id);
            if (vacationOrder == null)
            {
                return NotFound();
            }
            return View(vacationOrder);
        }

        // POST: Receipt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,email,streetaddress")] VacationOrder vacationOrder)
        {
            if (id != vacationOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationOrderExists(vacationOrder.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vacationOrder);
        }

        // GET: Receipt/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationOrder = await _context.VacationOrder
                .SingleOrDefaultAsync(m => m.id == id);
            if (vacationOrder == null)
            {
                return NotFound();
            }

            return View(vacationOrder);
        }

        // POST: Receipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vacationOrder = await _context.VacationOrder.SingleOrDefaultAsync(m => m.id == id);
            _context.VacationOrder.Remove(vacationOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationOrderExists(Guid id)
        {
            return _context.VacationOrder.Any(e => e.id == id);
        }
    }
}
