﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Phienbansach = new HashSet<Phienbansach>();
        }

        [Display(Name = "Mã tác giả")]
        public int Matacgia { get; set; }
        [Display(Name = "Tên tác giả")]
        public string? Tentacgia { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Quốc tịch")]
        public string? Quoctich { get; set; }

        public virtual ICollection<Phienbansach> Phienbansach { get; set; }
    }
}
