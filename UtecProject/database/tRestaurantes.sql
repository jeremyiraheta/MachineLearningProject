create trigger tRestaurantes
on PLATILLOS
after UPDATE, INSERT, DELETE
as
begin
	declare @id int
	declare @avg float
	if Exists(select * from inserted)
		select @id=ID_RESTAURANTES from inserted
	if Exists(select * from deleted)
		select @id=ID_RESTAURANTES from deleted
	select @avg=AVG(RATE) from PLATILLOS where ID_RESTAURANTES = @id
	update RESTAURANTES set RATE = @avg where ID_RESTAURANTES = @id
end