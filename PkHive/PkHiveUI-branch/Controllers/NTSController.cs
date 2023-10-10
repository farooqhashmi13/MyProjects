using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class NTSController : Controller
    {
        private readonly IJobsData _jobsData;

        public NTSController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("nts")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("nts-jobs")]
        public async Task<IActionResult> Jobs()
        {
            try
            {
                var subTypes = await _jobsData.GetNTSJobs();
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
