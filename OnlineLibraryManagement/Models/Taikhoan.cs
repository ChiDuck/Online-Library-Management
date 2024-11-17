using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Taikhoan
    {
        public int Matk { get; set; }
        public string? Tentk { get; set; }
        public string? Matkhau { get; set; }
        public bool? Loaitk { get; set; }

        public virtual Docgia? Docgia { get; set; }
        public virtual Thuthu? Thuthu { get; set; }
    }
}
