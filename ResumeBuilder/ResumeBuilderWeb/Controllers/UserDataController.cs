using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderLibrary.Interfaces;
using ResumeBuilderLibrary.Models;
using ResumeBuilderWeb.Models;

namespace ResumeBuilderWeb.Controllers
{
    public class UserDataController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserData _userData;

        public UserDataController(UserManager<ApplicationUser> userManager, IUserData userData)
        {
            _userManager = userManager;
            _userData = userData;
        }
        public async Task<IActionResult> Add()
        {
            var currentUser = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            return View();
        }
        public async Task<IActionResult> AddUserPersonalInfo(PersonalInfoViewModel info)
        {
            var currentUser = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            return RedirectToAction("Add");
        }
        public async Task<IActionResult> AddUserEducation(Education education)
        {
            var currentUser = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            return RedirectToAction("Add");
        }
        public async Task<IActionResult> AddUserExperience(Experience experience)
        {
            var currentUser = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            return RedirectToAction("Add");
        }
        public async Task<IActionResult> AddUserSkills(Skill skill)
        {
            var currentUser = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            return RedirectToAction("Add");
        } 
        public async Task<IActionResult> AddUserProjects(Project project)
        {
            var currentUser = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            return RedirectToAction("Add");
        }
    }
}
