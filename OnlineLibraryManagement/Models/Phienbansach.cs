namespace OnlineLibraryManagement.Models
{
    public partial class Phienbansach
    {
        public int Masach { get; set; }
        public int Matacgia { get; set; }
        public string? Vaitro { get; set; }

        public virtual Sach MasachNavigation { get; set; } = null!;
        public virtual Tacgia MatacgiaNavigation { get; set; } = null!;
    }
}
