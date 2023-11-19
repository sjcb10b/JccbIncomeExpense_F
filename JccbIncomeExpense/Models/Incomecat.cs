using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JccbIncomeExpense.Models
{
    public class Incomecat
    {
        [Key]
        public int CIncomeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Income Category")]
        public string Icategory { get; set; }
        [DisplayName("Order")]
        public int DisplayOrder { get; set; }
    }
}
