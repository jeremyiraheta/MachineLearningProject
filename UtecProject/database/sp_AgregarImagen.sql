create procedure sp_AgregarImagen(@url varchar(200))
as
begin
	insert into IMAGENES(URL) values(@url)
	return @@IDENTITY
end