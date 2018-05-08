--'REPORTE DE COTIZACIONES--
----------------------------
SELECT Co.COT_Codigo, C.CLI_RazonSocial, U.USU_ApePaterno+' '+U.USU_ApeMaterno+', '+U.USU_Nombres AS Acesor,
Co.COT_Descripcion, Co.COT_Garantia, Co.COT_Fecha, CONCAT(Co.COT_Dias,' DIAS'), CONCAT(Co.COT_Valides,' DIAS'), Co.COT_IGV,
Co.COT_CONINST, Co.COT_CONIGV, Co.COT_VERPREC, Co.COT_Moneda, Co.COT_FormaPago, Co.COT_Observacion
FROM tb_cotizaciones Co, tb_clientes C, tb_usuarios U
WHERE Co.CLI_Codigo=C.CLI_Codigo AND Co.USU_Codigo=U.USU_Codigo AND
Co.COT_Codigo='1600000005'

SELECT Dc.COT_Codigo, P.PRD_Nombre, P.PRD_Imagen, P.PRD_Especificaciones, Dc.DCOT_Cant, Dc.DCOT_Precio,
(Dc.DCOT_Cant * Dc.DCOT_Precio) AS SubTot
FROM tb_detalle_cotizaciones Dc, tb_productos P
WHERE P.PRD_Codigo=Dc.PRD_Codigo AND
Dc.COT_Codigo='1600000005'