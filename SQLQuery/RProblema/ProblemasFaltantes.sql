SELECT * FROM SimulacionKarelotitlan.dbo.Problema
WHERE clave NOT IN (SELECT problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE puntos = 100 and usuario = 5)