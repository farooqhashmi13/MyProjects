using NewOnlineExam.Models;
using NewOnlineExam.Models.UserDefineModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewOnlineExam.Controllers
{
    public class ManageTestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ManageTest
        public ActionResult Index()
        {
            ViewBag.subCat = db.SubCategory.ToList();
            return View();
        }

        public ActionResult GetData(string Id)
        {
            var users = db.Users.ToList();

            var listUserTest = new List<UserTestViewModel>();

            foreach (var user in users)
            {
                var tests = db.Test.Where(I => I.UserId == user.Id).ToList();

                if (tests.Count != 0)
                {
                    int avg = tests.Sum(g => g.Score != null ? g.Score.Value : 0) / tests.Count;
                    listUserTest.Add(new UserTestViewModel()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        TestCount = tests.Count,
                        TestAverage = avg
                    });
                }
            }

            var usersTest = new UsersTestTableData()
            {
                data = listUserTest
            };

            return Json(usersTest, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserTestDetails(string Id) 
        {
            Session["UserId"] = Id;
            return View();   
        }

        public ActionResult GetUsersTestData()
        {
            string Id = Session["UserId"] != null ? Session["UserId"].ToString() : "";

            var tests = db.Test.Where(I => I.UserId == Id).Include(C => C.Category).Include(C => C.SubCategory).Include(U => U.User).ToList();

            var jTD = new List<JsonTestData>();

            foreach (var test in tests)
            {
                var time = test.TimeTaken;
                jTD.Add(new JsonTestData()
                {
                    TestId = test.Id,
                    UserId = test.UserId,
                    UserName = test.User != null ? test.User.UserName : "",
                    CategoryId = test.CategoryId != null ? test.CategoryId.Value : 0,
                    CategoryName = test.Category != null ? test.Category.Name : "",
                    SubCategoryId = test.SubCategoryId != null ? test.SubCategoryId.Value : 0,
                    SubCategoryName = test.SubCategory != null ? test.SubCategory.Name : "",
                    TotalScore = test.TotalScore != null ? test.TotalScore.Value : 0,
                    ScoreTakken = test.Score != null ? test.Score.Value : 0,
                    TimeTakken = time
                });
            }

            var obj = new TestTableData()
            {
                data = jTD
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult DeleteData(int Id)
        {
            try
            {
                var test = db.Test.SingleOrDefault(I => I.Id == Id);
                if (test != null)
                {
                    db.Test.Remove(test);
                    db.SaveChanges();
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TestDetails(int Id)
        {
            try
            {
                var testQuestions = db.TestQuestions.Where(T => T.TestId == Id).Include(q => q.Questions).Include(o => o.SelectedOption).ToList();

                if (testQuestions != null)
                {
                    Session["TestQuestions"] = testQuestions;
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Test Details Are Not Available" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details()
        {
            var TestQuestions = new List<TestQuestions>();
            if (Session["TestQuestions"] != null)
            {
                TestQuestions = Session["TestQuestions"] as List<TestQuestions>;

                var listTestQuestions = new List<TestDetailsViewModel>();

                foreach (var testQuestion in TestQuestions)
                {
                    var options = db.Options.Where(q => q.QuestionId == testQuestion.QuestionsId).ToList();
                    listTestQuestions.Add(new TestDetailsViewModel()
                    {
                        QuestionNo = testQuestion.QuestionNo,
                        Question = testQuestion.Questions.Question,
                        SeletedOptionId = testQuestion.SelectedOptionId.Value,
                        Options = options,
                        IsCorrect = testQuestion.IsCorrect.Value
                    });
                }
                return View(listTestQuestions);
            }
            return RedirectToAction("Index");
        }
    }

    public class TestTableData
    {
        public IEnumerable<JsonTestData> data { get; set; }
    }
    public class JsonTestData
    {
        public string i { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int TotalScore { get; set; }
        public int ScoreTakken { get; set; }
        public string TimeTakken { get; set; }
    }

    public class TestDetailsViewModel
    {
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public int SeletedOptionId { get; set; }
        public List<Options> Options { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class UsersTestTableData
    {
        public IEnumerable<UserTestViewModel> data { get; set; }
    }

    public class UserTestViewModel
    {
        public string i { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int TestCount { get; set; }
        public int TestAverage { get; set; }
        public DateTime AverageTime { get; set; }
    }
}