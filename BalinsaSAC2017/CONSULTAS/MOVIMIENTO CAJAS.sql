SELECT MC.MCAJ_Codigo, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  
(SELECT CAJ_Nombre FROM tb_cajas WHERE CAJ_Codigo = MC.CAJ_Codigo) AS Caja,
(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo = MC.CON_Codigo) AS Consepto, 
(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Pagador) AS Pagador, 
(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Recibidor) AS Recibidor, 
MCAJ_Monto, MCAJ_Observacion AS Detalle 
FROM tb_movimiento_cajas MC, tb_conceptos C, tb_cajas CA
WHERE MC.CON_Codigo = C.CON_Codigo AND 
MC.CAJ_Codigo = CA.CAJ_Codigo
 
 select datepart(MONTH,getdate());