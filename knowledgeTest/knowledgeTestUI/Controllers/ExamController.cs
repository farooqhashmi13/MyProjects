using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestLibrary.Models;
using knowledgeTestUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace knowledgeTestUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamData _examData;
        private readonly ISubjectsData _subjectsData;

        public ExamController(IExamData examData, ISubjectsData subjectsData)
        {
            _examData = examData;
            _subjectsData = subjectsData;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Subjects = await _subjectsData.ShowAllAsync();
            return View();
        }
        [HttpPost]
        public IActionResult Start(int Id)
        {
            TempData["Id"] = Id;
            return RedirectToAction("StartTest");
        }

        public async Task<IActionResult> StartTest()
        {
            if (TempData["Id"] == null) return RedirectToAction("Index");

            var Id = Convert.ToInt32(TempData["Id"]);

            var questions = await _examData.GetExamQuestionsAsync(Id);

            TempData["Subject"] = questions?.First().Subject.Name;

            var testQuestions = new List<TestQuestion>();

            foreach (var question in questions)
            {
                var quest = new TestQuestion()
                {
                    QuestionId = question.Id,
                    Question = question,
                };
                testQuestions.Add(quest);
            }

            TempData["TestQuestions"] = JsonConvert.SerializeObject(testQuestions);

            return View(testQuestions);
        }

        public async Task<IActionResult> SaveExam(List<TestQuestion> testQuestions)
        {

            if (TempData["TestQuestions"] == null) return RedirectToAction("Index");

            var questions = JsonConvert.DeserializeObject<List<TestQuestion>>(TempData["TestQuestions"].ToString());

            var startTime = Convert.ToDateTime(TempData["StartTime"]);

            var dateTime = DateTime.Now;

            var minutes = (int)(dateTime - startTime).Minutes;
            var seconds = (int)(dateTime - startTime).Seconds;

            var timeTakken = minutes + "m " + seconds + "s";

            foreach (var testQuestion in testQuestions)
            {
                var question = questions.SingleOrDefault(q => q.QuestionId == testQuestion.QuestionId);

                var options = question.Question.Options;

                var selectedOption = options.SingleOrDefault(o => o.Id == testQuestion.SelectedOption);

                var isRight = selectedOption != null ? selectedOption.IsAnswer : false;

                testQuestion.IsRight = isRight;

                question.IsRight = isRight;

                question.SelectedOption = testQuestion.SelectedOption;
            }

            int totalMarks = testQuestions.Count();
            int gainedMarks = testQuestions.Where(q => q.IsRight).Count();
            Subject subject = questions.First().Question.Subject;

            var test = new Test()
            {
                TestDate = dateTime,
                TestQuestions = testQuestions,
                TimeTaken = timeTakken,
                TotalMarks = totalMarks,
                SubjectId = subject.Id,
                GainedMarkes = gainedMarks,
            };

            await _examData.AddAsync(test);

            TempData["TestId"] = test.Id;

            return RedirectToAction("Result");
        }

        public async Task<IActionResult> Result()
        {
            if (TempData["TestId"] == null) return RedirectToAction("Index");

            int testId = (int)TempData["TestId"];

            var result = await _examData.GetAsync(testId);

            return View(result);
        }

        public IActionResult SetTempData()
        {
            TempData["StartTime"] = DateTime.Now;
            return Json(new {Success = true});
        }
    }
}
