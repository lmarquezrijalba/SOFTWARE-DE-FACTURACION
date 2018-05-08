CREATE TRIGGER aperturar_Caja
ON tb_detalle_cajas FOR INSERT AS
	BEGIN
		DECLARE @IDCaja AS CHAR(4)

		SET @IDCaja = (SELECT CAJ_Codigo FROM INSERTED)
 
		UPDATE tb_cajas
		SET CAJ_Aperturado = '1'	
		WHERE CAJ_Codigo = @IDCaja
	END