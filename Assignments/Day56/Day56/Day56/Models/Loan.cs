using System.ComponentModel.DataAnnotations;

namespace Day56.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Borrower Name")]
        public string BorrowerName { get; set; }
        public string LenderName { get; set; }
        [Range(1, 500000)]
        public double Amount { get; set; }
        public bool IsSettled { get; set; }

        public override bool Equals(object? obj)
        {
            var x = obj as Loan;
            return Id.Equals(x.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id , Amount , LenderName , BorrowerName , IsSettled);
        }
    }
}
