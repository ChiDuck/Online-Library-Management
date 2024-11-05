using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Chitietphieumuons = new HashSet<Chitietphieumuon>();
            Phienbansaches = new HashSet<Phienbansach>();
        }

        public int Masach { get; set; }
        public string? Tensach { get; set; }
        public int? Soluong { get; set; }
        public string? Anhbia { get; set; }
        public int? Maloai { get; set; }
        public int? Manxb { get; set; }

        public virtual Theloai? MaloaiNavigation { get; set; }
        public virtual Nhaxuatban? ManxbNavigation { get; set; }
        public virtual ICollection<Chitietphieumuon> Chitietphieumuons { get; set; }
        public virtual ICollection<Phienbansach> Phienbansaches { get; set; }
    }
}
