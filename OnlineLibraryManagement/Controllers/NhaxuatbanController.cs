using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    public class NhaxuatbanController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();

        public IActionResult Index()
        {
            List<CNhaxuatban> list = db.Nhaxuatban.Select(i => CNhaxuatban.chuyenDoi(i)).ToList();
            return View(list);
        }

        public IActionResult frmThemNhaxuatban()
        {
            return View();
        }

        public IActionResult themNhaxuatban(CNhaxuatban cnxb)
        {
            if (ModelState.IsValid)
            {
                Nhaxuatban nxb = CNhaxuatban.chuyenDoi(cnxb);
                db.Nhaxuatban.Add(nxb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("frmThemNhaxuatban");
        }

        public IActionResult frmXoaNhaxuatban(int id)
        {
            Nhaxuatban nxb = db.Nhaxuatban.Find(id);
            return View(CNhaxuatban.chuyenDoi(nxb));
        }

        public IActionResult xoaNhaxuatban(int id)
        {
            try
            {
                Nhaxuatban nxb = db.Nhaxuatban.Find(id);
                db.Nhaxuatban.Remove(nxb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Không thể xóa nhà xuất bản này!";
                return View("Error", error);
            }
        }

        public IActionResult frmSuaNhaxuatban(int id)
        {
            CNhaxuatban cnxb = CNhaxuatban.chuyenDoi(db.Nhaxuatban.Find(id));
            return View(cnxb);
        }

        public IActionResult suaNhaxuatban(CNhaxuatban cnxb)
        {
            Nhaxuatban nxb = CNhaxuatban.chuyenDoi(cnxb);
            db.Nhaxuatban.Update(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
