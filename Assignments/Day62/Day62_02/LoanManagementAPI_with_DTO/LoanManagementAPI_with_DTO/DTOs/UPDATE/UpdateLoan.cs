using System.ComponentModel.DataAnnotations;

namespace LoanManagementAPI_with_DTO.DTOs.UPDATE
{
    public class UpdateLoan
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Borrower { get; set; }
        [Required]
        public decimal LoanAmount { get; set; }
        public int Months { get; set; }
        [Required]
        public bool IsSettled { get; set; }
    }
}
