using Microsoft.EntityFrameworkCore;
using ResumeBuilderLibrary.DataAccess;
using ResumeBuilderLibrary.Interfaces;
using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Services
{
    public class EducationData : IEducationData
    {
        private readonly ApplicationDbContext _context;
        public EducationData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Education>> GetEducations()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetEducationId(int id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task<int> CreateAll(List<Education> Educations)
        {
            foreach (var Education in Educations)
            {
                await _context.Educations.AddAsync(Education);
            }
            return _context.SaveChanges();
        }

        public async Task<int> Create(Education Education)
        {
            await _context.Educations.AddAsync(Education);
            return _context.SaveChanges();
        }

        public int Update(Education Education)
        {
            _context.Educations.Update(Education);
            return _context.SaveChanges();
        }

        public int Delete(Education Education)
        {
            _context.Educations.Remove(Education);
            return _context.SaveChanges();
        }
    }
}
