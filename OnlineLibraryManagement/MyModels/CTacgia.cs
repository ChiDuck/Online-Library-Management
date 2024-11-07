using OnlineLibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.MyModels
{
    public class CTacgia
    {
        [Display(Name = "Mã tác giả")]
        public int Matacgia { get; set; }
        [Display(Name = "Tên tác giả")]
        public string? Tentacgia { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Quốc tịch")]
        public string? Quoctich { get; set; }

        public static CTacgia chuyenDoi(Tacgia tg)
        {
            return new CTacgia
            {
                Matacgia = tg.Matacgia,
                Tentacgia = tg.Tentacgia,
                Ngaysinh = tg.Ngaysinh,
                Quoctich = tg.Quoctich
            };
        }

        public static Tacgia chuyenDoi(CTacgia ctg)
        {
            return new Tacgia
            {
                Matacgia = ctg.Matacgia,
                Tentacgia = ctg.Tentacgia,
                Ngaysinh = ctg.Ngaysinh,
                Quoctich = ctg.Quoctich
            };
        }
    }
}
