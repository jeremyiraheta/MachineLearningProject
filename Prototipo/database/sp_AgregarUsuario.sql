create procedure sp_AgregarUsuario
(@id varchar(50), @nombre nvarchar(200), @apellido nvarchar(200),@correo varchar(200),@borndate date,@pass varchar(200), @image varchar(200) = null)
as
begin
	declare @img varchar(200) = null
	if @image is not null
		exec @img = sp_AgregarImagen @image
	insert into USUARIOS(ID_USUARIO, nombre, apellido, CORREO_ELECTRONICO, FECHA_CUMPLE, CONTRASENA, [ADMIN], ID_IMAGEN) values(
		@id, @nombre,@apellido,@correo, @borndate,EncryptByPassPhrase('1NeeDh3LpM3', @pass), 0, @img
	)
end