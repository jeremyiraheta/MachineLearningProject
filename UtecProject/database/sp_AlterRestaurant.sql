create procedure sp_AlterRestaurant(@id int, @user varchar(50), @nombre nvarchar(200), @referencia nvarchar(200), @point int=-1,@image int=-1)
as
begin
	if(@image != -1)
		update RESTAURANTES set ID_IMAGEN=@image where ID_RESTAURANTES=@id
	if(@point != -1)
		update RESTAURANTES set ID_POINT=@point where ID_RESTAURANTES=@id
	update RESTAURANTES set NOMBRE=@nombre,REFERENCIA=@referencia where ID_RESTAURANTES=@id
	exec sp_AgregarLog @user, @id, 'RESTAURANTES','U'
end