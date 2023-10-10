using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class FIAController : Controller
    {
        private readonly IJobsData _jobsData;

        public FIAController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("fia-online-apply")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var Jobs = await _jobsData.GetFIAJobs();
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
