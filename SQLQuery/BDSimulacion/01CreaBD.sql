USE [SimulacionKarelotitlan]
 
ALTER TABLE [dbo].[UsuarioProblema] DROP CONSTRAINT [FK_UsuarioProblema_Usuario]
 
ALTER TABLE [dbo].[UsuarioProblema] DROP CONSTRAINT [FK_UsuarioProblema_Problema]
 
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_OMI]
 
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Estado]
 
ALTER TABLE [dbo].[Recomendacion] DROP CONSTRAINT [FK_Recomendacion_Usuario]
 
ALTER TABLE [dbo].[Recomendacion] DROP CONSTRAINT [FK_Recomendacion_Problema]
 
ALTER TABLE [dbo].[Recomendacion] DROP CONSTRAINT [FK_Recomendacion_Algoritmo]
 
ALTER TABLE [dbo].[Problema] DROP CONSTRAINT [FK_Problema_Clasificacion]
 
ALTER TABLE [dbo].[Evento] DROP CONSTRAINT [FK_Evento_TipoEvento]
 
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[UsuarioProblema]
 
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Usuario]
 
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[TipoEvento]
 
/****** Object:  Table [dbo].[Recomendacion]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Recomendacion]
 
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[problemaDificultad]
 
/****** Object:  Table [dbo].[Problema]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Problema]
 
/****** Object:  Table [dbo].[OMI]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[OMI]
 
/****** Object:  Table [dbo].[Nivel]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Nivel]
 
/****** Object:  Table [dbo].[Evento]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Evento]
 
/****** Object:  Table [dbo].[Estado]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Estado]
 
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Clasificacion]
 
/****** Object:  Table [dbo].[Algoritmo]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP TABLE [dbo].[Algoritmo]
 
USE [master]
 
/****** Object:  Database [SimulacionKarelotitlan]    Script Date: 17/03/2015 01:19:26 p.m. ******/
DROP DATABASE [SimulacionKarelotitlan]
 
/****** Object:  Database [SimulacionKarelotitlan]    Script Date: 17/03/2015 01:19:26 p.m. ******/
CREATE DATABASE [SimulacionKarelotitlan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimulacionKarelotitlan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SimulacionKarelotitlan.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimulacionKarelotitlan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SimulacionKarelotitlan_log.ldf' , SIZE = 32448KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 
ALTER DATABASE [SimulacionKarelotitlan] SET COMPATIBILITY_LEVEL = 110
 
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimulacionKarelotitlan].[dbo].[sp_fulltext_database] @action = 'enable'
end
 
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_NULL_DEFAULT OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_NULLS OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_PADDING OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET ANSI_WARNINGS OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET ARITHABORT OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_CLOSE OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_CREATE_STATISTICS ON 
 
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_SHRINK OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_UPDATE_STATISTICS ON 
 
ALTER DATABASE [SimulacionKarelotitlan] SET CURSOR_CLOSE_ON_COMMIT OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET CURSOR_DEFAULT  GLOBAL 
 
ALTER DATABASE [SimulacionKarelotitlan] SET CONCAT_NULL_YIELDS_NULL OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET NUMERIC_ROUNDABORT OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET QUOTED_IDENTIFIER OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET RECURSIVE_TRIGGERS OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET  DISABLE_BROKER 
 
