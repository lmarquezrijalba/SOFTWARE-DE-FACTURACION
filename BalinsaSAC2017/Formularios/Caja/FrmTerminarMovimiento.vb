Public Class FrmTerminarMovimiento
    Dim esSoles As Boolean
    Dim soles, dolares As Double

    Private Sub FrmTerminarMovimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdTerminar_Click(sender As Object, e As EventArgs) Handles cmdTerminar.Click
        Dim sqlRetorna_Monto_Caja As String = ""
        Dim sqlActualiza_Estado_Mov, sqlMovimientos As String
        Dim MontoDevolver As Double

        MontoDevolver = CDbl(lblDevolver.Text)

        sqlActualiza_Estado_Mov = "UPDATE tb_movimiento_cajas SET " & _
                                  "MCAJ_Activo='0' " & _
                                  "WHERE MCAJ_Codigo='" & lblIDMov.Text & "'"

        If MsgBox("Realmente desea terminar la operación?" & vbNewLine & vbNewLine & _
                   "De realizar la conformidad, la operación pasará a estado de TERMINADO " & _
                   "y no se prodrán realizar más cambios sobre esta.", vbQuestion + vbYesNo + vbDefaultButton2, "Confirmar") = vbYes Then

            If objFunciones.Ejecutar(sqlActualiza_Estado_Mov) Then
                sqlMovimientos =
                 "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
                 "(SELECT CAJ_Nombre FROM tb_cajas WHERE CAJ_Codigo = MC.CAJ_Codigo) AS Caja, " & _
                 "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo = MC.CON_Codigo) AS Consepto, " & _
                 "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Pagador) AS Pagador, " & _
                 "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Recibidor) AS Recibidor, " & _
                 "(SELECT COALESCE(SUM(DGAS_MontoSoles), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverSoles, " & _
                 "(SELECT COALESCE(SUM(DGAS_MontoDolares), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverDolares, " & _
                 "MCAJ_MontoSoles, MCAJ_MontoDolares, MCAJ_Detalle AS Detalle, MCAJ_Activo AS Estado " & _
                 "FROM tb_movimiento_cajas MC, tb_conceptos C, tb_cajas CA " & _
                 "WHERE MC.CON_Codigo = C.CON_Codigo AND " & _
                 "MC.CAJ_Codigo = CA.CAJ_Codigo AND " & _
                 "MC.MCAJ_Tipo='E' AND " & _
                 "MC.CAJ_Codigo='" & lblIDCaja.Text & "'"

                If lblMoneda.Text = "S" Then
                    FrmListaEgresos.lblQueda_Sol.Text = Format(MONTO_ACT_CAJASEL_SOL + CDbl(lblDevolver.Text), "#,##0.00")
                ElseIf lblMoneda.Text = "D" Then
                    FrmListaEgresos.lblQueda_Dol.Text = Format(MONTO_ACT_CAJASEL_USD + CDbl(lblDevolver.Text), "#,##0.00")
                End If
                'FrmListaEgresos.lblQueda_Dol.Text += lblDevolver.Text
                With FrmAperturarCaja
                    .cmdNuevo.Enabled = True
                    crearBotones("SELECT * FROM tb_cajas WHERE CAJ_Aperturado <> 2", .panelCajas, 200, 132, 5)
                End With
                modProcedimientos.listarMovimCaja(sqlMovimientos, FrmListaEgresos.dgvDetalleMov)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmTerminarMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class