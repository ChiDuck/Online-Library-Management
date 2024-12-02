using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Thuthu
    {
        public Thuthu()
        {
            Phieumuonsach = new HashSet<Phieumuonsach>();
        }

        public int Matt { get; set; }
        public string? Tentt { get; set; }
        public string? Sdt { get; set; }
        public int? Matk { get; set; }

        public virtual Taikhoan? MatkNavigation { get; set; }
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
    }
}
