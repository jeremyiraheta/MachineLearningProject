create view vComentario as
select c.*, i.URL, p.NOMBRE as PLATILLO from COMENTARIOS c 
inner join USUARIOS u on u.ID_USUARIO = c.ID_USUARIO
inner join PLATILLOS p on p.ID_PLATILLOS = c.ID_PLATILLOS
inner join IMAGENES i on i.ID_IMAGEN = u.ID_IMAGEN