USE [master]
GO
/****** Object:  Database [SimulacionKarelotitlan]    Script Date: 20/05/2015 01:53:01 p. m. ******/
CREATE DATABASE [SimulacionKarelotitlan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimulacionKarelotitlan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SimulacionKarelotitlan.mdf' , SIZE = 269312KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimulacionKarelotitlan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SimulacionKarelotitlan_log.ldf' , SIZE = 4211392KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Algoritmo]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Algoritmo](
	[id] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Algoritmo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[Estado]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[Evento]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSimulacion] [int] NOT NULL,
	[tipoEvento] [int] NOT NULL,
	[timestamp] [datetime2](7) NOT NULL,
	[comentario] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpertoRecomendacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpertoRecomendacion](
	[usuario] [int] NOT NULL,
	[problema] [int] NOT NULL,
	[tiempo] [int] NOT NULL,
 CONSTRAINT [PK_ExpertoRecomendacion] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[problema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inversion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inversion](
	[u1] [int] NOT NULL,
	[u2] [int] NOT NULL,
	[inversiones] [int] NULL,
	[iguales] [int] NULL,
	[complemento] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[OMI]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[Problema]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[problemaDificultad](
	[problema] [int] NULL,
	[dificultad] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProblemaRecomendacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProblemaRecomendacion](
	[p1] [int] NULL,
	[p2] [int] NULL,
	[correlacion] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recomendacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recomendacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idAlgoritmo] [int] NOT NULL,
	[idSimulacion] [int] NOT NULL,
	[idUsuarioSimulacion] [int] NOT NULL,
	[idProblema] [int] NOT NULL,
	[resolvio] [bit] NOT NULL,
	[subioNivel] [bit] NOT NULL,
	[timestamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Recomendacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Simulacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Simulacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[inicio] [datetime2](7) NOT NULL,
	[fin] [datetime2](7) NULL,
	[comentario] [text] NULL,
 CONSTRAINT [PK_Simulacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SVDProblemF]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SVDProblemF](
	[problema] [int] NOT NULL,
	[feature] [int] NOT NULL,
	[valor] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SVDUserF]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SVDUserF](
	[usuario] [int] NOT NULL,
	[feature] [int] NOT NULL,
	[valor] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](100) NOT NULL,
	[descripcion] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 20/05/2015 01:53:01 p. m. ******/
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
/****** Object:  Table [dbo].[UsuarioRecomendacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRecomendacion](
	[u1] [int] NULL,
	[u2] [int] NULL,
	[correlacion] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioSimulacion]    Script Date: 20/05/2015 01:53:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioSimulacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idSimulacion] [int] NOT NULL,
	[motivacionInicial] [float] NOT NULL,
	[aPositiva] [float] NOT NULL,
	[aNegativa] [float] NOT NULL,
	[fFacilidad] [float] NOT NULL,
	[comentario] [text] NULL,
	[sinRecomendacion] [float] NULL,
 CONSTRAINT [PK_UsuarioSimulacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [Inversion_u1]    Script Date: 20/05/2015 01:53:01 p. m. ******/
CREATE NONCLUSTERED INDEX [Inversion_u1] ON [dbo].[Inversion]
(
	[u1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Inversion_u2]    Script Date: 20/05/2015 01:53:01 p. m. ******/
CREATE NONCLUSTERED INDEX [Inversion_u2] ON [dbo].[Inversion]
(
	[u2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Problema]  WITH CHECK ADD  CONSTRAINT [FK_Problema_Clasificacion] FOREIGN KEY([clasificacion])
REFERENCES [dbo].[Clasificacion] ([clave])
GO
ALTER TABLE [dbo].[Problema] CHECK CONSTRAINT [FK_Problema_Clasificacion]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Algoritmo] FOREIGN KEY([idAlgoritmo])
REFERENCES [dbo].[Algoritmo] ([id])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Algoritmo]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Problema] FOREIGN KEY([idProblema])
REFERENCES [dbo].[Problema] ([clave])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Problema]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_Simulacion] FOREIGN KEY([idSimulacion])
REFERENCES [dbo].[Simulacion] ([id])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_Simulacion]
GO
ALTER TABLE [dbo].[Recomendacion]  WITH CHECK ADD  CONSTRAINT [FK_Recomendacion_UsuarioSimulacion] FOREIGN KEY([idUsuarioSimulacion])
REFERENCES [dbo].[UsuarioSimulacion] ([id])
GO
ALTER TABLE [dbo].[Recomendacion] CHECK CONSTRAINT [FK_Recomendacion_UsuarioSimulacion]
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
ALTER TABLE [dbo].[UsuarioSimulacion]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioSimulacion_Simulacion] FOREIGN KEY([idSimulacion])
REFERENCES [dbo].[Simulacion] ([id])
GO
ALTER TABLE [dbo].[UsuarioSimulacion] CHECK CONSTRAINT [FK_UsuarioSimulacion_Simulacion]
GO
USE [master]
GO
ALTER DATABASE [SimulacionKarelotitlan] SET  READ_WRITE 
GO
