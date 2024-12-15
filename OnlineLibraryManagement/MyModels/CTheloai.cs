using OnlineLibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.MyModels
{
    public class CTheloai
    {
        private QuanLyThuVienContext db = new QuanLyThuVienContext();

        [Display(Name = "Mã thể loại")]
        public int Maloai { get; set; }

        [Display(Name = "Tên thể loại")]
        [Required(ErrorMessage = "Vui lòng nhập tên cho thể loại")]
        public string? Tenloai { get; set; }

        public static CTheloai chuyenDoi(Theloai tl)
        {
            return new CTheloai
            {
                Maloai = tl.Maloai,
                Tenloai = tl.Tenloai
            };
        }
        public static Theloai chuyenDoi(CTheloai ctl)
        {
            return new Theloai
            {
                Maloai = ctl.Maloai,
                Tenloai = ctl.Tenloai
            };
        }
    }
}
