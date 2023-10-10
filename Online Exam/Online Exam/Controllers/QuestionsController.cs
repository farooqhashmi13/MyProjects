using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Exam.Models;
using Online_Exam.Models.ViewModels;

namespace Online_Exam.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Category).ToList();

            var QVM = new List<QuestionViewModel>();

            foreach (var question in questions)
            {
                var options = db.Options.Where(I => I.QuestionId == question.Id);
                QVM.Add(new QuestionViewModel()
                {
                    Questions = question,
                    Category = question.Category,
                    Options = options.ToArray()
                });
            }

            return View(QVM);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.QuestionCategories, "Id", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,CategoryId,Options")] QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = new Questions()
                {
                    Question = model.Question,
                    CategoryId = model.CategoryId
                };
                db.Questions.Add(question);
                db.SaveChanges();
                foreach (var option in model.Options)
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

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.QuestionCategories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.QuestionCategories, "Id", "Name", questions.CategoryId);
            return View(questions);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Option1,Option2,Option3,Option4,Answer,CategoryId")] Questions questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.QuestionCategories, "Id", "Name", questions.CategoryId);
            return View(questions);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questions questions = db.Questions.Find(id);
            db.Questions.Remove(questions);
            db.SaveChanges();
            return RedirectToAction("Index");
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
}
