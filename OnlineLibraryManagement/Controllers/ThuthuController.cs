using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryManagement.Controllers
{
    public class ThuthuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
