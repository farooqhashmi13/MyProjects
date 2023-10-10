using Microsoft.AspNet.Identity;
using Online_Exam.Models;
using Online_Exam.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Online_Exam.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext _context;
        public TestController()
        {
            _context = new ApplicationDbContext();
        }
        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Test
        public ActionResult Index(string testCat)
        {
            ViewBag.TestCat = _context.TestCategories == null ? null : _context.TestCategories.ToList();
            ViewBag.SubjectCat = _context.QuestionCategories == null ? null : _context.QuestionCategories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string testCat, string subCat, string totalQuests)
        {
            if (ModelState.IsValid)
            {

                int questCat = Convert.ToInt32(subCat);
                var questions = new List<Questions>();
                if (testCat != null)
                {
                    if (testCat == "NTS")
                    {
                        //int catId = 1;
                        //ViewBag.Id = catId;
                        ViewBag.category = "NTS";
                        questions = _context.Questions.Include(g => g.Category).ToList();
                        var Portion1 = questions.Where
                            (p => p.Category.Name == "English").OrderBy(r => Guid.NewGuid()).Take(20).ToList();
                        var Portion2 = questions.Where
                            (p => p.Category.Name == "Pak Studies").OrderBy(r => Guid.NewGuid()).Take(15).ToList();
                        var Portion3 = questions.Where
                            (p => p.Category.Name == "Quantitative").OrderBy(r => Guid.NewGuid()).Take(15).ToList();
                        var Portion4 = questions.Where
                            (p => p.CategoryId == questCat).OrderBy(r => Guid.NewGuid()).Take(50).ToList();
                        questions = Portion1;
                        questions.AddRange(Portion2);
                        questions.AddRange(Portion3);
                        questions.AddRange(Portion4);
                        TempData["Questions"] = questions;

                        return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                    }
                    else if (testCat == "Custom")
                    {
                        ViewBag.category = "Custom";
                        questions = _context.Questions.Include(g => g.Category)
                            .Where(g => g.CategoryId == questCat)
                            .OrderBy(r => Guid.NewGuid())
                            .Take(Convert.ToInt32(totalQuests)).ToList();

                        TempData["Questions"] = questions;

                        return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StartTest()
        {
            if (ModelState.IsValid)
            {
                //if (TempData["Questions"] != null)
                //{
                var questions = _context.Questions.ToList();//TempData["Questions"] as List<Questions>;
                int page = 1;
                int pageSize = 0;
                int pageNumber = 0;
                questions = _context.Questions.OrderBy(r => Guid.NewGuid()).ToList();
                int count = questions.Count();
                var QVM = new List<QuestionViewModel>();

                foreach (var question in questions)
                {
                    var options = _context.Options.Where(I => I.QuestionId == question.Id).OrderBy(g => Guid.NewGuid());
                    QVM.Add(new QuestionViewModel()
                    {
                        Questions = question,
                        Category = question.Category,
                        Options = options.ToArray(),
                        IsAnswered = false
                    });
                }
                var test = new Test()
                {
                    TestDateTime = DateTime.Now,
                    UserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : null
                };
                var testId = _context.Test.Add(test);
                _context.SaveChanges();
                Session["TestId"] = testId.Id;
                TempData["RemainingQs"] = count - 1;
                Session["Questions"] = QVM;
                pageSize = 1;
                pageNumber = page;
                ViewBag.Remainings = pageNumber;
                return View(QVM.ToPagedList(pageNumber, pageSize));
                //}
                //else
                //{
                //    return RedirectToAction("Index");
                //}
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PageIndex(int page)
        {
            if (ModelState.IsValid)
            {
                if (Session["Questions"] == null) return RedirectToAction("Index");
                TempData["RemainingQs"] = Convert.ToInt32(TempData["val"]) - 1;
                List<QuestionViewModel> questionsList = Session["Questions"] as List<QuestionViewModel>;
                int count = questionsList.Count();
                int pageSize = 1;
                int pageNumber = page;
                ViewBag.Count = count - (pageNumber + 1);
                if (pageNumber <= count)
                {
                    return PartialView("_partialViewQuestion", questionsList.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return RedirectToAction("ShowResult");
                }
            }
            return View();
        }

        public ActionResult Test()
        {
            var questions = _context.Questions.ToList();
            return View(questions);
        }

        public ActionResult ShowResult()
        {
            if (Session["TestId"] != null)
            {
                var testId = Convert.ToInt32(Session["TestId"]);
                var test = _context.Test.Find(testId);
                var result = new Test()
                {
                    Score = test.Score,
                    UserId = test.UserId,
                    User = test.User,
                    TestDateTime = test.TestDateTime,
                    TimeTaken = test.TimeTaken
                };
                //Session["TestId"] = null;
                return View(result);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult PostQuestion(TestView testView)
        {
            try
            {
                if (testView != null)
                {
                    var testId = Convert.ToInt16(Session["TestId"]);
                    var test = _context.Test.Find(testId);
                    var question = _context.Questions.Find(testView.QuestionId);
                    var option = _context.Options.Find(testView.OptionId);

                    if (Session["Question"] != null)
                    {
                        List<QuestionViewModel> questionsList = Session["Questions"] as List<QuestionViewModel>;
                        var quest = questionsList.SingleOrDefault(g => g.Question == question.Question);
                        if (quest != null)
                        {
                            quest.IsAnswered = true;
                        }
                        Session["Questions"] = questionsList;
                    }

                    if (option.IsAnswer)
                    {
                        var Score = test.Score == null ? 1 : test.Score + 1;
                        test.Score = Score;
                        //var testQuestion = new TestQuestions()
                        //{
                        //    QuestionsId = testView.QuestionId,
                        //    TestId = testView.TestId,
                        //    Result = "Right",
                        //    OptionId = testView.OptionId
                        //};
                        //_context.TestQuestions.Add(testQuestion);
                        _context.SaveChanges();
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("Error404");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error404");
            }

        }
    }
}