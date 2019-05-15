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

