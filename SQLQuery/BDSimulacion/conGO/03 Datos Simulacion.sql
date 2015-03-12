USE [SimulacionKarelotitlan]
GO
DELETE FROM [dbo].[problemaDificultad]
GO
DELETE FROM [dbo].[OMI]
GO
DELETE FROM [dbo].[Nivel]
GO
DELETE FROM [dbo].[Estado]
GO
DELETE FROM [dbo].[Problema]
GO
DELETE FROM [dbo].[Clasificacion]
GO
SET IDENTITY_INSERT [dbo].[Clasificacion] ON 

GO
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (1, N'Introducci�n', 0, N'Conoce a Karel y sus operaciones b�sicas', N'../curso/introduccion.html')
GO
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (2, N'B�sico', 30, N'Aprendiendo una metodolog�a, llegar�s lejos', N'../curso/metodo.pdf')
GO
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (3, N'Recursi�n', 60, N'Para contar, usa recursi�n', N'../curso/recursion.html')
GO
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (4, N'Recursi�n con par�metros', 60, N'El par�metro tambi�n se guarda en la pila', N'../curso/parametros.html')
GO
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (5, N'B�squedas', 60, N'Recursi�n exhaustiva', N'')
GO
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (6, N'Problemario', 120, N'Reta tus conocimientos', N'')
GO
SET IDENTITY_INSERT [dbo].[Clasificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Problema] ON 

GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12846, N'El apag�n', N'Concentraci�n 2007, 1a OCyMI', 4, 1, 1, 0, 200)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12847, N'Midiendo la distancia', N'8.5a OMI, Piedras Negras 2004', 3, 1, 1, 0, 100)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12849, N'Cactus', N'11a OMI, examen estatal del DF y Estado de M�xico', 2, 1, 1, 0, 500)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12850, N'B�nkeres', N'Concentraci�n 2007, 1a OCyMI', 5, 1, 1, 0, 1000)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12851, N'Camino a Torre�n', N'Concentraci�n 2007, 1a OCyMI', 4, 1, 1, 0, 1000)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12852, N'Camino a Torre�n Reloaded', N'Concentraci�n 2007, 1a OCyMI', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12853, N'Chuzpa regresa', N'1a OCyMI, Distrito Federal 2007', 5, 1, 1, 0, 200)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12854, N'El sitio', N'Concentraci�n 2008, 2a OCyMI (DF, EDOMEX y OAXACA)', 4, 1, 1, 0, 600)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12855, N'La ben�vola Chizpa', N'Concentraci�n 2008, 2a OCyMI', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12856, N'La ciudad de Karelotitl�n', N'1a OCyMI, Distrito Federal 2007', 3, 1, 1, 0, 400)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12857, N'Los bloques perdidos', N'1a OCyMI, Distrito Federal 2007', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12858, N'Los ratones Karel', N'Propuesta Competencia PUMINET 2008', 4, 1, 1, 0, 700)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12859, N'Reconstruyendo la pir�mide', N'1a OCyMI, Distrito Federal 2007', 4, 1, 1, 0, 310)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12860, N'Sumas karelianas', N'Concentraci�n 2007, 1a OCyMI', 4, 1, 1, 0, 400)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12861, N'Traves�a escolar', N'Competencia PUMINET 2007', 3, 1, 1, 0, 310)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12862, N'Torneos', N'Competencia PUMINET 2008', 4, 1, 1, 0, 430)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12863, N'Arquitectos karelianos', N'2a OCyMI, Distrito Federal 2008', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12864, N'Escalando la monta�a', N'2a OCyMI, Distrito Federal 2008', 4, 1, 1, 0, 300)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12865, N'El hijo del cartero', N'2a OCyMI, Distrito Federal 2008', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12866, N'Matriuskas', N'2a OCyMI, Distrito Federal 2008', 3, 1, 1, 0, 600)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12867, N'Bacterias infecciosas', N'Concentraci�n 2008, 2a OCyMI', 5, 1, 1, 0, 600)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12868, N'Los cubos de Karel', N'Concentraci�n 2008, 2a OCyMI', 4, 1, 1, 0, 550)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12869, N'Matriuskas Reloaded', N'Concentraci�n 2008, 2a OCyMI', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12870, N'Delegaciones', N'Concentraci�n 2008, 2a OCyMI (DF, EDOMEX y OAXACA)', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12871, N'Monte Alb�n', N'Concentraci�n 2008, 2a OCyMI (DF, EDOMEX y OAXACA)', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12872, N'Carrera', N'11a OMI, examen estatal del DF y Estado de M�xico', 3, 1, 1, 0, 700)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12873, N'KarelGol', N'11a OMI, examen estatal del DF y Estado de M�xico', 3, 1, 1, 0, 300)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12874, N'Tendedero', N'11a OMI, examen estatal del DF y Estado de M�xico', 4, 1, 1, 0, 320)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12875, N'La balanza', N'10a OMI, examen estatal del DF y Estado de M�xico', 4, 1, 1, 0, 230)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12876, N'Bardando el terreno', N'10a OMI, examen estatal del DF y Estado de M�xico', 4, 1, 1, 0, 500)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12877, N'Comprando', N'10a OMI, repechaje del DF y Estado de M�xico', 4, 1, 1, 0, 210)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12878, N'Cuenta pasos', N'10a OMI, examen estatal del DF y Estado de M�xico', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12879, N'Karel-per�metro', N'10a OMI, repechaje del DF y Estado de M�xico', 3, 1, 1, 0, 200)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12880, N'Sembrando', N'10a OMI, repechaje del DF y Estado de M�xico', 1, 1, 1, 0, 300)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12881, N'Los canales del lago', N'Concentraci�n 2008, 2a OCyMI', 1, 1, 1, 0, 700)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12882, N'Detr�s del arco�ris', N'9a OMI, examen estatal oficial', 2, 1, 1, 0, 900)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12883, N'El mapa del tesoro', N'10a OMI, Durango 2005', 2, 1, 1, 0, 600)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12884, N'Despu�s del recreo', N'Karelotitl�n 2009', 3, 1, 1, 0, 500)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12885, N'Alacranes zumbadores', N'10a OMI, Durango 2005', 2, 1, 1, 0, 550)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12886, N'Paredes', N'8.5a OMI, Piedras Negras 2004', 1, 1, 1, 0, 500)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12887, N'Leyendo el peri�dico', N'Curso b�sico de recursividad, Karel', 3, 1, 1, 0, 150)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12888, N'Amontonar zumbadores', N'9a OMI, Morelia 2004', 1, 1, 1, 0, 50)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12889, N'La marcha', N'9a OMI, Morelia 2004', 3, 1, 1, 0, 175)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12890, N'El estadio de f�tbol', N'9a OMI, Morelia 2004', 4, 1, 1, 0, 415)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12891, N'Sumar', N'9a OMI, examen estatal oficial', 2, 1, 1, 0, 575)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12892, N'Recoge zumbadores', N'8.5a OMI, Piedras Negras 2004', 1, 1, 1, 0, 150)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12893, N'Pasa los n�meros al otro lado', N'8.5a OMI, Piedras Negras 2004', 1, 1, 1, 0, 600)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12894, N'Pasando los n�meros Reloaded', N'Karelotitl�n 2009', 3, 1, 1, 0, 250)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12895, N'Multiplicaci�n y divisi�n', N'8.5a OMI, Piedras Negras 2004', 4, 1, 1, 0, 900)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12896, N'Autopista', N'10a OMI, Durango 2005', 3, 1, 1, 0, 225)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12897, N'Medias pir�mides', N'Karelotitl�n 2009', 1, 1, 1, 0, 550)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12898, N'Sedim�rip saidem', N'9002 N�ltitolerak', 1, 1, 1, 0, 551)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12899, N'Los ratones Karel, Episodio I', N'Karelotitl�n 2009', 2, 1, 1, 0, 100)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12900, N'Buscaminas', N'11a OMI, San Luis Potos� 2006', 3, 1, 1, 0, 800)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12901, N'�reas', N'11a OMI, San Luis Potos� 2006', 5, 1, 1, 0, 300)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12902, N'El mal�fico Chuzpa', N'11a OMI, San Luis Potos� 2006', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12903, N'Un beeper en la casa', N'12a OMI, Torre�n 2007', 2, 1, 1, 0, 800)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12904, N'Vigas', N'12a OMI, Torre�n 2007', 2, 1, 1, 0, 585)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12905, N'Costo m�nimo', N'12a OMI, Torre�n 2007', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12906, N'Erosi�n', N'13a OMI, Puebla 2008', 2, 1, 1, 0, 850)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12907, N'S�per-Karelman', N'13a OMI, Puebla 2008', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12908, N'Camino de primos', N'13a OMI, Puebla 2008', 5, 1, 1, 0, 800)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12909, N'La expedici�n de Karelotl', N'Karelotitl�n 2009', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12910, N'Calcetines desemparejados', N'3a OCyMI, Distrito Federal 2009', 2, 1, 1, 0, 700)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12911, N'La fila de las tortillas', N'3a OCyMI, Distrito Federal 2009', 2, 1, 1, 0, 580)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12912, N'Vig�as', N'3a OCyMI, Distrito Federal 2009', 4, 1, 1, 0, 650)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12913, N'Pasteles', N'3a OCyMI, Distrito Federal 2009', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12914, N'La fila de las tortillas Reloaded', N'Concentraci�n 2009, 3a OCyMI', 4, 1, 1, 0, 450)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12915, N'Tlakarelel, y la piedra de la maldici�n', N'Concentraci�n 2009, 3a OCyMI', 5, 1, 1, 0, 900)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12916, N'Burocracia interminable', N'Problema perdido en el 2007', 3, 1, 1, 0, 305)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12917, N'La fila', N'14a OMI, examen estatal de Morelos', 3, 1, 1, 0, 375)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12918, N'Campamento', N'14 OMI, examen estatal de Morelos', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12919, N'Piedras', N'14a OMI, examen estatal de Morelos', 4, 1, 1, 0, 240)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12920, N'Rutas', N'Examen por Internet, Septiembre 2009', 5, 1, 1, 0, 850)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12921, N'R�os', N'Examen por Internet, Septiembre 2009', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12922, N'Isla', N'14a OMI, Colima 2009', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12923, N'Influenza', N'14a OMI, Colima 2009', 3, 1, 1, 0, 750)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12924, N'Divisores', N'14a OMI, Colima 2009', 5, 1, 1, 0, 950)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12925, N'Clases de manejo', N'4a Olimpiada de Inform�tica del DF y Edo M�x 2010', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12926, N'Comida buena y mala', N'4a Olimpiada de Inform�tica del DF y Edo M�x 2010', 4, 1, 1, 0, 950)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12927, N'El cochecito', N'4a Olimpiada de Inform�tica del DF y Edo M�x 2010', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12928, N'Calor�as', N'Olimpiada de Inform�tica de Morelos 2010', 5, 1, 1, 0, 825)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12929, N'El cine', N'Olimpiada de Inform�tica de Morelos 2010', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12930, N'Indentaciones', N'Olimpiada de Inform�tica de Morelos 2010', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12931, N'�Tache!', N'14� OMI en Aguascalientes, 2009', 2, 1, 1, 0, 250)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12932, N'K�bola', N'14� OMI en Aguascalientes, 2009', 2, 1, 1, 0, 750)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12933, N'Kontando en el Kallej�n', N'14� OMI en Aguascalientes, 2009', 3, 1, 1, 0, 125)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12934, N'Kami�n', N'14� OMI en Aguascalientes, 2009', 4, 1, 1, 0, 440)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12935, N'Klaveles Kompany', N'14� OMI en Aguascalientes, 2009', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12936, N'Hombre-Puma', N'Concentraci�n 2010, 4a OMI DF-EDOMEX', 5, 1, 1, 0, 875)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12937, N'San Bombazo', N'Concentraci�n 2010, 4a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12938, N'Karel, el aprendiz de pintor', N'Concentraci�n 2010, 4a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12939, N'Almohada', N'15a OMI, M�rida 2010', 4, 1, 1, 0, 270)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12940, N'Rombo', N'15a OMI, M�rida 2010', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12941, N'Recuerda de d�nde saliste', N'15a OMI, M�rida 2010', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12942, N'Rebelde', N'15a OMI, M�rida 2010', 5, 1, 1, 0, 880)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12943, N'Comedor', N'5a Olimpiada de Inform�tica del DF y Edo M�x 2011', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12944, N'Galletas', N'5a Olimpiada de Inform�tica del DF y Edo M�x 2011', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12945, N'Zapatos', N'5a Olimpiada de Inform�tica del DF y Edo M�x 2011', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12946, N'Comprando Reloaded', N'Concentraci�n 2011, 5a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12947, N'Dulces', N'Concentraci�n 2011, 5a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12948, N'Durmiendo', N'Concentraci�n 2011, 5a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12949, N'Edificios', N'Concentraci�n 2011, 5a OMI DF-EDOMEX', 4, 1, 1, 0, 575)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12950, N'Riesgo', N'5a Olimpiada de Inform�tica del DF y Edo M�x 2011', 5, 1, 1, 0, 925)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12951, N'La casa', N'16a OMI, Delegaci�n Yucat�n', 4, 1, 1, 0, 220)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12952, N'Esquinas', N'16a OMI, Delegaci�n Yucat�n', 2, 1, 1, 0, 300)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12953, N'El encuentro', N'16a OMI, Delegaci�n Yucat�n', 3, 1, 1, 0, 160)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12954, N'El mural', N'16a OMI, Delegaci�n Yucat�n', 4, 1, 1, 0, 445)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12955, N'La pared', N'16a OMI, Delegaci�n Yucat�n', 3, 1, 1, 0, 167)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12956, N'Los Aluxes', N'16a OMI, Delegaci�n Yucat�n', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12957, N'Karel Mosby, arquitecto', N'16a OMI, Cuernavaca 2011', 2, 1, 1, 0, 275)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12958, N'Kareleseo', N'16a OMI, Cuernavaca 2011', 3, 1, 1, 0, 350)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12959, N'Kareloscopio', N'16a OMI, Cuernavaca 2011', 4, 1, 1, 0, 800)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12960, N'Kill Karel', N'16a OMI, Cuernavaca 2011', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12961, N'Hansel & Gretel', N'16a OMI, Primera Fase Estatal San Luis Potos�', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12962, N'KareLevy', N'16a OMI, Primera Fase Estatal San Luis Potos�', 2, 1, 1, 0, 525)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12963, N'Cuadro m�gico', N'15a OMI, Primera Fase Estatal San Luis Potos�', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12964, N'Asterisco', N'Olimpiada Potosina de Inform�tica 2012', 2, 1, 1, 0, 400)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12965, N'La novia de Karel', N'Olimpiada Potosina de Inform�tica 2012', 2, 1, 1, 0, 150)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12966, N'Saludos', N'Olimpiada Potosina de Inform�tica 2012', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12967, N'Karel Digital', N'Olimpiada Potosina de Inform�tica 2012, fase 2', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12968, N'Rehilete', N'Propuesto por Elias Augusto Tuyu Alamilla', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12969, N'Tiro con arco', N'17a OMI, Hermosillo 2012', 2, 1, 1, 0, 650)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12970, N'Sombras del desierto', N'17a OMI, Hermosillo 2012', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12971, N'Simetr�a', N'17a OMI, Hermosillo 2012', 6, 1, 1, 0, 1)
GO
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12972, N'Patrones', N'17a OMI, Hermosillo 2012', 6, 1, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Problema] OFF
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 

GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (1, N'DF / Estado de M�xico')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (2, N'Aguascalientes')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (3, N'Baja California Norte')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (4, N'Baja California Sur')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (5, N'Chihuahua')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (6, N'Chiapas')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (7, N'Campeche')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (8, N'Durango')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (9, N'Guanajuato')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (10, N'Guerrero')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (11, N'Hidalgo')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (12, N'Jalisco')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (13, N'Nayarit')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (14, N'Nuevo Le�n')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (15, N'Oaxaca')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (16, N'Puebla')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (17, N'Quer�taro')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (18, N'Michoac�n')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (19, N'Sonora')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (20, N'Sinaloa')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (21, N'Tabasco')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (22, N'Tamaulipas')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (23, N'San Luis Potos�')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (24, N'Coahuila')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (25, N'Yucat�n')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (26, N'Quintana Roo')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (27, N'Tlaxcala')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (28, N'Veracruz')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (29, N'Morelos')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (30, N'Zacatecas')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (31, N'Colima')
GO
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (32, N'- Extranjero -')
GO
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (-1, N'Rendido', N'El usuario ya no sube mas problemas')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (0, N'Inicia', N'El usuario inicia con tema')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (1, N'Muy facil', N'Problemas que se utilizan para epxlicacion de tema')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (2, N'Facil', N'Problemas que tiene ligeras modificaciones')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (3, N'Medio', N'Problemas que es necesarion pensar para resolverlo')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (4, N'Dificil', N'Problemas que requieren un analisis para ser resuletos')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (5, N'Muy Dificil', N'Probelmas mas dificil que los niveles anteriores')
GO
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (6, N'Completo', N'El usuario completo todos los problemas')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (1, N'Asesor')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2, N'L�der')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (3, N'Delegado')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (4, N'COMI')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (5, N'Invitado')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (6, N'Comit� Estatal')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2014, N'OMI 2014 Hidalgo')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2015, N'OMI 2015 Chihuahua')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2016, N'OMI 2016 Veracruz')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2017, N'OMI 2017 Quer�taro')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2018, N'OMI 2018')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2019, N'OMI 2019')
GO
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2020, N'OMI 2020')
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12846, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12889, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12899, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12853, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12939, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12922, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12901, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12895, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12940, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12916, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12941, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12890, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12875, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12877, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12847, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12858, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12929, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12862, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12857, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12856, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12942, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12868, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12909, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12918, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12930, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12896, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12887, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12864, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12859, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12914, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12951, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12937, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12879, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12888, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12892, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12931, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12849, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12866, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12882, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12880, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12884, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12881, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12861, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12851, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12885, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12886, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12897, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12933, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12876, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12900, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12893, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12898, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12883, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12923, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12908, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12907, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12903, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12891, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12863, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12911, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12935, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12867, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12870, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12904, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12932, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12919, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12878, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12854, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12928, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12917, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12894, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12865, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12934, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12920, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12905, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12938, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12872, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12850, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12913, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12912, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12961, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12924, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12902, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12925, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12957, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12952, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12953, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12874, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12855, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12915, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12871, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12927, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12860, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12869, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12956, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12936, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12945, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12852, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12948, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12960, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12971, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12967, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12926, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12950, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12954, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12965, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12955, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12959, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12958, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12944, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12964, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12873, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12949, 4)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12921, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12943, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12906, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12947, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12910, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12962, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12963, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12966, 2)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12970, 3)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12969, 1)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12972, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12946, 5)
GO
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12968, 5)
GO
