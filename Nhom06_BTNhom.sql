USE [master]
GO
/****** Object:  Database [QuanLyBanHang]    Script Date: 05/06/2019 3:48:18 CH ******/
CREATE DATABASE [QuanLyBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyBanHang.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyBanHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyBanHang_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyBanHang] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[CTPhieuNhap]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPhieuNhap](
	[MaPN] [int] NOT NULL,
	[MaHH] [int] NOT NULL,
	[SoLuong] [float] NOT NULL,
	[GiaNhap] [float] NOT NULL,
 CONSTRAINT [PK_CTPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTHoaDon]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDon](
	[MaHD] [int] NOT NULL,
	[MaHH] [int] NOT NULL,
	[SoLuong] [float] NOT NULL,
	[GiaBan] [float] NOT NULL,
 CONSTRAINT [PK_CTHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHH] [int] NOT NULL,
	[TenHH] [nvarchar](200) NOT NULL,
	[DonViTinh] [nvarchar](50) NOT NULL,
	[GiaNhap] [float] NOT NULL,
	[GiaBan] [float] NOT NULL,
	[SoLuongTon] [float] NOT NULL,
	[MaNH] [int] NOT NULL,
 CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayBan] [datetime] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] NOT NULL,
	[TenKH] [nvarchar](200) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoai] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] NOT NULL,
	[TenNCC] [nvarchar](200) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoai] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] NOT NULL,
	[TenNV] [nvarchar](200) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoai] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhomHang]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomHang](
	[MaNH] [int] NOT NULL,
	[TenNH] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_NhomHang] PRIMARY KEY CLUSTERED 
(
	[MaNH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [int] NOT NULL,
	[MaNCC] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaNV] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CTPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuNhap_HangHoa] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[CTPhieuNhap] CHECK CONSTRAINT [FK_CTPhieuNhap_HangHoa]
