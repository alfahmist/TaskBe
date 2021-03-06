USE [master]
GO
/****** Object:  Database [TaskBe]    Script Date: 10/11/2021 4:42:51 PM ******/
CREATE DATABASE [TaskBe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskBe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TaskBe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskBe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TaskBe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TaskBe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskBe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskBe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskBe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskBe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskBe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskBe] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskBe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskBe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskBe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskBe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskBe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskBe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskBe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskBe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskBe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskBe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TaskBe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskBe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskBe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskBe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskBe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskBe] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TaskBe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskBe] SET RECOVERY FULL 
GO
ALTER DATABASE [TaskBe] SET  MULTI_USER 
GO
ALTER DATABASE [TaskBe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskBe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskBe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskBe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskBe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskBe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TaskBe', N'ON'
GO
ALTER DATABASE [TaskBe] SET QUERY_STORE = OFF
GO
USE [TaskBe]
GO
/****** Object:  Table [dbo].[Pegawai]    Script Date: 10/11/2021 4:42:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pegawai](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Unit_id] [int] NULL,
	[Created_at] [datetime2](7) NULL,
	[Created_by] [nvarchar](max) NULL,
	[Isactive] [bit] NULL,
	[Update_at] [datetime2](7) NULL,
	[Update_by] [nvarchar](max) NULL,
	[Isdelete] [bit] NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pegawai] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 10/11/2021 4:42:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Created_at] [datetime2](7) NULL,
	[Created_by] [nvarchar](max) NULL,
	[Isactive] [bit] NULL,
	[Update_at] [datetime2](7) NULL,
	[Update_by] [nvarchar](max) NULL,
	[Isdelete] [bit] NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pegawai] ON 

INSERT [dbo].[Pegawai] ([Id], [Name], [Unit_id], [Created_at], [Created_by], [Isactive], [Update_at], [Update_by], [Isdelete], [Password]) VALUES (1, N'user', 1, CAST(N'2021-09-27T15:58:29.1855161' AS DateTime2), NULL, 1, CAST(N'2021-09-27T15:59:37.5791609' AS DateTime2), N'user1', 0, N'user')
INSERT [dbo].[Pegawai] ([Id], [Name], [Unit_id], [Created_at], [Created_by], [Isactive], [Update_at], [Update_by], [Isdelete], [Password]) VALUES (2, N'string', 1, NULL, N'user', 1, CAST(N'2021-09-27T15:51:59.6308596' AS DateTime2), N'string', 1, N'string')
INSERT [dbo].[Pegawai] ([Id], [Name], [Unit_id], [Created_at], [Created_by], [Isactive], [Update_at], [Update_by], [Isdelete], [Password]) VALUES (3, N'user2', 2, CAST(N'2021-09-27T16:03:31.4724751' AS DateTime2), N'user', NULL, NULL, NULL, 0, N'user2')
INSERT [dbo].[Pegawai] ([Id], [Name], [Unit_id], [Created_at], [Created_by], [Isactive], [Update_at], [Update_by], [Isdelete], [Password]) VALUES (4, N'user3', 2, CAST(N'2021-09-27T16:06:46.7248373' AS DateTime2), N'string', 1, NULL, NULL, 0, N'user3')
SET IDENTITY_INSERT [dbo].[Pegawai] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [Name], [Code], [Created_at], [Created_by], [Isactive], [Update_at], [Update_by], [Isdelete]) VALUES (1, N'unit', N'u1', NULL, N'user', 1, NULL, N'user', 0)
INSERT [dbo].[Unit] ([Id], [Name], [Code], [Created_at], [Created_by], [Isactive], [Update_at], [Update_by], [Isdelete]) VALUES (2, N'unit', N'u1', NULL, N'user', 1, CAST(N'2021-09-27T16:01:23.8221679' AS DateTime2), N'user1', 0)
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
/****** Object:  Index [IX_Pegawai_Unit_id]    Script Date: 10/11/2021 4:42:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pegawai_Unit_id] ON [dbo].[Pegawai]
(
	[Unit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pegawai]  WITH CHECK ADD  CONSTRAINT [FK_Pegawai_Unit_Unit_id] FOREIGN KEY([Unit_id])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[Pegawai] CHECK CONSTRAINT [FK_Pegawai_Unit_Unit_id]
GO
USE [master]
GO
ALTER DATABASE [TaskBe] SET  READ_WRITE 
GO
