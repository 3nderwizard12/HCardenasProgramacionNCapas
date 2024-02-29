CREATE DATABASE Mapa
USE Mapa

--Scaffold-DbContext "Server=.; Database= Mapa; TrustServerCertificate=True; User ID=sa; Password=pass@word1;" Microsoft.EntityFrameworkCore.SqlServer -f

CREATE TABLE Cine
(
	IdCine INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	Direccion VARCHAR(50),
	IdZona INT NOT NULL CONSTRAINT FK_Cine
	FOREIGN KEY (IdZona)
	REFERENCES Zona(IdZona),
	Ventas INT
)
GO

CREATE TABLE Zona
(
	IdZona INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)
GO

ALTER PROCEDURE CineAdd
@Nombre VARCHAR(50),
@Direccion VARCHAR(50),
@idZona INT,
@Ventas INT
AS
INSERT INTO Cine
(
	Nombre,
	Direccion,
	IdZona,
	Ventas
)
VALUES
(
	@Nombre,
	@Direccion,
	@idZona,
	@Ventas
)
GO

CREATE PROCEDURE CineDelete 
@IdCine INT
AS
DELETE FROM Cine
WHERE IdCine = @IdCine
GO

Create PROCEDURE CineUpdate
@IdCine INT,
@Nombre VARCHAR(50),
@Direccion VARCHAR(50),
@IdZona INT,
@Ventas INT
AS
UPDATE Cine
SET Nombre = @Nombre,
	Direccion = @Direccion,
	IdZona = @IdZona,
	Ventas = @Ventas
WHERE IdCine = @IdCine
GO

ALTER PROCEDURE CineGetAll
AS
SELECT	Cine.IdCine,
		Cine.Nombre,
		Cine.Direccion,
		Cine.Ventas,
		Zona.IdZona,
		Zona.Nombre AS NombreZona
FROM Cine
INNER JOIN Zona ON Cine.IdZona = Zona.IdZona
GO

CREATE PROCEDURE CineById
@IdCine INT
AS
SELECT	Cine.IdCine,
		Cine.Nombre,
		Cine.Direccion,
		Cine.Ventas,
		Zona.IdZona,
		Zona.Nombre AS NombreZona
FROM Cine
INNER JOIN Zona ON Cine.IdZona = Zona.IdZona
WHERE IdCine = @IdCine
GO

CREATE PROCEDURE ZonaGetAll
AS
SELECT	Zona.IdZona,
		Zona.Nombre
FROM zona

CREATE TABLE Usuario
(
	IdUsuario INT IDENTITY(1,1) CONSTRAINT PK_Usuario PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL UNIQUE,
	NombreCompleto VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Password VARBINARY(20) NOT NULL,
)
GO

CREATE PROCEDURE UsuarioByEmail
@Email VARCHAR(50)
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.NombreCompleto,
		Usuario.Email,
		Usuario.Password
FROM Usuario
WHERE Usuario.Email = @Email
GO

CREATE PROCEDURE UsuarioAdd
@NombreCompleto VARCHAR(50),
@UserName VARCHAR(50),
@Email VARCHAR(50),
@Password VARBINARY(20)
AS
INSERT INTO Usuario
(
	NombreCompleto,
	UserName,
	Email,
	Password
)
VALUES
(
	@NombreCompleto,
	@UserName,
	@Email,
	@Password
)
GO

CREATE PROCEDURE UsuarioById
@IdUsuario INT
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.NombreCompleto,
		Usuario.Email,
		Usuario.Password
FROM Usuario
WHERE Usuario.IdUsuario = @IdUsuario
GO

CREATE PROCEDURE UsuarioFindByEmail
@Email VARCHAR(50)
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.NombreCompleto,
		Usuario.Email,
		Usuario.Password
FROM Usuario
WHERE Usuario.Email = @Email
GO

CREATE PROCEDURE UsuarioUpdate
@Email VARCHAR(50),
@Password VARBINARY(20)
AS 
UPDATE Usuario
SET Password = @Password
WHERE Email = @Email