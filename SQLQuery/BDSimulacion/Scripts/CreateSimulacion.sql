INSERT INTO SimulacionKarelotitlan.dbo.Simulacion (inicio)
VALUES(SYSDATETIME ())
SELECT SCOPE_IDENTITY()

/// http://stackoverflow.com/questions/5228780/how-to-get-last-inserted-id