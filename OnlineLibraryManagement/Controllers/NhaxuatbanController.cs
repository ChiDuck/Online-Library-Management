using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
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

        public IActionResult themNhaxuatban([FromBody] CNhaxuatban2 cnxb)
        {
            Nhaxuatban nxb = new()
            {
                Tennxb = cnxb.Tennxb,
                Email = cnxb.Email,
                Diachi = cnxb.Diachi
            };
            db.Nhaxuatban.Add(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult frmXoaNhaxuatban(int id)
        {
            Nhaxuatban nxb = db.Nhaxuatban.Find(id);
            bool flag = true;
            if (db.Sach.Where(x => x.Manxb == id).Count() > 0)
            {
                flag = false;
            }
            ViewBag.flag = flag;
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
                error.RequestId = "Đã xảy ra lỗi khi xóa nhà xuất bản này!!!";
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
