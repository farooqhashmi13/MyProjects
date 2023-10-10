using Microsoft.AspNetCore.Identity;
using ResumeBuilderLibrary.Models;
using System.Security.Claims;

namespace ResumeBuilderLibrary.Interfaces
{
    public interface IUserData
    {
        Task<ApplicationUser> GetCurrentUser(UserManager<ApplicationUser> userManager, ClaimsPrincipal claimsPrincipal);
        Task<int> CreateUser(ApplicationUser user);
        Task<ApplicationUser> GetUserEducation(string userId);
        Task<ApplicationUser> GetUserExperience(string userId);
        Task<ApplicationUser> GetUserProjects(string userId);
        Task<ApplicationUser> GetUserSkills(string userId);
    }
}