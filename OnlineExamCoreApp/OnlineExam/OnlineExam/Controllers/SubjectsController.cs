using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.Models.ViewModels;

namespace OnlineExam.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        [HttpGet]
        public IActionResult Get()
        {
            var subjects = _context.Subjects.ToList();

            var subjectList = new List<SubjectsViewModel>();

            foreach (var subject in subjects)
            {
                subjectList.Add(new SubjectsViewModel()
                {
                    i = "",
                    Id = subject.Id,
                    Name = subject.Name
                });
            }

            return Json(new { success = true, data = subjectList });
        }

        [HttpPost]
        public IActionResult Save(Subject subject)
        {
            if (subject.Id == 0)
            {
                Add(subject);
            }
            else
            {
                Edit(subject);
            }

            return Json(new { success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var subject = _context.Subjects.Find(Id);
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return Json(new { success = true });
        }

        public void Edit(Subject subject)
        {
            var subj = _context.Subjects.Find(subject.Id);
            subj.Name = subject.Name;
            _context.SaveChanges();
        }

        public void Add(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

    }
}
