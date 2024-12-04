using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;

namespace OnlineLibraryManagement.Controllers
{
    public class PhieumuonsachController : Controller
    {
        QuanLyThuVienContext db = new QuanLyThuVienContext();

        public IActionResult Index()
        {
           return View();
        }
        #region Thủ thư
        public IActionResult DSPhieuMuon_Thuthu()
        {
            List<Phieumuonsach> ds = db.Phieumuonsach.OrderByDescending(s => s.Ngaylapphieu).ToList();
            foreach (Phieumuonsach item in ds)
            {
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
                ct.MasachNavigation = db.Sach.Find(ct.Masach);
                ct.MasachNavigation = db.Sach.Include(s => s.MaloaiNavigation)
                                             .Include(s => s.ManxbNavigation)
                                             .FirstOrDefault(s => s.Masach == ct.MasachNavigation.Masach);
                //ct.MasachNavigation.MaloaiNavigation = db.Theloai.Find(ct.MasachNavigation.Maloai);
                //ct.MasachNavigation.ManxbNavigation = db.Nhaxuatban.Find(ct.MasachNavigation.Manxb);

                //Xét trường hợp cuốn sách trễ hạn
                if (ct.Matinhtrang == 1 && p.Hantra.HasValue)
                {
                    if (DateTime.Compare(DateTime.Now.Date, p.Hantra.Value.Date) > 0) //Ngày thực tế > hạn trả => Trễ hạn
                    {
                        ct.Matinhtrang = 3;
                        try
                        {
                            db.Chitietphieumuon.Update(ct);
                            db.SaveChanges();
                        }
                        catch (Exception ex) { }
                    }    
                }
                ct.MatinhtrangNavigation = db.Tinhtrangmuon.Find(ct.Matinhtrang);
            }
            return View(p);
        }
        public IActionResult xacNhanMuonSach(int maphieumuon)
        {
            Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
            Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault(); 
            Phieumuonsach p = db.Phieumuonsach.Find(maphieumuon);
            if (p != null && p.Matinhtrang == 1) //Nếu tìm thấy phiếu mượn và có tình trạng đang chờ phản hồi
            {
                try
                {
                    //update bảng CTPM
                    List<Chitietphieumuon> dsCTPM = db.Chitietphieumuon.Where(ct => ct.Maphieu == maphieumuon).ToList();
                    foreach (Chitietphieumuon ct in dsCTPM)
                    {
                        ct.Matinhtrang = 1;
                        db.Update(ct);
                    }

                    //update bảng phiếu mượn
                    p.Matinhtrang = 2;
                    p.Ngaymuon = DateTime.Now.Date;
                    p.Hantra = p.Ngaymuon.Value.AddDays(14);
                    p.Matt = tt.Matt; 
                    db.Phieumuonsach.Update(p);

                    //Cập nhật xuống DB
                    db.SaveChanges();
                    return RedirectToAction("DSPhieuMuon_Thuthu");
                }
                catch (Exception e)
                { }
            }    
            
            return View("formXemCTPhieuMuon");
            
        }
        public IActionResult tuChoiMuonSach(int maphieumuon)
        {
            Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
            Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault();
            Phieumuonsach p = db.Phieumuonsach.Find(maphieumuon);
            if (p != null && p.Matinhtrang == 1)
            {
                try
                {
                    //update bảng phiếu mượn
                    p.Matinhtrang = 4;
                    p.Ngaymuon = DateTime.Now.Date;
                    p.Matt = tt.Matt;
                    db.Phieumuonsach.Update(p);

                    //update bảng sách
                    List<Chitietphieumuon> dsCTPM = db.Chitietphieumuon.Where(ct => ct.Maphieu == maphieumuon).ToList();
                    foreach (Chitietphieumuon ct in dsCTPM)
                    {
                        Sach s = db.Sach.Find(ct.Masach);
                        if (s != null)
                        {
                            s.Soluong += 1; //cập nhật lại số lượng
                            db.Sach.Update(s);
                        }   
                    }

                    //Cập nhật xuống DB
                    db.SaveChanges();
                    return RedirectToAction("DSPhieuMuon_Thuthu");
                }
                catch (Exception e)
                { }
            }
            return View("formXemCTPhieuMuon");
        }
        #endregion

    }
}
