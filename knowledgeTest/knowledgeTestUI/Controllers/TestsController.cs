using KnowledgeTestLibrary.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace knowledgeTestUI.Controllers
{
    [Authorize(Roles = "Owner, Admin")]
    public class TestsController : Controller
    {
        private readonly IQuestionsData _questionsData;

        public TestsController(IQuestionsData questionsData)
        {
            _questionsData = questionsData;
        }

        [Route("/admin/portal/tests")]
        public async Task<IActionResult> Index()
        {
            var listQuestions = await _questionsData.GetQuestionsBySubjectAsync(1);
            return View(listQuestions);
        }
    }
}
