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
    public class InsulinDosagesController : Controller
    {
        private readonly Diabetes_HelperContext _context;

        public InsulinDosagesController(Diabetes_HelperContext context)
        {
            _context = context;
        }

        // GET: InsulinDosages
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsulinDosage.ToListAsync());
        }

        // GET: InsulinDosages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insulinDosage = await _context.InsulinDosage
                .FirstOrDefaultAsync(m => m.DosageId == id);
            if (insulinDosage == null)
            {
                return NotFound();
            }

            return View(insulinDosage);
        }

        // GET: InsulinDosages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsulinDosages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosageId,UserId,BloodSugarRangeId,InsulinDosage1")] InsulinDosage insulinDosage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insulinDosage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insulinDosage);
        }

        // GET: InsulinDosages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insulinDosage = await _context.InsulinDosage.FindAsync(id);
            if (insulinDosage == null)
            {
                return NotFound();
            }
            return View(insulinDosage);
        }

        // POST: InsulinDosages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("DosageId,UserId,BloodSugarRangeId,InsulinDosage1")] InsulinDosage insulinDosage)
        {
            if (id != insulinDosage.DosageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insulinDosage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsulinDosageExists(insulinDosage.DosageId))
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
            return View(insulinDosage);
        }

        // GET: InsulinDosages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insulinDosage = await _context.InsulinDosage
                .FirstOrDefaultAsync(m => m.DosageId == id);
            if (insulinDosage == null)
            {
                return NotFound();
            }

            return View(insulinDosage);
        }

        // POST: InsulinDosages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var insulinDosage = await _context.InsulinDosage.FindAsync(id);
            _context.InsulinDosage.Remove(insulinDosage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsulinDosageExists(long id)
        {
            return _context.InsulinDosage.Any(e => e.DosageId == id);
        }
    }
}
