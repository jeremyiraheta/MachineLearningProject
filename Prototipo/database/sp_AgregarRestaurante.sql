create procedure sp_AgregarRestaurante(@nombre nvarchar(200),@referencia nvarchar(200),@image varchar(200) = null)
as
begin
	declare @img varchar(200) = null
	if @image is not null
		exec @img = sp_AgregarImagen @image
	insert into RESTAURANTES(nombre,referencia, id_imagen) values(@nombre,@referencia,@img)
end