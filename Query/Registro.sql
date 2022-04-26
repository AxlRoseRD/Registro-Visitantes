CREATE DATABASE Registro

USE Registro

--TABLAS
CREATE TABLE Users(
US_ID int identity(1,1) primary key,
NAME_ NVARCHAR(40)NOT NULL,
LASTNAME NVARCHAR(60) NOT NULL,
BIRTHDATE DATE NOT NULL,
USERNAME NVARCHAR(20) NOT NULL,
PASWORD NVARCHAR(100)NOT NULL,
US_TYPE NVARCHAR(15) NOT NULL
)

CREATE TABLE Edificios
(
id_edificio INT IDENTITY(1,1) PRIMARY KEY,
nombre NVARCHAR(50) NOT NULL
)

CREATE TABLE Aulas(
id_aula INT IDENTITY(1,1) PRIMARY KEY,
id_edificio INT NOT NULL,
nombre NVARCHAR(50)
)

CREATE TABLE Visitas(
ID_visita INT IDENTITY(1,1) PRIMARY KEY,
nombre NVARCHAR(35) NOT NULL,
apellido NVARCHAR(40)NOT NULL,
carrera NVARCHAR(60),
correo NVARCHAR(125),
id_edificio INT NOT NULL,
H_entrada TIME,
H_salida TIME,
motivo_V NVARCHAR(100),
id_aula INT
)

--PRUEBAS
SELECT * FROM Visitas
SELECT * FROM Users
drop table Aulas
drop table Visitas
truncate table Aulas

 DELETE Users
 WHERE USERNAME = 'a'

--inserts de prueba
insert into Users values ('Axcell','Espinal','2001-07-02','Axl','123456789','administrador')


--LLAVES FORANEAS
--ALTER TABLE Visitas ADD FOREIGN KEY (id_edificio) REFERENCES Edificios(id_edificio)
--ALTER TABLE Visitas ADD FOREIGN KEY (id_aula) REFERENCES Aulas(id_aula)
--ALTER TABLE Aulas ADD FOREIGN KEY (id_edificio) REFERENCES Edificios(id_edificio)

/*
ALTER TABLE Visitas
DROP Constraint FK_Edificio
GO

ALTER TABLE Visitas
ADD CONSTRAINT [FK_Edificio]
FOREIGN KEY (id_edificio) REFERENCES Edificios(id_edificio)
ON DELETE CASCADE ON UPDATE CASCADE
GO 
*/