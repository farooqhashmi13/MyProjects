using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.Models.ViewModels;
using RestSharp;

namespace OnlineExam.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Get(int subjectId)
        {

            var quests = _context.Questions.Where(g => g.SubjectId == subjectId).ToList();

            var questionsList = new List<QuestionsList>();

            foreach (var quest in quests)
            {

                var options = _context.Options.Where(q => q.QuestionId == quest.Id).ToList();
                if (options.Count == 4)
                {
                    questionsList.Add(new QuestionsList()
                    {
                        Question = quest,
                        Options = options
                    });
                }
            }

            return Json(new { success = true, data = questionsList });
        }

        [HttpPost]
        public IActionResult Save(QuestionViewModel obj)
        {

            if (obj == null)
                return Json(new { success = false });

            if (obj.Question.Id == 0)
            {
                if (!Add(obj))
                    return Json(new { success = false });
            }
            else
            {
                if (!Edit(obj))
                    return Json(new { success = false });
            }

            return Json(new { success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var quest = _context.Questions.SingleOrDefault(I => I.Id == Id);
            _context.Questions.Remove(quest);

            var options = _context.Options.Where(I => I.QuestionId == Id);

            foreach (var option in options)
            {
                _context.Options.Remove(option);
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        public bool Add(QuestionViewModel obj)
        {
            try
            {
                var question = new Question()
                {
                    Quest = obj.Question.Quest,
                    SubjectId = obj.Question.SubjectId
                };
                _context.Questions.Add(question);
                _context.SaveChanges();

                var questId = _context.Questions.Max(I => I.Id);

                foreach (var option in obj.Options)
                {
                    option.QuestionId = questId;
                    _context.Options.Add(option);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(QuestionViewModel obj)
        {
            try
            {
                var quest = _context.Questions.SingleOrDefault(I => I.Id == obj.Question.Id);

                if (quest == null)
                    return false;

                quest.Quest = obj.Question.Quest;
                quest.SubjectId = obj.Question.SubjectId;

                _context.SaveChanges();

                foreach (var option in obj.Options)
                {
                    var opt = _context.Options.SingleOrDefault(I => I.Id == option.Id);
                    if (opt != null)
                    {
                        opt.Opt = option.Opt;
                        opt.IsAnswer = option.IsAnswer;
                        opt.QuestionId = option.QuestionId;
                    }

                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
