using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace OnlineLibraryManagement.Models
{
    public partial class Taikhoan
    {
        public int Matk { get; set; }

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string? Tentk { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Mật khẩu phải từ 3 kí tự trở lên.")]
        public string? Matkhau { get; set; }

		[NotMapped]
		[Display(Name = "Nhập mật khẩu cũ")]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu cũ")]
		[DataType(DataType.Password)]
        public string? Matkhaucu { get; set; }

        [NotMapped]
        [Display(Name = "Nhập lại mật khẩu mới")]
		[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu mới")]
		[Compare("Matkhau", ErrorMessage = "Mật khẩu không khớp.")]
        [DataType(DataType.Password)]
        public string? Nhaplaimatkhau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email", AllowEmptyStrings = false)]
        [EmailAddress]
        public string? Email { get; set; }
        public bool? Loaitk { get; set; }

        public virtual Docgia? Docgia { get; set; }
        public virtual Thuthu? Thuthu { get; set; }
    }
}
