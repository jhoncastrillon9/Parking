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
    public class ParkingCellsController : Controller
    {
        private readonly ParkingContext _context;

        public ParkingCellsController(ParkingContext context)
        {
            _context = context;
        }

        // GET: ParkingCells
        public async Task<IActionResult> Index()
        {
              return _context.ParkingCell != null ? 
                          View(await _context.ParkingCell.ToListAsync()) :
                          Problem("Entity set 'ParkingContext.ParkingCell'  is null.");
        }

        // GET: ParkingCells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingCell == null)
            {
                return NotFound();
            }

            var parkingCell = await _context.ParkingCell
                .FirstOrDefaultAsync(m => m.ParkingCellId == id);
            if (parkingCell == null)
            {
                return NotFound();
            }

            return View(parkingCell);
        }

        // GET: ParkingCells/Create
        public async Task<IActionResult> Create()
        {           
            var ParkiCells=  await _context.ParkingCellStatus.ToListAsync();            
            ViewBag.ParkingCellStatus = new SelectList(ParkiCells, "ParkingCellStatusId", "Name");
            return View();
        }

        // POST: ParkingCells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkingCellId,Name,Note,ParkingCellStatusId")] ParkingCell parkingCell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingCell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingCell);
        }

        // GET: ParkingCells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingCell == null)
            {
                return NotFound();
            }

            var parkingCell = await _context.ParkingCell.FindAsync(id);
            if (parkingCell == null)
            {
                return NotFound();
            }
            return View(parkingCell);
        }

        // POST: ParkingCells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkingCellId,Name,Note,ParkingCellStatusId")] ParkingCell parkingCell)
        {
            if (id != parkingCell.ParkingCellId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingCell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingCellExists(parkingCell.ParkingCellId))
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
            return View(parkingCell);
        }

        // GET: ParkingCells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingCell == null)
            {
                return NotFound();
            }

            var parkingCell = await _context.ParkingCell
                .FirstOrDefaultAsync(m => m.ParkingCellId == id);
            if (parkingCell == null)
            {
                return NotFound();
            }

            return View(parkingCell);
        }

        // POST: ParkingCells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingCell == null)
            {
                return Problem("Entity set 'ParkingContext.ParkingCell'  is null.");
            }
            var parkingCell = await _context.ParkingCell.FindAsync(id);
            if (parkingCell != null)
            {
                _context.ParkingCell.Remove(parkingCell);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingCellExists(int id)
        {
          return (_context.ParkingCell?.Any(e => e.ParkingCellId == id)).GetValueOrDefault();
        }
    }
}
