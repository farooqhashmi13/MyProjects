using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Data;
using OnlineExam.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExam.Controllers
{
    public class ExamsController : Controller
    {
        ApplicationDbContext _context;
        public ExamsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var exams = _context.Exams.Where(i => i.UserId != null).Include(u => u.User).Include(s => s.Subject).ToList();

            var examsList = new List<ExamsViewModel>();

            foreach (var exam in exams)
            {
                examsList.Add(new ExamsViewModel()
                {
                    Id = exam.Id,
                    UserName = exam.User?.Email,
                    ExamSubject = exam.Subject.Name,
                    TotalMarks = exam.TotalMarks.ToString(),
                    GainedMarks = exam.GainedMarks.ToString(),
                    ExamDate = exam.ExamDate.ToString("dd MMM yyyy")
                });
            }

            return Json(new { success = true, data = examsList });
        }


    }
}
