using Microsoft.AspNet.Identity;
using NewOnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewOnlineExam.Models.UserDefineModels;

namespace NewOnlineExam.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsersTestData()
        {
            string Id = "";
            if (User.Identity.IsAuthenticated)
                Id = User.Identity.GetUserId();

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

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult PortFolio()
        {
            return View();
        }

    }
}