USE [master]
GO
/****** Object:  Database [Schad]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE DATABASE [Schad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Schad', FILENAME = N'D:\Databases\SQL Server\Data\Schad.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Schad_log', FILENAME = N'D:\Databases\SQL Server\Data\Schad_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Schad] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Schad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Schad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Schad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Schad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Schad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Schad] SET ARITHABORT OFF 
GO
ALTER DATABASE [Schad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Schad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Schad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Schad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Schad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Schad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Schad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Schad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Schad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Schad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Schad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Schad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Schad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Schad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Schad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Schad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Schad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Schad] SET RECOVERY FULL 
GO
ALTER DATABASE [Schad] SET  MULTI_USER 
GO
ALTER DATABASE [Schad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Schad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Schad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Schad] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Schad] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Schad', N'ON'
GO
USE [Schad]
GO
/****** Object:  User [Schad]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE USER [Schad] FOR LOGIN [Schad] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Schad]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Schad]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Schad]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL DEFAULT (CONVERT([bit],(1))),
	[CustomerTypeId] [int] NOT NULL,
	[Rnc] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerTypes]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTypes](
	[CustomerTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL DEFAULT (CONVERT([bit],(1))),
 CONSTRAINT [PK_CustomerTypes] PRIMARY KEY CLUSTERED 
(
	[CustomerTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[InvoiceDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[InvoiceId] [bigint] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[Ncf] [nvarchar](40) NULL,
	[Itbis] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[InvoiceDate] [datetime2](7) NOT NULL DEFAULT ('2023-02-19T14:43:41.2221040-04:00'),
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NcfSequences]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NcfSequences](
	[SequenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[Serie] [nvarchar](10) NOT NULL,
	[VoucherType] [nvarchar](25) NOT NULL,
	[StartSequence] [int] NOT NULL,
	[EndSequence] [int] NOT NULL,
	[LastUsedSequence] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL DEFAULT ('2023-02-19T14:43:41.2220843-04:00'),
	[LastUpdateDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL DEFAULT (CONVERT([bit],(1))),
 CONSTRAINT [PK_NcfSequences] PRIMARY KEY CLUSTERED 
(
	[SequenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/19/2023 5:20:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](600) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ProductCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[Stock] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Customers_CustomerTypeId]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customers_CustomerTypeId] ON [dbo].[Customers]
(
	[CustomerTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetails_InvoiceId]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetails_InvoiceId] ON [dbo].[InvoiceDetails]
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetails_ProductId]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetails_ProductId] ON [dbo].[InvoiceDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoices_CustomerId]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoices_CustomerId] ON [dbo].[Invoices]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ProductCategoryId]    Script Date: 2/19/2023 5:20:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProductCategoryId] ON [dbo].[Products]
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerTypes_CustomerTypeId] FOREIGN KEY([CustomerTypeId])
REFERENCES [dbo].[CustomerTypes] ([CustomerTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerTypes_CustomerTypeId]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategories] ([ProductCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories_ProductCategoryId]
GO
USE [master]
GO
ALTER DATABASE [Schad] SET  READ_WRITE 
GO
