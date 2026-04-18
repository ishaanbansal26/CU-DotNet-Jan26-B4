using NorthwindCatalog.Services.DTOs;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {

        [Fact]
        public void Matching_InventoryValue()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Test Product",
                UnitPrice = 10,
                UnitsInStock = 5
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(50, result);
        }
    }
}
