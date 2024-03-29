USE [master]
GO
/****** Object:  Database [test]    Script Date: 28.10.2013 17:07:19 ******/
CREATE DATABASE [test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\test.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\test_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [test] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test] SET ARITHABORT OFF 
GO
ALTER DATABASE [test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test] SET  ENABLE_BROKER 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test] SET RECOVERY FULL 
GO
ALTER DATABASE [test] SET  MULTI_USER 
GO
ALTER DATABASE [test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [test]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeesList]    Script Date: 28.10.2013 17:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Andrey Nikolaev
-- Create date: 26-10-2013
-- Description:	Получение списка сотрудников в необходимом формате
-- =============================================
CREATE PROCEDURE [dbo].[GetEmployeesList] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [last_name]+' '+left([first_name],1)+'.'+left([second_name],1)+'.' emp_fullname,
		s.[name] emp_status, d.[name] emp_dept, ps.[name] emp_post, 
		coalesce(format([date_employ], 'yyyy-MM-dd'), '') date_emp, 
		coalesce(format([date_uneploy], 'yyyy-MM-dd'), '') date_unemp
	FROM [dbo].[persons] p join [dbo].[status] s on p.status=s.id 
		join [dbo].[deps] d on p.id_dep=d.id
		join [dbo].[posts] ps on p.id_post=ps.id
END

GO
/****** Object:  StoredProcedure [dbo].[GetEmpsStats]    Script Date: 28.10.2013 17:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Andrey Nikolaev
-- Create date: 2013-10-26
-- Description:	Получение статистики по сотрудникам
-- =============================================
CREATE PROCEDURE [dbo].[GetEmpsStats] 
	-- Add the parameters for the stored procedure here
	@per_begin datetime = 0, 
	@per_end datetime = 0,
	@need_status varchar(100) = '',
	@hire_status int = 0
	/* @hire_status: 0-принятые на работу, иначе - уволенные */
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF (@hire_status = 0) 
		SELECT format([date_employ], 'yyyy-MM-dd') date_per, COUNT([first_name]) emp_cou
		FROM [dbo].[persons] p join [dbo].[status] s on p.status = s.id
		WHERE ([date_employ] is not null and [date_uneploy] is null)
			and [date_employ] between @per_begin and @per_end
			and s.[name] = @need_status
		GROUP BY [date_employ]
	ELSE
		SELECT format([date_uneploy], 'yyyy-MM-dd') date_per, COUNT([first_name]) emp_cou
		FROM [dbo].[persons] p join [dbo].[status] s on p.status = s.id
		WHERE ([date_employ] is not null and [date_uneploy] is not null)
			and [date_uneploy] between @per_begin and @per_end
			and s.[name] = @need_status
		GROUP BY [date_uneploy]
END

GO
/****** Object:  Table [dbo].[deps]    Script Date: 28.10.2013 17:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[deps](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_deps] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[persons]    Script Date: 28.10.2013 17:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[persons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](100) NOT NULL,
	[second_name] [varchar](100) NOT NULL,
	[last_name] [varchar](100) NOT NULL,
	[date_employ] [datetime] NULL,
	[date_uneploy] [datetime] NULL,
	[status] [int] NOT NULL,
	[id_dep] [int] NOT NULL,
	[id_post] [int] NOT NULL,
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[posts]    Script Date: 28.10.2013 17:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[posts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[status]    Script Date: 28.10.2013 17:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[deps] ON 

GO
INSERT [dbo].[deps] ([id], [name]) VALUES (1, N'АХО')
GO
INSERT [dbo].[deps] ([id], [name]) VALUES (2, N'Администрация')
GO
INSERT [dbo].[deps] ([id], [name]) VALUES (3, N'Бухгалтерия')
GO
INSERT [dbo].[deps] ([id], [name]) VALUES (4, N'Грузчики')
GO
SET IDENTITY_INSERT [dbo].[deps] OFF
GO
SET IDENTITY_INSERT [dbo].[persons] ON 

GO
INSERT [dbo].[persons] ([id], [first_name], [second_name], [last_name], [date_employ], [date_uneploy], [status], [id_dep], [id_post]) VALUES (3, N'Иван', N'Иванович', N'Иванов', CAST(0x000095DA00000000 AS DateTime), NULL, 1, 2, 1)
GO
INSERT [dbo].[persons] ([id], [first_name], [second_name], [last_name], [date_employ], [date_uneploy], [status], [id_dep], [id_post]) VALUES (4, N'Анна', N'Михайловна', N'Петрова', CAST(0x000095DA00000000 AS DateTime), NULL, 1, 1, 2)
GO
INSERT [dbo].[persons] ([id], [first_name], [second_name], [last_name], [date_employ], [date_uneploy], [status], [id_dep], [id_post]) VALUES (10, N'Григорий', N'Михайлович', N'Сидоров', CAST(0x00009E1500000000 AS DateTime), NULL, 2, 4, 6)
GO
INSERT [dbo].[persons] ([id], [first_name], [second_name], [last_name], [date_employ], [date_uneploy], [status], [id_dep], [id_post]) VALUES (11, N'Сергей', N'Викторович', N'Михайлов', CAST(0x00009E1500000000 AS DateTime), CAST(0x00009FC400000000 AS DateTime), 3, 4, 6)
GO
INSERT [dbo].[persons] ([id], [first_name], [second_name], [last_name], [date_employ], [date_uneploy], [status], [id_dep], [id_post]) VALUES (12, N'Ирина', N'Вячеславовна', N'Терехина', CAST(0x00009AAC00000000 AS DateTime), NULL, 1, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[persons] OFF
GO
SET IDENTITY_INSERT [dbo].[posts] ON 

GO
INSERT [dbo].[posts] ([id], [name]) VALUES (1, N'Директор')
GO
INSERT [dbo].[posts] ([id], [name]) VALUES (2, N'Главный бухгалтер')
GO
INSERT [dbo].[posts] ([id], [name]) VALUES (3, N'Секретарь')
GO
INSERT [dbo].[posts] ([id], [name]) VALUES (4, N'Продавец')
GO
INSERT [dbo].[posts] ([id], [name]) VALUES (5, N'Администратор')
GO
INSERT [dbo].[posts] ([id], [name]) VALUES (6, N'Грузчик')
GO
INSERT [dbo].[posts] ([id], [name]) VALUES (7, N'Программист')
GO
SET IDENTITY_INSERT [dbo].[posts] OFF
GO
SET IDENTITY_INSERT [dbo].[status] ON 

GO
INSERT [dbo].[status] ([id], [name]) VALUES (1, N'статус 1')
GO
INSERT [dbo].[status] ([id], [name]) VALUES (2, N'статус 2')
GO
INSERT [dbo].[status] ([id], [name]) VALUES (3, N'статус 3')
GO
SET IDENTITY_INSERT [dbo].[status] OFF
GO
USE [master]
GO
ALTER DATABASE [test] SET  READ_WRITE 
GO
