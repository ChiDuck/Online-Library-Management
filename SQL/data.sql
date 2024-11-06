USE QuanLyThuVien
GO

-- DELETE DATA FROM TABLES
DELETE FROM PHIENBANSACH
DELETE FROM CHITIETPHIEUMUON
DELETE FROM PHIEUMUONSACH
DELETE FROM SACH
DELETE FROM THELOAI
DELETE FROM TACGIA
DELETE FROM THUTHU
DELETE FROM NHAXUATBAN

-- RESET AUTO_INCREAMENT
DBCC CHECKIDENT (PHIEUMUONSACH, RESEED, 0)
DBCC CHECKIDENT (SACH, RESEED, 0)
DBCC CHECKIDENT (THELOAI, RESEED, 0)
DBCC CHECKIDENT (TACGIA, RESEED, 0)
DBCC CHECKIDENT (THUTHU, RESEED, 0)
DBCC CHECKIDENT (NHAXUATBAN, RESEED, 0)

INSERT INTO THELOAI VALUES
(N'Sách giáo khoa'),    --1
(N'Sách tham khảo'),    --2
(N'Sách giáo viên'),    --3
(N'Sách bài tập'), 	   --4
(N'Kỹ năng'), 		   --5
(N'Tiểu thuyết'), 	   --6
(N'Truyện tranh'), 	   --7
(N'Truyện ngắn'), 	   --8
(N'Kinh dị'), 		   --9
(N'Ngôn tình'), 		   --10
(N'Văn học'), 		   --11
(N'Khoa học'), 		   --12
(N'Tập thơ')		   --13

INSERT INTO NHAXUATBAN VALUES
(N'NXB Lao động',  'info@nxblaodong.com.vn',  N'Số 97 Trần Quốc Toản,  Phường Trần Hưng Đạo,  Quận Hoàn Kiếm,  Thành phố Hà Nội'), 
(N'NXB Kim đồng',  'cskh_online@nxbkimdong.com.vn',  N'Số 55 Quang Trung,  Nguyễn Du,  Hai Bà Trưng,  Hà Nội'), 
(N'NXB Giáo dục Việt Nam',  'nxbgd@moet.edu.vn',  N'Số 81 Trần Hưng Đạo,  Hoàn Kiếm,  Hà Nội'), 
(N'NXB Trẻ',  'hopthubandoc@nxbtre.com.vn',  N'161B Lý Chính Thắng,  Phường Võ Thị Sáu,  Quận 3 ,  TP. Hồ Chí Minh')

INSERT INTO THUTHU VALUES
(N'Nguyễn Chí Đức',  0123456789,  'breadwithginger@gmail.com')

INSERT INTO TACGIA VALUES
(N'PGS.TS. Lê Thái Phong', 11-03-1979, N'Việt Nam'), 
(N'ThS. Nguyễn Diệu Ninh', null, N'Việt Nam'), 
(N'ThS. Phạm Thị Mỹ Dung', null, N'Việt Nam'), 
(N'Phan Đăng', 16-02-1984, N'Việt Nam'), 
(N'Hase Seishu', 18-02-1965, N'Nhật Bản')

INSERT INTO SACH VALUES
(N'Kỹ năng làm việc nhóm', 10, 'kynanglamviecnhom.jpg', 5, 1), 
(N'39 cuộc đối thoại tri thức', 5, '39-cuoc-doi-thoai-tri-thuc.png', 5, 2), 
(N'Chú chó hộ mệnh', 3, 'chuchuhomenh.png', 6, 2)

INSERT INTO PHIENBANSACH VALUES
(1, 1, 2023, 1), 
(1, 2, 2023, 1), 
(1, 3, 2023, 1), 
(2, 4, null, 1), 
(3, 5, 2023, 1)

INSERT INTO PHIEUMUONSACH VALUES
(06-11-2024, 07-11-2024, 1), 
(29-10-2024, 01-11-2024, 1)

INSERT INTO CHITIETPHIEUMUON VALUES
(1, 2, 20-11-2024, 1), 
(1, 3, 15-11-2024, 1)