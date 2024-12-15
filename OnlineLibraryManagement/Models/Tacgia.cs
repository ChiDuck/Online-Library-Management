namespace OnlineLibraryManagement.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Phienbansach = new HashSet<Phienbansach>();
        }

        public int Matacgia { get; set; }
        public string? Tentacgia { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public DateTime? Ngaymat { get; set; }
        public string? Quoctich { get; set; }

        public virtual ICollection<Phienbansach> Phienbansach { get; set; }
    }
}
