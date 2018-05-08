select * from tb_detalle_cajas
select * from tb_movimiento_cajas

INSERT INTO tb_movimiento_cajas(MCAJ_NroOperacion, CAJ_Codigo, CON_Codigo, MCAJ_Pagador, MCAJ_Recibidor,
MCAJ_Tipo, MCAJ_FechaHora, MCAJ_MontoSoles, MCAJ_MontoDolares, MCAJ_Proveniente, MCAJ_Detalle, MCAJ_Activo) 
VALUES('0003', '1', 'A007', '150005', '150005', 'I', '2015-03-12 12:44:20', '0', '0', 'APERTURA DE CAJA', 
'SE APERTURÓ CAJA BALINSA CON S/ 0,00 Y $ 0,00', 0),
('0002', '2', 'A007', '150005', '150005', 'I', '2015-03-12 12:41:02', '8.301,40', '0', 'APERTURA DE CAJA', 
'SE APERTURÓ SERVICIO SEIN S.A.C CON S/ 8.301,40 Y $ 0,00', 0),
('0004', '3', 'A007', '150005', '150005', 'I', '2015-03-12 15:00:05', '765.58', '0', 'APERTURA DE CAJA', 
'SE APERTURÓ PAGO RAPEL CON S/ 765.58,00 Y $ 0,00', 0)