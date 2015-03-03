/*
 * Script para poder obtener lista de nombre e ID de problema de la base de datos de Karelotitlan 
 */
SELECT nombre,
	   clave, 
	   clasificacion,
	   (select nombre from Karelotitlan.dbo.Clasificacion where Problema.clasificacion = clave) as nombreClasificacion,
	   (select avg(UsuarioProblema.puntos) from Karelotitlan.dbo.UsuarioProblema where UsuarioProblema.problema = Problema.clave) as promedio,
	   (select count(*) from Karelotitlan.dbo.UsuarioProblema where UsuarioProblema.problema = Problema.clave) as resuletos,
	   (select avg(UsuarioProblema.primero) from Karelotitlan.dbo.UsuarioProblema where UsuarioProblema.problema = Problema.clave) as promedioPrimero
	   FROM [Karelotitlan].[dbo].[Problema]