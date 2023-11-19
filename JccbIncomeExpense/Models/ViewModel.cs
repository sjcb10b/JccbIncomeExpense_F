namespace JccbIncomeExpense.Models
{
    public class ViewModel
    {
        public IEnumerable<Infoincome> Infoincomes { get; set; }
        public IEnumerable<Myexpense> Myexpenses { get; set; }

        //expense
        public IEnumerable<Myexpense> MyexpensesDecember { get; set; }
        public IEnumerable<Myexpense> MyexpensesNovember { get; set; }
        public IEnumerable<Myexpense> MyexpensesOctober { get; set; }
        public IEnumerable<Myexpense> MyexpensesSeptember { get; set; }


        // income
        public IEnumerable<Infoincome> InfoincomesDecember { get; set; }
        public IEnumerable<Infoincome> InfoincomesNovember { get; set; }
        public IEnumerable<Infoincome> InfoincomesOctober { get; set; }
        public IEnumerable<Infoincome> InfoincomesSeptember { get; set; }

        public IEnumerable<Infoincome> InfoincomesSalary { get; set; }
    }
}
