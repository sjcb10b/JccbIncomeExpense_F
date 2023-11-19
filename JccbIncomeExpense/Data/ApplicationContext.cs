using JccbIncomeExpense.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Microsoft.Data.SqlClient;

namespace JccbIncomeExpense.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Testo> Testos { get; set; }
        public DbSet<Catexpense> Catexpenses { get; set; }
        public DbSet<Incomecat> incomecats { get; set; }
        public DbSet<Infoincome> Infoincomes { get; set; }
        public DbSet<Myexpense> myexpenses { get; set; }

        public IQueryable<Incomecat> SearchCategory(string Icategory)
        {
            SqlParameter pContactName = new SqlParameter("@Icategory", Icategory);
            return this.incomecats.FromSqlRaw("EXECUTE Income_SearchCategory @Icategory", pContactName);
        }


        public IQueryable<Catexpense> SearchCategorye(string Excategory)
        {
            SqlParameter pContactName = new SqlParameter("@Excategory", Excategory);
            return this.Catexpenses.FromSqlRaw("EXECUTE expense_SearchCategory @Excategory", pContactName);
        }


        public IQueryable<Infoincome> SearchReference(string Reference)
        {
            SqlParameter pContactName = new SqlParameter("@Reference", Reference);
            return this.Infoincomes.FromSqlRaw("EXECUTE info_Searchreference @Reference", pContactName);
        }

        public IQueryable<Myexpense> SearchReferencee(string Reference)
        {
            SqlParameter pContactName = new SqlParameter("@Reference", Reference);
            return this.myexpenses.FromSqlRaw("EXECUTE expense_Searchreference @Reference", pContactName);
        }





    }
}
