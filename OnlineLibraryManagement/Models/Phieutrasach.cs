using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Phieutrasach
    {
        [Display(Name ="Mã phiếu")]
        public int Maphieu { get; set; }
        [Display(Name ="Ngày lập phiếu")]
        public DateTime? Ngaylapphieu { get; set; }
        [Display(Name ="Số sách trả")]
        public int? Sosachtra { get; set; }
        [Display(Name ="Ghi chú")]
        public string? Ghichu { get; set; }
        [Display(Name ="Mã phiếu mượn")]
        public int? Maphieumuon { get; set; }
        [Display(Name ="Thủ thư duyệt")]
        public int? Matt { get; set; }

        public virtual Phieumuonsach? MaphieumuonNavigation { get; set; }
        public virtual Thuthu? MattNavigation { get; set; }
    }
}
