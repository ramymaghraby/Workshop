using Microsoft.AspNetCore.Mvc;

namespace LMS.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
