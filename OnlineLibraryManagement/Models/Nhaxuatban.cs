using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Nhaxuatban
    {
        public Nhaxuatban()
        {
            Sach = new HashSet<Sach>();
        }

        public int Manxb { get; set; }
        public string? Tennxb { get; set; }
        public string? Email { get; set; }
        public string? Diachi { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
