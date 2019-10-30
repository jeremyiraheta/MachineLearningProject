create procedure sp_AlterComentario(@id int, @user varchar(50),@comentario nvarchar(200))
as
begin
	update COMENTARIOS set COMENTARIOS = @comentario where ID_COMENTARIOS=@id
	exec sp_AgregarLog @user, @id, 'COMENTARIOS','U'
end
