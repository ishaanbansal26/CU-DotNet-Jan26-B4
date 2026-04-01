using MongoDB.Driver;
using VoltGearSystem.MongoDbSettings;
using VoltGearSystem.Models;
using VoltGearSystem.Repository;

namespace VoltGearSystem.Service
{
    public class LaptopService
    {
        private ILaptopRepository _laptopRepository;

        public LaptopService(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public async Task CreateAsync(Laptop laptop)
        {
            if (string.IsNullOrWhiteSpace(laptop.ModelName))
                throw new Exception("Laptop name is required");

            if (laptop.Price <= 0)
                throw new Exception("Invalid price");
            await _laptopRepository.CreateAsync(laptop);
        }
        public async Task<IEnumerable<Laptop>> GetAsync()
        {

            return await _laptopRepository.GetAsync();
        }
    }
}
