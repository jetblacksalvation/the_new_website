using Microsoft.AspNetCore.Mvc;

namespace website_test.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
