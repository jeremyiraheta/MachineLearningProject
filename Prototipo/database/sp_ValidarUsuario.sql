create procedure sp_ValidarUsuario(@iduser varchar(50), @pass varchar(50))
as
begin	
	if Exists (select * from USUARIOS where ID_USUARIO = @iduser and cast(DECRYPTBYPASSPHRASE('1NeeDh3LpM3',CONTRASENA) as varchar) = @pass)
		select * from vUsuarios where id_USUARIO = @iduser
	else
		select -1

end
