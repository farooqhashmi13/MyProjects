using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace knowledgeTestUI.Controllers
{
    [Authorize(Roles = "Owner, Admin")]
    public class SubjectsController : Controller
    {
        private readonly ISubjectsData _subjectsData;

        public SubjectsController(ISubjectsData subjectsData)
        {
            _subjectsData = subjectsData;
        }

        [Route("/admin/portal/subjects")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Subjects = await _subjectsData.GetAllAsync();

            return View(new Subject());
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var subjects = await _subjectsData.GetAllAsync();

            var data = new List<object>();

            foreach (var subject in subjects)
            {
                data.Add(new
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Count = subject.Questions.Count,
                    IsEnabled = subject.IsEnabled
                });
            }

            return Json(new { success = true, data = data });
        }

        [HttpPost]
        public async Task<IActionResult> SaveData(Subject subject)
        {
            var result = 0;
            if (subject.Id == 0)
            {
                result = await _subjectsData.AddAsync(subject);
            }
            else
            {
                result = await _subjectsData.UpdateAsync(subject);
            }
            return Json(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteData(Subject subject)
        {
            var res = await _subjectsData.DeleteAsync(subject);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Enable(int id, bool value)
        {
            var res = await _subjectsData.EnableDisableSubjectAsync(id, value);
            return Json(new { success = true });
        }
    }
}
