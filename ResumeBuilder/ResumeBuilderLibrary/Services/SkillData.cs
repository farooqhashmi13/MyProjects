using Microsoft.EntityFrameworkCore;
using ResumeBuilderLibrary.DataAccess;
using ResumeBuilderLibrary.Interfaces;
using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Services
{
    public class SkillData : ISkillData
    {
        private readonly ApplicationDbContext _context;
        public SkillData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillId(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<int> CreateAll(List<Skill> skills)
        {
            foreach (var skill in skills)
            {
                await _context.Skills.AddAsync(skill);
            }
            return _context.SaveChanges();
        }

        public async Task<int> Create(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            return _context.SaveChanges();
        }

        public int Update(Skill skill)
        {
            _context.Skills.Update(skill);
            return _context.SaveChanges();
        }

        public int Delete(Skill skill)
        {
            _context.Skills.Remove(skill);
            return _context.SaveChanges();
        }
    }
}
