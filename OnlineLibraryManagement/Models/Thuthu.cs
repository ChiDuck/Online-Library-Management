using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Thuthu
    {
        public Thuthu()
        {
            Phieumuonsaches = new HashSet<Phieumuonsach>();
        }

        public int Matt { get; set; }
        public string? Tentt { get; set; }
        public int? Sdt { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Phieumuonsach> Phieumuonsaches { get; set; }
    }
}
