USE master 
GO
ALTER DATABASE QuanLyThuVien set single_user with rollback immediate -- DISCONNECT FROM ALL SOURCE
DROP DATABASE IF exists QuanLyThuVien
GO 
CREATE DATABASE QuanLyThuVien
GO
USE QuanLyThuVien
GO

/*==============================================================*/
/* Table: TAIKHOAN                                              */
/*==============================================================*/
CREATE TABLE TAIKHOAN 
(
	MATK		INT				IDENTITY(1,1) NOT NULL,
	TENTK		VARCHAR(20)		NULL,
	MATKHAU		VARCHAR(20)		NULL,
	EMAIL		VARCHAR(35)		NULL,
	LOAITK		BIT				NULL,
	PRIMARY KEY(MATK)
);

/*==============================================================*/
/* Table: DOCGIA                                                */
/*==============================================================*/
CREATE TABLE DOCGIA 
(
	MADOCGIA	INT				IDENTITY(1,1) NOT NULL,
	TENDOCGIA	NVARCHAR(35)	NULL,
	NGAYSINH	DATE			NULL,
	MATK		INT				UNIQUE REFERENCES TAIKHOAN(MATK),
	PRIMARY KEY(MADOCGIA)
);

/*==============================================================*/
/* Table: THELOAI                                               */
/*==============================================================*/
CREATE TABLE THELOAI 
(
	MALOAI		INT				IDENTITY(1,1) NOT NULL,
	TENLOAI		NVARCHAR(50)	NULL,
	PRIMARY KEY(MALOAI)
);

/*==============================================================*/
/* Table: NHAXUATBAN                                            */
/*==============================================================*/
CREATE TABLE NHAXUATBAN 
(
	MANXB		INT				IDENTITY(1,1) NOT NULL,
	TENNXB		NVARCHAR(50)	NULL,
	EMAIL		VARCHAR(35)		NULL,
	DIACHI		NVARCHAR(100)	NULL,
	PRIMARY KEY(MANXB)
);

/*==============================================================*/
/* Table: TACGIA                                                */
/*==============================================================*/
CREATE TABLE TACGIA 
(
	MATACGIA	INT				IDENTITY(1,1) NOT NULL,
	TENTACGIA	NVARCHAR(50)	NULL,
	NGAYSINH	DATE			NULL,
	NGAYMAT		DATE			NULL,
	QUOCTICH	NVARCHAR(30)	NULL,
	PRIMARY KEY(MATACGIA)
);

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
CREATE TABLE SACH 
(
	MASACH		INT				IDENTITY(1,1) NOT NULL,
	TENSACH		NVARCHAR(100)	NULL,
	SOLUONG		INT				NULL,
	NAMXUATBAN	INT				NULL,
	ANHBIA		VARCHAR(100)	NULL,
	MALOAI		INT				FOREIGN KEY(MALOAI) REFERENCES THELOAI(MALOAI),
	MANXB		INT				FOREIGN KEY(MANXB) REFERENCES NHAXUATBAN(MANXB),
	PRIMARY KEY(MASACH)
);

/*==============================================================*/
/* Table: PHIENBANSACH											*/
/*==============================================================*/
CREATE TABLE PHIENBANSACH 
(
	MASACH		INT				NOT NULL FOREIGN KEY(MASACH) REFERENCES SACH(MASACH),
	MATACGIA	INT				NOT NULL FOREIGN KEY(MATACGIA) REFERENCES TACGIA(MATACGIA),
	VAITRO		NCHAR(20)		NULL,		
	PRIMARY KEY(MASACH, MATACGIA)
);

/*==============================================================*/
/* Table: THUTHU												*/
/*==============================================================*/
CREATE TABLE THUTHU 
(
	MATT		INT				IDENTITY(1,1) NOT NULL,
	TENTT		NVARCHAR(35)	NULL,
	SDT			CHAR(10)		NULL,	
	MATK		INT				UNIQUE REFERENCES TAIKHOAN(MATK),
	PRIMARY KEY(MATT)
);

/*==============================================================*/
/* Table: TINHTRANGMUON											*/
/*==============================================================*/
CREATE TABLE TINHTRANGMUON 
(
	MATINHTRANG		INT			IDENTITY(1,1) NOT NULL,
	TENTINHTRANG	NCHAR(15)	NULL,
	PRIMARY KEY(MATINHTRANG)
);

