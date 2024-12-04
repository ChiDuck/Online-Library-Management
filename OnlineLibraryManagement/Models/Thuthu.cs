using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Thuthu
    {
        public Thuthu()
        {
            Phieugiahan = new HashSet<Phieugiahan>();
            Phieumuonsach = new HashSet<Phieumuonsach>();
            Phieutrasach = new HashSet<Phieutrasach>();
        }

        [Display(Name = "Mã thủ thư ")]
        public int Matt { get; set; }
        [Display(Name = "Tên thủ thư")]
        public string? Tentt { get; set; }
        [Display(Name = "Số điện thoại")]
        public string? Sdt { get; set; }
        [Display(Name = "Mã tài khoản")]
        public int? Matk { get; set; }

        public virtual Taikhoan? MatkNavigation { get; set; }
        public virtual ICollection<Phieugiahan> Phieugiahan { get; set; }
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
        public virtual ICollection<Phieutrasach> Phieutrasach { get; set; }
    }
}
