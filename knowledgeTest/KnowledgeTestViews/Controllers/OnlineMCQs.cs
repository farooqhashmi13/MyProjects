using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestViews.Controllers
{
    [Route("online-mcqs")]
    public class OnlineMCQs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
