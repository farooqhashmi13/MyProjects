using NewOnlineExam.Models;
using NewOnlineExam.Models.UserDefineModels;
using NewOnlineExam.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace NewOnlineExam.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Questions
        public ActionResult Index()
        {

            ViewBag.subCat = db.SubCategory.ToList();
            int catId = Convert.ToInt32(1);

            var questions = db.Questions.Where(c => c.CategoryId == catId).Include(q => q.subCategory).ToList();

            var jQ = new List<JsonQuestion>();

            foreach (var question in questions)
            {
                var options = db.Options.Where(I => I.QuestionId == question.Id);
                jQ.Add(new JsonQuestion()
                {
                    Questions = question,
                    Category = question.subCategory,
                    Options = options.ToArray()
                });
            }

            var obj = new TableData()
            {
                data = jQ
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
            //return View();
        }

        public ActionResult GetData(string Id)
        {

            int catId = Convert.ToInt32(Id);

            var questions = db.Questions.Where(c => c.CategoryId == catId).Include(q => q.subCategory).ToList();

            var jQ = new List<JsonQuestion>();

            foreach (var question in questions)
            {
                var options = db.Options.Where(I => I.QuestionId == question.Id);
                jQ.Add(new JsonQuestion()
                {
                    Questions = question,
                    Category = question.subCategory,
                    Options = options.ToArray()
                });
            }

            var obj = new TableData()
            {
                data = jQ
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveData(JsonQuestion obj)
        {
            try
            {
                if (obj.Questions.Id == 0)
                {
                    var question = new Questions()
                    {
                        Question = obj.Questions.Question,
                        CategoryId = obj.Questions.CategoryId
                    };
                    db.Questions.Add(question);
                    db.SaveChanges();
                    foreach (var option in obj.Options)
                    {
                        var opt = new Options()
                        {
                            QuestionId = question.Id,
                            Option = option.Option,
                            IsAnswer = option.IsAnswer
                        };
                        db.Options.Add(opt);
                        db.SaveChanges();
                    }
                }
                else
                {
                    var question = db.Questions.Find(obj.Questions.Id);
                    if (question != null)
                    {
                        question.Question = obj.Questions.Question;
                        question.CategoryId = obj.Questions.CategoryId;

                        foreach (var option in obj.Options)
                        {
                            var opt = db.Options.Find(option.Id);
                            if (opt != null)
                            {
                                opt.Option = option.Option;
                                opt.QuestionId = option.QuestionId;
                                opt.IsAnswer = option.IsAnswer;
                            }
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Question Not Found in db");
                    }
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteData(int Id)
        {
            try
            {
                var question = db.Questions.Find(Id);
                if (question != null)
                {
                    db.Questions.Remove(question);
                    db.SaveChanges();
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class TableData
    {
        public IEnumerable<JsonQuestion> data { get; set; }
    }

    public class JsonQuestion
    {
        public string i { get; set; }
        public SubCategory Category { get; set; }
        public Questions Questions { get; set; }
        public Options[] Options { get; set; }
        public bool IsAnswered { get; set; }
    }
}
