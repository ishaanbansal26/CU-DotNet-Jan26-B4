using System.ComponentModel.DataAnnotations;

namespace LoanManagementAPI_with_DTO.DTOs.CREATE
{
    public class AddLoan
    {
        [Required]
        public string BorrowerName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int LoanTermMonths { get; set; }
     
        [Required]
        public bool IsApproved { get; set; }
    }
}
