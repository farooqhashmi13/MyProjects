using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class ASFController : Controller
    {
        private readonly IJobsData _jobsData;

        public ASFController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }
        [Route("join-asf")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var Jobs = await _jobsData.GetASFJobs();
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
