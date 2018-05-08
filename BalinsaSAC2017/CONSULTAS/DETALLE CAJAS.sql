SELECT * FROM tb_detalle_cajas DC
WHERE DC.CAJ_Codigo='C001'


select * from tb_cajas


SELECT DC.DCAJ_FechaApertura, DC.DCAJ_AperturoCon
FROM tb_cajas C, tb_detalle_cajas DC
WHERE C.CAJ_Codigo=DC.CAJ_Codigo AND
C.CAJ_Codigo = 'C001'-- AND DC.DCAJ_Estado='1'

SELECT U.USU_Codigo, U.USU_Nombres, DC.DCAJ_FechaApertura, DC.DCAJ_AperturoCon, C.CAJ_Aperturado, C.CAJ_Nombre 
FROM tb_cajas C, tb_detalle_cajas DC, tb_usuarios U 
WHERE C.CAJ_Codigo=DC.CAJ_Codigo AND 
DC.USU_Codigo=U.USU_Codigo AND 
C.CAJ_Codigo='C001'