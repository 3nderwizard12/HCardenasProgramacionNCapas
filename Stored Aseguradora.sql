CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

INSERT INTO Aseguradora
(
	Nombre,
	FechaCreacion,
	FechaModificacion,
	IdUsuario
)
VALUES
(
	'nose','2018-04-15','2018-05-01',2
)

CREATE PROCEDURE AseguradoraAdd
@Nombre VARCHAR(50),
@IdUsuario INT
AS
INSERT INTO Aseguradora
(
	Nombre,
	FechaCreacion,
	FechaModificacion,
	IdUsuario
)
VALUES
(
	@Nombre,
	GETDATE(),
	GETDATE(),
	@IdUsuario
)

CREATE PROCEDURE AseguradoraDelete 
@IdAseguradora INT
AS
DELETE FROM Aseguradora
WHERE IdAseguradora = @IdAseguradora

CREATE PROCEDURE AseguradoraUpdate
@IdAseguradora INT,
@Nombre VARCHAR(50),
@IdUsuario INT
AS
UPDATE Aseguradora
SET Nombre = @Nombre,
	FechaModificacion = GETDATE(),
	IdUsuario = @IdUsuario
WHERE IdAseguradora = @IdAseguradora

CREATE PROCEDURE AseguradoraGetAll
AS
SELECT	Aseguradora.IdAseguradora,
		Aseguradora.Nombre,
		Aseguradora.FechaCreacion,
		Aseguradora.FechaModificacion,
		Usuario.IdUsuario,
		Usuario.Nombre AS NombreUsuario,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno
FROM Aseguradora
INNER JOIN Usuario ON Aseguradora.IdUsuario = Usuario.IdUsuario

CREATE PROCEDURE AseguradoraById 2
@IdAseguradora INT
AS
SELECT	Aseguradora.IdAseguradora,
		Aseguradora.Nombre,
		Aseguradora.FechaCreacion,
		Aseguradora.FechaModificacion,
		Usuario.IdUsuario,
		Usuario.Nombre AS NombreUsuario,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno
FROM Aseguradora
INNER JOIN Usuario ON Aseguradora.IdUsuario = Usuario.IdUsuario
WHERE IdAseguradora = @IdAseguradora

SELECT * FROM Aseguradora