/*
--TOTAL INGRESOS POR CAJA
---------------------------
SELECT C.CAJ_Codigo, C.CAJ_Nombre, 
SUM(MCAJ_MontoSoles) AS TOTAL_CAJA_SOL, SUM(MCAJ_MontoDolares) AS TATAL_CAJA_USD
FROM tb_cajas C, tb_movimiento_cajas MC
WHERE C.CAJ_Codigo = MC.CAJ_Codigo AND MCAJ_Tipo='I'
GROUP BY C.CAJ_Codigo, C.CAJ_Nombre
*/

--MOVIMIENTOS POR CAJA
---------------------------
/*
SELECT C.CAJ_Nombre, CO.CON_Descripcion, MC.MCAJ_Tipo, 
MC.MCAJ_MontoSoles AS [SALIDASOL], MC.MCAJ_MontoDolares AS [SALIDADOL], 
MC.MCAJ_Detalle
FROM tb_cajas C, tb_movimiento_cajas MC, tb_conceptos CO
WHERE C.CAJ_Codigo=MC.CAJ_Codigo AND
MC.CON_Codigo=CO.CON_Codigo AND
C.CAJ_Codigo='6'
*/

--GASTOS POR CONCEPTOS Y CAJAS
---------------------------------------
/*
SELECT CA.CAJ_Nombre, CO.CON_Descripcion, SUM(DGAS_MontoSoles) AS SOL, SUM(DGAS_MontoDolares) AS USD
FROM tb_detalle_gastos DG, tb_movimiento_cajas MC, tb_cajas CA, tb_conceptos CO
WHERE MC.MCAJ_Codigo = DG.MCAJ_Codigo AND 
CA.CAJ_Codigo = MC.CAJ_Codigo AND
MC.CON_Codigo = CO.CON_Codigo AND
CO.CON_Tipo = 'E' AND
MC.CAJ_Codigo = '6'
GROUP BY CA.CAJ_Nombre, CO.CON_Descripcion
*/


/*
SELECT C.CAJ_Codigo, C.CAJ_Nombre, SUM(MC.MCAJ_MontoSoles) AS SOL, SUM(MC.MCAJ_MontoDolares) AS USD,
(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CON_Codigo='A007' AND CAJ_Codigo='4') AS FECHAAPERTURA,
ISNULL((SELECT TOP 4 ISNULL(MCAJ_MontoSoles, 0.00) FROM tb_movimiento_cajas WHERE CAJ_Codigo='4' AND MCAJ_Tipo='I'
ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULTING_SOL,
ISNULL((SELECT TOP 4 ISNULL(MCAJ_MontoDolares, 0.00) FROM tb_movimiento_cajas WHERE CAJ_Codigo='4' AND MCAJ_Tipo='I'
ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULTING_DOL,
ISNULL((SELECT SUM(DGAS_MontoSoles) FROM tb_detalle_gastos DG, tb_movimiento_cajas MC
WHERE MC.MCAJ_Codigo = DG.MCAJ_Codigo AND MC.CAJ_Codigo = '4' GROUP BY MC.CAJ_Codigo), 0.00) AS GASTOSOL,
ISNULL((SELECT SUM(DGAS_MontoDolares) FROM tb_detalle_gastos DG, tb_movimiento_cajas MC
WHERE MC.MCAJ_Codigo = DG.MCAJ_Codigo AND MC.CAJ_Codigo = '4' GROUP BY MC.CAJ_Codigo), 0.00) AS GASTODOL
FROM tb_cajas C, tb_movimiento_cajas MC
WHERE C.CAJ_Codigo = MC.CAJ_Codigo AND 
MCAJ_Tipo='I' AND C.CAJ_Codigo='4'
GROUP BY C.CAJ_Codigo, C.CAJ_Nombre
*/

