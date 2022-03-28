using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayrollCalculator.Contexts;
using PayrollCalculator.Models;

namespace PayrollCalculator.Controllers
{
    public class PieceworkWorkerModelsController : Controller
    {
        private readonly PieceworkWorkerContext _context;

        public PieceworkWorkerModelsController(PieceworkWorkerContext context)
        {
            _context = context;
        }

        // GET: PieceworkWorkerModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workers.ToListAsync());
        }

        // GET: PieceworkWorkerModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkWorkerModel);
        }

        // GET: PieceworkWorkerModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PieceworkWorkerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Messages,IsSenior")] PieceworkWorkerModel pieceworkWorkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceworkWorkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceworkWorkerModel);
        }

        // GET: PieceworkWorkerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.Workers.FindAsync(id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }
            return View(pieceworkWorkerModel);
        }

        // POST: PieceworkWorkerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Messages,IsSenior")] PieceworkWorkerModel pieceworkWorkerModel)
        {
            if (id != pieceworkWorkerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceworkWorkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceworkWorkerModelExists(pieceworkWorkerModel.Id))
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
            return View(pieceworkWorkerModel);
        }

        // GET: PieceworkWorkerModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkWorkerModel);
        }

        // POST: PieceworkWorkerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pieceworkWorkerModel = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(pieceworkWorkerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieceworkWorkerModelExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}
