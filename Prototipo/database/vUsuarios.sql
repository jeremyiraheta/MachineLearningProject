create view vUsuarios as
select u.*, i.URL, e.CANTIDAD as VISITAS from USUARIOS u 
left join IMAGENES i on i.ID_IMAGEN = u.ID_IMAGEN
left join ESTADISTICA e on e.ID_USUARIO = u.ID_USUARIO