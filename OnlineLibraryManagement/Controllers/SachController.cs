using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;
using System.Collections;
using System.IO;
using waHoadon.Models;

namespace OnlineLibraryManagement.Controllers
{
    public class SachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {   List<Sach> ds = db.Sach.ToList();
            foreach(var s in ds)
            {
                s.ManxbNavigation = db.Nhaxuatban.Find(s.Manxb);
                s.MaloaiNavigation = db.Theloai.Find(s.Maloai);
            }    
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
            return View();
        }
        public IActionResult themSach(Sach s, IFormFile fileImg)
        {
            Sach book = MySessions.Get<Sach>(HttpContext.Session, "sach");
            if (book != null)
            {
                //kiểm tra số lượng
                if (s.Soluong < 1)
                {
                    book.Soluong = s.Soluong;
                    book.Namxuatban = s.Namxuatban;
                    book.Manxb = s.Manxb;
                    book.Maloai = s.Maloai;
                    MySessions.Set<Sach>(HttpContext.Session, "sach", book);
                    ModelState.AddModelError("Soluong", "Số lượng phải lớn hơn 0");
                    ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
                    ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
                    return View("formThemSach", book);
                }

                //kiểm tra năm xuất bản
                if (s.Namxuatban < 1970 || s.Namxuatban > DateTime.Now.Year)
                {
                    book.Soluong = s.Soluong;
                    book.Namxuatban = s.Namxuatban;
                    book.Manxb = s.Manxb;
                    book.Maloai = s.Maloai;
                    MySessions.Set<Sach>(HttpContext.Session, "sach", book);
                    ModelState.AddModelError("Namxuatban", "Vui lòng nhập đầu sách có năm xuất bản mới hơn và nhỏ hơn hoặc bằng năm hiện tại");
                    ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
                    ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
                    return View("formThemSach", book);
                }

                //xử lý hình ảnh
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
                
                if (book.Phienbansach.Count > 0)
                {
                   foreach(Phienbansach p in book.Phienbansach)
                    {
                        Phienbansach Phienbansach = new Phienbansach(); //tạo ra phiên bản sách mới

                        //Sao chép dữ liệu từ phiên bản sách trong biến session
                        Phienbansach.Matacgia = p.Matacgia;
                        Phienbansach.Masach = s.Masach;
                        s.Phienbansach.Add(Phienbansach); //gán vào s
                    }
                }

            }
            else
            {
                ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
                ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
                return RedirectToAction("formThemSach");
            }
            db.Sach.Add(s);
            db.SaveChanges();

            //xóa dữ liệu sách cũ khi đã thêm sách
            MySessions.Set<Sach>(HttpContext.Session, "sach", new Sach());

            return RedirectToAction("Index");

        }
        public IActionResult formSuaSach(int id)
        {
            Sach sach = db.Sach.Find(id);
            sach.MaloaiNavigation = db.Theloai.Find(sach.Maloai);
            sach.ManxbNavigation = db.Nhaxuatban.Find(sach.Manxb);
            foreach (Phienbansach item in db.Phienbansach.Where(s => s.Masach == id).ToList())
            {
                item.MatacgiaNavigation = db.Tacgia.Find(item.Matacgia);
            }
            ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
            ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
            return View(sach);
        }
        public IActionResult suaSach(Sach s, IFormFile fileImg)
        {

            //xử lý số lượng
            if (s.Soluong < 1)
            {
                ModelState.AddModelError("Soluong", "Số lượng phải lớn hơn 0");
                ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
                ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
                return View("formSuaSach",s);

            }
            if (s.Namxuatban < 1970 || s.Namxuatban > DateTime.Now.Year)
            {
                ModelState.AddModelError("Namxuatban", "Vui lòng nhập đầu sách có năm xuất bản mới hơn và nhỏ hơn hoặc bằng năm hiện tại");
                ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
                ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
                return View("formSuaSach", s);

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
            db.Sach.Update(s);
            db.SaveChanges();

              
            return RedirectToAction("Index");
        }
        public IActionResult formXoaSach(int id)
        {
            Sach sach = db.Sach.Find(id);
            sach.MaloaiNavigation = db.Theloai.Find(sach.Maloai);
            sach.ManxbNavigation = db.Nhaxuatban.Find(sach.Manxb);
            foreach (Phienbansach item in db.Phienbansach.Where(s => s.Masach == id).ToList())
            {
                item.MatacgiaNavigation = db.Tacgia.Find(item.Matacgia);
            }    
            return View(sach);
        }
        public IActionResult xoaSach(int masach)
        {
            try
            {
                Sach s = db.Sach.Find(masach);
                foreach (Phienbansach p in db.Phienbansach.Where(s => s.Masach == masach).ToList())
                {
                    db.Phienbansach.Remove(p);
                }
                xoaAnh(s.Anhbia);
                db.Sach.Remove(s);
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
        public IActionResult formChonTacGia()
        {
            return View(db.Tacgia.ToList());
        }
        public IActionResult chonTacGia(int matacgia)
        {
            Tacgia tg = db.Tacgia.Find(matacgia);
            if (tg == null)
            {
                return RedirectToAction("Index");
            }
            Sach s = MySessions.Get<Sach>(HttpContext.Session, "sach");
            if (s == null)
            {
                s = new Sach();
            }
            Phienbansach pb = null;
            foreach (Phienbansach a in s.Phienbansach)
            {
                if (a.Matacgia == matacgia)
                {
                    pb = a;
                    break;
                }    
            }
            if (pb == null)
            {
                pb = new Phienbansach();
                pb.MatacgiaNavigation = tg;
                pb.Matacgia = tg.Matacgia;
                s.Phienbansach.Add(pb);
            }
            MySessions.Set<Sach>(HttpContext.Session,"sach",s);

            ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
            ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
            return View("formThemSach",s);
        }
        public IActionResult xoaTacgia(int matacgia)
        {
            Sach s = MySessions.Get<Sach>(HttpContext.Session, "sach");
            if (s != null)
            {
                foreach (Phienbansach a in s.Phienbansach.Where(t => t.Matacgia == matacgia).ToList())
                {
                    s.Phienbansach.Remove(a);
                }
                MySessions.Set<Sach>(HttpContext.Session, "sach", s);
                ViewBag.DSTheLoai = new SelectList(db.Theloai.ToList(), "Maloai", "Tenloai");
                ViewBag.DSNhaXuatBan = new SelectList(db.Nhaxuatban.ToList(), "Manxb", "Tennxb");
                return View("formThemSach", s);
            }
            else
            {
                return RedirectToAction("Index");
            }    
        }
    }
}
