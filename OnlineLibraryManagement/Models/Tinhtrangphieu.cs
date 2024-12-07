using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Tinhtrangphieu
    {
        public Tinhtrangphieu()
        {
            Phieugiahan = new HashSet<Phieugiahan>();
            Phieumuonsach = new HashSet<Phieumuonsach>();
        }

        public int Matinhtrang { get; set; }
        public string? Tentinhtrang { get; set; }

        public virtual ICollection<Phieugiahan> Phieugiahan { get; set; }
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
    }
}
