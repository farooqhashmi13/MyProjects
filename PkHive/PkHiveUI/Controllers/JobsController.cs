using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobsData _jobsData;

        public JobsController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("nts-jobs")]
        public async Task<IActionResult> NTS()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByType("NTS");
                return View(jobs);
            }
            catch(Exception ex)
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("join-asf")]
        public async Task<IActionResult> ASF()
        {
            try
            {
                var Jobs = await _jobsData.GetJobsByType("ASF");
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("fbr-jobs")]
        public async Task<IActionResult> FBR()
        {
            try
            {
                var Jobs = await _jobsData.GetJobsByType("FBR");
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }

        }

        [Route("fia-online-apply")]
        public async Task<IActionResult> FIA()
        {
            try
            {
                var Jobs = await _jobsData.GetJobsByType("FIA");
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("ministry-of-climate-change-jobs")]
        public async Task<IActionResult> MOCC()
        {
            try
            {
                var Jobs = await _jobsData.GetJobsByType("MOCC");
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }

        [Route("nab-jobs")]
        public async Task<IActionResult> NAB()
        {
            try
            {
                var Jobs = await _jobsData.GetJobsByType("NAB");
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }

        }

        [Route("nadra-jobs")]
        public async Task<IActionResult> NADRA()
        {
            try
            {
                var Jobs = await _jobsData.GetJobsByType("NADRA");
                return View(Jobs);
            }
            catch
            {
                var jobs = new List<JobViewModel>();
                return View(jobs);
            }
        }
    }
}
