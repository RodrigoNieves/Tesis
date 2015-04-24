USE [SimulacionKarelotitlan]
GO
/****** Object:  Table [dbo].[Inversion]    Script Date: 24/04/2015 12:48:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inversion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Inversion](
	[u1] [int] NOT NULL,
	[u2] [int] NOT NULL,
	[inversiones] [int] NULL,
	[iguales] [int] NULL,
	[complemento] [int] NULL
) ON [PRIMARY]
END
GO
