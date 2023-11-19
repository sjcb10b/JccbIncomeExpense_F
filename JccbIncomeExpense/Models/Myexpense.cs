using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JccbIncomeExpense.Models
{
    public class Myexpense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        [DisplayName("Expense Name")]
        public string Expname { get; set; }

        [Required]
        [DisplayName("Amount")]
        //[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public float? ExpAmount { get; set; }

        public string? Reference { get; set; }

        [DisplayName(" Category")]
        public string? Excategory { get; set; }

        public string? Note { get; set; }
        [DisplayName(" Date Created")]
        public DateTime Datedexp { get; set; } = DateTime.Now;
    }
}
