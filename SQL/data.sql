USE QuanLyThuVien
GO

-- RESET AUTO_INCREAMENT
IF exists (SELECT * FROM TAIKHOAN)		DBCC CHECKIDENT (TAIKHOAN, RESEED, 0)
IF exists (SELECT * FROM TINHTRANGMUON)	DBCC CHECKIDENT (TINHTRANGMUON, RESEED, 0)
IF exists (SELECT * FROM TINHTRANGPHIEU)DBCC CHECKIDENT (TINHTRANGPHIEU, RESEED, 0)
IF exists (SELECT * FROM DOCGIA)		DBCC CHECKIDENT (DOCGIA, RESEED, 0)
IF exists (SELECT * FROM THELOAI)		DBCC CHECKIDENT (THELOAI, RESEED, 0)
IF exists (SELECT * FROM NHAXUATBAN)	DBCC CHECKIDENT (NHAXUATBAN, RESEED, 0)
IF exists (SELECT * FROM TACGIA)		DBCC CHECKIDENT (TACGIA, RESEED, 0)
IF exists (SELECT * FROM THUTHU)		DBCC CHECKIDENT (THUTHU, RESEED, 0)
IF exists (SELECT * FROM SACH)			DBCC CHECKIDENT (SACH, RESEED, 0)
IF exists (SELECT * FROM PHIEUMUONSACH) DBCC CHECKIDENT (PHIEUMUONSACH, RESEED, 0)
IF exists (SELECT * FROM PHIEUTRASACH)	DBCC CHECKIDENT (PHIEUTRASACH, RESEED, 0)
IF exists (SELECT * FROM PHIEUGIAHAN)	DBCC CHECKIDENT (PHIEUGIAHAN, RESEED, 0)

-- DELETE DATA FROM TABLES
--DELETE FROM CHITIETPHIEUTRA
DELETE FROM PHIEUTRASACH
DELETE FROM PHIEUGIAHAN
DELETE FROM PHIENBANSACH
DELETE FROM CHITIETPHIEUMUON
DELETE FROM PHIEUMUONSACH
DELETE FROM SACH
DELETE FROM THELOAI
DELETE FROM TACGIA
DELETE FROM THUTHU
DELETE FROM NHAXUATBAN	  
DELETE FROM DOCGIA
DELETE FROM TINHTRANGMUON
DELETE FROM TINHTRANGPHIEU
DELETE FROM TAIKHOAN
						  
INSERT INTO TAIKHOAN VALUES
('duc','123','breadwithginger@gmail.com', 0),
('ducuser','123','duc@gmail.com', 1),			  
('nghia','123','nghia@gmail.com', 1)			  
						  
INSERT INTO TINHTRANGMUON VALUES
(N'Chờ phê duyệt'),		--1
(N'Đang mượn'),			--2
(N'Đã trả'),			--3
(N'Trễ hạn'),			--4
(N'Mất sách')			--5

INSERT INTO TINHTRANGPHIEU VALUES
(N'Chờ phê duyệt'),		--1
(N'Đã chấp nhận'),		--2
(N'Đã kết thúc'),		--3
(N'Từ chối'),			--4
(N'Trễ hạn')			--5

INSERT INTO DOCGIA VALUES
(N'Nguyễn Đức', '2003-2-16', 2),
(N'Đặng Minh Nghĩa', '2003-2-16', 3)

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
(N'Tập thơ'),			--13
(N'Tùy bút')			--14

INSERT INTO NHAXUATBAN VALUES
(N'NXB Lao động',		'info@nxblaodong.com.vn',		N'Số 97 Trần Quốc Toản, Phường Trần Hưng Đạo, Quận Hoàn Kiếm, Thành phố Hà Nội'), 
(N'NXB Kim đồng',		'cskh_online@nxbkimdong.com.vn',N'Số 55 Quang Trung, Nguyễn Du, Hai Bà Trưng, Hà Nội'), 
(N'NXB Giáo dục Việt Nam', 'nxbgd@moet.edu.vn',			N'Số 81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội'), 
(N'NXB Trẻ',			'hopthubandoc@nxbtre.com.vn',	N'161B Lý Chính Thắng, Phường Võ Thị Sáu, Quận 3 , TP. Hồ Chí Minh'),
(N'NXB Văn học',		'info@nxbvanhoc.com.vn',		N'18 Nguyễn Trường Tộ - Ba Đình - Hà Nội'),
(N'NXB Thanh Niên',		'info@nxbthanhnien.vn',			N'D29 Khu đô thị mới Cầu Giấy, phường Yên Hòa, quận Cầu Giấy, Hà Nội'),
(N'NXB Hồng Đức',		'nhaxuatbanhongduc65@gmail.com',N'65 Tràng Thi, P.Hàng Bông, Q.Hoàn Kiếm, Hà Nội')

