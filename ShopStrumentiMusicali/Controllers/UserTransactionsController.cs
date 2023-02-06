using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;

namespace ShopStrumentiMusicali.Controllers
{
    public class UserTransactionsController : Controller
    {
        private readonly ParamusicContext _context;

        public UserTransactionsController(ParamusicContext context)
        {
            _context = context;
        }

        // GET: UserTransactions
        public async Task<IActionResult> Index()
        {
            var paramusicContext = _context.UserTransactions.Include(u => u.Instrument);
            return View(await paramusicContext.ToListAsync());
        }

        // GET: UserTransactions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserTransactions == null)
            {
                return NotFound();
            }

            var userTransaction = await _context.UserTransactions
                .Include(u => u.Instrument)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTransaction == null)
            {
                return NotFound();
            }

            return View(userTransaction);
        }

        // GET: UserTransactions/Create
        public IActionResult Create()
        {
            ViewData["InstrumentID"] = new SelectList(_context.Instruments, "Id", "Id");
            return View();
        }

        // POST: UserTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransactionDate,TransactionQuantity,InstrumentID")] UserTransaction userTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrumentID"] = new SelectList(_context.Instruments, "Id", "Id", userTransaction.InstrumentID);
            return View(userTransaction);
        }

        // GET: UserTransactions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserTransactions == null)
            {
                return NotFound();
            }

            var userTransaction = await _context.UserTransactions.FindAsync(id);
            if (userTransaction == null)
            {
                return NotFound();
            }
            ViewData["InstrumentID"] = new SelectList(_context.Instruments, "Id", "Id", userTransaction.InstrumentID);
            return View(userTransaction);
        }

        // POST: UserTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TransactionDate,TransactionQuantity,InstrumentID")] UserTransaction userTransaction)
        {
            if (id != userTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTransactionExists(userTransaction.Id))
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
            ViewData["InstrumentID"] = new SelectList(_context.Instruments, "Id", "Id", userTransaction.InstrumentID);
            return View(userTransaction);
        }

        // GET: UserTransactions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserTransactions == null)
            {
                return NotFound();
            }

            var userTransaction = await _context.UserTransactions
                .Include(u => u.Instrument)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTransaction == null)
            {
                return NotFound();
            }

            return View(userTransaction);
        }

        // POST: UserTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserTransactions == null)
            {
                return Problem("Entity set 'ParamusicContext.UserTransactions'  is null.");
            }
            var userTransaction = await _context.UserTransactions.FindAsync(id);
            if (userTransaction != null)
            {
                _context.UserTransactions.Remove(userTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTransactionExists(string id)
        {
          return _context.UserTransactions.Any(e => e.Id == id);
        }
    }
}
