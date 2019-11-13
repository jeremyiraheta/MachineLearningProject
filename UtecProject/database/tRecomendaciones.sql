create trigger tRecomendaciones
on VALORACIONES
after UPDATE
as
begin
	declare @iduser varchar(50)
	declare @idplatillo int	
	declare @valoracion float
	select @iduser=ID_USUARIO,@idplatillo=ID_PLATILLOS,@valoracion=RATE from inserted
	declare @id varchar(50)
	declare @rate float
	declare each_row cursor 
	for select ID_USUARIO, RATE from VALORACIONES where ID_PLATILLOS=@idplatillo and floor(RATE)= FLOOR(@valoracion)
	open each_row
	fetch next from each_row into @id,@rate
	WHILE @@FETCH_STATUS = 0
		BEGIN			
			if Exists(select * from RECOMENDACIONES where (ID_USUARIOA = @iduser and ID_USUARIOB =@id))
				update RECOMENDACIONES set COINCIDENCIAS += 1 where (ID_USUARIOA = @iduser and ID_USUARIOB =@id)
			else if Exists(select * from RECOMENDACIONES where (ID_USUARIOA = @id and ID_USUARIOB =@iduser))
				update RECOMENDACIONES set COINCIDENCIAS += 1 where (ID_USUARIOA = @id and ID_USUARIOB =@iduser)
			else
				begin
          if @iduser != @id
            insert into RECOMENDACIONES values(@iduser,@id,1)
        end
			fetch next from each_row into @id,@rate        
		END;
 
	CLOSE each_row;
 
	DEALLOCATE each_row;
end
