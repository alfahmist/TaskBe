USE [TaskBe]
GO
/****** Object:  Table [dbo].[Pegawai]    Script Date: 9/27/2021 4:26:33 PM ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 9/27/2021 4:26:33 PM ******/
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
ALTER TABLE [dbo].[Pegawai]  WITH CHECK ADD  CONSTRAINT [FK_Pegawai_Unit_Unit_id] FOREIGN KEY([Unit_id])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[Pegawai] CHECK CONSTRAINT [FK_Pegawai_Unit_Unit_id]
GO
