create procedure sp_RecomendacionPersonalizada(@user varchar(50))
as
begin
	;with P as(
		select v1.id_usuario usuarioa, v2.id_usuario usuariob,count(v1.rate) coincidencias from valoraciones v1 inner join valoraciones v2 on v1.id_platillos = v2.id_platillos and v1.id_usuario != v2.id_usuario and v1.rate = v2.rate group by v1.id_usuario,v2.id_usuario
	)select * from P where usuarioa=@user order by coincidencias desc
end
