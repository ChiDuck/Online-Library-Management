using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Nhaxuatban
    {
        public Nhaxuatban()
        {
            Saches = new HashSet<Sach>();
        }

        public int Manxb { get; set; }
        public string? Tennxb { get; set; }
        public string? Email { get; set; }
        public string? Diachi { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
