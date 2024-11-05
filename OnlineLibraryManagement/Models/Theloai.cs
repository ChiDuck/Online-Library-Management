using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Saches = new HashSet<Sach>();
        }

        public int Maloai { get; set; }
        public string? Tenloai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
