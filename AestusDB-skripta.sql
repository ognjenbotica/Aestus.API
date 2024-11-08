USE [master]
GO
/****** Object:  Database [AestusDB]    Script Date: 6.11.2024. 15:52:46 ******/
CREATE DATABASE [AestusDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AestusDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AestusDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AestusDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AestusDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AestusDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AestusDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AestusDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AestusDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AestusDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AestusDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AestusDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AestusDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AestusDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AestusDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AestusDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AestusDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AestusDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AestusDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AestusDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AestusDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AestusDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AestusDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AestusDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AestusDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AestusDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AestusDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AestusDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AestusDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AestusDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AestusDB] SET  MULTI_USER 
GO
ALTER DATABASE [AestusDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AestusDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AestusDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AestusDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AestusDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AestusDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AestusDB', N'ON'
GO
ALTER DATABASE [AestusDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [AestusDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AestusDB]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 6.11.2024. 15:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingID] [int] IDENTITY(1,1) NOT NULL,
	[SettingName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SettingVersions]    Script Date: 6.11.2024. 15:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SettingVersions](
	[VersionID] [int] IDENTITY(1,1) NOT NULL,
	[SettingID] [int] NULL,
	[Value] [decimal](5, 2) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VersionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([SettingID], [SettingName]) VALUES (1, N'profit_tax')
INSERT [dbo].[Settings] ([SettingID], [SettingName]) VALUES (2, N'sales_tax')
INSERT [dbo].[Settings] ([SettingID], [SettingName]) VALUES (3, N'vat_rate')
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[SettingVersions] ON 

INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (1, 1, CAST(12.00 AS Decimal(5, 2)), CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2021-12-31T23:59:59.000' AS DateTime))
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (2, 1, CAST(10.00 AS Decimal(5, 2)), CAST(N'2022-01-01T00:00:00.000' AS DateTime), CAST(N'2023-12-31T23:59:59.000' AS DateTime))
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (3, 1, CAST(8.50 AS Decimal(5, 2)), CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (4, 2, CAST(15.00 AS Decimal(5, 2)), CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2020-12-31T23:59:59.000' AS DateTime))
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (5, 2, CAST(14.00 AS Decimal(5, 2)), CAST(N'2021-01-01T00:00:00.000' AS DateTime), CAST(N'2022-12-31T23:59:59.000' AS DateTime))
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (6, 2, CAST(13.50 AS Decimal(5, 2)), CAST(N'2023-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (7, 3, CAST(20.00 AS Decimal(5, 2)), CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T23:59:59.000' AS DateTime))
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (8, 3, CAST(19.00 AS Decimal(5, 2)), CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2021-12-31T23:59:59.000' AS DateTime))
INSERT [dbo].[SettingVersions] ([VersionID], [SettingID], [Value], [StartDate], [EndDate]) VALUES (9, 3, CAST(18.50 AS Decimal(5, 2)), CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[SettingVersions] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Settings__BCA5D463F533DA14]    Script Date: 6.11.2024. 15:52:47 ******/
ALTER TABLE [dbo].[Settings] ADD UNIQUE NONCLUSTERED 
(
	[SettingName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_SettingVersion]    Script Date: 6.11.2024. 15:52:47 ******/
ALTER TABLE [dbo].[SettingVersions] ADD  CONSTRAINT [UQ_SettingVersion] UNIQUE NONCLUSTERED 
(
	[SettingID] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SettingVersions]  WITH CHECK ADD FOREIGN KEY([SettingID])
REFERENCES [dbo].[Settings] ([SettingID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SettingVersions]  WITH CHECK ADD  CONSTRAINT [CK_DateOrder] CHECK  (([StartDate]<isnull([EndDate],'9999-12-31 23:59:59')))
GO
ALTER TABLE [dbo].[SettingVersions] CHECK CONSTRAINT [CK_DateOrder]
GO
USE [master]
GO
ALTER DATABASE [AestusDB] SET  READ_WRITE 
GO
