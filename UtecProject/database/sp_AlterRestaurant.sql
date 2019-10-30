create procedure sp_AlterRestaurant(@id int, @user varchar(50), @image int, @point int, @nombre nvarchar(200), @referencia nvarchar(200))
as
begin
	update RESTAURANTES set ID_IMAGEN=@image, ID_POINT=@point,NOMBRE=@nombre,REFERENCIA=@referencia where ID_RESTAURANTES=@id
	exec sp_AgregarLog @user, @id, 'RESTAURANTES','U'
end
