SELECT TOP 1 * FROM SimulacionKarelotitlan.dbo.Problema 
WHERE Problema.clave not in (SELECT UsuarioProblema.problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE UsuarioProblema.usuario = 31 and UsuarioProblema.puntos = 100) and 
	  Problema.clave not in (SELECT ExpertoRecomendacion.problema FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion WHERE ExpertoRecomendacion.usuario = 31 and ExpertoRecomendacion.tiempo < 10)
order by Problema.dificultad