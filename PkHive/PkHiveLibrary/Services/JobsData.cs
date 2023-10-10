using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.Services
{
    public class JobsData : IJobsData
    {
        private readonly ApplicationDbContext _context;
        public JobsData(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<JobViewModel>> GetJobsByType(string Type)
        {
            var listJobViewModel = new List<JobViewModel>();

            var jObj = from job in _context.Jobs
                       where job.Type.Name == Type && job.LastDate >= DateTime.Today
                       join jobLocation in _context.JobLocations on job.Id equals jobLocation.JobId
                       join location in _context.Locations on jobLocation.LocationId equals location.Id
                       select new
                       {
                           job = job,
                           Location = location,
                       };

            var listObj = jObj.ToList();

            var group = listObj.GroupBy(o => o.job);

            foreach (var item in group)
            {
                var listLocation = new List<Location>();
                foreach (var i in item)
                {
                    listLocation.Add(i.Location);
                }

                listJobViewModel.Add(new JobViewModel()
                {
                    Job = item.Key,
                    Locations = listLocation
                });
            }

            return Task.FromResult(listJobViewModel);
        }
        public async Task<JobsCount> GetJobsCount()
        {
            var jobs = await _context.Jobs
                .Where(j => j.LastDate >= DateTime.Today)
                .Include(t => t.Type)
                .ToListAsync();

            var jobsCount = new JobsCount()
            {
                ASFCount = jobs.Count(j => j.Type.Name == "ASF"),
                FBRCount = jobs.Count(j => j.Type.Name == "FBR"),
                FIACount = jobs.Count(j => j.Type.Name == "FIA"),
                FPSCCount = jobs.Count(j => j.Type.Name == "FPSC"),
                NABCount = jobs.Count(j => j.Type.Name == "NAB"),
                NADRACount = jobs.Count(j => j.Type.Name == "NADRA"),
                NTSCount = jobs.Count(j => j.Type.Name == "NTS"),
                PPSCCount = jobs.Count(j => j.Type.Name == "PPSC"),
                MOCCCount = jobs.Count(j => j.Type.Name == "MOCC"),
            };

            return jobsCount;
        }
        public async Task<int> AddJob(Job job)
        {
            await _context.Jobs.AddAsync(job);
            return _context.SaveChanges();
        }
        public async Task<List<Job>> GetAllJobs()
        {
            var jobs = await _context.Jobs
                .Where(j => j.LastDate >= DateTime.Today)
                .Include(j => j.Type).ToListAsync();

            return jobs;
        }
        public Task<List<Job>> GetJobsByLocation(string Location)
        {

            var location = _context.Locations.SingleOrDefault(l => l.Name == Location);

            var jobs = new List<Job>();

            var jobLocations = _context.JobLocations
                .Include(jl => jl.Job)
                .ThenInclude(j => j.Type)
                .Where(jl => jl.LocationId == location.Id);

            foreach (var jobLocation in jobLocations)
            {
                if (jobLocation.Job.LastDate >= DateTime.Today)
                {
                    jobs.Add(jobLocation.Job);
                }
            }

            //var listJobs = from job in _context.Jobs
            //               join jl in _context.JobLocations
            //               on job.Id equals jl.JobId
            //               join l in _context.Locations
            //               on jl.LocationId equals l.Id
            //               where l.Name == Location && job.LastDate >= DateTime.Today
            //               select job;

            return Task.FromResult(jobs);
        }

        public async Task<Job> GetJobsById(int Id)
        {
            var job = await _context.Jobs.FindAsync(Id);
            return job;
        }

        public Task<int> UpdateJob(Job job)
        {
            _context.Jobs.Update(job);
            return _context.SaveChangesAsync();
        }
    }
}
