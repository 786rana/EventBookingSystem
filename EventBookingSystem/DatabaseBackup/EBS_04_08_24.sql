USE [master]
GO
/****** Object:  Database [EventBookingSystemORG10]    Script Date: 8/4/2024 12:46:12 AM ******/
CREATE DATABASE [EventBookingSystemORG10]

USE [EventBookingSystemORG10]
GO
/****** Object:  Table [dbo].[MarriageHalls]    Script Date: 8/4/2024 12:46:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarriageHalls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[ImageUrl] [varchar](500) NULL,
 CONSTRAINT [PK_MarriageHalls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarriageHallServices]    Script Date: 8/4/2024 12:46:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarriageHallServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MarriageHallId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_MarriageHallServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 8/4/2024 12:46:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/4/2024 12:46:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MarriageHallId] [int] NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Tip] [decimal](18, 2) NOT NULL,
	[NetAmount] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[BalanceAmount] [decimal](18, 2) NULL,
	[Remarks] [varchar](max) NULL,
	[BookingType] [varchar](500) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicess]    Script Date: 8/4/2024 12:46:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ImageUrl] [varchar](500) NULL,
	[Detail] [varchar](max) NULL,
 CONSTRAINT [PK_Servicess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/4/2024 12:46:12 AM ******/
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
SET IDENTITY_INSERT [dbo].[MarriageHalls] ON 
GO
INSERT [dbo].[MarriageHalls] ([Id], [Name], [Phone], [Location], [Details], [UserId], [ImageUrl]) VALUES (1009, N'Abdullah Palace', N'03456869546', N'Amnabad Road Sialkot', N'We are providing all services ', 1, N'/MarriageImages/download1_638583195897964380.jpg')
GO
INSERT [dbo].[MarriageHalls] ([Id], [Name], [Phone], [Location], [Details], [UserId], [ImageUrl]) VALUES (1014, N'5G', N'03466566828', N'Panjgarii', N'We are providing all services ', 1, NULL)
GO
INSERT [dbo].[MarriageHalls] ([Id], [Name], [Phone], [Location], [Details], [UserId], [ImageUrl]) VALUES (2004, N'Chiragh Maquee', N'03456869540', N'Kotli Bawa Faqeer chand, Tehsil Pasrur, Distt. Sialkot', N'We are providing all services ', 1, N'/MarriageImages/images (1)_638583289389874780.jfif')
GO
SET IDENTITY_INSERT [dbo].[MarriageHalls] OFF
GO
SET IDENTITY_INSERT [dbo].[MarriageHallServices] ON 
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1019, 1009, 1007, 100)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1020, 1009, 1009, 5000)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1021, 1009, 1012, 7000)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1022, 1014, 1009, 5000)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1023, 1014, 1008, 800)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1024, 1014, 1007, 600)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1025, 1014, 1011, 20000)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (1026, 1014, 1012, 30000)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (2002, 2004, 1013, 1500)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (2003, 2004, 1012, 2000)
GO
INSERT [dbo].[MarriageHallServices] ([Id], [MarriageHallId], [ServiceId], [Price]) VALUES (2004, 2004, 1010, 3000)
GO
SET IDENTITY_INSERT [dbo].[MarriageHallServices] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ServiceId], [Quantity], [Price], [Amount]) VALUES (14, 9, 1009, 1, CAST(5000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ServiceId], [Quantity], [Price], [Amount]) VALUES (15, 9, 1007, 10, CAST(100.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ServiceId], [Quantity], [Price], [Amount]) VALUES (16, 9, 1012, 1, CAST(7000.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [UserId], [MarriageHallId], [Total], [Tip], [NetAmount], [CreatedDate], [StartDate], [EndDate], [PaidAmount], [BalanceAmount], [Remarks], [BookingType]) VALUES (9, 1003, 1009, CAST(13000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(13000.00 AS Decimal(18, 2)), CAST(N'2024-08-01T23:31:15.897' AS DateTime), CAST(N'2024-08-01T23:29:00.000' AS DateTime), CAST(N'2024-08-02T23:29:00.000' AS DateTime), CAST(13000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, N'Birthday')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicess] ON 
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1007, N'Catering Single Dish', N'/serviceImages/images_638583181231254256.jpg', N'we are providing single dish ')
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1008, N'Catering Double Dish', N'/serviceImages/img_638583198507145261.jpg', N'we are providing doubledish ')
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1009, N'DJ Simple', N'/serviceImages/road_image2_638583287953315101.jpg', N'Simple DJ')
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1010, N'DJ with Band', NULL, NULL)
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1011, N'Cameraman ', NULL, NULL)
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1012, N'Cameraman with Photoshot', NULL, NULL)
GO
INSERT [dbo].[Servicess] ([Id], [Name], [ImageUrl], [Detail]) VALUES (1013, N'Bismillah', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Servicess] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1, N'Ehtisham', N'ehtishamrana@gmail.com', N'123', N'03466566828', N'Badinah', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (2, N'Rana EHTISHAM', N'ehtishamrana@gmail.com', N'123', N'03466566828', N'Rachara', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1002, N'Rana EHTISHAM', N'ehtishamrana@gmail.com', N'123', N'03466566828', N'Rachara', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1003, N'Ali', N'ali@raza.com', N'123', N'222', N'johar town lahore', 0)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1004, N'Rafaqat', N'rafaqat@786gmail.com', N'1234', N'03429287899', N'Rachara', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1005, N'shahid', N'saifali@gmail.com', N'1234567', N'03466566828', N'Sialkot', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1007, N'Admin', N'admin@gmail.com', N'123', N'111', N'Lahore', 0)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [Phone], [Address], [Vendor]) VALUES (1008, N'uskt', N'uskt@gmail.com', N'1234', N'03429287899', N'Sialkot', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_MarriageHalls_UserId]    Script Date: 8/4/2024 12:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_MarriageHalls_UserId] ON [dbo].[MarriageHalls]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MarriageHallServices_MarriageHallId]    Script Date: 8/4/2024 12:46:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_MarriageHallServices_MarriageHallId] ON [dbo].[MarriageHallServices]
(
	[MarriageHallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 8/4/2024 12:46:12 AM ******/
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
ALTER TABLE [dbo].[MarriageHallServices]  WITH CHECK ADD  CONSTRAINT [FK_MarriageHallServices_Servicess] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Servicess] ([Id])
GO
ALTER TABLE [dbo].[MarriageHallServices] CHECK CONSTRAINT [FK_MarriageHallServices_Servicess]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_MarriageHalls] FOREIGN KEY([MarriageHallId])
REFERENCES [dbo].[MarriageHalls] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_MarriageHalls]
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
