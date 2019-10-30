create view vRestaurantes as
select r.*, i.URL, p.X,p.Y from RESTAURANTES r 
left join IMAGENES i on i.ID_IMAGEN = r.ID_IMAGEN
left join POINT p on p.ID_POINT = r.ID_POINT