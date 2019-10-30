create trigger tValoraciones
on VALORACIONES
after UPDATE, INSERT, DELETE
as
begin
	declare @id int
	declare @avg float
	if Exists(select * from inserted)
		select @id=ID_PLATILLOS from inserted
	if Exists(select * from deleted)
		select @id=ID_PLATILLOS from deleted
	select @avg=AVG(RATE) from VALORACIONES where ID_PLATILLOS = @id
	update PLATILLOS set RATE = @avg where ID_PLATILLOS = @id
end