create procedure sp_AlterLocation(@id int, @x int, @y int)
as
begin
	declare @point int
	select @point=ID_POINT from vRestaurantes where id_restaurantes=@id			
	if(@point is null)
	begin
		insert into point(X,Y) values(@x,@y)		
		update restaurantes set id_point=@@IDENTITY where id_restaurantes=@id
	end
	else
		update point set x=@x,y=@y where id_point=@point		
end