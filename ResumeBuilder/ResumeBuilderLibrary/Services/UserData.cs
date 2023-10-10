using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderLibrary.DataAccess;
using ResumeBuilderLibrary.Interfaces;
using ResumeBuilderLibrary.Models;
using System.Security.Claims;

namespace ResumeBuilderLibrary.Services
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContext _context;

        public UserData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserSkills(string userId)
        {
            return await _context.Users.Include(U => U.Skills).FirstOrDefaultAsync(U => U.Id == userId);
        }
        public async Task<ApplicationUser> GetUserEducation(string userId)
        {
            return await _context.Users.Include(U => U.Educations).FirstOrDefaultAsync(U => U.Id == userId);
        }
        public async Task<ApplicationUser> GetUserProjects(string userId)
        {
            return await _context.Users.Include(U => U.Projects).FirstOrDefaultAsync(U => U.Id == userId);
        }
        public async Task<ApplicationUser> GetUserExperience(string userId)
        {
            return await _context.Users.Include(U => U.Experiences).FirstOrDefaultAsync(U => U.Id == userId);
        }

        public async Task<int> CreateUser(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
            return _context.SaveChanges();
        }

        public async Task<ApplicationUser> GetCurrentUser(UserManager<ApplicationUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var user = await userManager.GetUserAsync(claimsPrincipal);
            return user;
        }
    }
}
