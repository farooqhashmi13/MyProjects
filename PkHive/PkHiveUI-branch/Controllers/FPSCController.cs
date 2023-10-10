using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;
using PkHiveUI.Models;

namespace PkHiveUI.Controllers
{
    public class FPSCController : Controller
    {
        private readonly IJobsData _jobsData;

        public FPSCController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("fpsc")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("fpsc-jobs")]
        public async Task<IActionResult> Jobs()
        {
            try
            {
                var subTypes = await _jobsData.GetFPSCJobs();
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
