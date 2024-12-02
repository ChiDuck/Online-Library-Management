using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    public class ThuthuController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            return View();
        }
        public Taikhoan tk()
        {
            return MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
        }
        public IActionResult Taikhoan()
        {
            Thuthu t = db.Thuthu.Where(x => x.Matk == tk().Matk).FirstOrDefault();
            t.MatkNavigation = tk();
            return View(t);
        }
        public IActionResult frmSuaTaikhoan(int id)
        {
            Thuthu t = db.Thuthu.Find(id);
            t.MatkNavigation = tk();
            return View(t);
        }
        public IActionResult frmDoiMatkhau()
        {
            return View();
        }
    }
}
