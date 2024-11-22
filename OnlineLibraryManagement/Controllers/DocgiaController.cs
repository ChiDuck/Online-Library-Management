﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    public class DocgiaController : Controller
    {   QuanLyThuVienContext db = new QuanLyThuVienContext();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult hienThiDSSach()
        {
            List<Sach> ds = db.Sach.ToList();
            return View(ds);
        }
        public IActionResult timSach(string giatricantim)
        {
            List<Sach> dsGoc = db.Sach.ToList();
            List<Sach> dsTimKiem = null;

            //Trường hợp để trống giá trị tìm kiếm
            if (string.IsNullOrEmpty(giatricantim))
            {
                return View("hienThiDSSach", dsGoc);
            }
            
            //tìm theo tên sách
            dsTimKiem = db.Sach.Where(s => s.Tensach.Contains(giatricantim)).ToList();
            if (dsTimKiem.Count > 0)
            {
                return View("hienThiDSSach", dsTimKiem);
            }

            //Tìm theo năm xuất bản
            try
            {
                int namxb = Int32.Parse(giatricantim);
                dsTimKiem = db.Sach.Where(s => s.Namxuatban == namxb).ToList();
                if (dsTimKiem.Count > 0)
                {
                    return View("hienThiDSSach", dsTimKiem);
                }
            }
            catch (Exception ex)
            {
                //Tìm theo tên tác giả
                var kq = from sach in db.Sach
                         join phienbansach in db.Phienbansach on sach.Masach equals phienbansach.Masach
                         join tacgia in db.Tacgia on phienbansach.Matacgia equals tacgia.Matacgia
                         where tacgia.Tentacgia.Contains(giatricantim)
                         select new Sach {
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
                    return View("hienThiDSSach", dsTimKiem);
                }

            }
            ModelState.AddModelError("", "Không tìm thấy");
            return View("hienThiDSSach",dsGoc);
        }
        public IActionResult locSach(int theloai, int nhaxuatban )
        {
            List<Sach> dsGoc = db.Sach.ToList();
            List<Sach> dsLoc = null;
            if (theloai != 0 && nhaxuatban == 0)
            {
                dsLoc = db.Sach.Where(s => s.Maloai == theloai).ToList();
                if (dsLoc.Count > 0)
                    return View("hienThiDSSach", dsLoc);
                else
                {
                    ModelState.AddModelError("", "Chưa có sách thỏa điều kiện lọc");
                    return View("hienThiDSSach", dsGoc);
                }    
            }
            else if (theloai == 0 && nhaxuatban != 0)
            {
                dsLoc = db.Sach.Where(s => s.Manxb == nhaxuatban).ToList();
                if (dsLoc.Count > 0)
                    return View("hienThiDSSach", dsLoc);
                else
                {
                    ModelState.AddModelError("", "Chưa có sách thỏa điều kiện lọc");
                    return View("hienThiDSSach", dsGoc);
                }
            }
            else if (theloai != 0 && nhaxuatban != 0)
            {
                dsLoc = db.Sach.Where(s => s.Maloai == theloai && s.Manxb == nhaxuatban).ToList();
                if (dsLoc.Count > 0)
                    return View("hienThiDSSach", dsLoc);
                else
                {
                    ModelState.AddModelError("", "Chưa có sách thỏa điều kiện lọc");
                    return View("hienThiDSSach", dsGoc);
                }
            }
            else
            {
                dsLoc = db.Sach.ToList();
                return View("hienThiDSSach", dsLoc);
            }
        }


        public Taikhoan tk()
        {
            return MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
        }

        public IActionResult Taikhoan()
        {
            Docgia dg = db.Docgia.Where(x => x.Matk == tk().Matk).FirstOrDefault();
            dg.MatkNavigation = tk();
            return View(dg);
        }

        public IActionResult frmSuaTaikhoan(int id)
        {
            Docgia dg = db.Docgia.Find(id);
            dg.MatkNavigation = tk();
            return View(dg);
        }

        public IActionResult suaTaikhoan(Docgia dg)
        {    
            Taikhoan x = tk();
            x.Email = dg.MatkNavigation.Email;     
            MySessions.Set(HttpContext.Session, "taikhoan",x);
        
            dg.MatkNavigation = tk();
            if (db.Taikhoan.Any(t => t.Email == dg.MatkNavigation.Email))
            {
                ModelState.AddModelError("MatkNavigation.Email", "Email đã tồn tại.");
                return View("frmSuaTaikhoan");
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
            db.Docgia.Update(dg);    
            db.SaveChanges();               
            return RedirectToAction("Taikhoan");
        }

        public IActionResult frmDoiMatkhau(int id)
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