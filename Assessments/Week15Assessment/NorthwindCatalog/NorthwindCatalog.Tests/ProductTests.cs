using NorthwindCatalog.Services.DTOs;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {

        [Fact]
        public void Matching_InventoryValue()
        {
            var product = new ProductDto
            {
                ProductName = "Test Product",
                UnitPrice = 10,
                UnitsInStock = 5
            };

            var result = product.InventoryValue;
            Assert.Equal(50, result);
        }
    }
}
