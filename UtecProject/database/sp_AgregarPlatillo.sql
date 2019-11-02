create procedure sp_AgregarPlatillo(@user varchar(50),@nombre nvarchar(200), @precio float, @descripcion nvarchar(200), @tipo int, @restaurante int, @image varchar(200) = null)
as
begin
	declare @img varchar(200) = null
	if @image is not null
		exec @img = sp_AgregarImagen @image
	insert into PLATILLOS(NOMBRE, PRECIO, DESCRIPCION, ID_TIPO, ID_RESTAURANTES, ID_IMAGEN,FECHA) values(@nombre,@precio,@descripcion,@tipo,@restaurante, @img,GETDATE())
	exec sp_AgregarLog @user, @@IDENTITY, 'PLATILLOS','C'
end