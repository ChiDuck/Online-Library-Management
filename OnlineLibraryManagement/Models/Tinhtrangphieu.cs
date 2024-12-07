namespace OnlineLibraryManagement.Models
{
    public partial class Tinhtrangphieu
    {
        public Tinhtrangphieu()
        {
            Phieumuonsach = new HashSet<Phieumuonsach>();
        }

        public int Matinhtrang { get; set; }
        public string? Tentinhtrang { get; set; }

        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
    }
}
