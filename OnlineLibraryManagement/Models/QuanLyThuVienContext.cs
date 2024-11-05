using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineLibraryManagement.Models
{
    public partial class QuanLyThuVienContext : DbContext
    {
        public QuanLyThuVienContext()
        {
        }

        public QuanLyThuVienContext(DbContextOptions<QuanLyThuVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietphieumuon> Chitietphieumuons { get; set; } = null!;
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; } = null!;
        public virtual DbSet<Phienbansach> Phienbansaches { get; set; } = null!;
        public virtual DbSet<Phieumuonsach> Phieumuonsaches { get; set; } = null!;
        public virtual DbSet<Sach> Saches { get; set; } = null!;
        public virtual DbSet<Tacgia> Tacgia { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoans { get; set; } = null!;
        public virtual DbSet<Theloai> Theloais { get; set; } = null!;
        public virtual DbSet<Thuthu> Thuthus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MinhNghia;Initial Catalog=QuanLyThuVien;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietphieumuon>(entity =>
            {
                entity.HasKey(e => new { e.Maphieu, e.Masach })
                    .HasName("PK__CHITIETP__23FDF1A5A7A41DEA");

                entity.ToTable("CHITIETPHIEUMUON");

                entity.Property(e => e.Maphieu).HasColumnName("MAPHIEU");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Ngaytra)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYTRA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MaphieuNavigation)
                    .WithMany(p => p.Chitietphieumuons)
                    .HasForeignKey(d => d.Maphieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPH__MAPHI__4BAC3F29");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany(p => p.Chitietphieumuons)
                    .HasForeignKey(d => d.Masach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPH__MASAC__4CA06362");
            });

            modelBuilder.Entity<Nhaxuatban>(entity =>
            {
                entity.HasKey(e => e.Manxb)
                    .HasName("PK__NHAXUATB__7ABD9EF2F88B81B8");

                entity.ToTable("NHAXUATBAN");

                entity.Property(e => e.Manxb).HasColumnName("MANXB");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Tennxb)
                    .HasMaxLength(100)
                    .HasColumnName("TENNXB");
            });

            modelBuilder.Entity<Phienbansach>(entity =>
            {
                entity.HasKey(e => new { e.Masach, e.Matacgia })
                    .HasName("PK__PHIENBAN__F3934F2A27E47230");

                entity.ToTable("PHIENBANSACH");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Matacgia).HasColumnName("MATACGIA");

                entity.Property(e => e.Namxuatban).HasColumnName("NAMXUATBAN");

                entity.Property(e => e.Taiban).HasColumnName("TAIBAN");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany(p => p.Phienbansaches)
                    .HasForeignKey(d => d.Masach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIENBANS__MASAC__4316F928");

                entity.HasOne(d => d.MatacgiaNavigation)
                    .WithMany(p => p.Phienbansaches)
                    .HasForeignKey(d => d.Matacgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIENBANS__MATAC__440B1D61");
            });

            modelBuilder.Entity<Phieumuonsach>(entity =>
            {
                entity.HasKey(e => e.Maphieu)
                    .HasName("PK__PHIEUMUO__F001B9411750CE35");

                entity.ToTable("PHIEUMUONSACH");

                entity.Property(e => e.Maphieu).HasColumnName("MAPHIEU");

                entity.Property(e => e.Matt).HasColumnName("MATT");

                entity.Property(e => e.Ngaylapphieu)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYLAPPHIEU");

                entity.Property(e => e.Ngaymuon)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYMUON");

                entity.HasOne(d => d.MattNavigation)
                    .WithMany(p => p.Phieumuonsaches)
                    .HasForeignKey(d => d.Matt)
                    .HasConstraintName("FK__PHIEUMUONS__MATT__48CFD27E");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__SACH__3FC48E4C6380B0AD");

                entity.ToTable("SACH");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Anhbia)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ANHBIA");

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Manxb).HasColumnName("MANXB");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tensach)
                    .HasMaxLength(100)
                    .HasColumnName("TENSACH");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK__SACH__MALOAI__3F466844");

                entity.HasOne(d => d.ManxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Manxb)
                    .HasConstraintName("FK__SACH__MANXB__403A8C7D");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.Matacgia)
                    .HasName("PK__TACGIA__C57C166DA06440F0");

                entity.ToTable("TACGIA");

                entity.Property(e => e.Matacgia).HasColumnName("MATACGIA");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Quoctich)
                    .HasMaxLength(30)
                    .HasColumnName("QUOCTICH");

                entity.Property(e => e.Tentacgia)
                    .HasMaxLength(100)
                    .HasColumnName("TENTACGIA");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Matk)
                    .HasName("PK__TAIKHOAN__60237216EB66E444");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Matk).HasColumnName("MATK");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MATKHAU");

                entity.Property(e => e.Tentk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TENTK");
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__THELOAI__2F633F2367970FAD");

                entity.ToTable("THELOAI");

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Thuthu>(entity =>
            {
                entity.HasKey(e => e.Matt)
                    .HasName("PK__THUTHU__6023720FE2610B01");

                entity.ToTable("THUTHU");

                entity.Property(e => e.Matt).HasColumnName("MATT");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.Tentt)
                    .HasMaxLength(50)
                    .HasColumnName("TENTT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
