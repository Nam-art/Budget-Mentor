using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.Models
{
    public class ExpenseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Item")]
        public string ItemName { get; set; }
        [Required]
        [DisplayName("Cost")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        [DisplayName("Date of purchase")]
        [DataType(DataType.DateTime)]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        [Required]
        public string Category { get; set; }
    }
}
