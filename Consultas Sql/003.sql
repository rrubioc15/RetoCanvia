go
use DBPRUEBAS
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'psp_registrar')
DROP PROCEDURE psp_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'psp_modificar')
DROP PROCEDURE psp_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'psp_obtener')
DROP PROCEDURE psp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'psp_listar')
DROP PROCEDURE psp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'psp_eliminar')
DROP PROCEDURE psp_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure psp_registrar(
@nombre varchar(60),
@director varchar(60),
@categoria varchar(60)
)
as
begin

insert into PELICULA(Nombre,Director,Categoria)
values
(
@nombre,
@director,
@categoria
)
end
go



create procedure psp_modificar(
@idpelicula int,
@nombre varchar(60),
@director varchar(60),
@categoria varchar(60)
)
as
begin

update PELICULA set 
Nombre = @nombre,
Director = @director,
Categoria = @categoria
where idpelicula = @idpelicula

end
go



create procedure psp_obtener(@idpelicula int)
as
begin

select * from PELICULA where idpelicula = @idpelicula and estado=1
end

go
create procedure psp_listar
as
begin
select * from PELICULA where estado=1
end
go



go
create procedure psp_eliminar(
@idpelicula int
)
as
begin

delete from PELICULA where idpelicula = @idpelicula

end
go


go
create procedure psp_desactivar(
@idpelicula int
)
as
begin
update PELICULA set Estado=0 where idpelicula = @idpelicula
end
go


go
create procedure psp_activar(
@idpelicula int
)
as
begin
update PELICULA set Estado=1 where idpelicula = @idpelicula
end
go


create procedure psp_pagination(
@registros_por_pagina int,
@pagina int
)
as
begin
	select * from PELICULA where estado=1 order by idpelicula ASC
	OFFSET (@pagina - 1) * @registros_por_pagina ROWS
	FETCH NEXT @registros_por_pagina ROWS ONLY
end
go