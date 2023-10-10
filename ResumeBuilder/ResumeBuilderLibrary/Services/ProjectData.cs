using Microsoft.EntityFrameworkCore;
using ResumeBuilderLibrary.DataAccess;
using ResumeBuilderLibrary.Interfaces;
using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Services
{
    public class ProjectData : IProjectData
    {
        private readonly ApplicationDbContext _context;
        public ProjectData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectId(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<int> CreateAll(List<Project> Projects)
        {
            foreach (var Project in Projects)
            {
                await _context.Projects.AddAsync(Project);
            }
            return _context.SaveChanges();
        }

        public async Task<int> Create(Project Project)
        {
            await _context.Projects.AddAsync(Project);
            return _context.SaveChanges();
        }

        public int Update(Project Project)
        {
            _context.Projects.Update(Project);
            return _context.SaveChanges();
        }

        public int Delete(Project Project)
        {
            _context.Projects.Remove(Project);
            return _context.SaveChanges();
        }
    }
}
