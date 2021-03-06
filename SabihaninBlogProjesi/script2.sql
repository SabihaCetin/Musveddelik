USE [master]
GO
/****** Object:  Database [SabihaBlog]    Script Date: 18.01.2018 01:37:13 ******/
CREATE DATABASE [SabihaBlog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SabihaBlog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SBHCTN\MSSQL\DATA\SabihaBlog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SabihaBlog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SBHCTN\MSSQL\DATA\SabihaBlog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SabihaBlog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SabihaBlog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SabihaBlog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SabihaBlog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SabihaBlog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SabihaBlog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SabihaBlog] SET ARITHABORT OFF 
GO
ALTER DATABASE [SabihaBlog] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SabihaBlog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SabihaBlog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SabihaBlog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SabihaBlog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SabihaBlog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SabihaBlog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SabihaBlog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SabihaBlog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SabihaBlog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SabihaBlog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SabihaBlog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SabihaBlog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SabihaBlog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SabihaBlog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SabihaBlog] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SabihaBlog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SabihaBlog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SabihaBlog] SET  MULTI_USER 
GO
ALTER DATABASE [SabihaBlog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SabihaBlog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SabihaBlog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SabihaBlog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SabihaBlog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SabihaBlog] SET QUERY_STORE = OFF
GO
USE [SabihaBlog]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SabihaBlog]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[AdSoyad] [nvarchar](max) NOT NULL,
	[Meslek] [nvarchar](max) NOT NULL,
	[Cinsiyet] [bit] NOT NULL,
	[DogumTarihi] [datetime] NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[Resim] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[ArkaPlanResmi] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etikets]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etikets](
	[EtiketID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Etikets] PRIMARY KEY CLUSTERED 
(
	[EtiketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoris]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoris](
	[KAtegoriID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](max) NULL,
	[Aciklama] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Kategoris] PRIMARY KEY CLUSTERED 
(
	[KAtegoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MakaleEtikets]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MakaleEtikets](
	[Makale_MakaleID] [int] NOT NULL,
	[Etiket_EtiketID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MakaleEtikets] PRIMARY KEY CLUSTERED 
(
	[Makale_MakaleID] ASC,
	[Etiket_EtiketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Makales]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makales](
	[MakaleID] [int] IDENTITY(1,1) NOT NULL,
	[Baslik] [nvarchar](max) NULL,
	[Icerik] [nvarchar](max) NULL,
	[EklenmeTarihi] [datetime] NOT NULL,
	[KategoriID] [int] NULL,
	[GoruntulenmeSayisi] [int] NULL,
	[Begeni] [int] NULL,
	[KullaniciID] [int] NULL,
	[Kullanici_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Makales] PRIMARY KEY CLUSTERED 
(
	[MakaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resims]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resims](
	[ResimID] [int] IDENTITY(1,1) NOT NULL,
	[KucukBoyut] [nvarchar](max) NULL,
	[OrtaBoyut] [nvarchar](max) NULL,
	[BuyukBoyut] [nvarchar](max) NULL,
	[Video] [nvarchar](max) NULL,
	[MakaleID] [int] NULL,
 CONSTRAINT [PK_dbo.Resims] PRIMARY KEY CLUSTERED 
(
	[ResimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yorums]    Script Date: 18.01.2018 01:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yorums](
	[YorumID] [int] IDENTITY(1,1) NOT NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Begeni] [int] NOT NULL,
	[Makale_MakaleID] [int] NULL,
	[YorumIcerik] [nvarchar](max) NULL,
	[Kullanici_Id] [nvarchar](128) NULL,
	[AdSoyad] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Yorums] PRIMARY KEY CLUSTERED 
(
	[YorumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 18.01.2018 01:37:13 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 18.01.2018 01:37:13 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Etiket_EtiketID]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_Etiket_EtiketID] ON [dbo].[MakaleEtikets]
(
	[Etiket_EtiketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Makale_MakaleID]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_Makale_MakaleID] ON [dbo].[MakaleEtikets]
(
	[Makale_MakaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KategoriID]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_KategoriID] ON [dbo].[Makales]
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Kullanici_Id]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_Kullanici_Id] ON [dbo].[Makales]
(
	[Kullanici_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MakaleID]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_MakaleID] ON [dbo].[Resims]
(
	[MakaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Kullanici_Id]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_Kullanici_Id] ON [dbo].[Yorums]
(
	[Kullanici_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Makale_MakaleID]    Script Date: 18.01.2018 01:37:13 ******/
CREATE NONCLUSTERED INDEX [IX_Makale_MakaleID] ON [dbo].[Yorums]
(
	[Makale_MakaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[MakaleEtikets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MakaleEtikets_dbo.Etikets_Etiket_EtiketID] FOREIGN KEY([Etiket_EtiketID])
REFERENCES [dbo].[Etikets] ([EtiketID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MakaleEtikets] CHECK CONSTRAINT [FK_dbo.MakaleEtikets_dbo.Etikets_Etiket_EtiketID]
GO
ALTER TABLE [dbo].[MakaleEtikets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MakaleEtikets_dbo.Makales_Makale_MakaleID] FOREIGN KEY([Makale_MakaleID])
REFERENCES [dbo].[Makales] ([MakaleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MakaleEtikets] CHECK CONSTRAINT [FK_dbo.MakaleEtikets_dbo.Makales_Makale_MakaleID]
GO
ALTER TABLE [dbo].[Makales]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Makales_dbo.AspNetUsers_Kullanici_Id] FOREIGN KEY([Kullanici_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Makales] CHECK CONSTRAINT [FK_dbo.Makales_dbo.AspNetUsers_Kullanici_Id]
GO
ALTER TABLE [dbo].[Makales]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Makales_dbo.Kategoris_KategoriID] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategoris] ([KAtegoriID])
GO
ALTER TABLE [dbo].[Makales] CHECK CONSTRAINT [FK_dbo.Makales_dbo.Kategoris_KategoriID]
GO
ALTER TABLE [dbo].[Resims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Resims_dbo.Makales_MakaleID] FOREIGN KEY([MakaleID])
REFERENCES [dbo].[Makales] ([MakaleID])
GO
ALTER TABLE [dbo].[Resims] CHECK CONSTRAINT [FK_dbo.Resims_dbo.Makales_MakaleID]
GO
ALTER TABLE [dbo].[Yorums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Yorums_dbo.AspNetUsers_Kullanici_Id] FOREIGN KEY([Kullanici_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Yorums] CHECK CONSTRAINT [FK_dbo.Yorums_dbo.AspNetUsers_Kullanici_Id]
GO
ALTER TABLE [dbo].[Yorums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Yorums_dbo.Makales_Makale_MakaleID] FOREIGN KEY([Makale_MakaleID])
REFERENCES [dbo].[Makales] ([MakaleID])
GO
ALTER TABLE [dbo].[Yorums] CHECK CONSTRAINT [FK_dbo.Yorums_dbo.Makales_Makale_MakaleID]
GO
USE [master]
GO
ALTER DATABASE [SabihaBlog] SET  READ_WRITE 
GO
