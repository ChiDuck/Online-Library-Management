using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.Models
{
    public partial class Docgia
    {
        public Docgia()
        {
            Phieumuonsach = new HashSet<Phieumuonsach>();
        }

        [Display(Name = "Mã độc giả")]
        public int Madocgia { get; set; }
        [Display(Name = "Tên độc giả")]
        public string? Tendocgia { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Mã tài khoản")]
        public int? Matk { get; set; }

        public virtual Taikhoan? MatkNavigation { get; set; }
        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
    }
}
