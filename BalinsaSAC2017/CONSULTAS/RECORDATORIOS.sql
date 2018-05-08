/*--ALERTAS DIARIAS, SEMANALES, MENSUALES
SELECT NOT_Fecha, NOT_Hora, NOT_Frecuencia FROM tb_notas_x_usuario
WHERE USU_Codigo='150002' AND NOT_Frecuencia <> 0 AND
NOT_Estado='1'

--ALERTAS DIAS SELECCIONADOS
SELECT * FROM tb_notas_x_usuario
WHERE USU_Codigo='150002' AND NOT_Frecuencia = 0 AND
NOT_Estado='1'*/

SELECT * 
FROM tb_notas_x_usuario 
WHERE USU_Codigo='150002' AND 
NOT_Frecuencia <> 0 AND 
NOT_Hora BETWEEN '12:52' AND '12:57' AND 
NOT_Estado='1'

select * from tb_notas_x_usuario
