create procedure sp_AlterPlatillo(@id int, @user varchar(50), @restaurant int, @tipo int, @nombre nvarchar(200),@precio float, @descripcion nvarchar(200), @image int=-1)
as
begin
	if(@image = -1)
		update PLATILLOS set ID_RESTAURANTES = @restaurant, ID_TIPO=@tipo, NOMBRE=@nombre,PRECIO=@precio,DESCRIPCION=@descripcion where ID_PLATILLOS = @id
	else
		update PLATILLOS set ID_RESTAURANTES = @restaurant, ID_IMAGEN = @image, ID_TIPO=@tipo, NOMBRE=@nombre,PRECIO=@precio,DESCRIPCION=@descripcion where ID_PLATILLOS = @id
	exec sp_AgregarLog @user, @id, 'PLATILLOS','U'
end