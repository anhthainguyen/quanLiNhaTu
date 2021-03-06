USE [master]
GO
/****** Object:  Database [QUAN_LI_NHA_TU]    Script Date: 5/28/2019 2:19:01 PM ******/
CREATE DATABASE [QUAN_LI_NHA_TU]
GO
USE [QUAN_LI_NHA_TU]
GO
/****** Object:  Table [dbo].[BO_PHAN]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BO_PHAN](
	[Ma_BP] [nvarchar](128) NOT NULL,
	[Ten_BP] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_BP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BO_PHAN_CA_TRUC]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BO_PHAN_CA_TRUC](
	[Ma_BP] [nvarchar](128) NOT NULL,
	[Ngay_Trong_Tuan] [int] NOT NULL,
	[Bat_Dau] [time](7) NOT NULL,
	[Ket_Thuc] [time](7) NOT NULL,
 CONSTRAINT [PK_BP_CT] PRIMARY KEY CLUSTERED 
(
	[Ma_BP] ASC,
	[Ngay_Trong_Tuan] ASC,
	[Bat_Dau] ASC,
	[Ket_Thuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CA_TRUC]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CA_TRUC](
	[Ngay_Trong_Tuan] [int] NOT NULL,
	[Bat_Dau] [time](7) NOT NULL,
	[Ket_Thuc] [time](7) NOT NULL,
 CONSTRAINT [PK_Ca_Truc] PRIMARY KEY CLUSTERED 
(
	[Ngay_Trong_Tuan] ASC,
	[Bat_Dau] ASC,
	[Ket_Thuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAN_BO]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAN_BO](
	[Ma_CB] [nvarchar](128) NOT NULL,
	[Ho_Ten] [nvarchar](max) NULL,
	[SDT] [nvarchar](20) NULL,
	[Ngay_Sinh] [date] NULL,
	[Mat_Khau] [nvarchar](max) NULL,
	[Ma_BP] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_CB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAN_BO_CONG_VIEC]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAN_BO_CONG_VIEC](
	[Ma_CB] [nvarchar](128) NOT NULL,
	[Ma_CV] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_CB_CV] PRIMARY KEY CLUSTERED 
(
	[Ma_CB] ASC,
	[Ma_CV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAN_BO_DOT_KHAM_BENH]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAN_BO_DOT_KHAM_BENH](
	[Ma_CB] [nvarchar](128) NOT NULL,
	[Ngay_KB] [datetime] NOT NULL,
 CONSTRAINT [PK_CB_DKB] PRIMARY KEY CLUSTERED 
(
	[Ma_CB] ASC,
	[Ngay_KB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAU_HINH]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAU_HINH](
	[Ma_CH] [int] IDENTITY(1,1) NOT NULL,
	[Ten_CH] [nvarchar](max) NULL,
	[Gia_Tri] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_CH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONG_VIEC]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONG_VIEC](
	[Ma_CV] [nvarchar](128) NOT NULL,
	[Ten_CV] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_CV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DOT_KHAM_BENH]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOT_KHAM_BENH](
	[Ngay_KB] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Ngay_KB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHEN_THUONG]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHEN_THUONG](
	[Ma_KT] [int] IDENTITY(1,1) NOT NULL,
	[Ten_KT] [nvarchar](max) NULL,
	[Ma_Tu_N] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_KT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NANG_KHIEU]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NANG_KHIEU](
	[Ma_NK] [int] IDENTITY(1,1) NOT NULL,
	[Ten_NK] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_NK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THAN_NHAN]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAN_NHAN](
	[Ma_Than_N] [nvarchar](128) NOT NULL,
	[Ho_Ten] [nvarchar](max) NULL,
	[Gioi_Tinh] [nvarchar](5) NULL,
	[Ngay_Sinh] [date] NULL,
	[SDT] [nvarchar](20) NULL,
	[Mat_Khau] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_Than_N] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TU_NHAN]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TU_NHAN](
	[Ma_Tu_N] [nvarchar](128) NOT NULL,
	[Ho_Ten] [nvarchar](max) NULL,
	[Ngay_Sinh] [date] NULL,
	[Gioi_Tinh] [nvarchar](5) NULL,
	[Toi_Danh] [nvarchar](max) NULL,
	[Ngay_Vao_Tu] [datetime] NULL,
	[Ngay_Ra_Tu] [datetime] NULL,
	[Tinh_Trang_suc_Khoe] [nvarchar](max) NULL,
	[Ngay_Duoc_Tham_Nuoi] [datetime] NULL,
	[Muc_Do_Cai_Tao] [nvarchar](20) NULL,
	[Tinh_Trang_Giam_Giu] [nvarchar](max) NULL,
	[Ngay_Kham] [datetime] NULL,
	[Ngay_Tai_Kham] [datetime] NULL,
	[Mat_Khau] [nvarchar](max) NULL,
	[Ma_Than_N] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_Tu_N] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TU_NHAN_DOT_KHAM_BENH]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TU_NHAN_DOT_KHAM_BENH](
	[Ma_Tu_N] [nvarchar](128) NOT NULL,
	[Ngay_KB] [datetime] NOT NULL,
 CONSTRAINT [PK_Tu_N_Dot_KB] PRIMARY KEY CLUSTERED 
(
	[Ma_Tu_N] ASC,
	[Ngay_KB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TU_NHAN_NANG_KHIEU]    Script Date: 5/28/2019 2:19:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TU_NHAN_NANG_KHIEU](
	[Ma_NK] [int] NOT NULL,
	[Ma_Tu_N] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Tu_N_NK] PRIMARY KEY CLUSTERED 
(
	[Ma_NK] ASC,
	[Ma_Tu_N] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[BO_PHAN] ([Ma_BP], [Ten_BP]) VALUES (N'BP01', N'Quản giáo')
INSERT [dbo].[BO_PHAN] ([Ma_BP], [Ten_BP]) VALUES (N'BP02', N'Y tế')
INSERT [dbo].[BO_PHAN] ([Ma_BP], [Ten_BP]) VALUES (N'BP03', N'Tiếp nhận phóng tích tù nhân')
INSERT [dbo].[BO_PHAN] ([Ma_BP], [Ten_BP]) VALUES (N'BP04', N'Cấp dưỡng')
INSERT [dbo].[BO_PHAN] ([Ma_BP], [Ten_BP]) VALUES (N'BP05', N'Quản lý')
INSERT [dbo].[BO_PHAN] ([Ma_BP], [Ten_BP]) VALUES (N'BP06', N'Cải tạo')
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP01', 2, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP01', 8, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP02', 2, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP02', 4, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP03', 3, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP03', 6, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP04', 3, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP04', 4, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP05', 5, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[BO_PHAN_CA_TRUC] ([Ma_BP], [Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (N'BP06', 7, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (2, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (3, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (4, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (5, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (6, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (7, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc]) VALUES (8, CAST(N'08:00:00' AS Time), CAST(N'05:00:00' AS Time))
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_01', N'La Quang Tín', N'08698373', CAST(N'1975-01-02' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP01')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_010', N'Lâm Tài Minh', N'09956865', CAST(N'1983-12-06' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP04')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_02', N'Trương Quang Hùng', N'097486434', CAST(N'1985-04-05' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP02')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_03', N'Lâm Tấn Tài', N'09987865', CAST(N'1983-10-06' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP03')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_04', N'Nguyễn Đức Minh', N'09654278', CAST(N'1986-03-12' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP04')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_05', N'Lê Việt Hương', N'012345678', CAST(N'1986-03-12' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP05')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_06', N'Trương Văn Hùng', N'097486434', CAST(N'1985-04-05' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP06')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_07', N'Trần Đức Minh', N'09654278', CAST(N'1986-03-11' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP01')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_08', N'Trương Thị Hoa', N'097483434', CAST(N'1985-07-05' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP02')
INSERT [dbo].[CAN_BO] ([Ma_CB], [Ho_Ten], [SDT], [Ngay_Sinh], [Mat_Khau], [Ma_BP]) VALUES (N'CB_09', N'Lâm Chấn Tài', N'09987865', CAST(N'1973-10-06' AS Date), N'6fd742a61bd034804c00c49b18045020', N'BP03')
INSERT [dbo].[CAN_BO_CONG_VIEC] ([Ma_CB], [Ma_CV]) VALUES (N'CB_010', N'CV02')
INSERT [dbo].[CAN_BO_CONG_VIEC] ([Ma_CB], [Ma_CV]) VALUES (N'CB_02', N'CV01')
INSERT [dbo].[CAN_BO_CONG_VIEC] ([Ma_CB], [Ma_CV]) VALUES (N'CB_03', N'CV03')
INSERT [dbo].[CAN_BO_CONG_VIEC] ([Ma_CB], [Ma_CV]) VALUES (N'CB_04', N'CV02')
INSERT [dbo].[CAN_BO_CONG_VIEC] ([Ma_CB], [Ma_CV]) VALUES (N'CB_08', N'CV01')
INSERT [dbo].[CAN_BO_CONG_VIEC] ([Ma_CB], [Ma_CV]) VALUES (N'CB_09', N'CV03')
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_01', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_010', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_02', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_03', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_04', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_05', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_06', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_07', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_08', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[CAN_BO_DOT_KHAM_BENH] ([Ma_CB], [Ngay_KB]) VALUES (N'CB_09', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[CONG_VIEC] ([Ma_CV], [Ten_CV]) VALUES (N'CV01', N'Khám Bệnh')
INSERT [dbo].[CONG_VIEC] ([Ma_CV], [Ten_CV]) VALUES (N'CV02', N'Phát thức ăn')
INSERT [dbo].[CONG_VIEC] ([Ma_CV], [Ten_CV]) VALUES (N'CV03', N'Tiếp nhận tù nhân')
INSERT [dbo].[DOT_KHAM_BENH] ([Ngay_KB]) VALUES (CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[DOT_KHAM_BENH] ([Ngay_KB]) VALUES (CAST(N'2019-07-08 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[KHEN_THUONG] ON 

INSERT [dbo].[KHEN_THUONG] ([Ma_KT], [Ten_KT], [Ma_Tu_N]) VALUES (1, N'C?i t?o T?t', N'TN09')
INSERT [dbo].[KHEN_THUONG] ([Ma_KT], [Ten_KT], [Ma_Tu_N]) VALUES (2, N'Giúp d? tù nhân khác', N'TN07')
INSERT [dbo].[KHEN_THUONG] ([Ma_KT], [Ten_KT], [Ma_Tu_N]) VALUES (3, N'Sáng t?o trong làm vi?c', N'TN08')
SET IDENTITY_INSERT [dbo].[KHEN_THUONG] OFF
SET IDENTITY_INSERT [dbo].[NANG_KHIEU] ON 

INSERT [dbo].[NANG_KHIEU] ([Ma_NK], [Ten_NK]) VALUES (1, N'Khéo tay')
INSERT [dbo].[NANG_KHIEU] ([Ma_NK], [Ten_NK]) VALUES (2, N'Hát hay')
INSERT [dbo].[NANG_KHIEU] ([Ma_NK], [Ten_NK]) VALUES (3, N'Ảo thuật')
SET IDENTITY_INSERT [dbo].[NANG_KHIEU] OFF
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_01', N'An Lành', N'Nam', CAST(N'1980-02-11' AS Date), N'0945234499', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_010', N'Nguyễn Văn Nhung', N'Nữ', CAST(N'1981-07-09' AS Date), N'0946767899', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_02', N'La Tấn Phát', N'Nam', CAST(N'1985-02-09' AS Date), N'0945267499', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_03', N'Nguyễn Hồng Nhung', N'Nữ', CAST(N'1991-07-09' AS Date), N'0946767499', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_04', N'Lê Thanh', N'Nam', CAST(N'1980-02-10' AS Date), N'0945234499', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_05', N'Nguyễn Chấn Lâm', N'Nam', CAST(N'1993-06-09' AS Date), N'0945267899', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_06', N'Nguyễn Hồng Hạnh', N'Nữ', CAST(N'1961-07-09' AS Date), N'0946767799', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_07', N'La Đại Phát', N'Nam', CAST(N'1980-09-11' AS Date), N'0945238799', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_08', N'La Tấn Minh', N'Nam', CAST(N'1985-05-09' AS Date), N'0945267999', NULL)
INSERT [dbo].[THAN_NHAN] ([Ma_Than_N], [Ho_Ten], [Gioi_Tinh], [Ngay_Sinh], [SDT], [Mat_Khau]) VALUES (N'TN_09', N'Nguyễn Hồng Thư', N'Nữ', CAST(N'1990-07-09' AS Date), N'0946767799', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN01', N'Lê Văn Ha', CAST(N'1974-05-07' AS Date), N'Nam', N'Ăn Cấp', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 1', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN010', N'Lê Quốc Minh', CAST(N'1974-05-07' AS Date), N'Nam', N'Ăn Cấp', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 1', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN02', N'Nguyễn Hoàng Anh', CAST(N'1974-05-07' AS Date), N'Nam', N'Cướp của', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 2', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN03', N'Liêu Văn Ưng', CAST(N'1974-05-07' AS Date), N'Nam', N'Ăn Cấp', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'Bệnh', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 1', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN04', N'La Đại Thành', CAST(N'1974-05-07' AS Date), N'Nam', N'Giết người', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 3', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN05', N'Nguyễn Văn Minh', CAST(N'1974-05-07' AS Date), N'Nam', N'Ăn Cấp', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 1', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN06', N'Lý Gia Thư', CAST(N'1974-05-07' AS Date), N'Nữ', N'Cớp Của', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'Bệnh', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 2', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN07', N'Lê Tuấn Phát', CAST(N'1974-05-07' AS Date), N'Nam', N'Ăn Cấp', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 1', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN08', N'Đào Văn Trung', CAST(N'1974-05-07' AS Date), N'Nam', N'Ăn Cấp', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'tốt', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 1', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN] ([Ma_Tu_N], [Ho_Ten], [Ngay_Sinh], [Gioi_Tinh], [Toi_Danh], [Ngay_Vao_Tu], [Ngay_Ra_Tu], [Tinh_Trang_suc_Khoe], [Ngay_Duoc_Tham_Nuoi], [Muc_Do_Cai_Tao], [Tinh_Trang_Giam_Giu], [Ngay_Kham], [Ngay_Tai_Kham], [Mat_Khau], [Ma_Than_N]) VALUES (N'TN09', N'La Thành', CAST(N'1974-05-07' AS Date), N'Nam', N'Giết người', CAST(N'1992-07-03 00:00:00.000' AS DateTime), CAST(N'2020-07-03 00:00:00.000' AS DateTime), N'Bệnh', CAST(N'2019-02-10 00:00:00.000' AS DateTime), N'Mức độ 3', N'Bình thường', CAST(N'2019-01-07 00:00:00.000' AS DateTime), CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'123', NULL)
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN01', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN010', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN02', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN03', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN04', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN05', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN06', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN07', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN08', CAST(N'2019-07-08 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_DOT_KHAM_BENH] ([Ma_Tu_N], [Ngay_KB]) VALUES (N'TN09', CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (1, N'TN03')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (1, N'TN04')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (1, N'TN07')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (2, N'TN01')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (2, N'TN010')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (2, N'TN06')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (3, N'TN02')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (3, N'TN05')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (3, N'TN08')
INSERT [dbo].[TU_NHAN_NANG_KHIEU] ([Ma_NK], [Ma_Tu_N]) VALUES (3, N'TN09')
ALTER TABLE [dbo].[BO_PHAN_CA_TRUC]  WITH CHECK ADD  CONSTRAINT [FK_BP_CT_1] FOREIGN KEY([Ma_BP])
REFERENCES [dbo].[BO_PHAN] ([Ma_BP])
GO
ALTER TABLE [dbo].[BO_PHAN_CA_TRUC] CHECK CONSTRAINT [FK_BP_CT_1]
GO
ALTER TABLE [dbo].[BO_PHAN_CA_TRUC]  WITH CHECK ADD  CONSTRAINT [FK_BP_CT_2] FOREIGN KEY([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc])
REFERENCES [dbo].[CA_TRUC] ([Ngay_Trong_Tuan], [Bat_Dau], [Ket_Thuc])
GO
ALTER TABLE [dbo].[BO_PHAN_CA_TRUC] CHECK CONSTRAINT [FK_BP_CT_2]
GO
ALTER TABLE [dbo].[CAN_BO]  WITH CHECK ADD FOREIGN KEY([Ma_BP])
REFERENCES [dbo].[BO_PHAN] ([Ma_BP])
GO
ALTER TABLE [dbo].[CAN_BO_CONG_VIEC]  WITH CHECK ADD  CONSTRAINT [FK_CB_CV_1] FOREIGN KEY([Ma_CB])
REFERENCES [dbo].[CAN_BO] ([Ma_CB])
GO
ALTER TABLE [dbo].[CAN_BO_CONG_VIEC] CHECK CONSTRAINT [FK_CB_CV_1]
GO
ALTER TABLE [dbo].[CAN_BO_CONG_VIEC]  WITH CHECK ADD  CONSTRAINT [FK_CB_CV_2] FOREIGN KEY([Ma_CV])
REFERENCES [dbo].[CONG_VIEC] ([Ma_CV])
GO
ALTER TABLE [dbo].[CAN_BO_CONG_VIEC] CHECK CONSTRAINT [FK_CB_CV_2]
GO
ALTER TABLE [dbo].[CAN_BO_DOT_KHAM_BENH]  WITH CHECK ADD  CONSTRAINT [FK_CB_KB_1] FOREIGN KEY([Ma_CB])
REFERENCES [dbo].[CAN_BO] ([Ma_CB])
GO
ALTER TABLE [dbo].[CAN_BO_DOT_KHAM_BENH] CHECK CONSTRAINT [FK_CB_KB_1]
GO
ALTER TABLE [dbo].[CAN_BO_DOT_KHAM_BENH]  WITH CHECK ADD  CONSTRAINT [FK_CB_KB_2] FOREIGN KEY([Ngay_KB])
REFERENCES [dbo].[DOT_KHAM_BENH] ([Ngay_KB])
GO
ALTER TABLE [dbo].[CAN_BO_DOT_KHAM_BENH] CHECK CONSTRAINT [FK_CB_KB_2]
GO
ALTER TABLE [dbo].[KHEN_THUONG]  WITH CHECK ADD FOREIGN KEY([Ma_Tu_N])
REFERENCES [dbo].[TU_NHAN] ([Ma_Tu_N])
GO
ALTER TABLE [dbo].[TU_NHAN]  WITH CHECK ADD  CONSTRAINT [FK_TuNhanThanNhan] FOREIGN KEY([Ma_Than_N])
REFERENCES [dbo].[THAN_NHAN] ([Ma_Than_N])
GO
ALTER TABLE [dbo].[TU_NHAN] CHECK CONSTRAINT [FK_TuNhanThanNhan]
GO
ALTER TABLE [dbo].[TU_NHAN_DOT_KHAM_BENH]  WITH CHECK ADD  CONSTRAINT [FK_Tu_N_Dot_KB_1] FOREIGN KEY([Ma_Tu_N])
REFERENCES [dbo].[TU_NHAN] ([Ma_Tu_N])
GO
ALTER TABLE [dbo].[TU_NHAN_DOT_KHAM_BENH] CHECK CONSTRAINT [FK_Tu_N_Dot_KB_1]
GO
ALTER TABLE [dbo].[TU_NHAN_DOT_KHAM_BENH]  WITH CHECK ADD  CONSTRAINT [FK_Tu_N_Dot_KB_2] FOREIGN KEY([Ngay_KB])
REFERENCES [dbo].[DOT_KHAM_BENH] ([Ngay_KB])
GO
ALTER TABLE [dbo].[TU_NHAN_DOT_KHAM_BENH] CHECK CONSTRAINT [FK_Tu_N_Dot_KB_2]
GO
ALTER TABLE [dbo].[TU_NHAN_NANG_KHIEU]  WITH CHECK ADD  CONSTRAINT [FK_Tu_N_NK_1] FOREIGN KEY([Ma_NK])
REFERENCES [dbo].[NANG_KHIEU] ([Ma_NK])
GO
ALTER TABLE [dbo].[TU_NHAN_NANG_KHIEU] CHECK CONSTRAINT [FK_Tu_N_NK_1]
GO
ALTER TABLE [dbo].[TU_NHAN_NANG_KHIEU]  WITH CHECK ADD  CONSTRAINT [FK_Tu_N_NK_2] FOREIGN KEY([Ma_Tu_N])
REFERENCES [dbo].[TU_NHAN] ([Ma_Tu_N])
GO
ALTER TABLE [dbo].[TU_NHAN_NANG_KHIEU] CHECK CONSTRAINT [FK_Tu_N_NK_2]
GO
USE [master]
GO
ALTER DATABASE [QUAN_LI_NHA_TU] SET  READ_WRITE 
GO
