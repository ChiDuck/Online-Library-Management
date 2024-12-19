using OnlineLibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.MyModels
{
	public class CNhaxuatban
	{
		[Display(Name = "Mã NXB")]
		public int Manxb { get; set; }
		[Display(Name = "Tên NXB")]
		[Required(ErrorMessage = "Vui lòng nhập tên NXB")]
		public string? Tennxb { get; set; }
		[Display(Name = "Email")]
		public string? Email { get; set; }
		[Display(Name = "Địa chỉ")]
		public string? Diachi { get; set; }

		public static CNhaxuatban chuyenDoi(Nhaxuatban nxb)
		{
			return new CNhaxuatban
			{
				Manxb = nxb.Manxb,
				Tennxb = nxb.Tennxb,
				Email = nxb.Email,
				Diachi = nxb.Diachi
			};
		}
		public static Nhaxuatban chuyenDoi(CNhaxuatban cnxb)
		{
			return new Nhaxuatban
			{
				Manxb = cnxb.Manxb,
				Tennxb = cnxb.Tennxb,
				Email = cnxb.Email,
				Diachi = cnxb.Diachi
			};
		}
	}
}
