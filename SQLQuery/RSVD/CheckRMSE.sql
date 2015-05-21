/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [id]
      ,[idSimulacion]
      ,[tipoEvento]
      ,[timestamp]
      ,[comentario]
  FROM [SimulacionKarelotitlan].[dbo].[Evento]
  WHERE idSimulacion = 51
  order by id desc