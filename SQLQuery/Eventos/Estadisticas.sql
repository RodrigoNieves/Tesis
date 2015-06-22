/* Total Recomendaciones */
Select idSimulacion,SUM( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nRecomendaciones')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

/* Total de Exitos*/
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nExitos')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion


/* Total de Fallos */
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nFallos')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

/*Total de incrementos*/
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nIncNivel')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

/*Total usuarios completos*/
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nCompletos')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

/* Total rendidos*/
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nRendidos')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

/* Total sin Recomendacion */
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nSinRecomendacion')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

/*Total cold start*/
Select idSimulacion,MAX( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nColdStart')
and idSimulacion in (115,116,134,125,126,129)
group by idSimulacion
order by idSimulacion

