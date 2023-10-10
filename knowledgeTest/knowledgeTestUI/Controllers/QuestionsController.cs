using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace knowledgeTestUI.Controllers
{
    [Authorize(Roles = "Owner, Admin")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionsData _questionsData;
        private readonly ISubjectsData _subjectsData;

        public QuestionsController(IQuestionsData questionsData, ISubjectsData subjectsData)
        {
            _questionsData = questionsData;
            _subjectsData = subjectsData;
        }
        [Route("/admin/portal/questions")]
        public async Task<IActionResult> Index()
        {
            ViewBag.subjects = await _subjectsData.GetAllAsync();
            return View(new Question());
        }

        public async Task<IActionResult> GetData(int SubjectId)
        {

            var questions = await _questionsData.GetQuestionsBySubjectAsync(SubjectId);

            return Json(new { success = true, data = questions });
        }

        [HttpPost]
        public async Task<IActionResult> SaveData(Question question)
        {
            var res = 0;
            if (question.Id == 0)
            {
                res = await _questionsData.AddAsync(question);
            }
            else
            {
                res = await _questionsData.UpdateAsync(question);
            }

            return Json(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteData(Question question)
        {
            var res = await _questionsData.DeleteAsync(question);
            return Json(new { success = true });
        }
    }
}
