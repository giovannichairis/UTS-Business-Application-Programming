USE [master]
GO
/****** Object:  Database [DB_DATA]    Script Date: 18/11/2020 16:52:32 ******/
CREATE DATABASE [DB_DATA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_DATA', FILENAME = N'D:\food\DB_DATA.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_DATA_log', FILENAME = N'D:\food\DB_DATA_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_DATA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_DATA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_DATA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_DATA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_DATA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_DATA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_DATA] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_DATA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_DATA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_DATA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_DATA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_DATA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_DATA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_DATA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_DATA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_DATA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_DATA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_DATA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_DATA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_DATA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_DATA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_DATA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_DATA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_DATA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_DATA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_DATA] SET  MULTI_USER 
GO
ALTER DATABASE [DB_DATA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_DATA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_DATA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_DATA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_DATA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_DATA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_DATA] SET QUERY_STORE = OFF
GO
USE [DB_DATA]
GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 18/11/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category](
	[cat_id] [int] NOT NULL,
	[cat_name] [varchar](max) NOT NULL,
	[cat_desc] [varchar](max) NULL,
	[cat_image] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_dbill]    Script Date: 18/11/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_dbill](
	[bill_id] [int] NOT NULL,
	[menu_id] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
	[total] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_hbill]    Script Date: 18/11/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_hbill](
	[bill_id] [int] IDENTITY(1,1) NOT NULL,
	[table_id] [nchar](10) NOT NULL,
	[date_add] [smalldatetime] NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
	[tax] [decimal](18, 2) NOT NULL,
	[grand_total] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_menu]    Script Date: 18/11/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_menu](
	[menu_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_id] [nchar](10) NULL,
	[name] [varchar](max) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[image] [image] NULL,
	[qty_jual] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 18/11/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order](
	[table_id] [nchar](10) NOT NULL,
	[menu_id] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[status] [varchar](1) NOT NULL,
	[date_ordered] [smalldatetime] NOT NULL,
	[date_closed] [smalldatetime] NULL,
	[date_billed] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 18/11/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[username] [nchar](10) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'O: ordered (ongoing order); C: closed (bill requested); B: billed (bill printed);' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_order', @level2type=N'COLUMN',@level2name=N'status'
GO
USE [master]
GO
ALTER DATABASE [DB_DATA] SET  READ_WRITE 
GO
