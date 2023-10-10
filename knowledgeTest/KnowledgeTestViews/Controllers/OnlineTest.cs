using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestViews.Controllers
{
    [Route("online-test")]
    public class OnlineTest : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
