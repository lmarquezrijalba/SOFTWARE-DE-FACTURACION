/*SELECT COUNT(CAJ_Codigo) FROM tb_cajas

SELECT * FROM TB_CAJAS

SELECT C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Nombres, DC.DCAJ_FechaApertura, 
DC.DCAJ_AperturoCon, C.CAJ_Aperturado
FROM tb_cajas C, tb_detalle_cajas DC, tb_usuarios U
WHERE C.CAJ_Codigo = DC.CAJ_Codigo AND
DC.USU_Codigo = U.USU_Codigo
*/
SELECT * FROM TB_DETALLE_CAJAS

SELECT DC.CAJ_Codigo,  U.USU_Nombres, DC.DCAJ_FechaApertura, 
DC.DCAJ_AperturoCon
FROM tb_detalle_cajas DC, tb_usuarios U
WHERE DC.USU_Codigo = U.USU_Codigo AND
DC.CAJ_Codigo = 'C001'