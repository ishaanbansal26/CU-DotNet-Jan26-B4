using TrackingService.Dtos;
using TrackingService.Models;

namespace TrackingService.Services
{
    public interface ITrackService
    {
        Task<Track> Create(CreateTrackDto createTrackDto);
        Task Remove(int id);
        Task<Track> GetById(int id);
        Task<IEnumerable<Track>> GetAll();

        Task<Track> Update(int id, UpdateTrackDto updateTrackDto);
    }
}
