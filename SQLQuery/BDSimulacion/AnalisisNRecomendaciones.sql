Select idSimulacion,SUM( CONVERT(INT, CONVERT(char,comentario))) AS VALOR from SimulacionKarelotitlan.dbo.Evento where Evento.tipoEvento = 
	(SELECT id from SimulacionKarelotitlan.dbo.TipoEvento where nombre = 'nRecomendaciones')
and idSimulacion in 
(274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284)
group by idSimulacion
order by idSimulacion

/*RRandom*/
(263, 264, 265, 266, 267, 268, 269, 270, 271, 272 ,273)
/*RExperto*/
(274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284)
/*RInversiones*/
(246, 247, 248, 249, 250)
/*RUser*/
/*RProblem*/
/*RSVD*/
(252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262)