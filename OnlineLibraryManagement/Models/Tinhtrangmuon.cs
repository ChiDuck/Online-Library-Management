using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Tinhtrangmuon
    {
        public Tinhtrangmuon()
        {
            Chitietphieumuon = new HashSet<Chitietphieumuon>();
        }

        public int Matinhtrang { get; set; }
        public string? Tentinhtrang { get; set; }

        public virtual ICollection<Chitietphieumuon> Chitietphieumuon { get; set; }
    }
}
