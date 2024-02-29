CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

CREATE TABLE Users
(
    IdUser INT IDENTITY(1,1) CONSTRAINT PK_Users PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MotherLastName VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    PostalCode VARCHAR(5) NOT NULL,
)

ALTER TABLE Users
ADD  UserName VARCHAR(50) NOT NULL DEFAULT(''),
	 Birthday DATE NOT NULL DEFAULT(''),
	 Gender CHAR(2) NOT NULL DEFAULT(''),
	 MobileNumber VARCHAR(10) NOT NULL DEFAULT(''),
	 CURP VARCHAR(50) NOT NULL DEFAULT(''),
	 Image VARCHAR(MAX) NOT NULL DEFAULT('')

ALTER TABLE Users
ADD IdRole TINYINT NOT NULL CONSTRAINT FK_User
	FOREIGN KEY (IdRole)
	REFERENCES Role(IdRole)

CREATE TABLE Usuario
(
	IdUsuario INT IDENTITY(1,1) CONSTRAINT PK_Usuario PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL UNIQUE,
	Nombre VARCHAR(50) NOT NULL,
	ApellidoPaterno VARCHAR(50) NOT NULL,
	ApellidoMaterno VARCHAR(50) NOT NULL,
	Email VARCHAR(254) NOT NULL UNIQUE,
	Password VARCHAR(50) NOT NULL,
	Sexo CHAR(2) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	Celular VARCHAR(20) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	CURP VARCHAR(50) NOT NULL DEFAULT(''),
	Image VARCHAR(MAX) NOT NULL DEFAULT(''),
	IdRole TINYINT NOT NULL CONSTRAINT FK_Usuario
	FOREIGN KEY (IdRole)
	REFERENCES Role(IdRole)
)

ALTER TABLE Usuario
ADD  Estatus BIT

CREATE TABLE Role
(
	IdRole TINYINT IDENTITY(1,1) CONSTRAINT PK_Roles PRIMARY KEY,
	Nombre varchar(50) NOT NULL,
)

CREATE TABLE Aseguradora
(
	IdAseguradora INT IDENTITY(1,1) CONSTRAINT PK_Aseguradora PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	FechaCreacion DATETIME,
	FechaModificacion DATETIME,
	IdUsuario INT NOT NULL CONSTRAINT FK_Aseguradora
	FOREIGN KEY (IdUsuario)
	REFERENCES Usuario(IdUsuario)
)

CREATE TABLE Direccion
(
	IdDireccion INT IDENTITY(1,1) CONSTRAINT PK_Direccion PRIMARY KEY,
	Calle VARCHAR(50) NOT NULL,
	NumeroInterios VARCHAR(50) NULL,
	Numeroexterior VARCHAR(50) NOT NULL,
	IdColonia INT NOT NULL CONSTRAINT FK_DireccionColonia
	FOREIGN KEY (IdColonia)
	REFERENCES Colonia(IdColonia),
	IdUsuario INT NOT NULL CONSTRAINT FK_DireccionUsuario
	FOREIGN KEY (IdUsuario)
	REFERENCES usuario(IdUsuario)
)

CREATE TABLE Empleado
(
	NumeroEmpleado VARCHAR(50) CONSTRAINT PK_Empleado PRIMARY KEY NOT NULL,
	RFC VARCHAR(20),
	Nombre VARCHAR(50) NOT NULL,
	ApellidoPaterno VARCHAR(50) NOT NULL,
	ApelldioMaterno VARCHAR(50) NOT NULL,
	Email VARCHAR(254) NOT NULL UNIQUE,
	Telefono VARCHAR(20) NOT NULL,
	FechaNacimiento DATE NULL,
	NSS VARCHAR(20),
	FechaIngreso DATE,
	Foto VARCHAR(MAX),
	IdEmpresa INT NOT NULL CONSTRAINT FK_Empleado
	FOREIGN KEY (IdEmpresa)
	REFERENCES Empresa(IdEmpresa)
)

CREATE TABLE Empresa
(
	IdEmpresa INT IDENTITY(1,1) CONSTRAINT PK_Empresa PRIMARY KEY,
	Nombre VARCHAR(50),
	Telefono VARCHAR(50),
	Email VARCHAR(50),
	DireccionWeb VARCHAR(100),
	Logo VARBINARY(MAX)
)

CREATE TABLE Colonia
(
	IdColonia INT IDENTITY(1,1) CONSTRAINT PK_Colonoa PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	CodigoPostal VARCHAR(50) NOT NULL,
	IdMunicipio INT NOT NULL CONSTRAINT FK_Colonia
	FOREIGN KEY (IdMunicipio)
	REFERENCES Municipio(IdMunicipio)
)

