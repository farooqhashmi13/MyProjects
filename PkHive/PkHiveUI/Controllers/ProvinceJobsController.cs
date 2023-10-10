using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;

namespace PkHiveUI.Controllers
{
    public class ProvinceJobsController : Controller
    {
        private readonly IJobsData _jobsData;

        public ProvinceJobsController(IJobsData jobsData)
        {
            _jobsData = jobsData;
        }

        [Route("govt-jobs-in-islamabad")]
        public async Task<IActionResult> Islamabad()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByLocation("Islamabad");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<Job>();
                return View(jobs);
            }
        }

        [Route("punjab-govt-jobs")]
        public async Task<IActionResult> Punjab()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByLocation("Punjab");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<Job>();
                return View(jobs);
            }
        }

        [Route("sindh-govt-jobs")]
        public async Task<IActionResult> Sindh()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByLocation("Sindh");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<Job>();
                return View(jobs);
            }
        }

        [Route("kpk-govt-jobs")]
        public async Task<IActionResult> KPK()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByLocation("KPK");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<Job>();
                return View(jobs);
            }
        }

        [Route("balochistan-jobs")]
        public async Task<IActionResult> Balochistan()
        {
            try
            {
                var jobs = await _jobsData.GetJobsByLocation("Balochistan");
                return View(jobs);
            }
            catch
            {
                var jobs = new List<Job>();
                return View(jobs);
            }
        }
    }
}
