CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

--Scaffold-DbContext "Server=.; Database= HCardenasProgramcionNCapas; TrustServerCertificate=True; User ID=sa; Password=pass@word1;" Microsoft.EntityFrameworkCore.SqlServer

INSERT INTO Role (Name)
VALUES ('Usuario'),
	   ('Administador')

SELECT * FROM Role

INSERT INTO Usuario
(
	UserName,
	Nombre,
	ApellidoPaterno,
	ApellidoMaterno,
	Email,
	Password,
	Sexo,
	Telefono,
	Celular,
	FechaNacimiento,
	CURP,
	Image,
	IdRole
)
VALUES
	('Ender','Hugo', 'Cardenas','Gonzalez','HCarddenas@hotmail.com','1345','M','5435351316','52662','1999-03-23','2385049571','ferg43gg3',2),
	('Isra','Israel','Cardenas','Gonzalez','IGonzalez@hotmail.com','2666','M','6272112789','64217','1999-03-23','2385049571','ghrege',2),
	('jess','Jessica','Navarrete','Rocha','jessNva@hotmail.com','5552','F','3573446790','23578','1999-06-15','2385049571','jetjej',1),
	('Huesos','Etan','Olalde','Perez','EtnOlaldes@hotmail.com','5344','M','2566334621','77543','1999-06-10','2385049571','jytjetgrgnhj',1),
	('richi','Ricardo','Perez','Verde','richi@hotmail.com','9650','M','126743899','22765','1999-08-15','2385049571','yeryer65',1);

CREATE PROCEDURE UsuarioAdd
@UserName VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(254),
@Password VARCHAR(50),
@Sexo CHAR(2),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@FechaNacimiento DATE,
@CURP VARCHAR(50),
@Image VARCHAR(MAX),
@IdRole INT
AS
INSERT INTO Usuario
(
	UserName,
	Nombre,
	ApellidoPaterno,
	ApellidoMaterno,
	Email,
	Password,
	Sexo,
	Telefono,
	Celular,
	FechaNacimiento,
	CURP,
	Image,
	IdRole
)
VALUES
(
	@UserName,
	@Nombre,
	@ApellidoPaterno,
	@ApellidoMaterno,
	@Email,
	@Password,
	@Sexo,
	@Telefono,
	@Celular,
	@FechaNacimiento,
	@CURP,
	@Image,
	@IdRole
)

CREATE PROCEDURE UsuarioDelete 
@IdUsuario INT
AS
DELETE FROM Usuario
WHERE IdUsuario = @IdUsuario

CREATE PROCEDURE UsuarioUpdate
@IdUsuario INT,
@UserName VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(254),
@Password VARCHAR(50),
@Sexo CHAR(2),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@FechaNacimiento DATE,
@CURP VARCHAR(50),
@Image VARCHAR(MAX),
@IdRole INT
AS
UPDATE Usuario
SET UserName = @UserName,
	Nombre = @Nombre,
	ApellidoPaterno = @ApellidoPaterno,
	ApellidoMaterno = @ApellidoMaterno,
	Email  = @Email,
	Password = @Password,
	Sexo = @Sexo,
	Telefono = @Telefono,
	Celular = @Celular,
	FechaNacimiento = @FechaNacimiento,
	CURP = @CURP,
	Image = @Image,
	IdRole = @IdRole
WHERE IdUsuario = @IdUsuario

EXEC 

CREATE PROCEDURE UsuarioGetAll '','',''
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.Nombre,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno,
		Usuario.Email,
		Usuario.Password,
		Usuario.Sexo,
		Usuario.Telefono,
		Usuario.Celular,
		Usuario.FechaNacimiento,
		Usuario.CURP,
		Usuario.Image,
		Usuario.IdRole,
		Role.Name AS NombreRole
FROM Usuario
INNER JOIN Role ON Usuario.IdRole = Role.IdRole

CREATE PROCEDURE UsuarioById
@IdUsuario INT
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.Nombre,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno,
		Usuario.Email,
		Usuario.Password,
		Usuario.Sexo,
		Usuario.Telefono,
		Usuario.Celular,
		Usuario.FechaNacimiento,
		Usuario.CURP,
		Usuario.Image,
		Usuario.IdRole,
		Role.Name AS NombreRole
FROM Usuario
INNER JOIN Role ON Usuario.IdRole = Role.IdRole
WHERE IdUsuario = @IdUsuario

CREATE PROCEDURE RoleGetAll
AS
SELECT	Role.IdRole,
		Role.Name
FROM ROLE

ALTER PROCEDURE UsuarioAdd
@UserName VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(254),
@Password VARCHAR(50),
@Sexo CHAR(2),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@FechaNacimiento DATE,
@CURP VARCHAR(50),
@Image VARCHAR(MAX),
@IdRole INT,

