
USE DBPRUEBAS
GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PELICULA')
create table PELICULA(
IdPelicula int primary key identity(1,1),
Nombre varchar(60),
Director varchar(60),
Categoria varchar(60),
FechaRegistro datetime default getdate(),
Estado bit not null default 1,
)

go

CREATE NONCLUSTERED INDEX IX_tblPelicula_Name
ON Pelicula(Nombre ASC)


select * from Pelicula