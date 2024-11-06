using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    public class SachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            List<CSach> ds = db.Saches.Select(x => CSach.chuyenDoi(x)).ToList();
            return View(ds);
        }
        public IActionResult formThemSach()
        {
            ViewBag.DSTheLoai = new SelectList(db.Theloais.ToList(),"Maloai","Tenloai");
            ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatbans.ToList(), "Manxb", "Tennxb");
            ViewBag.DSTacGia = new MultiSelectList(db.Tacgia.ToList(), "Matacgia", "Tentacgia");
            return View();
        }
        public IActionResult themSach(CSach s, IFormFile fileImg)
        {
            if (ModelState.IsValid)
            {
                //xử lý file ảnh
                if (fileImg != null)
                {
                    s.Anhbia = fileImg.FileName;
                    string tenfile = Directory.GetCurrentDirectory();
                    tenfile += @"\wwwroot\img\" + fileImg.FileName;
                    FileStream f = new FileStream(tenfile, FileMode.Create);
                    fileImg.CopyTo(f);
                    f.Close();
                }
                else
                {
                    s.Anhbia = string.Empty;
                }
                //Thêm dữ liệu vào bảng sách
                Sach sach = CSach.chuyenDoi(s);
                db.Saches.Add(sach);
                db.SaveChanges();

                //Lấy mã sách vừa thêm từ database
                //Mã sách vừa thêm vào sẽ có mã lớn nhất
                if (s.Matacgia != null)
                {
                    int masach = db.Saches.Max(t => t.Masach);
                    Sach sachNew = db.Saches.Find(masach);

                    CSach cSachNew = CSach.chuyenDoi(sachNew);
                    cSachNew.Matacgia = s.Matacgia;
                    cSachNew.Namxuatban = s.Namxuatban;
                    cSachNew.Taiban = s.Taiban;

                    //Thêm dữ liệu vào bảng Phiên bản sách
                    List<Phienbansach> dsPhienBan = CSach.chuyenDoiPhienBanSach(cSachNew);
                    foreach (var item in dsPhienBan)
                    {
                        db.Phienbansaches.Add(item);
                    }
                    db.SaveChanges();
                }    
               
                return RedirectToAction("Index");
            }
            ViewBag.DSTheLoai = new SelectList(db.Theloais.ToList(), "Maloai", "Tenloai");
            ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatbans.ToList(), "Manxb", "Tennxb");
            ViewBag.DSTacGia = new MultiSelectList(db.Tacgia.ToList(), "Matacgia", "Tentacgia");
            return View("formThemSach");

        }

    }
}
