create procedure sp_AlterPlatillo(@id int, @user varchar(50), @restaurant int, @image int, @tipo int, @nombre nvarchar(200),@precio float, @descripcion nvarchar(200))
as
begin
	update PLATILLOS set ID_RESTAURANTES = @restaurant, ID_IMAGEN = @image, ID_TIPO=@tipo, NOMBRE=@nombre,PRECIO=@precio,DESCRIPCION=@descripcion where ID_PLATILLOS = @id
	exec sp_AgregarLog @user, @id, 'PLATILLOS','U'
end