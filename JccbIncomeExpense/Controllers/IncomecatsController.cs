using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JccbIncomeExpense.Data;
using JccbIncomeExpense.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Data.SqlClient;

namespace JccbIncomeExpense.Controllers
{
    public class IncomecatsController : Controller
    {
        private readonly ApplicationContext _context;

        public IncomecatsController(ApplicationContext context)
        {
            _context = context;
        }








        // GET: Incomecats
        public async Task<IActionResult> Index()
        {
            return View(_context.SearchCategory("").ToList());
        }

        [HttpPost]
        public IActionResult Index(string Icategory)
        {
            return View( _context.SearchCategory(Icategory).ToList());
        }







        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Incomecat());
            else
            {
                var incomecat = await _context.incomecats.FindAsync(id);
                if (incomecat == null)
                {
                    return NotFound();
                }
                return View(incomecat);
            }
        }



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("CIncomeId,Icategory,DisplayOrder")] Incomecat incomecat)
        {
              if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    // insert 
                    _context.Add(incomecat);
                    await _context.SaveChangesAsync();


                }
                else
                {
                    // update
                    try
                    {
                        _context.Update(incomecat);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!IncomecatExists(incomecat.CIncomeId))
                        { return NotFound(); }
                        else
                        { throw; }


                    }

                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.incomecats.ToList()) });


                }

            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", incomecat) });
        }



        /*
        // GET: Incomecats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.incomecats == null)
            {
                return NotFound();
            }

            var incomecat = await _context.incomecats.FindAsync(id);
            if (incomecat == null)
            {
                return NotFound();
            }
            return View(incomecat);
        }

        // POST: Incomecats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CIncomeId,Icategory,DisplayOrder")] Incomecat incomecat)
        {
            if (id != incomecat.CIncomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomecat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomecatExists(incomecat.CIncomeId))
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
            return View(incomecat);
        }
        */

        // GET: Incomecats/Delete/5
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.incomecats == null)
            {
                return NotFound();
            }

            var incomecat = await _context.incomecats.FirstOrDefaultAsync(m => m.CIncomeId == id);


            if (incomecat == null)
            {
                return NotFound();
            }

            return View(incomecat);
        }

        // POST: Incomecats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
   /*
            var incomecatsmodel = await _context.incomecats.FindAsync(id);
            _context.incomecats.Remove(incomecatsmodel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.incomecats.ToList()) });
   */
          
            if (_context.incomecats == null)
            {
                return Problem("Entity set 'ApplicationContext.incomecats'  is null.");
            }
            var incomecat = await _context.incomecats.FindAsync(id);
            if (incomecat != null)
            {
                _context.incomecats.Remove(incomecat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         
           
        }




        private bool IncomecatExists(int id)
        {
          return _context.incomecats.Any(e => e.CIncomeId == id);
        }
    }
}
