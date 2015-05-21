SELECT clave FROM SimulacionKarelotitlan.dbo.Problema WHERE
clave not in (SELECT problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE usuario = 6 and puntos = 100) and
clave not in (SELECT problema FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion WHERE usuario = 6 and tiempo < 3)