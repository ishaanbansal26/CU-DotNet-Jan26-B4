using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinTrack_pro.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; } // e.g., Income, Expense
        public DateTime Date { get; set; }

        public int AccountId { get; set; }
        [ValidateNever]
        public Account Account { get; set; }
    }

}
