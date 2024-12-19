using OnlineLibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryManagement.MyModels
{
    public class CTacgia2
    {
        public string? Tentacgia { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? Ngaysinh { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? Ngaymat { get; set; }
        public string? Quoctich { get; set; }
    }
}
