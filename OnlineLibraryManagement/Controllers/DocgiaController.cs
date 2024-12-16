using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{

    public class DocgiaController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();

        #region Độc giả
        [Authorize(Roles = "Docgia")]
        public IActionResult Index()
        {
            List<Sach> ds = db.Sach.Where(t => t.Namxuatban == DateTime.Now.Year).ToList();
            ViewBag.dsSachMoi = ds;
            return View();
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult hienThiDSSach()
        {
            List<Sach> dsSach = MySessions.Get<List<Sach>>(HttpContext.Session, "dsSach");
            if (dsSach != null)
            {
                foreach (Sach item in dsSach)
                {
                    item.MaloaiNavigation = db.Theloai.Find(item.Maloai);
                    item.ManxbNavigation = db.Nhaxuatban.Find(item.Manxb);
                }
                ViewBag.dsSach = dsSach;
            }
            ViewBag.soSachMuon = dsSach != null ? dsSach.Count : 0;

            // Kiểm tra xem có phiếu mượn đang chờ phê duyệt không
            int mdg = MySessions.Get<int>(HttpContext.Session, "madocgia");
            if (db.Phieumuonsach.Any(t => t.Madocgia == mdg && t.Matinhtrang == 1))
            {
                MySessions.Set(HttpContext.Session, "tinhTrang", true);
            }
            else
            {
                MySessions.Set(HttpContext.Session, "tinhTrang", false);
            }
            ViewBag.tinhTrang = checkFlag("tinhTrang");

            //Trả về danh sách tìm kiếm hoặc lọc
            List<Sach> ds = db.Sach.ToList();
            string dsJson = HttpContext.Session.GetString("timkiem");
            if (dsJson != null)
            {
                ds = JsonConvert.DeserializeObject<List<Sach>>(dsJson);
            }
            else
            {
                ModelState.AddModelError("", "Không có sách thỏa điều kiện");
            }
            return View(ds);
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult timSach(string giatricantim)
        {
            if (string.IsNullOrEmpty(giatricantim)) HttpContext.Session.Remove("timkiem");

            List<Sach> dsGoc = db.Sach.ToList();
            List<Sach> dsTimKiem = null;

            //Trường hợp để trống giá trị tìm kiếm
            if (string.IsNullOrEmpty(giatricantim))
            {
                HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsGoc));
                return RedirectToAction("hienThiDSSach");
            }

            //tìm theo tên sách
            dsTimKiem = db.Sach.Where(s => s.Tensach.Contains(giatricantim)).ToList();
            if (dsTimKiem.Count > 0)
            {
                HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsTimKiem));
                return RedirectToAction("hienThiDSSach");
            }

            //Tìm theo năm xuất bản
            try
            {
                int namxb = Int32.Parse(giatricantim);
                dsTimKiem = db.Sach.Where(s => s.Namxuatban == namxb).ToList();
                if (dsTimKiem.Count > 0)
                {
                    HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsTimKiem));
                    return RedirectToAction("hienThiDSSach");
                }
            }
            catch (Exception ex)
            {
                //Tìm theo tên tác giả
                var kq = from sach in db.Sach
                         join phienbansach in db.Phienbansach on sach.Masach equals phienbansach.Masach
                         join tacgia in db.Tacgia on phienbansach.Matacgia equals tacgia.Matacgia
                         where tacgia.Tentacgia.Contains(giatricantim)
                         select new Sach
                         {
                             Masach = sach.Masach,
                             Tensach = sach.Tensach,
                             Soluong = sach.Soluong,
                             Namxuatban = sach.Namxuatban,
                             Anhbia = sach.Anhbia,
                             Maloai = sach.Maloai,
                             Manxb = sach.Manxb
                         };
                dsTimKiem = kq.ToList();
                if (dsTimKiem.Count > 0)
                {
                    HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsTimKiem));
                    return RedirectToAction("hienThiDSSach");
                }

            }
            HttpContext.Session.Remove("timkiem");
            return RedirectToAction("hienThiDSSach");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult locSach(int theloai, int nhaxuatban)
        {
            HttpContext.Session.Remove("timkiem");
            List<Sach> dsLoc = null;
            if (theloai != 0 && nhaxuatban == 0)
            {
                dsLoc = db.Sach.Where(s => s.Maloai == theloai).ToList();
                if (dsLoc.Count > 0)
                {
                    HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsLoc));
                    return RedirectToAction("hienThiDSSach");
                }
                return RedirectToAction("hienThiDSSach");
            }
            else if (theloai == 0 && nhaxuatban != 0)
            {
                dsLoc = db.Sach.Where(s => s.Manxb == nhaxuatban).ToList();
                if (dsLoc.Count > 0)
                {
                    HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsLoc));
                    return RedirectToAction("hienThiDSSach");
                }
                return RedirectToAction("hienThiDSSach");
            }
            else if (theloai != 0 && nhaxuatban != 0)
            {
                dsLoc = db.Sach.Where(s => s.Maloai == theloai && s.Manxb == nhaxuatban).ToList();
                if (dsLoc.Count > 0)
                {
                    HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsLoc));
                    return RedirectToAction("hienThiDSSach");
                }
                return RedirectToAction("hienThiDSSach");
            }

            dsLoc = db.Sach.ToList();
            HttpContext.Session.SetString("timkiem", JsonConvert.SerializeObject(dsLoc));
            return RedirectToAction("hienThiDSSach");
        }

        [Authorize(Roles = "Docgia")]
        public Taikhoan tk()
        {
            return MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
        }

        [Authorize(Roles = "Docgia")]
        public bool checkFlag(string s)
        {
            if (MySessions.Get<bool?>(HttpContext.Session, s) == null)
                return false;
            else
            {
                return MySessions.Get<bool>(HttpContext.Session, s);
            }
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult Taikhoan()
        {
            Docgia dg = db.Docgia.Where(x => x.Matk == tk().Matk).FirstOrDefault();
            dg.MatkNavigation = tk();
            return View(dg);
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult frmSuaTaikhoan(int id)
        {
            Docgia dg = db.Docgia.Find(id);
            dg.MatkNavigation = tk();
            return View(dg);
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult suaTaikhoan(Docgia dg)
        {
            Taikhoan x = tk();

            if (x.Email != dg.MatkNavigation.Email)
            {
                if (db.Taikhoan.Any(t => t.Email == dg.MatkNavigation.Email))
                {
                    ModelState.AddModelError("MatkNavigation.Email", "Email đã tồn tại.");
                    return View("frmSuaTaikhoan");
                }
                x.Email = dg.MatkNavigation.Email;
                MySessions.Set(HttpContext.Session, "taikhoan", x);
            }
            if (string.IsNullOrEmpty(dg.MatkNavigation.Email))
            {
                ModelState.AddModelError("MatkNavigation.Email", "Email không được để trống.");
                return View("frmSuaTaikhoan");
            }
            if (dg.Ngaysinh > DateTime.Now)
            {
                ModelState.AddModelError("Ngaysinh", "Ngày sinh lớn hơn ngày hiện tại");
                return View("frmSuaTaikhoan");
            }
            dg.MatkNavigation = tk();
            db.Docgia.Update(dg);
            db.SaveChanges();
            return RedirectToAction("Taikhoan");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult frmDoiMatkhau()
        {
            return View();
        }

        [Authorize(Roles = "Docgia")]
        [ValidateAntiForgeryToken]
        public IActionResult doiMatkhau(Taikhoan tkmoi)
        {
            ModelState.Remove(nameof(tkmoi.Tentk));
            ModelState.Remove(nameof(tkmoi.Email));

            if (!ModelState.IsValid) return View("frmDoiMatkhau");

            Taikhoan t = tk();
            if (t.Matkhau == tkmoi.Matkhaucu)
            {
                if (tkmoi.Matkhaucu == tkmoi.Matkhau)
                {
                    ModelState.AddModelError("Matkhau", "Mật khẩu mới phải khác mật khẩu cũ");
                    return View("frmDoiMatkhau");
                }
                t.Matkhau = tkmoi.Matkhau;
            }
            else
            {
                ModelState.AddModelError("Matkhaucu", "Sai mật khẩu");
                return View("frmDoiMatkhau");
            }

            db.Taikhoan.Update(t);
            db.SaveChanges();
            MySessions.Set(HttpContext.Session, "taikhoan", t);
            return RedirectToAction("Taikhoan");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult dsPhieumuonsach()
        {
            ViewBag.dangLapPhieu = checkFlag("dangLapPhieu");
            if (ViewBag.dangLapPhieu)
            {
                ViewBag.PhieuMoi = MySessions.Get<Phieumuonsach>(HttpContext.Session, "lapPMS");
                List<Sach> dsSach = MySessions.Get<List<Sach>>(HttpContext.Session, "dsSach");
                foreach (Sach item in dsSach)
                {
                    item.MaloaiNavigation = db.Theloai.Find(item.Maloai);
                    item.ManxbNavigation = db.Nhaxuatban.Find(item.Manxb);
                }
                ViewBag.dsSach = dsSach;
            }

            int madg = MySessions.Get<int>(HttpContext.Session, "madocgia");
            List<Phieumuonsach> dspms = db.Phieumuonsach
                .OrderByDescending(x => x.Maphieu)
                .Where(x => x.Madocgia == madg)
                .Include(x => x.MatinhtrangNavigation)
                .Include(x => x.MattNavigation)
                .ToList();
            return View(dspms);
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult chonSach(int id)
        {
            Sach sach = db.Sach.Find(id);
            Phieumuonsach pms = new Phieumuonsach();
            List<Sach> dsSach = MySessions.Get<List<Sach>>(HttpContext.Session, "dsSach");
            if (dsSach == null) dsSach = new List<Sach>();
            if (dsSach.Count < 7) dsSach.Add(sach);
            else return RedirectToAction("hienThiDSSach");

            if (!checkFlag("dangLapPhieu")) //flag chọn sách lần đầu tiên -> khởi tạo phiếu mượn
            {
                MySessions.Set(HttpContext.Session, "dangLapPhieu", true);
                pms.Ngaylapphieu = DateTime.Now.Date;
                pms.Soluongsach = 1;
                pms.Madocgia = MySessions.Get<int>(HttpContext.Session, "madocgia");
            }
            else
            {
                pms = MySessions.Get<Phieumuonsach>(HttpContext.Session, "lapPMS");
                pms.Soluongsach++;
            }

            MySessions.Set(HttpContext.Session, "lapPMS", pms);
            MySessions.Set(HttpContext.Session, "dsSach", dsSach);

            return RedirectToAction("hienThiDSSach");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult xoaSach(int id)
        {
            Phieumuonsach pms = MySessions.Get<Phieumuonsach>(HttpContext.Session, "lapPMS");
            pms.Soluongsach--;
            MySessions.Set(HttpContext.Session, "lapPMS", pms);

            List<Sach> dsSach = MySessions.Get<List<Sach>>(HttpContext.Session, "dsSach");
            dsSach.RemoveAll(t => t.Masach == id);
            MySessions.Set(HttpContext.Session, "dsSach", dsSach);

            return RedirectToAction("dsPhieumuonsach");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult huyPhieu()
        {
            removeSessions();
            return RedirectToAction("dsPhieumuonsach");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult taoPhieu()
        {
            Phieumuonsach pms = MySessions.Get<Phieumuonsach>(HttpContext.Session, "lapPMS");
            List<Sach> dsSach = MySessions.Get<List<Sach>>(HttpContext.Session, "dsSach");
            pms.Matinhtrang = 1;
            db.Phieumuonsach.Add(pms);
            db.SaveChanges();

            Phieumuonsach phieumoi = db.Phieumuonsach.Find(pms.Maphieu);

            foreach (Sach s in dsSach)
            {
                s.Soluong--;
                db.Sach.Update(s);

                Chitietphieumuon ctpm = new Chitietphieumuon();
                ctpm.Maphieu = phieumoi.Maphieu;
                ctpm.Masach = s.Masach;
                ctpm.Matinhtrang = 1;
                db.Chitietphieumuon.Add(ctpm);
                db.SaveChanges();
            }
            removeSessions();

            return RedirectToAction("dsPhieumuonsach");
        }

        [Authorize(Roles = "Docgia")]
        public void removeSessions()
        {
            MySessions.Set(HttpContext.Session, "dangLapPhieu", false);
            HttpContext.Session.Remove("lapPMS");
            HttpContext.Session.Remove("dsSach");
        }

        [Authorize(Roles = "Docgia")]
        public IActionResult chitietPhieumuonsach(int id)
        {
            Phieumuonsach pms = db.Phieumuonsach
                .Include(x => x.MatinhtrangNavigation)
                .Include(x => x.MattNavigation)
                .FirstOrDefault(x => x.Maphieu == id);

            ViewBag.DSCTPhieuMuon = db.Chitietphieumuon.Where(x => x.Maphieu == id).ToList();
            foreach (Chitietphieumuon ct in ViewBag.DSCTPhieuMuon)
            {
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.Masach);

                if (ct.Matinhtrang == 1 && pms.Hantra.HasValue)
                {
                    if (DateTime.Compare(DateTime.Now.Date, pms.Hantra.Value.Date) > 0)
                    {
                        ct.Matinhtrang = 3;
                        try
                        {
                            db.Chitietphieumuon.Update(ct);
                            db.SaveChanges();
                        }
                        catch (Exception ex) { }
                    }
                }
                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);
            }

            return View(pms);
        }
        [Authorize(Roles = "Docgia")]
        public IActionResult dsPhieutrasach()
        {
            int mdg = MySessions.Get<int>(HttpContext.Session, "madocgia");
            List<Phieutrasach> ds = db.Phieutrasach
                .Where(t => t.MaphieumuonNavigation.Madocgia == mdg)
                .Include(t => t.MattNavigation)
                .ToList();
            return View(ds);
        }
        [Authorize(Roles = "Docgia")]
        public IActionResult chitietPhieutrasach(int id)
        {
            Phieutrasach p = db.Phieutrasach.Include(s => s.MattNavigation)
                                            .Include(s => s.MaphieumuonNavigation)
                                            .FirstOrDefault(s => s.Maphieu == id);
            ViewBag.DSCTPhieuTra = db.Chitietphieumuon.Where(x => x.Maphieu == p.Maphieumuon && x.Matinhtrang == 3).ToList();
            foreach (Chitietphieumuon ct in ViewBag.DSCTPhieuTra)
            {
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.Masach);
                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);
            }
            return View(p);
        }

        public IActionResult dsPhieugiahan()
        {
            int mdg = MySessions.Get<int>(HttpContext.Session, "madocgia");
            List<Phieugiahan> ds = db.Phieugiahan
                .OrderByDescending(t => t.Ngaylapphieu)
                .Where(t => t.MaphieumuonNavigation.Madocgia == mdg)
                .Include(t => t.MatinhtrangNavigation)
                .Include(t => t.MattNavigation)
                .ToList();
            return View(ds);
        }

        public IActionResult themPhieugiahan([FromBody] CGhichu x)
        {
            int mdg = MySessions.Get<int>(HttpContext.Session, "madocgia");
            Phieumuonsach pms = db.Phieumuonsach.Where(k => k.Maphieu == x.Maphieu && k.Madocgia == mdg).FirstOrDefault();
            int lanGH = 0;

            if (pms != null)
            {
                if (db.Phieugiahan.Where(t => t.Matinhtrang == 1 && t.Maphieumuon == x.Maphieu).Count() > 0)
                {
                    return Json("chogiahan");
                }
                switch (pms.Matinhtrang)
                {
                    case 1: return Json("chuaduyet");
                    case 3: return Json("ketthuc");
                    case 4: return Json("tuchoi");
                }
                lanGH = db.Phieugiahan.Where(t => t.Matinhtrang == 2 && t.Maphieumuon == x.Maphieu).Count();
                if (lanGH >= 2) return Json("toida");
            }
            else return Json("khongco");

            Phieugiahan p = new()
            {
                Ngaylapphieu = DateTime.Now.Date,
                Langiahan = lanGH,
                Matinhtrang = 1,
                Maphieumuon = x.Maphieu,
                Lydo = x.Ghichu
            };

            db.Phieugiahan.Add(p);
            db.SaveChanges();

            return Json(true);
        }

        public IActionResult chitietPhieugiahan(int id)
        {
            Phieugiahan p = db.Phieugiahan.Find(id);
            return View(p);
        }
        #endregion

        #region Thủ thư
        [Authorize(Roles = "Thuthu")]
        public IActionResult hienthiDSDocgia()
        {
            List<Docgia> ds = db.Docgia.ToList();
            foreach (Docgia d in ds)
            {
                d.MatkNavigation = db.Taikhoan.Find(d.Matk);
            }
            return View(ds);
        }
        [Authorize(Roles = "Thuthu")]
        public IActionResult formXemCTDocGia(int madocgia)
        {
            Docgia d = db.Docgia.Find(madocgia);
            if (d != null)
            {
                d.MatkNavigation = db.Taikhoan.Find(d.Matk);
            }
            ViewBag.DSPhieuMuon = db.Phieumuonsach.Include(s => s.MattNavigation)
                                                  .Include(s => s.MatinhtrangNavigation)
                                                  .Where(s => s.Madocgia == madocgia)
                                                  .ToList();
            return View(d);
        }
        #endregion


    }
}
