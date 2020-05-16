using Microsoft.AspNetCore.Mvc;

namespace SanAndreas.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
