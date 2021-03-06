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
            return _context.CheckIngCheckOut != null ?
                        View(await _context.CheckIngCheckOut.ToListAsync()) :
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
            var vehicles = await _context.Vehicles.ToListAsync();
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Plate");

            var typeChecks = await _context.TypeCheck.ToListAsync();
            ViewBag.TypeChecks = new SelectList(typeChecks, "TypeCheckId", "Name");

            return View(checkIngCheckOut);
        }

        // GET: CheckIngCheckOuts/Create
        public async Task<IActionResult> Create()
        {
            var typeChecks = await _context.TypeCheck.ToListAsync();
            ViewBag.TypeChecks = new SelectList(typeChecks, "TypeCheckId", "Name");

            var vehicles = await _context.Vehicles.ToListAsync();
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Plate");
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

        public async Task<IActionResult> CreateChecking()
        {
            var typeChecks = await _context.TypeCheck.ToListAsync();
            ViewBag.TypeChecks = new SelectList(typeChecks, "TypeCheckId", "Name");

            var vehicles = await _context.Vehicles.ToListAsync();
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Plate");
            return View();
        }

        // POST: CheckIngCheckOuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChecking([Bind("CheckIngCheckOutId,VehicleId,TypeCheckId,DateCreate")] CheckIngCheckOut checkIngCheckOut)
        {
            var vehicle = await _context.Vehicles
           .FirstOrDefaultAsync(m => m.VehicleId == checkIngCheckOut.VehicleId);

            var cellForUpdate = _context.ParkingCell
           .FirstOrDefaultAsync(m => m.ParkingCellId == vehicle.ParkingCellId).Result;

            var statusCell = await _context.ParkingCellStatus.FirstOrDefaultAsync(m => m.Name == "Ocupada");
           cellForUpdate.ParkingCellStatusId = statusCell.ParkingCellStatusId;

            var cellUpdate = _context.ParkingCell.Update(cellForUpdate);
             

            var typeCheck = await _context.TypeCheck.ToListAsync();
            checkIngCheckOut.DateCreate = DateTime.Now;
            checkIngCheckOut.TypeCheckId = typeCheck.Where(x => x.Name == "Ingreso").FirstOrDefault().TypeCheckId;
            _context.Add(checkIngCheckOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(checkIngCheckOut);
        }

        public async Task<IActionResult> CreateCheckOut()
        {
            var typeChecks = await _context.TypeCheck.ToListAsync();
            ViewBag.TypeChecks = new SelectList(typeChecks, "TypeCheckId", "Name");

            var vehicles = await _context.Vehicles.ToListAsync();
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Plate");
            return View();
        }

        // POST: CheckIngCheckOuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckOut([Bind("CheckIngCheckOutId,VehicleId,TypeCheckId,DateCreate")] CheckIngCheckOut checkIngCheckOut)
        {

            var vehicle = await _context.Vehicles
            .FirstOrDefaultAsync(m => m.VehicleId == checkIngCheckOut.VehicleId);

            var cellForUpdate = _context.ParkingCell
           .FirstOrDefaultAsync(m => m.ParkingCellId == vehicle.ParkingCellId).Result;

            var statusCell = await _context.ParkingCellStatus.FirstOrDefaultAsync(m => m.Name == "Libre");
            cellForUpdate.ParkingCellStatusId = statusCell.ParkingCellStatusId;

            var cellUpdate = _context.ParkingCell.Update(cellForUpdate);

            var typeCheck = await _context.TypeCheck.ToListAsync();
            checkIngCheckOut.DateCreate = DateTime.Now;
            checkIngCheckOut.TypeCheckId = typeCheck.Where(x => x.Name == "Salida").FirstOrDefault().TypeCheckId;
            _context.Add(checkIngCheckOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

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

            var typeChecks = await _context.TypeCheck.ToListAsync();
            ViewBag.TypeChecks = new SelectList(typeChecks, "TypeCheckId", "Name");

            var vehicles = await _context.Vehicles.ToListAsync();
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Plate");

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
