SELECT TOP 3 *,(126-sqrt(2*inversiones))*iguales*complemento AS score FROM SimulacionKarelotitlan.dbo.Inversion
WHERE u1 = 1
ORDER BY score DESC
