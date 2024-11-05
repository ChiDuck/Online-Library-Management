using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Phieumuonsach
    {
        public Phieumuonsach()
        {
            Chitietphieumuons = new HashSet<Chitietphieumuon>();
        }

        public int Maphieu { get; set; }
        public DateTime? Ngaylapphieu { get; set; }
        public DateTime? Ngaymuon { get; set; }
        public int? Matt { get; set; }

        public virtual Thuthu? MattNavigation { get; set; }
        public virtual ICollection<Chitietphieumuon> Chitietphieumuons { get; set; }
    }
}
