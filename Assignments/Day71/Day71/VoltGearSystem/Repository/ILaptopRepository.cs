using VoltGearSystem.Models;

namespace VoltGearSystem.Repository
{
    public interface ILaptopRepository
    {
        Task CreateAsync(Laptop laptop);
        Task<IEnumerable<Laptop>> GetAsync();
    }
}
