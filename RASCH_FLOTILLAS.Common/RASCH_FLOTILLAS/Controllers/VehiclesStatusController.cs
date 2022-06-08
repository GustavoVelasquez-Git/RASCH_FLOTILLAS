using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RASCH_FLOTILLAS.Data;
using RASCH_FLOTILLAS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RASCH_FLOTILLAS.Controllers
{
    public class VehiclesStatusController : Controller
    {
        private readonly DataContext _context;

        public VehiclesStatusController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleStatus.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleStatus vehicleStatus)
        {

            try
            {
                _context.Add(vehicleStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este estado del vehículo.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }

            return View(vehicleStatus);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleStatus vehicleStatus = await _context.VehicleStatus.FindAsync(id);
            if (vehicleStatus == null)
            {
                return NotFound();
            }

            return View(vehicleStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleStatus VehicleStatus)
        {
            if (id != VehicleStatus.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(VehicleStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este estado del vehículo.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);

            }
            return View(VehicleStatus);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleStatus vehicleStatus = await _context.VehicleStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleStatus == null)
            {
                return NotFound();
            }

            _context.VehicleStatus.Remove(vehicleStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}