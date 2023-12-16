using Microsoft.AspNetCore.Mvc;

namespace website_test.Controllers
{
    public class RpgController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
