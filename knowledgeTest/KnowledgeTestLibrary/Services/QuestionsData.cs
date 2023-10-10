using KnowledgeTestLibrary.Data;
using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeTestLibrary.Services
{
    public class QuestionsData : IQuestionsData
    {
        private readonly ApplicationDbContext _context;

        public QuestionsData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Question>> GetQuestionsBySubjectAsync(int SubjectId)
        {
            var subject = await _context.Subjects.Include(S => S.Questions).ThenInclude(q => q.Options).SingleOrDefaultAsync(S => S.Id == SubjectId);
            var questions = subject != null ? subject.Questions : new List<Question>();
            return questions;
        }
        public async Task<Question> GetQuestionByIdAsync(int Id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == Id);
            return question;
        }
        public async Task<int> AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            return _context.SaveChanges();
        }
        public async Task<int> UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Question question)
        {
            _context.Questions.Remove(question);
            return await _context.SaveChangesAsync();
        }
    }
}
