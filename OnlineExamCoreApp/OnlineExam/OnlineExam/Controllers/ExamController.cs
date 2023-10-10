using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace OnlineExam.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        ApplicationDbContext _context;

        UserManager<ApplicationUser> _userManager;

        public ExamController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        public IActionResult Start(string type, int subject)
        {

            var questions = new List<Question>();
            var evModelList = new List<ExamViewModel>();
            var evModal = new ExamViewModel();
            var optionsList = new List<Option>();

            if (type == "short")
            {
                questions = _context.Questions.Where(s => s.SubjectId == subject)
                    .Include(s => s.Subject)
                    .OrderBy(r => Guid.NewGuid())
                    .Take(15).ToList();
            }
            else if (type == "medium")
            {
                questions = _context.Questions.Where(s => s.SubjectId == subject)
                    .Include(s => s.Subject)
                    .OrderBy(r => Guid.NewGuid())
                    .Take(50).ToList();
            }
            else
            {
                questions = _context.Questions.Where(s => s.SubjectId == subject)
                    .Include(s => s.Subject)
                    .OrderBy(r => Guid.NewGuid())
                    .Take(100).ToList();
            }

            int questionNo = 1;

            foreach (var question in questions)
            {
                var options = _context.Options.Where(q => q.QuestionId == question.Id).ToList();
                evModelList.Add(new ExamViewModel()
                {
                    ExamCategory = type,
                    Subject = question.Subject.Name,
                    QuestionNo = questionNo,
                    Question = question,
                    Options = options
                });
                questionNo += 1;
            }
            return View(evModelList);
        }

        [HttpPost]
        public IActionResult Finish(ExamQuestionList obj)
        {

            if (obj == null) return RedirectToAction("Index");

            List<ExamQuestion> listQuestions = obj.Data;
            int marks = 0;

            foreach (var question in listQuestions)
            {
                var option = _context.Options.SingleOrDefault(I => I.Id == question.SelectedOptionId && I.QuestionId == question.QuestionId);
                marks = (option?.IsAnswer).HasValue ? ((option?.IsAnswer).Value ? marks + 1 : marks) : marks;
            }

            var subjectId = _context.Questions.SingleOrDefault(I => I.Id == listQuestions.First().QuestionId)?.SubjectId;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.GetUserAsync(HttpContext.User);

            var exam = new Exam()
            {
                SubjectId = subjectId != null ? subjectId.Value : 0,
                ExamDate = DateTime.Now,
                TotalMarks = obj.TotalQuestions,
                GainedMarks = marks,
                UserId = userId,
                User = user?.Result
            };

            _context.Exams.Add(exam);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult Result()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var email = User.FindFirst(ClaimTypes.Name)?.Value;

            var lastExam = _context.Exams.Where(u => u.UserId == userId)?.Include(s => s.Subject).OrderByDescending(i => i.Id).First();

            var result = new ResultViewModel()
            {
                UserName = userName,
                Email = email,
                Subject = lastExam.Subject.Name,
                Date = lastExam.ExamDate.ToString("d MMM yyyy"),
                GainedMarks = lastExam.GainedMarks.ToString(),
                TotalMarks = lastExam.TotalMarks.ToString()
            };
            return View(result);
        }
    }

    public class ExamQuestionList
    {
        public int TotalQuestions { get; set; }
        public List<ExamQuestion> Data { get; set; }
    }

    public class ExamQuestion
    {
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
    }
}
