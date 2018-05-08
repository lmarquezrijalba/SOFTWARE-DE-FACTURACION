SELECT MC.MCAJ_Codigo,'FECHA: '+CONVERT(VARCHAR(10), MC.MCAJ_FechaHora, 103)+' - '+
	   C.CON_Descripcion+' : '+cast(MC.MCAJ_MontoSoles AS varchar(30)) AS S
FROM tb_movimiento_cajas MC, tb_conceptos C
WHERE C.CON_codigo = MC.CON_Codigo AND
MC.MCAJ_Recibidor = '150001' AND 
MC.MCAJ_Activo = '1'