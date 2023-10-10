using KnowledgeTestLibrary.Data;
using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeTestLibrary.Services
{
    public class SubjectsData : ISubjectsData
    {
        private readonly ApplicationDbContext _context;

        public SubjectsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> EnableDisableSubjectAsync(int id, bool value)
        {
            var subject = await _context.Subjects.SingleOrDefaultAsync(s => s.Id == id);
            subject.IsEnabled = value;
            return _context.SaveChanges();
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _context.Subjects.OrderBy(s => s.Name).Include(S => S.Questions).ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _context.Subjects.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Subject>> ShowAllAsync()
        {
            return await _context.Subjects.Where(s => s.IsEnabled).OrderBy(s => s.Name).Include(S => S.Questions).ToListAsync();
        }

        public async Task<int> UpdateAsync(Subject subject)
        {
            var subj = await _context.Subjects.SingleOrDefaultAsync(s => s.Id == subject.Id);

            subj.Name = subject.Name;

            return _context.SaveChanges();
        }
    }
}
