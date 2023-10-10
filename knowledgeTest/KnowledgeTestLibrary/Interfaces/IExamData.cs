using KnowledgeTestLibrary.Models;

namespace KnowledgeTestLibrary.Interfaces
{
    public interface IExamData
    {
        Task<IEnumerable<Question>> GetExamQuestionsAsync(int SubjectId);
        Task<int> AddAsync(Test test);
        Task<Test> GetAsync(int Id);
    }
}