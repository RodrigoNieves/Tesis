USE [SimulacionKarelotitlan]
 
DELETE FROM [dbo].[problemaDificultad]
 
DELETE FROM [dbo].[OMI]
 
DELETE FROM [dbo].[Nivel]
 
DELETE FROM [dbo].[Estado]
 
DELETE FROM [dbo].[Problema]
 
DELETE FROM [dbo].[Clasificacion]
 
SET IDENTITY_INSERT [dbo].[Clasificacion] ON 

 
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (1, N'Introducción', 0, N'Conoce a Karel y sus operaciones básicas', N'../curso/introduccion.html')
 
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (2, N'Básico', 30, N'Aprendiendo una metodología, llegarás lejos', N'../curso/metodo.pdf')
 
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (3, N'Recursión', 60, N'Para contar, usa recursión', N'../curso/recursion.html')
 
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (4, N'Recursión con parámetros', 60, N'El parámetro también se guarda en la pila', N'../curso/parametros.html')
 
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (5, N'Búsquedas', 60, N'Recursión exhaustiva', N'')
 
INSERT [dbo].[Clasificacion] ([clave], [nombre], [tiempo], [descripcion], [url]) VALUES (6, N'Problemario', 120, N'Reta tus conocimientos', N'')
 
SET IDENTITY_INSERT [dbo].[Clasificacion] OFF
 
