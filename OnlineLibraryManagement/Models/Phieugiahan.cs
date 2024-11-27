using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Phieugiahan
    {
        public int Maphieu { get; set; }
        public DateTime? Ngaylapphieu { get; set; }
        public int? Langiahan { get; set; }
        public int? Maphieumuon { get; set; }
        public int? Madocgia { get; set; }

        public virtual Docgia? MadocgiaNavigation { get; set; }
        public virtual Phieumuonsach? MaphieumuonNavigation { get; set; }
    }
}
