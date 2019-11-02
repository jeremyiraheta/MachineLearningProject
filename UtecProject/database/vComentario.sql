create view vComentarios as
select c.*, i.URL, p.NOMBRE as PLATILLO from COMENTARIOS c 
left join USUARIOS u on u.ID_USUARIO = c.ID_USUARIO
left join PLATILLOS p on p.ID_PLATILLOS = c.ID_PLATILLOS
left join IMAGENES i on i.ID_IMAGEN = u.ID_IMAGEN