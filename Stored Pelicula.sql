CREATE DATABASE Peliculas
USE Peliculas

CREATE TABLE Pelicula
(
	IdPelicula INT IDENTITY(1,1) CONSTRAINT PK_Pelicula PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	FechaLanzamiento DATE NOT NULL,
	Review VARCHAR(100),
	Puntuacion INT,
	IdDirector INT NOT NULL CONSTRAINT FK_Pelicula
	FOREIGN KEY (IdDirector)
	REFERENCES Director(IdDirector)
)

CREATE TABLE Director
(
	IdDirector INT IDENTITY(1,1) CONSTRAINT PK_Director PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)

INSERT INTO Director (Nombre)
VALUES ('Guillermo'),
	   ('Alfonso')

CREATE PROCEDURE PeliculaAdd
@Nombre VARCHAR(50),
@FechaLanzamiento DATE,
@Review VARCHAR(100),
@Puntuacion INT,
@IdDirector INT
AS
INSERT INTO Pelicula
(
	Nombre,
	FechaLanzamiento,
	Review,
	Puntuacion,
	IdDirector
)
VALUES
(
	@Nombre,
	@FechaLanzamiento,
	@Review,
	@Puntuacion,
	@IdDirector
)

CREATE PROCEDURE PeliculaDelete
@IdPelicula INT
AS
DELETE FROM Pelicula
WHERE IdPelicula = @IdPelicula

CREATE PROCEDURE PeliculaUpdate
@IdPelicula INT,
@Nombre VARCHAR(50),
@FechaLanzamiento DATE,
@Review VARCHAR(100),
@Puntuacion INT,
@IdDirector INT
AS
UPDATE Pelicula
SET Nombre = @Nombre,
	FechaLanzamiento = @FechaLanzamiento,
	Review = @Review,
	Puntuacion = @Puntuacion,
	IdDirector = @IdDirector
WHERE IdPelicula = @IdPelicula

ALTER PROCEDURE PeliculaGetAll
AS
SELECT	Pelicula.IdPelicula,
		Pelicula.Nombre,
		Pelicula.FechaLanzamiento,
		Pelicula.Review,
		Pelicula.Puntuacion,
		Pelicula.IdDirector,
		Director.Nombre AS NombrePelicula
FROM Pelicula
INNER JOIN Director ON Pelicula.IdDirector = Director.IdDirector

CREATE PROCEDURE PeliculaById
@IdPelicula INT
AS
SELECT	Pelicula.Nombre,
		Pelicula.FechaLanzamiento,
		Pelicula.Review,
		Pelicula.Puntuacion,
		Pelicula.IdDirector,
		Director.Nombre AS NombrePelicula
FROM Pelicula
INNER JOIN Director ON Pelicula.IdDirector = Director.IdDirector
WHERE IdPelicula = @IdPelicula

SELECT * FROM Pelicula