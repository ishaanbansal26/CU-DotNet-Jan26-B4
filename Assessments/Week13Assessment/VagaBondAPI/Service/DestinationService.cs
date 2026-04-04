using VagaBondAPI.DTOs;
using VagaBondAPI.Exceptions;
using VagaBondAPI.Models;
using VagaBondAPI.Reposiotries;

namespace VagaBondAPI.Service
{
    public class DestinationService : IDestinationService
    {
        private IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(CreateDestinationDto createDestinationDto)
        {
            if (string.IsNullOrEmpty(createDestinationDto.CityName) || string.IsNullOrEmpty(createDestinationDto.Country))
                throw new Exception("The city name or country should not be empty");
            var x = new Destination
            {
                CityName = createDestinationDto.CityName,
                Country = createDestinationDto.Country,
                Rating = createDestinationDto.Rating,
                Description = createDestinationDto.Description,
                LastVisited = DateTime.Today
            };
            await _repository.AddAsync(x);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null)
                throw new NotFoundException("Not found");
            await _repository.DeleteAsync(x.Id);
            return true;

        }

        public Task<IEnumerable<Destination>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Destination> GetByIdAsync(int id)
        {
            var x = _repository.GetByIdAsync(id);
            return x;
        }

        public async Task<Destination> UpdateAsync(int id, UpdateDestinationDto updateDestinationDto)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null)
                throw new NotFoundException("Destination not found");

            x.Description = updateDestinationDto.Description;
            x.Rating = updateDestinationDto.Rating;
            x.CityName = updateDestinationDto.CityName;
            x.Country = updateDestinationDto.Country;

            await _repository.UpdateAsync(x.Id, x);
            return x;
        }
    }
}
