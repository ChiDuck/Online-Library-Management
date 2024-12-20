USE [QuanLyThuVien]
GO
SET IDENTITY_INSERT [dbo].[THELOAI] ON 

INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (1, N'Sách giáo khoa')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (2, N'Sách tham khảo')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (3, N'Sách giáo viên')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (4, N'Sách bài tập')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (5, N'Kỹ năng')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (6, N'Tiểu thuyết')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (7, N'Truyện tranh')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (8, N'Truyện ngắn')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (9, N'Kinh dị')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (10, N'Ngôn tình')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (11, N'Văn học')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (12, N'Khoa học')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (13, N'Tập thơ')
INSERT [dbo].[THELOAI] ([MALOAI], [TENLOAI]) VALUES (14, N'Tùy bút')
SET IDENTITY_INSERT [dbo].[THELOAI] OFF
GO
SET IDENTITY_INSERT [dbo].[NHAXUATBAN] ON 

INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (1, N'NXB Lao động', N'info@nxblaodong.com.vn', N'Số 97 Trần Quốc Toản, Phường Trần Hưng Đạo, Quận Hoàn Kiếm, Thành phố Hà Nội')
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (2, N'NXB Kim đồng', N'cskh_online@nxbkimdong.com.vn', N'Số 55 Quang Trung, Nguyễn Du, Hai Bà Trưng, Hà Nội')
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (3, N'NXB Giáo dục Việt Nam', N'nxbgd@moet.edu.vn', N'Số 81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội')
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (4, N'NXB Trẻ', N'hopthubandoc@nxbtre.com.vn', N'161B Lý Chính Thắng, Phường Võ Thị Sáu, Quận 3 , TP. Hồ Chí Minh')
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (5, N'NXB Văn học', N'info@nxbvanhoc.com.vn', N'18 Nguyễn Trường Tộ - Ba Đình - Hà Nội')
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (6, N'NXB Thanh Niên', N'info@nxbthanhnien.vn', N'D29 Khu đô thị mới Cầu Giấy, phường Yên Hòa, quận Cầu Giấy, Hà Nội')
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [EMAIL], [DIACHI]) VALUES (7, N'NXB Hồng Đức', N'nhaxuatbanhongduc65@gmail.com', N'65 Tràng Thi, P.Hàng Bông, Q.Hoàn Kiếm, Hà Nội')
SET IDENTITY_INSERT [dbo].[NHAXUATBAN] OFF
GO
SET IDENTITY_INSERT [dbo].[SACH] ON 

INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (1, N'Kỹ năng làm việc nhóm', 10, 2023, N'kynanglamviecnhom.jpg', 5, 1)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (2, N'39 cuộc đối thoại tri thức', 5, 2023, N'39-cuoc-doi-thoai-tri-thuc.png', 5, 2)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (3, N'Chú chó hộ mệnh', 15, 2024, N'chuchohomenh.jpg', 6, 2)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (4, N'Tuyển tập truyện ngắn Trang Thế Hy', 18, 2024, N'nxbtre_trthehy.jpg', 8, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (5, N'LOOK BACK', 8, 2024, N'lookback.jpg', 7, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (6, N'Vào vùng nước xoáy', 22, 2024, N'vungnuocxoay.jpg', 6, 5)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (7, N'Rong chơi miền vui thú', 2, 2024, N'img-0858.jpg', 14, 5)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (8, N'FAUST', 8, 2023, N'faust.jpg', 11, 5)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (9, N'Ông Già Và Biển Cả', 12, 2023, N'onggia.jpg', 11, 5)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (11, N'Khôn ngoan hơn thuật toán', 15, 2024, N'nxbtre_full_26032024_040303.jpg', 5, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (12, N'Hành Trang Lập Trình - Những Kỹ Năng Lập Trình Viên Chuyên Nghiệp Cần Có', 10, 2020, N'laptrinh.jpg', 12, 6)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (13, N'VŨ TRỤ TRONG VỎ HẠT DẺ', 10, 2022, N'nxbtre_vutru.jpg', 12, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (14, N'Nghệ Thuật Tư Duy Dựa Trên Dữ Liệu', 8, 2022, N'nxbtre_full_27472022_114749.jpg', 12, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (15, N'Ngày xưa có một chuyện tình', 10, 2024, N'nxbtre_full_06022024_040257.jpg', 10, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (16, N'Nhà Đen', 5, 2019, N'nhaden_bia1_1.jpg', 9, 7)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (17, N'Tiệm Sách Của Nàng', 5, 2024, N'nxbtre_full_25422024_024216.jpg', 11, 4)
INSERT [dbo].[SACH] ([MASACH], [TENSACH], [SOLUONG], [NAMXUATBAN], [ANHBIA], [MALOAI], [MANXB]) VALUES (18, N'Cho tôi xin một vé đi tuổi thơ', 4, 2019, N'10925109.jpg', 11, 4)
SET IDENTITY_INSERT [dbo].[SACH] OFF
GO
SET IDENTITY_INSERT [dbo].[TACGIA] ON 

INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (1, N'PGS.TS. Lê Thái Phong', CAST(N'1979-03-11' AS Date), NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (2, N'ThS. Nguyễn Diệu Ninh', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (3, N'ThS. Phạm Thị Mỹ Dung', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (4, N'Phan Đăng', CAST(N'1984-02-16' AS Date), NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (5, N'Hase Seishu', CAST(N'1965-02-18' AS Date), NULL, N'Nhật Bản')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (6, N'Trang Thế Hy', CAST(N'1924-10-29' AS Date), CAST(N'2015-12-08' AS Date), N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (7, N'Tatsuki Fujimoto', CAST(N'1993-10-10' AS Date), NULL, N'Nhật Bản')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (8, N'Ili Tenjou', NULL, NULL, N'Nhật Bản')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (9, N'Edgar Allan Poe', CAST(N'1809-01-19' AS Date), CAST(N'1849-10-07' AS Date), N'Hoa Kỳ')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (10, N'Lê Minh Đức', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (12, N'Lê Hữu Tỉnh', CAST(N'1952-01-01' AS Date), NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (14, N'Johann Wolfgang von Goethe', CAST(N'1794-08-28' AS Date), CAST(N'1832-03-22' AS Date), N'Đức')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (15, N'Quang Chiến', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (16, N'Ernest Hemingway', CAST(N'1899-07-21' AS Date), CAST(N'1961-07-02' AS Date), N'Hoa Kỳ')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (17, N'Lê Huy Bắc', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (18, N'Gerd Gigerenzer', CAST(N'1947-09-03' AS Date), NULL, N'Đức')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (19, N'Khổng Loan', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (20, N'Vũ Công Tấn Tài', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (21, N'Stephen Hawking', CAST(N'1942-01-08' AS Date), CAST(N'2018-03-14' AS Date), N'Vương Quốc Anh')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (22, N'Hoàng Hữu Đà', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (23, N'Nguyễn Nhật Ánh', CAST(N'1955-05-07' AS Date), NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (24, N'Peter May', CAST(N'1951-12-20' AS Date), NULL, N'Vương Quốc Anh')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (25, N'Minh Tú', NULL, NULL, N'Việt Nam')
INSERT [dbo].[TACGIA] ([MATACGIA], [TENTACGIA], [NGAYSINH], [NGAYMAT], [QUOCTICH]) VALUES (26, N'Đỗ Hoàng Tường', CAST(N'1960-01-01' AS Date), NULL, N'Việt Nam')
SET IDENTITY_INSERT [dbo].[TACGIA] OFF
GO
