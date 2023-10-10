using KnowledgeTestLibrary.Interfaces;
using KnowledgeTestViews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KnowledgeTestViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubjectsData _subjectsData;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISubjectsData subjectsData)
        {
            _logger = logger;
            _subjectsData = subjectsData;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Subjects = await _subjectsData.ShowAllAsync();
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("/contact")]
        public IActionResult Contact(object obj)
        {
            ViewBag.Message = "Thankyou for contacting us!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}