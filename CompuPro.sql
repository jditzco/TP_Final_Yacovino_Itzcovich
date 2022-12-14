USE [master]
GO
/****** Object:  Database [CompuPro]    Script Date: 22/11/2022 12:07:51 ******/
CREATE DATABASE [CompuPro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompuPro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CompuPro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompuPro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CompuPro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CompuPro] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompuPro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompuPro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompuPro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompuPro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompuPro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompuPro] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompuPro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompuPro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompuPro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompuPro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompuPro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompuPro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompuPro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompuPro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompuPro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompuPro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompuPro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompuPro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompuPro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompuPro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompuPro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompuPro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompuPro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompuPro] SET RECOVERY FULL 
GO
ALTER DATABASE [CompuPro] SET  MULTI_USER 
GO
ALTER DATABASE [CompuPro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompuPro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompuPro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompuPro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompuPro] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CompuPro', N'ON'
GO
ALTER DATABASE [CompuPro] SET QUERY_STORE = OFF
GO
USE [CompuPro]
GO
/****** Object:  User [alumno]    Script Date: 22/11/2022 12:07:51 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Computadora]    Script Date: 22/11/2022 12:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computadora](
	[idPC] [int] IDENTITY(1,1) NOT NULL,
	[imagenPortada] [varchar](max) NULL,
	[precio] [float] NOT NULL,
	[procesador] [varchar](max) NOT NULL,
	[mother] [varchar](max) NOT NULL,
	[placaVideo] [varchar](max) NOT NULL,
	[fuenteAlimentacion] [varchar](max) NOT NULL,
	[SO] [varchar](max) NOT NULL,
	[envioADomicilio] [bit] NOT NULL,
	[disponible] [bit] NOT NULL,
	[marca] [varchar](max) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[ram] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Computadora] PRIMARY KEY CLUSTERED 
(
	[idPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/11/2022 12:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[contraseña] [varchar](20) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[fechaSignUp] [datetime] NOT NULL,
	[plata] [float] NOT NULL,
	[computadorasCompradas] [int] NOT NULL,
	[computadorasVendidas] [int] NOT NULL,
	[rango] [char](1) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Computadora] ON 

INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (1, N'https://http2.mlstatic.com/D_NQ_NP_647970-MLA43352897926_092020-V.jpg', 699, N'Intel Core i5 11900K', N'Asus Rog Legacy 5590', N'Nvidia RTX 3060', N'CoolerMaster 600w', N'Windows', 0, 1, N'Dell', 1, N'Dell h56Pro', N'Fury Beast DDR4')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (2, N'https://buscadoresdeofertas.com.ar/images/v4a3QtPt9wvkHbMbjM4FjZxyvoDnWj8URy2XzW9t.jpeg', 399, N'Intel Core i3 8800K', N'hp 84a7', N'Nvidia Geforce 1050 TI', N'HP Mini 1000 493092-002', N'Windows', 1, 1, N'HP', 2, N'Hp Omen 4776Lite', N'Crucial CB8GS2666')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (3, N'http://d2r9epyceweg5n.cloudfront.net/stores/001/321/783/products/11uh-082011-7c88c527dd9bc00bd616577177732500-640-0.jpg', 1500, N'Intel i9-12900H', N'Msi Cr620', N'Nvidia Rtx 3070', N'Msi 280W adapter', N'Windows', 1, 0, N'Msi', 3, N'MSI Raider76x', N'Premier 4GB 1 Adata')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (4, N'https://support.hp.com/doc-images/85/c06123504.png', 3499, N'Intel Core i9 12900H', N'ASUS ROG STRIX Z590-E', N'Nvidia RTX 4090', N'Cooler Master MASTERWATT 750', N'Windows', 0, 1, N'HP', 4, N'Hp Game station Pro', N'Crucial CT8G4SFS832A')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (7, N'https://www.lenovo.com/medias/lenovo-laptop-legion-5-15-intel-subseries-hero.png?context=bWFzdGVyfHJvb3R8MzA2MjM2fGltYWdlL3BuZ3xoOGUvaDI2LzE0MzMyNjk1MzE0NDYyLnBuZ3w0NTQ5M2UyMWNkNjIyYmEzNmI0MWM0YTU4MjM0YjcxZmZhNTAxZThiZWE2OTUwNDJjOTQ2MDI3NWY3YzA3NzNm', 999, N'Intel Core i9 10700k', N'Lenovo Legion 376i', N'Nvidia RTX 2070 Super', N'Lenovo Power Brick', N'Windows', 1, 0, N'Lenovo', 5, N'Lenovo Legion 7', N'Lenovo 74648')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (8, N'https://m.media-amazon.com/images/I/71pczXb2vaL._AC_SX679_.jpg', 599, N'AMD Ryzen 3', N'Asus Rog Legacy 7784k', N'Nvidia GTX 1050Ti', N'Skytech 600W', N'Windows', 0, 0, N'Msi', 1, N'Skytech Archangel 3.0 Gaming PC ', N'Western Digital DDR4 887k')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (11, N'https://m.media-amazon.com/images/I/917tcG9ezXL._AC_SX679_.jpg', 4469, N'Intel Core i9 12900k', N'Asus Rog legacy 110M', N'Nvidia RTX 3090 Ti', N'Skytech 1000W', N'Windows', 0, 1, N'Msi', 1, N'Skytech Prism II', N'Corsair CMW32GX4M2A2666C16')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (13, N'https://m.media-amazon.com/images/I/810naSDT+2L._AC_SY300_SX300_.jpg', 2674, N'Intel Core i9 12900k', N'Hp 39486OM', N'Intel Integrated Graphics', N'Hp 900W 34834k', N'Windows', 0, 0, N'HP', 6, N'OMEN 30L', N'Ddr4 Xpg Spectrix')
INSERT [dbo].[Computadora] ([idPC], [imagenPortada], [precio], [procesador], [mother], [placaVideo], [fuenteAlimentacion], [SO], [envioADomicilio], [disponible], [marca], [idUsuario], [nombre], [ram]) VALUES (16, N'https://m.media-amazon.com/images/I/61Lj0z2FkKL._AC_SX679_.jpg', 3129, N'Intel Core i9 1050k', N'Del 2763MB', N'Nvidia RTX 3070 Ti', N'Alienware Power Brick', N'Windows', 1, 1, N'Dell', 6, N'Alienware Aurora R13', N'Premier 4GB 1 Adata')
SET IDENTITY_INSERT [dbo].[Computadora] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (1, N'Carlos23', N'carlitos', CAST(N'2000-05-21' AS Date), CAST(N'2018-02-11T00:00:00.000' AS DateTime), 0, 0, 0, N'J')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (2, N'MatheoYaco', N'mathe11', CAST(N'2006-02-07' AS Date), CAST(N'2021-11-20T00:00:00.000' AS DateTime), 0, 1, 1, N'H')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (3, N'Pablo001', N'señorpablo', CAST(N'1988-07-01' AS Date), CAST(N'2022-06-26T00:00:00.000' AS DateTime), 400, 2, 0, N'H')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (4, N'DarioGamer', N'FE1242', CAST(N'2001-05-30' AS Date), CAST(N'2020-05-09T00:00:00.000' AS DateTime), 160, 0, 0, N'J')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (5, N'MaestroHoracio', N'horacio62', CAST(N'1992-12-08' AS Date), CAST(N'2012-10-17T00:00:00.000' AS DateTime), 2700, 3, 8, N'B')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (6, N'Ma', N'123', CAST(N'2022-11-03' AS Date), CAST(N'2022-11-01T09:31:25.603' AS DateTime), 0, 0, 0, N'H')
INSERT [dbo].[Usuario] ([idUsuario], [nombre], [contraseña], [fechaNacimiento], [fechaSignUp], [plata], [computadorasCompradas], [computadorasVendidas], [rango]) VALUES (9, N'Mafd', N'123342', CAST(N'2022-11-02' AS Date), CAST(N'2022-11-22T10:51:32.893' AS DateTime), 0, 0, 0, N'H')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Computadora]  WITH CHECK ADD  CONSTRAINT [FK_Computadora_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Computadora] CHECK CONSTRAINT [FK_Computadora_Usuario]
GO
USE [master]
GO
ALTER DATABASE [CompuPro] SET  READ_WRITE 
GO

SELECT * FROM Computadora WHERE marca = Dell AND idUsuario <> 6