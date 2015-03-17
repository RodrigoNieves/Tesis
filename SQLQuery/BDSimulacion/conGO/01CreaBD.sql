USE [SimulacionKarelotitlan]
GO
ALTER TABLE [dbo].[UsuarioProblema] DROP CONSTRAINT [FK_UsuarioProblema_Usuario]
GO
ALTER TABLE [dbo].[UsuarioProblema] DROP CONSTRAINT [FK_UsuarioProblema_Problema]
GO
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_OMI]
GO
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Estado]
GO
ALTER TABLE [dbo].[Recomendacion] DROP CONSTRAINT [FK_Recomendacion_Usuario]
GO
ALTER TABLE [dbo].[Recomendacion] DROP CONSTRAINT [FK_Recomendacion_Problema]
GO
ALTER TABLE [dbo].[Recomendacion] DROP CONSTRAINT [FK_Recomendacion_Algoritmo]
GO
ALTER TABLE [dbo].[Problema] DROP CONSTRAINT [FK_Problema_Clasificacion]
GO
ALTER TABLE [dbo].[Evento] DROP CONSTRAINT [FK_Evento_TipoEvento]
GO
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[UsuarioProblema]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[TipoEvento]
GO
/****** Object:  Table [dbo].[Recomendacion]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Recomendacion]
GO
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[problemaDificultad]
GO
/****** Object:  Table [dbo].[Problema]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Problema]
GO
/****** Object:  Table [dbo].[OMI]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[OMI]
GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Nivel]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Evento]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Estado]
GO
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Clasificacion]
GO
/****** Object:  Table [dbo].[Algoritmo]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Algoritmo]
GO
USE [master]
GO
/****** Object:  Database [SimulacionKarelotitlan]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP DATABASE [SimulacionKarelotitlan]
GO
/****** Object:  Database [SimulacionKarelotitlan]    Script Date: 17/03/2015 01:19:26 p.m. ******/
CREATE DATABASE [SimulacionKarelotitlan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimulacionKarelotitlan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SimulacionKarelotitlan.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimulacionKarelotitlan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SimulacionKarelotitlan_log.ldf' , SIZE = 32448KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SimulacionKarelotitlan] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimulacionKarelotitlan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET RECOVERY FULL 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET  MULTI_USER 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimulacionKarelotitlan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimulacionKarelotitlan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SimulacionKarelotitlan]
GO
/****** Object:  Table [dbo].[Algoritmo]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Algoritmo](
	[AlgoritmoID] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Algoritmo] PRIMARY KEY CLUSTERED 
(
	[AlgoritmoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clasificacion](
	[clave] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tiempo] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[url] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Clasificacion] PRIMARY KEY CLUSTERED 
(
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[clave] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[tipoEvento] [int] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
	[infoExtra] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nivel](
	[idNivel] [int] NOT NULL,
	[nombre] [text] NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Nivel] PRIMARY KEY CLUSTERED 
(
	[idNivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OMI]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OMI](
	[OMI] [int] NOT NULL,
	[lugar] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OMI] PRIMARY KEY CLUSTERED 
(
	[OMI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Problema]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Problema](
	[clave] [int] IDENTITY(12843,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[origen] [varchar](50) NOT NULL,
	[clasificacion] [int] NOT NULL,
	[owner] [int] NOT NULL,
	[status] [int] NOT NULL,
	[bloqueado] [bit] NOT NULL,
	[dificultad] [int] NOT NULL,
 CONSTRAINT [PK_Problema] PRIMARY KEY CLUSTERED 
(
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[problemaDificultad](
	[problema] [int] NULL,
	[dificultad] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recomendacion]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recomendacion](
	[algoritmo] [int] NOT NULL,
	[usuario] [int] NOT NULL,
	[problema] [int] NOT NULL,
	[resolvio] [tinyint] NOT NULL,
	[timestamp] [timestamp] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvento](
	[id] [int] NOT NULL,
	[nombre] [nchar](100) NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_TipoEvento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[clave] [int] IDENTITY(1,1) NOT NULL,
	[nombreReal] [varchar](70) NOT NULL,
	[nombreUsuario] [varchar](30) NOT NULL,
	[password] [varbinary](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
	[sexo] [bit] NOT NULL,
	[pregunta] [int] NOT NULL,
	[respuesta] [varchar](50) NOT NULL,
	[lang] [bit] NOT NULL,
	[omi] [int] NOT NULL,
	[recibirEmail] [bit] NOT NULL,
	[asesor] [int] NOT NULL,
	[logged] [smallint] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioProblema](
	[usuario] [int] NOT NULL,
	[problema] [int] NOT NULL,
	[puntos] [int] NOT NULL,
	[hora] [bigint] NOT NULL,
	[primero] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioProblema] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[problema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_TipoEvento] FOREIGN KEY([tipoEvento])
REFERENCES [dbo].[TipoEvento] ([id])
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_Evento_TipoEvento]
GO
ALTER TABLE [dbo].[Problema]  WITH CHECK ADD  CONSTRAINT [FK_Problema_Clasificacion] FOREIGN KEY([clasificacion])
REFERENCES [dbo].[Clasificacion] ([clave])
GO
ALTER TABLE [dbo].[Problema] CHECK CONSTRAINT [FK_Problema_Clasificacion]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Algoritmo] FOREIGN KEY([algoritmo])
REFERENCES [dbo].[Algoritmo] ([AlgoritmoID])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Algoritmo]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Problema] FOREIGN KEY([problema])
REFERENCES [dbo].[Problema] ([clave])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Problema]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([clave])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Estado] FOREIGN KEY([estado])
REFERENCES [dbo].[Estado] ([clave])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Estado]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_OMI] FOREIGN KEY([omi])
REFERENCES [dbo].[OMI] ([OMI])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_OMI]
GO
ALTER TABLE [dbo].[UsuarioProblema]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProblema_Problema] FOREIGN KEY([problema])
REFERENCES [dbo].[Problema] ([clave])
GO
ALTER TABLE [dbo].[UsuarioProblema] CHECK CONSTRAINT [FK_UsuarioProblema_Problema]
GO
ALTER TABLE [dbo].[UsuarioProblema]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProblema_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([clave])
GO
ALTER TABLE [dbo].[UsuarioProblema] CHECK CONSTRAINT [FK_UsuarioProblema_Usuario]
GO
USE [master]
GO
ALTER DATABASE [SimulacionKarelotitlan] SET  READ_WRITE 
GO
