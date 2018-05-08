Public Class FrmFiltroMov
    Dim IDCaja As String
    Dim anioActual, anioInicio As Integer

    Private Sub FrmFiltroMov_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmFiltroMov_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Width = mcCalendario.Width + 16
        cboUsuarios.Width = mcCalendario.Width - 10
        cmdCerrar.Left = (Me.Width - cmdCerrar.Width) - 20
        cboMeses.Width = (cboUsuarios.Width - cboAnio.Width) - 6


        IDCaja = FrmListaEgresos.lblCodCaja.Text
        anioActual = CInt(Format(Now, "yyyy"))
        anioInicio = CInt(2015)

        'LLENAMOS COMBO CON AÑOS
        '--------------------------------
        cboAnio.Items.Clear()
        cboAnio.Items.Add("Seleccione")
        For i = anioActual To anioInicio Step -1
            cboAnio.Items.Add(i)
        Next

        'LLENAMOS COMBO CON MESES
        '--------------------------------
        cboMeses.Items.Clear()
        cboMeses.Items.Add("Seleccione")
        For i = 1 To 12
            If i < 10 Then
                cboMeses.Items.Add(i & "    " & objFunciones.obtenerNombreMes(i))
            Else
                cboMeses.Items.Add(i & "  " & objFunciones.obtenerNombreMes(i))
            End If
        Next

        modProcedimientos.llenarUsuarios(cboUsuarios)
    End Sub

    Private Sub mcCalendario_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mcCalendario.DateChanged
        Dim sqlMovimientos As String
        Dim fecha As Date
        fecha = mcCalendario.SelectionRange.Start()

        With FrmListaEgresos
            sqlMovimientos = "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
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
                             "MC.CAJ_Codigo='" & IDCaja & "'AND " & _
                             "CONVERT(VARCHAR(10), MC.MCAJ_FechaHora, 103)='" & fecha & "'"
            'End If

            modProcedimientos.listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
            'modProcedimientos.colorFilaMovimientos(.dgvDetalleMov, 15)
        End With
    End Sub

    Private Sub cboUsuarios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboUsuarios.SelectionChangeCommitted
        Dim IDRecibidor, sqlMovimientos As String
        IDRecibidor = CStr(cboUsuarios.SelectedValue)

        If IDRecibidor <> 0 Then
            With FrmListaEgresos
                sqlMovimientos = "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
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
                "MC.CAJ_Codigo='" & IDCaja & "'AND " & _
                "MC.MCAJ_Recibidor='" & IDRecibidor & "'"
                'End If

                modProcedimientos.listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
                'modProcedimientos.colorFilaMovimientos(.dgvDetalleMov, 15)
            End With
        End If
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        Dim Anio, sqlMovimientos As String
        Anio = cboAnio.Text 'Format(Now, "yyyy")

        If cboAnio.SelectedIndex <> 0 Then
            With FrmListaEgresos
                sqlMovimientos = "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
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
                "MC.CAJ_codigo='" & IDCaja & "'AND " & _
                "DATEPART(YEAR, MC.MCAJ_FechaHora)='" & Anio & "'"

                modProcedimientos.listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
                'modProcedimientos.colorFilaMovimientos(.dgvDetalleMov, 15)
            End With
        End If
    End Sub

    Private Sub cboMeses_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboMeses.SelectionChangeCommitted
        Dim Mes, Anio, sqlMovimientos As String
        Mes = Mid(cboMeses.Text, 1, 2) 'Format(Now, "yyyy")

        If cboAnio.SelectedIndex = 0 Then
            Anio = anioActual
        Else
            Anio = cboAnio.Text
        End If


        If cboMeses.SelectedIndex <> 0 Then
            With FrmListaEgresos
                sqlMovimientos = "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
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
                "MC.CAJ_Codigo='" & IDCaja & "' AND " & _
                "DATEPART(YEAR, MC.MCAJ_FechaHora)='" & Anio & "' AND " & _
                "DATEPART(MONTH, MC.MCAJ_FechaHora)='" & Mes & "'"

                modProcedimientos.listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
                'modProcedimientos.colorFilaMovimientos(.dgvDetalleMov, 15)
            End With
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedIndexChanged

    End Sub
End Class