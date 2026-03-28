using TrackingService.Dtos;
using TrackingService.Helpers;
using TrackingService.Models;
using TrackingService.Repositories;

namespace TrackingService.Services
{
    public class TrackService : ITrackService
    {
        private ITrackRepository _repository;

        public TrackService(ITrackRepository repository)
        {
            _repository = repository;
        }
        public async Task<Track> Create(CreateTrackDto createTrackDto)
        {
            if (string.IsNullOrEmpty(createTrackDto.Model) || string.IsNullOrEmpty(createTrackDto.StartDestination) ||
                string.IsNullOrEmpty(createTrackDto.EndDestination))
                throw new Exception();
            if (createTrackDto.Distance < 1)
                throw new Exception();
            var x = new Track
            {
                Model = createTrackDto.Model,
                Distance = createTrackDto.Distance,
                StartDestination = createTrackDto.StartDestination,
                EndDestination = createTrackDto.EndDestination
            };
            x.TruckNumber = TruckNumberGenerate.Generate(x.Id);
            await _repository.Create(x);
            return x ;
        }

        public async Task<IEnumerable<Track>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<Track> GetById(int id)
        {
            var x = _repository.GetById(id);
            if (x == null)
                throw new Exception();
            return x;
        }

        public Task Remove(int id)
        {
            var x = _repository.GetById(id);
            if (x == null)
                throw new Exception();
            return _repository.Remove(id);
        }

        public async Task<Track> Update(int id, UpdateTrackDto updateTrackDto)
        {
            var x = await _repository.GetById(id);
            if (x == null)
                throw new Exception();
            return await _repository.Update(x);
        }
    }
}
