USE [SimulacionKarelotitlan]
GO
/****** Object:  Table [dbo].[ExpertoRecomendacion]    Script Date: 24/03/2015 01:11:33 p.m. ******/
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
