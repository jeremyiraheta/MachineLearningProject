create view vPlatillos as
select p.*, t.TIPO, r.NOMBRE as RESTAURANTE, i.URL from PLATILLOS p
inner join TIPOPLATILLO t on  t.ID_TIPO = p.ID_TIPO
inner join RESTAURANTES r on r.ID_RESTAURANTES = p.ID_RESTAURANTES
inner join IMAGENES i on i.ID_IMAGEN = p.ID_IMAGEN