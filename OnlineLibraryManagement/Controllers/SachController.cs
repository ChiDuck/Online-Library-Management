using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    public class SachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            List<CSach> ds = db.Saches.Select(x => CSach.chuyenDoi(x)).ToList();
            return View(ds);
        }
    }
}
