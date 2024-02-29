CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

CREATE PROCEDURE DireccionGetAll
AS
SELECT	Direccion.IdDireccion,
		Direccion.Calle,
		Direccion.NumeroInterios,
		Direccion.NumeroExterior,
		Direccion.IdColonia,
		Colonia.Nombre as NombreColonia,
		Direccion.IdUsuario,
		Usuario.Nombre AS NombreUsuario,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno
FROM Direccion
INNER JOIN Colonia ON Direccion.IdColonia = Colonia.IdColonia
INNER JOIN Usuario ON Direccion.IdUsuario = Usuario.IdUsuario

CREATE PROCEDURE DireccionGetById 
@IdDireccion INT
AS
SELECT	Direccion.IdDireccion,
		Direccion.Calle,
		Direccion.NumeroInterios,
		Direccion.NumeroExterior,
		Direccion.IdColonia,
		Colonia.Nombre as NombreColonia,
		Direccion.IdUsuario,
		Usuario.Nombre AS NombreUsuario,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno
FROM Direccion
INNER JOIN Colonia ON Direccion.IdColonia = Colonia.IdColonia
INNER JOIN Usuario ON Direccion.IdUsuario = Usuario.IdUsuario
WHERE IdDIreccion = @IdDireccion

INSERT INTO Direccion
(
	Calle,
	NumeroInterios,
	Numeroexterior,
	IdColonia,
	IdUsuario

)
VALUES
	('Calle 12','2','5',1,2),
	('9 de julio','','115',2,5)

ALTER PROCEDURE ColoniaGetAll
AS
SELECT	Colonia.IdColonia,
		Colonia.Nombre,
		Colonia.CodigoPostal,
		Colonia.IdMunicipio,
		Municipio.Nombre AS NombreMunicipio
FROM Colonia
INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio

ALTER PROCEDURE ColoniaGetById 
@IdMunicipio INT
AS
SELECT	Colonia.IdColonia,
		Colonia.Nombre,
		Colonia.CodigoPostal,
		Colonia.IdMunicipio,
		Municipio.Nombre AS NombreMunicipio
FROM Colonia
INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
WHERE Colonia.IdMunicipio = @IdMunicipio

INSERT INTO Colonia
(
	Nombre,
	CodigoPostal,
	IdMunicipio
)
VALUES
	('La Quebrada','63545',1),
	('Santa Fe','65464',2)


ALTER PROCEDURE MunicipioGetAll
AS
SELECT	Municipio.IdMunicipio,
		Municipio.Nombre,
		Municipio.IdEstado,
		Estado.Nombre AS NombreEstado
FROM Municipio
INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado

ALTER PROCEDURE MunicipioGetById
@IdEstado INT
AS
SELECT	Municipio.IdMunicipio,
		Municipio.Nombre,
		Municipio.IdEstado,
		Estado.Nombre AS NombreEstado
FROM Municipio
INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
WHERE Municipio.IdEstado = @IdEstado

INSERT INTO Municipio
(
	Nombre,
	IdEstado

)
VALUES
	('Cuatitlan Izcalli',1),
	('Alvaro Obregon',2)


ALTER PROCEDURE EstadoGetAll
AS
SELECT	Estado.IdEstado,
		Estado.Nombre,
		Estado.IdPais,
		Pais.Nombre AS NombrePais
FROM Estado
INNER JOIN Pais ON Estado.IdPais = Pais.IdPais


ALTER PROCEDURE EstadoGetById
@IdPais INT
AS
SELECT	Estado.IdEstado,
		Estado.Nombre,
		Estado.IdPais,
		Pais.Nombre AS NombrePais
FROM Estado
INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
WHERE Estado.IdPais = @IdPais

INSERT INTO Estado
(
	Nombre,
	IdPais

)
VALUES
	('Estado de Mexico',1),
	('Distrito Federal',1)


CREATE PROCEDURE PaisGetAll
AS
SELECT	Pais.IdPais,
		Pais.Nombre
FROM Pais

CREATE PROCEDURE PaisGetById 1
@IdPais INT
AS
SELECT	Pais.IdPais,
		Pais.Nombre
FROM Pais
WHERE IdPais = @IdPais

INSERT INTO Pais
(
	Nombre
)
VALUES
	('Mexico'),
	('Canada')

pass@word1