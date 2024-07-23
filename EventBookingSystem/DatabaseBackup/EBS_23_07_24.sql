USE [master]
GO
/****** Object:  Database [EventBookingSystemORG10]    Script Date: 23/07/2024 7:42:41 pm ******/
CREATE DATABASE [EventBookingSystemORG10]
GO
USE [EventBookingSystemORG10]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[MarriageHalls]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarriageHalls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[Price] [nvarchar](max) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_MarriageHalls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarriageHallServices]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarriageHallServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MarriageHallId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[OrderId] [int] NULL,
 CONSTRAINT [PK_MarriageHallServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[MarriageHallId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[NetAmount] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicess]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Servicess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/07/2024 7:42:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Vendor] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240723094114_ebs19', N'7.0.14')
GO
SET IDENTITY_INSERT [dbo].[MarriageHalls] ON 
GO
INSERT [dbo].[MarriageHalls] ([Id], [Name], [Phone], [Location], [Price], [Details], [UserId]) VALUES (1, N'Abdullah', N'03466566828', N'Sialkot', N'5000000', N'lahore lahore e jnb', 1)
GO
SET IDENTITY_INSERT [dbo].[MarriageHalls] OFF
GO
SET IDENTITY_INSERT [dbo].[MarriageHallServices] ON 
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price], [OrderId]) VALUES (1, 1, 1, 467, NULL)
GO
SET IDENTITY_INSERT [dbo].[MarriageHallServices] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicess] ON 
GO
INSERT [dbo].[Servicess] ([Id], [Name], [Price]) VALUES (1, N'Catering', 200000)
GO
INSERT [dbo].[Servicess] ([Id], [Name], [Price]) VALUES (2, N'Palor', 200000)
GO
INSERT [dbo].[Servicess] ([Id], [Name], [Price]) VALUES (3, N'DJ', 40000)
GO
SET IDENTITY_INSERT [dbo].[Servicess] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1, N'Ehtisham', N'ehtishamrana@gmail.com', N'123', N'03466566828', N'Badinah', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_MarriageHalls_UserId]    Script Date: 23/07/2024 7:42:41 pm ******/
CREATE NONCLUSTERED INDEX [IX_MarriageHalls_UserId] ON [dbo].[MarriageHalls]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MarriageHallServices_MarriageHallId]    Script Date: 23/07/2024 7:42:41 pm ******/
CREATE NONCLUSTERED INDEX [IX_MarriageHallServices_MarriageHallId] ON [dbo].[MarriageHallServices]
(
	[MarriageHallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MarriageHallServices_OrderId]    Script Date: 23/07/2024 7:42:41 pm ******/
CREATE NONCLUSTERED INDEX [IX_MarriageHallServices_OrderId] ON [dbo].[MarriageHallServices]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 23/07/2024 7:42:41 pm ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MarriageHalls]  WITH CHECK ADD  CONSTRAINT [FK_MarriageHalls_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MarriageHalls] CHECK CONSTRAINT [FK_MarriageHalls_Users_UserId]
GO
ALTER TABLE [dbo].[MarriageHallServices]  WITH CHECK ADD  CONSTRAINT [FK_MarriageHallServices_MarriageHalls_MarriageHallId] FOREIGN KEY([MarriageHallId])
REFERENCES [dbo].[MarriageHalls] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MarriageHallServices] CHECK CONSTRAINT [FK_MarriageHallServices_MarriageHalls_MarriageHallId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
USE [master]
GO
ALTER DATABASE [EventBookingSystemORG10] SET  READ_WRITE 
GO
