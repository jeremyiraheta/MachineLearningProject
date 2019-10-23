create procedure sp_AgregarPlatillo(@nombre nvarchar(200), @precio float, @descripcion nvarchar(200), @tipo int, @restaurante int, @image varchar(200))
as
begin
	declare @img varchar(200) = null
	if @image is not null
		exec @img = sp_AgregarImagen @image
	insert into PLATILLOS(NOMBRE, PRECIO, DESCRIPCION, ID_TIPO, ID_RESTAURANTES, ID_IMAGEN) values(@nombre,@precio,@descripcion,@tipo,@restaurante, @img)
end