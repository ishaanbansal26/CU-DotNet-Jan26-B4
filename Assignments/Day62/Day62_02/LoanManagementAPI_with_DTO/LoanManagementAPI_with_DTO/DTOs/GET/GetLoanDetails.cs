using System.ComponentModel.DataAnnotations;

namespace LoanManagementAPI_with_DTO.DTOs.GET
{
    public class GetLoanDetails
    {
        
        public string Borrower { get; set; }
        
        public decimal LoanAmount { get; set; }
        
        public int Months { get; set; }
        
        public bool IsSettled { get; set; }

    }
}
