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
                var jobsCount = await _jobsData.GetJobsCount();

                ViewBag.nts = jobsCount.NTSCount;
                ViewBag.fpsc = jobsCount.FPSCCount;
                ViewBag.ppsc = jobsCount.PPSCCount;
                ViewBag.fia = jobsCount.FIACount;
                ViewBag.asf = jobsCount.ASFCount;
                ViewBag.fbr = jobsCount.FBRCount;
                ViewBag.nab = jobsCount.NABCount;
                ViewBag.nadra = jobsCount.NADRACount;
                ViewBag.mocc = jobsCount.MOCCCount;
            }
            catch {

                ViewBag.nts = 0;
                ViewBag.fpsc = 0;
                ViewBag.ppsc = 0;
                ViewBag.fia = 0;
                ViewBag.asf = 0;
                ViewBag.fbr = 0;
                ViewBag.nab = 0;
                ViewBag.nadra = 0;
                ViewBag.mocc = 0;

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