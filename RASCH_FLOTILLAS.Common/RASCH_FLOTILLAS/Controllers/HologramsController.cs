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
    public class HologramsController : Controller
    {
        private readonly DataContext _context;

        public HologramsController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Holograms.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hologram hologram)
        {

            try
            {
                _context.Add(hologram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este tipo de holograma.");
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

            return View(hologram);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hologram hologram = await _context.Holograms.FindAsync(id);
            if (hologram == null)
            {
                return NotFound();
            }

            return View(hologram);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hologram hologram)
        {
            if (id != hologram.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(hologram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este tipo de holograma.");
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
            return View(hologram);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hologram hologram = await _context.Holograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hologram == null)
            {
                return NotFound();
            }

            _context.Holograms.Remove(hologram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
