using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineLibraryManagement.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.MyModels
{
    public class CSach
    {

        [Display(Name = "Mã sách")]
        public int Masach { get; set; }
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sách!")]
        public string? Tensach { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng!")]
        public int? Soluong { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string? Anhbia { get; set; }
        [Display(Name = "Loại sách")]
        public int? Maloai { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public int? Manxb { get; set; }
        [Display(Name = "Tác giả")]
        public List<int>? Matacgias { get; set; }
        [Display(Name = "Năm xuất  bản")]
        public int? Namxuatban { get; set; }
        [Display(Name = "Tái bản")]
        public int? Taiban { get; set; }

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
        public static List<Phienbansach> chuyenDoiPhienBanSach(CSach s)
        {
            List<Phienbansach> ds = new List<Phienbansach>();
            for (int i = 0;i< s.Matacgias.Count;i++)
            {
                int matg = s.Matacgias[i];
                Phienbansach p = new Phienbansach();
                p.Masach = s.Masach;
                p.Matacgia = matg;
                p.Namxuatban = s.Namxuatban;
                p.Taiban = s.Taiban;
                ds.Add(p);
            }    
            return ds;
        }
        public static CSach chuyenDoiPhienBanSach(List<Phienbansach> ds)
        {
            CSach s = null;
            if (ds.Count > 0)
            {
                s = new CSach();
                List<int> matg = new List<int>();
                foreach (Phienbansach item in ds)
                {
                    matg.Add(item.Matacgia);
                }
                s.Matacgias = matg;
                s.Taiban = ds[0].Taiban;
                s.Namxuatban = ds[0].Namxuatban;
            }    
            return s;
        }
    }
}
