create procedure sp_AgregarClick(@idplatillo int, @iduser varchar(50))
as
begin
	if Exists(select * from ACCIONCLICK where ID_PLATILLOS=@idplatillo and ID_USUARIO=@iduser)
		update ACCIONCLICK set CANTIDAD = CANTIDAD + 1 where ID_PLATILLOS=@idplatillo and ID_USUARIO=@iduser
	else
		insert into ACCIONCLICK(ID_PLATILLOS,ID_USUARIO,CANTIDAD) values(@idplatillo,@iduser,1)
end