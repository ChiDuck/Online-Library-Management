using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Docgia
    {
        public Docgia()
        {
            Phieumuonsach = new HashSet<Phieumuonsach>();
        }

        public int Madocgia { get; set; }
        public string? Tendocgia { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public int? Matk { get; set; }

        public virtual Taikhoan? MatkNavigation { get; set; }
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
    }
}
