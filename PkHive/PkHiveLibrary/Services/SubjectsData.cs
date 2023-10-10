using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.Services
{
    public class SubjectsData : ISubjectsData
    {
        private readonly ApplicationDbContext _context;

        public SubjectsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetSubjectId(string subjectName)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Name == subjectName);
            return subject == null ? 0 : subject.Id;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }
    }
}
