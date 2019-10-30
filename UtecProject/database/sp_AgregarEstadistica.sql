create procedure sp_AgregarEstadistica(@iduser varchar(50))
as
begin
	declare @cantidad int
	select @cantidad = cantidad from ESTADISTICA where ID_USUARIO = @iduser
	if(@cantidad is not null)
		update ESTADISTICA set CANTIDAD += 1 where ID_USUARIO = @iduser
	else
		insert into ESTADISTICA(ID_USUARIO,CANTIDAD) values(@iduser, 1)
end
