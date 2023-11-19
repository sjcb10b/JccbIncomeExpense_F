using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JccbIncomeExpense.Data;
using JccbIncomeExpense.Models;
using System.Security.Policy;
using JccbIncomeExpense.Migrations;

namespace JccbIncomeExpense.Controllers
{
    public class CatexpensesController : Controller
    {
        private readonly ApplicationContext _context;

        public CatexpensesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Catexpenses
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Catexpenses.ToListAsync());
        //}



        // GET: Incomecats
        public IActionResult Index()
        {
            return View(_context.SearchCategorye("").ToList());
        }

        [HttpPost]
        public IActionResult Index(string Excategory)
        {
            return View(_context.SearchCategorye(Excategory).ToList());
        }


        //public async Task<IActionResult> AddOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Catexpense());
        //    }
        //    else
        //    {
        //        var catexpense = await _context.Catexpenses.FindAsync(id);
        //        if (catexpense == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(catexpense);
        //    }

        //}







        // POST: Catexpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Catexpense());
            }
            else
            {
                var expense = await _context.Catexpenses.FindAsync(id);
                if (expense == null)
                {
                    return NotFound();
                }
                return View(expense);
            }


            //if (ModelState.IsValid)
            //{
            //    _context.Add(catexpense);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(catexpense);
        }

        // GET: Catexpenses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Catexpenses == null)
        //    {
        //        return NotFound();
        //    }

        //    var catexpense = await _context.Catexpenses.FindAsync(id);
        //    if (catexpense == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(catexpense);
        //}

        // POST: Catexpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id,[Bind("CatexpenseId,Excategory,DisplayOrder")] Catexpense catexpense)
        {

            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    
                    _context.Add(catexpense);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(catexpense);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CatexpenseExists(catexpense.CatexpenseId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Catexpenses.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", catexpense) });
        }


                //if (id != catexpense.CatexpenseId)
                //{
                //    return NotFound();
                //}

                //if (ModelState.IsValid)
                //{
                //    try
                //    {
                //        _context.Update(catexpense);
                //        await _context.SaveChangesAsync();
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        if (!CatexpenseExists(catexpense.CatexpenseId))
                //        {
                //            return NotFound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return RedirectToAction(nameof(Index));
                //}
                //return View(catexpense);
        

        // GET: Catexpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catexpenses == null)
            {
                return NotFound();
            }

            var catexpense = await _context.Catexpenses
                .FirstOrDefaultAsync(m => m.CatexpenseId == id);
            if (catexpense == null)
            {
                return NotFound();
            }

            return View(catexpense);
        }

        // POST: Catexpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catexpenses == null)
            {
                return Problem("Entity set 'ApplicationContext.Catexpenses'  is null.");
            }
            var catexpense = await _context.Catexpenses.FindAsync(id);
            if (catexpense != null)
            {
                _context.Catexpenses.Remove(catexpense);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Catexpenses.ToList()) });
        }

        private bool CatexpenseExists(int id)
        {
          return _context.Catexpenses.Any(e => e.CatexpenseId == id);
        }
    }
}
