using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.Services
{
    public class LocationsData : ILocationsData
    {
        private readonly ApplicationDbContext _context;

        public LocationsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddLocation(Location location)
        {
            await _context.Locations.AddAsync(location);
            return _context.SaveChanges();
        }

        public async Task<Location> GetLocationById(int Id)
        {
            return await _context.Locations.FindAsync(Id);
        }

        public async Task<List<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public Task<int> UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            return _context.SaveChangesAsync();
        }
    }
}
