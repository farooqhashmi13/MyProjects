using KnowledgeTestLibrary.Data;
using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeTestLibrary.Services
{
    public class ExamData : IExamData
    {
        private readonly ApplicationDbContext _context;

        public ExamData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Test test)
        {
            await _context.Tests.AddAsync(test);
            return _context.SaveChanges();
        }

        public async Task<Test> GetAsync(int Id)
        {
            return await _context.Tests
                .Include(t => t.TestQuestions)
                .ThenInclude(t => t.Question)
                .ThenInclude(q => q.Options)
                .Include(t => t.Subject)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task<IEnumerable<Question>> GetExamQuestionsAsync(int SubjectId)
        {
            var questions = await _context.Questions.Where(q => q.SubjectId == SubjectId)
                .Include(q => q.Subject)
                .Include(q => q.Options).OrderBy(x => Guid.NewGuid())?.Take(15).ToListAsync();
            return questions;
        }
    }
}
