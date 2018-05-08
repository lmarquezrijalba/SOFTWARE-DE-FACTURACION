CREATE TRIGGER aperturar_Caja ON tb_detalle_cajas 
FOR INSERT AS
	BEGIN
		DECLARE @IDCaja AS CHAR(4)

		SET @IDCaja = (SELECT CAJ_Codigo FROM INSERTED)
 
		UPDATE tb_cajas
		SET CAJ_Aperturado = '1'	
		WHERE CAJ_Codigo = @IDCaja
	END

drop trigger aperturar_Caja


---------------------------------------------------------------------
/*CREATE TRIGGER ACTUALIZA_MONTO ON tb_cajas
FOR UPDATE AS
	BEGIN
		DECLARE @IDCaja AS CHAR(4),
				@MONTO_SOL AS DECIMAL(18,2),
				@MONTO_DOL AS DECIMAL(18,2)

		SELECT @IDCaja = CAJ_Codigo FROM UPDATE

	END
*/
---------------------------------------------------------------------
drop trigger registraEgreso

CREATE TRIGGER registraEgreso ON tb_movimiento_cajas 
FOR INSERT AS
	BEGIN
		DECLARE @IDCaja AS CHAR(4),
				@TIPOMOV CHAR(1),
				@MONTOACT_SOL AS DECIMAL(18,2),
				@MONTOACT_DOL AS DECIMAL(18,2),
				@IMPORTE_SOL AS DECIMAL(18,2),
				@IMPORTE_DOL AS DECIMAL(18,2),
				@TOTAL_SOL AS DECIMAL(18,2),
				@TOTAL_DOL AS DECIMAL(18,2)
 
		SELECT @IDCaja = CAJ_Codigo FROM INSERTED
		SELECT @TIPOMOV = MCAJ_Tipo FROM INSERTED
		SELECT @IMPORTE_SOL = MCAJ_MontoSoles FROM INSERTED
		SELECT @IMPORTE_DOL = MCAJ_MontoDolares FROM INSERTED
		
		SELECT @MONTOACT_SOL = (SELECT DCAJ_MontoActual_Soles FROM tb_detalle_cajas 
								WHERE CAJ_Codigo = @IDCaja AND DCAJ_Estado='1')
		SELECT @MONTOACT_DOL = (SELECT DCAJ_MontoActual_Dolares FROM tb_detalle_cajas 
								WHERE CAJ_Codigo = @IDCaja AND DCAJ_Estado='1')

		IF @TIPOMOV = 'E'
			BEGIN
				SELECT @TOTAL_SOL = (@MONTOACT_SOL - @IMPORTE_SOL)
				SELECT @TOTAL_DOL = (@MONTOACT_DOL - @IMPORTE_DOL)
			END
		
		UPDATE tb_detalle_cajas
		SET DCAJ_MontoActual_Soles = @TOTAL_SOL,
			DCAJ_MontoActual_Dolares = @TOTAL_DOL
		WHERE CAJ_Codigo = @IDCaja AND DCAJ_Estado = '1'
	END

---------------------------------------------------------------------------------------------------
DROP TRIGGER gastosPendientes
/*
CREATE TRIGGER gastosPendientes ON tb_detalle_gastos
FOR INSERT AS
	BEGIN
		DECLARE @IDMovCaja AS int

		SELECT @IDMovCaja = MCAJ_Codigo FROM INSERTED

		UPDATE tb_movimiento_cajas
		SET MCAJ_Activo = '2'
		WHERE MCAJ_Codigo = @IDMovCaja
	END
*/
----------------------------------------------------------------------------------------------------