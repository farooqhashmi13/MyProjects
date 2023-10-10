using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderLibrary.Interfaces;
using ResumeBuilderLibrary.Models;
using System.Security.Claims;

namespace ResumeBuilderWeb.Controllers
{
    public class ResumeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserData _userData;

        public ResumeController(UserManager<ApplicationUser> userManager, IUserData userData)
        {
            _userManager = userManager;
            _userData = userData;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userData.GetCurrentUser(_userManager, HttpContext.User);

            ViewBag.education = user.Educations;
            ViewBag.projects = user.Projects;
            ViewBag.experience = user.Experiences;
            ViewBag.skills = user.Skills;

            return View();
        }
        public IActionResult Template1()
        {
            return View();
        }
    }
}
