using JccbIncomeExpense.Data;
using JccbIncomeExpense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
 


namespace JccbIncomeExpense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationContext dbContext = null)
        {
            _logger = logger;
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewModel viewmodel = new ViewModel();

            viewmodel.Myexpenses = TotalExpense();
            viewmodel.Infoincomes = TotalIncome();
            viewmodel.InfoincomesDecember = TotalIncomeDecember();
            viewmodel.InfoincomesNovember = TotalIncomeMovember();
            viewmodel.InfoincomesOctober = TotalIncomeOctober();
            viewmodel.InfoincomesSeptember = TotalIncomeSeptember();

            viewmodel.MyexpensesDecember = TotalExpenseDecember();
            viewmodel.MyexpensesNovember = TotalExpenseNovember();
            viewmodel.MyexpensesOctober = TotalExpenseOctober();
            viewmodel.MyexpensesSeptember = TotalExpenseSeptember();
            // income options




            viewmodel.InfoincomesSalary = TotalIncomeSalary();

            return View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // expense
        public List<Myexpense> TotalExpense()
        {
            var mytotalexpese = _dbContext.myexpenses.FromSqlRaw($"select * from myexpenses ").ToList();

            return mytotalexpese;
        }

        public List<Myexpense> TotalExpenseDecember()
        {
            var mytotalexpeseD = _dbContext.myexpenses.FromSqlRaw($"select * from [dbo].[myexpenses] where Datedexp between '2022-12-01 00:00:00' and '2022-12-31 00:00:00' ").ToList();
            return mytotalexpeseD;
        }

        public List<Myexpense> TotalExpenseNovember()
        {
            var mytotalexpeseN = _dbContext.myexpenses.FromSqlRaw($"select * from [dbo].[myexpenses] where Datedexp between '2022-11-01 00:00:00' and '2022-11-30 00:00:00' ").ToList();
            return mytotalexpeseN;
        }

        public List<Myexpense> TotalExpenseOctober()
        {
            var mytotalexpeseO = _dbContext.myexpenses.FromSqlRaw($"select * from [dbo].[myexpenses] where Datedexp between '2022-10-01 00:00:00' and '2022-10-30 00:00:00' ").ToList();
            return mytotalexpeseO;
        }


        public List<Myexpense> TotalExpenseSeptember()
        {
            var mytotalexpeseS = _dbContext.myexpenses.FromSqlRaw($"select * from [dbo].[myexpenses] where Datedexp between '2022-9-01 00:00:00' and '2022-9-30 00:00:00' ").ToList();
            return mytotalexpeseS;
        }







        // Income 

        public List<Infoincome> TotalIncome()
        {
            var totalincomea = _dbContext.Infoincomes.FromSqlRaw($"select *   from [dbo].[infoincomes]  ").ToList();
            return totalincomea;
        }


        public List<Infoincome> TotalIncomeSalary()
        {

            var totalincomesalary = _dbContext.Infoincomes.FromSqlRaw($"select * from [dbo].[infoincomes] where Icategory='Salary' ").ToList();

            return totalincomesalary;
        }




        public List<Infoincome> TotalIncomeDecember()
        {
            var totalincomeb = _dbContext.Infoincomes.FromSqlRaw($"select * from [dbo].[infoincomes]  where Dated between '2022-12-01 00:00:00' and '2022-12-31 00:00:00' ").ToList();
            return totalincomeb;
        }
        public List<Infoincome> TotalIncomeMovember()
        {
            var totalincomeN = _dbContext.Infoincomes.FromSqlRaw($"select * from [dbo].[infoincomes]  where Dated between '2022-11-01 00:00:00' and '2022-11-30 00:00:00' ").ToList();
            return totalincomeN;
        }

        public List<Infoincome> TotalIncomeOctober()
        {
            var totalincomeO = _dbContext.Infoincomes.FromSqlRaw($"select * from [dbo].[infoincomes]  where Dated between '2022-10-01 00:00:00' and '2022-10-30 00:00:00' ").ToList();
            return totalincomeO;
        }
        public List<Infoincome> TotalIncomeSeptember()
        {
            var totalincomeS = _dbContext.Infoincomes.FromSqlRaw($"select * from [dbo].[infoincomes]  where Dated between '2022-9-01 00:00:00' and '2022-9-30 00:00:00' ").ToList();
            return totalincomeS;
        }

    }
}