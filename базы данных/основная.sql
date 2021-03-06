USE [master]
GO
/****** Object:  Database [manager_1]    Script Date: 08/01/2017 20:37:31 ******/
CREATE DATABASE [manager_1] ON  PRIMARY 
( NAME = N'manager_1', FILENAME = N'D:\SQLDB\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\manager_1.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'manager_1_log', FILENAME = N'D:\SQLDB\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\manager_1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [manager_1] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [manager_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [manager_1] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [manager_1] SET ANSI_NULLS OFF
GO
ALTER DATABASE [manager_1] SET ANSI_PADDING OFF
GO
ALTER DATABASE [manager_1] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [manager_1] SET ARITHABORT OFF
GO
ALTER DATABASE [manager_1] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [manager_1] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [manager_1] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [manager_1] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [manager_1] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [manager_1] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [manager_1] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [manager_1] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [manager_1] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [manager_1] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [manager_1] SET  DISABLE_BROKER
GO
ALTER DATABASE [manager_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [manager_1] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [manager_1] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [manager_1] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [manager_1] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [manager_1] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [manager_1] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [manager_1] SET  READ_WRITE
GO
ALTER DATABASE [manager_1] SET RECOVERY SIMPLE
GO
ALTER DATABASE [manager_1] SET  MULTI_USER
GO
ALTER DATABASE [manager_1] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [manager_1] SET DB_CHAINING OFF
GO
USE [manager_1]
GO
/****** Object:  User [man]    Script Date: 08/01/2017 20:37:31 ******/
CREATE USER [man] FOR LOGIN [man] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 08/01/2017 20:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Managers](
	[IDManager] [int] IDENTITY(1,1) NOT NULL,
	[FullNameManager] [varchar](100) NOT NULL,
	[StartDateWork] [datetime] NOT NULL,
	[PercentOnSale] [float] NOT NULL,
	[Phone] [float] NOT NULL,
	[Note] [varchar](1000) NULL,
 CONSTRAINT [XPKManagers] PRIMARY KEY CLUSTERED 
(
	[IDManager] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Managers] UNIQUE NONCLUSTERED 
(
	[IDManager] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wage]    Script Date: 08/01/2017 20:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wage](
	[IDWage] [int] IDENTITY(1,1) NOT NULL,
	[IDManager] [int] NOT NULL,
	[SumOrders] [int] NULL,
	[CurrentSum] [float] NULL,
	[Paid] [float] NULL,
	[Rest] [float] NULL,
 CONSTRAINT [XPKWage] PRIMARY KEY CLUSTERED 
(
	[IDManager] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Wage] UNIQUE NONCLUSTERED 
(
	[IDWage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[WageReport]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WageReport](SumOrders,CurrentSum,Paid,Rest,FullNameManager)
AS
SELECT Wage.SumOrders,Wage.CurrentSum,Wage.Paid,Wage.Rest,Managers.FullNameManager
	FROM Wage,Managers
		WHERE Managers.IDManager = Wage.IDManager
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[IDOrder] [int] IDENTITY(1,1) NOT NULL,
	[IDEnterprise] [int] NOT NULL,
	[IDTypeReklama] [int] NOT NULL,
	[IDManager] [int] NOT NULL,
	[Cost] [float] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[FinallyDate] [datetime] NOT NULL,
	[Paid] [float] NOT NULL,
	[Debt] [float] NOT NULL,
	[AllSum] [float] NOT NULL,
 CONSTRAINT [XPKOrders] PRIMARY KEY CLUSTERED 
(
	[IDOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Orders] UNIQUE NONCLUSTERED 
(
	[IDOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enterprises]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enterprises](
	[IDEnterprise] [int] IDENTITY(1,1) NOT NULL,
	[NameEnterprise] [varchar](100) NOT NULL,
	[Representative] [varchar](100) NOT NULL,
	[Phone] [float] NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Email] [varchar](50) NULL,
	[Note] [varchar](1000) NULL,
 CONSTRAINT [XPKEnterprises] PRIMARY KEY CLUSTERED 
(
	[IDEnterprise] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Enterprises] UNIQUE NONCLUSTERED 
(
	[IDEnterprise] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[DebtReport]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DebtReport](NameEnterprise,Representative,Phone,Paid,Debt,StartDate,FinallyDate,IDEnterprise)
AS
SELECT Enterprises.NameEnterprise,Enterprises.Representative,Enterprises.Phone,Orders.Paid,Orders.Debt,Orders.StartDate,Orders.FinallyDate,Orders.IDEnterprise
	FROM Enterprises,Orders
		WHERE Orders.IDEnterprise = Enterprises.IDEnterprise
GO
/****** Object:  Table [dbo].[TypeReklama]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeReklama](
	[IDTypeReklama] [int] IDENTITY(1,1) NOT NULL,
	[IDCarrier] [int] NOT NULL,
	[NameReklama] [varchar](100) NOT NULL,
	[Position] [varchar](500) NOT NULL,
	[Cost] [float] NOT NULL,
	[Note] [varchar](1000) NULL,
 CONSTRAINT [XPKTypeReklama] PRIMARY KEY CLUSTERED 
(
	[IDTypeReklama] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1TypeReklama] UNIQUE NONCLUSTERED 
(
	[IDTypeReklama] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Carrier]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Carrier](
	[IDCarrier] [int] IDENTITY(1,1) NOT NULL,
	[NameCarrier] [varchar](100) NOT NULL,
	[TimeCarrier] [varchar](20) NOT NULL,
 CONSTRAINT [XPKCarrier] PRIMARY KEY CLUSTERED 
(
	[IDCarrier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [XAK1Carrier] UNIQUE NONCLUSTERED 
(
	[IDCarrier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Praylist]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Praylist](NameReklama,Position,Cost,NameCarrier)
AS
SELECT TypeReklama.NameReklama,TypeReklama.Position,TypeReklama.Cost,Carrier.NameCarrier
	FROM TypeReklama,Carrier
		WHERE Carrier.IDCarrier = TypeReklama.IDCarrier
GO
/****** Object:  View [dbo].[OrdersReport]    Script Date: 08/01/2017 20:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrdersReport](NameCarrier,NameReklama,NameEnterprise,StartDate,FinallyDate,Cost,IDEnterprise)
AS
SELECT Carrier.NameCarrier,TypeReklama.NameReklama,Enterprises.NameEnterprise,Orders.StartDate,Orders.FinallyDate,Orders.Cost,Enterprises.IDEnterprise
	FROM Orders,Enterprises,TypeReklama,Carrier
		WHERE Carrier.IDCarrier = TypeReklama.IDCarrier and Enterprises.IDEnterprise=Orders.IDEnterprise and TypeReklama.IDTypeReklama = Orders.IDTypeReklama
GO
/****** Object:  ForeignKey [R_6]    Script Date: 08/01/2017 20:37:33 ******/
ALTER TABLE [dbo].[Wage]  WITH CHECK ADD  CONSTRAINT [R_6] FOREIGN KEY([IDManager])
REFERENCES [dbo].[Managers] ([IDManager])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wage] CHECK CONSTRAINT [R_6]
GO
/****** Object:  ForeignKey [R_2]    Script Date: 08/01/2017 20:37:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [R_2] FOREIGN KEY([IDEnterprise])
REFERENCES [dbo].[Enterprises] ([IDEnterprise])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [R_2]
GO
/****** Object:  ForeignKey [R_3]    Script Date: 08/01/2017 20:37:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [R_3] FOREIGN KEY([IDTypeReklama])
REFERENCES [dbo].[TypeReklama] ([IDTypeReklama])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [R_3]
GO
/****** Object:  ForeignKey [R_4]    Script Date: 08/01/2017 20:37:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [R_4] FOREIGN KEY([IDManager])
REFERENCES [dbo].[Managers] ([IDManager])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [R_4]
GO
/****** Object:  ForeignKey [R_1]    Script Date: 08/01/2017 20:37:34 ******/
ALTER TABLE [dbo].[TypeReklama]  WITH CHECK ADD  CONSTRAINT [R_1] FOREIGN KEY([IDCarrier])
REFERENCES [dbo].[Carrier] ([IDCarrier])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeReklama] CHECK CONSTRAINT [R_1]
GO
