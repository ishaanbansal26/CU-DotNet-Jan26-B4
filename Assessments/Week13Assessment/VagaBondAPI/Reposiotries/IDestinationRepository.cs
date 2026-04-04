using VagaBondAPI.Models;

namespace VagaBondAPI.Reposiotries
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task AddAsync(Destination destination);
        Task UpdateAsync(int id, Destination destination);
        Task<bool> DeleteAsync(int id);
    }
}
