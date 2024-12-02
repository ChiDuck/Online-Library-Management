using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Chitietphieumuon
    {
        [Display(Name = "Mã phiếu")]
        public int Maphieu { get; set; }
        [Display(Name = "Mã sách")]
        public int Masach { get; set; }
        [Display(Name = "Mã tình trạng")]
        public int? Matinhtrang { get; set; }

        public virtual Phieumuonsach MaphieuNavigation { get; set; } = null!;
        public virtual Sach MasachNavigation { get; set; } = null!;
        public virtual Tinhtrangmuon? MatinhtrangNavigation { get; set; }
    }
}
