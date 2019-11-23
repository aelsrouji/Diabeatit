using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diabeatit.Models;

namespace Diabeatit.Controllers
{
    public class LogBookController : Controller
    {
        private readonly Diabetes_HelperContext _context;

        public LogBookController(Diabetes_HelperContext context)
        {
            _context = context;
        }

        // GET: LogBook
        public async Task<IActionResult> Index()
        {
            return View(await _context.LogBook.ToListAsync());
        }

        // GET: LogBook/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logBook = await _context.LogBook
                .FirstOrDefaultAsync(m => m.LogBookId == id);
            if (logBook == null)
            {
                return NotFound();
            }

            return View(logBook);
        }

        // GET: LogBook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogBookId,UserId,LogDate,LogTime,MeterReading,LogNotes,RoutineId")] LogBook logBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logBook);
        }

        // GET: LogBook/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logBook = await _context.LogBook.FindAsync(id);
            if (logBook == null)
            {
                return NotFound();
            }
            return View(logBook);
        }

        // POST: LogBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LogBookId,UserId,LogDate,LogTime,MeterReading,LogNotes,RoutineId")] LogBook logBook)
        {
            if (id != logBook.LogBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogBookExists(logBook.LogBookId))
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
            return View(logBook);
        }

        // GET: LogBook/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logBook = await _context.LogBook
                .FirstOrDefaultAsync(m => m.LogBookId == id);
            if (logBook == null)
            {
                return NotFound();
            }

            return View(logBook);
        }

        // POST: LogBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var logBook = await _context.LogBook.FindAsync(id);
            _context.LogBook.Remove(logBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogBookExists(long id)
        {
            return _context.LogBook.Any(e => e.LogBookId == id);
        }
    }
}
