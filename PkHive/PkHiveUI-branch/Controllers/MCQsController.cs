using Microsoft.AspNetCore.Mvc;
using PkHiveLibrary.Interfaces;

namespace PkHiveUI.Controllers
{
    public class MCQsController : Controller
    {
        private readonly ISubjectsData _subjectsData;

        public MCQsController(ISubjectsData subjectsData)
        {
            _subjectsData = subjectsData;
        }

        [Route("/geography-mcqs")]
        public async Task<IActionResult> Geography()
        {
            var subjectId =await _subjectsData.GetSubjectId("Geography");

            TempData["SubjectId"] = subjectId;

            return Redirect("/test");
        }

    }
}
