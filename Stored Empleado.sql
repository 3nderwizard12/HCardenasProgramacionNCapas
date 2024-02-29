CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

INSERT INTO Empresa
(
	Nombre,
	Telefono,
	Email,
	DireccionWeb,
	Logo
)
VALUES
	('Lego','5419405315', 'lego@hotmail.com','www',01),
	('Amazon','1268543278','Amazon@hotmail.com','www',01)

SELECT * FROM Empresa

CREATE PROCEDURE EmpresaGetAll
AS
SELECT	IdEmpresa,
		Nombre,
		Telefono,
		Email,
		DireccionWeb,
		Logo
FROM Empresa

CREATE PROCEDURE EmpresabyId
@IdEmpresa INT
AS
SELECT	IdEmpresa,
		Nombre,
		Telefono,
		Email,
		DireccionWeb,
		Logo
FROM Empresa
WHERE IdEmpresa = @IdEmpresa


INSERT INTO Empleado
(
	NumeroEmpleado,
	RFC,
	Nombre,
	ApellidoPaterno,
	ApelldioMaterno,
	Email,
	Telefono,
	FechaNacimiento,
	NSS,
	FechaIngreso,
	Foto,
	IdEmpresa
)
VALUES
	('12l', '24rhtrty4', 'Hugo', 'Cardenas', 'Gonzalez', 'Hugo@hotmail.com', '456785435', '1999-03-23', '87654yhjn',GETDATE(), '', 1),
	('13a', 'u56u65u56', 'Etan', 'Olalde', 'Perez', 'Etan@hotmail.com', '456785767', '1999-06-10', '765tgy6', GETDATE(), '', 2)

SELECT * FROM Empleado

ALTER PROCEDURE EmpleadoAdd --'15a', '24rhtrty4', 'Israel', 'Cardenas', 'Gonzalez', 'Israel@hotmail.com', '456785435', '1999-03-23', '87654yhjn','2023-04-18', '', 1
@NumeroEmpleado VARCHAR(50),
@RFC VARCHAR(20),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApelldioMaterno VARCHAR(50),
@Email VARCHAR(254),
@Telefono VARCHAR(20),
@FechaNacimiento DATE,
@NSS VARCHAR(20),
@Foto VARCHAR(MAX),
@IdEmpresa INT
AS
INSERT INTO Empleado
(
	NumeroEmpleado,
	RFC,
	Nombre,
	ApellidoPaterno,
	ApelldioMaterno,
	Email,
	Telefono,
	FechaNacimiento,
	NSS,
	FechaIngreso,
	Foto,
	IdEmpresa
)
VALUES
(
	@NumeroEmpleado,
	@RFC,
	@Nombre,
	@ApellidoPaterno,
	@ApelldioMaterno,
	@Email,
	@Telefono,
	@FechaNacimiento,
	@NSS,
	GETDATE(),
	@Foto,
	@IdEmpresa
)

CREATE PROCEDURE EmpleadoGetAll
AS
SELECT	Empleado.NumeroEmpleado,
		Empleado.RFC,
		Empleado.Nombre,
		Empleado.ApellidoPaterno,
		Empleado.ApelldioMaterno,
		Empleado.Email,
		Empleado.Telefono,
		Empleado.FechaNacimiento,
		Empleado.NSS,
		Empleado.FechaIngreso,
		Empleado.Foto,
		Empleado.IdEmpresa,
		Empleado.Nombre AS NombreEmpresa
FROm Empleado

CREATE PROCEDURE EmpleadoDelete
@NumeroEmpleado VARCHAR(50)
AS
DELETE FROM Empleado
WHERE NumeroEmpleado = @NumeroEmpleado

ALTER PROCEDURE EmpleadoUpdate
@NumeroEmpleado VARCHAR(50),
@RFC VARCHAR(20),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApelldioMaterno VARCHAR(50),
@Email VARCHAR(254),
@Telefono VARCHAR(20),
@FechaNacimiento DATE,
@NSS VARCHAR(20),
@Foto VARCHAR(MAX),
@IdEmpresa INT
AS
UPDATE Empleado
SET	NumeroEmpleado = @NumeroEmpleado,
	RFC = @RFC,
	Nombre = @Nombre,
	ApellidoPaterno = @ApellidoPaterno,
	@ApelldioMaterno = @ApelldioMaterno,
	@Email = @Email,
	@Telefono = @Telefono,
	FechaNacimiento = @FechaNacimiento,
	NSS = @NSS,
	Foto = @Foto,
	IdEmpresa = @IdEmpresa
WHERE Empleado.NumeroEmpleado = @NumeroEmpleado

ALTER PROCEDURE EmpleadoGetAll
AS
SELECT
		Empleado.NumeroEmpleado,
		Empleado.RFC,
		Empleado.Nombre,
		Empleado.ApellidoPaterno,
		Empleado.ApelldioMaterno,
		Empleado.Email,
		Empleado.Telefono,
		Empleado.FechaNacimiento,
		Empleado.NSS,
		Empleado.FechaIngreso,
		Empleado.Foto,
		Empleado.IdEmpresa,
		Empresa.Nombre AS NombreEmpresa
FROM Empleado
INNER JOIN Empresa ON Empleado.IdEmpresa = Empresa.IdEmpresa

CREATE PROCEDURE EmpleadoById '12l'
@NumeroEmpleado VARCHAR(50)
AS
SELECT
		Empleado.NumeroEmpleado,
		Empleado.RFC,
		Empleado.Nombre,
		Empleado.ApellidoPaterno,
		Empleado.ApelldioMaterno,
		Empleado.Email,
		Empleado.Telefono,
		Empleado.FechaNacimiento,
		Empleado.NSS,
		Empleado.FechaIngreso,
		Empleado.Foto,
		Empleado.IdEmpresa,
		Empresa.Nombre AS NombreEmpresa
FROM Empleado
INNER JOIN Empresa ON Empleado.IdEmpresa = Empresa.IdEmpresa
WHERE NumeroEmpleado = @NumeroEmpleado