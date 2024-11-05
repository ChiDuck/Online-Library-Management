using System;
using System.Collections.Generic;

namespace OnlineLibraryManagement.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Phienbansaches = new HashSet<Phienbansach>();
        }

        public int Matacgia { get; set; }
        public string? Tentacgia { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Quoctich { get; set; }

        public virtual ICollection<Phienbansach> Phienbansaches { get; set; }
    }
}
