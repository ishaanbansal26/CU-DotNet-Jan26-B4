namespace GlobalMart.Services
{
    public class PricingService : IPricingService
    {
        public double Winter25(double price)
        {
            return price - price * 0.15;
        }

        public double Freeship(double price)
        {
            return price - 5.00;
        }
    }
}
