create procedure sp_Delete(@tipo varchar(1), @id int, @user varchar(50))
as
begin
	if(@tipo = 'R')
	begin
		delete from COMENTARIOS where ID_PLATILLOS in (select ID_PLATILLOS from PLATILLOS where ID_RESTAURANTES=@id)
		delete from PLATILLOS where ID_RESTAURANTES = @id
		delete from RESTAURANTES where ID_RESTAURANTES = @id		
		exec sp_AgregarLog @user,@id, 'RESTAURANTES','D'
	end
	if(@tipo = 'P')
	begin
		delete from COMENTARIOS where ID_PLATILLOS = @id
		delete from PLATILLOS where ID_PLATILLOS = @id		
		exec sp_AgregarLog @user,@id, 'PLATILLOS','D'
	end
	if(@tipo = 'C')
	begin
		delete from COMENTARIOS where ID_COMENTARIOS = @id
		exec sp_AgregarLog @user,@id, 'COMENTARIOS','D'
	end
end