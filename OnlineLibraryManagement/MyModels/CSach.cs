using OnlineLibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.MyModels
{
    public class CSach
    {
        private QuanLyThuVienContext db = new QuanLyThuVienContext();

        [Display(Name = "Mã sách")]
        public int Masach { get; set; }
        [Display(Name = "Tên sách")]
        public string? Tensach { get; set; }
        [Display(Name = "Số lượng")]
        public int? Soluong { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string? Anhbia { get; set; }
        [Display(Name = "Loại sách")]
        public int? Maloai { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public int? Manxb { get; set; }
        public static CSach chuyenDoi(Sach s)
        {
            return new CSach
            {
                Masach = s.Masach,
                Tensach = s.Tensach,
                Soluong = s.Soluong,
                Anhbia = s.Anhbia,
                Maloai = s.Maloai,
                Manxb = s.Manxb,
            };
        }
        public static Sach chuyenDoi(CSach s)
        {
            return new Sach
            {
                Masach = s.Masach,
                Tensach = s.Tensach,
                Soluong = s.Soluong,
                Anhbia = s.Anhbia,
                Maloai = s.Maloai,
                Manxb = s.Manxb,
            };
        }
    }
}
