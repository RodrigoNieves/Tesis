SELECT  nombreReal, 
		nombreUsuario, 
		correo,
		(SELECT Estado.estado FROM Karelotitlan.dbo.Estado WHERE Estado.clave = Usuario.estado) as EstadoOrigen,
		(SELECT OMI.lugar FROM Karelotitlan.dbo.OMI WHERE OMI.OMI = Usuario.omi) as Lugar,
		asesor
		FROM Karelotitlan.dbo.Usuario WHERE Usuario.clave = 9692

SELECT * FROM Karelotitlan.dbo.Usuario WHERE Usuario.nombreUsuario = 'luisRodolfo'