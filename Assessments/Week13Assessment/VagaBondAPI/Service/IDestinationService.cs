using VagaBondAPI.DTOs;
using VagaBondAPI.Models;

namespace VagaBondAPI.Service
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task AddAsync(CreateDestinationDto createDestinationDto);
        Task<Destination> UpdateAsync(int id, UpdateDestinationDto updateDestinationDto);
        Task<bool> DeleteAsync(int id);
    }
}
