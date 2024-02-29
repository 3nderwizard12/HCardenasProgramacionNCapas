CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

SELECT * FROM Empleado

INSERT INTO Dependiente
(
	NumeroEmpleado,
	Nombre,
	ApellidoPaterno,
	ApellidoMaterno,
	FechaNacimiento,
	EstadoCivil,
	Genero,
	Telefono,
	RFC,
	IdDependienteTipo
)
VALUES
	('124A','Juan','Florez','Suares','1999-09-05','Soltero','M','437856','537y4hgb45',1),
	('12l','Luis','Mendes','Sanchez','1999-12-12','Soltero','M','56346643','3t5y4hh',2)


INSERT INTO DependienteTipo
(Nombre)
VALUES
	('Mayor'),
	('Nuevo')

SELECT * FROM DependienteTipo

CREATE PROCEDURE DependienteAdd
@NumeroEmpleado VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento DATE,
@EstadoCivil VARCHAR(10),
@Genero CHAR(2),
@Telefono VARCHAR(20),
@RFC VARCHAR(20),
@IdDependienteTipo INT
AS
INSERT INTO Dependiente
(
	NumeroEmpleado,
	Nombre,
	ApellidoPaterno,
	ApellidoMaterno,
	FechaNacimiento,
	EstadoCivil,
	Genero,
	Telefono,
	RFC,
	IdDependienteTipo
)
VALUES
(
	@NumeroEmpleado,
	@Nombre,
	@ApellidoPaterno,
	@ApellidoMaterno,
	@FechaNacimiento,
	@EstadoCivil,
	@Genero,
	@Telefono,
	@RFC,
	@IdDependienteTipo
)

CREATE PROCEDURE DependienteUpdate
@IdDependiente INT,
@NumeroEmpleado VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento DATE,
@EstadoCivil VARCHAR(10),
@Genero CHAR(2),
@Telefono VARCHAR(20),
@RFC VARCHAR(20),
@IdDependienteTipo INT
AS
UPDATE Dependiente
SET	NumeroEmpleado = @NumeroEmpleado,
	Nombre = @Nombre,
	ApellidoPaterno = @ApellidoPaterno,
	ApellidoMaterno = @ApellidoMaterno,
	FechaNacimiento = @FechaNacimiento,
	EstadoCivil = @EstadoCivil,
	Genero = @Genero,
	Telefono = @Telefono,
	RFC = @RFC,
	IdDependienteTipo = @IdDependienteTipo
WHERE IdDependiente = @IdDependiente

CREATE PROCEDURE DependienteByEmpleado
@NumeroEmpleado VARCHAR(50)
AS
SELECT	IdDependiente,
		Dependiente.NumeroEmpleado,
		Empleado.Nombre AS NombreEmpleado,
		Empleado.ApellidoPaterno AS ApellidoPaternoEmpleado,
		Empleado.ApelldioMaterno AS ApelldioMaternoEmpleado,
		Dependiente.Nombre,
		Dependiente.ApellidoPaterno,
		Dependiente.ApellidoMaterno,
		Dependiente.FechaNacimiento,
		EstadoCivil,
		Genero,
		Dependiente.Telefono,
		Dependiente.RFC,
		Dependiente.IdDependienteTipo,
		DependienteTipo.Nombre AS NombreDependienteTipo
FROM Dependiente
INNER JOIN Empleado ON Dependiente.NumeroEmpleado = Empleado.NumeroEmpleado
INNER JOIN DependienteTipo ON Dependiente.IdDependienteTipo = DependienteTipo.IdDependienteTipo
WHERE Dependiente.NumeroEmpleado = @NumeroEmpleado

ALTER PROCEDURE DependienteById
@IdDependiente INt
AS
SELECT	IdDependiente,
		Dependiente.NumeroEmpleado,
		Empleado.Nombre AS NombreEmpleado,
		Empleado.ApellidoPaterno AS ApellidoPaternoEmpleado,
		Empleado.ApelldioMaterno AS ApelldioMaternoEmpleado,
		Dependiente.Nombre,
		Dependiente.ApellidoPaterno,
		Dependiente.ApellidoMaterno,
		Dependiente.FechaNacimiento,
		EstadoCivil,
		Genero,
		Dependiente.Telefono,
		Dependiente.RFC,
		Dependiente.IdDependienteTipo,
		DependienteTipo.Nombre AS NombreDependienteTipo
FROM Dependiente
INNER JOIN Empleado ON Dependiente.NumeroEmpleado = Empleado.NumeroEmpleado
INNER JOIN DependienteTipo ON Dependiente.IdDependienteTipo = DependienteTipo.IdDependienteTipo
WHERE Dependiente.IdDependiente = @IdDependiente

CREATE PROCEDURE DependienteTipoGetAll
AS
SELECT	IdDependienteTipo,
		Nombre
FROM DependienteTipo