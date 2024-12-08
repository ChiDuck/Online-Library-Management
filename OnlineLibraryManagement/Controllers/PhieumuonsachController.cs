using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
    [Authorize(Roles = "Thuthu")]
    public class PhieumuonsachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();
        #region Thủ thư
        public IActionResult DSPhieuMuon_Thuthu()
        {
            List<Phieumuonsach> ds = db.Phieumuonsach.OrderByDescending(s => s.Ngaylapphieu).ToList();
            foreach (Phieumuonsach item in ds)
            {
                if (item.Matinhtrang == 2 && item.Hantra.HasValue)
                {
                    if (DateTime.Compare(DateTime.Now.Date, item.Hantra.Value.Date) > 0) //Ngày thực tế > hạn trả => Trễ hạn
                    {
                        try
                        {

                            item.Matinhtrang = 5;
                            List<Chitietphieumuon> dsCTPhieuMuon = db.Chitietphieumuon.Where(x => x.Maphieu == item.Maphieu).ToList();
                            foreach (Chitietphieumuon ct in dsCTPhieuMuon)
                            {
                                ct.Matinhtrang = 4;
                            }    
                            db.SaveChanges();
                        }
                        catch (Exception ex) { }
                    }
                }
                item.MadocgiaNavigation = db.Docgia.Find(item.Madocgia);
                item.MattNavigation = db.Thuthu.Find(item.Matt);
                item.MatinhtrangNavigation = db.Tinhtrangphieu.Find(item.Matinhtrang);
            }
            return View(ds);
        }
        public IActionResult formXemCTPhieuMuon(int maphieumuon)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Phieumuonsach p = db.Phieumuonsach.Include(s => s.MadocgiaNavigation)
                                              .Include(s => s.MattNavigation)
                                              .Include(s => s.MatinhtrangNavigation)
                                              .FirstOrDefault(s => s.Maphieu == maphieumuon);

            ViewBag.DSCTPhieuMuon = db.Chitietphieumuon.Where(x => x.Maphieu == maphieumuon).ToList();
            foreach (Chitietphieumuon ct in ViewBag.DSCTPhieuMuon)
            {
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.Masach);
                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);
            }
            return View(p);
        }
        public IActionResult xacNhanMuonSach([FromBody] CGhichu c)
        {  
            Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
            Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault();
            Phieumuonsach p = db.Phieumuonsach.Find(c.Maphieu);
            if (p != null && p.Matinhtrang == 1) //Nếu tìm thấy phiếu mượn và có tình trạng đang chờ phản hồi
            {
                try
                {
                    //update bảng CTPM
                    List<Chitietphieumuon> dsCTPM = db.Chitietphieumuon.Where(ct => ct.Maphieu == c.Maphieu).ToList();
                    foreach (Chitietphieumuon ct in dsCTPM)
                    {
                        ct.Matinhtrang = 2;
                        db.Update(ct);
                    }

                    //update bảng phiếu mượn
                    p.Matinhtrang = 2;
                    p.Ngaypheduyet = DateTime.Now.Date;
                    p.Hantra = c.Hantra;
                    p.Matt = tt.Matt;
                    db.Phieumuonsach.Update(p);

                    //Cập nhật xuống DB
                    db.SaveChanges();
                    return Json(true);
                }
                catch (Exception e)
                {
                    return Json(false);
                }
            }

            return Json(false);

        }
        public IActionResult tuChoiMuonSach([FromBody] CGhichu c)
        {
            Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
            Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault();
            Phieumuonsach p = db.Phieumuonsach.Find(c.Maphieu);
            if (p != null && p.Matinhtrang == 1)
            {
                try
                {
                    //update bảng phiếu mượn
                    p.Matinhtrang = 4;
                    p.Ngaypheduyet = DateTime.Now.Date;
                    p.Ghichu = c.Ghichu;
                    p.Matt = tt.Matt;
                    db.Phieumuonsach.Update(p);

                    //update bảng sách
                    List<Chitietphieumuon> dsCTPM = db.Chitietphieumuon.Where(ct => ct.Maphieu == c.Maphieu).ToList();
                    foreach (Chitietphieumuon ct in dsCTPM)
                    {
                        ct.Matinhtrang = null;
                        db.Chitietphieumuon.Update(ct);

                        Sach s = db.Sach.Find(ct.Masach);
                        if (s != null)
                        {
                            s.Soluong += 1; //cập nhật lại số lượng
                            db.Sach.Update(s);
                        }
                    }

                    //Cập nhật xuống DB
                    db.SaveChanges();
                    return Json(true);
                }
                catch (Exception e)
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        #endregion

    }
}
