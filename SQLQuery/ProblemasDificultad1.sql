SELECT clave, 
	   nombre,
	   origen,
	   clasificacion,
	   (SELECT problemaDificultad.dificultad FROM Karelotitlan.dbo.problemaDificultad WHERE problemaDificultad.problema = Problema.clave )  as DificultadN
	   FROM Karelotitlan.dbo.Problema;