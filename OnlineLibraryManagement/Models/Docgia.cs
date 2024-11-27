using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Docgia
    {
        public Docgia()
        {
            Phieugiahan = new HashSet<Phieugiahan>();
            Phieumuonsach = new HashSet<Phieumuonsach>();
            Phieutrasach = new HashSet<Phieutrasach>();
        }
        [Display(Name = "Mã độc giả")]
        public int Madocgia { get; set; }
        [Display(Name = "Tên độc giả")]
        public string? Tendocgia { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Mã tài khoản")]
        public int? Matk { get; set; }

        public virtual Taikhoan? MatkNavigation { get; set; }
        public virtual ICollection<Phieugiahan> Phieugiahan { get; set; }
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
        public virtual ICollection<Phieutrasach> Phieutrasach { get; set; }
    }
}
