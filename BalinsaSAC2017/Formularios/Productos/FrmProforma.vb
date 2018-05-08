Public Class FrmProforma
    Dim fila, colum As Integer
    Dim numRegistrados As Integer

    Dim SQLIDCotizacion As String = "SELECT COUNT(COT_Codigo) FROM tb_cotizaciones " & _
                                    "WHERE DATEPART(MONTH, COT_FECHA)='" & Format(Now, "MM") & "'"

    Dim SQLRequerientos As String =
    "SELECT R.REQ_Codigo, R.REQ_Tipo, R.REQ_Fecha, R.REQ_Descripcion, " & _
    "R.REQ_Estado, R.REQ_Estado, C.CLI_RazonSocial, " & _
    "ISNULL(R.REQ_FechaSeg, '01/01/1900') AS REQ_FechaSeg, U.USU_Nombres " & _
    "FROM tb_requerimientos R, tb_usuarios U, tb_clientes C " & _
    "WHERE U.USU_Codigo=R.USU_Codigo AND " & _
    "R.CLI_Codigo=C.CLI_Codigo AND R.REQ_Estado='0' " & _
    "ORDER BY R.REQ_FechaSeg ASC"

    Dim SQLCotizaciones As String =
    "SELECT SUBSTRING(Co.COT_Codigo, 1, 8) AS Indice, " & _
    "(SELECT CLI_RazonSocial FROM tb_clientes C  WHERE C.CLI_Codigo=Co.CLI_Codigo) AS Cliente," & _
    "(SELECT U.USU_ApePaterno+' '+U.USU_ApeMaterno+', '+U.USU_Nombres FROM tb_usuarios U  WHERE U.USU_Codigo=Co.USU_Codigo) AS Registro, " & _
    "(SELECT COUNT(COT_Codigo) from tb_cotizaciones WHERE SUBSTRING(COT_Codigo, 1, 8)=SUBSTRING(Co.COT_Codigo, 1, 8)) AS NumCotiz " & _
    "FROM tb_cotizaciones Co " & _
    "WHERE Co.COT_Estado='1' " & _
    "GROUP BY SUBSTRING(Co.COT_Codigo, 1, 8), Co.CLI_Codigo, Co.USU_Codigo " & _
    "ORDER BY Indice"

    Private Sub cmdListarProductos_Click(sender As Object, e As EventArgs) Handles cmdListarProductos.Click
        FrmListaProductos.ShowDialog()
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
        Quitar()
    End Sub

    Private Sub Quitar()
        Dim subTotal, valIGV, Total, Materiales As Double
        Dim ID_Det_Cotiz As String = ""

        With dgvDetalleCotizacion
            If Not IsNothing(.CurrentRow) Then
                ID_Det_Cotiz = .Item(0, .CurrentRow.Index).Value

                If MsgBox("¿ Realmente deseas quitar la fila seleccionada ?.", _
                          vbQuestion + vbYesNo + vbDefaultButton1, "Quitar elemento") = vbYes Then

                    If Not IsNumeric(ID_Det_Cotiz) Then
                        .Rows.Remove(.CurrentRow)

                        For i = 0 To .RowCount - 1
                            .Item(1, i).Value = i + 1
                        Next

                        subTotal = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)
                        lblSubTotal.Text = Format(subTotal, "#,##0.00")
                    Else
                        If objFunciones.Ejecutar("UPDATE tb_detalle_cotizaciones SET DCOT_Activo='0' " & _
                                                 "WHERE DCOT_Codigo='" & ID_Det_Cotiz & "'") Then
                            .Rows.Remove(.CurrentRow)

                            For i = 0 To .RowCount - 1
                                .Item(1, i).Value = i + 1
                            Next

                            subTotal = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)
                            lblSubTotal.Text = Format(subTotal, "#,##0.00")
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dgvDetalleCotizacion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleCotizacion.CellEnter
        Try
            With dgvDetalleCotizacion
                fila = .CurrentCell.RowIndex
                colum = .CurrentCell.ColumnIndex

                Dim cellRectangle = .GetCellDisplayRectangle(colum, fila, True)
                Dim cellAlto As Integer = cellRectangle.Height - 1
                Dim CellAncho As Integer = cellRectangle.Width - 1
                Dim PosicionX As Integer = cellRectangle.X + .Left
                Dim PosicionY As Integer = cellRectangle.Y + .Top

                cmdQuitar.Enabled = True

                If colum = 3 Then
                    txtPrecio.AutoSize = False
                    txtPrecio.Size = New Size(CellAncho, cellAlto)
                    txtPrecio.Left = PosicionX
                    txtPrecio.Top = PosicionY
                    txtPrecio.Visible = True
                    txtPrecio.Text = .Item(colum, fila).Value
                    txtPrecio.Focus()

                    modProcedimientos.SELEC_TODO_TEXTO(txtPrecio)
                    Exit Sub
                Else
                    txtPrecio.Visible = False
                End If
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCatalogoProd_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetalleCotizacion.KeyDown
        Dim subTotal, valIGV, Total, Materiales As Double

        Dim Precio As Double
        Dim fila, Cant As Integer

        Try
            If Not IsNothing(dgvDetalleCotizacion.CurrentRow) Then
                fila = dgvDetalleCotizacion.CurrentRow.Index
                Cant = dgvDetalleCotizacion.Item(4, fila).Value
                Precio = dgvDetalleCotizacion.Item(3, fila).Value

                If e.KeyData = 46 Then
                    Quitar()
                ElseIf (e.KeyData = 107 Or e.KeyValue = 187) And Cant >= 1 Then
                    dgvDetalleCotizacion.Item(4, fila).Value += 1
                    Cant = dgvDetalleCotizacion.Item(4, fila).Value
                    dgvDetalleCotizacion.Item(5, fila).Value = Format(Precio * Cant, "#,##0.00")
                ElseIf (e.KeyData = 109 Or e.KeyValue = 189) And Cant > 1 Then
                    dgvDetalleCotizacion.Item(4, fila).Value -= 1
                    Cant = dgvDetalleCotizacion.Item(4, fila).Value
                    dgvDetalleCotizacion.Item(5, fila).Value = Format(Precio * Cant, "#,##0.00")
                End If

                subTotal = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)
                lblSubTotal.Text = Format(subTotal, "#,##0.00")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub cmdMateriales_Click(sender As Object, e As EventArgs) Handles cmdMateriales.Click
        txtMateriales.Visible = True
        cmdMateriales.Visible = False

        txtMateriales.Focus()
    End Sub

    Private Sub FrmProforma_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            'Me.Close()
            If dgvListaClientes.Visible = True Then
                dgvListaClientes.Visible = False
            End If
        End If
    End Sub

    Private Sub txtMateriales_TextChanged(sender As Object, e As EventArgs) Handles txtMateriales.TextChanged
        If Len(txtMateriales.Text) > 0 Then
            If Val(txtMateriales.Text) < 0 Or Val(txtMateriales.Text) > 100 Then
                MsgBox("El rango de ingreso debe estar entre 0 - 100", vbInformation, "Corregir")
                txtMateriales.Focus()
            End If
        Else
            txtMateriales.Text = "0"
        End If
    End Sub

    Private Sub txtMateriales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMateriales.KeyDown
        Dim valIGV, Subtotal, Materiales As Double

        If e.KeyCode = 13 Then
            valIGV = lblIGV.Text
            Subtotal = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)
            Materiales = (Subtotal + valIGV) * (txtMateriales.Text / 100)

            lblMateriales.Text = Format(Materiales, "#,##0.00")
            lblTotal.Text = Format(Subtotal + valIGV + Materiales, "#,##0.00")

            txtMateriales.Visible = False
            cmdMateriales.Visible = True
        End If
    End Sub

    Private Sub FrmProforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.Default

        lblMoneda.Text = "SOLES" : txtMateriales.Text = "0"
        lblSubTotal.Text = "0,00" : lblTotal.Text = "0,00"
        lblIGV.Text = "0,00" : lblMateriales.Text = "0,00"

        lblIDCotiz.Text = Format(Now, "yy") & objFunciones.Generar_Codigo("SELECT ISNULL(MAX(SUBSTRING(COT_Codigo, 3, 6)), 0) FROM tb_cotizaciones WHERE DATEPART(YEAR, COT_Fecha)='" & Format(Now, "yyyy") & "'", "000000") & _
                  "-1"  'objFunciones.Generar_Codigo(SQLIDCotizacion, "00000000", Format(Now, "yy"))
        lblFecha.Text = Format(Now, "dd/MM/yyyy")

        With tbNumCotizaciones
            .Minimum = 1 : .Maximum = 9
        End With

        With dgvListaClientes
            .Height = 153
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With

        With dgvDetalleCotizacion
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .Font = New Font(New FontFamily("Courier New"), 8, FontStyle.Bold)
        End With

        lblAsesor.Text = USU_NOMBRE_LARGO

        For i = 1 To 30
            If i <= 9 Then
                cboDiasEntrega.Items.Add("0" & i)
                cboDiasValidos.Items.Add("0" & i)
            Else
                cboDiasEntrega.Items.Add(i)
                cboDiasValidos.Items.Add(i)
            End If
        Next
    End Sub

    Private Sub txtCliente_Click(sender As Object, e As EventArgs) Handles txtCliente.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtCliente)
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtCliente, e)
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.Text <> "" Then
            modProcedimientos.listarClientesFactura(dgvListaClientes, txtCliente.Text)
        Else
            dgvListaClientes.Visible = False
        End If
    End Sub

    Private Sub dgvListaClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaClientes.CellDoubleClick
        Dim fila As Integer

        If e.RowIndex >= 0 Then
            fila = e.RowIndex

            lblIDCliente.Text = dgvListaClientes.Item(0, fila).Value
            txtCliente.Text = dgvListaClientes.Item(1, fila).Value

            dgvListaClientes.Visible = False
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDescripcion, e)
    End Sub

    Private Sub txtFormaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFormaPago.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtFormaPago, e)
    End Sub

    Private Sub txtGarantia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGarantia.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtGarantia, e)
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtObservacion, e)
    End Sub

    Private Sub cmdCambiar_Click(sender As Object, e As EventArgs) Handles cmdCambiar.Click
        If lblMoneda.Text = "SOLES" Then
            lblMoneda.Text = "DÓLARES"
        ElseIf lblMoneda.Text = "DÓLARES" Then
            lblMoneda.Text = "SOLES"
        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        Dim CANT As Integer
        Dim PREC, SUBTOT As Double

        If e.KeyCode = 13 Then
            With dgvDetalleCotizacion
                PREC = txtPrecio.Text
                CANT = .Item(4, fila).Value

                .Item(3, fila).Value = Format(CDbl(txtPrecio.Text), "#,##0.00")
                .Item(5, fila).Value = Format(PREC * CANT, "#,##0.00")

                SUBTOT = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)
                lblSubTotal.Text = Format(SUBTOT, "#,##0.00")

                txtPrecio.Visible = False
                cmdListarProductos.Focus()
            End With
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtPrecio)
    End Sub

    Private Sub lblSubTotal_TextChanged(sender As Object, e As EventArgs) Handles lblSubTotal.TextChanged
        Dim subTotal, MontoIGV, Total, Materiales As Double

        subTotal = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)

        If chkIncIGV.Checked Then
            MontoIGV = 0
        Else
            MontoIGV = subTotal * (IGV / 100)
        End If

        Total = subTotal + MontoIGV
        Materiales = Total * (txtMateriales.Text / 100)

        lblMateriales.Text = Format(Materiales, "#,##0.00")
        lblSubTotal.Text = Format(subTotal, "#,##0.00")
        lblIGV.Text = Format(MontoIGV, "#,##0.00")
        lblTotal.Text = Format(Total + Materiales, "#,##0.00")
    End Sub

    Private Sub chkIncIGV_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncIGV.CheckedChanged
        Dim subTot, MontoIGV, Materia, Tot As Double

        subTot = objFunciones.Sumar_Columna(dgvDetalleCotizacion, 5)

        If chkIncIGV.Checked Then
            MontoIGV = 0
        Else
            MontoIGV = subTot * (IGV / 100)
        End If

        lblSubTotal.Text = Format(subTot, "#,##0.00")

        Tot = subTot + MontoIGV
        Materia = Tot * (txtMateriales.Text / 100)
        lblIGV.Text = Format(MontoIGV, "#,##0.00")
        lblTotal.Text = Format(Tot, "#,##.00")
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim IDCotiz As String = ""
        Dim SQLInsertar As String = "" : Dim SQLUpdate As String = ""
        Dim SQLInsertDetalle As String = "" : Dim sqlUpdateDetalle As String = ""
        Dim SQLGeneraID As String
        Dim Marcar As Integer = 0

        numRegistrados += 1

        SQLGeneraID =
        "SELECT ISNULL(MAX(SUBSTRING(COT_Codigo, 3, 6)), 0) FROM tb_cotizaciones WHERE DATEPART(YEAR, COT_Fecha)='" & Format(Now, "yyyy") & "'"

        With dgvDetalleCotizacion
            If cmdGuardar.Text = "Guardar proforma " And MDIPrincipal.mnuRegistrarCotización.Enabled Then
                NOMB_VENTANA_ACTIVA = "Guardar proforma "

                IDCotiz = Format(Now, "yy") & objFunciones.Generar_Codigo(SQLGeneraID, "000000") & "-" & numRegistrados

                SQLInsertar =
                "INSERT INTO tb_cotizaciones(COT_Codigo, CLI_Codigo, USU_Codigo, COT_Garantia, " & _
                "COT_Fecha, COT_Dias, COT_Valides, COT_PORMAT, COT_IGV, COT_CONINST, COT_CONIGV, COT_VERPREC, " & _
                "COT_Moneda, COT_FormaPago, COT_Descripcion, COT_Observacion, COT_Importe, COT_Estado) " & _
                "VALUES('" & IDCotiz & "', '" & lblIDCliente.Text & "', '" & USU_CODIGO & "', '" & _
                txtGarantia.Text & "', '" & Format(Now, "dd/MM/yyyy") & "', '" & cboDiasEntrega.Text & "', '" & _
                cboDiasValidos.Text & "', '" & txtMateriales.Text & "', '" & IGV & "', '" & chkIncINS.Checked & "', '" & _
                chkIncIGV.Checked & "', '" & chkMostrarPrecios.Checked & "', '" & _
                Mid(lblMoneda.Text, 1, 1) & "', '" & txtFormaPago.Text & "', '" & txtDescripcion.Text & "', '" & _
                txtObservacion.Text & "', '" & objFunciones.convertMoneda(CDbl(lblSubTotal.Text)) & "', '" & 1 & "')"

                If .Rows.Count > 0 Then
                    If objFunciones.Ejecutar(SQLInsertar) Then

                        For i = 0 To .Rows.Count - 1
                            SQLInsertDetalle =
                            "INSERT INTO tb_detalle_cotizaciones(COT_Codigo, PRD_Codigo, DCOT_Precio, " & _
                            "DCOT_Cant, DCOT_Activo) " & _
                            "VALUES('" & IDCotiz & "', '" & .Item(6, i).Value & "', '" & _
                            objFunciones.convertMoneda(CDbl(.Item(3, i).Value)) & "', '" & _
                            .Item(4, i).Value & "', '" & 1 & "')"

                            objFunciones.Ejecutar(SQLInsertDetalle)
                        Next

                        If numRegistrados = CInt(lblNumCotiz.Text) Then
                            If objFunciones.Ejecutar("UPDATE tb_requerimientos SET REQ_Estado='1' " & _
                                                     "WHERE REQ_Codigo='" & lblIDReq.Text & "'") Then

                                MsgBox("La cotización " & numRegistrados & " de " & lblNumCotiz.Text & vbNewLine & vbNewLine & _
                                       "Ha sido registrada con exito en el sistema.", vbInformation, "Exito")

                                lblNumCotMarcadas.Text = numRegistrados & " DE " & lblNumCotiz.Text
                                Me.Close()

                                modProcedimientos.listarRequerimientos(SQLRequerientos, MDIPrincipal.dgvRequerimientos)
                                modProcedimientos.listarCotizaciones(SQLCotizaciones, MDIPrincipal.dgvCotizados)
                            End If
                        Else
                            MsgBox("La cotización " & numRegistrados & " de " & lblNumCotiz.Text & vbNewLine & vbNewLine & _
                                   "Ha sido registrada con exito en el sistema.", vbInformation, "Exito")

                            txtCliente.Enabled = False
                            txtDescripcion.BackColor = Color.FromArgb(31, 31, 31)
                            txtDescripcion.ForeColor = Color.White
                            txtFormaPago.Text = "" : txtGarantia.Text = "" : txtObservacion.Text = ""
                            .Rows.Clear()
                            lblSubTotal.Text = "0.00" : lblTotal.Text = "0.00"

                            lblNumCotMarcadas.Text = numRegistrados + 1 & " DE " & lblNumCotiz.Text
                        End If
                    End If
                Else
                    MsgBox("No se pudo guardar la cotización " & IDCotiz & vbNewLine & vbNewLine & _
                           "Necesita registrar el detalle de la cotización antes de poderla guardar. " & _
                           "Por favor ingrese todos los datos y vuelva a intentarlo.", vbCritical, "Verifique")
                End If
            ElseIf cmdGuardar.Text = "Modificar proforma " And MDIPrincipal.mnuModificarCotizaciones.Enabled Then
                NOMB_VENTANA_ACTIVA = "Modificar proforma "
                IDCotiz = lblIDCotiz.Text

                SQLUpdate =
                "UPDATE tb_cotizaciones SET " & _
                "CLI_Codigo='" & lblIDCliente.Text & "', " & _
                "COT_Garantia='" & txtGarantia.Text & "', " & _
                "COT_Dias='" & cboDiasEntrega.Text & "', " & _
                "COT_Valides='" & cboDiasValidos.Text & "', " & _
                "COT_PORMAT='" & txtMateriales.Text & "', " & _
                "COT_IGV='" & IGV & "', " & _
                "COT_CONINST='" & chkIncINS.Checked & "', " & _
                "COT_CONIGV='" & chkIncIGV.Checked & "', " & _
                "COT_VERPREC='" & chkMostrarPrecios.Checked & "', " & _
                "COT_Moneda='" & Mid(lblMoneda.Text, 1, 1) & "', " & _
                "COT_FormaPago='" & txtFormaPago.Text & "', " & _
                "COT_Descripcion='" & txtDescripcion.Text & "', " & _
                "COT_Observacion='" & txtObservacion.Text & "', " & _
                "COT_Importe='" & objFunciones.convertMoneda(CDbl(lblSubTotal.Text)) & "' " & _
                "WHERE COT_Codigo='" & IDCotiz & "'"

                If objFunciones.Ejecutar(SQLUpdate) Then
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dim ID_Det_Cot As String = .Item(0, i).Value

                            If String.IsNullOrEmpty(ID_Det_Cot) Then
                                sqlUpdateDetalle =
                                "INSERT INTO tb_detalle_cotizaciones(COT_Codigo, PRD_Codigo, DCOT_Precio, " & _
                                "DCOT_Cant, DCOT_Activo) " & _
                                "VALUES('" & IDCotiz & "', '" & .Item(6, i).Value & "', '" & _
                                objFunciones.convertMoneda(CDbl(.Item(3, i).Value)) & "', '" & _
                                .Item(4, i).Value & "', '" & 1 & "')"
                            Else
                                sqlUpdateDetalle =
                                "UPDATE tb_detalle_cotizaciones SET " & _
                                "PRD_Codigo='" & .Item(6, i).Value & "', " & _
                                "DCOT_Precio='" & objFunciones.convertMoneda(CDbl(.Item(3, i).Value)) & "', " & _
                                "DCOT_Cant='" & .Item(4, i).Value & "' " & _
                                "WHERE DCOT_Codigo='" & .Item(0, i).Value & "'"
                            End If

                            objFunciones.Ejecutar(sqlUpdateDetalle)
                        Next
                    End If
                    MsgBox("En hora buena." & vbNewLine & vbNewLine & _
                           "Los datos de la cotización se modificarón con exito.", vbInformation, "Correcto")

                    'listar detalle de la cotizacion
                    '--------------------------------
                    Dim SQLDetalle As String =
                    "SELECT Dc.DCOT_Codigo, P.PRD_Codigo, P.PRD_Nombre, Dc.DCOT_Precio, Dc.DCOT_Cant, " & _
                    "(Dc.DCOT_Precio * Dc.DCOT_Cant) AS Importe " & _
                    "FROM tb_detalle_cotizaciones Dc, tb_productos P " & _
                    "WHERE DC.PRD_Codigo=P.PRD_Codigo AND " & _
                    "Dc.COT_Codigo='" & IDCotiz & "' AND " & _
                    "Dc.DCOT_Activo='1'"

                    modProcedimientos.listar_Detalle_Cotizacion(SQLDetalle, dgvDetalleCotizacion)

                    Dim SQLListaCotizaciones As String =
                    "SELECT Co.COT_Codigo, Co.COT_Fecha, Co.COT_Descripcion, Co.COT_Moneda, Co.COT_Importe, " & _
                    "(Co.COT_Importe * (CAST(Co.COT_IGV AS FLOAT) / 100)) AS ImporteIGV, " & _
                    "Co.COT_CONIGV, Co.COT_CONINST, U.USU_Nombres, Co.COT_estado " & _
                    "FROM tb_cotizaciones Co, tb_usuarios U " & _
                    "WHERE Co.USU_Codigo=U.USU_Codigo"

                    'MARCAR_FILA = FrmListaCotizaciones.dgvCotizaciones.CurrentRow.Index
                    modProcedimientos.listarTodasCotizaciones(SQLListaCotizaciones, FrmListaCotizaciones.dgvCotizaciones)
                    FrmListaCotizaciones.dgvCotizaciones.Rows(MARCAR_FILA).Selected = True

                    Me.Close()
                End If
            Else
                If cmdGuardar.Text = "Guardar proforma " Then
                    MsgBox("Error: No puedes registrar la cotización: " & vbNewLine & vbNewLine & _
                           "No cuentas con los permisos necesarios para poder registrar esta cotización", vbCritical, "Aviso")
                ElseIf cmdGuardar.Text = "Modificar proforma " Then
                    MsgBox("Error: No puedes modificar la cotización" & vbNewLine & vbNewLine & _
                           "No cuentas con los permisos necesarios para poder modicar esta cotización", vbCritical, "Aviso")
                End If
            End If
        End With
    End Sub

    Private Sub tbNumCotizaciones_Scroll(sender As Object, e As EventArgs) Handles tbNumCotizaciones.Scroll
        lblNumCotMarcadas.Text = "1 DE " & tbNumCotizaciones.Value
        lblNumCotiz.Text = tbNumCotizaciones.Value
    End Sub


    Private Sub FrmProforma_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If NOMB_VENTANA_ACTIVA = "Guardar proforma " Then
            If numRegistrados < CInt(lblNumCotiz.Text) Then
                If (MsgBox("Lea atentamente : " & vbNewLine & vbNewLine & _
                          "El sistema ha detectado que aún tiene ( " & _
                           CInt(lblNumCotiz.Text) - numRegistrados & " ) cotizacion pendiente de registrar. " & _
                          "De cerrar la ventana, se perderá toda información no registrada." & vbNewLine & vbNewLine & _
                          "Desea cerrar esta ventana de todas maneras ?", _
                          vbExclamation + vbYesNo + vbDefaultButton2, "Ciudado")) = vbYes Then

                    Me.Hide()
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    
End Class