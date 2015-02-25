/*
 * Script para poder obtener lista de nombre e ID de problema de la base de datos de Karelotitlan 
 */
SELECT nombre,
	   clave, 
	   clasificacion,
	   (select nombre from Karelotitlan.dbo.Clasificacion where Problema.clasificacion = clave) as nombreClasificacion 
	   FROM [Karelotitlan].[dbo].[Problema]