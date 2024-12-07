using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
    public class TacgiaController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();

        public IActionResult Index()
        {
            List<CTacgia> list = db.Tacgia.Select(i => CTacgia.chuyenDoi(i)).ToList();
            return View(list);
        }

        public IActionResult frmThemTacgia()
        {
            return View();
        }

        public IActionResult themTacgia(CTacgia ctg)
        {
            if (ModelState.IsValid)
            {
                Tacgia tg = CTacgia.chuyenDoi(ctg);
                db.Tacgia.Add(tg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("frmThemTacgia");
        }

        public IActionResult frmXoaTacgia(int id)
        {
            Tacgia tg = db.Tacgia.Find(id);
            return View(CTacgia.chuyenDoi(tg));
        }

        public IActionResult xoaTacgia(int id)
        {
            try
            {
                Tacgia tg = db.Tacgia.Find(id);
                db.Tacgia.Remove(tg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Không thể xóa tác giả này!";
                return View("Error", error);
            }
        }

        public IActionResult frmSuaTacgia(int id)
        {
            CTacgia ctg = CTacgia.chuyenDoi(db.Tacgia.Find(id));
            return View(ctg);
        }

        public IActionResult suaTacgia(CTacgia ctg)
        {
            Tacgia tg = CTacgia.chuyenDoi(ctg);
            db.Tacgia.Update(tg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
