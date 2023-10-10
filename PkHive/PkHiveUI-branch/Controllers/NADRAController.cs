using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class NADRAController : Controller
    {
        private readonly IJobsData _jobsData;

        public NADRAController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }
        [Route("nadra-jobs-2022")]
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
