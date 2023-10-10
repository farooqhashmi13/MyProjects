using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface ISubjectsData
    {
        Task<List<Subject>> GetSubjects();
        Task<int> GetSubjectId(string subjectName);
    }
}