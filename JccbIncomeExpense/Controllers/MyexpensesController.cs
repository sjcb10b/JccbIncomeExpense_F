using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JccbIncomeExpense.Data;
using JccbIncomeExpense.Models;
using JccbIncomeExpense.Migrations;

namespace JccbIncomeExpense.Controllers
{
    public class MyexpensesController : Controller
    {
        private readonly ApplicationContext _context;

        public MyexpensesController(ApplicationContext context)
        {
            _context = context;
        }

     



        // GET: Incomecats
        public IActionResult Index()
        {
            return View(_context.SearchReferencee("").ToList());
        }

        [HttpPost]
        public IActionResult Index(string Reference)
        {
            return View(_context.SearchReferencee(Reference).ToList());
        }








        public async Task<IActionResult> AddorEdit(int id = 0)
        {
            if (id == 0)
            {

                ViewData["CategoryName"] = new SelectList(_context.Catexpenses, "Excategory", "Excategory");
                return View(new Myexpense());
            }
            else
            {
                var myexpenseModel = await _context.myexpenses.FindAsync(id);
                if (myexpenseModel == null)
                {
                    return NotFound();
                }
                ViewData["CategoryName"] = new SelectList(_context.Catexpenses, "Excategory", "Excategory", myexpenseModel.Excategory);
                return View(myexpenseModel);
            }
        }





        // GET: Myexpenses/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.myexpenses == null)
        //    {
        //        return NotFound();
        //    }

        //    var myexpense = await _context.myexpenses
        //        .FirstOrDefaultAsync(m => m.ExpenseId == id);
        //    if (myexpense == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(myexpense);
        //}

        //// GET: Myexpenses/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Myexpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ExpenseId,Expname,ExpAmount,Reference,Excategory,Note,Datedexp")] Myexpense myexpense)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(myexpense);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(myexpense);
        //}

        //// GET: Myexpenses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.myexpenses == null)
        //    {
        //        return NotFound();
        //    }

        //    var myexpense = await _context.myexpenses.FindAsync(id);
        //    if (myexpense == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(myexpense);
        //}

        // POST: Myexpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ExpenseId,Expname,ExpAmount,Reference,Excategory,Note,Datedexp")] Myexpense myexpense)
        {
           

            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    // insert
                    _context.Add(myexpense);
                }
                else 
                {
                    // update 
  
                try
                {
                    _context.Update(myexpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyexpenseExists(myexpense.ExpenseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                }// if statement 



                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.myexpenses.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", myexpense) });
        }

        // GET: Myexpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.myexpenses == null)
            {
                return NotFound();
            }

            var myexpense = await _context.myexpenses
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (myexpense == null)
            {
                return NotFound();
            }

            return View(myexpense);
        }

        // POST: Myexpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.myexpenses == null)
            {
                return Problem("Entity set 'ApplicationContext.myexpenses'  is null.");
            }
            var myexpense = await _context.myexpenses.FindAsync(id);
            if (myexpense != null)
            {
                _context.myexpenses.Remove(myexpense);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyexpenseExists(int id)
        {
          return _context.myexpenses.Any(e => e.ExpenseId == id);
        }
    }
}
