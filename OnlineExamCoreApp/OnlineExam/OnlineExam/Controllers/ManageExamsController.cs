using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Data;
using OnlineExam.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExam.Controllers
{
    public class ManageExamsController : Controller
    {
        ApplicationDbContext _context;
        public ManageExamsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
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
                    UserId = exam.UserId,
                    UserName = exam.User?.Email,
                    SubjectId = exam.SubjectId,
                    ExamSubject = exam.Subject.Name,
                    TotalMarks = exam.TotalMarks.ToString(),
                    GainedMarks = exam.GainedMarks.ToString(),
                    ExamDate = exam.ExamDate.ToString("yyyy-MM-dd"),
                    ExamDateS = exam.ExamDate.ToString("dd MMM yyyy")
                });
            }

            return Json(new { success = true, data = examsList });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var exam = _context.Exams.SingleOrDefault(I => I.Id == Id);
            if (exam == null)
                return Json(new { success = false, message = "Exam data not found" });
            _context.Exams.Remove(exam);

            _context.SaveChanges();
            return Json(new { success = true });
        }

        public IActionResult Edit(ExamsViewModel obj)
        {
            if (obj == null)
                return Json(new { success = false, message = "Exam data must not be null" });

            var exam = _context.Exams.SingleOrDefault(I => I.Id == obj.Id);
            if (exam == null)
                return Json(new { success = false, message = "Exam data not found" });

            exam.SubjectId = obj.SubjectId;
            exam.GainedMarks = Convert.ToInt32(obj.GainedMarks);
            exam.TotalMarks = Convert.ToInt32(obj.TotalMarks);
            exam.ExamDate = Convert.ToDateTime(obj.ExamDate);

            _context.SaveChanges();
            return Json(new { success = true });
        }



    }
}
