Imports System.Data.SqlClient

Public Class FrmListaFacturas
    Dim SQLFacturas As String
    Dim SQLEstadoFactura As String

    Dim codCliente As String = ""

    Private Sub FrmListaFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim column As DataGridViewColumn
        With dgvListarFacturas
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.CellBorderStyle = DataGridViewCellBorderStyle.None

            For Each column In .Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With

        With dgvListaClientes
            '.Height = 84
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With

        With cboAnio
            Dim anioInicio As Integer = 2013
            Dim anioActual As Integer = Format(Now, "yyyy")

            cboAnio.Items.Clear()

            For c = anioActual To anioInicio Step -1
                cboAnio.Items.Add(c)
            Next
        End With

        cboAnio.Text = Format(Now, "yyyy")
        modProcedimientos.listarFacturas(dgvListarFacturas, Format(Now, "yyyy"))
    End Sub

    Private Sub dgvListarFacturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListarFacturas.CellDoubleClick
        Dim sqlDatosFactura, sqlDetalleFactura As String
        Dim fila, numReg As Integer
        Dim IDFactura As String

        Dim Moned As String
        Dim strMoneda As String = ""
        Dim Simb As String = ""
        Dim Activo As Boolean ': Dim strActivo As String

        NOMB_VENTANA_ACTIVA = "Listar Factura"

        Try
            'CARGAR DETALLE DE CAJA A CERRAR
            '--------------------------------
            If Not IsNothing(dgvListarFacturas.CurrentRow) And e.RowIndex >= 0 Then
                fila = CInt(dgvListarFacturas.CurrentRow.Index)
                IDFactura = Replace(dgvListarFacturas.Item(0, fila).Value, "-", "")

                If IDFactura <> "" Then
                    sqlDatosFactura =
                    "SELECT F.FAC_Codigo, F.FAC_Talonario, F.FAC_Nro, F.FAC_GR, FAC_GRT, F.CLI_Codigo, F.FAC_Moneda, " & _
                    "C.CLI_RazonSocial, C.CLI_DireccionLegal, C.CLI_RUC, F.FAC_TIPO, F.FAC_Dias, F.FAC_Fecha, " & _
                    "F.FAC_IGV, F.FAC_Subtotal, F.FAC_valIGV, F.FAC_Total, F.FAC_Observacion, F.FAC_Activo " & _
                    "FROM tb_facturas F, tb_clientes C " & _
                    "WHERE F.CLI_Codigo = C.CLI_Codigo AND " & _
                    "F.FAC_Codigo='" & IDFactura & "'"

                    sqlDetalleFactura = "SELECT DFAC_Codigo, FAC_Codigo, PRD_Codigo, DFAC_Descripcion, " & _
                    "DFAC_Cantidad, DFAC_Precio, DFAC_Dscto " & _
                    "FROM tb_detalle_facturas " & _
                    "WHERE FAC_Codigo='" & IDFactura & "' AND " & _
                    "DFAC_Activo='" & 1 & "'"

                    dtaux = New Data.DataTable
                    sqlda = New SqlDataAdapter(sqlDatosFactura, cnn)
                    sqlda.Fill(dtaux)

                    numReg = dtaux.Rows.Count

                    'If NOMB_VENTANA_ACTIVA = "Registrar Clientes" Then
                    'If objFunciones.estaVentanaAbierta(FrmRegistroClientes) Then

                    With FrmRegistroFactura
                        .lblIDCliente.Text = ""
                        .txtCliente.Text = ""
                        .lblDireccion.Text = ""
                        .lblRuc.Text = ""
                        .txtTalonario.Text = Mid(IDFactura, 1, 4)
                        .txtNroFactura.Text = Mid(IDFactura, 5, 6)
                        .lblMoneda.Text = ""
                        .txtS_GR.Text = ""
                        .txtGR.Text = ""
                        .txtS_GRT.Text = ""
                        .txtGRT.Text = ""
                        .txtObservacion.Text = ""
                        .lblSub.Text = "0.00"
                        .lblMontoIGV.Text = "0.00"
                        .lblTot.Text = "0.00"
                        .lblMontoTexto.Text = ""

                        .dgvDetalle.Rows.Clear()

                        If numReg > 0 Then
                            If NOMB_VENTANA_ACTIVA = "Listar Factura" Then
                                .lblIDCliente.Text = CStr(dtaux.Rows(0).Item("CLI_Codigo").ToString)
                                .txtCliente.Text = CStr(dtaux.Rows(0).Item("CLI_RazonSocial").ToString)
                                .lblDireccion.Text = CStr(dtaux.Rows(0).Item("CLI_DireccionLegal").ToString)
                                .lblRuc.Text = CStr(dtaux.Rows(0).Item("CLI_RUC").ToString)
                                .txtTalonario.Text = CStr(dtaux.Rows(0).Item("FAC_Talonario").ToString)
                                .txtNroFactura.Text = CStr(dtaux.Rows(0).Item("FAC_Nro").ToString)
                                .lblMoneda.Text = CStr(dtaux.Rows(0).Item("FAC_Moneda").ToString)
                                .txtS_GR.Text = CStr(Mid(dtaux.Rows(0).Item("FAC_GR"), 1, 4)).ToString
                                .txtGR.Text = Mid(CStr(dtaux.Rows(0).Item("FAC_GR").ToString), 5, 6)
                                .txtS_GRT.Text = Mid(CStr(dtaux.Rows(0).Item("FAC_GRT").ToString), 1, 4)
                                .txtGRT.Text = Mid(CStr(dtaux.Rows(0).Item("FAC_GRT").ToString), 5, 6)
                                .txtObservacion.Text = CStr(dtaux.Rows(0).Item("FAC_Observacion").ToString)
                                .lblSub.Text = Format(dtaux.Rows(0).Item("FAC_Subtotal"), "#,##0.00")
                                .lblMontoIGV.Text = Format(dtaux.Rows(0).Item("FAC_valIGV"), "#,##0.00")
                                .lblTot.Text = Format(dtaux.Rows(0).Item("FAC_Total"), "#,##0.00")

                                Activo = CBool(dtaux.Rows(0).Item("FAC_Activo").ToString)

                                If Activo Then
                                    .lblEstado.ForeColor = Color.Green
                                    .lblEstado.Text = "ACTIVA"
                                Else
                                    .lblEstado.ForeColor = Color.Red
                                    .lblEstado.Text = "ANULADA"
                                End If

                                Moned = CStr(dtaux.Rows(0).Item("FAC_Moneda").ToString)

                                If Moned = "S" Then
                                    strMoneda = "Soles"
                                    Simb = "S/"
                                ElseIf Moned = "D" Then
                                    strMoneda = "Dolares"
                                    Simb = "$"
                                End If

                                .Text = "Se facturó en " & strMoneda 'TITULO DE LA VENTANA

                                .lblSubtotal.Text = "Subtotal " & Simb
                                .lblTotal.Text = "Total " & Simb

                                .lblDia.Text = Format(dtaux.Rows(0).Item("FAC_Fecha"), "dd")
                                .lblMes.Text = UCase(Format(dtaux.Rows(0).Item("FAC_Fecha"), "MMMM"))
                                .lblAnio.Text = Format(dtaux.Rows(0).Item("FAC_Fecha"), "yy")

                                .lblIGV.Text = "I.G.V. " & CInt(dtaux.Rows(0).Item("FAC_IGV")) & "%"
                                .cmdRegistrar.Text = "Modificar"
                                .cmdNuevo.Visible = False

                                .dgvListaClientes.Visible = False
                            End If
                            modProcedimientos.listarDetalleFactura(sqlDetalleFactura, .dgvDetalle)
                        End If

                        If dgvListarFacturas.Item(6, e.RowIndex).Value = "ACTIVA" Then
                            .lblEstado.ForeColor = Color.Green
                            .lblEstado.Text = "ACTIVA"
                        ElseIf dgvListarFacturas.Item(6, e.RowIndex).Value = "ANULADA" Then
                            .lblEstado.ForeColor = Color.Red
                            .lblEstado.Text = "ANULADA"
                        End If

                        .cmdRegistrar.Text = "Modificar"
                        .ShowDialog()
                    End With
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub dgvListarFacturas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListarFacturas.CellFormatting
        e.CellStyle.SelectionBackColor = dgvListarFacturas.Rows(e.RowIndex).DefaultCellStyle.BackColor

        If dgvListarFacturas.Item(7, e.RowIndex).Value <> "ACTIVA" And dgvListarFacturas.Item(7, e.RowIndex).Value <> "ANULADA" Then
            e.CellStyle.SelectionForeColor = dgvListarFacturas.Rows(e.RowIndex).DefaultCellStyle.ForeColor 'Color.Yellow
            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        Else
            e.CellStyle.SelectionForeColor = Color.Yellow
            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdAnular_Click(sender As Object, e As EventArgs) Handles cmdAnular.Click
        FrmAnularFactura.ShowDialog()
    End Sub

    Private Sub dgvListarFacturas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListarFacturas.CellEnter
        If MDIPrincipal.mnuAnulaFactura.Enabled Then
            If Not IsNothing(dgvListarFacturas.CurrentRow) Then
                With dgvListarFacturas
                    Dim fila As Integer = .CurrentRow.Index

                    If .Item(7, fila).Value = "ACTIVA" Then
                        cmdAnular.Enabled = True
                        'cmdAnular.Image = Image.FromFile(Application.StartupPath & "\Iconos\close.png")
                        'cmdAnular.Text = "Anular Factura"
                    ElseIf .Item(7, fila).Value = "ANULADA" And MDIPrincipal.mnuAnulaFactura.Enabled Then
                        cmdAnular.Enabled = False
                        'cmdAnular.Image = Image.FromFile(Application.StartupPath & "\Iconos\check.png")
                        'cmdAnular.Text = "Activar Factura"
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        modProcedimientos.listarFacturas(dgvListarFacturas, cboAnio.Text)
    End Sub

    Private Sub cmdEstadisticas_Click(sender As Object, e As EventArgs) Handles cmdEstadisticas.Click
        FrmEstadisticas.ShowDialog()
    End Sub

    Private Sub FrmListaFacturas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim anchoGrida As Integer = dgvListarFacturas.Width - 22

        With dgvListarFacturas
            .Columns(0).Width = (anchoGrida * 7) / 100
            .Columns(1).Width = (anchoGrida * 7) / 100
            .Columns(2).Width = (anchoGrida * 45) / 100
            .Columns(3).Width = (anchoGrida * 5) / 100
            .Columns(4).Width = (anchoGrida * 10) / 100
            .Columns(5).Width = (anchoGrida * 10) / 100
            .Columns(6).Width = (anchoGrida * 10) / 100
            .Columns(7).Width = (anchoGrida * 6) / 100
        End With

        With dgvListaClientes
            .Top = (panelContenedor.Top) - 68
        End With
    End Sub

    Private Sub txtFiltro_Click(sender As Object, e As EventArgs) Handles txtFiltro.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtFiltro)
    End Sub

    Private Sub txtFiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltro.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtFiltro, e)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            modProcedimientos.listarClientesFactura(dgvListaClientes, txtFiltro.Text)
        Else
            dgvListaClientes.Visible = False
        End If
    End Sub

    Private Sub dgvListaClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaClientes.CellDoubleClick
        Dim fila_Selec As Integer = e.RowIndex 'dgvListaClientes.CurrentRow.Index

        codCliente = dgvListaClientes.Item(0, fila_Selec).Value
        txtFiltro.Text = dgvListaClientes.Item(1, fila_Selec).Value
        modProcedimientos.filtrarFacturas(codCliente, dgvListarFacturas, cboAnio.Text)

        dgvListaClientes.Visible = False
    End Sub
End Class