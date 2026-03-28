using Microsoft.EntityFrameworkCore;
using TrackingService.Data;
using TrackingService.Helpers;
using TrackingService.Models;

namespace TrackingService.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private TrackingServiceContext _context;

        public TrackRepository(TrackingServiceContext context)
        {
            _context = context;
        }
        public async Task Create(Track track)
        {
            await _context.Track.AddAsync(track);
            await _context.SaveChangesAsync();
            track.TruckNumber = TruckNumberGenerate.Generate(track.Id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Track>> GetAll()
        {
            return await _context.Track.ToListAsync();
        }

        public async Task<Track> GetById(int id)
        {
            var x = await _context.Track.FindAsync(id);
            return x;
        }

        public async Task<bool> Remove(int id)
        {
            var x = await _context.Track.FindAsync(id);
            if (x == null)
                return false;
            _context.Track.Remove(x);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<Track> Update( Track track)
        {
            var x = await _context.Track.FindAsync(track.Id);
            if(x!=null)
            {
                x.Model = track.Model;
                x.Distance = track.Distance;
                x.StartDestination = track.StartDestination;
                x.EndDestination = track.EndDestination;
            }
            _context.SaveChanges();
            return x;
        }
    }
}
