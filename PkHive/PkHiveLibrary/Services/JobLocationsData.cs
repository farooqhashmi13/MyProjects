using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.Services
{
    public class JobLocationsData : IJobLocationsData
    {
        private readonly ApplicationDbContext _context;

        public JobLocationsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddJobLocations(List<JobLocation> jobLocations)
        {
            await _context.JobLocations.AddRangeAsync(jobLocations);
            return _context.SaveChanges();
        }

        public async Task<List<JobLocation>> GetJobLocations(int jobId)
        {
            return await _context.JobLocations
                .Include(l => l.Location)
                .Where(l => l.JobId == jobId)
                .ToListAsync();
        }
    }
}