GO
ALTER TABLE [dbo].[CTPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuNhap_PhieuNhap] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[CTPhieuNhap] CHECK CONSTRAINT [FK_CTPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[CTHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDon_HangHoa] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[CTHoaDon] CHECK CONSTRAINT [FK_CTHoaDon_HangHoa]
GO
ALTER TABLE [dbo].[CTHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDon_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[CTHoaDon] CHECK CONSTRAINT [FK_CTHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_NhomHang] FOREIGN KEY([MaNH])
REFERENCES [dbo].[NhomHang] ([MaNH])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_NhomHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO

SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[V_CTPhieuNhap]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[V_CTPhieuNhap] As
select 
PhieuNhap.MaPN, 
NhaCungCap.MaNCC, 
NhaCungCap.TenNCC, 
NhanVien.MaNV,
NhanVien.TenNV, 
NgayNhap,
dbo.HangHoa.MaHH,
TenHH,
SoLuong,
DonViTinh,
CTPhieuNhap.GiaNhap,
(CTPhieuNhap.SoLuong* CTPhieuNhap.GiaNhap) as ThanhTien,
NhomHang.MaNH,
TenNH
from PhieuNhap, NhaCungCap, NhanVien, HangHoa, NhomHang , CTPhieuNhap
where PhieuNhap.MaPN=CTPhieuNhap.MaPN
and CTPhieuNhap.MaHH=HangHoa.MaHH
and HangHoa.MaNH=NhomHang.MaNH
AND NhaCungCap.MaNCC = PhieuNhap.MaNCC
AND NhanVien.MaNV = PhieuNhap.MaNV


GO
/****** Object:  View [dbo].[V_CTHoaDon]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[V_CTHoaDon] As
select 
HoaDon.MaHD, 
KhachHang.MaKH, 
KhachHang.TenKH, 
NhanVien.MaNV,
NhanVien.TenNV, 
NgayBan,
dbo.HangHoa.MaHH,
TenHH,
SoLuong,
DonViTinh,
CTHoaDon.GiaBan,
(CTHoaDon.SoLuong* CTHoaDon.GiaBan) as ThanhTien,
NhomHang.MaNH,
TenNH
from HoaDon, KhachHang, NhanVien, HangHoa, NhomHang , CTHoaDon
where HoaDon.MaHD=CTHoaDon.MaHD
and CTHoaDon.MaHH=HangHoa.MaHH
and HangHoa.MaNH=NhomHang.MaNH
AND KhachHang.MaKH = HoaDon.MaKH
AND NhanVien.MaNV = HoaDon.MaNV


GO
/****** Object:  View [dbo].[V_HoaDon]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[V_HoaDon] AS
select HoaDon.MaHD, HoaDon.MaKH, TenKH, HoaDon.MaNV, TenNV, NgayBan, sum( CTHoaDon.SoLuong * CTHoaDon.GiaBan) AS ThanhTien
from HoaDon, KhachHang, NhanVien, CTHoaDon
where HoaDon.MaHD= CTHoaDon.MaHD
and KhachHang.MaKH=HoaDon.MaKH
and NhanVien.MaNV=HoaDon.MaNV 
group by HoaDon.MaHD, HoaDon.MaKH, TenKH, HoaDon.MaNV, TenNV, NgayBan


GO
/****** Object:  View [dbo].[V_PhieuNhap]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[V_PhieuNhap] AS
select PhieuNhap.MaPN, PhieuNhap.MaNCC, TenNCC, PhieuNhap.MaNV, TenNV, NgayNhap, sum(CTPhieuNhap.SoLuong* CTPhieuNhap.GiaNhap) as ThanhTien
from PhieuNhap, NhaCungCap, NhanVien, CTPhieuNhap
where PhieuNhap.MaPN=CTPhieuNhap.MaPN
and NhanVien.MaNV= PhieuNhap.MaNV
and NhaCungCap.MaNCC=PhieuNhap.MaNCC 
group by PhieuNhap.MaPN, PhieuNhap.MaNCC, TenNCC, PhieuNhap.MaNV, TenNV, NgayNhap


GO


CREATE TRIGGER T_ThemCTPN ON dbo.CTPhieuNhap FOR INSERT
AS
BEGIN
	UPDATE dbo.HangHoa SET SoLuongTon = SoLuongTon + SoLuong FROM Inserted WHERE HangHoa.MaHH = Inserted.MaHH
END
GO

CREATE TRIGGER T_XoaCTPN ON dbo.CTPhieuNhap FOR DELETE
AS
BEGIN
	UPDATE dbo.HangHoa SET SoLuongTon = SoLuongTon - SoLuong FROM Deleted WHERE HangHoa.MaHH = Deleted.MaHH
END
GO

CREATE TRIGGER T_ThemCTHD ON dbo.CTHoaDon FOR INSERT
AS
BEGIN
	UPDATE dbo.HangHoa SET SoLuongTon = SoLuongTon - SoLuong FROM Inserted WHERE HangHoa.MaHH = Inserted.MaHH
END
GO

CREATE TRIGGER T_XoaCTHD ON dbo.CTHoaDon FOR DELETE
AS
BEGIN
	UPDATE dbo.HangHoa SET SoLuongTon = SoLuongTon + SoLuong FROM Deleted WHERE HangHoa.MaHH = Deleted.MaHH
END
GO



/****** Object:  StoredProcedure [dbo].[SP_LayMaHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaHD]
AS BEGIN
	SELECT MAX(MaHD)+1 FROM dbo.HoaDon
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_LayMaHH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaHH]
AS BEGIN
	SELECT MAX(MaHH)+1 FROM dbo.HangHoa
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_LayMaKH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaKH]
AS BEGIN
	SELECT MAX(MaKH)+1 FROM dbo.KhachHang
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_LayMaNCC]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaNCC]
AS BEGIN
	SELECT MAX(MaNCC)+1 FROM dbo.NhaCungCap
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_LayMaNV]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaNV]
AS BEGIN
	SELECT MAX(MaNV)+1 FROM dbo.NhanVien
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_LayMaNH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaNH]
AS BEGIN
	SELECT MAX(MaNH)+1 FROM dbo.NhomHang
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_LayMaPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayMaPN]
AS BEGIN
	SELECT MAX(MaPN)+1  FROM dbo.PhieuNhap
   END


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaCTPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaCTPN]
@MaPN int, @MaHH int, @SoLuong float, @GiaNhap float
as begin
update CTPhieuNhap
set  SoLuong=@SoLuong, GiaNhap=@GiaNhap
where CTPhieuNhap.MaHH=@MaHH
and CTPhieuNhap.MaPN=@MaPN
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaCTHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaCTHD]
@MaHD int, @MaHH int, @SoLuong float, @GiaBan float
as begin
update dbo.CTHoaDon
set  SoLuong=@SoLuong, GiaBan=@GiaBan
where CTHoaDon.MaHH=@MaHH
and CTHoaDon.MaHD=@MaHD
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaHD]
@MaHD int,  @MaKH int, @MaNV INT,@NgayBan datetime
as begin
update HoaDon
set  NgayBan=@NgayBan, MaKH=@MaKH, MaNV=@MaNV
where dbo.HoaDon.MaHD=@MaHD
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaHH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaHH]
@MaHH int, @TenHH nvarchar(200), @DonViTinh nvarchar(50), @GiaNhap FLOAT, @GiaBan float, @SoLuongTon float, @MaNH int
as begin 
update HangHoa
set TenHH=@TenHH, DonViTinh=@DonViTinh, GiaNhap = @GiaNhap, GiaBan=@GiaBan, SoLuongTon=@SoLuongTon, MaNH=@MaNH 
where HangHoa.MaHH=@MaHH
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaKH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaKH] 
@MaKH int, @TenKH nvarchar(200), @DiaChi nvarchar(200), @SoDienThoai varchar(50), @Email varchar(200)
as begin
update KhachHang
set  TenKH=@TenKH, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai, Email=@Email
where KhachHang.MaKH=@MaKH
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaNCC]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaNCC]
@MaNCC int, @TenNCC nvarchar(200), @DiaChi nvarchar(200), @SoDienThoai varchar(50), @Email varchar(200)
as begin
update NhaCungCap
set TenNCC=@TenNCC, Email=@Email, SoDienThoai=@SoDienThoai, DiaChi=@DiaChi
where NhaCungCap.MaNCC=@MaNCC
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaNV]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaNV]
@MaNV int, @TenNV nvarchar(200), @DiaChi nvarchar(200), @SoDienThoai varchar(50),@Email varchar(200)
as begin
update NhanVien
set  TenNV=@TenNV, DiaChi=@DiaChi, Email=@Email, SoDienThoai=@SoDienThoai
where NhanVien.MaNV=@MaNV
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaNH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaNH]
@MaNH int, @TenNH nvarchar(200)
as begin
update NhomHang
set TenNH=@TenNH
where NhomHang.MaNH=@MaNH
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaPN]
@MaPN int, @MaNCC INT,  @MaNV int,@NgayNhap datetime
as begin
update dbo.PhieuNhap
set NgayNhap=@NgayNhap, MaNV=@MaNV, MaNCC=@MaNCC
where PhieuNhap.MaPN=@MaPN
end


GO
/****** Object:  StoredProcedure [dbo].[SP_SuaTK]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SuaTK]
@MaNV int, @UserName varchar(50), @PassWord nvarchar(50), @Type int
as begin
update TaiKhoan
set  UserName=@UserName, PassWord=@PassWord, Type=@Type
where TaiKhoan.MaNV=@MaNV
end


GO
/****** Object:  StoredProcedure [dbo].[SP_TimCTPN_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimCTPN_ma](@maPN INT)
AS 
( SELECT * FROM dbo.V_CTPhieuNhap WHERE MaPN = @maPN)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimCTPN_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimCTPN_mix](@tenNV NVARCHAR(200), @tenNCC NVARCHAR(200), @tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	IF	(@tenNV = '' AND @tenNCC = '')
		SELECT * FROM dbo.V_CTPhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay
    ELSE IF (@tenNV = '')
		SELECT * FROM dbo.V_CTPhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay AND TenNCC LIKE '%' + @tenNCC + '%'
    ELSE IF (@tenNCC = '')
		SELECT * FROM dbo.V_CTPhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay AND TenNV LIKE '%' + @tenNV + '%'
    ELSE
		SELECT * FROM dbo.V_CTPhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay AND TenNCC LIKE '%' + @tenNCC + '%' AND TenNV LIKE '%' + @tenNV + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[SP_TimCTHD_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimCTHD_ma](@maHD INT)
AS 
( SELECT * FROM dbo.V_CTHoaDon WHERE MaHD = @maHD)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimCTHD_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimCTHD_mix](@tenNV NVARCHAR(200), @tenKH NVARCHAR(200), @tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	IF	(@tenNV = '' AND @tenKH = '')
		SELECT * FROM dbo.V_CTHoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
    ELSE IF (@tenNV = '')
		SELECT * FROM dbo.V_CTHoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay AND TenKH LIKE '%' + @tenKH + '%'
    ELSE IF (@tenKH = '')
		SELECT * FROM dbo.V_CTHoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay AND TenNV LIKE '%' + @tenNV + '%'
    ELSE
		SELECT * FROM dbo.V_CTHoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay AND TenKH LIKE '%' + @tenKH + '%' AND TenNV LIKE '%' + @tenNV + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[SP_TimHD_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimHD_ma](@maHD INT)
AS 
( SELECT * FROM dbo.V_HoaDon WHERE MaHD = @maHD)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimHD_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimHD_mix](@tenNV NVARCHAR(200), @tenKH NVARCHAR(200), @tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	IF	(@tenNV = '' AND @tenKH = '')
		SELECT * FROM dbo.V_HoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
    ELSE IF (@tenNV = '')
		SELECT * FROM dbo.V_HoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay AND TenKH LIKE '%' + @tenKH + '%'
    ELSE IF (@tenKH = '')
		SELECT * FROM dbo.V_HoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay AND TenNV LIKE '%' + @tenNV + '%'
    ELSE
		SELECT * FROM dbo.V_HoaDon
		WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay AND TenKH LIKE '%' + @tenKH + '%' AND TenNV LIKE '%' + @tenNV + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[SP_TimHH_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimHH_ma](@MaHH int)
as
(SELECT MaHH, TenHH, DonViTinh, GiaNhap, GiaBan, SoLuongTon, HangHoa.MaNH, TenNH from HangHoa, NhomHang
where HangHoa.MaHH=@MaHH AND HangHoa.MaNH = NhomHang.MaNH)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimHH_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimHH_mix](@first NVARCHAR(200), @second NVARCHAR(200))
AS
SELECT MaHH, TenHH, DonViTinh, GiaNhap, GiaBan, SoLuongTon, HangHoa.MaNH, TenNH FROM HangHoa, NhomHang
where (HangHoa.TenHH like '%'+@first+'%' AND TenHH LIKE '%'+@second+'%') AND HangHoa.MaNH = NhomHang.MaNH


GO
/****** Object:  StoredProcedure [dbo].[SP_TimHH_ten]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimHH_ten]( @TenHH nvarchar(200))
as
(SELECT MaHH, TenHH, DonViTinh,GiaNhap, GiaBan, SoLuongTon, HangHoa.MaNH, TenNH FROM HangHoa, NhomHang
where HangHoa.TenHH like '%'+@TenHH+'%' AND HangHoa.MaNH = NhomHang.MaNH)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimKH_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimKH_ma]( @MaKH int)
as
(select*from KhachHang
where KhachHang.MaKH=@MaKH)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimKH_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimKH_mix](@first NVARCHAR(200), @second NVARCHAR(200))
AS
SELECT * FROM dbo.KhachHang WHERE TenKH LIKE '%'+@first+'%' AND TenKH LIKE '%'+@second+'%'


GO
/****** Object:  StoredProcedure [dbo].[SP_TimKH_ten]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimKH_ten] (@TenKH nvarchar(200))
as
( select*from KhachHang
where KhachHang.TenKH like '%'+@TenKH+'%')


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNCC_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNCC_ma] (@MaNCC int)
as 
( select*from NhaCungCap
where NhaCungCap.MaNCC=@MaNCC)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNCC_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNCC_mix](@first NVARCHAR(200), @second NVARCHAR(200))
AS
SELECT * FROM dbo.NhaCungCap WHERE TenNCC LIKE '%'+@first+'%' AND TenNCC LIKE '%'+@second+'%'


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNCC_ten]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNCC_ten]( @TenNCC nvarchar(200))
as 
(select*from NhaCungCap 
where NhaCungCap.TenNCC like '%'+@TenNCC+'%')


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNV_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNV_ma](@MaNV int)
as
(select*from NhanVien 
WHERE NhanVien.MaNV=@MaNV)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNV_noaccount]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_TimNV_noaccount]
AS
SELECT * FROM dbo.NhanVien WHERE MaNV NOT IN (SELECT MaNV FROM dbo.TaiKhoan)

GO
/****** Object:  StoredProcedure [dbo].[SP_TimNV_ten]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNV_ten](@TenNV nvarchar(200))
as 
(select*from NhanVien 
WHERE NhanVien.TenNV like '%'+@TenNV+'%'
)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNH_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNH_ma]( @MaNH int)
as 
 (
select*from NhomHang
where NhomHang.MaNH=@MaNH)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimNH_ten]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimNH_ten](@TenNH nvarchar(200))
as
(select*from NhomHang 
WHERE NhomHang.TenNH like '%'+@TenNH+'%'
)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimPN_ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimPN_ma](@maPN INT)
AS 
( SELECT * FROM dbo.V_PhieuNhap WHERE MaPN = @maPN)


GO
/****** Object:  StoredProcedure [dbo].[SP_TimPN_mix]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimPN_mix](@tenNV NVARCHAR(200), @tenNCC NVARCHAR(200), @tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	IF	(@tenNV = '' AND @tenNCC = '')
		SELECT * FROM dbo.V_PhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay
    ELSE IF (@tenNV = '')
		SELECT * FROM dbo.V_PhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay AND TenNCC LIKE '%' + @tenNCC + '%'
    ELSE IF (@tenNCC = '')
		SELECT * FROM dbo.V_PhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay AND TenNV LIKE '%' + @tenNV + '%'
    ELSE
		SELECT * FROM dbo.V_PhieuNhap
		WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay AND TenNCC LIKE '%' + @tenNCC + '%' AND TenNV LIKE '%' + @tenNV + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[SP_TimTK_likeuser]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimTK_likeuser](@UserName VARCHAR(50))
AS
SELECT * FROM dbo.TaiKhoan WHERE UserName LIKE '%' + @UserName + '%'


GO
/****** Object:  StoredProcedure [dbo].[SP_TimTK_user]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TimTK_user](@UserName varchar(50))
as
(select*from TaiKhoan 
WHERE TaiKhoan.UserName=@UserName)


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemCTPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemCTPN]
@MaPN int, @MaHH int, @SoLuong float, @GiaNhap float
as begin
insert into CTPhieuNhap(MaPN,MaHH,SoLuong,GiaNhap)
values (@MaPN,@MaHH,@SoLuong,@GiaNhap)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemCTHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemCTHD]
@MaHD int, @MaHH int, @SoLuong float, @GiaBan float
as begin
insert into CTHoaDon(MaHD,MaHH,SoLuong,GiaBan)
values( @MaHD,@MaHH,@SoLuong,@GiaBan)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemHD]
@MaHD int, @MaKH INT,  @MaNV int,@NgayBan datetime
as begin
insert into HoaDon(MaHD,MaKH,MaNV,NgayBan)
values ( @MaHD,@MaKH,@MaNV,@NgayBan)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemHH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemHH]
@MaHH int, @TenHH nvarchar(200), @DonViTinh nvarchar(50), @GiaNhap FLOAT, @GiaBan float, @SoLuongTon float, @MaNH int
as begin 
insert into dbo.HangHoa(MaHH,TenHH,DonViTinh, GiaNhap, GiaBan,SoLuongTon,MaNH)
values (@MaHH,@TenHH,@DonViTinh,@GiaNhap,@GiaBan,@SoLuongTon,@MaNH)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemKH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemKH]
@MaKH int, @TenKH nvarchar(200), @DiaChi nvarchar(200), @SoDienThoai varchar(50), @Email varchar(200)
as begin
insert into KhachHang(MaKH,TenKH,DiaChi,SoDienThoai,Email)
values(@MaKH,@TenKH,@DiaChi,@SoDienThoai,@Email)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemNCC]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemNCC]
@MaNCC int, @TenNCC nvarchar(200), @DiaChi nvarchar(200), @SoDienThoai varchar(50), @Email varchar(200)
as begin
insert into dbo.NhaCungCap (MaNCC, TenNCC, Email,SoDienThoai, DiaChi)
values (@MaNCC, @TenNCC, @Email, @SoDienThoai, @DiaChi)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemNV]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemNV] 
@MaNV int, @TenNV nvarchar(200), @DiaChi nvarchar(200), @SoDienThoai varchar(50),@Email varchar(200)
as begin
insert into NhanVien(MaNV,TenNV,DiaChi,SoDienThoai,Email)
values (@MaNV,@TenNV,@DiaChi,@SoDienThoai,@Email)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemNH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemNH]
@MaNH int, @TenNH nvarchar(200)
as begin
insert into NhomHang(MaNH,TenNH)
values(@MaNH,@TenNH)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemPN]
@MaPN int, @MaNCC int, @MaNV INT, @NgayNhap datetime
as begin
insert into dbo.PhieuNhap(MaPN,NgayNhap, MaNCC,MaNV)
values (@MaPN,@NgayNhap,@MaNCC,@MaNV)

end


GO
/****** Object:  StoredProcedure [dbo].[SP_ThemTK]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemTK]
@MaNV int, @UserName varchar(50), @PassWord nvarchar(50), @Type int
as begin
insert into TaiKhoan(MaNV,UserName,PassWord,Type)
values( @MaNV,@UserName,@PassWord,@Type)
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaCTPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaCTPN]
@MaPN int, @MaHH int
as begin 
delete from CTPhieuNhap
where CTPhieuNhap.MaHH=@MaHH
and CTPhieuNhap.MaPN=@MaPN
end 


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaCTPN_1ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_XoaCTPN_1ma](@maPN INT)
AS BEGIN 
	DELETE FROM dbo.CTPhieuNhap WHERE MaPN = @maPN 
END


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaCTHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaCTHD]
@MaHD int, @MaHH int
as begin 
delete from CTHoaDon
where CTHoaDon.MaHD=@MaHD
and CTHoaDon.MaHH=@MaHH
end  


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaCTHD_1ma]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_XoaCTHD_1ma](@maHD INT)
AS BEGIN
	DELETE FROM dbo.CTHoaDon WHERE MaHD = @maHD
END


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaHD]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaHD]
@MaHD int
as begin 
delete from HoaDon
where HoaDon.MaHD=@MaHD
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaHH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaHH]
@MaHH int
as begin 
delete from HangHoa
where HangHoa.MaHH=@MaHH
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaKH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaKH]
@MaKH int
as begin 
delete from KhachHang
where KhachHang.MaKH=@MaKH
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaNCC]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaNCC]
@MaNCC int
as begin 
delete from NhaCungCap
where NhaCungCap.MaNCC=@MaNCC
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaNV]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaNV]
@MaNV int
as begin 
delete from NhanVien
where NhanVien.MaNV=@MaNV
end 


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaNH]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaNH]
@MaNH int
as begin 
delete from NhomHang
where NhomHang.MaNH=@MaNH
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaPN]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaPN]
@MaPN int
as begin
delete from PhieuNhap
where PhieuNhap.MaPN=@MaPN
end


GO
/****** Object:  StoredProcedure [dbo].[SP_XoaTK]    Script Date: 05/06/2019 3:48:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_XoaTK]
@MaNV int
as begin 
delete from TaiKhoan
where TaiKhoan.MaNV=@MaNV
end 


GO

CREATE PROC SP_BCDoanhThu_nhanvien(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		MaNV AS 'ma',
		TenNV AS 'ten',
		SUM(ThanhTien) AS 'tongTien'
	FROM dbo.V_CTHoaDon
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
	GROUP BY MaNV, TenNV
END
GO

CREATE PROC SP_BCDoanhThu_khachhang(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		MaKH AS 'ma',
		TenKH AS 'ten',
		SUM(ThanhTien) AS 'tongTien'
	FROM dbo.V_CTHoaDon
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
	GROUP BY MaKH, TenKH
END
GO

CREATE PROC SP_BCDoanhThu_hanghoa(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		MaHH AS 'ma',
		TenHH AS 'ten',
		SUM(ThanhTien) AS 'tongTien'
	FROM dbo.V_CTHoaDon
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
	GROUP BY MaHH, TenHH
END
GO

CREATE PROC SP_BCDoanhThu_nhomhang(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		MaNH AS 'ma',
		TenNH AS 'ten',
		SUM(ThanhTien) AS 'tongTien'
	FROM dbo.V_CTHoaDon
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
	GROUP BY MaNH, TenNH
END
GO

CREATE PROC SP_BCChiPhi_nhacungcap(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		MaNCC AS 'ma',
		TenNCC AS 'ten',
		SUM(ThanhTien) AS 'tongTien'
	FROM dbo.V_PhieuNhap
	WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay
	GROUP BY MaNCC, TenNCC
END
GO

CREATE PROC SP_BCLoiNhuan_hanghoa(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		V_CTHoaDon.MaHH AS 'ma',
		V_CTHoaDon.TenHH AS 'ten',
		SUM((V_CTHoaDon.GiaBan-GiaNhap)*SoLuong) AS 'tongTien'
	FROM dbo.V_CTHoaDon LEFT JOIN dbo.HangHoa ON HangHoa.MaHH = V_CTHoaDon.MaHH
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
	GROUP BY V_CTHoaDon.MaHH, V_CTHoaDon.TenHH
END
GO

CREATE PROC SP_BCLoiNhuan_nhomhang(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT
		V_CTHoaDon.MaNH AS 'ma',
		V_CTHoaDon.TenNH AS 'ten',
		SUM((V_CTHoaDon.GiaBan-GiaNhap)*SoLuong) AS 'tongTien'
	FROM dbo.V_CTHoaDon LEFT JOIN dbo.HangHoa ON HangHoa.MaNH = V_CTHoaDon.MaNH
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
	GROUP BY V_CTHoaDon.MaNH, V_CTHoaDon.TenNH
END
GO

CREATE PROC SP_TongDoanhThu(@tuNgay DATETIME, @denNgay DATETIME)
AS
SELECT SUM(ThanhTien) FROM dbo.V_CTHoaDon WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
GO

CREATE PROC SP_TongChiPhi(@tuNgay DATETIME, @denNgay DATETIME)
AS
SELECT SUM(ThanhTien) FROM dbo.V_CTPhieuNhap WHERE @tuNgay <= NgayNhap AND NgayNhap <= @denNgay
GO

CREATE PROC SP_TongLoiNhuan(@tuNgay DATETIME, @denNgay DATETIME)
AS
BEGIN
	SELECT SUM((V_CTHoaDon.GiaBan-GiaNhap)*SoLuong)
	FROM dbo.V_CTHoaDon LEFT JOIN dbo.HangHoa ON HangHoa.MaNH = V_CTHoaDon.MaNH
	WHERE @tuNgay <= NgayBan AND NgayBan <= @denNgay
END
GO 






INSERT INTO dbo.NhanVien VALUES(1,N'Admin', N'', '', N'')
INSERT INTO dbo.NhanVien VALUES(2,N'Nguyễn Xuân Đồng', N'Hà Nội', '968083620', N'dong@gmail.com')
INSERT INTO dbo.NhanVien VALUES(3,N'Lê Thành Trung', N'Đà Nẵng', '960672278', N'trung@hotmail.com')
INSERT INTO dbo.NhanVien VALUES(4,N'Phạm Thúy Kiều', N'Hồ Chí Minh', '976177825', N'thuykieu@icloud.com')
INSERT INTO dbo.NhanVien VALUES(5,N'Lê Thị Vân', N'Hải Phòng', '964565110', N'levan@live.com')
INSERT INTO dbo.NhanVien VALUES(6,N'Nguyễn Hoàng Hải', N'Đà Lạt', '968865669', N'nguyenhoang@hust.mail.com')

INSERT INTO dbo.NhaCungCap VALUES(1, N'Tổng đại lý', N'', '', N'')
INSERT INTO dbo.NhaCungCap VALUES(2, N'Công ty gạo Hoa Lúa', N'Hà Nội', '948392005', N'')
INSERT INTO dbo.NhaCungCap VALUES(3, N'Hải sản Phú Quốc', N'Phú Quốc', '973528146', N'')
INSERT INTO dbo.NhaCungCap VALUES(4, N'Nước mắm Thanh Hà', N'Phú Quốc', '961548732', N'')
INSERT INTO dbo.NhaCungCap VALUES(5, N'Công ty TNHH Thành Việt', N'Hà Nội', '976676041', N'')
INSERT INTO dbo.NhaCungCap VALUES(6, N'Hoa quả Hải Dương', N'Hải Dương', '968069558', N'')
INSERT INTO dbo.NhaCungCap VALUES(7, N'Hoa quả Hưng Yên', N'Hưng Yên', '982755345', N'')
INSERT INTO dbo.NhaCungCap VALUES(8, N'Hoa quả Thanh Hưng', N'Hưng Yên', '948665890', N'')
INSERT INTO dbo.NhaCungCap VALUES(9, N'Rau Sóc Sơn', N'Sóc Sơn', '979696682', N'')
INSERT INTO dbo.NhaCungCap VALUES(10, N'Rau Hải Hiền', N'Ba Vì', '980182843', N'')
INSERT INTO dbo.NhaCungCap VALUES(11, N'Vườn rau Gia Thịnh', N'Hưng Yên', '952837564', N'')
INSERT INTO dbo.NhaCungCap VALUES(12, N'Nước mắm Phú Quốc', N'Phú Quốc', '986193211', N'')
INSERT INTO dbo.NhaCungCap VALUES(13, N'Gạo Nam Định', N'Nam Định', '975849438', N'')
INSERT INTO dbo.NhaCungCap VALUES(14, N'Thịt lợn Trường Hải', N'Hà Nội', '960328588', N'')
INSERT INTO dbo.NhaCungCap VALUES(15, N'Thịt lợn Đông Hưng', N'Hà Nội', '967520111', N'')
INSERT INTO dbo.NhaCungCap VALUES(16, N'Thịt lợn Rasa', N'Hà Nội', '972463806', N'')
INSERT INTO dbo.NhaCungCap VALUES(17, N'Hải sản Thanh Hóa', N'Thanh Hóa', '964790842', N'')
INSERT INTO dbo.NhaCungCap VALUES(18, N'Đặc sản Yên Bái', N'Yên Bái', '959341683', N'')
INSERT INTO dbo.NhaCungCap VALUES(19, N'Công ty xuất nhập khẩu Đông Thành', N'Hà Nội', '957719560', N'')


INSERT INTO dbo.KhachHang VALUES(1, N'Khách lẻ', N'', '', N'')
INSERT INTO dbo.KhachHang VALUES(2, N'Chị Dịu', N'', '952129537', N'')
INSERT INTO dbo.KhachHang VALUES(3, N'Chị Mai', N'', '953091579', N'')
INSERT INTO dbo.KhachHang VALUES(4, N'Chị Bình', N'', '960265068', N'')
INSERT INTO dbo.KhachHang VALUES(5, N'Anh Lâm', N'', '973034313', N'')
INSERT INTO dbo.KhachHang VALUES(6, N'Chị Bích', N'', '959666135', N'')
INSERT INTO dbo.KhachHang VALUES(7, N'Chị Yến', N'', '984191565', N'')
INSERT INTO dbo.KhachHang VALUES(8, N'Cô THủy', N'', '987739154', N'')
INSERT INTO dbo.KhachHang VALUES(9, N'Cô Hà', N'', '974189529', N'')
INSERT INTO dbo.KhachHang VALUES(10, N'Chú Sơn', N'', '972368821', N'')
INSERT INTO dbo.KhachHang VALUES(11, N'cô Diệp', N'', '983594049', N'')
INSERT INTO dbo.KhachHang VALUES(12, N'Chị Phương Anh', N'', '969906903', N'')
INSERT INTO dbo.KhachHang VALUES(13, N'Chị Lan', N'', '989168487', N'')
INSERT INTO dbo.KhachHang VALUES(14, N'Chị Bình', N'', '976596683', N'')
INSERT INTO dbo.KhachHang VALUES(15, N'Chị Huyền', N'', '969961629', N'')
INSERT INTO dbo.KhachHang VALUES(16, N'Chị Thảo', N'', '956690595', N'')
INSERT INTO dbo.KhachHang VALUES(17, N'Chị Hà', N'', '988292615', N'')
INSERT INTO dbo.KhachHang VALUES(18, N'Chị Ngọc', N'', '954486479', N'')
INSERT INTO dbo.KhachHang VALUES(19, N'Chị Hồng Anh', N'', '979710999', N'')
INSERT INTO dbo.KhachHang VALUES(20, N'Chị Hà', N'', '964153380', N'')
INSERT INTO dbo.KhachHang VALUES(21, N'Lộc mx', N'', '971147942', N'')
INSERT INTO dbo.KhachHang VALUES(22, N'Chị THanh', N'', '957549177', N'')
INSERT INTO dbo.KhachHang VALUES(23, N'Chị Trang', N'', '983071169', N'')
INSERT INTO dbo.KhachHang VALUES(24, N'Cô Mỹ Hạnh', N'', '963694715', N'')
INSERT INTO dbo.KhachHang VALUES(25, N'Anh Đức', N'', '974095087', N'')
INSERT INTO dbo.KhachHang VALUES(26, N'Chị Lan', N'', '955176627', N'')
INSERT INTO dbo.KhachHang VALUES(27, N'Chị Loan', N'', '988061710', N'')
INSERT INTO dbo.KhachHang VALUES(28, N'Chị Nga', N'', '977581066', N'')
INSERT INTO dbo.KhachHang VALUES(29, N'Chị Thanh', N'', '949794258', N'')
INSERT INTO dbo.KhachHang VALUES(30, N'Chú Cường', N'', '979074228', N'')
INSERT INTO dbo.KhachHang VALUES(31, N'Cô Mậu', N'', '956749886', N'')
INSERT INTO dbo.KhachHang VALUES(32, N'Cô Sâm', N'', '974386311', N'')
INSERT INTO dbo.KhachHang VALUES(33, N'Chị Liên', N'', '976961405', N'')
INSERT INTO dbo.KhachHang VALUES(34, N'Chị Cúc', N'', '964809059', N'')
INSERT INTO dbo.KhachHang VALUES(35, N'Cô Mai', N'', '971840907', N'')
INSERT INTO dbo.KhachHang VALUES(36, N'Cô Nguyệt', N'', '963001384', N'')
INSERT INTO dbo.KhachHang VALUES(37, N'Chị Vy An', N'', '988616129', N'')
INSERT INTO dbo.KhachHang VALUES(38, N'Chị Thủy', N'', '958186302', N'')
INSERT INTO dbo.KhachHang VALUES(39, N'Chị Oanh', N'', '981152214', N'')
INSERT INTO dbo.KhachHang VALUES(40, N'Chị Nga', N'', '949649426', N'')
INSERT INTO dbo.KhachHang VALUES(41, N'Chị Hoa', N'', '950103103', N'')
INSERT INTO dbo.KhachHang VALUES(42, N'Chị Hảo', N'', '980846148', N'')
INSERT INTO dbo.KhachHang VALUES(43, N'Chị Nga', N'', '957767730', N'')
INSERT INTO dbo.KhachHang VALUES(44, N'Chị Oanh', N'', '965001747', N'')
INSERT INTO dbo.KhachHang VALUES(45, N'Chị Hường', N'', '963260143', N'')
INSERT INTO dbo.KhachHang VALUES(46, N'Cô Trâm', N'', '952513068', N'')
INSERT INTO dbo.KhachHang VALUES(47, N'Chị Phương Thanh', N'', '953118556', N'')
INSERT INTO dbo.KhachHang VALUES(48, N'Chị Hải Đường', N'', '969673748', N'')
INSERT INTO dbo.KhachHang VALUES(49, N'Chị Liên', N'', '972445695', N'')
INSERT INTO dbo.KhachHang VALUES(50, N'Chị Linh', N'', '959138273', N'')
INSERT INTO dbo.KhachHang VALUES(51, N'Chị Dung', N'', '967135961', N'')
INSERT INTO dbo.KhachHang VALUES(52, N'Chị Hà', N'', '973941968', N'')
INSERT INTO dbo.KhachHang VALUES(53, N'Chú Thắng', N'', '981922765', N'')


INSERT INTO dbo.NhomHang VALUES(1, N'Nhóm chung')
INSERT INTO dbo.NhomHang VALUES(2, N'Rau củ quả')
INSERT INTO dbo.NhomHang VALUES(3, N'Thịt các loại')
INSERT INTO dbo.NhomHang VALUES(4, N'Thủy hải sản')
INSERT INTO dbo.NhomHang VALUES(5, N'Đồ khô')
INSERT INTO dbo.NhomHang VALUES(6, N'Gia vị')


INSERT INTO dbo.HangHoa VALUES(2,N'Bắp Cải Trái Tim Đà Lạt',N'Kg',36000,40000,0,2)
INSERT INTO dbo.HangHoa VALUES(3,N'Cải Thảo Đà Lạt',N'Kg',25000,35000,0,2)
INSERT INTO dbo.HangHoa VALUES(4,N'Chanh dây Đà Lạt',N'Kg',40000,50000,0,2)
INSERT INTO dbo.HangHoa VALUES(5,N'Khoai Lang giống nhật',N'Kg',24000,45000,0,2)
INSERT INTO dbo.HangHoa VALUES(6,N'Quả Sake',N'Kg',28000,50000,0,2)
INSERT INTO dbo.HangHoa VALUES(7,N'Rau bò khai',N'Kg',55000,80000,0,2)
INSERT INTO dbo.HangHoa VALUES(8,N'Rau ngót rừng',N'Kg',74250,95000,0,2)
INSERT INTO dbo.HangHoa VALUES(9,N'Su hào Mộc Châu',N'Kg',10000,30000,0,2)
INSERT INTO dbo.HangHoa VALUES(10,N'Mướp Hương',N'Kg',22000,35000,0,2)
INSERT INTO dbo.HangHoa VALUES(11,N'Cà Tím',N'Kg',18000,50000,0,2)
INSERT INTO dbo.HangHoa VALUES(12,N'Sườn thăn lợn Thảo Dược',N'Kg',145800,167000,0,3)
INSERT INTO dbo.HangHoa VALUES(13,N'Ngan hữu cơ TT',N'Kg',100000,140000,0,3)
INSERT INTO dbo.HangHoa VALUES(14,N'Vai giòn lợn thảo dược',N'Kg',140400,156000,0,3)
INSERT INTO dbo.HangHoa VALUES(15,N'Ba chỉ lợn thảo dược',N'Kg',143100,164000,0,3)
INSERT INTO dbo.HangHoa VALUES(16,N'Gân thăn lợn thảo dược',N'Kg',124800,156000,0,3)
INSERT INTO dbo.HangHoa VALUES(17,N'Xương ống thảo dược',N'Kg',36400,52000,0,3)
INSERT INTO dbo.HangHoa VALUES(18,N'Nạc thăn thảo dược',N'Kg',124800,156000,0,3)
INSERT INTO dbo.HangHoa VALUES(19,N'Thịt chân giò thảo dược',N'Kg',119200,149000,0,3)
INSERT INTO dbo.HangHoa VALUES(20,N'Bắp giò thảo dược',N'Kg',148500,170000,0,3)
INSERT INTO dbo.HangHoa VALUES(21,N'Móng giò thảo dược',N'Kg',84000,105000,0,3)
INSERT INTO dbo.HangHoa VALUES(22,N'Xương cục thảo dược',N'Kg',63000,90000,0,3)
INSERT INTO dbo.HangHoa VALUES(23,N'Tim lợn thảo dược',N'Kg',241600,260000,0,3)
INSERT INTO dbo.HangHoa VALUES(24,N'Sườn vai thảo dược',N'Kg',123250,145000,0,3)
INSERT INTO dbo.HangHoa VALUES(25,N'Thăn bò ta',N'Kg',240000,310000,0,3)
INSERT INTO dbo.HangHoa VALUES(26,N'Diềm thăn bò ta',N'Kg',230000,290000,0,3)
INSERT INTO dbo.HangHoa VALUES(27,N'Cá diêu hồng',N'Kg',95000,120000,0,4)
INSERT INTO dbo.HangHoa VALUES(28,N'Tôm nõn khô PQ',N'Kg',760000,1029000,0,4)
INSERT INTO dbo.HangHoa VALUES(29,N'Tôm bóc nõn PQ',N'Kg',490000,680000,0,4)
INSERT INTO dbo.HangHoa VALUES(30,N'Tôm sú size 35 PQ',N'Kg',305000,440000,0,4)
INSERT INTO dbo.HangHoa VALUES(31,N'Cá thu tươi PQ',N'Kg',295000,390000,0,4)
INSERT INTO dbo.HangHoa VALUES(32,N'Mực lá PQ',N'Kg',305000,400000,0,4)
INSERT INTO dbo.HangHoa VALUES(33,N'Cá bống PQ',N'Kg',240000,300000,0,4)
INSERT INTO dbo.HangHoa VALUES(34,N'Nem hàu Bavabi',N'Khay',47000,60000,0,4)
INSERT INTO dbo.HangHoa VALUES(35,N'Cá cơm 200g Bavabi',N'Gói',28800,46000,0,4)
INSERT INTO dbo.HangHoa VALUES(36,N'Cá Thu Nướng NC',N'Kg',225000,295000,0,4)
INSERT INTO dbo.HangHoa VALUES(37,N'Đầu đuôi cá trắm đen size 4kg',N'Kg',115697,150000,0,4)
INSERT INTO dbo.HangHoa VALUES(38,N'Đầu cá hồi Nauy',N'Cái',55000,75000,0,4)
INSERT INTO dbo.HangHoa VALUES(39,N'Cá Trích PQ',N'Kg',180000,250000,0,4)
INSERT INTO dbo.HangHoa VALUES(40,N'Cá hồi Nauy',N'Kg',415000,580000,0,4)
INSERT INTO dbo.HangHoa VALUES(41,N'Tôm Rảo',N'Hộp',93000,107000,0,4)
INSERT INTO dbo.HangHoa VALUES(42,N'Đầu đuôi cá trắm trắng sông Đà',N'Kg',0,110000,0,4)
INSERT INTO dbo.HangHoa VALUES(43,N'Tôm Sú size 12',N'Kg',570000,800000,0,4)
INSERT INTO dbo.HangHoa VALUES(44,N'Ghẹ nõn PQ',N'Kg',670000,800000,0,4)
INSERT INTO dbo.HangHoa VALUES(45,N'Cá hồi Oganic fille',N'Kg',485000,690000,0,4)
INSERT INTO dbo.HangHoa VALUES(46,N'Cá chép Sông Đà làm sạch',N'Kg',100000,180000,0,4)
INSERT INTO dbo.HangHoa VALUES(47,N'Bề Bề HF 500g',N'Túi',150000,192000,0,4)
INSERT INTO dbo.HangHoa VALUES(48,N'Gạo sạch Hoa Lúa-Xanh 2kg',N'Gói',62050,73000,0,5)
INSERT INTO dbo.HangHoa VALUES(49,N'Gạo sạch Hoa Lúa-Xanh 5kg',N'Gói',150875,177500,0,5)
INSERT INTO dbo.HangHoa VALUES(50,N'Gạo sạch Hoa Lúa-Hồng 2kg',N'Gói',62050,73000,0,5)
INSERT INTO dbo.HangHoa VALUES(51,N'Gạo sạch Hoa Lúa-Hồng 5kg',N'Gói',150875,177500,0,5)
INSERT INTO dbo.HangHoa VALUES(52,N'Hạt vừng vàng 200g DNV',N'Gói',15000,21000,0,5)
INSERT INTO dbo.HangHoa VALUES(53,N'Hạt đỗ xanh nguyên hạt 200g DNV',N'Gói',9000,15000,0,5)
INSERT INTO dbo.HangHoa VALUES(54,N'Hạt đỗ xanh tách vỏ 200g DNV',N'Gói',10000,16000,0,5)
INSERT INTO dbo.HangHoa VALUES(55,N'Hạt đỗ xanh vỡ hạt 200g DNV',N'Gói',9500,15000,0,5)
INSERT INTO dbo.HangHoa VALUES(56,N'Hạt đỗ đen 200g DNV',N'Gói',13000,15000,0,5)
INSERT INTO dbo.HangHoa VALUES(57,N'Hạt đậu Hà Lan 250g DNV',N'Túi',22000,27000,0,5)
INSERT INTO dbo.HangHoa VALUES(58,N'Hạt đậu đỏ hạt nhỏ 200g DNV',N'Gói',9500,11000,0,5)
INSERT INTO dbo.HangHoa VALUES(59,N'Hạt đậu đỏ hạt to 200g DNV',N'Gói',8500,12000,0,5)
INSERT INTO dbo.HangHoa VALUES(60,N'Hạt sen bắc DNV',N'Túi',32000,43000,0,5)
INSERT INTO dbo.HangHoa VALUES(61,N'Hạt lạc đỏ Nghệ An 200g DNV',N'Gói',16000,20000,0,5)
INSERT INTO dbo.HangHoa VALUES(62,N'Hạt lạc chay Nghệ An 200g DNV',N'Gói',13500,18000,0,5)
INSERT INTO dbo.HangHoa VALUES(63,N'Hạt vừng vàng 100g DNV',N'Gói',8000,10000,0,5)
INSERT INTO dbo.HangHoa VALUES(64,N'Hạt vừng vàng tách vỏ 100g DNV',N'Gói',10000,13000,0,5)
INSERT INTO dbo.HangHoa VALUES(65,N'Nước mắm Thanh Hà 35gN/L',N'Chai',62320,80000,0,6)
INSERT INTO dbo.HangHoa VALUES(66,N'Nước mắm Thanh Hà 40gN/L',N'Chai',77995,102000,0,6)
INSERT INTO dbo.HangHoa VALUES(67,N'Đường tinh luyện Biên Hòa 800g',N'Hộp',24000,30000,0,6)
INSERT INTO dbo.HangHoa VALUES(68,N'Đường phèn Biên Hòa cao cấp hũ 450g',N'Hũ',30000,37000,0,6)
INSERT INTO dbo.HangHoa VALUES(69,N'Đường hữu cơ Biên Hòa',N'Gói',52000,59000,0,6)
INSERT INTO dbo.HangHoa VALUES(70,N'Muối khoáng biển 500g HF',N'Túi',29700,35000,0,6)
INSERT INTO dbo.HangHoa VALUES(71,N'Bột nấm củ quả 250g HF',N'Túi',44000,55000,0,6)
INSERT INTO dbo.HangHoa VALUES(72,N'Tiêu đen PQ xay nhuyễn',N'Lọ',53675,70000,0,6)
INSERT INTO dbo.HangHoa VALUES(73,N'Tiêu sọ PQ xay nhuyễn',N'Lọ',91200,117000,0,6)
INSERT INTO dbo.HangHoa VALUES(74,N'Tiêu đen PQ nguyên hạt',N'Lọ',51000,66000,0,6)
INSERT INTO dbo.HangHoa VALUES(75,N'Tiêu sọ PQ nguyên hạt',N'Lọ',87000,113000,0,6)
INSERT INTO dbo.HangHoa VALUES(76,N'Nước mắm chắt Ba Làng',N'Chai',60000,78000,0,6)
INSERT INTO dbo.HangHoa VALUES(77,N'Muối Hồng tiêu Phú Quốc',N'Lọ',19000,25000,0,6)
INSERT INTO dbo.HangHoa VALUES(78,N'Mướp đắng khô 100g AF',N'Gói',17900,23000,0,6)
INSERT INTO dbo.HangHoa VALUES(79,N'Hành lát sấy khô 60g AF',N'Gói',14300,18000,0,6)
INSERT INTO dbo.HangHoa VALUES(80,N'Tai chua 50g AF',N'Gói',10500,14000,0,6)
INSERT INTO dbo.HangHoa VALUES(81,N'Sốt mè rang',N'Chai',50500,55000,0,6)
INSERT INTO dbo.HangHoa VALUES(82,N'Dầu Đỗ tương 1 lít HY',N'Chai',70000,86000,0,6)
INSERT INTO dbo.HangHoa VALUES(83,N'Dầu lạc 1 lít HY',N'Chai',105000,130000,0,6)
INSERT INTO dbo.HangHoa VALUES(84,N'Dầu vừng đen 400ml HY',N'Chai',89000,105000,0,6)
INSERT INTO dbo.HangHoa VALUES(85,N'Dầu vừng đen 1 lít HY',N'Chai',200000,240000,0,6)
INSERT INTO dbo.HangHoa VALUES(86,N'Bột Nghệ 120g',N'Lọ',56000,70000,0,6)



INSERT INTO dbo.TaiKhoan VALUES(1,'Admin','Admin',1)
INSERT INTO dbo.TaiKhoan VALUES(2,'dong','dong',1)
INSERT INTO dbo.TaiKhoan VALUES(3,'trung','trung',0)


INSERT INTO dbo.PhieuNhap VALUES(1,2,4,43617)
INSERT INTO dbo.PhieuNhap VALUES(2,9,3,43618)
INSERT INTO dbo.PhieuNhap VALUES(3,14,4,43618)
INSERT INTO dbo.PhieuNhap VALUES(4,19,4,43619)
INSERT INTO dbo.PhieuNhap VALUES(5,17,4,43619)
INSERT INTO dbo.PhieuNhap VALUES(6,18,2,43620)
INSERT INTO dbo.PhieuNhap VALUES(7,12,3,43620)
INSERT INTO dbo.PhieuNhap VALUES(8,19,4,43621)
INSERT INTO dbo.PhieuNhap VALUES(9,5,6,43621)
INSERT INTO dbo.PhieuNhap VALUES(10,18,6,43622)
INSERT INTO dbo.PhieuNhap VALUES(11,11,5,43622)
INSERT INTO dbo.PhieuNhap VALUES(12,4,3,43623)
INSERT INTO dbo.PhieuNhap VALUES(13,11,5,43623)
INSERT INTO dbo.PhieuNhap VALUES(14,18,5,43624)
INSERT INTO dbo.PhieuNhap VALUES(15,14,2,43624)
INSERT INTO dbo.PhieuNhap VALUES(16,3,6,43625)
INSERT INTO dbo.PhieuNhap VALUES(17,2,2,43625)
INSERT INTO dbo.PhieuNhap VALUES(18,5,5,43626)
INSERT INTO dbo.PhieuNhap VALUES(19,6,3,43626)
INSERT INTO dbo.PhieuNhap VALUES(20,1,2,43627)
INSERT INTO dbo.PhieuNhap VALUES(21,4,2,43627)
INSERT INTO dbo.PhieuNhap VALUES(22,14,4,43628)
INSERT INTO dbo.PhieuNhap VALUES(23,18,6,43628)
INSERT INTO dbo.PhieuNhap VALUES(24,1,4,43629)
INSERT INTO dbo.PhieuNhap VALUES(25,13,3,43629)
INSERT INTO dbo.PhieuNhap VALUES(26,6,4,43630)
INSERT INTO dbo.PhieuNhap VALUES(27,13,4,43630)
INSERT INTO dbo.PhieuNhap VALUES(28,9,5,43631)
INSERT INTO dbo.PhieuNhap VALUES(29,11,2,43631)


INSERT INTO dbo.CTPhieuNhap VALUES(1,83,19,105000)
INSERT INTO dbo.CTPhieuNhap VALUES(2,4,15,40000)
INSERT INTO dbo.CTPhieuNhap VALUES(3,64,24,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(4,16,21,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(5,36,18,225000)
INSERT INTO dbo.CTPhieuNhap VALUES(6,20,25,148500)
INSERT INTO dbo.CTPhieuNhap VALUES(7,39,19,180000)
INSERT INTO dbo.CTPhieuNhap VALUES(8,24,19,123250)
INSERT INTO dbo.CTPhieuNhap VALUES(9,9,16,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(10,2,21,36000)
INSERT INTO dbo.CTPhieuNhap VALUES(11,52,21,15000)
INSERT INTO dbo.CTPhieuNhap VALUES(12,3,17,25000)
INSERT INTO dbo.CTPhieuNhap VALUES(13,64,18,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(14,8,20,74250)
INSERT INTO dbo.CTPhieuNhap VALUES(15,66,16,77995)
INSERT INTO dbo.CTPhieuNhap VALUES(16,57,19,22000)
INSERT INTO dbo.CTPhieuNhap VALUES(17,7,20,55000)
INSERT INTO dbo.CTPhieuNhap VALUES(18,82,17,70000)
INSERT INTO dbo.CTPhieuNhap VALUES(19,18,23,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(20,63,22,8000)
INSERT INTO dbo.CTPhieuNhap VALUES(21,66,21,77995)
INSERT INTO dbo.CTPhieuNhap VALUES(22,26,18,230000)
INSERT INTO dbo.CTPhieuNhap VALUES(23,58,20,9500)
INSERT INTO dbo.CTPhieuNhap VALUES(24,80,23,10500)
INSERT INTO dbo.CTPhieuNhap VALUES(25,64,17,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(26,46,21,100000)
INSERT INTO dbo.CTPhieuNhap VALUES(27,64,25,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(28,52,25,15000)
INSERT INTO dbo.CTPhieuNhap VALUES(29,29,20,490000)
INSERT INTO dbo.CTPhieuNhap VALUES(1,46,21,100000)
INSERT INTO dbo.CTPhieuNhap VALUES(2,11,18,18000)
INSERT INTO dbo.CTPhieuNhap VALUES(3,40,17,415000)
INSERT INTO dbo.CTPhieuNhap VALUES(4,31,18,295000)
INSERT INTO dbo.CTPhieuNhap VALUES(5,51,21,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(6,54,16,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(7,42,15,0)
INSERT INTO dbo.CTPhieuNhap VALUES(8,65,20,62320)
INSERT INTO dbo.CTPhieuNhap VALUES(9,58,15,9500)
INSERT INTO dbo.CTPhieuNhap VALUES(10,17,17,36400)
INSERT INTO dbo.CTPhieuNhap VALUES(11,42,19,0)
INSERT INTO dbo.CTPhieuNhap VALUES(12,8,24,74250)
INSERT INTO dbo.CTPhieuNhap VALUES(13,24,15,123250)
INSERT INTO dbo.CTPhieuNhap VALUES(14,18,25,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(15,48,15,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(16,6,25,28000)
INSERT INTO dbo.CTPhieuNhap VALUES(17,39,16,180000)
INSERT INTO dbo.CTPhieuNhap VALUES(18,27,16,95000)
INSERT INTO dbo.CTPhieuNhap VALUES(19,48,15,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(20,31,15,295000)
INSERT INTO dbo.CTPhieuNhap VALUES(21,85,23,200000)
INSERT INTO dbo.CTPhieuNhap VALUES(22,55,16,9500)
INSERT INTO dbo.CTPhieuNhap VALUES(23,35,21,28800)
INSERT INTO dbo.CTPhieuNhap VALUES(24,6,17,28000)
INSERT INTO dbo.CTPhieuNhap VALUES(25,66,21,77995)
INSERT INTO dbo.CTPhieuNhap VALUES(26,36,16,225000)
INSERT INTO dbo.CTPhieuNhap VALUES(27,24,20,123250)
INSERT INTO dbo.CTPhieuNhap VALUES(28,11,23,18000)
INSERT INTO dbo.CTPhieuNhap VALUES(29,80,24,10500)
INSERT INTO dbo.CTPhieuNhap VALUES(1,6,23,28000)
INSERT INTO dbo.CTPhieuNhap VALUES(2,40,15,415000)
INSERT INTO dbo.CTPhieuNhap VALUES(3,7,21,55000)
INSERT INTO dbo.CTPhieuNhap VALUES(4,65,21,62320)
INSERT INTO dbo.CTPhieuNhap VALUES(5,15,22,143100)
INSERT INTO dbo.CTPhieuNhap VALUES(6,47,21,150000)
INSERT INTO dbo.CTPhieuNhap VALUES(7,71,18,44000)
INSERT INTO dbo.CTPhieuNhap VALUES(8,57,21,22000)
INSERT INTO dbo.CTPhieuNhap VALUES(9,22,25,63000)
INSERT INTO dbo.CTPhieuNhap VALUES(10,73,23,91200)
INSERT INTO dbo.CTPhieuNhap VALUES(11,80,19,10500)
INSERT INTO dbo.CTPhieuNhap VALUES(12,77,20,19000)
INSERT INTO dbo.CTPhieuNhap VALUES(13,73,23,91200)
INSERT INTO dbo.CTPhieuNhap VALUES(14,22,24,63000)
INSERT INTO dbo.CTPhieuNhap VALUES(15,24,18,123250)
INSERT INTO dbo.CTPhieuNhap VALUES(16,54,18,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(17,18,22,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(18,67,19,24000)
INSERT INTO dbo.CTPhieuNhap VALUES(19,72,16,53675)
INSERT INTO dbo.CTPhieuNhap VALUES(20,34,18,47000)
INSERT INTO dbo.CTPhieuNhap VALUES(21,2,20,36000)
INSERT INTO dbo.CTPhieuNhap VALUES(22,22,16,63000)
INSERT INTO dbo.CTPhieuNhap VALUES(23,80,25,10500)
INSERT INTO dbo.CTPhieuNhap VALUES(24,64,20,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(25,26,21,230000)
INSERT INTO dbo.CTPhieuNhap VALUES(26,43,18,570000)
INSERT INTO dbo.CTPhieuNhap VALUES(27,48,22,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(28,80,18,10500)
INSERT INTO dbo.CTPhieuNhap VALUES(29,86,23,56000)
INSERT INTO dbo.CTPhieuNhap VALUES(1,54,20,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(2,6,16,28000)
INSERT INTO dbo.CTPhieuNhap VALUES(3,82,21,70000)
INSERT INTO dbo.CTPhieuNhap VALUES(4,49,15,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(5,38,15,55000)
INSERT INTO dbo.CTPhieuNhap VALUES(6,17,20,36400)
INSERT INTO dbo.CTPhieuNhap VALUES(7,30,17,305000)
INSERT INTO dbo.CTPhieuNhap VALUES(8,37,21,115697)
INSERT INTO dbo.CTPhieuNhap VALUES(9,76,24,60000)
INSERT INTO dbo.CTPhieuNhap VALUES(10,31,24,295000)
INSERT INTO dbo.CTPhieuNhap VALUES(11,29,21,490000)
INSERT INTO dbo.CTPhieuNhap VALUES(12,82,21,70000)
INSERT INTO dbo.CTPhieuNhap VALUES(13,48,21,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(15,49,19,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(16,2,19,36000)
INSERT INTO dbo.CTPhieuNhap VALUES(17,43,24,570000)
INSERT INTO dbo.CTPhieuNhap VALUES(18,21,17,84000)
INSERT INTO dbo.CTPhieuNhap VALUES(19,25,20,240000)
INSERT INTO dbo.CTPhieuNhap VALUES(20,11,23,18000)
INSERT INTO dbo.CTPhieuNhap VALUES(21,62,16,13500)
INSERT INTO dbo.CTPhieuNhap VALUES(22,77,17,19000)
INSERT INTO dbo.CTPhieuNhap VALUES(23,49,24,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(24,48,24,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(25,9,15,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(26,83,21,105000)
INSERT INTO dbo.CTPhieuNhap VALUES(27,61,15,16000)
INSERT INTO dbo.CTPhieuNhap VALUES(28,27,21,95000)
INSERT INTO dbo.CTPhieuNhap VALUES(29,81,17,50500)
INSERT INTO dbo.CTPhieuNhap VALUES(1,41,20,93000)
INSERT INTO dbo.CTPhieuNhap VALUES(2,57,15,22000)
INSERT INTO dbo.CTPhieuNhap VALUES(3,8,17,74250)
INSERT INTO dbo.CTPhieuNhap VALUES(4,19,24,119200)
INSERT INTO dbo.CTPhieuNhap VALUES(5,35,23,28800)
INSERT INTO dbo.CTPhieuNhap VALUES(7,35,20,28800)
INSERT INTO dbo.CTPhieuNhap VALUES(8,83,20,105000)
INSERT INTO dbo.CTPhieuNhap VALUES(9,48,23,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(10,21,17,84000)
INSERT INTO dbo.CTPhieuNhap VALUES(11,64,16,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(12,18,23,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(13,25,22,240000)
INSERT INTO dbo.CTPhieuNhap VALUES(14,6,24,28000)
INSERT INTO dbo.CTPhieuNhap VALUES(15,75,22,87000)
INSERT INTO dbo.CTPhieuNhap VALUES(16,30,24,305000)
INSERT INTO dbo.CTPhieuNhap VALUES(17,12,17,145800)
INSERT INTO dbo.CTPhieuNhap VALUES(18,53,24,9000)
INSERT INTO dbo.CTPhieuNhap VALUES(19,37,16,115697)
INSERT INTO dbo.CTPhieuNhap VALUES(21,52,16,15000)
INSERT INTO dbo.CTPhieuNhap VALUES(22,49,23,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(23,54,24,10000)
INSERT INTO dbo.CTPhieuNhap VALUES(24,81,21,50500)
INSERT INTO dbo.CTPhieuNhap VALUES(25,55,20,9500)
INSERT INTO dbo.CTPhieuNhap VALUES(26,29,18,490000)
INSERT INTO dbo.CTPhieuNhap VALUES(27,17,17,36400)
INSERT INTO dbo.CTPhieuNhap VALUES(28,18,15,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(29,85,15,200000)
INSERT INTO dbo.CTPhieuNhap VALUES(1,16,20,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(2,71,15,44000)
INSERT INTO dbo.CTPhieuNhap VALUES(3,81,20,50500)
INSERT INTO dbo.CTPhieuNhap VALUES(4,12,19,145800)
INSERT INTO dbo.CTPhieuNhap VALUES(5,21,16,84000)
INSERT INTO dbo.CTPhieuNhap VALUES(6,55,18,9500)
INSERT INTO dbo.CTPhieuNhap VALUES(7,45,24,485000)
INSERT INTO dbo.CTPhieuNhap VALUES(8,60,17,32000)
INSERT INTO dbo.CTPhieuNhap VALUES(9,3,15,25000)
INSERT INTO dbo.CTPhieuNhap VALUES(10,43,16,570000)
INSERT INTO dbo.CTPhieuNhap VALUES(11,16,15,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(12,45,20,485000)
INSERT INTO dbo.CTPhieuNhap VALUES(13,2,20,36000)
INSERT INTO dbo.CTPhieuNhap VALUES(14,84,19,89000)
INSERT INTO dbo.CTPhieuNhap VALUES(15,70,25,29700)
INSERT INTO dbo.CTPhieuNhap VALUES(16,44,15,670000)
INSERT INTO dbo.CTPhieuNhap VALUES(17,56,16,13000)
INSERT INTO dbo.CTPhieuNhap VALUES(18,14,25,140400)
INSERT INTO dbo.CTPhieuNhap VALUES(19,20,18,148500)
INSERT INTO dbo.CTPhieuNhap VALUES(20,22,20,63000)
INSERT INTO dbo.CTPhieuNhap VALUES(21,6,16,28000)
INSERT INTO dbo.CTPhieuNhap VALUES(22,16,20,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(23,10,17,22000)
INSERT INTO dbo.CTPhieuNhap VALUES(24,25,15,240000)
INSERT INTO dbo.CTPhieuNhap VALUES(25,65,22,62320)
INSERT INTO dbo.CTPhieuNhap VALUES(26,26,24,230000)
INSERT INTO dbo.CTPhieuNhap VALUES(27,65,23,62320)
INSERT INTO dbo.CTPhieuNhap VALUES(28,79,20,14300)
INSERT INTO dbo.CTPhieuNhap VALUES(29,4,17,40000)
INSERT INTO dbo.CTPhieuNhap VALUES(1,70,16,29700)
INSERT INTO dbo.CTPhieuNhap VALUES(2,24,16,123250)
INSERT INTO dbo.CTPhieuNhap VALUES(3,47,21,150000)
INSERT INTO dbo.CTPhieuNhap VALUES(4,50,21,62050)
INSERT INTO dbo.CTPhieuNhap VALUES(5,24,16,123250)
INSERT INTO dbo.CTPhieuNhap VALUES(6,61,20,16000)
INSERT INTO dbo.CTPhieuNhap VALUES(7,75,16,87000)
INSERT INTO dbo.CTPhieuNhap VALUES(8,75,16,87000)
INSERT INTO dbo.CTPhieuNhap VALUES(9,18,21,124800)
INSERT INTO dbo.CTPhieuNhap VALUES(10,34,17,47000)
INSERT INTO dbo.CTPhieuNhap VALUES(11,69,15,52000)
INSERT INTO dbo.CTPhieuNhap VALUES(12,80,23,10500)
INSERT INTO dbo.CTPhieuNhap VALUES(13,45,24,485000)
INSERT INTO dbo.CTPhieuNhap VALUES(15,33,20,240000)
INSERT INTO dbo.CTPhieuNhap VALUES(16,61,17,16000)
INSERT INTO dbo.CTPhieuNhap VALUES(18,51,18,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(19,34,25,47000)
INSERT INTO dbo.CTPhieuNhap VALUES(20,7,15,55000)
INSERT INTO dbo.CTPhieuNhap VALUES(21,27,25,95000)
INSERT INTO dbo.CTPhieuNhap VALUES(22,25,23,240000)
INSERT INTO dbo.CTPhieuNhap VALUES(23,59,16,8500)
INSERT INTO dbo.CTPhieuNhap VALUES(24,2,24,36000)
INSERT INTO dbo.CTPhieuNhap VALUES(25,61,20,16000)
INSERT INTO dbo.CTPhieuNhap VALUES(26,51,16,150875)
INSERT INTO dbo.CTPhieuNhap VALUES(27,84,24,89000)
INSERT INTO dbo.CTPhieuNhap VALUES(28,71,24,44000)
INSERT INTO dbo.CTPhieuNhap VALUES(29,60,15,32000)



INSERT INTO dbo.HoaDon VALUES(1,38,2,43631)
INSERT INTO dbo.HoaDon VALUES(2,28,2,43631)
INSERT INTO dbo.HoaDon VALUES(3,25,4,43631)
INSERT INTO dbo.HoaDon VALUES(4,8,5,43631)
INSERT INTO dbo.HoaDon VALUES(5,46,5,43632)
INSERT INTO dbo.HoaDon VALUES(6,35,5,43632)
INSERT INTO dbo.HoaDon VALUES(7,21,4,43632)
INSERT INTO dbo.HoaDon VALUES(8,21,3,43632)
INSERT INTO dbo.HoaDon VALUES(9,25,3,43632)
INSERT INTO dbo.HoaDon VALUES(10,5,4,43632)
INSERT INTO dbo.HoaDon VALUES(11,47,2,43633)
INSERT INTO dbo.HoaDon VALUES(12,3,6,43633)
INSERT INTO dbo.HoaDon VALUES(13,12,5,43633)
INSERT INTO dbo.HoaDon VALUES(14,34,6,43633)
INSERT INTO dbo.HoaDon VALUES(15,49,4,43634)
INSERT INTO dbo.HoaDon VALUES(16,38,4,43634)
INSERT INTO dbo.HoaDon VALUES(17,46,2,43634)
INSERT INTO dbo.HoaDon VALUES(18,23,4,43634)
INSERT INTO dbo.HoaDon VALUES(19,1,3,43634)


INSERT INTO dbo.CTHoaDon VALUES(1,80,3,14000)
INSERT INTO dbo.CTHoaDon VALUES(2,48,3,73000)
INSERT INTO dbo.CTHoaDon VALUES(3,75,4,113000)
INSERT INTO dbo.CTHoaDon VALUES(4,51,3,177500)
INSERT INTO dbo.CTHoaDon VALUES(5,21,1,105000)
INSERT INTO dbo.CTHoaDon VALUES(6,47,1,192000)
INSERT INTO dbo.CTHoaDon VALUES(7,39,4,250000)
INSERT INTO dbo.CTHoaDon VALUES(8,48,1,73000)
INSERT INTO dbo.CTHoaDon VALUES(9,20,3,170000)
INSERT INTO dbo.CTHoaDon VALUES(10,3,1,35000)
INSERT INTO dbo.CTHoaDon VALUES(11,67,5,30000)
INSERT INTO dbo.CTHoaDon VALUES(12,54,1,16000)
INSERT INTO dbo.CTHoaDon VALUES(13,19,5,149000)
INSERT INTO dbo.CTHoaDon VALUES(14,55,1,15000)
INSERT INTO dbo.CTHoaDon VALUES(15,5,5,45000)
INSERT INTO dbo.CTHoaDon VALUES(16,15,1,164000)
INSERT INTO dbo.CTHoaDon VALUES(17,35,5,46000)
INSERT INTO dbo.CTHoaDon VALUES(18,48,1,73000)
INSERT INTO dbo.CTHoaDon VALUES(19,9,1,30000)
INSERT INTO dbo.CTHoaDon VALUES(1,50,1,73000)
INSERT INTO dbo.CTHoaDon VALUES(2,73,4,117000)
INSERT INTO dbo.CTHoaDon VALUES(3,13,2,140000)
INSERT INTO dbo.CTHoaDon VALUES(4,57,2,27000)
INSERT INTO dbo.CTHoaDon VALUES(5,29,3,680000)
INSERT INTO dbo.CTHoaDon VALUES(6,61,2,20000)
INSERT INTO dbo.CTHoaDon VALUES(7,65,2,80000)
INSERT INTO dbo.CTHoaDon VALUES(8,18,1,156000)
INSERT INTO dbo.CTHoaDon VALUES(10,43,4,800000)
INSERT INTO dbo.CTHoaDon VALUES(11,50,4,73000)
INSERT INTO dbo.CTHoaDon VALUES(12,21,1,105000)
INSERT INTO dbo.CTHoaDon VALUES(13,28,3,1029000)
INSERT INTO dbo.CTHoaDon VALUES(14,58,4,11000)
INSERT INTO dbo.CTHoaDon VALUES(15,26,1,290000)
INSERT INTO dbo.CTHoaDon VALUES(16,68,4,37000)
INSERT INTO dbo.CTHoaDon VALUES(17,53,5,15000)
INSERT INTO dbo.CTHoaDon VALUES(18,10,2,35000)
INSERT INTO dbo.CTHoaDon VALUES(19,53,5,15000)
INSERT INTO dbo.CTHoaDon VALUES(1,45,1,690000)
INSERT INTO dbo.CTHoaDon VALUES(2,42,1,110000)
INSERT INTO dbo.CTHoaDon VALUES(3,32,5,400000)
INSERT INTO dbo.CTHoaDon VALUES(4,72,1,70000)
INSERT INTO dbo.CTHoaDon VALUES(5,59,1,12000)
INSERT INTO dbo.CTHoaDon VALUES(6,59,1,12000)
INSERT INTO dbo.CTHoaDon VALUES(7,12,1,167000)
INSERT INTO dbo.CTHoaDon VALUES(8,72,3,70000)
INSERT INTO dbo.CTHoaDon VALUES(9,50,3,73000)
INSERT INTO dbo.CTHoaDon VALUES(10,79,5,18000)
INSERT INTO dbo.CTHoaDon VALUES(11,54,5,16000)
INSERT INTO dbo.CTHoaDon VALUES(12,24,3,145000)
INSERT INTO dbo.CTHoaDon VALUES(13,79,1,18000)
INSERT INTO dbo.CTHoaDon VALUES(14,34,3,60000)
INSERT INTO dbo.CTHoaDon VALUES(15,13,2,140000)
INSERT INTO dbo.CTHoaDon VALUES(16,40,4,580000)
INSERT INTO dbo.CTHoaDon VALUES(17,30,1,440000)
INSERT INTO dbo.CTHoaDon VALUES(18,43,2,800000)
INSERT INTO dbo.CTHoaDon VALUES(19,51,5,177500)
INSERT INTO dbo.CTHoaDon VALUES(1,41,4,107000)
INSERT INTO dbo.CTHoaDon VALUES(2,51,2,177500)
INSERT INTO dbo.CTHoaDon VALUES(3,68,5,37000)
INSERT INTO dbo.CTHoaDon VALUES(5,14,3,156000)
INSERT INTO dbo.CTHoaDon VALUES(6,13,4,140000)
INSERT INTO dbo.CTHoaDon VALUES(7,42,4,110000)
INSERT INTO dbo.CTHoaDon VALUES(8,17,1,52000)
INSERT INTO dbo.CTHoaDon VALUES(9,4,1,50000)
INSERT INTO dbo.CTHoaDon VALUES(10,8,3,95000)
INSERT INTO dbo.CTHoaDon VALUES(11,11,4,50000)
INSERT INTO dbo.CTHoaDon VALUES(12,73,1,117000)
INSERT INTO dbo.CTHoaDon VALUES(13,7,5,80000)
INSERT INTO dbo.CTHoaDon VALUES(14,42,5,110000)
INSERT INTO dbo.CTHoaDon VALUES(15,67,4,30000)
INSERT INTO dbo.CTHoaDon VALUES(16,39,5,250000)
INSERT INTO dbo.CTHoaDon VALUES(17,64,3,13000)
INSERT INTO dbo.CTHoaDon VALUES(18,71,2,55000)
INSERT INTO dbo.CTHoaDon VALUES(19,13,3,140000)
INSERT INTO dbo.CTHoaDon VALUES(1,7,2,80000)
INSERT INTO dbo.CTHoaDon VALUES(3,29,5,680000)
INSERT INTO dbo.CTHoaDon VALUES(4,53,3,15000)
INSERT INTO dbo.CTHoaDon VALUES(5,49,2,177500)
INSERT INTO dbo.CTHoaDon VALUES(6,38,2,75000)
INSERT INTO dbo.CTHoaDon VALUES(7,63,5,10000)
INSERT INTO dbo.CTHoaDon VALUES(8,21,5,105000)
INSERT INTO dbo.CTHoaDon VALUES(9,58,5,11000)
INSERT INTO dbo.CTHoaDon VALUES(10,33,2,300000)
INSERT INTO dbo.CTHoaDon VALUES(11,46,1,180000)
INSERT INTO dbo.CTHoaDon VALUES(12,14,1,156000)
INSERT INTO dbo.CTHoaDon VALUES(13,78,1,23000)
INSERT INTO dbo.CTHoaDon VALUES(14,24,5,145000)
INSERT INTO dbo.CTHoaDon VALUES(15,55,4,15000)
INSERT INTO dbo.CTHoaDon VALUES(16,29,2,680000)
INSERT INTO dbo.CTHoaDon VALUES(17,60,5,43000)
INSERT INTO dbo.CTHoaDon VALUES(18,37,2,150000)
INSERT INTO dbo.CTHoaDon VALUES(19,43,3,800000)

