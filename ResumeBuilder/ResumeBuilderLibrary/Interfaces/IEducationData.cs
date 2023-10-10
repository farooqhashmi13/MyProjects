using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Interfaces
{
    public interface IEducationData
    {
        Task<int> Create(Education Education);
        Task<int> CreateAll(List<Education> Educations);
        int Delete(Education Education);
        Task<Education> GetEducationId(int id);
        Task<List<Education>> GetEducations();
        int Update(Education Education);
    }
}