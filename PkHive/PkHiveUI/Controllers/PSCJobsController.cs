using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class PSCJobsController : Controller
    {
        private readonly IJobsData _jobsData;

        public PSCJobsController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("fpsc-jobs")]
        public async Task<IActionResult> FPSC()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByType("FPSC");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("ppsc-jobs")]
        public async Task<IActionResult> PPSC()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByType("PPSC");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("kppsc-jobs")]
        public async Task<IActionResult> KPPSC()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByType("KPPSC");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("spsc-jobs")]
        public async Task<IActionResult> SPSC()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByType("SPSC");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("bpsc-jobs")]
        public async Task<IActionResult> BPSC()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByType("BPSC");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

    }
}
