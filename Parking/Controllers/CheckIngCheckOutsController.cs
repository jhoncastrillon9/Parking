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
    public class CheckIngCheckOutsController : Controller
    {
        private readonly ParkingContext _context;

        public CheckIngCheckOutsController(ParkingContext context)
        {
            _context = context;
        }

        // GET: CheckIngCheckOuts
        public async Task<IActionResult> Index()
        {
              return _context.Movie != null ? 
                          View(await _context.Movie.ToListAsync()) :
                          Problem("Entity set 'ParkingContext.CheckIngCheckOut'  is null.");
        }

        // GET: CheckIngCheckOuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CheckIngCheckOut == null)
            {
                return NotFound();
            }

            var checkIngCheckOut = await _context.CheckIngCheckOut
                .FirstOrDefaultAsync(m => m.CheckIngCheckOutId == id);
            if (checkIngCheckOut == null)
            {
                return NotFound();
            }

            return View(checkIngCheckOut);
        }

        // GET: CheckIngCheckOuts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckIngCheckOuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckIngCheckOutId,VehicleId,TypeCheckId,DateCreate")] CheckIngCheckOut checkIngCheckOut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIngCheckOut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkIngCheckOut);
        }

        // GET: CheckIngCheckOuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CheckIngCheckOut == null)
            {
                return NotFound();
            }

            var checkIngCheckOut = await _context.CheckIngCheckOut.FindAsync(id);
            if (checkIngCheckOut == null)
            {
                return NotFound();
            }
            return View(checkIngCheckOut);
        }

        // POST: CheckIngCheckOuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckIngCheckOutId,VehicleId,TypeCheckId,DateCreate")] CheckIngCheckOut checkIngCheckOut)
        {
            if (id != checkIngCheckOut.CheckIngCheckOutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkIngCheckOut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckIngCheckOutExists(checkIngCheckOut.CheckIngCheckOutId))
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
            return View(checkIngCheckOut);
        }

        // GET: CheckIngCheckOuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CheckIngCheckOut == null)
            {
                return NotFound();
            }

            var checkIngCheckOut = await _context.CheckIngCheckOut
                .FirstOrDefaultAsync(m => m.CheckIngCheckOutId == id);
            if (checkIngCheckOut == null)
            {
                return NotFound();
            }

            return View(checkIngCheckOut);
        }

        // POST: CheckIngCheckOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CheckIngCheckOut == null)
            {
                return Problem("Entity set 'ParkingContext.CheckIngCheckOut'  is null.");
            }
            var checkIngCheckOut = await _context.CheckIngCheckOut.FindAsync(id);
            if (checkIngCheckOut != null)
            {
                _context.CheckIngCheckOut.Remove(checkIngCheckOut);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckIngCheckOutExists(int id)
        {
          return (_context.CheckIngCheckOut?.Any(e => e.CheckIngCheckOutId == id)).GetValueOrDefault();
        }
    }
}