SET IDENTITY_INSERT [dbo].[Problema] ON 

 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12846, N'El apagón', N'Concentración 2007, 1a OCyMI', 4, 1, 1, 0, 200)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12847, N'Midiendo la distancia', N'8.5a OMI, Piedras Negras 2004', 3, 1, 1, 0, 100)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12849, N'Cactus', N'11a OMI, examen estatal del DF y Estado de México', 2, 1, 1, 0, 500)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12850, N'Búnkeres', N'Concentración 2007, 1a OCyMI', 5, 1, 1, 0, 1000)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12851, N'Camino a Torreón', N'Concentración 2007, 1a OCyMI', 4, 1, 1, 0, 1000)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12852, N'Camino a Torreón Reloaded', N'Concentración 2007, 1a OCyMI', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12853, N'Chuzpa regresa', N'1a OCyMI, Distrito Federal 2007', 5, 1, 1, 0, 200)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12854, N'El sitio', N'Concentración 2008, 2a OCyMI (DF, EDOMEX y OAXACA)', 4, 1, 1, 0, 600)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12855, N'La benévola Chizpa', N'Concentración 2008, 2a OCyMI', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12856, N'La ciudad de Karelotitlán', N'1a OCyMI, Distrito Federal 2007', 3, 1, 1, 0, 400)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12857, N'Los bloques perdidos', N'1a OCyMI, Distrito Federal 2007', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12858, N'Los ratones Karel', N'Propuesta Competencia PUMINET 2008', 4, 1, 1, 0, 700)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12859, N'Reconstruyendo la pirámide', N'1a OCyMI, Distrito Federal 2007', 4, 1, 1, 0, 310)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12860, N'Sumas karelianas', N'Concentración 2007, 1a OCyMI', 4, 1, 1, 0, 400)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12861, N'Travesía escolar', N'Competencia PUMINET 2007', 3, 1, 1, 0, 310)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12862, N'Torneos', N'Competencia PUMINET 2008', 4, 1, 1, 0, 430)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12863, N'Arquitectos karelianos', N'2a OCyMI, Distrito Federal 2008', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12864, N'Escalando la montaña', N'2a OCyMI, Distrito Federal 2008', 4, 1, 1, 0, 300)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12865, N'El hijo del cartero', N'2a OCyMI, Distrito Federal 2008', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12866, N'Matriuskas', N'2a OCyMI, Distrito Federal 2008', 3, 1, 1, 0, 600)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12867, N'Bacterias infecciosas', N'Concentración 2008, 2a OCyMI', 5, 1, 1, 0, 600)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12868, N'Los cubos de Karel', N'Concentración 2008, 2a OCyMI', 4, 1, 1, 0, 550)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12869, N'Matriuskas Reloaded', N'Concentración 2008, 2a OCyMI', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12870, N'Delegaciones', N'Concentración 2008, 2a OCyMI (DF, EDOMEX y OAXACA)', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12871, N'Monte Albán', N'Concentración 2008, 2a OCyMI (DF, EDOMEX y OAXACA)', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12872, N'Carrera', N'11a OMI, examen estatal del DF y Estado de México', 3, 1, 1, 0, 700)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12873, N'KarelGol', N'11a OMI, examen estatal del DF y Estado de México', 3, 1, 1, 0, 300)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12874, N'Tendedero', N'11a OMI, examen estatal del DF y Estado de México', 4, 1, 1, 0, 320)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12875, N'La balanza', N'10a OMI, examen estatal del DF y Estado de México', 4, 1, 1, 0, 230)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12876, N'Bardando el terreno', N'10a OMI, examen estatal del DF y Estado de México', 4, 1, 1, 0, 500)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12877, N'Comprando', N'10a OMI, repechaje del DF y Estado de México', 4, 1, 1, 0, 210)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12878, N'Cuenta pasos', N'10a OMI, examen estatal del DF y Estado de México', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12879, N'Karel-perímetro', N'10a OMI, repechaje del DF y Estado de México', 3, 1, 1, 0, 200)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12880, N'Sembrando', N'10a OMI, repechaje del DF y Estado de México', 1, 1, 1, 0, 300)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12881, N'Los canales del lago', N'Concentración 2008, 2a OCyMI', 1, 1, 1, 0, 700)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12882, N'Detrás del arcoíris', N'9a OMI, examen estatal oficial', 2, 1, 1, 0, 900)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12883, N'El mapa del tesoro', N'10a OMI, Durango 2005', 2, 1, 1, 0, 600)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12884, N'Después del recreo', N'Karelotitlán 2009', 3, 1, 1, 0, 500)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12885, N'Alacranes zumbadores', N'10a OMI, Durango 2005', 2, 1, 1, 0, 550)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12886, N'Paredes', N'8.5a OMI, Piedras Negras 2004', 1, 1, 1, 0, 500)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12887, N'Leyendo el periódico', N'Curso básico de recursividad, Karel', 3, 1, 1, 0, 150)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12888, N'Amontonar zumbadores', N'9a OMI, Morelia 2004', 1, 1, 1, 0, 50)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12889, N'La marcha', N'9a OMI, Morelia 2004', 3, 1, 1, 0, 175)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12890, N'El estadio de fútbol', N'9a OMI, Morelia 2004', 4, 1, 1, 0, 415)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12891, N'Sumar', N'9a OMI, examen estatal oficial', 2, 1, 1, 0, 575)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12892, N'Recoge zumbadores', N'8.5a OMI, Piedras Negras 2004', 1, 1, 1, 0, 150)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12893, N'Pasa los números al otro lado', N'8.5a OMI, Piedras Negras 2004', 1, 1, 1, 0, 600)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12894, N'Pasando los números Reloaded', N'Karelotitlán 2009', 3, 1, 1, 0, 250)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12895, N'Multiplicación y división', N'8.5a OMI, Piedras Negras 2004', 4, 1, 1, 0, 900)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12896, N'Autopista', N'10a OMI, Durango 2005', 3, 1, 1, 0, 225)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12897, N'Medias pirámides', N'Karelotitlán 2009', 1, 1, 1, 0, 550)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12898, N'Sedimárip saidem', N'9002 Náltitolerak', 1, 1, 1, 0, 551)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12899, N'Los ratones Karel, Episodio I', N'Karelotitlán 2009', 2, 1, 1, 0, 100)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12900, N'Buscaminas', N'11a OMI, San Luis Potosí 2006', 3, 1, 1, 0, 800)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12901, N'Áreas', N'11a OMI, San Luis Potosí 2006', 5, 1, 1, 0, 300)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12902, N'El maléfico Chuzpa', N'11a OMI, San Luis Potosí 2006', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12903, N'Un beeper en la casa', N'12a OMI, Torreón 2007', 2, 1, 1, 0, 800)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12904, N'Vigas', N'12a OMI, Torreón 2007', 2, 1, 1, 0, 585)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12905, N'Costo mínimo', N'12a OMI, Torreón 2007', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12906, N'Erosión', N'13a OMI, Puebla 2008', 2, 1, 1, 0, 850)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12907, N'Súper-Karelman', N'13a OMI, Puebla 2008', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12908, N'Camino de primos', N'13a OMI, Puebla 2008', 5, 1, 1, 0, 800)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12909, N'La expedición de Karelotl', N'Karelotitlán 2009', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12910, N'Calcetines desemparejados', N'3a OCyMI, Distrito Federal 2009', 2, 1, 1, 0, 700)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12911, N'La fila de las tortillas', N'3a OCyMI, Distrito Federal 2009', 2, 1, 1, 0, 580)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12912, N'Vigías', N'3a OCyMI, Distrito Federal 2009', 4, 1, 1, 0, 650)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12913, N'Pasteles', N'3a OCyMI, Distrito Federal 2009', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12914, N'La fila de las tortillas Reloaded', N'Concentración 2009, 3a OCyMI', 4, 1, 1, 0, 450)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12915, N'Tlakarelel, y la piedra de la maldición', N'Concentración 2009, 3a OCyMI', 5, 1, 1, 0, 900)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12916, N'Burocracia interminable', N'Problema perdido en el 2007', 3, 1, 1, 0, 305)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12917, N'La fila', N'14a OMI, examen estatal de Morelos', 3, 1, 1, 0, 375)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12918, N'Campamento', N'14 OMI, examen estatal de Morelos', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12919, N'Piedras', N'14a OMI, examen estatal de Morelos', 4, 1, 1, 0, 240)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12920, N'Rutas', N'Examen por Internet, Septiembre 2009', 5, 1, 1, 0, 850)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12921, N'Ríos', N'Examen por Internet, Septiembre 2009', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12922, N'Isla', N'14a OMI, Colima 2009', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12923, N'Influenza', N'14a OMI, Colima 2009', 3, 1, 1, 0, 750)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12924, N'Divisores', N'14a OMI, Colima 2009', 5, 1, 1, 0, 950)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12925, N'Clases de manejo', N'4a Olimpiada de Informática del DF y Edo Méx 2010', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12926, N'Comida buena y mala', N'4a Olimpiada de Informática del DF y Edo Méx 2010', 4, 1, 1, 0, 950)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12927, N'El cochecito', N'4a Olimpiada de Informática del DF y Edo Méx 2010', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12928, N'Calorías', N'Olimpiada de Informática de Morelos 2010', 5, 1, 1, 0, 825)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12929, N'El cine', N'Olimpiada de Informática de Morelos 2010', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12930, N'Indentaciones', N'Olimpiada de Informática de Morelos 2010', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12931, N'¡Tache!', N'14° OMI en Aguascalientes, 2009', 2, 1, 1, 0, 250)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12932, N'Kábola', N'14° OMI en Aguascalientes, 2009', 2, 1, 1, 0, 750)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12933, N'Kontando en el Kallejón', N'14° OMI en Aguascalientes, 2009', 3, 1, 1, 0, 125)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12934, N'Kamión', N'14° OMI en Aguascalientes, 2009', 4, 1, 1, 0, 440)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12935, N'Klaveles Kompany', N'14° OMI en Aguascalientes, 2009', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12936, N'Hombre-Puma', N'Concentración 2010, 4a OMI DF-EDOMEX', 5, 1, 1, 0, 875)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12937, N'San Bombazo', N'Concentración 2010, 4a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12938, N'Karel, el aprendiz de pintor', N'Concentración 2010, 4a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12939, N'Almohada', N'15a OMI, Mérida 2010', 4, 1, 1, 0, 270)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12940, N'Rombo', N'15a OMI, Mérida 2010', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12941, N'Recuerda de dónde saliste', N'15a OMI, Mérida 2010', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12942, N'Rebelde', N'15a OMI, Mérida 2010', 5, 1, 1, 0, 880)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12943, N'Comedor', N'5a Olimpiada de Informática del DF y Edo Méx 2011', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12944, N'Galletas', N'5a Olimpiada de Informática del DF y Edo Méx 2011', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12945, N'Zapatos', N'5a Olimpiada de Informática del DF y Edo Méx 2011', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12946, N'Comprando Reloaded', N'Concentración 2011, 5a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12947, N'Dulces', N'Concentración 2011, 5a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12948, N'Durmiendo', N'Concentración 2011, 5a OMI DF-EDOMEX', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12949, N'Edificios', N'Concentración 2011, 5a OMI DF-EDOMEX', 4, 1, 1, 0, 575)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12950, N'Riesgo', N'5a Olimpiada de Informática del DF y Edo Méx 2011', 5, 1, 1, 0, 925)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12951, N'La casa', N'16a OMI, Delegación Yucatán', 4, 1, 1, 0, 220)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12952, N'Esquinas', N'16a OMI, Delegación Yucatán', 2, 1, 1, 0, 300)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12953, N'El encuentro', N'16a OMI, Delegación Yucatán', 3, 1, 1, 0, 160)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12954, N'El mural', N'16a OMI, Delegación Yucatán', 4, 1, 1, 0, 445)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12955, N'La pared', N'16a OMI, Delegación Yucatán', 3, 1, 1, 0, 167)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12956, N'Los Aluxes', N'16a OMI, Delegación Yucatán', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12957, N'Karel Mosby, arquitecto', N'16a OMI, Cuernavaca 2011', 2, 1, 1, 0, 275)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12958, N'Kareleseo', N'16a OMI, Cuernavaca 2011', 3, 1, 1, 0, 350)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12959, N'Kareloscopio', N'16a OMI, Cuernavaca 2011', 4, 1, 1, 0, 800)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12960, N'Kill Karel', N'16a OMI, Cuernavaca 2011', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12961, N'Hansel & Gretel', N'16a OMI, Primera Fase Estatal San Luis Potosí', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12962, N'KareLevy', N'16a OMI, Primera Fase Estatal San Luis Potosí', 2, 1, 1, 0, 525)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12963, N'Cuadro mágico', N'15a OMI, Primera Fase Estatal San Luis Potosí', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12964, N'Asterisco', N'Olimpiada Potosina de Informática 2012', 2, 1, 1, 0, 400)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12965, N'La novia de Karel', N'Olimpiada Potosina de Informática 2012', 2, 1, 1, 0, 150)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12966, N'Saludos', N'Olimpiada Potosina de Informática 2012', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12967, N'Karel Digital', N'Olimpiada Potosina de Informática 2012, fase 2', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12968, N'Rehilete', N'Propuesto por Elias Augusto Tuyu Alamilla', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12969, N'Tiro con arco', N'17a OMI, Hermosillo 2012', 2, 1, 1, 0, 650)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12970, N'Sombras del desierto', N'17a OMI, Hermosillo 2012', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12971, N'Simetría', N'17a OMI, Hermosillo 2012', 6, 1, 1, 0, 1)
 
