create procedure sp_UltimosPlatillos(@start_row int, @end_row int)
as
begin
;WITH OFFSET AS
(
     SELECT
         v.*,
          ROW_NUMBER() OVER(ORDER BY id_platillos) AS row_number
     FROM
          vPlatillos v
)
SELECT
     *
FROM
     OFFSET
WHERE
     row_number BETWEEN @start_row AND @end_row	 
end