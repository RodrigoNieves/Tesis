USE [SimulacionKarelotitlan]
 
ALTER TABLE [dbo].[UsuarioProblema] DROP CONSTRAINT [FK_UsuarioProblema_Usuario]
 
ALTER TABLE [dbo].[UsuarioProblema] DROP CONSTRAINT [FK_UsuarioProblema_Problema]
 
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_OMI]
 
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Estado]
 
ALTER TABLE [dbo].[Problema] DROP CONSTRAINT [FK_Problema_Clasificacion]
 
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[UsuarioProblema]
 
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[Usuario]
 
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[problemaDificultad]
 
/****** Object:  Table [dbo].[Problema]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[Problema]
 
/****** Object:  Table [dbo].[OMI]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[OMI]
 
/****** Object:  Table [dbo].[Nivel]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[Nivel]
 
/****** Object:  Table [dbo].[Estado]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[Estado]
 
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 12/03/2015 12:10:12 p.m. ******/
DROP TABLE [dbo].[Clasificacion]
 
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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
 
/****** Object:  Table [dbo].[Estado]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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
 
/****** Object:  Table [dbo].[Nivel]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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

 
/****** Object:  Table [dbo].[OMI]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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
 
/****** Object:  Table [dbo].[Problema]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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
 
/****** Object:  Table [dbo].[problemaDificultad]    Script Date: 12/03/2015 12:10:12 p.m. ******/
SET ANSI_NULLS ON
 
SET QUOTED_IDENTIFIER ON
 
CREATE TABLE [dbo].[problemaDificultad](
	[problema] [int] NULL,
	[dificultad] [int] NULL
) ON [PRIMARY]

 
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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
 
/****** Object:  Table [dbo].[UsuarioProblema]    Script Date: 12/03/2015 12:10:12 p.m. ******/
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

 
ALTER TABLE [dbo].[Problema]  WITH CHECK ADD  CONSTRAINT [FK_Problema_Clasificacion] FOREIGN KEY([clasificacion])
REFERENCES [dbo].[Clasificacion] ([clave])
 
ALTER TABLE [dbo].[Problema] CHECK CONSTRAINT [FK_Problema_Clasificacion]
 
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
 
