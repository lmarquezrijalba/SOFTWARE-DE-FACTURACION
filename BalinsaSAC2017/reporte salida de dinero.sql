/*SELECT CA.CAJ_Nombre, CO.CON_Descripcion, SUM(MC.MCAJ_MontoSoles) AS Soles, SUM(MC.MCAJ_MontoDolares) AS Dolares
FROM tb_conceptos CO, tb_movimiento_cajas MC, tb_cajas CA
WHERE CA.CAJ_Codigo=MC.CAJ_Codigo AND
CO.CON_Codigo=MC.CON_Codigo AND
CO.CON_Tipo = 'E' AND 
CO.CON_Codigo <> 'T001' AND 
MC.CAJ_Codigo='1005'
GROUP BY CA.CAJ_Codigo, CA.CAJ_Nombre, CO.CON_Descripcion*/


--select * from tb_cajas

SELECT C.CAJ_Codigo, C.CAJ_Nombre, DC.DCAJ_AperturoCon_Dolares, DC.DCAJ_AperturoCon_Soles,
DC.DCAJ_MontoActual_Dolares, DC.DCAJ_MontoActual_Soles,
U.USU_ApePaterno+' '+U.USU_ApeMaterno+', '+U.USU_Nombres AS Encargado, DC.DCAJ_Estado
FROM tb_detalle_cajas DC, tb_cajas C, tb_usuarios U
WHERE C.CAJ_Codigo = DC.CAJ_Codigo AND
DC.USU_Codigo = U.USU_Codigo AND
C.CAJ_Codigo = '1005'
