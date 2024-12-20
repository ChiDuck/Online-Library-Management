﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryManagement.Models;
using OnlineLibraryManagement.MyModels;

namespace OnlineLibraryManagement.Controllers
{
	[Authorize(Roles = "Thuthu")]
	public class PhieugiahanController : Controller
	{
		private QuanLyThuVienContext db = new QuanLyThuVienContext();
		public IActionResult Index()
		{
			List<Phieugiahan> ds = db.Phieugiahan.OrderByDescending(s => s.Ngaylapphieu).ThenBy(s => s.Matinhtrang).ToList();
			foreach (Phieugiahan item in ds)
			{
				item.MattNavigation = db.Thuthu.Find(item.Matt);
				item.MatinhtrangNavigation = db.Tinhtrangphieu.Find(item.Matinhtrang);
				item.MaphieumuonNavigation = db.Phieumuonsach.Find(item.Maphieumuon);
				item.MaphieumuonNavigation.MadocgiaNavigation = db.Docgia.Find(item.MaphieumuonNavigation.Madocgia);
			}
			return View(ds);
		}
		public IActionResult formXemCTPhieuGiahan(int maphieugiahan)
		{
			Phieugiahan p = db.Phieugiahan.Include(s => s.MattNavigation)
										  .Include(s => s.MatinhtrangNavigation)
										  .Include(s => s.MaphieumuonNavigation)
										  .ThenInclude(x => x.MadocgiaNavigation)
										  .FirstOrDefault(s => s.Maphieu == maphieugiahan);
			if (p != null) return View(p);
			TempData["Message"] = "Độc giả đã hủy yêu cầu. Phiếu gia hạn không tồn tại để xem";
			return RedirectToAction("Index");
		}
		public IActionResult xacNhanGiaHan([FromBody] CGhichu c)
		{
			Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
			Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault();
			Phieugiahan p = db.Phieugiahan.Find(c.Maphieu);
			if (p != null && p.Matinhtrang == 1) //Nếu tìm thấy phiếu và có tình trạng đang chờ phản hồi
			{
				try
				{
					p.Ngaypheduyet = DateTime.Now.Date;
					p.Hantramoi = c.Hantra;
					p.Ghichu = c.Ghichu;
					p.Langiahan += 1;
					p.Matinhtrang = 2;
					p.Matt = tt.Matt;

					p.MaphieumuonNavigation = db.Phieumuonsach.Find(p.Maphieumuon);
					p.MaphieumuonNavigation.Hantra = c.Hantra;


					if (p.MaphieumuonNavigation.Matinhtrang == 5)
					{
						p.MaphieumuonNavigation.Matinhtrang = 2;
						List<Chitietphieumuon> dsCTPM = db.Chitietphieumuon.Where(x => x.Maphieu == p.MaphieumuonNavigation.Maphieu).ToList();
						foreach (Chitietphieumuon ct in dsCTPM)
						{
							if (ct.Matinhtrang == 4)
								ct.Matinhtrang = 2;
						}
					}

					db.SaveChanges();
					return Json(true);
				}
				catch (Exception e)
				{
					return Json(false);
				}
			}
			return Json("Độc giả đã hủy yêu cầu gia hạn");
		}
		public IActionResult tuChoiGiaHan([FromBody] CGhichu c)
		{

			Taikhoan tk = MySessions.Get<Taikhoan>(HttpContext.Session, "taikhoan");
			Thuthu tt = db.Thuthu.Where(t => t.Matk == tk.Matk).FirstOrDefault();
			Phieugiahan p = db.Phieugiahan.Find(c.Maphieu);
			if (p != null && p.Matinhtrang == 1)
			{
				try
				{
					p.Matinhtrang = 4;
					p.Ngaypheduyet = DateTime.Now.Date;
					p.Langiahan += 1;
					p.Ghichu = c.Ghichu;
					p.Matt = tt.Matt;

					db.SaveChanges();
					return Json(true);
				}
				catch (Exception e)
				{
					return Json(false);
				}
			}
			return Json("Độc giả đã hủy yêu cầu gia hạn");
		}

	}
}