INSERT [dbo].[Problema] ([clave], [nombre], [origen], [clasificacion], [owner], [status], [bloqueado], [dificultad]) VALUES (12972, N'Patrones', N'17a OMI, Hermosillo 2012', 6, 1, 1, 0, 1)
 
SET IDENTITY_INSERT [dbo].[Problema] OFF
 
SET IDENTITY_INSERT [dbo].[Estado] ON 

 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (1, N'DF / Estado de México')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (2, N'Aguascalientes')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (3, N'Baja California Norte')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (4, N'Baja California Sur')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (5, N'Chihuahua')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (6, N'Chiapas')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (7, N'Campeche')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (8, N'Durango')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (9, N'Guanajuato')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (10, N'Guerrero')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (11, N'Hidalgo')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (12, N'Jalisco')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (13, N'Nayarit')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (14, N'Nuevo León')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (15, N'Oaxaca')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (16, N'Puebla')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (17, N'Querétaro')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (18, N'Michoacán')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (19, N'Sonora')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (20, N'Sinaloa')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (21, N'Tabasco')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (22, N'Tamaulipas')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (23, N'San Luis Potosí')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (24, N'Coahuila')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (25, N'Yucatán')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (26, N'Quintana Roo')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (27, N'Tlaxcala')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (28, N'Veracruz')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (29, N'Morelos')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (30, N'Zacatecas')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (31, N'Colima')
 
