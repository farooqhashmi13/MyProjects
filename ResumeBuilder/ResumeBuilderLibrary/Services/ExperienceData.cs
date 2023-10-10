using Microsoft.EntityFrameworkCore;
using ResumeBuilderLibrary.DataAccess;
using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Services
{
    public class ExperienceData : IExperienceData
    {
        private readonly ApplicationDbContext _context;
        public ExperienceData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Experience>> GetExperiences()
        {
            return await _context.Experiences.ToListAsync();
        }

        public async Task<Experience> GetExperienceId(int id)
        {
            return await _context.Experiences.FindAsync(id);
        }

        public async Task<int> CreateAll(List<Experience> Experiences)
        {
            foreach (var Experience in Experiences)
            {
                await _context.Experiences.AddAsync(Experience);
            }
            return _context.SaveChanges();
        }

        public async Task<int> Create(Experience Experience)
        {
            await _context.Experiences.AddAsync(Experience);
            return _context.SaveChanges();
        }

        public int Update(Experience Experience)
        {
            _context.Experiences.Update(Experience);
            return _context.SaveChanges();
        }

        public int Delete(Experience Experience)
        {
            _context.Experiences.Remove(Experience);
            return _context.SaveChanges();
        }
    }
}
