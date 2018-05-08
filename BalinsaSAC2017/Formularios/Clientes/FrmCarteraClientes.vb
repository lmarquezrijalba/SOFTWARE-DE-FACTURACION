Imports System.Data.SqlClient

Public Class FrmCarteraClientes
    Dim Criterios As Integer

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmCarteraClientes_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If NOMB_VENTANA_ACTIVA = "Cartera de Clientes" Then
            cmdSeleccionar.Visible = False
        ElseIf NOMB_VENTANA_ACTIVA = "Registrar Clientes" Then
            cmdSeleccionar.Visible = True
        End If
    End Sub

    Private Sub FrmCarteraClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmCarteraClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next

        Criterios = 0

        With dgvClientes
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.CellBorderStyle = DataGridViewCellBorderStyle.None

            'For Each column In .Columns
            'column.SortMode = DataGridViewColumnSortMode.NotSortable
            'Next
        End With

        modProcedimientos.filtrar_Clientes(dgvClientes, Criterios, lblNumRegistros, txtFiltro.Text,
                                           chkBalanzas.Checked, chkCamaras.Checked)

        txtFiltro.Focus()
    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick
        Dim sqlDatosCliente, sqlCont_x_Cliente As String
        Dim fila As Integer '= CInt(dgvClientes.CurrentRow.Index)
        Dim IDCliente As String '= dgvClientes.Item(0, fila).Value

        'CARGAR DETALLE DE CAJA A CERRAR
        '--------------------------------
        If Not IsNothing(dgvClientes.CurrentRow) And e.RowIndex >= 0 Then
            fila = CInt(dgvClientes.CurrentRow.Index)
            IDCliente = dgvClientes.Item(0, fila).Value

            sqlDatosCliente = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                              "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Direccion1, C.CLI_Direccion2, " & _
                              "C.CLI_Observacion, C.CLI_Tipo " & _
                              "FROM tb_clientes C, tb_usuarios U " & _
                              "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                              "C.CLI_Codigo='" & IDCliente & "'"

            sqlCont_x_Cliente = "SELECT * FROM tb_contato_x_clientes " & _
                                "WHERE CLI_Codigo='" & IDCliente & "'"

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlDatosCliente, cnn)
            sqlda.Fill(dt)

            If NOMB_VENTANA_ACTIVA = "Registrar Clientes" Then
                If objFunciones.estaVentanaAbierta(FrmRegistroClientes) Then
                    With FrmRegistroClientes
                        .lblMantenimiento.Text = "Editar"

                        .cmdNuevo.Enabled = False
                        .cmdRegistrar.Enabled = True
                        .cmdCancelar.Enabled = True
                        .cmdEliminar.Enabled = True
                        '.cmdListarClientes.Enabled = False
                        .lblAgregar.Enabled = True
                        .lblQuitar.Enabled = True

                        '.lblCodigo.Text = codGenerado
                        .txtRS.Enabled = True
                        .txtRUC.Enabled = True
                        .cboCiudad.Enabled = True
                        .txtDirLegal.Enabled = True
                        .txtDirec1.Enabled = True
                        .txtDirec2.Enabled = True

                        .txtObservaciones.Enabled = True

                        .lblCodigo.Text = CStr(dt.Rows(0).Item("CLI_Codigo"))
                        .lblTipoCliente.Text = CStr(dt.Rows(0).Item("CLI_Tipo"))
                        .txtRS.Text = CStr(dt.Rows(0).Item("CLI_RazonSocial"))
                        .txtRUC.Text = CStr(dt.Rows(0).Item("CLI_RUC"))
                        .txtDirLegal.Text = CStr(dt.Rows(0).Item("CLI_DireccionLegal"))
                        .txtDirec1.Text = CStr(dt.Rows(0).Item("CLI_Direccion1").ToString)
                        .txtDirec2.Text = CStr(dt.Rows(0).Item("CLI_Direccion2").ToString)
                        .txtObservaciones.Text = CStr(dt.Rows(0).Item("CLI_Observacion"))
                        .cboCiudad.Text = CStr(dt.Rows(0).Item("CLI_Ciudad"))

                        modProcedimientos.listarContact_x_Cliente(.dgvContactos, sqlCont_x_Cliente)
                    End With

                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txtFiltro_Click(sender As Object, e As EventArgs) Handles txtFiltro.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtFiltro)
    End Sub

    Private Sub txtFiltro_GotFocus(sender As Object, e As EventArgs) Handles txtFiltro.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtFiltro)
    End Sub

    Private Sub txtFiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltro.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtFiltro, e)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        modProcedimientos.filtrar_Clientes(dgvClientes, Criterios, lblNumRegistros, txtFiltro.Text,
                                           chkBalanzas.Checked, chkCamaras.Checked)
    End Sub

    Private Sub optCliente_CheckedChanged(sender As Object, e As EventArgs) Handles optCliente.CheckedChanged
        Criterios = 0
        txtFiltro.Focus()
    End Sub

    Private Sub optCiudad_CheckedChanged(sender As Object, e As EventArgs) Handles optCiudad.CheckedChanged
        Criterios = 1
        txtFiltro.Focus()
    End Sub

    Private Sub optEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles optEmpleado.CheckedChanged
        Criterios = 2
        txtFiltro.Focus()
    End Sub

    Private Sub dgvClientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvClientes.CellFormatting
        With dgvClientes
            e.CellStyle.SelectionBackColor = .Rows(e.RowIndex).DefaultCellStyle.BackColor

            If .Item(7, e.RowIndex).Value > 0 Then
                e.CellStyle.SelectionForeColor = Color.Green 'FromArgb(147, 187, 73) '.Rows(e.RowIndex).DefaultCellStyle.ForeColor 'Color.Yellow
                e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
            Else
                e.CellStyle.SelectionForeColor = Color.Blue
                e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
            End If
        End With
    End Sub

    Private Sub cmdSeleccionar_Click(sender As Object, e As EventArgs) Handles cmdSeleccionar.Click
        Dim sqlDatosCliente, sqlCont_x_Cliente As String
        Dim fila As Integer = CInt(dgvClientes.CurrentRow.Index)
        Dim IDCliente As String = dgvClientes.Item(0, fila).Value

        'CARGAR DETALLE DE CAJA A CERRAR
        '--------------------------------
        If Not IsNothing(dgvClientes.CurrentRow) Then
            sqlDatosCliente = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                              "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo " & _
                              "FROM tb_clientes C, tb_usuarios U " & _
                              "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                              "C.CLI_Codigo='" & IDCliente & "'"

            sqlCont_x_Cliente = "SELECT * FROM tb_contato_x_clientes " & _
                                "WHERE CLI_Codigo='" & IDCliente & "'"

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlDatosCliente, cnn)
            sqlda.Fill(dt)

            If NOMB_VENTANA_ACTIVA = "Registrar Clientes" Then
                With FrmRegistroClientes
                    .lblMantenimiento.Text = "Editar"

                    .cmdNuevo.Enabled = False
                    .cmdRegistrar.Enabled = True
                    .cmdCancelar.Enabled = True
                    .cmdEliminar.Enabled = True
                    '.cmdListarClientes.Enabled = False

                    '.lblCodigo.Text = codGenerado
                    .txtRS.Enabled = True
                    .txtRUC.Enabled = True
                    .cboCiudad.Enabled = True
                    .txtDirLegal.Enabled = True
                    .txtDirec1.Enabled = True
                    .txtDirec2.Enabled = True

                    .txtObservaciones.Enabled = True

                    .lblCodigo.Text = dt.Rows(0).Item("CLI_Codigo")
                    .lblTipoCliente.Text = dt.Rows(0).Item("CLI_Tipo")
                    .txtRS.Text = dt.Rows(0).Item("CLI_RazonSocial")
                    .txtRUC.Text = dt.Rows(0).Item("CLI_RUC")
                    .txtDirLegal.Text = dt.Rows(0).Item("CLI_DireccionLegal")
                    .txtObservaciones.Text = dt.Rows(0).Item("CLI_Observacion")
                    .cboCiudad.Text = dt.Rows(0).Item("CLI_Ciudad")

                    modProcedimientos.listarContact_x_Cliente(.dgvContactos, sqlCont_x_Cliente)
                End With
            End If
        End If

        Me.Close()
    End Sub

    Private Sub chkBalanzas_CheckedChanged(sender As Object, e As EventArgs) Handles chkBalanzas.CheckedChanged
        modProcedimientos.filtrar_Clientes(dgvClientes, Criterios, lblNumRegistros, txtFiltro.Text,
                                           chkBalanzas.Checked, chkCamaras.Checked)

        txtFiltro.Focus()
    End Sub

    Private Sub chkCamaras_CheckedChanged(sender As Object, e As EventArgs) Handles chkCamaras.CheckedChanged
        modProcedimientos.filtrar_Clientes(dgvClientes, Criterios, lblNumRegistros, txtFiltro.Text,
                                           chkBalanzas.Checked, chkCamaras.Checked)

        txtFiltro.Focus()
    End Sub

    
    Private Sub FrmCarteraClientes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim anchoGrida As Integer = dgvClientes.Width - 20

        With dgvClientes
            .Columns(1).Width = (anchoGrida * 5) / 100
            .Columns(2).Width = (anchoGrida * 8) / 100
            .Columns(3).Width = (anchoGrida * 35) / 100
            .Columns(4).Width = (anchoGrida * 27) / 100
            .Columns(5).Width = (anchoGrida * 10) / 100
            .Columns(6).Width = (anchoGrida * 10) / 100
            .Columns(7).Width = (anchoGrida * 5) / 100
        End With
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        modProcedimientos.filtrar_Clientes_Impresion(FrmPrint.dgvClientes, Criterios, lblNumRegistros, txtFiltro.Text,
                                          chkBalanzas.Checked, chkCamaras.Checked)
        FrmPrint.Show()
        Me.Enabled = False

        'razon social
        'nombres
        'cargo
        'telefono
        'correo

    End Sub
End Class