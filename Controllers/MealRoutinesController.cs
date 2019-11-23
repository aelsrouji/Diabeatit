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
    public class MealRoutinesController : Controller
    {
        private readonly Diabetes_HelperContext _context;

        public MealRoutinesController(Diabetes_HelperContext context)
        {
            _context = context;
        }

        // GET: MealRoutines
        public async Task<IActionResult> Index()
        {
            return View(await _context.MealRoutine.ToListAsync());
        }

        // GET: MealRoutines/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealRoutine = await _context.MealRoutine
                .FirstOrDefaultAsync(m => m.RoutineId == id);
            if (mealRoutine == null)
            {
                return NotFound();
            }

            return View(mealRoutine);
        }

        // GET: MealRoutines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealRoutines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoutineId,UserId,Active,FromDate,ToDate")] MealRoutine mealRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealRoutine);
        }

        // GET: MealRoutines/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealRoutine = await _context.MealRoutine.FindAsync(id);
            if (mealRoutine == null)
            {
                return NotFound();
            }
            return View(mealRoutine);
        }

        // POST: MealRoutines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("RoutineId,UserId,Active,FromDate,ToDate")] MealRoutine mealRoutine)
        {
            if (id != mealRoutine.RoutineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealRoutineExists(mealRoutine.RoutineId))
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
            return View(mealRoutine);
        }

        // GET: MealRoutines/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealRoutine = await _context.MealRoutine
                .FirstOrDefaultAsync(m => m.RoutineId == id);
            if (mealRoutine == null)
            {
                return NotFound();
            }

            return View(mealRoutine);
        }

        // POST: MealRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mealRoutine = await _context.MealRoutine.FindAsync(id);
            _context.MealRoutine.Remove(mealRoutine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealRoutineExists(long id)
        {
            return _context.MealRoutine.Any(e => e.RoutineId == id);
        }
    }
}
