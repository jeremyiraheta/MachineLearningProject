create procedure sp_AgregarComentario(@iduser varchar(50), @idplatillo int, @comentario nvarchar(200))
as
begin
	insert into COMENTARIOS(ID_USUARIO, ID_PLATILLOS, COMENTARIOS,FECHA) values(@iduser, @idplatillo,@comentario,GETDATE())
	exec sp_AgregarLog @iduser, @@IDENTITY, 'COMENTARIOS','C'
end