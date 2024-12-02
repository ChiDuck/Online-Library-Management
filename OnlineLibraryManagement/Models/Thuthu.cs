using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Thuthu
    {
        public Thuthu()
        {
            Phieumuonsach = new HashSet<Phieumuonsach>();
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
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
    }
}
