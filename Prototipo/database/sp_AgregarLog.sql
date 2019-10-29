create procedure [sp_AgregarLog](@iduser varchar(50), @object int,@table varchar(10), @class varchar(3))
as
begin
	insert into LOGS(ID_USUARIO, ID_OBJECT, CREACION, TABLA,TIPO) values (@iduser,@object,GETDATE(), @table,@class) 
end