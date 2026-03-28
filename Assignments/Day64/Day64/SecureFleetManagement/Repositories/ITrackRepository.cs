using TrackingService.Models;

namespace TrackingService.Repositories
{
    public interface ITrackRepository
    {
        Task Create(Track track);
        Task<IEnumerable<Track>> GetAll();
        Task<Track> GetById(int id);
        Task<bool> Remove(int id);
        Task<Track> Update(Track track);
    }
}
