create procedure sp_AlterUsuario(@iduser varchar(50), @password varchar(50), @image int, @nombre nvarchar(200), @apellido nvarchar(200), @correo varchar(200), @admin bit, @birth date)
as
begin
	if(@image != -1)
		update USUARIOS set ID_IMAGEN = @image where ID_USUARIO = @iduser
	update USUARIOS set CONTRASENA = ENCRYPTBYPASSPHRASE('1NeeDh3LpM3',@password), NOMBRE =@nombre,APELLIDO = @apellido,CORREO_ELECTRONICO=@correo, FECHA_CUMPLE=@birth,[ADMIN]=@admin where ID_USUARIO = @iduser
	exec sp_AgregarLog @iduser, -1, 'USUARIOS', 'U'
end