ALTER DATABASE [SimulacionKarelotitlan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET DATE_CORRELATION_OPTIMIZATION OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET TRUSTWORTHY OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET PARAMETERIZATION SIMPLE 
 
ALTER DATABASE [SimulacionKarelotitlan] SET READ_COMMITTED_SNAPSHOT OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET HONOR_BROKER_PRIORITY OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET RECOVERY FULL 
 
ALTER DATABASE [SimulacionKarelotitlan] SET  MULTI_USER 
 
ALTER DATABASE [SimulacionKarelotitlan] SET PAGE_VERIFY CHECKSUM  
 
ALTER DATABASE [SimulacionKarelotitlan] SET DB_CHAINING OFF 
 
ALTER DATABASE [SimulacionKarelotitlan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
 
ALTER DATABASE [SimulacionKarelotitlan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
 
USE [SimulacionKarelotitlan]
 
/****** Object:  Table [dbo].[Algoritmo]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
SET ANSI_PADDING ON
 
CREATE TABLE [dbo].[Algoritmo](
	[AlgoritmoID] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Algoritmo] PRIMARY KEY CLUSTERED 
(
	[AlgoritmoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

 
SET ANSI_PADDING OFF
 
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
SET ANSI_PADDING ON
 
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

 
SET ANSI_PADDING OFF
 
/****** Object:  Table [dbo].[Estado]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
SET ANSI_PADDING ON
 
CREATE TABLE [dbo].[Estado](
	[clave] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

 
SET ANSI_PADDING OFF
 
/****** Object:  Table [dbo].[Evento]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Evento](
	[tipoEvento] [int] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
	[infoExtra] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

 
/****** Object:  Table [dbo].[Nivel]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Nivel](
	[idNivel] [int] NOT NULL,
	[nombre] [text] NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Nivel] PRIMARY KEY CLUSTERED 
(
	[idNivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

 
/****** Object:  Table [dbo].[OMI]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
SET ANSI_PADDING ON
 
CREATE TABLE [dbo].[OMI](
	[OMI] [int] NOT NULL,
	[lugar] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OMI] PRIMARY KEY CLUSTERED 
(
	[OMI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

 
SET ANSI_PADDING OFF
 
/****** Object:  Table [dbo].[Problema]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
SET ANSI_PADDING ON
 
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

 
SET ANSI_PADDING OFF
 
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[problemaDificultad](
	[problema] [int] NULL,
	[dificultad] [int] NULL
) ON [PRIMARY]

 
/****** Object:  Table [dbo].[Recomendacion]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[Recomendacion](
	[algoritmo] [int] NOT NULL,
	[usuario] [int] NOT NULL,
	[problema] [int] NOT NULL,
	[resolvio] [tinyint] NOT NULL,
	[timestamp] [timestamp] NOT NULL
) ON [PRIMARY]

 
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[TipoEvento](
	[id] [int] NOT NULL,
	[nombre] [nchar](100) NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_TipoEvento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

 
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
SET ANSI_PADDING ON
 
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

 
SET ANSI_PADDING OFF
 
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 17/03/2015 01:19:27 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
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

 
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_TipoEvento] FOREIGN KEY([tipoEvento])
REFERENCES [dbo].[TipoEvento] ([id])
 
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_Evento_TipoEvento]
 
ALTER TABLE [dbo].[Problema]  WITH CHECK ADD  CONSTRAINT [FK_Problema_Clasificacion] FOREIGN KEY([clasificacion])
REFERENCES [dbo].[Clasificacion] ([clave])
 
ALTER TABLE [dbo].[Problema] CHECK CONSTRAINT [FK_Problema_Clasificacion]
 
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Algoritmo] FOREIGN KEY([algoritmo])
REFERENCES [dbo].[Algoritmo] ([AlgoritmoID])
 
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Algoritmo]
 
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Problema] FOREIGN KEY([problema])
REFERENCES [dbo].[Problema] ([clave])
 
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Problema]
 
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([clave])
 
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Usuario]
 
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Estado] FOREIGN KEY([estado])
REFERENCES [dbo].[Estado] ([clave])
 
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Estado]
 
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_OMI] FOREIGN KEY([omi])
REFERENCES [dbo].[OMI] ([OMI])
 
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_OMI]
 
ALTER TABLE [dbo].[UsuarioProblema]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProblema_Problema] FOREIGN KEY([problema])
REFERENCES [dbo].[Problema] ([clave])
 
ALTER TABLE [dbo].[UsuarioProblema] CHECK CONSTRAINT [FK_UsuarioProblema_Problema]
 
ALTER TABLE [dbo].[UsuarioProblema]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProblema_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([clave])
 
ALTER TABLE [dbo].[UsuarioProblema] CHECK CONSTRAINT [FK_UsuarioProblema_Usuario]
 
USE [master]
 
ALTER DATABASE [SimulacionKarelotitlan] SET  READ_WRITE 
 
