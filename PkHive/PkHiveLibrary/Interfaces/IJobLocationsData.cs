using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface IJobLocationsData
    {
        Task<int> AddJobLocations(List<JobLocation> jobLocations);
        Task<List<JobLocation>> GetJobLocations(int jobId);
    }
}