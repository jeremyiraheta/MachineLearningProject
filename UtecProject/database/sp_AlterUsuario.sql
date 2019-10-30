create procedure sp_AlterUsuario(@iduser varchar(50), @password varchar(50), @image int, @nombre nvarchar(200), @apellido nvarchar(200), @correo varchar(200), @admin bit)
as
begin
	update USUARIOS set CONTRASENA = ENCRYPTBYPASSPHRASE('1NeeDh3LpM3',@password), ID_IMAGEN = @image, NOMBRE =@nombre,APELLIDO = @apellido,CORREO_ELECTRONICO=@correo,[ADMIN]=@admin where ID_USUARIO = @iduser
	exec sp_AgregarLog @iduser, -1, 'USUARIOS', 'U'
end