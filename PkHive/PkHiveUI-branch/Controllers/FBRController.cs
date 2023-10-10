using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class FBRController : Controller
    {
        private readonly IJobsData _jobsData;

        public FBRController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("/fbr-jobs-2022")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var Jobs = await _jobsData.GetFBRJobs();
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<Job>();
                return View(jobs);
            }

        }

    }
}
