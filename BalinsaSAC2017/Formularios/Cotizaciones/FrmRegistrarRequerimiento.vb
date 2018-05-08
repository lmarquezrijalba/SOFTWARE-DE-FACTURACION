Imports System.Data.SqlClient

Public Class FrmRegistrarRequerimiento
    Dim SQLGenerarID As String = "SELECT COUNT(REQ_Codigo) FROM tb_requerimientos"

    Dim SQLRequerimientos As String =
    "SELECT R.REQ_Codigo, R.REQ_tipo, R.REQ_Fecha, R.REQ_Descripcion, " & _
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

    Dim IDRequerimiento As String
    Dim EXISTE_CLIENT As Boolean

    Private Sub HABILIATAR(Estado As Boolean)
        If Estado = False Then
            txtCliente.Enabled = False
            txtDescripcion.Enabled = False
            txtObservacion.Enabled = False

            cmdNuevo.Enabled = True
            cmdRegistrar.Enabled = False
        Else
            txtCliente.Enabled = True
            txtDescripcion.Enabled = False
            txtObservacion.Enabled = True

            cmdNuevo.Enabled = False
            cmdRegistrar.Enabled = True
        End If
    End Sub

    Private Sub chkActivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivar.CheckedChanged
        If chkActivar.Checked Then
            Label7.Visible = True
            dtpFecha.Visible = True
        Else
            Label7.Visible = False
            dtpFecha.Visible = False
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        EXISTE_CLIENT = False

        HABILIATAR(True)
        cmdRegistrar.Text = "Registrar"
        lblFechaReq.Text = Format(Now, "dd/MM/yyyy")
        chkActivar.Checked = False
        lblIDReq.Text = Trim(objFunciones.Generar_Codigo(SQLGenerarID))
    End Sub

    Private Sub FrmRegistrarRequerimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIPrincipal.Cursor = Cursors.Default
        lblFechaReq.Text = Format(Now, "dd/MM/yyyy")
        'dgvListaClientes.Visible = False

        With dgvListaClientes
            .Height = 110
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim SQLInsertar, SQLModificar As String
        Dim TIPO_REQ As String = ""

        If opt_B.Checked Then
            TIPO_REQ = "B"
        ElseIf opt_C.Checked Then
            TIPO_REQ = "C"
        End If

        If cmdRegistrar.Text = "Registrar" Then
            If EXISTE_CLIENT = False Then
                MsgBox("El cliente " & txtCliente.Text & " no existe." & vbNewLine & vbNewLine & _
                       "El sistema abrirá el formulario de registro de clientes nuevos al sistema, " & _
                       "luego podrá registrar a dicho cliente y posteriormente seguir con el registro del requerimiento", vbInformation, "Aviso")

                With FrmRegistroClientes
                    .MdiParent = MDIPrincipal
                    .Show()

                    .txtRS.Enabled = True
                    .txtRS.Text = txtCliente.Text

                    txtCliente.Text = ""

                    .txtRUC.Enabled = True
                    .cboCiudad.Enabled = True
                    .txtDirLegal.Enabled = True
                    .txtDirec1.Enabled = True
                    .txtDirec2.Enabled = True
                    .txtObservaciones.Enabled = True

                    .cmdNuevo.Enabled = False
                    .cmdRegistrar.Enabled = True
                    .cmdCancelar.Enabled = True
                    .cmdEliminar.Enabled = False
                    .cmdListarClientes.Enabled = False

                    .lblAgregar.Enabled = True
                    .lblQuitar.Enabled = True

                    .txtRS.Focus()

                End With

                Exit Sub
            Else

                lblIDReq.Text = Trim(objFunciones.Generar_Codigo(SQLGenerarID))

                SQLInsertar =
                "INSERT INTO tb_requerimientos(REQ_Codigo, USU_Codigo, CLI_Codigo, REQ_Fecha, " & _
                "REQ_Descripcion, REQ_Observacion, REQ_Tipo, REQ_Estado) VALUES('" & lblIDReq.Text & "', '" & _
                USU_CODIGO & "', '" & lblIDCliente.Text & "', '" & lblFechaReq.Text & "', '" & _
                txtDescripcion.Text & "', '" & txtObservacion.Text & "', '" & _
                TIPO_REQ & "', '" & 0 & "')"

                If txtCliente.Text = "" Then
                    MsgBox("Datos del cliente necesarios" & vbNewLine & vbNewLine & _
                           "Por favor ingrese los datos del cliente al cual se le realizará el requerimiento.",
                           vbCritical, "Digite datos")

                    txtCliente.Focus()
                    Exit Sub
                Else
                    If objFunciones.Ejecutar(SQLInsertar) Then
                        MsgBox("En hora buena." & vbNewLine & vbNewLine & _
                               "El registro de su requerimiento ha sido realizado con exito", vbInformation, "Correcto")

                        EXISTE_CLIENT = False
                    End If

                    HABILIATAR(False)
                    cmdRegistrar.Text = "Modificar"
                End If
            End If
        ElseIf cmdRegistrar.Text = "Modificar" Then
            SQLModificar =
            "UPDATE tb_requerimientos SET " & _
            "CLI_Codigo='" & lblIDCliente.Text & "', " & _
            "REQ_Tipo='" & TIPO_REQ & "', " & _
            "REQ_Descripcion='" & txtDescripcion.Text & "', " & _
            "REQ_Observacion='" & txtObservacion.Text & "', " & _
            "REQ_FechaSeg='" & Format(dtpFecha.Value, "dd/MM/yyyy") & "' " & _
            "WHERE REQ_Codigo='" & lblIDReq.Text & "'"

            If MsgBox("Esta apunto de ejecutar un cambio en el requerimiento " & vbNewLine & _
                     "# " & lblIDReq.Text & "." & vbNewLine & vbNewLine & _
                     "Para confirmar dicha accion pulse el botón [ Si ]", _
                     vbYesNo + vbQuestion + vbDefaultButton1, "Confirme") = vbYes Then
                objFunciones.Ejecutar(SQLModificar)
            End If
        End If

        Me.Close()

        modProcedimientos.listarRequerimientos(SQLRequerimientos, MDIPrincipal.dgvRequerimientos)
        modProcedimientos.listarCotizaciones(SQLCotizaciones, MDIPrincipal.dgvCotizados)
    End Sub

    Private Sub txtCliente_Click(sender As Object, e As EventArgs) Handles txtCliente.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtCliente)
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtCliente, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDescripcion, e)
        'modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtObservacion, e)
        'modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.Text <> "" Then
            modProcedimientos.listarClientesFactura(dgvListaClientes, txtCliente.Text)
        Else
            dgvListaClientes.Visible = False
        End If
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
                txtObservacion.Text &= "DIRECCION: " & dtaux.Rows(0).Item("CLI_DireccionLegal").ToString
                'lblDireccion.Text = dtaux.Rows(0).Item("CLI_DireccionLegal").ToString
                'lblRuc.Text = dtaux.Rows(0).Item("CLI_RUC").ToString

                dgvListaClientes.Visible = False

                EXISTE_CLIENT = True
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try

    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim SQLDelete As String =
        "UPDATE tb_requerimientos SET REQ_Estado='X' " & _
        "WHERE REQ_Codigo='" & lblIDReq.Text & "'"

        If MsgBox("Realmente deseas quitar el requerimiento seleccionado de la lista " & _
                      "de requerimientos pendientes?", _
                      vbYesNo + vbQuestion + vbDefaultButton2, "Quitar") = vbYes Then

            If objFunciones.Ejecutar(SQLDelete) Then
                modProcedimientos.listarRequerimientos(SQLRequerimientos, MDIPrincipal.dgvRequerimientos)
                Me.Close()
            End If
        End If
    End Sub
End Class