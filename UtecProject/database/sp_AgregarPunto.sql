create procedure sp_AgregarPunto(@x int, @y int, @restaurante int)
as
begin
	declare @id int
	select @id=id_point from RESTAURANTES where ID_RESTAURANTES = @restaurante
	if(@id is not null)
		update POINT set X = @x, Y = @y where ID_POINT = @id
	else
		begin
			insert into POINT(X,Y) values(@x,@y)
			update RESTAURANTES set ID_POINT = @@IDENTITY where ID_RESTAURANTES = @restaurante
		end
end