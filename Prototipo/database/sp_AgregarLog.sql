create procedure sp_AgregarLog(@iduser varchar(50), @query varchar(200))
as
begin
	insert into LOGS(ID_USUARIO, [DATE], QUERY) values (@iduser,GETDATE(),@query) 
end