/*==============================================================*/
/* Table: TINHTRANGPHIEU										*/
/*==============================================================*/
CREATE TABLE TINHTRANGPHIEU 
(
	MATINHTRANG		INT				IDENTITY(1,1) NOT NULL,
	TENTINHTRANG	NCHAR(15)		NULL,
	PRIMARY KEY(MATINHTRANG)
);

/*==============================================================*/
/* Table: PHIEUMUONSACH											*/
/*==============================================================*/
CREATE TABLE PHIEUMUONSACH 
(
	MAPHIEU			INT				IDENTITY(1,1) NOT NULL,
	NGAYLAPPHIEU	DATE			NULL,
	NGAYPHEDUYET	DATE			NULL,
	HANTRA			DATE			NULL,	
	SOLUONGSACH		INT				NULL,
	GHICHU			NVARCHAR(70)	NULL,
	MATINHTRANG		INT				FOREIGN KEY(MATINHTRANG) REFERENCES TINHTRANGPHIEU(MATINHTRANG),
	MATT			INT				FOREIGN KEY(MATT) REFERENCES THUTHU(MATT),
	MADOCGIA		INT				FOREIGN KEY(MADOCGIA) REFERENCES DOCGIA(MADOCGIA),
	PRIMARY KEY(MAPHIEU)
);

/*==============================================================*/
/* Table: CHITIETPHIEUMUON										*/
/*==============================================================*/
CREATE TABLE CHITIETPHIEUMUON 
(
	MAPHIEU			INT			NOT NULL FOREIGN KEY(MAPHIEU) REFERENCES PHIEUMUONSACH(MAPHIEU),
	MASACH			INT			NOT NULL FOREIGN KEY(MASACH) REFERENCES SACH(MASACH),
	MATINHTRANG		INT			FOREIGN KEY(MATINHTRANG) REFERENCES TINHTRANGMUON(MATINHTRANG),
	PRIMARY KEY(MAPHIEU, MASACH)
);

/*==============================================================*/
/* Table: PHIEUTRASACH											*/
/*==============================================================*/
CREATE TABLE PHIEUTRASACH 
(
	MAPHIEU			INT				IDENTITY(1,1) NOT NULL,
	NGAYLAPPHIEU	DATE			NULL,
	SOSACHTRA		INT				NULL,
	GHICHU			NVARCHAR(70)	NULL,
	MAPHIEUMUON		INT				UNIQUE REFERENCES PHIEUMUONSACH(MAPHIEU),
	MATT			INT				FOREIGN KEY(MATT) REFERENCES THUTHU(MATT),
	PRIMARY KEY(MAPHIEU)
);

/*==============================================================*/
/* Table: PHIEUGIAHAN											*/
/*==============================================================*/
CREATE TABLE PHIEUGIAHAN 
(
	MAPHIEU			INT				IDENTITY(1,1) NOT NULL,
	NGAYLAPPHIEU	DATE			NULL,
	NGAYPHEDUYET	DATE			NULL,
	HANTRAMOI		DATE			NULL,	
	LANGIAHAN		INT				NULL,
	GHICHU			NVARCHAR(70)	NULL,
	LYDO			NVARCHAR(70)	NULL,
	MATINHTRANG		INT				FOREIGN KEY(MATINHTRANG) REFERENCES TINHTRANGPHIEU(MATINHTRANG),
	MAPHIEUMUON		INT				FOREIGN KEY(MAPHIEUMUON) REFERENCES PHIEUMUONSACH(MAPHIEU),
	MATT			INT				FOREIGN KEY(MATT) REFERENCES THUTHU(MATT),
	PRIMARY KEY(MAPHIEU)
);

/*==============================================================*/
/* Table: CHITIETPHIEUTRA										*/
/*==============================================================*/
--CREATE TABLE CHITIETPHIEUTRA 
--(
--	MAPHIEU			INT			NOT NULL FOREIGN KEY(MAPHIEU) REFERENCES PHIEUTRASACH(MAPHIEU),
--	MASACH			INT			NOT NULL FOREIGN KEY(MASACH) REFERENCES SACH(MASACH),
--	PRIMARY KEY(MAPHIEU, MASACH)
--);





