using Microsoft.AspNetCore.Mvc;

namespace CrudApi.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
