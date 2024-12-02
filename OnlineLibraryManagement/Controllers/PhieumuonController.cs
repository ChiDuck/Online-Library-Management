using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    public class PhieumuonController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            List<Phieumuonsach> ds = db.Phieumuonsach.OrderByDescending(s => s.Ngaylapphieu).ToList();
            foreach (Phieumuonsach item in ds)
            {
                item.MadocgiaNavigation = db.Docgia.Find(item.Madocgia);
                item.MattNavigation = db.Thuthu.Find(item.Matt);
                item.MatinhtrangNavigation = db.Tinhtrangphieu.Find(item.Matinhtrang);
            }    
            return View(ds);
        }
        public IActionResult formXemCTPhieuMuon(int maphieumuon)
        {
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Phieumuonsach p = db.Phieumuonsach.Include(s => s.MadocgiaNavigation)
                                              .Include(s => s.MattNavigation)
                                              .Include(s => s.MatinhtrangNavigation)
                                              .FirstOrDefault(s => s.Maphieu == maphieumuon);

            ViewBag.DSCTPhieuMuon = db.Chitietphieumuon.Where(x => x.Maphieu == maphieumuon).ToList();
            foreach(Chitietphieumuon ct in ViewBag.DSCTPhieuMuon)
            {
                ct.MasachNavigation = db.Sach.Find(ct.Masach);
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.MasachNavigation.Masach);
                //ct.MasachNavigation.MaloaiNavigation = db.Theloai.Find(ct.MasachNavigation.Maloai);
                //ct.MasachNavigation.ManxbNavigation = db.Nhaxuatban.Find(ct.MasachNavigation.Manxb);

                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);


            }    
            return View(p);
        }
    }
}
