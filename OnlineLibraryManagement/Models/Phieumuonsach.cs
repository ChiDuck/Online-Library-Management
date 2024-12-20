﻿using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
	public partial class Phieumuonsach
	{
		public Phieumuonsach()
		{
			Chitietphieumuon = new HashSet<Chitietphieumuon>();
			Phieugiahan = new HashSet<Phieugiahan>();
		}

		[Display(Name = "Mã phiếu")]
		public int Maphieu { get; set; }

		[Display(Name = "Ngày lập phiếu")]
		public DateTime? Ngaylapphieu { get; set; }

		[Display(Name = "Ngày phê duyệt")]
		public DateTime? Ngaypheduyet { get; set; }

		[Display(Name = "Hạn trả")]
		public DateTime? Hantra { get; set; }

		[Display(Name = "Số lượng sách")]
		public int? Soluongsach { get; set; }

		[Display(Name = "Ghi chú")]
		public string? Ghichu { get; set; }

		[Display(Name = "Tình trạng")]
		public int? Matinhtrang { get; set; }

		[Display(Name = "Thủ thư duyệt")]
		public int? Matt { get; set; }

		[Display(Name = "Độc giả")]
		public int? Madocgia { get; set; }


		public virtual Docgia? MadocgiaNavigation { get; set; }
		public virtual Tinhtrangphieu? MatinhtrangNavigation { get; set; }
		public virtual Thuthu? MattNavigation { get; set; }
		public virtual Phieutrasach? Phieutrasach { get; set; }
		public virtual ICollection<Chitietphieumuon> Chitietphieumuon { get; set; }
		public virtual ICollection<Phieugiahan> Phieugiahan { get; set; }
	}
}
