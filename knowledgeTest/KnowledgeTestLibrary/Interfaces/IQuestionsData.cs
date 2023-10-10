using KnowledgeTestLibrary.Models;

namespace KnowledgeTestLibrary.Interfaces
{
    public interface IQuestionsData
    {
        Task<int> AddAsync(Question question);
        Task<int> DeleteAsync(Question question);
        Task<Question> GetQuestionByIdAsync(int Id);
        Task<List<Question>> GetQuestionsBySubjectAsync(int SubjectId);
        Task<int> UpdateAsync(Question question);
    }
}