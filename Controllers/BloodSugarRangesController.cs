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
    public class BloodSugarRangesController : Controller
    {
        private readonly Diabetes_HelperContext _context;

        public BloodSugarRangesController(Diabetes_HelperContext context)
        {
            _context = context;
        }

        // GET: BloodSugarRanges
        public async Task<IActionResult> Index()
        {
            return View(await _context.BloodSugarRange.ToListAsync());
        }

        // GET: BloodSugarRanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodSugarRange = await _context.BloodSugarRange
                .FirstOrDefaultAsync(m => m.BloodSugarRangeId == id);
            if (bloodSugarRange == null)
            {
                return NotFound();
            }

            return View(bloodSugarRange);
        }

        // GET: BloodSugarRanges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodSugarRanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloodSugarRangeId,BloodSugarRangeFrom,BloodSugarRangeTo")] BloodSugarRange bloodSugarRange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodSugarRange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodSugarRange);
        }

        // GET: BloodSugarRanges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodSugarRange = await _context.BloodSugarRange.FindAsync(id);
            if (bloodSugarRange == null)
            {
                return NotFound();
            }
            return View(bloodSugarRange);
        }

        // POST: BloodSugarRanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BloodSugarRangeId,BloodSugarRangeFrom,BloodSugarRangeTo")] BloodSugarRange bloodSugarRange)
        {
            if (id != bloodSugarRange.BloodSugarRangeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodSugarRange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodSugarRangeExists(bloodSugarRange.BloodSugarRangeId))
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
            return View(bloodSugarRange);
        }

        // GET: BloodSugarRanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodSugarRange = await _context.BloodSugarRange
                .FirstOrDefaultAsync(m => m.BloodSugarRangeId == id);
            if (bloodSugarRange == null)
            {
                return NotFound();
            }

            return View(bloodSugarRange);
        }

        // POST: BloodSugarRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodSugarRange = await _context.BloodSugarRange.FindAsync(id);
            _context.BloodSugarRange.Remove(bloodSugarRange);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodSugarRangeExists(int id)
        {
            return _context.BloodSugarRange.Any(e => e.BloodSugarRangeId == id);
        }
    }
}