@Calle VARCHAR(50),
@NumeroInterios VARCHAR(50),
@Numeroexterior VARCHAR(50),
@IdColonia INT
AS
INSERT INTO Usuario
(
	UserName,
	Nombre,
	ApellidoPaterno,
	ApellidoMaterno,
	Email,
	Password,
	Sexo,
	Telefono,
	Celular,
	Estatus,
	FechaNacimiento,
	CURP,
	Image,
	IdRole
)
VALUES
(
	@UserName,
	@Nombre,
	@ApellidoPaterno,
	@ApellidoMaterno,
	@Email,
	@Password,
	@Sexo,
	@Telefono,
	@Celular,
	1,
	@FechaNacimiento,
	@CURP,
	@Image,
	@IdRole
)

INSERT INTO Direccion
(
	Calle,
	NumeroInterios,
	Numeroexterior,
	IdColonia,
	IdUsuario
)
VALUES
(
	@Calle,
	@NumeroInterios,
	@Numeroexterior,
	@IdColonia,
	@@IDENTITY	
)

ALTER PROCEDURE UsuarioGetAll
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.Nombre,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno,
		Usuario.Email,
		Usuario.Password,
		Usuario.Sexo,
		Usuario.Telefono,
		Usuario.Celular,
		Usuario.FechaNacimiento,
		Usuario.CURP,
		Usuario.Image,
		Usuario.IdRole,
		Role.Name AS NombreRole,
		Direccion.IdDireccion,
		Direccion.Calle,
		Direccion.NumeroInterios	,
		Direccion.Numeroexterior,
		Colonia.IdColonia,
		Colonia.Nombre AS NombreColonia,
		Municipio.IdMunicipio,
		Municipio.Nombre AS NombreMunicipio,
		Estado.IdEstado,
		Estado.Nombre AS NombreEstado,
		Pais.IdPais,
		Pais.Nombre AS NombrePais
FROM Usuario
INNER JOIN Role ON Usuario.IdRole = Role.IdRole
INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.idUsuario
INNER JOIN Colonia ON Colonia.IdColonia = Direccion.idColonia
INNER JOIN Municipio ON Municipio.IdMunicipio = Colonia.IdMunicipio
INNER JOIN Estado ON Estado.IdEstado = Municipio.IdEstado
INNER JOIN Pais ON Pais.IdPais = Estado.IdEstado

ALTER PROCEDURE UsuarioDelete 
@IdUsuario INT
AS
DELETE FROM Direccion
WHERE IdUsuario = @IdUsuario
DELETE FROM Usuario
WHERE IdUsuario = @IdUsuario

SELECT * FROM Usuario
SELECT * FROM Direccion

ALTER PROCEDURE	UsuarioById 1
@IdUsuario INT
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.Nombre,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno,
		Usuario.Email,
		Usuario.Password,
		Usuario.Sexo,
		Usuario.Telefono,
		Usuario.Celular,
		Usuario.Estatus,
		Usuario.FechaNacimiento,
		Usuario.CURP,
		Usuario.Image,
		Usuario.IdRole,
		Role.Name AS NombreRole,
		Direccion.IdDireccion,
		Direccion.Calle,
		Direccion.NumeroInterios	,
		Direccion.Numeroexterior,
		Colonia.IdColonia,
		Colonia.Nombre AS NombreColonia,
		Municipio.IdMunicipio,
		Municipio.Nombre AS NombreMunicipio,
		Estado.IdEstado,
		Estado.Nombre AS NombreEstado,
		Pais.IdPais,
		Pais.Nombre AS NombrePais
FROM Usuario
INNER JOIN Role ON Usuario.IdRole = Role.IdRole
INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.idUsuario
INNER JOIN Colonia ON Colonia.IdColonia = Direccion.idColonia
INNER JOIN Municipio ON Municipio.IdMunicipio = Colonia.IdMunicipio
INNER JOIN Estado ON Estado.IdEstado = Municipio.IdEstado
INNER JOIN Pais ON Pais.IdPais = Estado.IdPais
WHERE Usuario.IdUsuario = @IdUsuario

ALTER PROCEDURE UsuarioUpdate
@IdUsuario INT,
@UserName VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(254),
@Password VARCHAR(50),
@Sexo CHAR(2),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@FechaNacimiento DATE,
@CURP VARCHAR(50),
@Image VARCHAR(MAX),
@IdRole INT,

@Calle VARCHAR(50),
@NumeroInterios VARCHAR(50),
@Numeroexterior VARCHAR(50),
@IdColonia INT
AS
UPDATE Usuario
SET UserName = @UserName,
	Nombre = @Nombre,
	ApellidoPaterno = @ApellidoPaterno,
	ApellidoMaterno = @ApellidoMaterno,
	Email  = @Email,
	Password = @Password,
	Sexo = @Sexo,
	Telefono = @Telefono,
	Celular = @Celular,
	Estatus = Estatus,
	FechaNacimiento = @FechaNacimiento,
	CURP = @CURP,
	Image = @Image,
	IdRole = @IdRole
WHERE IdUsuario = @IdUsuario

UPDATE Direccion
SET	Calle = @Calle,
	NumeroInterios = @NumeroInterios,
	Numeroexterior = @Numeroexterior,
	IdColonia = @IdColonia,
	IdUsuario =@IdUsuario
WHERE IdUsuario = @IdUsuario

