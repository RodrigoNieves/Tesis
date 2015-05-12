/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [id]
      ,[inicio]
      ,[fin]
      ,[comentario]
	  ,DATEDIFF(MINUTE,[inicio],[fin]) as tiempo
  FROM [SimulacionKarelotitlan].[dbo].[Simulacion]
  order by id desc