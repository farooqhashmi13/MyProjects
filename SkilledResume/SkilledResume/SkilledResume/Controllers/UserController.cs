using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkilledResume.Data;
using SkilledResume.Models;
using SkilledResume.Models.Entities;
using SkilledResume.Models.View_Models;
using SkilledResume.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkilledResume.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;
        public UserController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            this._context = _context;
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditResume()
        {
            return View();
        }

        #region --> Personal Info <--
        [HttpGet]
        public async Task<IActionResult> LoadInfoAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user != null)
                {
                    var age = DateTime.Now.Subtract(user.DOB).Days / 365;

                    var userObj = new AboutViewModel()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        City = user.City,
                        Country = user.Country,
                        DOBs = user.DOB.ToString("dd MMM yyyy"),
                        DOB = user.DOB.ToString("yyyy-MM-dd"),
                        Age = age.ToString(),
                        Email = user.Email,
                        Phone = user.PhoneNumber,
                        Description = user.Description
                    };

                    return Json(new { success = true, data = userObj });
                }
            }

            return Json(new { success = false });
        }


        [HttpPost]
        public async Task<IActionResult> SaveInfoAsync(ApplicationUser user)
        {

            if (User.Identity.IsAuthenticated)
            {
                var usrId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var usr = await _userManager.FindByIdAsync(usrId);

                usr.City = user.City;
                usr.Country = user.Country;
                usr.Description = user.Description;
                usr.DOB = user.DOB;
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.PhoneNumber = user.PhoneNumber;

                var res = await _userManager.UpdateAsync(usr);

                if (res.Succeeded)
                {
                    return Json(new { success = true });
                }
            }

            return Json(new { success = false });
        }
        #endregion

        #region --> Education <--
        [HttpGet]
        public IActionResult LoadEdu()
        {

            if (User.Identity.IsAuthenticated)
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var listEdu = _context.Education.Where(u => u.UserId == UserId).ToList();

                var EVMlist = new List<EducationViewModel>();

                foreach (var edu in listEdu)
                {
                    EVMlist.Add(new EducationViewModel()
                    {
                        EduId = edu.Id,
                        EduDegreeTitle = edu.DegreeTitle,
                        EduDescription = edu.Description,
                        EduFromDate = edu.FromDate?.ToString("yyyy-MM"),
                        EduFromDateS = edu.FromDate?.ToString("MMM yyyy"),
                        EduGrade = edu.Grade,
                        EduInstitute = edu.Institute,
                        EduToDate = edu.ToDate?.ToString("yyyy-MM"),
                        EduToDateS = edu.ToDate?.ToString("MMM yyyy"),
                    });
                }

                return Json(new { success = true, data = EVMlist });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult SaveEdu(EducationViewModel EVM)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    EVM.EduUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                    if (EVM.EduId == 0)
                    {
                        var education = new Education()
                        {
                            UserId = EVM.EduUserId,
                            DegreeTitle = EVM.EduDegreeTitle,
                            Description = EVM.EduDescription,
                            FromDate = Convert.ToDateTime(EVM.EduFromDate),
                            ToDate = Convert.ToDateTime(EVM.EduToDate),
                            Institute = EVM.EduInstitute
                        };
                        _context.Education.Add(education);
                        _context.SaveChanges();
                        return Json(new { success = true });
                    }
                    else
                    {
                        var edu = _context.Education.SingleOrDefault(g => g.Id == EVM.EduId && g.UserId == EVM.EduUserId);
                        if (edu != null)
                        {
                            edu.DegreeTitle = EVM.EduDegreeTitle;
                            edu.FromDate = Convert.ToDateTime(EVM.EduFromDate);
                            edu.ToDate = Convert.ToDateTime(EVM.EduToDate);
                            edu.Institute = EVM.EduInstitute;
                            edu.Description = EVM.EduDescription;
                            edu.UserId = EVM.EduUserId;
                            _context.SaveChanges();
                            return Json(new { success = true });
                        }
                    }
                }
                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpDelete]
        public ActionResult DelEdu(int EduId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var edu = _context.Education.SingleOrDefault(g => g.Id == EduId && g.UserId == UserId);
                if (edu != null)
                {
                    _context.Education.Remove(edu);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
            }

            return Json(new { success = false, message = "Something went wrong" });
        }

        #endregion
    }
}
