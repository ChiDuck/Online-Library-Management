USE QuanLyThuVien
GO

-- RESET AUTO_INCREAMENT
IF exists (SELECT * FROM TAIKHOAN)		DBCC CHECKIDENT (TAIKHOAN, RESEED, 0)
IF exists (SELECT * FROM DOCGIA)		DBCC CHECKIDENT (DOCGIA, RESEED, 0)
IF exists (SELECT * FROM THELOAI)		DBCC CHECKIDENT (THELOAI, RESEED, 0)
IF exists (SELECT * FROM NHAXUATBAN)	DBCC CHECKIDENT (NHAXUATBAN, RESEED, 0)
IF exists (SELECT * FROM TACGIA)		DBCC CHECKIDENT (TACGIA, RESEED, 0)
IF exists (SELECT * FROM THUTHU)		DBCC CHECKIDENT (THUTHU, RESEED, 0)
IF exists (SELECT * FROM SACH)			DBCC CHECKIDENT (SACH, RESEED, 0)
IF exists (SELECT * FROM PHIEUMUONSACH) DBCC CHECKIDENT (PHIEUMUONSACH, RESEED, 0)

-- DELETE DATA FROM TABLES
DELETE FROM PHIENBANSACH
DELETE FROM CHITIETPHIEUMUON
DELETE FROM PHIEUMUONSACH
DELETE FROM SACH
DELETE FROM THELOAI
DELETE FROM TACGIA
DELETE FROM THUTHU
DELETE FROM NHAXUATBAN	  
DELETE FROM DOCGIA
DELETE FROM TAIKHOAN
						  
INSERT INTO TAIKHOAN VALUES
('duc','123',0),
('ducuser','123',1),			  
('nghia','123',1)			  
						  
INSERT INTO DOCGIA VALUES
(N'Nguyễn Đức','duc@gmail.com','2003-2-16',2),
(N'Đặng Minh Nghĩa','nghia@gmail.com','2003-2-16',3)

INSERT INTO THELOAI VALUES
(N'Sách giáo khoa'),    --1
(N'Sách tham khảo'),    --2
(N'Sách giáo viên'),    --3
(N'Sách bài tập'), 		--4
(N'Kỹ năng'), 			--5
(N'Tiểu thuyết'), 		--6
(N'Truyện tranh'), 		--7
(N'Truyện ngắn'), 		--8
(N'Kinh dị'), 			--9
(N'Ngôn tình'),			--10
(N'Văn học'), 			--11
(N'Khoa học'), 			--12
(N'Tập thơ')			--13

INSERT INTO NHAXUATBAN VALUES
(N'NXB Lao động', 'info@nxblaodong.com.vn',			N'Số 97 Trần Quốc Toản, Phường Trần Hưng Đạo, Quận Hoàn Kiếm, Thành phố Hà Nội'), 
(N'NXB Kim đồng', 'cskh_online@nxbkimdong.com.vn',	N'Số 55 Quang Trung, Nguyễn Du, Hai Bà Trưng, Hà Nội'), 
(N'NXB Giáo dục Việt Nam', 'nxbgd@moet.edu.vn',		N'Số 81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội'), 
(N'NXB Trẻ', 'hopthubandoc@nxbtre.com.vn',			N'161B Lý Chính Thắng, Phường Võ Thị Sáu, Quận 3 , TP. Hồ Chí Minh')

INSERT INTO THUTHU VALUES
(N'Nguyễn Chí Đức', 0123456789, 'breadwithginger@gmail.com',1)

INSERT INTO TACGIA VALUES
(N'PGS.TS. Lê Thái Phong',	'1979-3-11',	N'Việt Nam'), 
(N'ThS. Nguyễn Diệu Ninh',	null,			N'Việt Nam'), 
(N'ThS. Phạm Thị Mỹ Dung',	null,			N'Việt Nam'), 
(N'Phan Đăng',				'1984-2-16',	N'Việt Nam'), 
(N'Hase Seishu',			'1965-2-18',	N'Nhật Bản')

INSERT INTO SACH VALUES
(N'Kỹ năng làm việc nhóm',		10, 2023, 'kynanglamviecnhom.jpg',			5, 1), 
(N'39 cuộc đối thoại tri thức', 5,	2023, '39-cuoc-doi-thoai-tri-thuc.png',	5, 2), 
(N'Chú chó hộ mệnh',			3,	2024, 'chuchohomenh.jpg',				6, 2)

INSERT INTO PHIENBANSACH VALUES
(1, 1, N'Tác giả chính'), 
(1, 2, N'Tác giả phụ'), 
(1, 3, N'Biên tập viên'), 
(2, 4, N'Tác giả chính'), 
(3, 5, N'Tác giả chính')

INSERT INTO PHIEUMUONSACH VALUES
('2024-11-6',  '2024-11-7',	1, 1), 
('2024-10-28', '2024-11-1', 1, 1)

INSERT INTO CHITIETPHIEUMUON VALUES
(1, 2, '2024-11-15', 1), 
(1, 3, '2024-11-20', 1),
(2, 1, '2024-11-27', 2)