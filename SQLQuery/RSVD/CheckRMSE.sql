/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [id]
      ,[idSimulacion]
      ,[tipoEvento]
      ,[timestamp]
      ,[comentario]
  FROM [SimulacionKarelotitlan].[dbo].[Evento]
  WHERE idSimulacion > 60 and tipoEvento = 3
  order by id desc