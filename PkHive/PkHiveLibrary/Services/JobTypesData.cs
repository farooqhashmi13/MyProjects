using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.Services
{
    public class JobTypesData : IJobTypesData
    {
        private readonly ApplicationDbContext _context;

        public JobTypesData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddJob(Job job)
        {
            await _context.Jobs.AddAsync(job);
            return _context.SaveChanges();
        }

        public async Task<int> AddJobType(JobType jobType)
        {
            await _context.JobTypes.AddAsync(jobType);
            return _context.SaveChanges();
        }

        public async Task<List<Job>> GetJobsByTypes(int jobTypeId)
        {
            return await _context.Jobs.Where(j => j.TypeId == jobTypeId).ToListAsync();
        }

        public async Task<List<JobType>> GetJobTypes()
        {
            return await _context.JobTypes.ToListAsync();
        }
    }
}