using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class PPSCController : Controller
    {
        private readonly IJobsData _jobsData;

        public PPSCController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("ppsc")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("ppsc-jobs")]
        public async Task<IActionResult> Jobs()
        {
            try
            {
                var subTypes = await _jobsData.GetPPSCJobs();
                return View(subTypes);
            }
            catch
            {
                var subTypes = new List<SubType>();
                return View(subTypes);
            }
        }
    }
}
