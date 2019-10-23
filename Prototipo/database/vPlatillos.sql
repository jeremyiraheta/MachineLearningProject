create view vPlatillos as
select p.*, t.TIPO, r.NOMBRE as RESTAURANTE, i.URL from PLATILLOS p
left join TIPOPLATILLO t on  t.ID_TIPO = p.ID_TIPO
left join RESTAURANTES r on r.ID_RESTAURANTES = p.ID_RESTAURANTES
left join IMAGENES i on i.ID_IMAGEN = p.ID_IMAGEN