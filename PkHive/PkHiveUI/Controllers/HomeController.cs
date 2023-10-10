using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;
using PkHiveUI.Models;
using System.Diagnostics;

namespace PkHiveUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobsData _jobsData;
        private readonly IContactData _contactData;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IJobsData jobsData, IContactData contactData)
        {
            _logger = logger;
            _jobsData = jobsData;
            _contactData = contactData;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var jobs = await _jobsData.GetAllJobs();

                ViewBag.NTSCount = jobs.Count(j => j.Type.Name == "NTS");
                ViewBag.FPSCCount = jobs.Count(j => j.Type.Name == "FPSC");
                ViewBag.PPSCCount = jobs.Count(j => j.Type.Name == "PPSC");
                ViewBag.KPPSCCount = jobs.Count(j => j.Type.Name == "KPPSC");
                ViewBag.SPSCCount = jobs.Count(j => j.Type.Name == "SPSC");
                ViewBag.BPSCCount = jobs.Count(j => j.Type.Name == "BPSC");

                ViewBag.Jobs = jobs;
            }
            catch
            {
                ViewBag.NTSCount = 0;
                ViewBag.FPSCCount = 0;
                ViewBag.PPSCCount = 0;
                ViewBag.KPPSCCount = 0;
                ViewBag.SPSCCount = 0;
                ViewBag.BPSCCount = 0;

                ViewBag.Jobs = new List<Job>();
            }

            return View();
        }

        [Route("/about")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/terms")]
        public IActionResult Terms()
        {
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var contactObj = new ContactUs()
                {
                    FullName = contactViewModel.FullName,
                    Email = contactViewModel.Email,
                    Message = contactViewModel.Message,
                    PhoneNumber = contactViewModel.PhoneNumber,
                    Subject = contactViewModel.Subject,
                    SubmitDateTime = DateTime.Now
                };

                _contactData.AddContactMessage(contactObj);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}