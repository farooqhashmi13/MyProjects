using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class NABController : Controller
    {
        private readonly IJobsData _jobsData;

        public NABController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }
        [Route("nab-jobs-2022")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var Jobs = await _jobsData.GetNABJobs();
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
