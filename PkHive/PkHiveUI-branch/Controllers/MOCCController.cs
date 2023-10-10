using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class MOCCController : Controller
    {
        private readonly IJobsData _jobsData;

        public MOCCController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("/ministry-of-climate-change-jobs")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var Jobs = await _jobsData.GetMOCCJobs();
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
