using KnowledgeTestLibrary.Models;

namespace KnowledgeTestLibrary.Interfaces
{
    public interface ISubjectsData
    {
        Task<Subject> GetByIdAsync(int id);
        Task<int> AddAsync(Subject subject);
        Task<List<Subject>> GetAllAsync();
        Task<List<Subject>> ShowAllAsync();
        Task<int> UpdateAsync(Subject subject);
        Task<int> DeleteAsync(Subject subject);
        Task<int> EnableDisableSubjectAsync(int id, bool value);
    }
}