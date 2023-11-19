using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JccbIncomeExpense.Models
{
    public class Catexpense
    {
        [Key]
        public int CatexpenseId { get; set; }
        [DisplayName("Expense Category")]
        [Column(TypeName = "nvarchar(50)")]
        public string Excategory { get; set; }
        [DisplayName("Order")]
        public int? DisplayOrder { get; set; }
    }
}
