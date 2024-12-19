using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
    public class TheloaiController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();

        public IActionResult Index()
        {
            List<CTheloai> list = db.Theloai.Select(i => CTheloai.chuyenDoi(i)).ToList();
            return View(list);
        }

        public IActionResult frmThemTheloai()
        {
            return View();
        }

        public IActionResult themTheloai(string id)
        {
            Theloai tl = new()
            {
                Tenloai = id
            };
            db.Theloai.Add(tl);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult frmXoaTheloai(int id)
        {
            Theloai tl = db.Theloai.Find(id);
            bool flag = true;
            if (db.Sach.Where(x => x.Maloai == id).Count() > 0)
            {
                flag = false;
            }
            ViewBag.flag = flag;
            return View(CTheloai.chuyenDoi(tl));
        }

        public IActionResult xoaTheloai(int id)
        {
            try
            {
                Theloai tl = db.Theloai.Find(id);
                db.Theloai.Remove(tl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Đã xảy ra lỗi khi xóa thể loại này!";
                return View("Error", error);
            }
        }

        public IActionResult frmSuaTheloai(int id)
        {
            CTheloai ctl = CTheloai.chuyenDoi(db.Theloai.Find(id));
            return View(ctl);
        }

        public IActionResult suaTheloai(CTheloai ctl)
        {
            Theloai tl = CTheloai.chuyenDoi(ctl);
            db.Theloai.Update(tl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
