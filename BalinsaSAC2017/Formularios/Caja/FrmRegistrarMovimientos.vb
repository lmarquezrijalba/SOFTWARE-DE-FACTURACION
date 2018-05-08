Public Class FrmRegistrarMovimientos
    Dim OPERACION_NRO, sqlOperacion As String
    Dim CodCaja As String

    Private Sub FrmRegistrarMovimientos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        modProcedimientos.llenarConceptosdeCajaxTipo(cboConceptos)
        modProcedimientos.llenarUsuarios(cboRecibidor)

        'If MDIPrincipal.mnuOperacionesCajas.Enabled = True Then
        'cmdConceptos.Enabled = True
        'cmdListar.Enabled = True
        'Else
        'cmdConceptos.Enabled = False
        'cmdListar.Enabled = False
        'End If
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim FechaMovimiento, CodConcepto, CodRecibidor, Observacion As String
        Dim TipoMoneda As String = ""
        Dim Monto, totalCajaSoles, totalCajaDolares As Double
        Dim sqlRegMovim As String = ""

        Dim Mes As String = Format(Now, "MM")

        CodCaja = lblCodCaja.Text
        FechaMovimiento = Format(Now, "dd/MM/yyyy H:mm:ss")
        CodConcepto = CStr(cboConceptos.SelectedValue)
        CodRecibidor = CStr(cboRecibidor.SelectedValue)
        Monto = txtImporte.Text
        totalCajaSoles = lblTotalCaja_Soles.Text
        totalCajaDolares = lblTotalCaja_Dolares.Text
        Observacion = txtObservacion.Text

        Try
            '------GENERA CODIGO DE OPERACION------
            '--------------------------------------
            sqlOperacion = "SELECT COUNT(MCAJ_Codigo) FROM tb_movimiento_cajas " & _
                           "WHERE CAJ_Codigo='" & CodCaja & "' AND " & _
                           "DATEPART(MONTH, MCAJ_FechaHora)='" & Mes & "' AND " & _
                           "MCAJ_Tipo='E'"

            OPERACION_NRO = objFunciones.Generar_Codigo(sqlOperacion, "0000")

            If CodRecibidor = "0" Then
                MsgBox("No se pudo registrar el movimiento." & vbNewLine & vbNewLine & _
                       "Debe seleccionar el usuario a quien le será asignado la salida de dinero.", vbCritical, "¡Aviso!")

                Exit Sub
                cboRecibidor.Focus()
            ElseIf Monto <= 0 Then
                MsgBox("No se pudo registrar el movimiento." & vbNewLine & vbNewLine & _
                       "El monto a desembolsar debe ser mayor a (cero).", vbCritical, "¡Aviso!")

                Exit Sub
                txtImporte.Focus()
            ElseIf optSoles.Checked And Monto > totalCajaSoles Then
                MsgBox("No se pudo registrar el movimiento." & vbNewLine & vbNewLine & _
                       "El monto a registrar es mayor al monto actual en soles de caja.", vbCritical, "¡Aviso!")

                Exit Sub
                txtImporte.Focus()
            ElseIf optDolares.Checked And Monto > totalCajaDolares Then
                MsgBox("No se pudo registrar el movimiento." & vbNewLine & vbNewLine & _
                       "El monto a registrar es mayor al monto actual en dólares de caja.", vbCritical, "¡Aviso!")

                Exit Sub
                txtImporte.Focus()
            Else
                If (MsgBox("¿ Realmente deseas registrar el siguiente movimiento ?", vbQuestion + vbYesNo + vbDefaultButton1, "Confirme") = vbYes) Then
                    Dim MontoInsertar As String = objFunciones.convertMoneda(Monto)

                    If optSoles.Checked Then
                        sqlRegMovim =
                        "INSERT INTO tb_movimiento_cajas(CAJ_Codigo, MCAJ_NroOperacion, CON_Codigo, " & _
                        "MCAJ_Pagador, MCAJ_Recibidor, MCAJ_Tipo,  MCAJ_FechaHora, " & _
                        "MCAJ_MontoSoles, MCAJ_Detalle, MCAJ_Activo) " & _
                        "VALUES('" & CodCaja & "','" & OPERACION_NRO & "','" & CodConcepto & "','" & _
                        USU_CODIGO & "','" & CodRecibidor & "','" & "E" & "','" & _
                        FechaMovimiento & "','" & MontoInsertar & "','" & _
                        Observacion & "','" & 1 & "')"
                    ElseIf optDolares.Checked Then
                        sqlRegMovim =
                        "INSERT INTO tb_movimiento_cajas(CAJ_Codigo, mcaj_nROoPERACION, CON_Codigo, " & _
                        "MCAJ_Pagador, MCAJ_Recibidor, MCAJ_Tipo, MCAJ_FechaHora, " & _
                        "MCAJ_MontoDolares, MCAJ_Detalle, MCAJ_Activo) " & _
                        "VALUES('" & CodCaja & "','" & OPERACION_NRO & "','" & CodConcepto & "','" & _
                        USU_CODIGO & "','" & CodRecibidor & "','" & "E" & "','" & _
                        FechaMovimiento & "','" & MontoInsertar & "','" & _
                        Observacion & "','" & 1 & "')"
                    End If

                    If objFunciones.Ejecutar(sqlRegMovim) Then
                        If optSoles.Checked Then
                            FrmListaEgresos.lblQueda_Sol.Text = Format(CType(lblTotalCaja_Soles.Text - txtImporte.Text, Decimal), "#,##0.00")
                            FrmListaIngresos.lblQueda_Sol.Text = Format(CType(lblTotalCaja_Soles.Text - txtImporte.Text, Decimal), "#,##0.00")
                            lblTotalCaja_Soles.Text = Format(CType(lblTotalCaja_Soles.Text - txtImporte.Text, Decimal), "#,##0.00")
                        ElseIf optDolares.Checked Then
                            FrmListaEgresos.lblQueda_Dol.Text = Format(CType(lblTotalCaja_Dolares.Text - txtImporte.Text, Decimal), "#,##0.00")
                            FrmListaIngresos.lblQueda_Dol.Text = Format(CType(lblTotalCaja_Dolares.Text - txtImporte.Text, Decimal), "#,##0.00")
                            lblTotalCaja_Dolares.Text = Format(CType(lblTotalCaja_Dolares.Text - txtImporte.Text, Decimal), "#,##0.00")
                        End If

                        panelEstado.BackColor = SystemColors.Control
                        cboConceptos.SelectedIndex = 0
                        cboRecibidor.SelectedIndex = 0
                        txtObservacion.Text = ""

                        cmdRegistrar.Enabled = False
                        txtImporte.Text = "0.00"
                        txtImporte.Enabled = False

                        'LISTAMOS MOVIMIENTOS
                        '-------------------------
                        Listar()
                    End If
                End If
                End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & CStr(objFunciones.getNombreProcedimiento))
        End Try
    End Sub

    Private Sub txtImporte_Click(sender As Object, e As EventArgs) Handles txtImporte.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtImporte)
    End Sub

    Private Sub txtImporte_GotFocus(sender As Object, e As EventArgs) Handles txtImporte.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtImporte)
    End Sub

    Private Sub txtImporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporte.KeyDown
        If e.KeyCode = 13 Then
            cmdRegistrar.Focus()
        End If
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        'modProcedimientos.Saltar(e)
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtImporte)
    End Sub

    Private Sub txtImporte_LostFocus(sender As Object, e As EventArgs) Handles txtImporte.LostFocus
        If txtImporte.Text <> "" Then
            txtImporte.Text = Format(CType(txtImporte.Text, Decimal), "#,##0.00")
        Else
            txtImporte.Text = Format(0, "#,##0.00")
        End If
    End Sub

    Private Sub cmdListar_Click(sender As Object, e As EventArgs) Handles cmdListar.Click
        Listar()
        'FrmListaEgresos.ShowDialog()
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtObservacion, e)
    End Sub

    Private Sub cboRecibidor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRecibidor.SelectionChangeCommitted
        If cboRecibidor.SelectedIndex <> 0 Then
            COD_RECIBIDOR = CStr(cboRecibidor.SelectedValue)
            FrmValidar.ShowDialog()
        End If
    End Sub

    Private Sub lblEstadoPermiso_TextChanged(sender As Object, e As EventArgs)
        If panelEstado.BackColor = Color.DarkTurquoise Then
            cmdRegistrar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboCajasNoPrincipales_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCajasNoPrincipales.SelectionChangeCommitted
        If cboCajasNoPrincipales.SelectedIndex <> 0 Then
            cmdRegistrar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub FrmRegistrarMovimientos_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FrmAperturarCaja.MdiParent = MDIPrincipal
        FrmAperturarCaja.Show()
    End Sub

    Private Sub cmdConceptos_Click(sender As Object, e As EventArgs) Handles cmdConceptos.Click
        FrmRegistrarConceptos.ShowDialog()
    End Sub

    Private Sub FrmRegistrarMovimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub optSoles_CheckedChanged(sender As Object, e As EventArgs) Handles optSoles.CheckedChanged
        lblstrMoneda.Text = "Monto S/."
    End Sub

    Private Sub optDolares_CheckedChanged(sender As Object, e As EventArgs) Handles optDolares.CheckedChanged
        lblstrMoneda.Text = "Monto $."
    End Sub

    Private Sub Listar()
        Dim sqlMovimientos As String
        Dim fechaActual As Date = Format(Now, "dd/MM/yyyy")

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
            "MC.CAJ_Codigo='" & lblCodCaja.Text & "'AND " & _
            "CONVERT(VARCHAR(10), MC.MCAJ_FechaHora, 103)='" & fechaActual & "'"

        With FrmListaEgresos
            listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
            'colorFilaMovimientos(.dgvDetalleMov, 15)

            .lblCodCaja.Text = lblCodCaja.Text
            .lblQueda_Sol.Text = lblTotalCaja_Soles.Text
            .lblQueda_Dol.Text = lblTotalCaja_Dolares.Text
            .ShowDialog()
        End With
    End Sub
End Class