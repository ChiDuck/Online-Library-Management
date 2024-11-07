using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;
using System.IO;

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
        public void xoaAnh(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            path += @"\wwwroot\img\" + filename;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        public IActionResult formThemSach()
        {
            ViewBag.DSTheLoai = new SelectList(db.Theloais.ToList(),"Maloai","Tenloai");
            ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatbans.ToList(), "Manxb", "Tennxb");
            ViewBag.DSTacGia = new MultiSelectList(db.Tacgias.ToList(), "Matacgia", "Tentacgia");
            return View();
        }
        public IActionResult themSach(CSach s, IFormFile fileImg)
        {


            //xử lý số lượng
            if (s.Soluong < 1 )
            {
                ModelState.AddModelError("Soluong", "Số lượng phải lớn hơn 0");
                ViewBag.DSTheLoai = new SelectList(db.Theloais.ToList(), "Maloai", "Tenloai");
                ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatbans.ToList(), "Manxb", "Tennxb");
                ViewBag.DSTacGia = new MultiSelectList(db.Tacgias.ToList(), "Matacgia", "Tentacgia");
                return View("formThemSach");
            }

            //Xử lý hình ảnh
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
            if (s.Matacgias != null)
            {
                int masach = db.Saches.Max(t => t.Masach);
                Sach sachNew = db.Saches.Find(masach);

                CSach cSachNew = CSach.chuyenDoi(sachNew);
                cSachNew.Matacgias = s.Matacgias;
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
        public IActionResult formSuaSach(int id)
        {
            Sach sach = db.Saches.Find(id);
            CSach s = CSach.chuyenDoi(sach);

            List<Phienbansach> dsPhienBan = new List<Phienbansach>();
            dsPhienBan = db.Phienbansaches.Where(p => p.Masach == id).ToList();
            CSach s2 = CSach.chuyenDoiPhienBanSach(dsPhienBan);
            if (s2 != null)
            {
                s.Matacgias = s2.Matacgias;
                s.Taiban = s2.Taiban;
                s.Namxuatban = s2.Namxuatban;
            }

            ViewBag.DSTheLoai = new SelectList(db.Theloais.ToList(), "Maloai", "Tenloai");
            ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatbans.ToList(), "Manxb", "Tennxb");
            ViewBag.DSTacGia = new MultiSelectList(db.Tacgias.ToList(), "Matacgia", "Tentacgia");
            return View(s);
        }
        public IActionResult suaSach(CSach s, IFormFile fileImg)
        {

            //xử lý số lượng
            if (s.Soluong < 1)
            {
                ModelState.AddModelError("Soluong", "Số lượng phải lớn hơn 0");
                ViewBag.DSTheLoai = new SelectList(db.Theloais.ToList(), "Maloai", "Tenloai");
                ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatbans.ToList(), "Manxb", "Tennxb");
                ViewBag.DSTacGia = new MultiSelectList(db.Tacgias.ToList(), "Matacgia", "Tentacgia");
                return View("formSuaSach");

            }

            //xử lý file ảnh
            if (fileImg != null)
            {
                xoaAnh(s.Anhbia); //xóa ảnh cũ đi
                //Thêm ảnh mới vào folder img
                s.Anhbia = fileImg.FileName;
                string tenfile = Directory.GetCurrentDirectory();
                tenfile += @"\wwwroot\img\" + fileImg.FileName;
                FileStream f = new FileStream(tenfile, FileMode.Create);
                fileImg.CopyTo(f);
                f.Close();
            }
            //Cập nhật dữ liệu vào bảng sách
            Sach sach = CSach.chuyenDoi(s);
            db.Saches.Update(sach);
            db.SaveChanges();

              
            if (s.Matacgias != null)
            {
            //Cập nhật dữ liệu vào bảng Phiên bản sách
                //xóa phiên bản sách cũ đi
                List<Phienbansach> dsPhienBanCu = db.Phienbansaches.Where(p => p.Masach == s.Masach).ToList();
                foreach (var item in dsPhienBanCu)
                {
                    db.Phienbansaches.Remove(item);
                }
                db.SaveChanges();
                List<Phienbansach> dsPhienBanMoi = CSach.chuyenDoiPhienBanSach(s);    
                    
                //Thêm mới lại
                foreach (var item in dsPhienBanMoi)
                {
                    db.Phienbansaches.Add(item);
                }
                db.SaveChanges();
            }
            else
            {
                List<Phienbansach> dsPhienBanCu = db.Phienbansaches.Where(p => p.Masach == s.Masach).ToList();
                foreach (var item in dsPhienBanCu)
                {
                    db.Phienbansaches.Remove(item);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult formXoaSach(int id)
        {
            int dem = 0;
            dem = db.Phienbansaches.Count(p => p.Masach == id);
            ViewBag.flagXoa = true;
            if (dem > 0)
            {
                ViewBag.flagXoa = false;
            }

            Sach sach = db.Saches.Find(id);
            CSach s = CSach.chuyenDoi(sach);

            List<Phienbansach> dsPhienBan = new List<Phienbansach>();
            dsPhienBan = db.Phienbansaches.Where(p => p.Masach == id).ToList();
            CSach s2 = CSach.chuyenDoiPhienBanSach(dsPhienBan);
            if (s2 != null)
            {
                s.Matacgias = s2.Matacgias;
                s.Taiban = s2.Taiban;
                s.Namxuatban = s2.Namxuatban;
            }
            return View(s);
        }
        public IActionResult xoaSach(int masach)
        {
            try
            {
                Sach s = db.Saches.Find(masach);
                xoaAnh(s.Anhbia);
                db.Saches.Remove(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ErrorViewModel err = new ErrorViewModel();
                err.RequestId = e.Message;
                return View("Error", err);
            }
        }
    }
}
