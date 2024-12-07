using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
    public class PhieutrasachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            List<Phieutrasach> ds = db.Phieutrasach.ToList();
            foreach (Phieutrasach item in ds)
            {
                item.MaphieumuonNavigation = db.Phieumuonsach.Find(item.Maphieumuon);
                item.MaphieumuonNavigation.MadocgiaNavigation = db.Docgia.Find(item.MaphieumuonNavigation.Madocgia);
                item.MattNavigation = db.Thuthu.Find(item.Matt);
            }
            return View(ds);
        }
        public IActionResult formLapPhieuTra(int maphieumuon)
        {
            ViewBag.DSCTPhieuMuon = db.Chitietphieumuon.Where(x => x.Maphieu == maphieumuon).ToList();
            foreach (Chitietphieumuon ct in ViewBag.DSCTPhieuMuon)
            {
                ct.MasachNavigation = db.Sach.Find(ct.Masach);
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.MasachNavigation.Masach);
                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);
            }
            return View();
        }
        public IActionResult matSach([FromBody] Chitietphieumuon x)
        {
            Chitietphieumuon ct = db.Chitietphieumuon.Find(x.Maphieu, x.Masach);
            if (ct != null)
            {
                ct.Matinhtrang = 5; //cập nhật sang tình trạng mất sách
                db.Chitietphieumuon.Update(ct);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult lapPhieuTra(Phieutrasach p)
        {
            try
            {
                p.Sosachtra = 0;
                p.MaphieumuonNavigation = db.Phieumuonsach.Find(p.Maphieumuon); //Lấy dữ liệu Phiếu mượn
                p.MaphieumuonNavigation.Chitietphieumuon = db.Chitietphieumuon.Where(x => x.Maphieu == p.Maphieumuon).ToList(); //Lấy dữ liệu CTPM
                foreach (Chitietphieumuon ct in p.MaphieumuonNavigation.Chitietphieumuon)
                {
                    if (ct.Matinhtrang == 2 || ct.Matinhtrang == 4) //tình trạng đang mượn hoặc trễ hạn
                    {
                        ct.Matinhtrang = 3; //cập nhật sang đã trả
                        ct.MasachNavigation = db.Sach.Find(ct.Masach); //Lấy dữ liệu sách trả sách về lại kho
                        ct.MasachNavigation.Soluong++;

                        p.Sosachtra++; //tăng số sách trả
                    }
                }

                Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
                Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault();
                p.Matt = tt.Matt;

                p.MaphieumuonNavigation.Matinhtrang = 3; //cập nhật phiếu mượn sang trạng thái kết thúc

                db.Phieutrasach.Add(p);

                db.SaveChanges();
                TempData["Message"] = "Lập phiếu trả sách thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Lỗi!!!";
            }
            TempData["Message"] = "Lập phiếu trả sách thất bại";
            return RedirectToAction("Index");
        }
        public IActionResult formXemCTPhieuTra(int maphieutra)
        {
            Phieutrasach p = db.Phieutrasach.Include(s => s.MattNavigation)
                                            .Include(s => s.MaphieumuonNavigation)
                                            .ThenInclude(s => s.MadocgiaNavigation)
                                            .FirstOrDefault(s => s.Maphieu == maphieutra);
            ViewBag.DSCTPhieuTra = db.Chitietphieumuon.Where(x => x.Maphieu == p.Maphieumuon && x.Matinhtrang == 3).ToList();
            foreach (Chitietphieumuon ct in ViewBag.DSCTPhieuTra)
            {
                //ct.MasachNavigation = db.Sach.Find(ct.Masach);
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.Masach);
                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);
            }
            return View(p);
        }
    }
}
