create database QUAN_LI_NHA_TU
go

use QUAN_LI_NHA_TU
go

create table THAN_NHAN
(
	Ma_Than_N nvarchar(128) primary key,
	Ho_Ten nvarchar(max),
	Gioi_Tinh nvarchar(5),
	Ngay_Sinh date,
	SDT nvarchar(20),
)
go

create table TU_NHAN
(
	Ma_Tu_N nvarchar(128)primary key,
	Ho_Ten nvarchar (max),
	Ngay_Sinh date,
	Gioi_Tinh nvarchar(5),
	Toi_Danh nvarchar(max),
	Ngay_Vao_Tu datetime,
	Ngay_Ra_Tu datetime,
	Tinh_Trang_suc_Khoe nvarchar(max),
	Ngay_Duoc_Tham_Nuoi datetime,
	Muc_Do_Cai_Tao nvarchar(20),
	Tinh_Trang_Giam_Giu nvarchar(max),
	Ngay_Kham datetime,
	Ngay_Tai_Kham datetime,
	Mat_Khau nvarchar(max),
)
go

create table THAN_NHAN_TU_NHAN
(
	Ma_Tu_N nvarchar(128),
	Ma_Than_N nvarchar(128),
	CONSTRAINT PK_ThanN_TuN primary key (Ma_Tu_N, Ma_Than_N),
	CONSTRAINT FK_Than_N_Tu_N_1
		FOREIGN KEY (Ma_Tu_N) REFERENCES TU_NHAN(Ma_Tu_N),
	CONSTRAINT FK_Than_N_Tu_N_2
		FOREIGN KEY (Ma_Than_N) REFERENCES THAN_NHAN(Ma_Than_N)
)
go

create table NANG_KHIEU
(
	Ma_NK int identity (1,1) primary key,
	Ten_NK nvarchar(max),
)
go

create table TU_NHAN_NANG_KHIEU
(
	Ma_NK int ,
	Ma_Tu_N nvarchar(128),
	CONSTRAINT PK_Tu_N_NK primary key (Ma_NK,Ma_Tu_N),
	CONSTRAINT FK_Tu_N_NK_1
		FOREIGN KEY (Ma_NK) REFERENCES NANG_KHIEU(Ma_NK),
	CONSTRAINT FK_Tu_N_NK_2
		FOREIGN KEY (Ma_Tu_N) REFERENCES TU_NHAN(Ma_Tu_N),
)
go

create table KHEN_THUONG
(
	Ma_KT int identity (1,1) primary key,
	Ten_KT nvarchar(max),
	Ma_Tu_N nvarchar(128),
	FOREIGN KEY (Ma_Tu_N) REFERENCES TU_NHAN(Ma_Tu_N),
)
go

create table DOT_KHAM_BENH
(
	Ngay_KB datetime PRIMARY KEY,
)
GO

create table TU_NHAN_DOT_KHAM_BENH
(
	Ma_Tu_N nvarchar(128),
	Ngay_KB datetime,
	CONSTRAINT PK_Tu_N_Dot_KB PRIMARY KEY (Ma_Tu_N,Ngay_KB),
	CONSTRAINT FK_Tu_N_Dot_KB_1 
		FOREIGN KEY (Ma_Tu_n) REFERENCES TU_NHAN(Ma_Tu_N),
	CONSTRAINT FK_Tu_N_Dot_KB_2 
		FOREIGN KEY (Ngay_KB) REFERENCES DOT_KHAM_BENH(Ngay_KB),
)
GO

create table BO_PHAN
(
	Ma_BP nvarchar(128) PRIMARY KEY,
	Ten_BP nvarchar(max),
)
GO

create table CAN_BO
(
	Ma_CB nvarchar(128) PRIMARY KEY,
	Ho_Ten nvarchar(max),
	SDT nvarchar(20),
	Ngay_Sinh date,
	Mat_Khau nvarchar(max),
	Ma_BP nvarchar(128),
	foreign key (Ma_BP) references BO_PHAN(Ma_BP),
)
go

CREATE TABLE CAN_BO_DOT_KHAM_BENH
(
	Ma_CB nvarchar(128),
	Ngay_KB datetime,
	CONSTRAINT PK_CB_DKB PRIMARY KEY (Ma_CB,Ngay_KB),
	CONSTRAINT FK_CB_KB_1 FOREIGN KEY (Ma_CB) REFERENCES CAN_BO(Ma_CB),
	CONSTRAINT FK_CB_KB_2 FOREIGN KEY (Ngay_KB) REFERENCES DOT_KHAM_BENH(Ngay_KB),
)
GO

CREATE TABLE CONG_VIEC
(
	Ma_CV nvarchar(128) PRIMARY KEY,
	Ten_CV nvarchar(max),
)
GO

CREATE TABLE CAN_BO_CONG_VIEC
(
	Ma_CB nvarchar(128),
	Ma_CV nvarchar(128),
	CONSTRAINT PK_CB_CV PRIMARY KEY (Ma_CB,Ma_CV),
	CONSTRAINT FK_CB_CV_1 FOREIGN KEY (Ma_CB) REFERENCES CAN_BO(Ma_CB),
	CONSTRAINT FK_CB_CV_2 FOREIGN KEY (Ma_CV) REFERENCES CONG_VIEC(Ma_CV),
)
GO

