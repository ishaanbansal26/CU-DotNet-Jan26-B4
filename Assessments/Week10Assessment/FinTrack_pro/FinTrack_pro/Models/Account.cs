using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinTrack_pro.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public int Balance { get; set; }

        [ValidateNever]
        public List<Transaction> Transactions { get; set; }
    }
}
