Imports System.Data.SqlClient

Public Class FrmRegistraGasto
    Dim colum, fila As Integer
    'Dim Ejec As Boolean
    Dim TipoMoneda As String

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        With dgvDetalle
            .Rows.Add()

            If .RowCount > 1 Then
                .CurrentCell = dgvDetalle.Rows(fila + 1).Cells(0)
            End If
        End With
    End Sub

    Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
        'Ejec = False

        With dgvDetalle
            If Not IsNothing(.CurrentRow) Then
                If MsgBox("Realmente deseas quitar la fila seleccionada.", _
                          vbQuestion + vbYesNo + vbDefaultButton2, "Quitar elemento") = vbYes Then

                    'Ejec = True

                    If txtMonto.Visible Or txtDescripcion.Visible Then
                        txtMonto.Visible = False
                        txtDescripcion.Visible = False
                    End If

                    .Rows.Remove(.CurrentRow)
                    lblTotGastado.Text = Format(objFunciones.Sumar_Columna(dgvDetalle, 1), "#,##0.00")
                    lblTotDevolver.Text = Format((CDbl(lblMontoOtorgado.Text) - CDbl(lblTotGastado.Text)), "#,##0.00")
                Else
                    'Ejec = True
                End If
            End If
        End With
    End Sub

    Private Sub FrmRegistraGasto_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        modProcedimientos.llenarDetalleGasto(cboMovimiento)
    End Sub

    Private Sub FrmRegistraGasto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub cboMovimiento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboMovimiento.SelectionChangeCommitted
        Dim sqlDetalleGasto As String
        Dim numReg As Integer

        Try
            If cboMovimiento.SelectedIndex = 0 Then
                'cmdRegistrar.Enabled = False
                cmdAgregar.Enabled = False
                'cmdQuitar.Enabled = False
            Else
                cmdAgregar.Enabled = True
                'cmdQuitar.Enabled = True

                sqlDetalleGasto = "SELECT MCAJ_Codigo, CAJ_Codigo, MCAJ_MontoSoles, " & _
                                  "MCAJ_MontoDolares " & _
                                  "FROM tb_movimiento_cajas " & _
                                  "WHERE MCAJ_Codigo='" & cboMovimiento.SelectedValue & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlDetalleGasto, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count - 1

                If numReg >= 0 Then
                    lblIDCaja.Text = CStr(dt.Rows(0).Item("CAJ_Codigo"))

                    If CDbl(dt.Rows(0).Item("MCAJ_MontoSoles")) = 0 Then
                        TipoMoneda = "Dolares"
                        lblMontoOtorgado.Text = Format(CDbl(dt.Rows(0).Item("MCAJ_MontoDolares")), "#,##0.00")
                    ElseIf CDbl(dt.Rows(0).Item("MCAJ_MontoDolares")) = 0 Then
                        TipoMoneda = "Soles"
                        lblMontoOtorgado.Text = Format(CDbl(dt.Rows(0).Item("MCAJ_MontoSoles")), "#,##0.00")
                    End If

                    cmdAgregar.Focus()
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtMonto_Click(sender As Object, e As EventArgs) Handles txtMonto.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtMonto)
    End Sub

    Private Sub txtMonto_GotFocus(sender As Object, e As EventArgs) Handles txtMonto.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtMonto)
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtMonto)
    End Sub

    Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

    End Sub

    Private Sub txtDescripcion_Click(sender As Object, e As EventArgs) Handles txtDescripcion.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtDescripcion)
    End Sub

    Private Sub txtDescripcion_GotFocus(sender As Object, e As EventArgs) Handles txtDescripcion.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtDescripcion)
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = 13 Then
            If txtDescripcion.Text <> "" Then
                dgvDetalle.Item(colum, fila).Value = CStr(txtDescripcion.Text)
                txtDescripcion.Visible = False
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDescripcion, e)
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim sqlInsert As String = ""
        Dim numReg As Integer
        Dim Desc As String : Dim Monto As Double
        Dim c As Integer
        numReg = dgvDetalle.Rows.Count

        Try
            If MsgBox("Confirme su accion." & vbNewLine & vbNewLine & _
                      "De haber declarado todos tus gastos pulsa el botón ( Si ), de no " & _
                      "haberlo hecho o faltar alguno(s) pulsa ( No ) y Agregalo(s).", vbQuestion + vbYesNo + vbDefaultButton1, "Confirme") = vbYes Then

                For c = 0 To numReg - 1
                    Dim VALOR_MONTO As Double = CDbl(dgvDetalle.Item(1, c).Value)
                    If VALOR_MONTO <= 0 Or Not IsNumeric(VALOR_MONTO) Then
                        dgvDetalle.Rows.RemoveAt(c)
                    End If
                Next

                If dgvDetalle.RowCount > 0 Then '-1 Then
                    For i = 0 To dgvDetalle.RowCount - 1
                        Desc = CStr(dgvDetalle.Item(0, i).Value)
                        Monto = CDbl(dgvDetalle.Item(1, i).Value)

                        If TipoMoneda = "Soles" Then
                            sqlInsert = "INSERT INTO tb_detalle_gastos(MCAJ_Codigo, DGAS_Descripcion, " & _
                                        "DGAS_MontoSoles, DGAS_Activo) " & _
                                        "VALUES('" & cboMovimiento.SelectedValue & "', '" & _
                                        Desc & "', '" & objFunciones.convertMoneda(Monto) & "', '" & 1 & "')"
                        ElseIf TipoMoneda = "Dolares" Then
                            sqlInsert = "INSERT INTO tb_detalle_gastos(MCAJ_Codigo, DGAS_Descripcion, " & _
                                        "DGAS_MontoDolares, DGAS_Activo) " & _
                                        "VALUES('" & cboMovimiento.SelectedValue & "', '" & _
                                        Desc & "', '" & objFunciones.convertMoneda(Monto) & "', '" & 1 & "')"
                        End If

                        objFunciones.Ejecutar(sqlInsert)
                        'End If
                    Next

                    If objFunciones.Ejecutar("UPDATE tb_movimiento_cajas SET " & _
                                             "MCAJ_Activo='2' WHERE MCAJ_Codigo='" & cboMovimiento.SelectedValue & "'") Then
                        MsgBox("El detalle de sus gastos se registrarón con exito.", vbInformation, "¡Correcto!")
                        modProcedimientos.llenarDetalleGasto(cboMovimiento)
                        cmdRegistrar.Enabled = False
                        dgvDetalle.Rows.Clear()
                    End If
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub dgvDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellEnter
        Try
            fila = dgvDetalle.CurrentCell.RowIndex
            colum = dgvDetalle.CurrentCell.ColumnIndex

            Dim cellRectangle = dgvDetalle.GetCellDisplayRectangle(colum, fila, True)
            Dim cellAlto As Integer = cellRectangle.Height - 1
            Dim CellAncho As Integer = cellRectangle.Width - 1
            Dim PosicionX As Integer = cellRectangle.X + dgvDetalle.Left
            Dim PosicionY As Integer = cellRectangle.Y + dgvDetalle.Top

            If colum = 0 Then
                txtDescripcion.AutoSize = False
                txtDescripcion.Size = New Size(CellAncho, cellAlto)
                txtDescripcion.Left = PosicionX
                txtDescripcion.Top = PosicionY
                txtDescripcion.Text = dgvDetalle.Item(colum, fila).Value

                txtDescripcion.Visible = True
                txtDescripcion.Focus()

                Exit Sub
            ElseIf colum = 1 Then
                txtMonto.AutoSize = False
                txtMonto.Size = New Size(CellAncho, cellAlto)
                txtMonto.Left = PosicionX
                txtMonto.Top = PosicionY
                txtMonto.Text = dgvDetalle.Item(colum, fila).Value

                txtMonto.Visible = True
                txtMonto.Focus()

                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        If dgvDetalle.RowCount > 0 Then
            'cmdRegistrar.Enabled = True
            cmdQuitar.Enabled = True
        Else
            'cmdRegistrar.Enabled = False
            cmdQuitar.Enabled = False
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub txtDescripcion_LostFocus(sender As Object, e As EventArgs) Handles txtDescripcion.LostFocus
        If txtDescripcion.Text <> "" Then
            dgvDetalle.Item(colum, fila).Value = CStr(txtDescripcion.Text)
            txtDescripcion.Visible = False

            dgvDetalle.CurrentCell = dgvDetalle.Rows(fila).Cells(1)
            cmdAgregar.Enabled = True
            cmdRegistrar.Enabled = True
        Else
            cmdAgregar.Enabled = False
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub txtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = 13 Then
            If IsNumeric(txtMonto.Text) And txtMonto.Text <> "" Then
                dgvDetalle.Item(colum, fila).Value = Format(CDbl(txtMonto.Text), "#,##0.00")

                lblTotGastado.Text = Format(objFunciones.Sumar_Columna(dgvDetalle, 1), "#,##0.00")
                lblTotDevolver.Text = Format((CDbl(lblMontoOtorgado.Text) - CDbl(lblTotGastado.Text)), "#,##0.00")

                cmdAgregar.Enabled = True
                txtMonto.Visible = False
            End If
        End If
    End Sub

    Private Sub txtMonto_LostFocus(sender As Object, e As EventArgs) Handles txtMonto.LostFocus
        Try
            If IsNumeric(txtMonto.Text) And txtMonto.Text <> "" Then
                dgvDetalle.Item(colum, fila).Value = Format(CDbl(txtMonto.Text), "#,##0.00")
                txtMonto.Visible = False
                cmdAgregar.Focus()

                cmdAgregar.Enabled = True
                cmdRegistrar.Enabled = True
            Else
                cmdAgregar.Enabled = False
                cmdRegistrar.Enabled = False
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub dgvDetalle_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDetalle.CellMouseMove
        dgvDetalle.Cursor = Cursors.Hand
    End Sub
End Class