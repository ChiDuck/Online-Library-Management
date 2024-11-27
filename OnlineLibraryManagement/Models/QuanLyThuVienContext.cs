﻿using System;
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

        public virtual DbSet<Chitietphieumuon> Chitietphieumuon { get; set; } = null!;
        public virtual DbSet<Docgia> Docgia { get; set; } = null!;
        public virtual DbSet<Nhaxuatban> Nhaxuatban { get; set; } = null!;
        public virtual DbSet<Phienbansach> Phienbansach { get; set; } = null!;
        public virtual DbSet<Phieugiahan> Phieugiahan { get; set; } = null!;
        public virtual DbSet<Phieumuonsach> Phieumuonsach { get; set; } = null!;
        public virtual DbSet<Phieutrasach> Phieutrasach { get; set; } = null!;
        public virtual DbSet<Sach> Sach { get; set; } = null!;
        public virtual DbSet<Tacgia> Tacgia { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoan { get; set; } = null!;
        public virtual DbSet<Theloai> Theloai { get; set; } = null!;
        public virtual DbSet<Thuthu> Thuthu { get; set; } = null!;
        public virtual DbSet<Tinhtrangmuon> Tinhtrangmuon { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=chiduck;Initial Catalog=QuanLyThuVien;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietphieumuon>(entity =>
            {
                entity.HasKey(e => new { e.Maphieu, e.Masach })
                    .HasName("PK__CHITIETP__23FDF1A559FDA7B6");

                entity.ToTable("CHITIETPHIEUMUON");

                entity.Property(e => e.Maphieu).HasColumnName("MAPHIEU");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Matinhtrang).HasColumnName("MATINHTRANG");

                entity.HasOne(d => d.MaphieuNavigation)
                    .WithMany(p => p.Chitietphieumuon)
                    .HasForeignKey(d => d.Maphieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPH__MAPHI__5441852A");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany(p => p.Chitietphieumuon)
                    .HasForeignKey(d => d.Masach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPH__MASAC__5535A963");

                entity.HasOne(d => d.MatinhtrangNavigation)
                    .WithMany(p => p.Chitietphieumuon)
                    .HasForeignKey(d => d.Matinhtrang)
                    .HasConstraintName("FK__CHITIETPH__MATIN__5629CD9C");
            });

            modelBuilder.Entity<Docgia>(entity =>
            {
                entity.HasKey(e => e.Madocgia)
                    .HasName("PK__DOCGIA__8CA726FC961AF17B");

                entity.ToTable("DOCGIA");

                entity.HasIndex(e => e.Matk, "UQ__DOCGIA__60237217433E2870")
                    .IsUnique();

                entity.Property(e => e.Madocgia).HasColumnName("MADOCGIA");

                entity.Property(e => e.Matk).HasColumnName("MATK");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Tendocgia)
                    .HasMaxLength(50)
                    .HasColumnName("TENDOCGIA");

                entity.HasOne(d => d.MatkNavigation)
                    .WithOne(p => p.Docgia)
                    .HasForeignKey<Docgia>(d => d.Matk)
                    .HasConstraintName("FK__DOCGIA__MATK__3A81B327");
            });

            modelBuilder.Entity<Nhaxuatban>(entity =>
            {
                entity.HasKey(e => e.Manxb)
                    .HasName("PK__NHAXUATB__7ABD9EF2C2E85BD2");

                entity.ToTable("NHAXUATBAN");

                entity.Property(e => e.Manxb).HasColumnName("MANXB");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Tennxb)
                    .HasMaxLength(50)
                    .HasColumnName("TENNXB");
            });

            modelBuilder.Entity<Phienbansach>(entity =>
            {
                entity.HasKey(e => new { e.Masach, e.Matacgia })
                    .HasName("PK__PHIENBAN__F3934F2A3D5F4021");

                entity.ToTable("PHIENBANSACH");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Matacgia).HasColumnName("MATACGIA");

                entity.Property(e => e.Vaitro)
                    .HasMaxLength(30)
                    .HasColumnName("VAITRO");

                entity.HasOne(d => d.MasachNavigation)
                    .WithMany(p => p.Phienbansach)
                    .HasForeignKey(d => d.Masach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIENBANS__MASAC__46E78A0C");

                entity.HasOne(d => d.MatacgiaNavigation)
                    .WithMany(p => p.Phienbansach)
                    .HasForeignKey(d => d.Matacgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIENBANS__MATAC__47DBAE45");
            });

            modelBuilder.Entity<Phieugiahan>(entity =>
            {
                entity.HasKey(e => e.Maphieu)
                    .HasName("PK__PHIEUGIA__F001B94176C48BDD");

                entity.ToTable("PHIEUGIAHAN");

                entity.Property(e => e.Maphieu).HasColumnName("MAPHIEU");

                entity.Property(e => e.Langiahan).HasColumnName("LANGIAHAN");

                entity.Property(e => e.Madocgia).HasColumnName("MADOCGIA");

                entity.Property(e => e.Maphieumuon).HasColumnName("MAPHIEUMUON");

                entity.Property(e => e.Ngaylapphieu)
                    .HasColumnType("date")
                    .HasColumnName("NGAYLAPPHIEU");

                entity.HasOne(d => d.MadocgiaNavigation)
                    .WithMany(p => p.Phieugiahan)
                    .HasForeignKey(d => d.Madocgia)
                    .HasConstraintName("FK__PHIEUGIAH__MADOC__5EBF139D");

                entity.HasOne(d => d.MaphieumuonNavigation)
                    .WithMany(p => p.Phieugiahan)
                    .HasForeignKey(d => d.Maphieumuon)
                    .HasConstraintName("FK__PHIEUGIAH__MAPHI__5DCAEF64");
            });

            modelBuilder.Entity<Phieumuonsach>(entity =>
            {
                entity.HasKey(e => e.Maphieu)
                    .HasName("PK__PHIEUMUO__F001B941E595A65C");

                entity.ToTable("PHIEUMUONSACH");

                entity.Property(e => e.Maphieu).HasColumnName("MAPHIEU");

                entity.Property(e => e.Hantra)
                    .HasColumnType("date")
                    .HasColumnName("HANTRA");

                entity.Property(e => e.Madocgia).HasColumnName("MADOCGIA");

                entity.Property(e => e.Matt).HasColumnName("MATT");

                entity.Property(e => e.Ngaylapphieu)
                    .HasColumnType("date")
                    .HasColumnName("NGAYLAPPHIEU");

                entity.Property(e => e.Ngaymuon)
                    .HasColumnType("date")
                    .HasColumnName("NGAYMUON");

                entity.Property(e => e.Soluongsach).HasColumnName("SOLUONGSACH");

                entity.HasOne(d => d.MadocgiaNavigation)
                    .WithMany(p => p.Phieumuonsach)
                    .HasForeignKey(d => d.Madocgia)
                    .HasConstraintName("FK__PHIEUMUON__MADOC__5165187F");

                entity.HasOne(d => d.MattNavigation)
                    .WithMany(p => p.Phieumuonsach)
                    .HasForeignKey(d => d.Matt)
                    .HasConstraintName("FK__PHIEUMUONS__MATT__5070F446");
            });

            modelBuilder.Entity<Phieutrasach>(entity =>
            {
                entity.HasKey(e => e.Maphieu)
                    .HasName("PK__PHIEUTRA__F001B9412883BDB5");

                entity.ToTable("PHIEUTRASACH");

                entity.HasIndex(e => e.Maphieumuon, "UQ__PHIEUTRA__3F97C76A84E49FC4")
                    .IsUnique();

                entity.Property(e => e.Maphieu).HasColumnName("MAPHIEU");

                entity.Property(e => e.Madocgia).HasColumnName("MADOCGIA");

                entity.Property(e => e.Maphieumuon).HasColumnName("MAPHIEUMUON");

                entity.Property(e => e.Ngaylapphieu)
                    .HasColumnType("date")
                    .HasColumnName("NGAYLAPPHIEU");

                entity.Property(e => e.Sosachtra).HasColumnName("SOSACHTRA");

                entity.HasOne(d => d.MadocgiaNavigation)
                    .WithMany(p => p.Phieutrasach)
                    .HasForeignKey(d => d.Madocgia)
                    .HasConstraintName("FK__PHIEUTRAS__MADOC__5AEE82B9");

                entity.HasOne(d => d.MaphieumuonNavigation)
                    .WithOne(p => p.Phieutrasach)
                    .HasForeignKey<Phieutrasach>(d => d.Maphieumuon)
                    .HasConstraintName("FK__PHIEUTRAS__MAPHI__59FA5E80");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__SACH__3FC48E4C805C13EB");

                entity.ToTable("SACH");

                entity.Property(e => e.Masach).HasColumnName("MASACH");

                entity.Property(e => e.Anhbia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ANHBIA");

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Manxb).HasColumnName("MANXB");

                entity.Property(e => e.Namxuatban).HasColumnName("NAMXUATBAN");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tensach)
                    .HasMaxLength(100)
                    .HasColumnName("TENSACH");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK__SACH__MALOAI__4316F928");

                entity.HasOne(d => d.ManxbNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.Manxb)
                    .HasConstraintName("FK__SACH__MANXB__440B1D61");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.Matacgia)
                    .HasName("PK__TACGIA__C57C166DDFA6A9C0");

                entity.ToTable("TACGIA");

                entity.Property(e => e.Matacgia).HasColumnName("MATACGIA");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Quoctich)
                    .HasMaxLength(30)
                    .HasColumnName("QUOCTICH");

                entity.Property(e => e.Tentacgia)
                    .HasMaxLength(50)
                    .HasColumnName("TENTACGIA");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Matk)
                    .HasName("PK__TAIKHOAN__60237216F1670B05");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Matk).HasColumnName("MATK");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Loaitk).HasColumnName("LOAITK");

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
                    .HasName("PK__THELOAI__2F633F23280A48CC");

                entity.ToTable("THELOAI");

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Thuthu>(entity =>
            {
                entity.HasKey(e => e.Matt)
                    .HasName("PK__THUTHU__6023720FE8BFDEF5");

                entity.ToTable("THUTHU");

                entity.HasIndex(e => e.Matk, "UQ__THUTHU__60237217B6967E2A")
                    .IsUnique();

                entity.Property(e => e.Matt).HasColumnName("MATT");

                entity.Property(e => e.Matk).HasColumnName("MATK");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.Tentt)
                    .HasMaxLength(50)
                    .HasColumnName("TENTT");

                entity.HasOne(d => d.MatkNavigation)
                    .WithOne(p => p.Thuthu)
                    .HasForeignKey<Thuthu>(d => d.Matk)
                    .HasConstraintName("FK__THUTHU__MATK__4BAC3F29");
            });

            modelBuilder.Entity<Tinhtrangmuon>(entity =>
            {
                entity.HasKey(e => e.Matinhtrang)
                    .HasName("PK__TINHTRAN__C118F2D5F1BD53AA");

                entity.ToTable("TINHTRANGMUON");

                entity.Property(e => e.Matinhtrang).HasColumnName("MATINHTRANG");

                entity.Property(e => e.Tentinhtrang)
                    .HasMaxLength(20)
                    .HasColumnName("TENTINHTRANG")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
