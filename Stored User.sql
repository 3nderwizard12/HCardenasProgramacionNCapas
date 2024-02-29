CREATE DATABASE HCardenasProgramcionNCapas
USE HCardenasProgramcionNCapas

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

-------------------------------------------------------------------

DELETE FROM User WHERE IdUser = 1

UPDATE User
SET Name = 'Jose Ricardo Perez',Email = 'richi@hotmail.com',Password = '9650',PhoneNumber = '126743899',PostalCode = '22765'
WHERE IdUser = 5

SELECT * FROM Users WHERE UsersId = 22

--------------------------------------------------------------------

CREATE PROCEDURE UserAdd
@Name VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(50),
@PhoneNumber VARCHAR(10),
@PostalCode VARCHAR(5)
AS
INSERT INTO Users
(
    Name,
    Email,
    Password,
    PhoneNumber,
	PostalCode	
)
VALUES
(
	@Name,
    @Email,
    @Password,
    @PhoneNumber,
    @PostalCode
)

CREATE PROCEDURE UserDelete
@IdUser INT
AS
DELETE FROM Users
WHERE IdUser = @IdUser

CREATE PROCEDURE UserUpdate 
@IdUser INT,
@Name VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(50),
@PhoneNumber VARCHAR(10),
@PostalCode VARCHAR(5)
AS
UPDATE Users
SET Name = @Name,
	Email = @Email,
	Password = @Password,
	PhoneNumber = @PhoneNumber,
	PostalCode = @PostalCode
WHERE IdUser = @IdUser

CREATE PROCEDURE UserGetAll
AS
SELECT IdUser,
	   Name,
	   Email,
	   Password,
	   PhoneNumber,
	   PostalCode 
FROM Users

CREATE PROCEDURE UserById 
@IdUser INT
AS
SELECT IdUser,Name,Email,Password,PhoneNumber,PostalCode 
FROM Users
WHERE IdUser = @IdUser

---------------------------------------------------------

ALTER PROCEDURE UserAdd
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@MotherLastName VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(50),
@PhoneNumber VARCHAR(10),
@PostalCode VARCHAR(5),
@UserName VARCHAR(50),
@Birthday VARCHAR(20),
@Gender CHAR(2),
@MobileNumber VARCHAR(10),
@CURP VARCHAR(50),
@Image VARCHAR(MAX),
@IdRole TINYINT
AS
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
(
	@FirstName,
	@LastName,
	@MotherLastName,
    @Email,
    @Password,
    @PhoneNumber,
    @PostalCode,
	@UserName,
	CONVERT(date,@Birthday,103),
	@Gender,
	@MobileNumber,
	@CURP,
	@Image,
	@IdRole
)

DROP PROCEDURE UserById

ALTER PROCEDURE UserUpdate 
@IdUser INT,
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@MotherLastName VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(50),
@PhoneNumber VARCHAR(10),
@PostalCode VARCHAR(5),
@UserName VARCHAR(50),
@Birthday DATE,
@Gender CHAR(2),
@MobileNumber VARCHAR(10),
@CURP VARCHAR(50),
@Image VARCHAR(MAX),
@IdRole TINYINT
AS
UPDATE Users
SET FirstName = @FirstName,
	LastName = @LastName,
	MotherLastName = @MotherLastName,
	Password = @Password,
	PhoneNumber = @PhoneNumber,
	PostalCode = @PostalCode,
	UserName = @UserName,
	Birthday = CONVERT(DATE,@Birthday,103),
	Gender = @Gender,
	MobileNumber = @MobileNumber,
	CURP = @CURP,
	Image = @Image,
	IdRole = @IdRole
WHERE IdUser = @IdUser

EXEC UserUpdate 8 ,'10','2','3','4','5','6','1999-04-10','8','9','10','11','1'

ALTER PROCEDURE UserGetAll
AS
SELECT Users.IdUser,
	   Users.FirstName,
	   Users.LastName,
	   Users.MotherLastName,
	   Users.Email,
	   Users.Password,
	   Users.PhoneNumber,
	   Users.PostalCode,
	   Users.UserName,
	   CONVERT(varchar,Users.Birthday,106)as Birthday,
	   Users.Gender,
	   Users.MobileNumber,
	   Users.CURP,
	   Users.Image,
	   Role.IdRole,
	   Role.Name AS RoleName
FROM Users
INNER JOIN Role ON Users.IdRole = Role.IdRole

declare @Existingdate datetime
Set @Existingdate=GETDATE()
Select CONVERT(varchar,@Existingdate,106) 


ALTER PROCEDURE UserById 
@IdUser INT
AS
SELECT Users.IdUser,
	   Users.FirstName,
	   Users.LastName,
	   Users.MotherLastName,
	   Users.Email,
	   Users.Password,
	   Users.PhoneNumber,
	   Users.PostalCode,
	   Users.UserName,
	   CONVERT(VARCHAR,Users.Birthday,103)as Birthday,
	   Users.Gender,
	   Users.MobileNumber,
	   Users.CURP,
	   Users.Image,
	   Role.IdRole,
	   Role.Name AS RoleName
FROM Users
INNER JOIN Role ON Users.IdRole = Role.IdRole
WHERE IdUser = @IdUser