--DETALLES DE CAJA
-------------------
SELECT C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres,
(SELECT SUM(MCAJ_MontoSoles) FROM tb_movimiento_cajas WHERE CAJ_Codigo='6' AND MCAJ_Tipo='I' AND MCAJ_Activo='0'),
SUM(MC.MCAJ_MontoSoles) AS TOTAL_ING_SOL, SUM(MC.MCAJ_MontoDolares) AS TOTAL_ING_USD,
ISNULL((SELECT SUM(MCAJ_MontoSoles)FROM tb_movimiento_cajas WHERE CAJ_Codigo='6' AND MCAJ_Tipo='E'), 0.00)AS DESEMBOL_SOL,
ISNULL((SELECT SUM(MCAJ_MontoDolares) FROM tb_movimiento_cajas WHERE CAJ_Codigo='6' AND MCAJ_Tipo='E'), 0.00) AS DESEMBOL_USD,
(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CON_Codigo='A007' AND CAJ_Codigo='6') AS FECHAAPERTURA,
ISNULL((SELECT TOP 1 MCAJ_MontoSoles FROM tb_movimiento_cajas WHERE CAJ_Codigo='6' AND MCAJ_Tipo='I'
ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_SOL,
ISNULL((SELECT TOP 1 MCAJ_MontoDolares FROM tb_movimiento_cajas WHERE CAJ_Codigo='6' AND MCAJ_Tipo='I'
ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_USD,
ISNULL((SELECT SUM(DGAS_MontoSoles) FROM tb_detalle_gastos DG, tb_movimiento_cajas MC
WHERE MC.MCAJ_Codigo = DG.MCAJ_Codigo AND MC.CAJ_Codigo = '6' GROUP BY MC.CAJ_Codigo), 0.00) AS GASTO_SOL,
ISNULL((SELECT SUM(DGAS_MontoDolares) FROM tb_detalle_gastos DG, tb_movimiento_cajas MC
WHERE MC.MCAJ_Codigo = DG.MCAJ_Codigo AND MC.CAJ_Codigo = '6' GROUP BY MC.CAJ_Codigo), 0.00) AS GASTO_USD
FROM tb_cajas C, tb_movimiento_cajas MC, tb_usuarios U
WHERE C.CAJ_Codigo = MC.CAJ_Codigo AND 
C.USU_Codigo = U.USU_Codigo AND
MCAJ_Tipo='I' AND C.CAJ_Codigo='6'
GROUP BY C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres

/*
--DETALLE DE GASTOS POR CONCEPTO Y CAJA
----------------------------------------
SELECT CA.CAJ_Nombre, CO.CON_Descripcion, SUM(DGAS_MontoSoles) AS SOL, SUM(DGAS_MontoDolares) AS USD
FROM tb_detalle_gastos DG, tb_movimiento_cajas MC, tb_cajas CA, tb_conceptos CO
WHERE MC.MCAJ_Codigo = DG.MCAJ_Codigo AND 
CA.CAJ_Codigo = MC.CAJ_Codigo AND
MC.CON_Codigo = CO.CON_Codigo AND
MC.CAJ_Codigo = '6'
GROUP BY CA.CAJ_Nombre, CO.CON_Descripcion

--INGRESOS POR CONCEPTO Y CAJA
-------------------------------
SELECT CA.CAJ_Nombre, CO.CON_Descripcion, SUM(MC.MCAJ_MontoSoles) AS SOL, SUM(MC.MCAJ_MontoDolares) AS USD
FROM tb_movimiento_cajas MC, tb_cajas CA, tb_conceptos CO
WHERE CA.CAJ_Codigo = MC.CAJ_Codigo AND
MC.CON_Codigo = CO.CON_Codigo AND
MC.CAJ_Codigo = '6' AND MCAJ_Tipo='I'
GROUP BY CA.CAJ_Nombre, CO.CON_Descripcion
*/

--RESUMEN DE GASTOS
----------------------
SELECT 
MC.MCAJ_MontoSoles AS DESEMBOLSOS_SOL,
ISNULL((SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_SOL,
ISNULL((MC.MCAJ_MontoSoles - (SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG 
WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo AND MC.MCAJ_Activo='0')), 0.00) AS RETORNO_SOL,
 MC.MCAJ_MontoDolares AS DESEMBOLSOS_USD,
ISNULL((SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG 
WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_USD,
ISNULL((MC.MCAJ_MontoDolares - (SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG 
WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo AND MC.MCAJ_Activo='0')), 0.00) AS RETORNO_USD,
MC.MCAJ_Activo AS ESTADO
FROM tb_movimiento_cajas MC
WHERE MC.CAJ_Codigo='6' AND MC.CON_Codigo<>'A007' AND MCAJ_Tipo='E'

--DETALLE DE CAJA APERTURADA
-----------------------------
SELECT U.USU_Codigo, U.USU_Nombres, C.CAJ_Codigo, C.CAJ_Nombre, C.CAJ_Principal, C.CAJ_Aperturado,
(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CAJ_Codigo=C.CAJ_Codigo AND CON_Codigo='A007') AS FECHA_APERT,
(SELECT MCAJ_MontoSoles FROM tb_movimiento_cajas WHERE CAJ_Codigo=C.CAJ_Codigo AND CON_Codigo='A007') AS APERTURO_SOL,
(SELECT MCAJ_MontoDolares FROM tb_movimiento_cajas WHERE CAJ_Codigo=C.CAJ_Codigo AND CON_Codigo='A007') AS APERTURO_USD
FROM tb_cajas C, tb_usuarios U
WHERE U.USU_Codigo=C.USU_Codigo AND
C.CAJ_Codigo='6'