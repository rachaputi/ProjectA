using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Controllers
{
    public class VehicleAllocationsController : Controller
    {
        private readonly TransportManagementSystemUpdatedContext _context;

        public VehicleAllocationsController(TransportManagementSystemUpdatedContext context)
        {
            _context = context;
        }

        // GET: VehicleAllocations
        public async Task<IActionResult> Index()
        {
            var transportManagementSystemUpdatedContext = _context.VehicleAllocation.Include(v => v.Employee).Include(v => v.RouteNumberNavigation).Include(v => v.VehicleNumberNavigation);
            return View(await transportManagementSystemUpdatedContext.ToListAsync());
        }

        // GET: VehicleAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleAllocation = await _context.VehicleAllocation
                .Include(v => v.Employee)
                .Include(v => v.RouteNumberNavigation)
                .Include(v => v.VehicleNumberNavigation)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (vehicleAllocation == null)
            {
                return NotFound();
            }

            return View(vehicleAllocation);
        }

        // GET: VehicleAllocations/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["RouteNumber"] = new SelectList(_context.Route, "RouteNumber", "RouteNumber");
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicle, "VehicleNumber", "VehicleNumber");
            return View();
        }

        // POST: VehicleAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,EmployeeId,RouteNumber,Location,VehicleNumber")] VehicleAllocation vehicleAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", vehicleAllocation.EmployeeId);
            ViewData["RouteNumber"] = new SelectList(_context.Route, "RouteNumber", "RouteNumber", vehicleAllocation.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicle, "VehicleNumber", "VehicleNumber", vehicleAllocation.VehicleNumber);
            return View(vehicleAllocation);
        }

        // GET: VehicleAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleAllocation = await _context.VehicleAllocation.FindAsync(id);
            if (vehicleAllocation == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", vehicleAllocation.EmployeeId);
            ViewData["RouteNumber"] = new SelectList(_context.Route, "RouteNumber", "RouteNumber", vehicleAllocation.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicle, "VehicleNumber", "VehicleNumber", vehicleAllocation.VehicleNumber);
            return View(vehicleAllocation);
        }

        // POST: VehicleAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,EmployeeId,RouteNumber,Location,VehicleNumber")] VehicleAllocation vehicleAllocation)
        {
            if (id != vehicleAllocation.AllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleAllocationExists(vehicleAllocation.AllocationId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", vehicleAllocation.EmployeeId);
            ViewData["RouteNumber"] = new SelectList(_context.Route, "RouteNumber", "RouteNumber", vehicleAllocation.RouteNumber);
            ViewData["VehicleNumber"] = new SelectList(_context.Vehicle, "VehicleNumber", "VehicleNumber", vehicleAllocation.VehicleNumber);
            return View(vehicleAllocation);
        }

        // GET: VehicleAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleAllocation = await _context.VehicleAllocation
                .Include(v => v.Employee)
                .Include(v => v.RouteNumberNavigation)
                .Include(v => v.VehicleNumberNavigation)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (vehicleAllocation == null)
            {
                return NotFound();
            }

            return View(vehicleAllocation);
        }

        // POST: VehicleAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleAllocation = await _context.VehicleAllocation.FindAsync(id);
            _context.VehicleAllocation.Remove(vehicleAllocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleAllocationExists(int id)
        {
            return _context.VehicleAllocation.Any(e => e.AllocationId == id);
        }
    }
}
