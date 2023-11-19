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
    public class InfoincomesController : Controller
    {
        private readonly ApplicationContext _context;

        public InfoincomesController(ApplicationContext context)
        {
            _context = context;
        }


        // GET: Incomecats
        public IActionResult Index()
        {
            return View(_context.SearchReference("").ToList());
        }

        [HttpPost]
        public IActionResult Index(string Reference)
        {
            return View(_context.SearchReference(Reference).ToList());
        }




        //
        // GET: Infoincomes
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.Infoincomes.ToListAsync());
        //}






        // GET: Infoincomes/Details/5
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                ViewData["CategoryName"] = new SelectList(_context.incomecats, "Icategory", "Icategory");
                return View(new Infoincome());
            }
            else
            {
                var infoin = await _context.Infoincomes.FindAsync(id);
                if (infoin == null)
                {
                    return NotFound();
                }
                ViewData["CategoryName"] = new SelectList(_context.incomecats, "Icategory", "Icategory", infoin.Icategory);
                return View(infoin);
            }
        }



        // POST: Infoincomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("IncomeId,Incomename,SaleAmount,Reference,Icategory,Note,Dated")] Infoincome infoincome)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                     
                    _context.Add(infoincome);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    try
                    {
                        _context.Update(infoincome);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!InfoincomeExists(infoincome.IncomeId))
                        { return NotFound(); }
                        else
                        { throw; }


                    }

                }



                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Infoincomes .ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", infoincome) });
        }

        //// GET: Infoincomes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Infoincomes == null)
        //    {
        //        return NotFound();
        //    }

        //    var infoincome = await _context.Infoincomes.FindAsync(id);
        //    if (infoincome == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewData["CategoryName"] = new SelectList(_context.incomecats, "Icategory", "Icategory",  infoincome.Icategory);
        //    return View(infoincome);
        //}

        // POST: Infoincomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IncomeId,Incomename,SaleAmount,Reference,Icategory,Note,Dated")] Infoincome infoincome)
        //{
        //    if (id != infoincome.IncomeId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(infoincome);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!InfoincomeExists(infoincome.IncomeId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(infoincome);
        //}

        // GET: Infoincomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Infoincomes == null)
            {
                return NotFound();
            }

            var infoincome = await _context.Infoincomes
                .FirstOrDefaultAsync(m => m.IncomeId == id);
            if (infoincome == null)
            {
                return NotFound();
            }

            return View(infoincome);
        }

        // POST: Infoincomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Infoincomes == null)
            {
                return Problem("Entity set 'ApplicationContext.Infoincomes'  is null.");
            }
            var infoincome = await _context.Infoincomes.FindAsync(id);
            if (infoincome != null)
            {
                _context.Infoincomes.Remove(infoincome);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoincomeExists(int id)
        {
          return _context.Infoincomes.Any(e => e.IncomeId == id);
        }
    }
}
