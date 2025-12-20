using Microsoft.AspNetCore.Mvc;

namespace LMS.Portal.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
