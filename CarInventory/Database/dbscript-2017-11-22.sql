USE [CarsInventory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Cars_Users_Mapping] DROP CONSTRAINT IF EXISTS [FK_Cars_Users_Mapping_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Cars_Users_Mapping] DROP CONSTRAINT IF EXISTS [FK_Cars_Users_Mapping_Cars]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/22/2017 9:48:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[Cars_Users_Mapping]    Script Date: 11/22/2017 9:48:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Cars_Users_Mapping]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 11/22/2017 9:48:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Cars]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 11/22/2017 9:48:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[New] [bit] NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Cars_Users_Mapping]    Script Date: 11/22/2017 9:48:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cars_Users_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[UsersId] [int] NULL,
 CONSTRAINT [PK_Cars_Users_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/22/2017 9:48:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[IsEmailVerified] [bit] NULL,
	[ContactNumber] [nvarchar](15) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [IsActive], [LastLogin], [IsEmailVerified], [ContactNumber]) VALUES (1, N'harshwardhan.dangra@gmail.com', N'harsh123#', N'harshwardhan.dangra@gmail.com', 1, NULL, 1, NULL)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [IsActive], [LastLogin], [IsEmailVerified], [ContactNumber]) VALUES (2, N'harsh', N'Harsh1234#', N'harshwardhan.dangra1988@gmail.com', 0, NULL, 0, NULL)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [IsActive], [LastLogin], [IsEmailVerified], [ContactNumber]) VALUES (3, N'divya', N'divya123#', N'divya.latest1990@gmail.com', 0, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Users_Mapping_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]'))
ALTER TABLE [dbo].[Cars_Users_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Users_Mapping_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Users_Mapping_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]'))
ALTER TABLE [dbo].[Cars_Users_Mapping] CHECK CONSTRAINT [FK_Cars_Users_Mapping_Cars]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Users_Mapping_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]'))
ALTER TABLE [dbo].[Cars_Users_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Users_Mapping_Users] FOREIGN KEY([UsersId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Users_Mapping_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars_Users_Mapping]'))
ALTER TABLE [dbo].[Cars_Users_Mapping] CHECK CONSTRAINT [FK_Cars_Users_Mapping_Users]
GO
