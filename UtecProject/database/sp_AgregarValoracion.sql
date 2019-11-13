create procedure sp_AgregarValoracion(@iduser varchar(50), @idplatillo int, @rate float)
as
begin
	declare @value float
	select @value = RATE from VALORACIONES where ID_USUARIO=@iduser and ID_PLATILLOS = @idplatillo
	if(@value is null)
		insert into VALORACIONES values(@idplatillo,@iduser,@rate)
	else
		update VALORACIONES set RATE = @rate where ID_USUARIO=@iduser and ID_PLATILLOS = @idplatillo
end