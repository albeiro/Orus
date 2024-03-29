USE [master]
GO
/****** Object:  Database [orus369]    Script Date: 8/7/2021 10:26:23 ******/
CREATE DATABASE [orus369]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'orus369', FILENAME = N'J:\Program\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\orus369.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'orus369_log', FILENAME = N'J:\Program\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\orus369_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [orus369] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [orus369].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [orus369] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [orus369] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [orus369] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [orus369] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [orus369] SET ARITHABORT OFF 
GO
ALTER DATABASE [orus369] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [orus369] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [orus369] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [orus369] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [orus369] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [orus369] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [orus369] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [orus369] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [orus369] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [orus369] SET  DISABLE_BROKER 
GO
ALTER DATABASE [orus369] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [orus369] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [orus369] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [orus369] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [orus369] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [orus369] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [orus369] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [orus369] SET RECOVERY FULL 
GO
ALTER DATABASE [orus369] SET  MULTI_USER 
GO
ALTER DATABASE [orus369] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [orus369] SET DB_CHAINING OFF 
GO
ALTER DATABASE [orus369] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [orus369] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [orus369] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [orus369] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'orus369', N'ON'
GO
ALTER DATABASE [orus369] SET QUERY_STORE = OFF
GO
USE [orus369]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](120) NULL,
	[SueldoPorHora] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [nvarchar](max) NULL,
	[Nombres] [nvarchar](max) NULL,
	[Pais] [nvarchar](max) NULL,
	[CargoId] [int] NULL,
	[SueldoPorHora] [numeric](18, 2) NULL,
	[Codigo] [int] NULL,
	[Estado] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Cargo] FOREIGN KEY([Id])
REFERENCES [dbo].[Cargo] ([Id])
GO
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Cargo]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Personal] FOREIGN KEY([CargoId])
REFERENCES [dbo].[Cargo] ([Id])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [FK_Personal_Personal]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeletePersonal]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Delete personal, the file  estado is update to Eliminado>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_DeletePersonal]
	@Id int
AS
	UPDATE Personal SET Estado = 'Eliminado'
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertCargo]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Insert into Cargo>
-- =============================================
Create PROCEDURE [dbo].[Sp_InsertCargo]
	@Nombre nvarchar(120),
	@SueldoPorHora numeric(18,2)
AS

IF EXISTS(SELECT Nombre FROM Cargo WHERE Nombre = @Nombre)
	Raiserror('Ya existe un cargo con este nombre',16,1)
ELSE
	INSERT INTO Cargo VALUES(
		@Nombre,
		@SueldoPorHora
	)
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertPersonal]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Inserter into Personal>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_InsertPersonal]
	@Identificacion nvarchar(max),
	@Nombre nvarchar(120),
	@Pais nvarchar(max),
	@CargoId nvarchar(max),
	@SueldoPorHora numeric(18,2)
AS

DECLARE @Codigo nvarchar(max) = (SELECT max(codigo)+1 FROM Personal);
DECLARE @Estado nvarchar(max) = 'Activo'

IF EXISTS(SELECT Identificacion FROM Personal WHERE Identificacion= @Identificacion)
	Raiserror('Ya existe un funcionario con esta identificación',16,1)
ELSE
	INSERT INTO Personal VALUES(
		@Identificacion,
		@Nombre,
		@Pais,
		@CargoId,
		@SueldoPorHora,
		@Codigo,
		@Estado
	)
GO
/****** Object:  StoredProcedure [dbo].[Sp_SearchCargo]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Update Cargo>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_SearchCargo]
	@Deste int,
	@Hasta int,
	@Buscar nvarchar(max)
AS
Set Nocount on;	

SELECT *
FROM(
	SELECT Cargo.Id, Cargo.Nombre,
	ROW_NUMBER() over (order by Cargo.Id)'NumeroFila'
	FROM Cargo 
) as paginado
WHERE paginado.NumeroFila >= @Deste and
	paginado.NumeroFila <= @Hasta and 
	paginado.Nombre like '%'+ @Buscar +'%' 

GO
/****** Object:  StoredProcedure [dbo].[Sp_SearchPersonal]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Update personal>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_SearchPersonal]
	@Deste int,
	@Hasta int,
	@Buscar nvarchar(max)
AS
Set Nocount on;	

SELECT *
FROM(
	SELECT Personal.Id, Personal.Identificacion, Personal.Nombres, Cargo.Nombre, Personal.CargoId,
	ROW_NUMBER() over (order by Personal.id)'NumeroFila'
	FROM Personal
	INNER JOIN Cargo ON Personal.CargoId = Cargo.Id
) as paginado
WHERE paginado.NumeroFila >= @Deste and
	paginado.NumeroFila <= @Hasta and 
	paginado.Identificacion + paginado.Nombres like '%'+ @Buscar +'%' 

GO
/****** Object:  StoredProcedure [dbo].[Sp_ShowPersonal]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Update personal>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_ShowPersonal]
	@Deste int,
	@Hasta int
AS
Set Nocount on;	

SELECT *
FROM(
	SELECT Personal.Id, Personal.Identificacion, Personal.Nombres, Cargo.Nombre, Personal.CargoId,
	ROW_NUMBER() over (order by Personal.id)'NumeroFila'
	FROM Personal
	INNER JOIN Cargo ON Personal.CargoId = Cargo.Id
) as paginado
WHERE paginado.NumeroFila >= @Deste and
	paginado.NumeroFila <= @Hasta
--WHERE Personal.Identificacion+Personal.Nombres 
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdatePersonal]    Script Date: 8/7/2021 10:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jesus GAviria>
-- Create date: <07/07/2021>
-- Description:	<Update personal>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_UpdatePersonal]
	@Id int,
	@Identificacion nvarchar(max),
	@Nombres nvarchar(max),
	@Pais nvarchar(max),
	@CargoId nvarchar(max),
	@SueldoPorHora numeric(18,2),
	@Estado nvarchar(50)
AS
IF EXISTS(SELECT Identificacion FROM Personal WHERE Identificacion = @Identificacion and Id <> @Id )
	Raiserror('Ya existe un registro con esta identificacion',16,1)
ELSE
	UPDATE Personal SET
		Identificacion = @Identificacion,
		Nombres = @Nombres,
		Pais = @Pais,
		CargoId = @CargoId,
		SueldoPorHora = @SueldoPorHora,
		Estado = @Estado
	
GO
USE [master]
GO
ALTER DATABASE [orus369] SET  READ_WRITE 
GO
