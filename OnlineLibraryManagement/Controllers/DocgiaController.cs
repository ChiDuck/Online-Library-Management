using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryManagement.Controllers
{
    public class DocgiaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