INSERT [dbo].[Estado] ([clave], [estado]) VALUES (32, N'- Extranjero -')
 
SET IDENTITY_INSERT [dbo].[Estado] OFF
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (-1, N'Rendido', N'El usuario ya no sube mas problemas')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (0, N'Inicia', N'El usuario inicia con tema')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (1, N'Muy facil', N'Problemas que se utilizan para epxlicacion de tema')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (2, N'Facil', N'Problemas que tiene ligeras modificaciones')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (3, N'Medio', N'Problemas que es necesarion pensar para resolverlo')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (4, N'Dificil', N'Problemas que requieren un analisis para ser resuletos')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (5, N'Muy Dificil', N'Probelmas mas dificil que los niveles anteriores')
 
INSERT [dbo].[Nivel] ([idNivel], [nombre], [descripcion]) VALUES (6, N'Completo', N'El usuario completo todos los problemas')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (1, N'Asesor')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2, N'Líder')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (3, N'Delegado')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (4, N'COMI')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (5, N'Invitado')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (6, N'Comité Estatal')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2014, N'OMI 2014 Hidalgo')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2015, N'OMI 2015 Chihuahua')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2016, N'OMI 2016 Veracruz')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2017, N'OMI 2017 Querétaro')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2018, N'OMI 2018')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2019, N'OMI 2019')
 
