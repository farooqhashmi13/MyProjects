using Microsoft.AspNetCore.Mvc;

namespace PkHiveUI.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/error/404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
