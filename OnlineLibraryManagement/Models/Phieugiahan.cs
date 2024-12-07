﻿using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Phieugiahan
    {
        public int Maphieu { get; set; }
        public DateTime? Ngaylapphieu { get; set; }
        public DateTime? Ngaypheduyet { get; set; }
        public DateTime? Hantramoi { get; set; }
        public int? Langiahan { get; set; }
        public string? Ghichu { get; set; }
        public string? Lydo { get; set; }
        public int? Matinhtrang { get; set; }
        public int? Maphieumuon { get; set; }
        public int? Matt { get; set; }

        public virtual Phieumuonsach? MaphieumuonNavigation { get; set; }
        public virtual Tinhtrangphieu? MatinhtrangNavigation { get; set; }
        public virtual Thuthu? MattNavigation { get; set; }
    }
}
