using System;
using System.ComponentModel.DataAnnotations;

namespace Day60.ViewModel
{
    public class InvestmentCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ticker is required")]
        [StringLength(10)]
        [Display(Name = "Ticker Symbol")]
        public string TickerSymbol { get; set; }

        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        [Display(Name = "Purchase Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Quantity { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Total Investment Value")]
        public string TotalValue => (Price * Quantity).ToString("C");
    }

}
