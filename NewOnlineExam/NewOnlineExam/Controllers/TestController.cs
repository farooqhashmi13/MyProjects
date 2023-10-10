using Microsoft.AspNet.Identity;
using NewOnlineExam.Models;
using NewOnlineExam.Models.UserDefineModels;
using NewOnlineExam.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewOnlineExam.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext _context;
        public TestController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Test
        public ActionResult Index()
        {
            var Catagories = _context.SubCategory;
            ViewBag.Categories = Catagories.ToList();
            return View();
        }

        public JsonResult CheckCategory(string CatName)
        {
            //Note : you can bind same list from database 
            try
            {
                List<SubCategory> ObjList = new List<SubCategory>();
                var Category = _context.SubCategory.SingleOrDefault(n => n.Name.ToLower() == CatName.ToLower());
                if (Category != null)
                {
                    Session["SubCategory"] = Category;
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Skill Category Not Found" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Skill Category Not Found" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Test()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["SubCategory"] != null)
                    {
                        var subCat = Session["SubCategory"] as SubCategory;

                        if (subCat == null) throw new Exception();

                        var test = new Test()
                        {
                            TestDateTime = DateTime.Now,
                            UserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : null,
                            CategoryId = subCat.CategoryId,
                            TotalScore = 15,
                            SubCategoryId = subCat.Id
                        };
                        var testId = _context.Test.Add(test);
                        _context.SaveChanges();
                        Session["TestId"] = testId.Id;

                        var questions = _context.Questions.Where(s => s.CategoryId == subCat.Id).OrderBy(r => Guid.NewGuid()).Take(15).ToList();

                        int i = 1;

                        foreach (var testQuestion in questions)
                        {
                            var testQuest = new TestQuestions()
                            {
                                TestId = testId.Id,
                                QuestionsId = testQuestion.Id,
                                QuestionNo = i
                            };
                            _context.TestQuestions.Add(testQuest);
                            _context.SaveChanges();
                            i++;
                        }

                        int page = 1;
                        int pageSize = 0;
                        int pageNumber = 0;
                        int count = questions.Count();
                        var QVM = new List<QuestionViewModel>();

                        var qcount = 1;
                        foreach (var question in questions)
                        {
                            var options = _context.Options.Where(I => I.QuestionId == question.Id).OrderBy(g => Guid.NewGuid());
                            QVM.Add(new QuestionViewModel()
                            {
                                Questions = question,
                                Category = question.subCategory,
                                Options = options.ToArray(),
                                IsAnswered = false,
                                QuestionNo = qcount
                            });
                            qcount++;
                        }
                        TempData["RemainingQs"] = count - 1;
                        Session["Questions"] = QVM;
                        pageSize = 1;
                        pageNumber = page;
                        ViewBag.Remainings = pageNumber;
                        Session["SubCategory"] = null;
                        return View(QVM.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PageIndex(int page)
        {
            try
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
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult PostQuestion(TestView testView)
        {
            try
            {
                if (testView != null)
                {
                    var testId = Convert.ToInt32(Session["TestId"]);
                    var option = _context.Options.Find(testView.OptionId);
                    var testQuest = _context.TestQuestions.SingleOrDefault(g => g.TestId == testId && g.QuestionsId == testView.QuestionId);
                    if (testView.OptionId != 0)
                    {
                        testQuest.SelectedOptionId = testView.OptionId;
                    }
                    testQuest.IsCorrect = option != null ? option.IsAnswer : false;
                    _context.SaveChanges();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult ShowResult()
        {
            return View();
        }

        public ActionResult GetTestResult()
        {

            try
            {
                if (!Request.IsAuthenticated) return Json(new { success = false, Authenticated = false }, JsonRequestBehavior.AllowGet);

                if (Session["TestId"] == null)
                {
                    var userId = User.Identity.GetUserId();

                    var testList = _context.Test.Where(i => i.UserId == userId).Include(u => u.User).Include(c => c.Category).Include(s => s.SubCategory);
                    if (testList.Count() == 0) return Json(new { success = false, Authenticated = true }, JsonRequestBehavior.AllowGet);

                    var test = testList.OrderByDescending(i => i.Id).First();

                    float score = test.Score.Value;
                    float totalScore = test.TotalScore.Value;

                    var fullName = test.User.FullName.ToUpper();
                    int ind = fullName.IndexOf(' ') + 1;
                    string name = "" + fullName[0] + "" + fullName[ind];

                    var result = new Result()
                    {
                        icon = name,
                        FullName = test.User.FullName,
                        UserName = User.Identity.GetUserName(),
                        SkillCategory = test.SubCategory.Name,
                        Percentage = ((score / totalScore) * 100).ToString("0.00"),
                        TimeTaken = test.TimeTaken,
                        Date = test.TestDateTime.Value.ToString("dd MMM yyyy")
                    };

                    return Json(new { data = result, success = true, Authenticated = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var testId = Convert.ToInt32(Session["TestId"]);

                    Session["TestId"] = null;

                    var testList = _context.Test.Where(i => i.Id == testId).Include(u => u.User).Include(c => c.Category).Include(s => s.SubCategory);
                    if (testList.Count() == 0) return Json(new { success = false, Authenticated = true }, JsonRequestBehavior.AllowGet);

                    var test = testList.First();
                    var testQuestions = _context.TestQuestions.Where(g => g.TestId == test.Id);

                    test.Score = testQuestions.Count(g => g.IsCorrect == true);
                    var timeTaken = DateTime.Now.Subtract(test.TestDateTime.Value);
                    test.TimeTaken = timeTaken.Minutes + "m " + timeTaken.Seconds + "s";
                    test.UserId = test.UserId ?? User.Identity.GetUserId();
                    _context.SaveChanges();

                    float score = test.Score.Value;
                    float totalScore = test.TotalScore.Value;

                    var fullName = test.User?.FullName.ToUpper();
                    int ind = fullName.IndexOf(' ') + 1;
                    string name = "" + fullName[0] + "" + fullName[ind];

                    var result = new Result()
                    {
                        icon = name,
                        FullName = test.User.FullName,
                        UserName = User.Identity.GetUserName(),
                        SkillCategory = test.SubCategory.Name,
                        Percentage = ((score / totalScore) * 100).ToString("0.00"),
                        TimeTaken = test.TimeTaken,
                        Date = test.TestDateTime.Value.ToString("dd MMM yyyy")
                    };

                    return Json(new { data = result, success = true, Authenticated = true }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, Authenticated = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    public class Result
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string icon { get; set; }
        public string SkillCategory { get; set; }
        public string Percentage { get; set; }
        public string TimeTaken { get; set; }
        public string Date { get; set; }
    }
}