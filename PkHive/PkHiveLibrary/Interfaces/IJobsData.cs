using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface IJobsData
    {
        Task<List<Job>> GetAllJobs();
        Task<List<JobViewModel>> GetJobsByType(string Type);
        Task<List<Job>> GetJobsByLocation(string Location);
        Task<Job> GetJobsById(int Id);
        Task<int> AddJob(Job job);
        Task<int> UpdateJob(Job job);
        Task<JobsCount> GetJobsCount();
    }
}