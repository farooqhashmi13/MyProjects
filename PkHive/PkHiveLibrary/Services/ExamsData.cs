using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.Services
{
    public class ExamsData : IExamsData
    {
        private readonly ApplicationDbContext _context;

        public ExamsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddExam(Test test)
        {
            await _context.Tests.AddAsync(test);
            return _context.SaveChanges();
        }

        public List<TestQuestion> GetExamQuestionsBySubject(string subject)
        {
            var questions = _context.Subjects
                .Include(s => s.Questions)
                .ThenInclude(q => q.Options)
                .SingleOrDefault(s => s.Name == subject)
                .Questions?.OrderBy(q => Guid.NewGuid()).Take(15).ToList();

            var testQuestions = new List<TestQuestion>();

            foreach (var question in questions)
            {
                testQuestions.Add(new TestQuestion()
                {
                    QuestionId = question.Id,
                    Question = question
                });
            }

            return testQuestions;
        }

        public List<TestQuestion> GetExamQuestions(int subjectId)
        {
            var questions = _context.Subjects
                .Include(s => s.Questions)
                .ThenInclude(q => q.Options)
                .SingleOrDefault(s => s.Id == subjectId)
                .Questions?.OrderBy(q => Guid.NewGuid()).Take(15).ToList();

            var testQuestions = new List<TestQuestion>();
            
            foreach (var question in questions)
            {
                testQuestions.Add(new TestQuestion()
                {
                    QuestionId = question.Id,
                    Question = question                    
                });
            }

            return testQuestions;
        }

        public async Task<Test> GetExam(int Id)
        {
            return await _context.Tests
                .Include(t => t.TestQuestions)
                .ThenInclude(t => t.Question)
                .ThenInclude(q => q.Options)
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }

        public Task<int> UpdateAsync(Test test)
        {
            _context.Tests.Update(test);
            return _context.SaveChangesAsync();
        }
    }
}
