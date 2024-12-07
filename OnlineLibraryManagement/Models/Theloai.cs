namespace OnlineLibraryManagement.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Sach = new HashSet<Sach>();
        }

        public int Maloai { get; set; }
        public string? Tenloai { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
