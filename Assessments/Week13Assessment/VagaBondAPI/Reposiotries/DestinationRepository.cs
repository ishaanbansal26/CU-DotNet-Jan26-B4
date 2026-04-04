using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using VagaBondAPI.Data;
using VagaBondAPI.Models;

namespace VagaBondAPI.Reposiotries
{
    public class DestinationRepository : IDestinationRepository
    {
        private VagaBondAPIContext _context;

        public DestinationRepository(VagaBondAPIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Destination destination)
        {
            await _context.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var x = await _context.Destination.FindAsync(id);
            if (x == null)
                return false;
            _context.Destination.Remove(x);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var x = await _context.Destination.FindAsync(id);
            //await _context.SaveChangesAsync();
            return x;
        }

        public async Task UpdateAsync(int id, Destination destination)
        {
            var x = await _context.Destination.FindAsync(id);
            if(x!=null)
            {
                x.CityName = destination.CityName;
                x.Country = destination.Country;
                x.Rating = destination.Rating;
                x.Description = destination.Description;
            }
            _context.Destination.Update(x);
            await _context.SaveChangesAsync();
           
        }
    }
}