INSERT INTO THUTHU VALUES
(N'Nguyễn Chí Đức', '0123456789', 1)

INSERT INTO TACGIA VALUES
(N'PGS.TS. Lê Thái Phong',	'1979-3-11',	null,			N'Việt Nam'),			--1
(N'ThS. Nguyễn Diệu Ninh',	null,			null,			N'Việt Nam'),			--2
(N'ThS. Phạm Thị Mỹ Dung',	null,			null,			N'Việt Nam'),			--3
(N'Phan Đăng',				'1984-2-16',	null,			N'Việt Nam'),			--4
('Hase Seishu',				'1965-2-18',	null,			N'Nhật Bản'),			--5
(N'Trang Thế Hy',			'1924-10-29', '2015-12-8',		N'Việt Nam'),			--6
('Tatsuki Fujimoto',		'1993-10-10',	null,			N'Nhật Bản'),			--7
('Ili Tenjou',				null,			null,			N'Nhật Bản'),			--8
('Edgar Allan Poe',			'1809-01-19','1849-10-07',		N'Hoa Kỳ'),				--9
(N'Lê Minh Đức',			NULL,			NULL,			N'Việt Nam'),			--10
(N'Lê Hữu Tỉnh',			'1952-01-01',	NULL,			N'Việt Nam'),			--11
('Johann Wolfgang von Goethe','1794-08-28','1832-03-22',	N'Đức'),				--12
(N'Quang Chiến',			NULL,			NULL,			N'Việt Nam'),			--13
('Ernest Hemingway',		'1899-07-21',	'1961-07-02',	N'Hoa Kỳ'),				--14
(N'Lê Huy Bắc',				NULL,			NULL,			N'Việt Nam'),			--15
('Gerd Gigerenzer',			'1947-09-03',	NULL,			N'Đức'),				--16
(N'Khổng Loan',				NULL,			NULL,			N'Việt Nam'),			--17
(N'Vũ Công Tấn Tài',		NULL,			NULL,			N'Việt Nam'),			--18
('Stephen Hawking',			'1942-01-08',	'2018-03-14',	N'Vương Quốc Anh'),		--19
(N'Hoàng Hữu Đà',			NULL,			NULL,			N'Việt Nam'),			--20
(N'Nguyễn Nhật Ánh',		'1955-05-07',	NULL,			N'Việt Nam'),			--21
('Peter May',				'1951-12-20',	NULL,			N'Vương Quốc Anh'),		--22
(N'Minh Tú',				NULL,			NULL,			N'Việt Nam'),			--23
(N'Đỗ Hoàng Tường',			'1960-01-01',	NULL,			N'Việt Nam')			--24