CREATE TABLE CA_TRUC
(
	Ngay_Trong_Tuan int,
	Bat_Dau time,
	Ket_Thuc time,
	CONSTRAINT PK_Ca_Truc  PRIMARY KEY (Ngay_Trong_Tuan,Bat_Dau,Ket_Thuc),
)
GO

CREATE TABLE BO_PHAN_CA_TRUC
(
	Ma_BP nvarchar(128),
	Ngay_Trong_Tuan int,
	Bat_Dau time,
	Ket_Thuc time,
	CONSTRAINT PK_BP_CT PRIMARY KEY (Ma_BP,Ngay_Trong_Tuan,Bat_Dau,Ket_Thuc),
	CONSTRAINT FK_BP_CT_1 FOREIGN KEY (Ma_BP) REFERENCES BO_PHAN(Ma_BP),
	CONSTRAINT FK_BP_CT_2 FOREIGN KEY (Ngay_Trong_Tuan,Bat_Dau,Ket_Thuc) REFERENCES CA_TRUC(Ngay_Trong_Tuan,Bat_Dau,Ket_Thuc),
)
GO

CREATE TABLE CAU_HINH
(
	Ma_CH int identity(1,1) primary key,
	Ten_CH nvarchar(max),
	Gia_Tri int,
)
GO

insert into THAN_NHAN values('TN_01',N'An Lành','Nam','02/11/1980','0945234499');
insert into THAN_NHAN values('TN_02',N'La Tấn Phát','Nam','02/09/1985','0945267499');
insert into THAN_NHAN values('TN_03',N'Nguyễn Hồng Nhung',N'Nữ','07/09/1991','0946767499');
insert into THAN_NHAN values('TN_04',N'Lê Thanh','Nam','02/10/1980','0945234499');
insert into THAN_NHAN values('TN_05',N'Nguyễn Chấn Lâm','Nam','06/09/1993','0945267899');
insert into THAN_NHAN values('TN_06',N'Nguyễn Hồng Hạnh',N'Nữ','07/09/1961','0946767799');
insert into THAN_NHAN values('TN_07',N'La Đại Phát','Nam','09/11/1980','0945238799');
insert into THAN_NHAN values('TN_08',N'La Tấn Minh','Nam','05/09/1985','0945267999');
insert into THAN_NHAN values('TN_09',N'Nguyễn Hồng Thư',N'Nữ','07/09/1990','0946767799');
insert into THAN_NHAN values('TN_010',N'Nguyễn Văn Nhung',N'Nữ','07/09/1981','0946767899');

insert into TU_NHAN values('TN01',N'Lê Văn Ha','05/07/1974','Nam',N'Ăn Cấp','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 1',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN02',N'Nguyễn Hoàng Anh','05/07/1974','Nam',N'Cướp của','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 2',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN03',N'Liêu Văn Ưng','05/07/1974','Nam',N'Ăn Cấp','07/03/1992','07/03/2020',N'Bệnh','02/10/2019',N'Mức độ 1',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN04',N'La Đại Thành','05/07/1974','Nam',N'Giết người','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 3',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN05',N'Nguyễn Văn Minh','05/07/1974','Nam',N'Ăn Cấp','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 1',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN06',N'Lý Gia Thư','05/07/1974',N'Nữ',N'Cớp Của','07/03/1992','07/03/2020',N'Bệnh','02/10/2019',N'Mức độ 2',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN07',N'Lê Tuấn Phát','05/07/1974','Nam',N'Ăn Cấp','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 1',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN08',N'Đào Văn Trung','05/07/1974','Nam',N'Ăn Cấp','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 1',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN09',N'La Thành','05/07/1974','Nam',N'Giết người','07/03/1992','07/03/2020',N'Bệnh','02/10/2019',N'Mức độ 3',N'Bình thường','01/07/2019','01/08/2019','123');
insert into TU_NHAN values('TN010',N'Lê Quốc Minh','05/07/1974','Nam',N'Ăn Cấp','07/03/1992','07/03/2020',N'tốt','02/10/2019',N'Mức độ 1',N'Bình thường','01/07/2019','01/08/2019','123');

insert into THAN_NHAN_TU_NHAN values('TN010','TN_01');
insert into THAN_NHAN_TU_NHAN values('TN09','TN_03');
insert into THAN_NHAN_TU_NHAN values('TN08','TN_02');
insert into THAN_NHAN_TU_NHAN values('TN05','TN_04');
insert into THAN_NHAN_TU_NHAN values('TN07','TN_05');
insert into THAN_NHAN_TU_NHAN values('TN04','TN_06');
insert into THAN_NHAN_TU_NHAN values('TN06','TN_07');
insert into THAN_NHAN_TU_NHAN values('TN03','TN_08');
insert into THAN_NHAN_TU_NHAN values('TN01','TN_09');
insert into THAN_NHAN_TU_NHAN values('TN02','TN_010');

