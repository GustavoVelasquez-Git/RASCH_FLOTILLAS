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
    public class VehiclesTypesController : Controller
    {
        private readonly DataContext _context;

        public VehiclesTypesController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesVehicles.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypesVehicle typesVehicle)
        {

            try
            {
                _context.Add(typesVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehículo.");
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

            return View(typesVehicle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypesVehicle typesVehicle = await _context.TypesVehicles.FindAsync(id);
            if (typesVehicle == null)
            {
                return NotFound();
            }

            return View(typesVehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TypesVehicle typesVehicle)
        {
            if (id != typesVehicle.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(typesVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehículo.");
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
            return View(typesVehicle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypesVehicle typesVehicle = await _context.TypesVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesVehicle == null)
            {
                return NotFound();
            }

            _context.TypesVehicles.Remove(typesVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