INSERT INTO SACH VALUES
(N'Kỹ năng làm việc nhóm',				10, 2023,	'kynanglamviecnhom.jpg',			5,	1),						--1
(N'39 cuộc đối thoại tri thức',			5,	2023,	'39-cuoc-doi-thoai-tri-thuc.png',	5,	2), 					--2
(N'Chú chó hộ mệnh',					15,	2024,	'chuchohomenh.jpg',					6,	2),						--3
(N'Tuyển tập truyện ngắn Trang Thế Hy',	18,	2024,	'nxbtre_trthehy.jpg',				8,	4),						--4
('LOOK BACK',							8,	2024,	'lookback.jpg',						7,	4),						--5
(N'Vào vùng nước xoáy',					22, 2024,	'vungnuocxoay.jpg',					6,	5),						--6
(N'Rong chơi miền vui thú',				2,	2024,	'img-0858.jpg',						14, 5),						--7
('FAUST',								8,	2023,	'faust.jpg',						11, 5),						--8
(N'Ông Già Và Biển Cả',					12, 2023,	'onggia.jpg',						11, 5),						--9
(N'Khôn ngoan hơn thuật toán',			15, 2024,	'nxbtre_full_26032024_040303.jpg',	5,	4),						--10
(N'Hành Trang Lập Trình - Kỹ Năng Lập Trình Viên', 10, 2020, N'laptrinh.jpg', 12, 6),	--11
(N'VŨ TRỤ TRONG VỎ HẠT DẺ',				10, 2022,	'nxbtre_vutru.jpg',					12, 4),						--12
(N'Nghệ Thuật Tư Duy Dựa Trên Dữ Liệu', 8,	2022,	'nxbtre_full_27472022_114749.jpg',	12,	4),						--13
(N'Ngày xưa có một chuyện tình',		10, 2024,	'nxbtre_full_06022024_040257.jpg',	10, 4),						--14
(N'Nhà Đen',							5,	2019,	'nhaden_bia1_1.jpg',				9,	7),						--15
(N'Tiệm Sách Của Nàng',					5,	2024,	'nxbtre_full_25422024_024216.jpg',	11, 4),						--16
(N'Cho tôi xin một vé đi tuổi thơ',		4,	2019,	'10925109.jpg',						11, 4)						--17

INSERT INTO PHIENBANSACH VALUES		--mã sách, mã tác giả
(1, 1,		N'Tác giả chính'),		--1
(1, 2,		N'Tác giả phụ  '), 		--2
(1, 3,		N'Biên tập viên'), 		--3
(2, 4,		N'Tác giả chính'), 		--4
(3, 5,		N'Tác giả chính'),		--5
(4, 6,		N'Tác giả chính'),		--6
(5, 7,		N'Tác giả chính'),		--7
(5, 8,		N'Dịch giả	   '),		--8
(6, 9,		N'Tác giả chính'),		--9
(6, 10,		N'Dịch giả     '),		--10
(7, 11,		N'Tác giả chính'),		--11
(8, 12,		N'Tác giả chính'),		--12
(8, 13,		N'Dịch giả     '),		--13
(9, 14,		N'Tác giả chính'),		--14
(9, 15,		N'Dịch giả     '),		--15
(10, 16,	N'Tác giả chính'),		--16
(10, 17,	N'Dịch giả     '),		--17
(11, 18,	N'Tác giả chính'),		--18
(12, 19,	N'Tác giả chính'),		--19
(13, 20,	N'Tác giả chính'),		--20
(14, 21,	N'Tác giả chính'),		--21
(15, 22,	N'Tác giả chính'),		--22
(15, 23,	N'Dịch giả     '),		--23
(16, 21,	N'Tác giả chính'),		--24
(17, 21,	N'Tác giả chính'),		--25
(17, 24,	N'Biên tập viên')		--26

INSERT INTO PHIEUMUONSACH VALUES		-- Ngày lập, ngày mượn, hạn trả, số lượng, ghi chú, mã tình trạng, mã tthu, mã độc giả
('2024-11-6',  '2024-11-7', '2024-11-14',2, null, 3, 1, 1), 
('2024-10-28', '2024-11-1', '2024-11-4'	,1, null, 3, 1, 2)

INSERT INTO CHITIETPHIEUMUON VALUES		-- Mã phiếu, mã sách, mã tình trạng
(1, 2, 3), 
(1, 3, 3),
(2, 5, 3)

INSERT INTO PHIEUTRASACH VALUES		-- Ngày lập, số lượng trả, ghi chú, mã phiếu mượn, mã tthu
('2024-11-17', 2, null, 1, 1),
('2024-11-4' , 1, null, 2, 1)

INSERT INTO PHIEUGIAHAN VALUES		-- Ngày lập, ngày duyệt, hạn mới, lần ghan, ghi chú, lý do,mã tình trạng, mã phiếu mượn, mã tthu
('2024-11-14','2024-11-14','2024-11-17', 1, N'Không trả phạt giờ',N'Xin muộn 2 ngày', 2, 1, 1)

select * from DOCGIA
select * from TAIKHOAN
select * from PHIEUGIAHAN
select CHITIETPHIEUMUON.* from CHITIETPHIEUMUON join PHIEUMUONSACH on CHITIETPHIEUMUON.MAPHIEU = PHIEUMUONSACH.MAPHIEU
where PHIEUMUONSACH.MAPHIEU = 3

