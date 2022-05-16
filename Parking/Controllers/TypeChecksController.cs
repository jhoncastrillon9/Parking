using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Controllers
{
    public class TypeChecksController : Controller
    {
        private readonly ParkingContext _context;

        public TypeChecksController(ParkingContext context)
        {
            _context = context;
        }

        // GET: TypeChecks
        public async Task<IActionResult> Index()
        {
              return _context.Movie != null ? 
                          View(await _context.Movie.ToListAsync()) :
                          Problem("Entity set 'ParkingContext.TypeCheck'  is null.");
        }

        // GET: TypeChecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeCheck == null)
            {
                return NotFound();
            }

            var typeCheck = await _context.TypeCheck
                .FirstOrDefaultAsync(m => m.TypeCheckId == id);
            if (typeCheck == null)
            {
                return NotFound();
            }

            return View(typeCheck);
        }

        // GET: TypeChecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeChecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeCheckId,Name")] TypeCheck typeCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeCheck);
        }

        // GET: TypeChecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeCheck == null)
            {
                return NotFound();
            }

            var typeCheck = await _context.TypeCheck.FindAsync(id);
            if (typeCheck == null)
            {
                return NotFound();
            }
            return View(typeCheck);
        }

        // POST: TypeChecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeCheckId,Name")] TypeCheck typeCheck)
        {
            if (id != typeCheck.TypeCheckId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeCheckExists(typeCheck.TypeCheckId))
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
            return View(typeCheck);
        }

        // GET: TypeChecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeCheck == null)
            {
                return NotFound();
            }

            var typeCheck = await _context.TypeCheck
                .FirstOrDefaultAsync(m => m.TypeCheckId == id);
            if (typeCheck == null)
            {
                return NotFound();
            }

            return View(typeCheck);
        }

        // POST: TypeChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeCheck == null)
            {
                return Problem("Entity set 'ParkingContext.TypeCheck'  is null.");
            }
            var typeCheck = await _context.TypeCheck.FindAsync(id);
            if (typeCheck != null)
            {
                _context.TypeCheck.Remove(typeCheck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeCheckExists(int id)
        {
          return (_context.TypeCheck?.Any(e => e.TypeCheckId == id)).GetValueOrDefault();
        }
    }
}