ALTER PROCEDURE UsuarioGetAll '','',''
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
IF @Nombre = '' AND @ApellidoPaterno = '' AND @ApellidoMaterno = ''
BEGIN
	SELECT	Usuario.IdUsuario,
			Usuario.UserName,
			Usuario.Nombre,
			Usuario.ApellidoPaterno,
			Usuario.ApellidoMaterno,
			Usuario.Email,
			Usuario.Password,
			Usuario.Sexo,
			Usuario.Telefono,
			Usuario.Celular,
			Usuario.FechaNacimiento,
			Usuario.CURP,
			Usuario.Estatus,
			Usuario.Image,
			Usuario.IdRole,
			Role.Name AS NombreRole,
			Direccion.IdDireccion,
			Direccion.Calle,
			Direccion.NumeroInterios,
			Direccion.Numeroexterior,
			Colonia.IdColonia,
			Colonia.Nombre AS NombreColonia,
			Municipio.IdMunicipio,
			Municipio.Nombre AS NombreMunicipio,
			Estado.IdEstado,
			Estado.Nombre AS NombreEstado,
			Pais.IdPais,
			Pais.Nombre AS NombrePais
	FROM Usuario
	INNER JOIN Role ON Usuario.IdRole = Role.IdRole
	INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.idUsuario
	INNER JOIN Colonia ON Colonia.IdColonia = Direccion.idColonia
	INNER JOIN Municipio ON Municipio.IdMunicipio = Colonia.IdMunicipio
	INNER JOIN Estado ON Estado.IdEstado = Municipio.IdEstado
	INNER JOIN Pais ON Pais.IdPais = Estado.IdPais
END
ELSE
BEGIN
	SELECT	Usuario.IdUsuario,
			Usuario.UserName,
			Usuario.Nombre,
			Usuario.ApellidoPaterno,
			Usuario.ApellidoMaterno,
			Usuario.Email,
			Usuario.Password,
			Usuario.Sexo,
			Usuario.Telefono,
			Usuario.Celular,
			Usuario.FechaNacimiento,
			Usuario.CURP,
			Usuario.Estatus,
			Usuario.Image,
			Usuario.IdRole,
			Role.Name AS NombreRole,
			Direccion.IdDireccion,
			Direccion.Calle,
			Direccion.NumeroInterios	,
			Direccion.Numeroexterior,
			Colonia.IdColonia,
			Colonia.Nombre AS NombreColonia,
			Municipio.IdMunicipio,
			Municipio.Nombre AS NombreMunicipio,
			Estado.IdEstado,
			Estado.Nombre AS NombreEstado,
			Pais.IdPais,
			Pais.Nombre AS NombrePais
	FROM Usuario
	INNER JOIN Role ON Usuario.IdRole = Role.IdRole
	INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.idUsuario
	INNER JOIN Colonia ON Colonia.IdColonia = Direccion.idColonia
	INNER JOIN Municipio ON Municipio.IdMunicipio = Colonia.IdMunicipio
	INNER JOIN Estado ON Estado.IdEstado = Municipio.IdEstado
	INNER JOIN Pais ON Pais.IdPais = Estado.IdPais

	WHERE Usuario.Nombre LIKE '%'+ @Nombre +'%'
	AND Usuario.ApellidoPaterno LIKE '%'+ @ApellidoPaterno +'%'
	AND Usuario.ApellidoMaterno LIKE '%'+ @ApellidoMaterno +'%'
END

CREATE PROCEDURE UsuarioEstatus
@IdUsuario INT,
@Estatus BIT
AS
UPDATE Usuario
SET Estatus = @Estatus
WHERE IdUsuario = @IdUsuario

ALTER PROCEDURE UsuarioByUserName
@UserName VARCHAR(50)
AS
SELECT	Usuario.IdUsuario,
		Usuario.UserName,
		Usuario.Nombre,
		Usuario.ApellidoPaterno,
		Usuario.ApellidoMaterno,
		Usuario.Email,
		Usuario.Password,
		Usuario.Sexo,
		Usuario.Telefono,
		Usuario.Celular,
		Usuario.Estatus,
		Usuario.FechaNacimiento,
		Usuario.CURP,
		Usuario.Image,
		Usuario.IdRole,
		Role.Name AS NombreRole,
		Direccion.IdDireccion,
		Direccion.Calle,
		Direccion.NumeroInterios	,
		Direccion.Numeroexterior,
		Colonia.IdColonia,
		Colonia.Nombre AS NombreColonia,
		Municipio.IdMunicipio,
		Municipio.Nombre AS NombreMunicipio,
		Estado.IdEstado,
		Estado.Nombre AS NombreEstado,
		Pais.IdPais,
		Pais.Nombre AS NombrePais
FROM Usuario
INNER JOIN Role ON Usuario.IdRole = Role.IdRole
INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.idUsuario
INNER JOIN Colonia ON Colonia.IdColonia = Direccion.idColonia
INNER JOIN Municipio ON Municipio.IdMunicipio = Colonia.IdMunicipio
INNER JOIN Estado ON Estado.IdEstado = Municipio.IdEstado
INNER JOIN Pais ON Pais.IdPais = Estado.IdPais
WHERE Usuario.UserName = @UserName

