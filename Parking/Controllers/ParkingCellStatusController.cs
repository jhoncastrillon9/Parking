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
    public class ParkingCellStatusController : Controller
    {
        private readonly ParkingContext _context;

        public ParkingCellStatusController(ParkingContext context)
        {
            _context = context;
        }

        // GET: ParkingCellStatus
        public async Task<IActionResult> Index()
        {
            return _context.ParkingCellStatus != null ? 
                          View(await _context.ParkingCellStatus.ToListAsync()) :
                          Problem("Entity set 'ParkingContext.ParkingCellStatus'  is null.");             
        }

        // GET: ParkingCellStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingCellStatus == null)
            {
                return NotFound();
            }

            var parkingCellStatus = await _context.ParkingCellStatus
                .FirstOrDefaultAsync(m => m.ParkingCellStatusId == id);
            if (parkingCellStatus == null)
            {
                return NotFound();
            }

            return View(parkingCellStatus);
        }

        // GET: ParkingCellStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingCellStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkingCellStatusId,Name")] ParkingCellStatus parkingCellStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingCellStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingCellStatus);
        }

        // GET: ParkingCellStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingCellStatus == null)
            {
                return NotFound();
            }

            var parkingCellStatus = await _context.ParkingCellStatus.FindAsync(id);
            if (parkingCellStatus == null)
            {
                return NotFound();
            }
            return View(parkingCellStatus);
        }

        // POST: ParkingCellStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkingCellStatusId,Name")] ParkingCellStatus parkingCellStatus)
        {
            if (id != parkingCellStatus.ParkingCellStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingCellStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingCellStatusExists(parkingCellStatus.ParkingCellStatusId))
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
            return View(parkingCellStatus);
        }

        // GET: ParkingCellStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingCellStatus == null)
            {
                return NotFound();
            }

            var parkingCellStatus = await _context.ParkingCellStatus
                .FirstOrDefaultAsync(m => m.ParkingCellStatusId == id);
            if (parkingCellStatus == null)
            {
                return NotFound();
            }

            return View(parkingCellStatus);
        }

        // POST: ParkingCellStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingCellStatus == null)
            {
                return Problem("Entity set 'ParkingContext.ParkingCellStatus'  is null.");
            }
            var parkingCellStatus = await _context.ParkingCellStatus.FindAsync(id);
            if (parkingCellStatus != null)
            {
                _context.ParkingCellStatus.Remove(parkingCellStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingCellStatusExists(int id)
        {
          return (_context.ParkingCellStatus?.Any(e => e.ParkingCellStatusId == id)).GetValueOrDefault();
        }
    }
}
