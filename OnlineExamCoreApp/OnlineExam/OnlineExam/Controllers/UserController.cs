using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineExam.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var exams = _context.Exams.Where(u => u.UserId == userId).ToList();

            return View(exams);
        }
    }
}
