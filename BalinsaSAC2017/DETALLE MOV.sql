SELECT MC.MCAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  
(SELECT CAJ_Nombre FROM tb_cajas WHERE CAJ_Codigo = MC.CAJ_Codigo) AS Caja, 
(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo = MC.CON_Codigo) AS Consepto, 
(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Pagador) AS Pagador, 
(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Recibidor) AS Recibidor, 
(SELECT MC.MCAJ_MontoSoles - COALESCE(SUM(DGAS_Monto), 0) FROM tb_detalle_gastos 
WHERE MCAJ_Codigo=MC.MCAJ_Codigo AND MC.MCAJ_Activo <> '0') AS Devolver, 
MC.MCAJ_MontoSoles, MC.MCAJ_MontoDolares, MC.MCAJ_Detalle AS Detalle, MC.MCAJ_Activo AS Estado 
FROM tb_movimiento_cajas MC, tb_conceptos C, tb_cajas CA 
WHERE MC.CON_Codigo = C.CON_Codigo AND 
MC.CAJ_Codigo = CA.CAJ_Codigo AND 
MC.CAJ_Codigo='1005'AND 
CONVERT(VARCHAR(10), MC.MCAJ_FechaHora, 103)='20/11/2015'