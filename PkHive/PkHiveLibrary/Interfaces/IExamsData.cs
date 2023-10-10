using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface IExamsData
    {
        List<TestQuestion> GetExamQuestions(int subjectId);
        List<TestQuestion> GetExamQuestionsBySubject(string subject);
        Task<Test> GetExam(int Id);
        Task<int> AddExam(Test test);
        Task<int> UpdateAsync(Test test);
    }
}