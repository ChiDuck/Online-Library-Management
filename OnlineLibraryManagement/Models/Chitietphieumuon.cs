using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Chitietphieumuon
    {
        public int Maphieu { get; set; }
        public int Masach { get; set; }
        public DateTime? Ngaytra { get; set; }
        public int? Soluong { get; set; }

        public virtual Phieumuonsach MaphieuNavigation { get; set; } = null!;
        public virtual Sach MasachNavigation { get; set; } = null!;
    }
}
