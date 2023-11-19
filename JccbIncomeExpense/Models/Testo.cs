using System.ComponentModel.DataAnnotations;

namespace JccbIncomeExpense.Models
{
    public class Testo
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
