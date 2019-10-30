create procedure sp_AgregarRestaurante(@user varchar(50), @nombre nvarchar(200),@referencia nvarchar(200),@image varchar(200) = null)
as
begin
	declare @img varchar(200) = null
	if @image is not null
		exec @img = sp_AgregarImagen @image
	insert into RESTAURANTES(nombre,referencia, id_imagen) values(@nombre,@referencia,@img)
	exec sp_AgregarLog @user, @@IDENTITY, 'RESTAURANTES','C'
end