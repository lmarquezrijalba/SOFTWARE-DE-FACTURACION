Imports System.Data.SqlClient

Public Class FrmRegistroFactura
    Dim TIPO As Integer
    Dim fila, colum As Integer
    Dim sqlNuevo As String

    Dim numFilas As Integer

    Dim EJECUTAR As Boolean
    Dim EXEC As String

    Private Sub Habilitar(Estado As Boolean)
        If Estado Then
            txtCliente.Enabled = True
            txtObservacion.Enabled = True
            txtTalonario.Enabled = True
            txtNroFactura.Enabled = True
            txtS_GR.Enabled = True
            txtGR.Enabled = True
            txtS_GRT.Enabled = True
            txtGRT.Enabled = True

            lblMoneda.Enabled = True
            dtpFecha.Visible = True

            cboCajas.Enabled = True
            optContado.Enabled = True
            optCredito.Enabled = True

            dgvDetalle.Enabled = True

            cmdAgregar.Visible = True
            cmdQuitar.Visible = True
            cmdRegistrar.Visible = True
            'cmdIGV.Visible = True
        Else
            txtCliente.Enabled = False
            txtObservacion.Enabled = False
            txtTalonario.Enabled = False
            txtNroFactura.Enabled = False
            txtS_GR.Enabled = False
            txtGR.Enabled = False
            txtS_GRT.Enabled = False
            txtGRT.Enabled = False

            lblMoneda.Enabled = False
            dtpFecha.Visible = False

            cboCajas.Enabled = False
            optContado.Enabled = False
            optCredito.Enabled = False

            dgvDetalle.Enabled = False

            cmdAgregar.Visible = False
            cmdQuitar.Visible = False
            cmdRegistrar.Visible = False
            'cmdIGV.Visible = False
        End If
    End Sub

    Private Sub Limpiar()
        'cboCajas.SelectedIndex = 0
        optContado.Checked = True
        txtCliente.Text = ""
        lblDireccion.Text = ""
        lblRuc.Text = ""
        'txtTalonario.Text = ""
        txtNroFactura.Text = ""

        txtS_GR.Text = "" : txtGR.Text = ""
        txtS_GRT.Text = "" : txtGRT.Text = ""
        txtObservacion.Text = ""

        lblEstado.Text = ""

        dgvDetalle.Rows.Clear()
    End Sub

    Private Sub FrmRegistroFactura_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        txtCliente.Focus()

        If MDIPrincipal.mnuCorregirDatosFactura.Enabled = True Or cmdRegistrar.Text = "Registrar" Then
            Habilitar(True)
        Else
            Habilitar(False)
        End If

        '---------------------------------------------------------------
        Dim SQLCajas As String : Dim NumREG As Integer

        SQLCajas = "SELECT '0' AS CAJ_Codigo, 'Seleccione' AS CAJ_Nombre " & _
                   "UNION SELECT CAJ_Codigo, CAJ_Nombre FROM tb_cajas " & _
                   "WHERE CAJ_Aperturado='1'"

        NumREG = objFunciones.getnumeroRegs("SELECT FAC_Nro FROM tb_facturas")
        sqlNuevo = "SELECT MAX(FAC_Nro) FROM tb_facturas"

        If NOMB_VENTANA_ACTIVA = "Registrar Factura" Then
            'Call Limpiar()
            '.Visible = True

            panelCaja.Visible = False
            lblDesc.Visible = True
            lblEstado.Visible = False

            lblIGV.Text = "I.G.V. " & IGV_CONFIG & "%"
            Me.Text = "Venta a realizarse en " & MONEDA 'TITULO DE LA VENTANA

            lblSubtotal.Text = "Subtotal " & SIMBOLO_MONEDA
            lblTotal.Text = "Total " & SIMBOLO_MONEDA

            lblDia.Text = Format(Now, "dd")
            lblMes.Text = UCase(Format(Now, "MMMM"))
            lblAnio.Text = Format(Now, "yy")

            If NumREG > 0 Then
                txtNroFactura.Enabled = False
                txtNroFactura.Text = objFunciones.Generar_Codigo(sqlNuevo, "000000")
            End If
        ElseIf NOMB_VENTANA_ACTIVA = "Emitir Factura" Then
            'Call Limpiar()
            If MDIPrincipal.mnuModificarIGV.Enabled Then
                cmdIGV.Visible = False
            End If

            panelCaja.Visible = True
            lblDesc.Visible = False
            lblEstado.Visible = False

            lblIGV.Text = "I.G.V. " & IGV & "%"
            Me.Text = "Venta a realizarse en " & MONEDA 'TITULO DE LA VENTANA

            lblSubtotal.Text = "Subtotal " & SIMBOLO_MONEDA
            lblTotal.Text = "Total " & SIMBOLO_MONEDA

            lblDia.Text = Format(Now, "dd")
            lblMes.Text = UCase(Format(Now, "MMMM"))
            lblAnio.Text = Format(Now, "yy")

            If NumREG > 0 Then
                txtNroFactura.Enabled = False
                txtNroFactura.Text = objFunciones.Generar_Codigo(sqlNuevo, "000000")
            End If

            modProcedimientos.llenarCajasActivas(cboCajas, SQLCajas)
            cboCajas.SelectedIndex = 0
        ElseIf NOMB_VENTANA_ACTIVA = "Listar Factura" Then

            If MDIPrincipal.mnuModificarIGV.Enabled Then
                cmdIGV.Visible = True
            End If

            'lblIGV.Text = "I.G.V. " & IGV & "%"
            panelCaja.Visible = False
            lblDesc.Visible = False
            lblEstado.Visible = True
        End If

        Hab_Agre_quitar()
    End Sub

    Private Sub FrmRegistroFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvListaClientes
            .Height = 84
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With

        If NOMB_VENTANA_ACTIVA <> "Listar Factura" Then
            Call Limpiar()
        ElseIf NOMB_VENTANA_ACTIVA = "Registrar Factura" Then
            Call Limpiar()
        End If
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        If NOMB_VENTANA_ACTIVA = "Registrar Factura" Or NOMB_VENTANA_ACTIVA = "Listar Factura" Or NOMB_VENTANA_ACTIVA = "Emitir Factura" Then
            With dgvDetalle
                .Rows.Add()

                numFilas = .RowCount
                dgvDetalle.CurrentCell = dgvDetalle.Rows(numFilas - 1).Cells(0)
                dgvDetalle.CurrentCell.Selected = False
            End With
            'ElseIf NOMB_VENTANA_ACTIVA = "Emitir Factura" Or NOMB_VENTANA_ACTIVA = "Listar Factura" Then
            'NOMB_VENTANA_ACTIVA = "Registrar Factura"
            'FrmListaProductos.ShowDialog()
        End If

        Hab_Agre_quitar()
    End Sub

    'Private Sub Calcular(ByVal fila As Integer)
    '    Try
    'Dim subtotal, importe As Double
    'Dim porcentIGV As Double = Val(IGV / 100)

    'Dim cant As Integer = Val(dgvDetalle.Item(0, fila).Value)
    'Dim prec As Double = Format(CDbl(dgvDetalle.Item(2, fila).Value), "#,##0.00")

    '        dgvDetalle.Item(2, fila).Value = prec
    '        dgvDetalle.Item(3, fila).Value = cant * prec

    '        For i = 0 To dgvDetalle.RowCount - 1
    '            subtotal += dgvDetalle.Item(3, i).Value
    '        Next

    '        lblSub.Text = Format(subtotal, "#,##0.00")
    '        importe = Math.Round(Val(subtotal * porcentIGV), 2)
    '        lblMontoIGV.Text = Format(importe, "#,##0.00")
    '        lblTot.Text = Format(Math.Round(subtotal + importe, 2), "#,##0.00")
    '    Catch ex As Exception
    ''modProcedimientos.MostrarError(ex.HResult, ex.Message, "(" & Me.Name & ", " & objFunciones.getNombreProcedimiento & ")")
    '    End Try
    'End Sub

    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        Try
            With dgvDetalle
                Dim prec, importe As Double
                Dim cant As Integer
                Dim suma As Double = 0
                Dim fila As Integer ' DataGridViewRow = CType(.Rows(e.RowIndex), DataGridViewRow)
                Dim porcentIGV As Double = 0


                If NOMB_VENTANA_ACTIVA = "Emitir Factura" Then
                    porcentIGV = Val(IGV / 100)
                Else
                    porcentIGV = Val(IGV_CONFIG / 100)
                End If

                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

                If e.RowIndex >= 0 Then
                    fila = e.RowIndex
                    txtDesc.Height = .Rows(fila).Height

                    prec = Format(CDbl(.Item(2, fila).Value), "#,##0.00")
                    cant = CInt(Val(.Item(0, fila).Value))

                    .Item(3, fila).Value = Format(prec * cant, "#,##0.00")

                    For i = 0 To .RowCount - 1
                        suma = suma + CDbl(.Item(3, i).Value)
                    Next

                    lblSub.Text = Format(suma, "#,##0.00")
                    importe = Math.Round(Val(suma * porcentIGV), 2)
                    lblMontoIGV.Text = Format(importe, "#,##0.00")
                    lblTot.Text = Format(Math.Round(suma + importe, 2), "#,##0.00")
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = 46 Then
            'With dgvDetalle
            'If Not IsNothing(.CurrentRow) Then
            'If MsgBox("Realmente deseas quitar la fila seleccionada.", _
            '          vbQuestion + vbYesNo + vbDefaultButton2, "Quitar elemento") = vbYes Then
            '.Rows.Remove(.CurrentRow)

            'If Not IsNothing(.CurrentRow) Then
            'Calcular(.CurrentRow.Index)
            'Else
            'lblMontoTexto.Text = ""
            'lblSub.Text = "0.00"
            'lblMontoIGV.Text = "0.00"
            'lblTot.Text = "0.00"
            'End If
            'End If
            'End If
            'End With
        End If
    End Sub

    Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
        txtCant.Visible = False : txtDesc.Visible = False : txtPrecio.Visible = False

        With dgvDetalle
            If Not IsNothing(.CurrentRow) Then

                Dim fila As Integer = .CurrentRow.Index
                Dim SQLQuitar As String =
                    "UPDATE tb_detalle_facturas SET " & _
                    "DFAC_Activo='" & 0 & "' " & _
                    "WHERE DFAC_Codigo='" & dgvDetalle.Item(4, fila).Value & "'"

                Dim sqlDetalleFactura As String =
                    "SELECT DFAC_Codigo, FAC_Codigo, PRD_Codigo, DFAC_Descripcion, " & _
                    "DFAC_Cantidad, DFAC_Precio, DFAC_Dscto " & _
                    "FROM tb_detalle_facturas " & _
                    "WHERE FAC_Codigo='" & txtTalonario.Text & txtNroFactura.Text & "' AND " & _
                    "DFAC_Activo='" & 1 & "'"

                'If .CurrentRow.Index >= 0 Then
                'If fila < 0 Then
                If MsgBox("Realmente deseas quitar la fila seleccionada.", _
                          vbQuestion + vbYesNo + vbDefaultButton2, "Quitar elemento") = vbYes Then

                    If Not IsNumeric(.Item(4, .CurrentRow.Index).Value) Then
                        .Rows.Remove(.CurrentRow)
                        numFilas = .RowCount
                    Else
                        objFunciones.Ejecutar(SQLQuitar)
                        modProcedimientos.listarDetalleFactura(sqlDetalleFactura, dgvDetalle)
                    End If

                    txtCant.Visible = False : txtDesc.Visible = False : txtPrecio.Visible = False

                    If .Rows.Count = 0 Then
                        lblMontoTexto.Text = ""
                        lblSub.Text = "0.00"
                        lblMontoIGV.Text = "0.00"
                        lblTot.Text = "0.00"
                    End If
                End If
            End If

            Hab_Agre_quitar()
        End With
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs)
        If Len(txtTalonario.Text) < 4 Then
            MsgBox("Factura no registrada." & vbNewLine & vbNewLine & _
                   "Ingrese el numero de talonario perteneciente a la factura", _
                   vbInformation, "Error al imprimir")

            txtTalonario.BackColor = Color.FromArgb(255, 128, 128)
            txtTalonario.ForeColor = Color.White
            txtTalonario.Focus()
        ElseIf Len(txtNroFactura.Text) < 6 Then
            MsgBox("Factura no registrada." & vbNewLine & vbNewLine & _
                   "Ingrese el numero de la factura a ser registrada", _
                   vbInformation, "Error al imprimir")

            txtNroFactura.BackColor = Color.FromArgb(255, 128, 128)
            txtNroFactura.ForeColor = Color.White
            txtNroFactura.Focus()
        End If
    End Sub

    '   VALIDACIONES DE LA GRIDA
    '--------------------------------------
    Private Sub lblTot_TextChanged(sender As Object, e As EventArgs) Handles lblTot.TextChanged
        If CDbl(lblTot.Text) > 0 Then
            Dim TOTAL As Double = CDbl(lblTot.Text)

            If lblMoneda.Text = "S" Then
                lblMontoTexto.Text = "SON " & objFunciones.Letras(TOTAL) & " SOLES."
            ElseIf lblMoneda.Text = "D" Then
                lblMontoTexto.Text = "SON " & objFunciones.Letras(TOTAL) & " DOLARES."
            End If
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    '--CAMBIOS--
    '-------------
    Private Sub txtTalonario_LostFocus(sender As Object, e As EventArgs) Handles txtTalonario.LostFocus
        txtTalonario.Text = objFunciones.autocompletarNumero(txtTalonario.Text, 4, txtTalonario)
    End Sub

    Private Sub txtTalonario_Click(sender As Object, e As EventArgs) Handles txtTalonario.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtTalonario)
    End Sub

    Private Sub txtTalonario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTalonario.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtObservacion, e)
    End Sub

    Private Sub txtGR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGR.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtGR_LostFocus(sender As Object, e As EventArgs) Handles txtGR.LostFocus
        txtGR.Text = objFunciones.autocompletarNumero(txtGR.Text, 6, txtGR)
    End Sub

    Private Sub txtGRT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGRT.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtGRT_LostFocus(sender As Object, e As EventArgs) Handles txtGRT.LostFocus
        txtGRT.Text = objFunciones.autocompletarNumero(txtGRT.Text, 6, txtGRT)
    End Sub

    Private Sub txtNroFactura_LostFocus(sender As Object, e As EventArgs) Handles txtNroFactura.LostFocus
        txtNroFactura.Text = objFunciones.autocompletarNumero(txtNroFactura.Text, 6, txtNroFactura)
    End Sub

    Private Sub txtNroFactura_Click(sender As Object, e As EventArgs) Handles txtNroFactura.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtNroFactura)
    End Sub

    Private Sub txtNroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroFactura.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub optCredito_CheckedChanged(sender As Object, e As EventArgs) Handles optCredito.CheckedChanged
        TIPO = 1

        lblDias.Visible = True
        txtDias.Visible = True
        txtDias.Focus()
    End Sub

    Private Sub optContado_CheckedChanged(sender As Object, e As EventArgs) Handles optContado.CheckedChanged
        TIPO = 0

        lblDias.Visible = False
        txtDias.Text = 0
        txtDias.Visible = False
    End Sub

    Private Sub cmdAnularFactura_Click(sender As Object, e As EventArgs) Handles cmdAnularFactura.Click
        With FrmAnularFactura
            Dim fechaSelec As Date = lblDia.Text & "/" & lblMes.Text & "/" & lblAnio.Text
            .dtpFecha.Value = Format(fechaSelec, "dd/MM/yyyy")
            .ShowDialog()
        End With
    End Sub

    Private Sub txtCliente_Click(sender As Object, e As EventArgs) Handles txtCliente.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtCliente)
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.Text <> "" Then
            modProcedimientos.listarClientesFactura(dgvListaClientes, txtCliente.Text)
        Else
            dgvListaClientes.Visible = False
        End If
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Escape Then
            dgvListaClientes.Visible = False
        End If
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        modProcedimientos.Saltar(e)
        modProcedimientos.A_MAYUSCULAS(txtCliente, e)
    End Sub

    Private Sub dgvListaClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaClientes.CellDoubleClick
        Dim codCliente, sqlDatos As String
        Dim fila_cliente, numReg As Integer

        Try
            fila_cliente = e.RowIndex 'dgvListaClientes.CurrentRow.Index
            codCliente = dgvListaClientes.Item(0, fila_cliente).Value

            sqlDatos = "SELECT CLI_Codigo, CLI_RazonSocial, CLI_RUC, CLI_DireccionLegal " & _
                       "FROM tb_clientes " & _
                       "WHERE CLI_Codigo='" & codCliente & "'"

            dtaux = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlDatos, cnn)
            sqlda.Fill(dtaux)

            numReg = dtaux.Rows.Count

            '   MOSTRAMOS DATOS
            '--------------------
            If numReg > 0 Then
                lblIDCliente.Text = codCliente
                txtCliente.Text = dtaux.Rows(0).Item("CLI_RazonSocial").ToString
                lblDireccion.Text = dtaux.Rows(0).Item("CLI_DireccionLegal").ToString
                lblRuc.Text = dtaux.Rows(0).Item("CLI_RUC").ToString

                dgvListaClientes.Visible = False
                txtTalonario.Focus()
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim SQLInsert As String = ""
        Dim SQLInsertDetalle As String = ""
        Dim SQLVerificaFactura As String
        Dim SQLVerificaDetalle As String = ""
 
        Dim SQLDetalleFactura As String =
            "SELECT DFAC_Codigo, FAC_Codigo, PRD_Codigo, DFAC_Descripcion, " & _
            "DFAC_Cantidad, DFAC_Precio, DFAC_Dscto " & _
            "FROM tb_detalle_facturas " & _
            "WHERE FAC_Codigo='" & txtTalonario.Text & txtNroFactura.Text & "' AND " & _
            "DFAC_Activo='" & 1 & "'"


        If NOMB_VENTANA_ACTIVA = "Registrar Factura" Then
            If txtTalonario.Text = "" Then
                EJECUTAR = False

                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                "Ingrese el número de serie de la factura.", vbCritical, "Ingrese")

                txtTalonario.Focus()
            ElseIf txtNroFactura.Text = "" Then
                EJECUTAR = False

                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                "Ingrese el número de la factura a registrar.", vbCritical, "Ingrese")

                txtNroFactura.Focus()
            Else
                EJECUTAR = True
                EXEC = "Insert"

                SQLInsert =
                "INSERT INTO tb_facturas(FAC_Codigo, FAC_Talonario, FAC_Nro, FAC_GR, FAC_GRT, " & _
                "CLI_Codigo, USU_Codigo_Registro, FAC_Moneda, FAC_Fecha, FAC_Observacion, FAC_IGV, " & _
                "FAC_Subtotal, FAC_valIGV, FAC_Total, FAC_Activo) " & _
                "VALUES('" & txtTalonario.Text & txtNroFactura.Text & "', '" & _
                txtTalonario.Text & "', '" & txtNroFactura.Text & "', '" & _
                txtS_GR.Text & txtGR.Text & "', '" & txtS_GRT.Text & txtGRT.Text & "', '" & _
                lblIDCliente.Text & "', '" & USU_CODIGO & "', '" & Mid(MONEDA, 1, 1) & "', '" & _
                Format(dtpFecha.Value, "dd/MM/yyyy H:mm:ss") & "', '" & _
                txtObservacion.Text & "', '" & IGV_CONFIG & "', '" & _
                objFunciones.convertMoneda(CDbl(lblSub.Text)) & "', '" & _
                objFunciones.convertMoneda(CDbl(lblMontoIGV.Text)) & "', '" & _
                objFunciones.convertMoneda(CDbl(lblTot.Text)) & "', '" & 1 & "')"
            End If
        ElseIf NOMB_VENTANA_ACTIVA = "Emitir Factura" Then
            If cboCajas.SelectedIndex = 0 Then
                EJECUTAR = False

                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                "Seleccione la caja en la cual se registrará la venta.", vbCritical, "Seleccione caja")

                cboCajas.Focus()
            ElseIf txtTalonario.Text = "" Then
                EJECUTAR = False

                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                "Ingrese el número de serie de la factura.", vbCritical, "Ingrese")

                txtTalonario.Focus()
            ElseIf txtNroFactura.Text = "" Then
                EJECUTAR = False

                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                "Ingrese el número de la factura a registrar.", vbCritical, "Ingrese")

                txtNroFactura.Focus()
            ElseIf optCredito.Checked = True And (Len(txtDias.Text) = 0 Or txtDias.Text = "" Or txtDias.Text = "0") Then
                EJECUTAR = False

                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                "Ingrese el número de días de crédito a asignar.", vbCritical, "Ingrese")

                txtDias.Focus()
            Else
                EJECUTAR = True
                EXEC = "Insert"

                SQLInsert =
                "INSERT INTO tb_facturas(FAC_Talonario, FAC_Nro, FAC_GR, FAC_GRT, " & _
                "CLI_Codigo, USU_Codigo_Registro, FAC_Moneda, FAC_Observacion, " & _
                "FAC_Tipo, FAC_Dias, FAC_Fecha, FAC_IGV, FAC_Subtotal, FAC_valIGV, FAC_Total, FAC_Activo) " & _
                "VALUES('" & txtTalonario.Text & txtNroFactura.Text & "', '" & _
                txtTalonario.Text & "', '" & txtNroFactura.Text & "', '" & _
                txtS_GR.Text & "-" & txtGR.Text & "', '" & txtS_GRT.Text & "-" & txtGRT.Text & "', '" & _
                lblIDCliente.Text & "', '" & USU_CODIGO & "', '" & Mid(MONEDA, 1, 1) & "', '" & _
                txtObservacion.Text & "', '" & _
                TIPO & "', '" & txtDias.Text & "', '" & _
                Format(dtpFecha.Value, "dd/MM/yyyy H:mm:ss") & "', '" & IGV & "', '" & _
                objFunciones.convertMoneda(CDbl(lblSub.Text)) & "', '" & _
                objFunciones.convertMoneda(CDbl(lblMontoIGV.Text)) & "', '" & _
                objFunciones.convertMoneda(CDbl(lblTot.Text)) & "', '" & 1 & "')"
            End If
        ElseIf NOMB_VENTANA_ACTIVA = "Listar Factura" Then
            If MsgBox("Esta apunto de realizar cambios en la factura." & vbNewLine & vbNewLine & _
                      "De confirmar la acción de modificación de datos de la factura, " & _
                      "verifique los nuevos datos a registrar y asegurese que sean los correctos.",
                      vbYesNo + vbQuestion + vbDefaultButton2, "Confirmar") = vbYes Then

                EJECUTAR = True
                EXEC = "Update"

                SQLInsert =
                    "UPDATE tb_facturas SET " & _
                    "FAC_Talonario='" & txtTalonario.Text & "', " & _
                    "FAC_Nro='" & txtNroFactura.Text & "', " & _
                    "FAC_GR='" & txtS_GR.Text & txtGR.Text & "', " & _
                    "FAC_GRT='" & txtS_GRT.Text & txtS_GRT.Text & "', " & _
                    "CLI_Codigo='" & lblIDCliente.Text & "', " & _
                    "USU_Codigo_Edito='" & USU_CODIGO & "', " & _
                    "FAC_Moneda='" & lblMoneda.Text & "', " & _
                    "FAC_Observacion='" & txtObservacion.Text & "', " & _
                    "FAC_Fecha='" & Format(CDate(lblDia.Text & "/" & lblMes.Text & "/" & lblAnio.Text), "dd/MM/yyyy H:mm:ss") & "', " & _
                    "FAC_IGV='" & IGV_CONFIG & "', " & _
                    "FAC_Subtotal='" & objFunciones.convertMoneda(CDbl(lblSub.Text)) & "', " & _
                    "FAC_valIGV='" & objFunciones.convertMoneda(CDbl(lblMontoIGV.Text)) & "', " & _
                    "FAC_Total='" & objFunciones.convertMoneda(CDbl(lblTot.Text)) & "' " & _
                    "WHERE FAC_Codigo='" & txtTalonario.Text & txtNroFactura.Text & "'"
            End If
        End If

        Try
            If EJECUTAR Then
                If EXEC = "Insert" Then
                    If MsgBox("Confirme su acción " & vbNewLine & vbNewLine & _
                              "Realmente deseas registrar la factura emitida el día " & _
                              Format(dtpFecha.Value, "dd/MM/yyy") & " con Número de factura " & _
                              txtTalonario.Text & "-" & txtNroFactura.Text, _
                              vbYesNo + vbQuestion + vbDefaultButton2, "Confirme") = vbYes Then

                        SQLVerificaFactura =
                        "SELECT * FROM tb_facturas WHERE FAC_Talonario='" & txtTalonario.Text & _
                        "' AND FAC_Nro='" & txtNroFactura.Text & "'"

                        If objFunciones.verificarRegistro(SQLVerificaFactura) = False Then
                            If objFunciones.Ejecutar(SQLInsert) Then
                                With dgvDetalle
                                    For i = 0 To .RowCount - 1
                                        SQLVerificaDetalle =
                                        "SELECT * FROM tb_detalle_facturas WHERE DFAC_Codigo='" & .Item(4, i).Value & "'"

                                        If objFunciones.verificarRegistro(SQLVerificaDetalle) = False Then
                                            SQLInsertDetalle =
                                            "INSERT INTO tb_detalle_facturas(FAC_Codigo, DFAC_Descripcion, DFAC_Cantidad, DFAC_Precio) " & _
                                            "VALUES('" & txtTalonario.Text & txtNroFactura.Text & "', '" & .Item(1, i).Value & "', '" & _
                                            .Item(0, i).Value & "', '" & objFunciones.convertMoneda(CDbl(.Item(2, i).Value)) & "')"

                                            objFunciones.Ejecutar(SQLInsertDetalle)
                                        End If
                                    Next
                                End With

                                MsgBox("En hora buena." & vbNewLine & vbNewLine & _
                                "La factura N° " & txtTalonario.Text & "-" & txtNroFactura.Text & " se registró con exito.", vbInformation, "Hecho.")
                            End If
                        Else
                            MsgBox("No se pudo registrar." & vbNewLine & vbNewLine & _
                                "La factura N° " & txtTalonario.Text & "-" & txtNroFactura.Text & " ya se encuentra registrada.", vbCritical, "Verifique.")
                        End If
                    End If
                ElseIf EXEC = "Update" Then
                    If objFunciones.Ejecutar(SQLInsert) Then
                        With dgvDetalle
                            For i = 0 To .RowCount - 1
                                SQLVerificaDetalle =
                                "SELECT * FROM tb_detalle_facturas WHERE DFAC_Codigo='" & .Item(4, i).Value & "'"

                                If objFunciones.verificarRegistro(SQLVerificaDetalle) = False Then
                                    SQLInsertDetalle =
                                    "INSERT INTO tb_detalle_facturas(FAC_Codigo, DFAC_Descripcion, DFAC_Cantidad, DFAC_Precio) " & _
                                    "VALUES('" & txtTalonario.Text & txtNroFactura.Text & "', '" & CStr(.Item(1, i).Value.ToString) & "', '" & _
                                    CInt(.Item(0, i).Value) & "', '" & objFunciones.convertMoneda(CDbl(.Item(2, i).Value)) & "')"
                                Else
                                    SQLInsertDetalle =
                                    "UPDATE tb_detalle_facturas SET " & _
                                    "FAC_Codigo='" & txtTalonario.Text & txtNroFactura.Text & "', " & _
                                    "DFAC_Descripcion='" & .Item(1, i).Value & "', " & _
                                    "DFAC_Cantidad='" & CInt(.Item(0, i).Value) & "', " & _
                                    "DFAC_Precio='" & objFunciones.convertMoneda(CDbl(.Item(2, i).Value)) & "' " & _
                                    "WHERE DFAC_Codigo='" & .Item(4, i).Value & "'"
                                End If

                                objFunciones.Ejecutar(SQLInsertDetalle)
                            Next
                        End With
                    End If
                End If

                modProcedimientos.listarDetalleFactura(SQLDetalleFactura, dgvDetalle)
                modProcedimientos.listarFacturas(FrmListaFacturas.dgvListarFacturas, Format(CDate(lblDia.Text & "/" & lblMes.Text & "/" & lblAnio.Text), "yyyy"))

                txtCant.Visible = False : txtDesc.Visible = False : txtPrecio.Visible = False
                'End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub txtS_GR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtS_GR.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtS_GR_LostFocus(sender As Object, e As EventArgs) Handles txtS_GR.LostFocus
        txtS_GR.Text = objFunciones.autocompletarNumero(txtS_GR.Text, 4, txtS_GR)
    End Sub

    Private Sub txtS_GRT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtS_GRT.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtS_GRT_LostFocus(sender As Object, e As EventArgs) Handles txtS_GRT.LostFocus
        txtS_GRT.Text = objFunciones.autocompletarNumero(txtS_GRT.Text, 4, txtS_GRT)
    End Sub

    Private Sub cboCajas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCajas.SelectionChangeCommitted
        Dim IDCaja, sqlDatos As String
        Dim numReg As Integer

        Try
            'fila = e.RowIndex 'dgvListaClientes.CurrentRow.Index
            IDCaja = cboCajas.SelectedValue

            sqlDatos = "SELECT C.CAJ_Codigo, C.CAJ_Nombre, " & _
            "U.USU_ApePaterno + ' ' + U.USU_ApeMaterno + ', ' + U.USU_Nombres AS Encargado " & _
            "FROM tb_cajas C, tb_usuarios U " & _
            "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
            "C.CAJ_Codigo='" & IDCaja & "' AND " & _
            "C.CAJ_Aperturado = '1'"

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlDatos, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            '   MOSTRAMOS DATOS
            '--------------------
            If numReg > 0 Then
                lblNomRespCaja.Text = CStr(dt.Rows(0).Item("Encargado"))
            Else
                lblNomRespCaja.Text = ""
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub txtDias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDias.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtDias_TextChanged(sender As Object, e As EventArgs) Handles txtDias.TextChanged
        If Val(txtDias.Text) > 30 Then
            MsgBox("No pueden ser asignado los " & txtDias.Text & " días." & vbNewLine & vbNewLine & _
                   "El número máximo de días permitidos para el crédito son de 30 días, " & vbNewLine & _
                   "por favor ingrese un valor menor o igual a 30", vbInformation, "Corregir")

            txtDias.Text = ""
            txtDias.Focus()
        End If
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        Call Limpiar()

        If objFunciones.estaVentanaAbierta(FrmListaFacturas) Then
            Me.Close()
            FrmListaFacturas.Close()
            FrmMoneda.MdiParent = MDIPrincipal
            FrmMoneda.Show()
        Else
            Me.Close()
            FrmMoneda.MdiParent = MDIPrincipal
            FrmMoneda.Show()
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Dim Dia, Mes, Anio, hora As String

        Dia = Format(dtpFecha.Value, "dd")
        Mes = UCase(Format(dtpFecha.Value, "MMMM"))
        Anio = Format(dtpFecha.Value, "yy")

        hora = Format(Now, "H:mm:ss")

        lblDia.Text = Dia : lblMes.Text = Mes : lblAnio.Text = Anio
    End Sub

    Private Sub dgvDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellEnter
        Try
            With dgvDetalle
                fila = .CurrentCell.RowIndex
                colum = .CurrentCell.ColumnIndex

                Dim cellRectangle = .GetCellDisplayRectangle(colum, fila, True)
                Dim cellAlto As Integer = cellRectangle.Height - 1
                Dim CellAncho As Integer = cellRectangle.Width - 1
                Dim PosicionX As Integer = cellRectangle.X + dgvDetalle.Left
                Dim PosicionY As Integer = cellRectangle.Y + dgvDetalle.Top

                cmdQuitar.Enabled = True

                If colum = 0 Then
                    txtCant.AutoSize = False
                    txtCant.Size = New Size(CellAncho, cellAlto)
                    txtCant.Left = PosicionX
                    txtCant.Top = PosicionY
                    txtCant.Visible = True
                    txtCant.Text = .Item(colum, fila).Value
                    txtCant.Focus()
                    modProcedimientos.SELEC_TODO_TEXTO(txtCant)

                    txtDesc.Visible = False
                    txtPrecio.Visible = False

                    Exit Sub
                ElseIf colum = 1 Then
                    txtDesc.AutoSize = False
                    txtDesc.Size = New Size(CellAncho, cellAlto)
                    txtDesc.Left = PosicionX
                    txtDesc.Top = PosicionY
                    txtDesc.Visible = True
                    txtDesc.Text = dgvDetalle.Item(colum, fila).Value
                    txtDesc.Focus()
                    modProcedimientos.SELEC_TODO_TEXTO(txtDesc)

                    txtCant.Visible = False
                    txtPrecio.Visible = False

                    Exit Sub
                ElseIf colum = 2 Then
                    txtPrecio.AutoSize = False
                    txtPrecio.Size = New Size(CellAncho, cellAlto)
                    txtPrecio.Left = PosicionX
                    txtPrecio.Top = PosicionY
                    txtPrecio.Visible = True
                    txtPrecio.Text = .Item(colum, fila).Value
                    txtPrecio.Focus()
                    modProcedimientos.SELEC_TODO_TEXTO(txtPrecio)

                    txtCant.Visible = False
                    txtDesc.Visible = False

                    Exit Sub
                Else
                    txtCant.Visible = False
                    txtDesc.Visible = False
                    txtPrecio.Visible = False
                End If
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdListar_Click(sender As Object, e As EventArgs) Handles cmdListar.Click
        NOMB_VENTANA_ACTIVA = "Listar Factura"
        Me.Close()

        If Not objFunciones.estaVentanaAbierta(FrmListaFacturas) Then
            FrmListaFacturas.ShowDialog()
        End If
    End Sub

    Private Sub dgvDetalle_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetalle.CellFormatting
        If dgvDetalle.Rows.Count > 0 Then
            With dgvDetalle
                If Val(.Item(0, e.RowIndex).Value) = 0 Or
                   CStr(.Item(1, e.RowIndex).Value) = "" Or
                   Val(.Item(2, e.RowIndex).Value) = 0 Then
                    cmdAgregar.Enabled = False
                Else
                    cmdAgregar.Enabled = True
                End If
            End With
        End If
    End Sub

    Private Sub Hab_Agre_quitar()
        If numFilas = 0 Then
            cmdAgregar.Enabled = True
            cmdQuitar.Enabled = False

            txtCant.Visible = False
            txtDesc.Visible = False
            txtPrecio.Visible = False
        Else
            cmdQuitar.Enabled = True
        End If
    End Sub

    '============================================
    'TEXTOS
    '============================================
    Private Sub txtDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesc.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDesc, e)
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        dgvDetalle.Item(1, fila).Value = txtDesc.Text
    End Sub

    Private Sub txtDesc_LostFocus(sender As Object, e As EventArgs) Handles txtDesc.LostFocus
        'dgvDetalle.Item(1, fila).Value = txtDesc.Text
        txtDesc.Visible = False

        dgvDetalle.CurrentCell = dgvDetalle.Rows(fila).Cells(2)
        dgvDetalle.CurrentCell.Selected = False
    End Sub

    Private Sub txtCant_LostFocus(sender As Object, e As EventArgs) Handles txtCant.LostFocus
        'dgvDetalle.Item(0, fila).Value = txtCant.Text
        txtCant.Visible = False

        dgvDetalle.CurrentCell = dgvDetalle.Rows(fila).Cells(1)
        dgvDetalle.CurrentCell.Selected = False
    End Sub

    Private Sub txtCant_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCant.KeyDown
        If e.KeyCode = 13 Then
            dgvDetalle.Item(0, fila).Value = txtCant.Text
            txtCant.Visible = False

            dgvDetalle.CurrentCell = dgvDetalle.Rows(fila).Cells(1)
            dgvDetalle.CurrentCell.Selected = False
        End If
    End Sub

    Private Sub txtCant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = 13 Then
            dgvDetalle.Item(2, fila).Value = Format(CDbl(txtPrecio.Text), "#,##0.00")
            txtPrecio.Visible = False

            If fila < dgvDetalle.RowCount - 1 Then
                dgvDetalle.CurrentCell = dgvDetalle.Rows(fila + 1).Cells(0)
                dgvDetalle.CurrentCell.Selected = False
            Else
                cmdAgregar.Focus()
            End If
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtPrecio)
    End Sub

    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        'dgvDetalle.Item(2, fila).Value = txtPrecio.Text
        'txtPrecio.Visible = False

        'If fila < dgvDetalle.RowCount - 1 Then
        'dgvDetalle.CurrentCell = dgvDetalle.Rows(fila + 1).Cells(0)
        'dgvDetalle.CurrentCell.Selected = False
        'Else
        'cmdAgregar.Focus()
        'End If
    End Sub

    Private Sub lblMoneda_Click(sender As Object, e As EventArgs) Handles lblMoneda.Click
        Dim TOTAL As Double = CDbl(lblTot.Text)

        If lblMoneda.Text = "0" Then
            lblMoneda.Text = "S"

            lblSubtotal.Text = "Subtotal S/"
            lblTotal.Text = "Total S/"

            If CDbl(lblTot.Text) > 0 Then
                lblMontoTexto.Text = "SON " & objFunciones.Letras(TOTAL) & " SOLES."
            End If
        ElseIf lblMoneda.Text = "S" Then
            lblMoneda.Text = "D"

            lblSubtotal.Text = "Subtotal $"
            lblTotal.Text = "Total $"

            If CDbl(lblTot.Text) > 0 Then
                lblMontoTexto.Text = "SON " & objFunciones.Letras(TOTAL) & " DOLARES."
            End If
        ElseIf lblMoneda.Text = "D" Then
            lblMoneda.Text = "S"

            lblSubtotal.Text = "Subtotal S/"
            lblTotal.Text = "Total S/"

            If CDbl(lblTot.Text) > 0 Then
                lblMontoTexto.Text = "SON " & objFunciones.Letras(TOTAL) & " SOLES."
            End If
        End If
    End Sub

    Private Sub cmdIGV_Click(sender As Object, e As EventArgs) Handles cmdIGV.Click
        REG_IGV = "IGV Config"

        FrmIGV.ShowDialog()
        'With FrmIGV
        '.MdiParent = MDIPrincipal
        '.Show()
        'End With
    End Sub



End Class