namespace Week11Assessment.Services
{
    public class PricingService1 : IPricingService
    {
        public double ApplyDiscount(double price, string code)
        {
            if (code == "WINTER25")
                return price - price * 0.15;
            if (code == "FREESHIP")
                return price - 5.00;
            return price;
        }
    }
}
