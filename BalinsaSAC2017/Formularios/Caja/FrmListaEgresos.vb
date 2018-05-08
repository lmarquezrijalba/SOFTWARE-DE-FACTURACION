Imports System.Data.SqlClient

Public Class FrmListaEgresos

    Dim IDCaja As String
    Dim Mes As Integer

    Private Sub FrmListaEgresos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        IDCaja = lblCodCaja.Text
    End Sub

    Private Sub FrmListarMovimientos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'With dgvDetalleMov
        '.Top = 62
        '.Width = Me.Width - 16.5
        '.Height = (Me.Height - (Panel1.Height + Panel2.Height + 41))


        'End With

        With dgvDetalleMov
            lblTextoEncabezado.Width = .Width
            Dim ancho As Integer = .Width - 20

            .Columns(1).Width = (ancho * 3) / 100
            .Columns(3).Width = (ancho * 7) / 100
            .Columns(5).Width = (ancho * 10) / 100
            .Columns(6).Width = (ancho * 20) / 100
            .Columns(7).Width = (ancho * 6) / 100
            .Columns(8).Width = (ancho * 6) / 100

            .Columns(9).Width = (ancho * 7) / 100
            .Columns(10).Width = (ancho * 7) / 100
            .Columns(11).Width = (ancho * 7) / 100
            .Columns(12).Width = (ancho * 7) / 100
            .Columns(13).Width = (ancho * 7) / 100
            .Columns(14).Width = (ancho * 7) / 100
            .Columns(15).Width = (ancho * 6) / 100
        End With
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        FrmFiltroMov.ShowDialog()
    End Sub

    Private Sub cmdRefrescar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        cargarLista()
    End Sub

    Private Sub FrmListaEgresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mes = Format(Now, "MM")
        Dim column As DataGridViewColumn
        With dgvDetalleMov
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.CellBorderStyle = DataGridViewCellBorderStyle.None

            For Each column In .Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With
        'modProcedimientos.setearGridaEstatica(dgvDetalleMov)
        'cargarLista()
    End Sub

    Private Sub cargarLista()
        Dim sqlMovimientos As String

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
        "MC.CAJ_Codigo='" & IDCaja & "'AND " & _
        "DATEPART(MONTH, MC.MCAJ_FechaHora)='" & Mes & "'"

        modProcedimientos.listarMovimCaja(sqlMovimientos, dgvDetalleMov)
        'modProcedimientos.colorFilaMovimientos(dgvDetalleMov, 15)
    End Sub

    Private Sub dgvDetalleMov_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleMov.CellClick
        'Dim filaSelec, ultimaFila As Integer

        'If e.RowIndex >= 0 Then
        'filaSelec = e.RowIndex
        'ultimaFila = dgvDetalleMov.RowCount - 1

        'If filaSelec = ultimaFila Then
        'dgvDetalleMov.Rows(ultimaFila).DefaultCellStyle.BackColor = Color.White
        'dgvDetalleMov.Rows(ultimaFila).Selected = False
        'Else
        'dgvDetalleMov.Rows(e.RowIndex).Selected = True
        ''e.CellStyle.SelectionBackColor = dgvDetalleMov.Rows(e.RowIndex).DefaultCellStyle.BackColor
        ''e.CellStyle.SelectionForeColor = Color.Yellow
        'End If
        'End If
    End Sub

    Private Sub dgvDetalleMov_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleMov.CellDoubleClick
        Dim fila As Integer
        Dim IDMov, IDCaj, NroOp, NombCaja, Estado As String
        Dim MontoSoles, GastoSoles, MontoDolares, GastoDolares As Double

        If e.RowIndex >= 0 Then
            fila = e.RowIndex

            'If MDIPrincipal.mnuOperacionesCajas.Enabled Then
            With FrmTerminarMovimiento
                IDMov = CStr(dgvDetalleMov.Item(0, fila).Value)
                IDCaj = CStr(dgvDetalleMov.Item(16, fila).Value)
                NroOp = CStr(dgvDetalleMov.Item(1, fila).Value)
                NombCaja = CStr(dgvDetalleMov.Item(2, fila).Value)
                Estado = CStr(dgvDetalleMov.Item(15, fila).Value)
                MontoSoles = CDbl(dgvDetalleMov.Item(9, fila).Value)
                GastoSoles = CDbl(dgvDetalleMov.Item(11, fila).Value)
                MontoDolares = CDbl(dgvDetalleMov.Item(12, fila).Value)
                GastoDolares = CDbl(dgvDetalleMov.Item(14, fila).Value)

                .lblOp.Text = NroOp
                .lblIDMov.Text = IDMov
                .lblIDCaja.Text = IDCaj
                .lblNombCaja.Text = NombCaja

                If MontoDolares = 0 Then
                    .lblstrDesembolso.Text = "Desembolsó " & "S/ : "
                    .lblstrDevolver.Text = "Por devolver " & "S/ : "
                    .lblstrGastado.Text = "Tot.  Gastado " & "S/ : "
                    .lblMoneda.Text = "S"

                    .lblImporte.Text = Format(MontoSoles, "#,##0.00")
                    .lblGastado.Text = Format(GastoSoles, "#,##0.00") 'Format(objFunciones.SumarLista(dgvDetalleMov, 1), "#,##0.00")
                    .lblDevolver.Text = Format(MontoSoles - GastoSoles, "#,##0.00") 'Format(CDbl(lblImporte.Text) - CDbl(lblGastado.Text), "#,##0.00")
                ElseIf MontoSoles = 0 Then
                    .lblstrDesembolso.Text = "Desembolsó " & "$ : "
                    .lblstrDevolver.Text = "Por devolver " & "$ : "
                    .lblstrGastado.Text = "Tot.  Gastado " & "$ : "
                    .lblMoneda.Text = "D"

                    .lblImporte.Text = Format(MontoDolares, "#,##0.00")
                    .lblGastado.Text = Format(GastoDolares, "#,##0.00") 'Format(objFunciones.SumarLista(dgvDetalleMov, 1), "#,##0.00")
                    .lblDevolver.Text = Format(MontoDolares - GastoDolares, "#,##0.00") 'Format(CDbl(lblImporte.Text) - CDbl(lblGastado.Text), "#,##0.00")
                End If

                If Estado = "PENDIENTE" Then
                    .cmdTerminar.Visible = True
                    .Text = "Terminar operación"

                    modProcedimientos.listarGastos_x_Mov(.dgvDetalleMov, IDMov)
                    .ShowDialog()
                ElseIf Estado = "TERMINADO" Then
                    .cmdTerminar.Visible = False
                    .Text = "Detalle de la operación"

                    modProcedimientos.listarGastos_x_Mov(.dgvDetalleMov, IDMov)
                    .ShowDialog()
                End If
            End With
            'Else
            '    MsgBox("No se puede realizar esta operación" & vbNewLine & vbNewLine & _
            '       "No cuentas con permisos suficientes para realizar esta operación.", vbCritical, "Permiso denegado")
            'End If
        End If
    End Sub

    Private Sub dgvDetalleMov_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetalleMov.CellFormatting
        'e.CellStyle.SelectionBackColor = dgvDetalleMov.Rows(e.RowIndex).DefaultCellStyle.BackColor
        'e.CellStyle.SelectionForeColor = Color.Black
        'e.CellStyle.Font = New Drawing.Font("Tahoma", 8, FontStyle.Bold, GraphicsUnit.Point)

        e.CellStyle.SelectionBackColor = dgvDetalleMov.Rows(e.RowIndex).DefaultCellStyle.BackColor

        If dgvDetalleMov.Item(15, e.RowIndex).Value <> "GENERADO" And
           dgvDetalleMov.Item(15, e.RowIndex).Value <> "PENDIENTE" And
           dgvDetalleMov.Item(15, e.RowIndex).Value <> "TERMINADO" Then
            e.CellStyle.SelectionForeColor = dgvDetalleMov.Rows(e.RowIndex).DefaultCellStyle.ForeColor 'Color.Yellow
            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        Else
            e.CellStyle.SelectionForeColor = Color.Yellow
            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        End If
    End Sub

    Private Sub dgvDetalleMov_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleMov.CellContentClick

    End Sub
End Class