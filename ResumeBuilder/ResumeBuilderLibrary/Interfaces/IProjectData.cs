using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Interfaces
{
    public interface IProjectData
    {
        Task<int> Create(Project Project);
        Task<int> CreateAll(List<Project> Projects);
        int Delete(Project Project);
        Task<Project> GetProjectId(int id);
        Task<List<Project>> GetProjects();
        int Update(Project Project);
    }
}