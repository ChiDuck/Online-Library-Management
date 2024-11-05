using Microsoft.AspNetCore.Mvc;

namespace OnlineLibraryManagement.Controllers
{
    public class LibrarianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