CREATE TABLE Poliza
(
	IdPoliza INT IDENTITY(1,1) CONSTRAINT PK_Poliza PRIMARY KEY,
	Nombre VARCHAR(100),
	IdSubPoliza TINYINT NOT NULL CONSTRAINT FK_Poliza_SubPoliza
	FOREIGN KEY (IdSubPoliza)
	REFERENCES SubPoliza(IdSubPoliza),
	NumeroPoliza VARCHAR(20),
	FechaCreacion DATETIME,
	FechaModificacion DATETIME,
	IdUsuario INT NOT NULL CONSTRAINT FK_Poliza_Usuario
	FOREIGN KEY (IdUsuario)
	REFERENCES Usuario(IdUsuario)
)

CREATE TABLE SubPoliza
(
	IdSubPoliza TINYINT IDENTITY(1,1) CONSTRAINT PK_SubPoliza PRIMARY KEY,
	Nombre VARCHAR(100)
)

CREATE TABLE Pais
(
	IdPais INT IDENTITY(1,1) CONSTRAINT PK_Pais PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)

CREATE TABLE Estado
(
	IdEstado INT IDENTITY(1,1) CONSTRAINT PK_Estado PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	IdPais INT NOT NULL CONSTRAINT FK_Estado
	FOREIGN KEY (IdPais)
	REFERENCES Pais(IdPais)
)

CREATE TABLE Municipio
(
	IdMunicipio INT IDENTITY(1,1) CONSTRAINT PK_Municipio PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	IdEstado INT NOT NULL CONSTRAINT FK_Municipio
	FOREIGN KEY (IdEstado)
	REFERENCES Estado(IdEstado)
)

CREATE TABLE EmpresaPoliza
(
	IdAseguradoraPoliza INT,
	IdAseguradora INT,
	IdPoliza INT,
	FechaCreacion DATE,
	FechaModificacion DATE,
	IdUser INT NOT NULL CONSTRAINT FK_EmpresaPoliza
	FOREIGN KEY (IdUser)
	REFERENCES Users(IdUSer)
)

CREATE TABLE Dependiente
(
	IdDependiente INT IDENTITY(1,1) CONSTRAINT PK_Dependiente PRIMARY KEY,
	NumeroEmpleado VARCHAR(50) NOT NULL CONSTRAINT FK_Dependiente_Empleado
	FOREIGN KEY (NumeroEmpleado)
	REFERENCES Empleado(NumeroEmpleado),
	Nombre VARCHAR(50) NOT NULL,
	ApellidoPaterno VARCHAR(50) NOT NULL,
	ApellidoMaterno VARCHAR(50) NOT NULL,
	FechaNacimiento DATE,
	EstadoCivil VARCHAR(10),
	Genero CHAR(2) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	RFC VARCHAR(20) NOT NULL,
	IdDependienteTipo INT NOT NULL CONSTRAINT FK_Dependiente_TIpo
	FOREIGN KEY (IdDependienteTipo)
	REFERENCES DependienteTipo(IdDependienteTipo),
)

CREATE TABLE DependienteTipo
(
	IdDependienteTipo INT IDENTITY(1,1) CONSTRAINT PK_DependienteTipo PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)









INSERT INTO Role (Name)
VALUES ('Usuario'),
	   ('Administador')

SELECT * FROM Role

INSERT INTO Users
(
    FirstName,
	LastName,
	MotherLastName,
    Email,
    Password,
    PhoneNumber,
	PostalCode,
	UserName,
	Birthday,
	Gender,
	MobileNumber,
	CURP,
	Image,
	IdRole
)
VALUES
	('Hugo', 'Cardenas','Gonzalez','HCarddenas@hotmail.com','1345','5435351316','52662','Ender','1999-03-23','M','2385049571','ferg43gg3','33jpg',2),
	('Israel','Cardenas','Gonzalez','IGonzalez@hotmail.com','2666','6272112789','64217','Isra','1999-03-23','M','2385049571','ghrege','33jpg',2),
	('Jessica','Navarrete','Rocha','jessNva@hotmail.com','5552','3573446790','23578','jess','1999-06-15','F','2385049571','jetjej','33jpg',1),
	('Etan','Olalde','Perez','EtnOlaldes@hotmail.com','5344','2566334621','77543','Huesos','1999-06-10','M','2385049571','jytjetgrgnhj','33jpg',1),
	('Ricardo','Perez','Verde','richi@hotmail.com','9650','126743899','22765','richi','1999-08-15','M','2385049571','yeryer65','33jpg',1);
