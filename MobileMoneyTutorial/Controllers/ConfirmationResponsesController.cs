using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileMoneyTutorial.Models;

namespace MobileMoneyTutorial.Controllers
{
    public class ConfirmationResponsesController : Controller
    {
        private readonly TestDbContext _context;

        public ConfirmationResponsesController(TestDbContext context)
        {
            _context = context;
        }

        // GET: ConfirmationResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConfirmationResponses.ToListAsync());
        }

        // GET: ConfirmationResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmationResponse = await _context.ConfirmationResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confirmationResponse == null)
            {
                return NotFound();
            }

            return View(confirmationResponse);
        }

        // GET: ConfirmationResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfirmationResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransactionType,TransID,TransTime,TransAmount,BusinessShortCode,BillRefNumber,InvoiceNumber,OrgAccountBalance,ThirdPartyTransID,MSISDN,FirstName,MiddleName,LastName")] ConfirmationResponse confirmationResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confirmationResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confirmationResponse);
        }

        // GET: ConfirmationResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmationResponse = await _context.ConfirmationResponses.FindAsync(id);
            if (confirmationResponse == null)
            {
                return NotFound();
            }
            return View(confirmationResponse);
        }

        // POST: ConfirmationResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransactionType,TransID,TransTime,TransAmount,BusinessShortCode,BillRefNumber,InvoiceNumber,OrgAccountBalance,ThirdPartyTransID,MSISDN,FirstName,MiddleName,LastName")] ConfirmationResponse confirmationResponse)
        {
            if (id != confirmationResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confirmationResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfirmationResponseExists(confirmationResponse.Id))
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
            return View(confirmationResponse);
        }

        // GET: ConfirmationResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmationResponse = await _context.ConfirmationResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confirmationResponse == null)
            {
                return NotFound();
            }

            return View(confirmationResponse);
        }

        // POST: ConfirmationResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confirmationResponse = await _context.ConfirmationResponses.FindAsync(id);
            _context.ConfirmationResponses.Remove(confirmationResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfirmationResponseExists(int id)
        {
            return _context.ConfirmationResponses.Any(e => e.Id == id);
        }
    }
}
