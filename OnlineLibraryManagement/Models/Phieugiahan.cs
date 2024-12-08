using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Phieugiahan
    {
        [Display(Name = "Mã phiếu GH")]
        public int Maphieu { get; set; }
        [Display(Name = "Ngày lập phiếu")]
        public DateTime? Ngaylapphieu { get; set; }
        [Display(Name = "Ngày phê duyệt")]
        public DateTime? Ngaypheduyet { get; set; }
        [Display(Name = "Hạn trả mới")]
        public DateTime? Hantramoi { get; set; }
        [Display(Name = "Lần gia hạn")]
        public int? Langiahan { get; set; }
        [Display(Name = "Ghi chú")]
        public string? Ghichu { get; set; }
        [Display(Name = "Lý do")]
        public string? Lydo { get; set; }
        [Display(Name = "Tình trạng")]
        public int? Matinhtrang { get; set; }
        [Display(Name = "Mã phiếu mượn")]
        public int? Maphieumuon { get; set; }
        [Display(Name = "Thủ thư duyệt")]
        public int? Matt { get; set; }

        public virtual Phieumuonsach? MaphieumuonNavigation { get; set; }
        public virtual Tinhtrangphieu? MatinhtrangNavigation { get; set; }
        public virtual Thuthu? MattNavigation { get; set; }
    }
}
