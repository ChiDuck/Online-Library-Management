using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    public class PhieugiahanController : Controller
    {
        private QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            List<Phieugiahan> ds = db.Phieugiahan.OrderByDescending(s => s.Ngaylapphieu).ToList();
            foreach (Phieugiahan item in ds)
            {
                item.MattNavigation = db.Thuthu.Find(item.Matt);
            }
            return View(ds);
        }
        public IActionResult formXemCTPhieuGiahan(int maphieugiahan)
        {
            Phieugiahan p = db.Phieugiahan.Include(s => s.MaphieumuonNavigation)
                                          .Include(s => s.MattNavigation)
                                          .FirstOrDefault(s => s.Maphieu == maphieugiahan);

    
            return View(p);
        }
    }
}
