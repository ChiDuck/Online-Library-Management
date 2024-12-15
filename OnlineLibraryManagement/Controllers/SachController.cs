using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
    public class SachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            List<Sach> ds = db.Sach.ToList();
            foreach (var s in ds)
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
            ModelState.Remove("fileImg");
            if (ModelState.IsValid && book != null)
            {

                //kiểm tra năm xuất bản
                if (s.Namxuatban > DateTime.Now.Year)
                {
                    book.Soluong = s.Soluong;
                    book.Namxuatban = s.Namxuatban;
                    book.Manxb = s.Manxb;
                    book.Maloai = s.Maloai;
                    MySessions.Set<Sach>(HttpContext.Session, "sach", book);
                    ModelState.AddModelError("Namxuatban", "Vui lòng nhập năm xuất bản nhỏ hơn hoặc bằng năm hiện tại");
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
                    foreach (Phienbansach p in book.Phienbansach)
                    {
                        Phienbansach Phienbansach = new Phienbansach(); //tạo ra phiên bản sách mới

                        //Sao chép dữ liệu từ phiên bản sách trong biến session
                        Phienbansach.Matacgia = p.Matacgia;
                        Phienbansach.Vaitro = p.Vaitro;
                        Phienbansach.Masach = s.Masach;
                        s.Phienbansach.Add(Phienbansach); //gán vào s
                    }
                }

                else
                {
                    return RedirectToAction("formThemSach");
                }
                db.Sach.Add(s);
                db.SaveChanges();

                //xóa dữ liệu sách cũ khi đã thêm sách
                MySessions.Set<Sach>(HttpContext.Session, "sach", new Sach());

                return RedirectToAction("Index");
            }
            else
            {
                book.Soluong = s.Soluong;
                book.Namxuatban = s.Namxuatban;
                book.Manxb = s.Manxb;
                book.Maloai = s.Maloai;
                MySessions.Set<Sach>(HttpContext.Session, "sach", book);
                return View("formThemSach", book);
            }


        }
        public IActionResult formSuaSach(int id)
        {
            //Sach sach = db.Sach.Find(id);
            //sach.MaloaiNavigation = db.Theloai.Find(sach.Maloai);
            //sach.ManxbNavigation = db.Nhaxuatban.Find(sach.Manxb);
            //foreach (Phienbansach item in db.Phienbansach.Where(s => s.Masach == id).ToList())
            //{
            //    item.MatacgiaNavigation = db.Tacgia.Find(item.Matacgia);
            //    item.Vaitro = db.Phienbansach.FirstOrDefault(t => t.Matacgia == item.Matacgia && t.Masach == id).Vaitro;
            //}
            Sach sach = db.Sach.Include(s => s.MaloaiNavigation)
                               .Include(s => s.ManxbNavigation)
                               .Include(s => s.Phienbansach)
                               .ThenInclude(p => p.MatacgiaNavigation)
                               .FirstOrDefault(s => s.Masach == id);
            return View(sach);
        }
        public IActionResult suaSach(Sach s, IFormFile fileImg)
        {
            ModelState.Remove("fileImg");
            if (ModelState.IsValid)
            {
                if (s.Namxuatban > DateTime.Now.Year)
                {
                    ModelState.AddModelError("Namxuatban", "Vui lòng nhập năm xuất bản nhỏ hơn hoặc bằng năm hiện tại");
                    Sach book = db.Sach.Include(s => s.MaloaiNavigation).Include(a => a.ManxbNavigation).Include(a => a.Phienbansach).ThenInclude(p => p.MatacgiaNavigation).FirstOrDefault(a => a.Masach == s.Masach);
                    return View("formSuaSach", book);

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
            else
            {
                Sach sach = db.Sach.Include(a => a.MaloaiNavigation)
                              .Include(a => a.ManxbNavigation)
                              .Include(a => a.Phienbansach)
                              .ThenInclude(a => a.MatacgiaNavigation)
                              .FirstOrDefault(a => a.Masach == s.Masach);
                return View("formSuaSach", sach);
            }
        }
        public IActionResult formXoaSach(int id)
        {
            //Sach sach = db.Sach.Find(id);
            //sach.MaloaiNavigation = db.Theloai.Find(sach.Maloai);
            //sach.ManxbNavigation = db.Nhaxuatban.Find(sach.Manxb);
            //foreach (Phienbansach item in db.Phienbansach.Where(s => s.Masach == id).ToList())
            //{
            //    item.MatacgiaNavigation = db.Tacgia.Find(item.Matacgia);
            //}
            Sach sach = db.Sach.Include(s => s.MaloaiNavigation)
                              .Include(s => s.ManxbNavigation)
                              .Include(s => s.Phienbansach)
                              .ThenInclude(p => p.MatacgiaNavigation)
                              .FirstOrDefault(s => s.Masach == id);
            if (sach != null)
            {
                bool flag = true;
                if (db.Chitietphieumuon.Where(x => x.Masach == id).Count() > 0)
                {
                    flag = false;
                }
                ViewBag.flag = flag;
                return View(sach);
            }
            else
            {
                return RedirectToAction("Index");
            }
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
                err.RequestId = "Đã xảy ra lỗi khi xóa cuốn sách này!!!";
                return View("Error", err);
            }
        }
        public IActionResult getData([FromBody] Sach x)
        {
            if (x == null)
                x = new Sach();
            Sach book = MySessions.Get<Sach>(HttpContext.Session, "sach");
            book.Soluong = x.Soluong;
            book.Tensach = x.Tensach;
            book.Namxuatban = x.Namxuatban;
            book.Maloai = x.Maloai;
            book.Manxb = x.Manxb;
            MySessions.Set<Sach>(HttpContext.Session, "sach", book);
            return Json(true);

        }
        public IActionResult formChonTacGia()
        {
            ViewBag.DSVaitro = CVaitro.getDSVaitro();
            return View(db.Tacgia.ToList());
        }
        public IActionResult chonTacGia(int matacgia, string vaitro)
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
                pb.Vaitro = vaitro;
                s.Phienbansach.Add(pb);
            }
            MySessions.Set<Sach>(HttpContext.Session, "sach", s);
            return View("formThemSach", s);
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
                return View("formThemSach", s);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
