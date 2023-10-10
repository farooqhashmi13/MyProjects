using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamsData _examsData;

        public ExamController(IExamsData examsData)
        {
            _examsData = examsData;
        }

        [Route("/test")]
        public IActionResult Index()
        {
            var subjectId = (int)TempData["SubjectId"];

            var testQuestions = _examsData.GetExamQuestions(subjectId);

            TempData["SubjectId"] = subjectId;
            
            return View(testQuestions);
        }

        [HttpPost]
        public async Task<IActionResult> SaveExam(List<TestQuestion> testQuestions)
        {

            var subjectId = (int)TempData["SubjectId"];
            var startTime = (DateTime)TempData["StartTime"];

            var dateTime = DateTime.Now;

            var minutes = (dateTime - startTime).Minutes;
            var seconds = (dateTime - startTime).Seconds;

            var timeTakken = minutes + "m " + seconds + "s";

            var test = new Test()
            {
                SubjectId = subjectId,
                TestDate = dateTime,
                TimeTaken = timeTakken,
                TestQuestions = testQuestions
            };

            await _examsData.AddExam(test);

            test = await _examsData.GetExam(test.Id);

            foreach (var testQuestion in test.TestQuestions)
            {
                testQuestion.IsRight = testQuestion.SelectedOption.IsAnswer;
            }

            test.GainedMarkes = test.TestQuestions.Count(q => q.IsRight);

            var res = await _examsData.UpdateAsync(test);

            TempData["TestId"] = test.Id;

            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            return View();
        }

        public IActionResult SetTempData()
        {
            TempData["StartTime"] = DateTime.Now;
            return Json(new { Success = true });
        }

    }
}
