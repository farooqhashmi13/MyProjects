using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Services
{
    public interface IExperienceData
    {
        Task<int> Create(Experience Experience);
        Task<int> CreateAll(List<Experience> Experiences);
        int Delete(Experience Experience);
        Task<Experience> GetExperienceId(int id);
        Task<List<Experience>> GetExperiences();
        int Update(Experience Experience);
    }
}