INSERT [dbo].[OMI] ([OMI], [lugar]) VALUES (2020, N'OMI 2020')
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12846, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12889, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12899, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12853, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12939, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12922, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12901, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12895, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12940, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12916, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12941, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12890, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12875, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12877, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12847, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12858, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12929, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12862, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12857, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12856, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12942, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12868, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12909, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12918, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12930, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12896, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12887, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12864, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12859, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12914, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12951, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12937, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12879, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12888, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12892, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12931, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12849, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12866, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12882, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12880, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12884, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12881, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12861, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12851, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12885, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12886, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12897, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12933, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12876, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12900, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12893, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12898, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12883, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12923, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12908, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12907, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12903, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12891, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12863, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12911, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12935, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12867, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12870, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12904, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12932, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12919, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12878, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12854, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12928, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12917, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12894, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12865, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12934, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12920, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12905, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12938, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12872, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12850, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12913, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12912, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12961, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12924, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12902, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12925, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12957, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12952, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12953, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12874, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12855, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12915, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12871, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12927, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12860, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12869, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12956, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12936, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12945, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12852, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12948, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12960, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12971, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12967, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12926, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12950, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12954, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12965, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12955, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12959, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12958, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12944, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12964, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12873, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12949, 4)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12921, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12943, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12906, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12947, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12910, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12962, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12963, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12966, 2)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12970, 3)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12969, 1)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12972, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12946, 5)
 
INSERT [dbo].[problemaDificultad] ([problema], [dificultad]) VALUES (12968, 5)
 
