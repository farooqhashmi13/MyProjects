using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface IJobTypesData
    {
        Task<int> AddJobType(JobType jobType);
        Task<List<JobType>> GetJobTypes();
        Task<List<Job>> GetJobsByTypes(int jobTypeId);
        Task<int> AddJob(Job job);
    }
}