using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Chitietphieumuon = new HashSet<Chitietphieumuon>();
            Phienbansach = new HashSet<Phienbansach>();
        }
        [Display(Name = "Mã sách")]
        public int Masach { get; set; }
        [Display(Name = "Tên sách sách")]
        [Required(ErrorMessage ="Bạn chưa nhập tên sách")]
        public string? Tensach { get; set; }


        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public int? Soluong { get; set; }

        [Display(Name = "Năm xuất bản")]
        [Required(ErrorMessage = "Bạn chưa năm xuất bản")]
        public int? Namxuatban { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string? Anhbia { get; set; }
        [Display(Name = "Thể loại")]
        public int? Maloai { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public int? Manxb { get; set; }

        public virtual Theloai? MaloaiNavigation { get; set; }
        public virtual Nhaxuatban? ManxbNavigation { get; set; }
        public virtual ICollection<Chitietphieumuon> Chitietphieumuon { get; set; }
        public virtual ICollection<Phienbansach> Phienbansach { get; set; }
    }
}
