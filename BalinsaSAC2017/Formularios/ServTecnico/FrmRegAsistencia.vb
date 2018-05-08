Imports System.Data.SqlClient

Public Class FrmRegAsistencia
    Dim SQLInser, SQLUpdate As String

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
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
            lblIDCliente.Text = ""
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

                dgvListaClientes.Visible = False
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub FrmRegAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modProcedimientos.llenarCiudades(cboCiudad)

        Dim column As DataGridViewColumn
        With dgvAsistencias
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.CellBorderStyle = DataGridViewCellBorderStyle.None

            For Each column In .Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With

        With dgvListaClientes
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None

            'For Each column In .Columns
            '    column.SortMode = DataGridViewColumnSortMode.NotSortable
            'Next
        End With
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim SQLDetalleAsistencia, IDAsistencia As String

        If lblIDCliente.Text = "" Then
            MsgBox("No se pudo registrar." & vbNewLine & vbNewLine & _
                   "Por favor ingrese la razón social del cliente a registrar la asistencia", vbCritical, "Verifique")
        Else
            If cmdGuardar.Text = "Guardar datos" Then
                IDAsistencia = objFunciones.Generar_Codigo("SELECT COUNT(AST_Codigo) FROM tb_asistencia_tecnicas", "0000", "A-")

                SQLInser =
                "INSERT INTO tb_asistencia_tecnicas(AST_Codigo, CLI_Codigo, AST_Ciudad, AST_Tipo, AST_Activo) " & _
                "VALUES('" & IDAsistencia & "', '" & lblIDCliente.Text & "', '" & cboCiudad.Text & "', '" & _
                lblCat.Text & "', '" & 1 & "')"

                If dgvAsistencias.Rows.Count > 0 Then
                    If objFunciones.Ejecutar(SQLInser) Then
                        With dgvAsistencias
                            For i = 0 To .RowCount - 1
                                If IsNumeric(.Item(0, i).Value) Then
                                    SQLDetalleAsistencia =
                                    "UPDATE tb_detalle_asistencias SET " & _
                                    "DAST_Fecha='" & .Item(3, i).Value & "' " & _
                                    "WHERE DAST_Codigo='" & .Item(0, i).Value & "'"
                                Else
                                    SQLDetalleAsistencia =
                                    "INSERT INTO tb_detalle_asistencias(AST_Codigo, DAST_Fecha, DAST_Estado) " & _
                                    "VALUES('" & IDAsistencia & "', '" & .Item(3, i).Value & "', '" & 1 & "')"
                                End If

                                objFunciones.Ejecutar(SQLDetalleAsistencia)
                            Next
                        End With

                        If lblCat.Text = "RL" Then
                            modProcedimientos.listarAsistenciasTecnicas(FrmAsistenciaTecnica.dgvRiceLake, "RL")
                        ElseIf lblCat.Text = "CM" Then
                            modProcedimientos.listarAsistenciasTecnicas(FrmAsistenciaTecnica.dgvCamiones, "CM")
                        End If

                        Me.Close()
                        'cmdGuardar.Text = "Modificar datos"
                    End If
                Else
                    MsgBox("No se puedo registrar" & vbNewLine & vbNewLine & _
                           "La lista de asistencias técnicas debe contener al menos una fila asignada.", vbCritical, "Ingrese")
                End If
            ElseIf cmdGuardar.Text = "Modificar datos" Then
                'IDAsistencia = objFunciones.Generar_Codigo("SELECT COUNT(AST_Codigo) FROM tb_asistencia_tecnicas", "0000", "A-")
                With dgvAsistencias
                    For i = 0 To .Rows.Count - 1
                        If IsNumeric(.Item(0, i).Value) Then
                            SQLDetalleAsistencia =
                            "UPDATE tb_detalle_asistencias SET " & _
                            "DAST_Fecha='" & .Item(3, i).Value & "' " & _
                            "WHERE DAST_Codigo='" & .Item(0, i).Value & "'"
                        Else
                            SQLDetalleAsistencia =
                            "INSERT INTO tb_detalle_asistencias(AST_Codigo, DAST_Fecha, DAST_Estado) " & _
                            "VALUES('" & lblIDAsistencia.Text & "', '" & .Item(3, i).Value & "', '" & 1 & "')"
                        End If

                        objFunciones.Ejecutar(SQLDetalleAsistencia)
                    Next
                End With

                If lblCat.Text = "RL" Then
                    modProcedimientos.listarAsistenciasTecnicas(FrmAsistenciaTecnica.dgvRiceLake, "RL")
                ElseIf lblCat.Text = "CM" Then
                    modProcedimientos.listarAsistenciasTecnicas(FrmAsistenciaTecnica.dgvCamiones, "CM")
                End If

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblAgregar_Click(sender As Object, e As EventArgs) Handles lblAgregar.Click
        Dim Registrar As Boolean

        With dgvAsistencias
            Dim fechaMarcada As Date = Format(dtpFecha.Value, "dd/MM/yyyy")

            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dim fechaAgregada As Date = Format(CDate(.Item(3, i).Value), "dd/MM/yyyy")

                    If fechaAgregada = fechaMarcada Then
                        Registrar = False
                        Exit For
                    Else
                        Registrar = True
                    End If
                Next

                If Registrar Then
                    .Rows.Add("", .Rows.Count + 1, UCase(Format(dtpFecha.Value, "dddd")), Format(dtpFecha.Value, "dd/MM/yyyy"))
                Else
                    MsgBox("La fecha de asistencia ya fue registrada", vbExclamation, "Verifique")
                    dtpFecha.Focus()
                End If
            Else
                .Rows.Add("", .Rows.Count + 1, UCase(Format(dtpFecha.Value, "dddd")), Format(dtpFecha.Value, "dd/MM/yyyy"))
            End If
        End With
    End Sub

    'tlwn781nd v2.1

    Private Sub lblQuitar_Click(sender As Object, e As EventArgs) Handles lblQuitar.Click
        With dgvAsistencias
            If Not IsNothing(.CurrentRow) Then
                Dim fila As Integer = .CurrentRow.Index

                Dim SQLQuitar As String =
                    "UPDATE tb_detalle_asistencias SET " & _
                    "DAST_Estado='" & 0 & "' " & _
                    "WHERE DAST_Codigo='" & .Item(0, fila).Value & "'"

                'If .CurrentRow.Index >= 0 Then
                'If fila < 0 Then
                If MsgBox("Realmente deseas quitar la fila seleccionada.", _
                          vbQuestion + vbYesNo + vbDefaultButton2, "Quitar elemento") = vbYes Then

                    If Not IsNumeric(.Item(0, .CurrentRow.Index).Value) Then
                        .Rows.Remove(.CurrentRow)
                        'numFilas = .RowCount
                    Else
                        objFunciones.Ejecutar(SQLQuitar)
                        'modProcedimientos.listar_DetalleAsistencias("", FrmAsistenciaTecnica.dgvRiceLake)
                        modProcedimientos.listar_DetalleAsistencias("SELECT DAST_Codigo, DAST_Fecha, DAST_Estado, " & _
                                                                    "UPPER(DATENAME(WEEKDAY, DAST_Fecha)) AS Dia " & _
                                                                    "FROM tb_detalle_asistencias " & _
                                                                    "WHERE AST_Codigo='" & lblIDAsistencia.Text & "' AND DAST_Estado='1'", dgvAsistencias)
                        If lblCat.Text = "RL" Then
                            modProcedimientos.listarAsistenciasTecnicas(FrmAsistenciaTecnica.dgvRiceLake, lblCat.Text)
                        ElseIf lblCat.Text = "CM" Then
                            modProcedimientos.listarAsistenciasTecnicas(FrmAsistenciaTecnica.dgvCamiones, lblCat.Text)
                        End If
                    End If
                End If
            End If
        End With
    End Sub
End Class