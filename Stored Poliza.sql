CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

SELECT * FROM Poliza
SELECT * FROM SubPoliza

INSERT INTO SubPoliza
	(Nombre)
VALUES
	('Vida'),
	('Auto')

CREATE PROCEDURE SubPolizaGetAll
AS
SELECT	IdSubPoliza,
		Nombre
FROM SubPoliza

CREATE PROCEDURE SubPolizaById
@IdSubPoliza INT
AS
SELECT	IdSubPoliza,
		Nombre
FROM SubPoliza
WHERE IdSubPoliza = @IdSubPoliza

INSERT INTO Poliza
(
	Nombre,
	IdSubPoliza,
	NumeroPoliza,
	FechaCreacion,
	FechaModificacion,
	IdUsuario
)
VALUES
	('Seguro','4','7654345',GETDATE(),GETDATE(),1),
	('Hogar','3','67654',GETDATE(),GETDATE(),1)


ALTER PROCEDURE PolizaAdd
@Nombre VARCHAR(100),
@NombreSubPoliza VARCHAR(100),
@NumeroPoliza VARCHAR(20),
@IdUsuario INT
AS
INSERT INTO SubPoliza
(
	Nombre
)
VALUES
(
	@NombreSubPoliza
)

INSERT INTO Poliza
(
	Nombre,
	IdSubPoliza,
	NumeroPoliza,
	FechaCreacion,
	FechaModificacion,
	IdUsuario
)
VALUES
(
	@Nombre,
	@@IDENTITY,
	@NumeroPoliza,
	GETDATE(),
	GETDATE(),
	@IdUsuario
)

ALTER PROCEDURE PolizaDelete
@IdPoliza INT
AS
DELETE Pl
FROM Poliza Pl
INNER JOIN SubPoliza ON Pl.IdSubPoliza = SubPoliza.IdSubPoliza
WHERE IdPoliza = @IdPoliza

ALTER PROCEDURE PolizaUpdate
@IdPoliza INT,
@IdSubPoliza INT,
@Nombre VARCHAR(100),
@NombreSubPoliza VARCHAR(100),
@NumeroPoliza VARCHAR(20),
@IdUsuario INT
AS
UPDATE SubPoliza
SET Nombre = @NombreSubPoliza
WHERE IdSubPoliza = @IdSubPoliza
UPDATE Poliza
SET Nombre = @Nombre,
	NumeroPoliza = @NumeroPoliza,
	FechaModificacion = GETDATE(),
	IdUsuario = @IdUsuario
WHERE IdPoliza = @IdPoliza

ALTER PROCEDURE PolizaGetAll
AS
SELECT	Poliza.IdPoliza,
		Poliza.Nombre,
		poliza.IdSubPoliza,
		SubPoliza.Nombre AS NombreSubPoliza,
		Poliza.NumeroPoliza,
		Poliza.FechaCreacion,
		Poliza.FechaModificacion,
		Poliza.IdUsuario,
		Usuario.Nombre AS NombreUsuario,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno
FROM Poliza
INNER JOIN SubPoliza ON Poliza.IdSubPoliza = SubPoliza.IdSubPoliza
INNER JOIN Usuario ON Poliza.IdUsuario = Usuario.idUsuario

ALTER PROCEDURE PolizaById
@IdPoliza INT
AS
SELECT	Poliza.IdPoliza,
		Poliza.Nombre,
		poliza.IdSubPoliza,
		SubPoliza.Nombre AS NombreSubPoliza,
		Poliza.NumeroPoliza,
		Poliza.FechaCreacion,
		Poliza.FechaModificacion,
		Poliza.IdUsuario,
		Usuario.Nombre AS NombreUsuario,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno
FROM Poliza
INNER JOIN SubPoliza ON Poliza.IdSubPoliza = SubPoliza.IdSubPoliza
INNER JOIN Usuario ON Poliza.IdUsuario = Usuario.idUsuario
WHERE Poliza.IdPoliza = @IdPoliza