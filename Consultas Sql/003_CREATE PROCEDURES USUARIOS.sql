go
use DBPRUEBAS
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrar')
DROP PROCEDURE usp_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificar')
DROP PROCEDURE usp_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtener')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listar')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminar')
DROP PROCEDURE usp_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure usp_registrar(
@documentoidentidad varchar(60),
@nombres varchar(60),
@telefono varchar(60),
@correo varchar(60),
@ciudad varchar(60)
)
as
begin

insert into USUARIO(DocumentoIdentidad,Nombres,Telefono,Correo,Ciudad)
values
(
@documentoidentidad,
@nombres,
@telefono,
@correo,
@ciudad
)
end
go



create procedure usp_modificar(
@idusuario int,
@documentoidentidad varchar(60),
@nombres varchar(60),
@telefono varchar(60),
@correo varchar(60),
@ciudad varchar(60)
)
as
begin

update USUARIO set 
DocumentoIdentidad = @documentoidentidad,
Nombres = @nombres,
Telefono = @telefono,
Correo = @correo,
Ciudad = @ciudad
where IdUsuario = @idusuario

end
go



create procedure usp_obtener(@idusuario int)
as
begin

select * from usuario where IdUsuario = @idusuario and estado=1
end

go
create procedure usp_listar
as
begin
select * from usuario where estado=1
end
go



go
create procedure usp_eliminar(
@idusuario int
)
as
begin

delete from usuario where IdUsuario = @idusuario

end
go


go
create procedure usp_desactivar(
@idusuario int
)
as
begin
update USUARIO set Estado=0 where IdUsuario = @idusuario
end
go


go
create procedure usp_activar(
@idusuario int
)
as
begin
update USUARIO set Estado=1 where IdUsuario = @idusuario
end
go


create procedure usp_pagination(
@registros_por_pagina int,
@pagina int
)
as
begin
	select * from USUARIO where estado=1 order by IdUsuario ASC
	OFFSET (@pagina - 1) * @registros_por_pagina ROWS
	FETCH NEXT @registros_por_pagina ROWS ONLY
end
go