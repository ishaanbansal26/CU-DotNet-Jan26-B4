using System.Collections.Specialized;

namespace Week11Assessment.Services
{
    public interface IPricingService
    {
        double ApplyDiscount(double price, string code);
    }
}
