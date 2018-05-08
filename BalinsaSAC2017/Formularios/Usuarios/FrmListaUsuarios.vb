Public Class FrmListaUsuarios
    Dim sqlListaUsuarios As String
    Dim fila As Integer

    Private Sub FrmListaUsuarios_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If NOMB_VENTANA_ACTIVA = "Usuarios Conectados" Then
            chkMostrarTodos.Visible = True
            cmdSeleccionar.Visible = False
        ElseIf NOMB_VENTANA_ACTIVA = "Aperturar Caja" Then
            chkMostrarTodos.Visible = False
            cmdSeleccionar.Visible = True
        End If
    End Sub

    Private Sub FrmListaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlListaUsuarios = "SELECT U.USU_Codigo, NU.NUSU_Descripcion, " & _
                           "U.USU_Nombres, USU_Login, U.USU_Conectado, U.USU_Activo " & _
                           "FROM tb_usuarios U, tb_niv_usuarios NU " & _
                           "WHERE U.NUSU_Codigo = NU.NUSU_Codigo AND " & _
                           "U.USU_Activo='" & 1 & "'"

        modProcedimientos.listarUsuarios(sqlListaUsuarios, dgvUsuarios)
        'modProcedimientos.colorFilaDGV(dgvUsuarios, 4, "True", Color.FromArgb(199, 234, 199), Color.Black)

        chkMostrarTodos.Checked = False
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdSeleccionar_Click(sender As Object, e As EventArgs) Handles cmdSeleccionar.Click
        If NOMB_VENTANA_ACTIVA = "Aperturar Caja" Then
            With FrmAperturarCaja
                .lblCodCajero.Text = CStr(dgvUsuarios.Item(0, fila).Value)
                .lblNombCajero.Text = CStr(dgvUsuarios.Item(2, fila).Value)
            End With
        End If

        Me.Close()
    End Sub

    Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        Dim IDUsuario, Estado, sqlEstado, Usuario As String
        Dim fila, columna As Integer

        If e.ColumnIndex = 5 And e.RowIndex >= 0 Then
            fila = CInt(e.RowIndex)
            columna = CInt(e.ColumnIndex)

            IDUsuario = CStr(dgvUsuarios.Item(0, fila).Value)
            Estado = CStr(dgvUsuarios.Item(5, fila).Value)
            Usuario = LCase(CStr(dgvUsuarios.Item(2, fila).Value))

            If Estado = "Activo" Then
                If MsgBox("Confirme su acción" & vbNewLine & vbNewLine & _
                          "Realmente desea dar de baja al usuario del " & vbNewLine & _
                          "sistema : *** " & Usuario & " ***", _
                          vbCritical + vbYesNo + vbDefaultButton2, "Confirme") = vbYes Then
                    sqlEstado = "UPDATE tb_usuarios SET USU_Activo='" & 0 & "' " & _
                                "WHERE USU_Codigo='" & IDUsuario & "'"

                    objFunciones.Ejecutar(sqlEstado)
                End If
            ElseIf Estado = "Baja" Then
                sqlEstado = "UPDATE tb_usuarios SET USU_Activo='" & 1 & "' " & _
                            "WHERE USU_Codigo='" & IDUsuario & "'"

                objFunciones.Ejecutar(sqlEstado)
            End If

            modProcedimientos.listarUsuarios(sqlListaUsuarios, dgvUsuarios)
            'modProcedimientos.colorFilaDGV(dgvUsuarios, 4, "True", Color.FromArgb(199, 234, 199), Color.Black)
            'dgvUsuarios.Refresh()
        End If
    End Sub

    Private Sub dgvUsuarios_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvUsuarios.CellFormatting
        e.CellStyle.SelectionBackColor = dgvUsuarios.Rows(e.RowIndex).DefaultCellStyle.BackColor
        e.CellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30)
        e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
    End Sub

    Private Sub dgvUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsuarios.SelectionChanged
        With dgvUsuarios
            fila = .CurrentRow.Index

            If Not IsNothing(.CurrentRow) Then

                With dgvUsuarios
                    '.Rows(fila).DefaultCellStyle.SelectionBackColor = dgvUsuarios.Rows(fila).DefaultCellStyle.BackColor
                End With
                'If NOMB_VENTANA_ACTIVA = "Aperturar Caja" Then
                'With FrmAperturarCaja
                '.lblCodCajero.Text = CStr(dgvUsuarios.Item(0, fila).Value)
                '.lblNombCajero.Text = CStr(dgvUsuarios.Item(2, fila).Value)
                'End With
            Else
                MsgBox("Seleccione una fila de la lista", vbInformation, "¡Seleccionar!")
            End If
        End With
    End Sub

    Private Sub chkMostrarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarTodos.CheckedChanged
        If chkMostrarTodos.Checked Then
            sqlListaUsuarios = "SELECT U.USU_Codigo, NU.NUSU_Descripcion, " & _
                   "U.USU_Nombres, USU_Login, U.USU_Conectado, U.USU_Activo " & _
                   "FROM tb_usuarios U, tb_niv_usuarios NU " & _
                   "WHERE U.NUSU_Codigo = NU.NUSU_Codigo AND " & _
                   "U.USU_Activo='" & 0 & "'"
        Else
            sqlListaUsuarios = "SELECT U.USU_Codigo, NU.NUSU_Descripcion, " & _
                   "U.USU_Nombres, USU_Login, U.USU_Conectado, U.USU_Activo " & _
                   "FROM tb_usuarios U, tb_niv_usuarios NU " & _
                   "WHERE U.NUSU_Codigo = NU.NUSU_Codigo AND " & _
                   "U.USU_Activo='" & 1 & "'"
        End If

        dgvUsuarios.Refresh()
        modProcedimientos.listarUsuarios(sqlListaUsuarios, dgvUsuarios)
        'modProcedimientos.colorFilaDGV(dgvUsuarios, 4, "True", Color.FromArgb(199, 234, 199), Color.Black)
    End Sub
End Class