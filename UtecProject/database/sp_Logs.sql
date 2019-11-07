create procedure [sp_Logs](@start_row int, @end_row int)
as
begin
;WITH OFFSET AS
(
     SELECT
         v.*,
          ROW_NUMBER() OVER(ORDER BY id_action) AS row_number
     FROM
          LOGS v
)
SELECT
     *
FROM
     OFFSET
WHERE
     row_number BETWEEN @start_row AND @end_row	 
end