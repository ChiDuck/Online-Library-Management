using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Chitietphieumuon = new HashSet<Chitietphieumuon>();
            Phienbansach = new HashSet<Phienbansach>();
        }

        public int Masach { get; set; }
        public string? Tensach { get; set; }
        public int? Soluong { get; set; }
        public int? Namxuatban { get; set; }
        public string? Anhbia { get; set; }
        public int? Maloai { get; set; }
        public int? Manxb { get; set; }

        public virtual Theloai? MaloaiNavigation { get; set; }
        public virtual Nhaxuatban? ManxbNavigation { get; set; }
        public virtual ICollection<Chitietphieumuon> Chitietphieumuon { get; set; }
        public virtual ICollection<Phienbansach> Phienbansach { get; set; }
    }
}