insert into NANG_KHIEU values(N'Khéo tay');
insert into NANG_KHIEU values(N'Hát hay');
insert into NANG_KHIEU values(N'Ảo thuật');

insert into TU_NHAN_NANG_KHIEU values('2','TN01');
insert into TU_NHAN_NANG_KHIEU values('1','TN03');
insert into TU_NHAN_NANG_KHIEU values('3','TN02');
insert into TU_NHAN_NANG_KHIEU values('2','TN06');
insert into TU_NHAN_NANG_KHIEU values('1','TN04');
insert into TU_NHAN_NANG_KHIEU values('3','TN05');
insert into TU_NHAN_NANG_KHIEU values('2','TN010');
insert into TU_NHAN_NANG_KHIEU values('1','TN07');
insert into TU_NHAN_NANG_KHIEU values('3','TN08');
insert into TU_NHAN_NANG_KHIEU values('3','TN09');

insert into KHEN_THUONG values('Cải tạo Tốt','TN09');
insert into KHEN_THUONG values('Giúp đở tù nhân khác','TN07');
insert into KHEN_THUONG values('Sáng tạo trong làm việc','TN08');

insert into DOT_KHAM_BENH values('07/05/2019');
insert into DOT_KHAM_BENH values('07/08/2019');

insert into TU_NHAN_DOT_KHAM_BENH values('TN01','07/05/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN02','07/08/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN03','07/05/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN04','07/08/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN05','07/05/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN06','07/08/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN07','07/05/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN08','07/08/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN09','07/05/2019');
insert into TU_NHAN_DOT_KHAM_BENH values('TN010','07/08/2019');

insert into BO_PHAN values('BP01',N'Quản giáo');
insert into BO_PHAN values('BP02',N'Y tế');
insert into BO_PHAN values('BP03',N'Tiếp nhận phóng tích tù nhân');
insert into BO_PHAN values('BP04',N'Cấp dưỡng');
insert into BO_PHAN values('BP05',N'Quản lý');
insert into BO_PHAN values('BP06',N'Cải tạo');

insert into CAN_BO values('CB_01',N'La Quang Tín','08698373','01/02/1975','123','BP01');
insert into CAN_BO values('CB_02',N'Trương Quang Hùng','097486434','04/05/1985','456','BP02');
insert into CAN_BO values('CB_03',N'Lâm Tấn Tài','09987865','10/06/1983','123','BP03');
insert into CAN_BO values('CB_04',N'Nguyễn Đức Minh','09654278','03/12/1986','113','BP04');
insert into CAN_BO values('CB_05',N'Lê Việt Hương','012345678','03/12/1986','12687','BP05');
insert into CAN_BO values('CB_06',N'Trương Văn Hùng','097486434','04/05/1985','4rưer6','BP06');
insert into CAN_BO values('CB_07',N'Trần Đức Minh','09654278','03/11/1986','113455','BP01');
insert into CAN_BO values('CB_08',N'Trương Thị Hoa','097483434','07/05/1985','45df6','BP02');
insert into CAN_BO values('CB_09',N'Lâm Chấn Tài','09987865','10/06/1973','12as3','BP03');
insert into CAN_BO values('CB_010',N'Lâm Tài Minh','09956865','12/06/1983','12rt3','BP04');

insert into CAN_BO_DOT_KHAM_BENH values('CB_01','07/05/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_02','07/08/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_03','07/05/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_04','07/08/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_05','07/05/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_06','07/08/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_07','07/05/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_08','07/08/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_09','07/05/2019');
insert into CAN_BO_DOT_KHAM_BENH values('CB_010','07/08/2019');

insert into CONG_VIEC values('CV01',N'Khám Bệnh');
insert into CONG_VIEC values('CV02',N'Phát thức ăn');
insert into CONG_VIEC values('CV03',N'Tiếp nhận tù nhân');

insert into CAN_BO_CONG_VIEC values('CB_02','CV01');
insert into CAN_BO_CONG_VIEC values('CB_08','CV01');
insert into CAN_BO_CONG_VIEC values('CB_04','CV02');
insert into CAN_BO_CONG_VIEC values('CB_010','CV02');
insert into CAN_BO_CONG_VIEC values('CB_03','CV03');
insert into CAN_BO_CONG_VIEC values('CB_09','CV03');

insert into CA_TRUC values('2','08:00:00','05:00:00');
insert into CA_TRUC values('4','08:00:00','05:00:00');
insert into CA_TRUC values('6','08:00:00','05:00:00');
insert into CA_TRUC values('3','08:00:00','05:00:00');
insert into CA_TRUC values('5','08:00:00','05:00:00');
insert into CA_TRUC values('7','08:00:00','05:00:00');
insert into CA_TRUC values('8','08:00:00','05:00:00');

insert into BO_PHAN_CA_TRUC values('BP01','2','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP02','4','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP03','6','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP04','3','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP05','5','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP06','7','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP01','8','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP02','2','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP03','3','08:00:00','05:00:00');
insert into BO_PHAN_CA_TRUC values('BP04','4','08:00:00','05:00:00');
