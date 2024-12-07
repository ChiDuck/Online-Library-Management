using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
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
        public IActionResult suaTaikhoan(Thuthu t)
        {
            if (string.IsNullOrEmpty(t.Tentt))
            {
                ModelState.AddModelError("Tentt", "Tên không được để trống.");
                return View("frmSuaTaikhoan");
            }
            if (string.IsNullOrEmpty(t.Sdt))
            {
                ModelState.AddModelError("Sdt", "Số điện thoại không được để trống.");
                return View("frmSuaTaikhoan");
            }
            if (string.IsNullOrEmpty(t.MatkNavigation.Email))
            {
                ModelState.AddModelError("MatkNavigation.Email", "Email không được để trống.");
                return View("frmSuaTaikhoan");
            }
          


            Thuthu x = db.Thuthu.Find(t.Matt);
            x.Tentt = t.Tentt;
            x.Sdt = t.Sdt;


            string oldEmail = db.Taikhoan.Find(t.Matk).Email;
            if (!t.MatkNavigation.Email.Equals(oldEmail))
            {
                if (db.Taikhoan.Any(a => a.Email == t.MatkNavigation.Email))
                {
                    ModelState.AddModelError("MatkNavigation.Email", "Email đã tồn tại.");
                    return View("frmSuaTaikhoan");
                }
                else
                {
                    x.MatkNavigation.Email = t.MatkNavigation.Email;
                    Taikhoan taikhoan = tk();
                    taikhoan.Email = t.MatkNavigation.Email;
                    MySessions.Set(HttpContext.Session, "taikhoan", taikhoan);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Taikhoan");
        }
        public IActionResult frmDoiMatkhau()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        public IActionResult doiMatkhau(Taikhoan tkmoi)
        {
            ModelState.Remove(nameof(tkmoi.Tentk));
            ModelState.Remove(nameof(tkmoi.Email));

            if (!ModelState.IsValid)
            {
                return View("frmDoiMatkhau");
            }

            Taikhoan t = tk();
            if (t.Matkhau == tkmoi.Matkhaucu)
            {
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
    }
}
