using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JccbIncomeExpense.Models
{
    public class Infoincome
    {
        [Key]
        public int IncomeId { get; set; }

        [Required]
        [DisplayName("Income Name")]
        public string Incomename { get; set; }

        [Required]
        [DisplayName("Amount")]

        //[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]

        public float? SaleAmount { get; set; }

        public string? Reference { get; set; }

        [DisplayName("Category")]
        public string? Icategory { get; set; }
        public string? Note { get; set; }

        [DisplayName("Date Created")]
        public DateTime Dated { get; set; } = DateTime.Now;
    }
}
