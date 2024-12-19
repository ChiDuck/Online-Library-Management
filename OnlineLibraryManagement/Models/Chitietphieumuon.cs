namespace OnlineLibraryManagement.Models
{
	public partial class Chitietphieumuon
	{
		public int Maphieu { get; set; }
		public int Masach { get; set; }
		public int? Matinhtrang { get; set; }

		public virtual Phieumuonsach MaphieuNavigation { get; set; } = null!;
		public virtual Sach MasachNavigation { get; set; } = null!;
		public virtual Tinhtrangmuon? MatinhtrangNavigation { get; set; }
	}
}
