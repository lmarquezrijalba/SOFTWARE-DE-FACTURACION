select * from tb_permisos
select * from tb_permisos_x_nivel

SELECT P.PER_Codigo, P.PER_Descripcion,
(SELECT PN.PER_Codigo FROM tb_permisos_x_nivel PN WHERE PN.PER_Codigo=P.PER_Codigo) AS Selec
FROM tb_permisos P
WHERE PER_Activo='1'
ORDER BY PER_Descripcion ASC

