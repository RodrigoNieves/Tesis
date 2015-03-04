/* 
 * Obtiene el historial de cada uno de los elementos
 * Preguntar a Felix por que algunos no tienen hora?
 */
SELECT usuario,
       DateTime,
	   problema FROM (SELECT
		usuario,
		problema,
		puntos,
		hora/100000000 as year,
		(hora/1000000) % 100 as month,
		(hora/10000)   % 100 as day,
		(hora/100)     % 100 as hour,
		hora           % 100 as minutes,
		DATETIMEFROMPARTS(
			hora/100000000,
			(hora/1000000) % 100,
			(hora/10000)   % 100,
			(hora/100)     % 100,
			hora           % 100,
			0,0) as DateTime
		FROM Karelotitlan.dbo.UsuarioProblema
	WHERE puntos = 100 and hora != 0) as submitions
	order by usuario, DateTime

	/*
		Parece que los ceros estan en forma random
	*/

	SELECT usuario, hora, problema FROM Karelotitlan.dbo.UsuarioProblema order by usuario