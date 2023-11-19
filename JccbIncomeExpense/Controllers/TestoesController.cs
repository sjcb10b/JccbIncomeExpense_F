using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JccbIncomeExpense.Data;
using JccbIncomeExpense.Models;

namespace JccbIncomeExpense.Controllers
{
    public class TestoesController : Controller
    {
        private readonly ApplicationContext _context;

        public TestoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Testoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Testos.ToListAsync());
        }

        // GET: Testoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Testos == null)
            {
                return NotFound();
            }

            var testo = await _context.Testos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testo == null)
            {
                return NotFound();
            }

            return View(testo);
        }

        // GET: Testoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Testo testo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testo);
        }

        // GET: Testoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Testos == null)
            {
                return NotFound();
            }

            var testo = await _context.Testos.FindAsync(id);
            if (testo == null)
            {
                return NotFound();
            }
            return View(testo);
        }

        // POST: Testoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Testo testo)
        {
            if (id != testo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestoExists(testo.Id))
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
            return View(testo);
        }

        // GET: Testoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Testos == null)
            {
                return NotFound();
            }

            var testo = await _context.Testos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testo == null)
            {
                return NotFound();
            }

            return View(testo);
        }

        // POST: Testoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Testos == null)
            {
                return Problem("Entity set 'ApplicationContext.Testos'  is null.");
            }
            var testo = await _context.Testos.FindAsync(id);
            if (testo != null)
            {
                _context.Testos.Remove(testo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestoExists(int id)
        {
          return _context.Testos.Any(e => e.Id == id);
        }
    }
}
