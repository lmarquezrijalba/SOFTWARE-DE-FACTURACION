Public Class FrmPermisos
    Dim fil, col As Integer
    Dim valor As Boolean

    Private Sub FrmPermisos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        modProcedimientos.listarPermisos(dgvPermisos, lblCodNivelSelec.Text)
        chkTodos.Checked = False
    End Sub

    Private Sub FrmPermisos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Dim totalFilas As Integer
        totalFilas = dgvPermisos.Rows.Count - 1
        Dim s As Integer
        If chkTodos.Checked Then
            For s = 0 To totalFilas
                If dgvPermisos.Item(3, s).Value = False Then
                    dgvPermisos.Rows(s).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192)
                    dgvPermisos.Item(3, s).Value = True
                End If
            Next
        Else
            For s = 0 To totalFilas
                If dgvPermisos.Item(3, s).Value = True Then
                    dgvPermisos.Rows(s).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255)
                    dgvPermisos.Item(3, s).Value = False
                End If
            Next
            'modProcedimientos.listarPermisos(dgvPermisos, lblCodNivelSelec.Text)
        End If
    End Sub

    Private Sub cmdAsignar_Click(sender As Object, e As EventArgs) Handles cmdAsignar.Click
        Dim sqlAgregarPermiso, sqlQuitarPermisos, sqlVerificar As String
        Dim numFilas As Integer
        Dim COD_PERMISO, COD_NIVEL As String
        Dim estaSeleccionado As Boolean

        numFilas = dgvPermisos.Rows.Count - 1

        Try
            For i = 0 To numFilas
                estaSeleccionado = CBool(dgvPermisos.Item(3, i).Value)
                COD_PERMISO = CStr(dgvPermisos.Item(0, i).Value)
                COD_NIVEL = CStr(lblCodNivelSelec.Text)

                sqlVerificar = "SELECT PER_Codigo, NUSU_Codigo FROM tb_permisos_x_nivel " & _
                               "WHERE PER_Codigo='" & COD_PERMISO & "' AND NUSU_Codigo='" & COD_NIVEL & "'"

                sqlAgregarPermiso = "INSERT INTO tb_permisos_x_nivel(PER_Codigo, NUSU_Codigo) " & _
                                    "VALUES('" & COD_PERMISO & "','" & COD_NIVEL & "')"

                sqlQuitarPermisos = "DELETE FROM tb_permisos_x_nivel WHERE PER_Codigo='" & _
                                    COD_PERMISO & "' AND NUSU_Codigo='" & COD_NIVEL & "'"

                If estaSeleccionado = True Then
                    If (objFunciones.verificarRegistro(sqlVerificar) = False) Then
                        objFunciones.Ejecutar(sqlAgregarPermiso)

                        objFunciones.Ejecutar("UPDATE tb_configsis SET escanearPermisos='1'")
                        'MDIPrincipal.tmrCambios_en_Permisos.Start()
                        'modProcedimientos.escanPermisos(MDIPrincipal.BarMenu)
                        'modProcedimientos.habilitarPermisos(MDIPrincipal.BarHerramienta)
                        'tmrActualizaPermisos.Start()
                    End If
                Else
                    If (objFunciones.verificarRegistro(sqlVerificar)) Then
                        objFunciones.Ejecutar(sqlQuitarPermisos)

                        objFunciones.Ejecutar("UPDATE tb_configsis SET escanearPermisos='1'")
                        'MDIPrincipal.tmrCambios_en_Permisos.Start()
                        'modProcedimientos.escanPermisos(MDIPrincipal.BarMenu)
                        'modProcedimientos.habilitarPermisos(MDIPrincipal.BarHerramienta)
                        'tmrActualizaPermisos.Start()
                    End If
                End If
            Next

            Me.Close()
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub dgvPermisos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermisos.CellContentClick
        With dgvPermisos
            fil = .CurrentCell.RowIndex
            col = .CurrentCell.ColumnIndex

            If col = 3 Then
                valor = .Item(col, fil).Value

                If valor = False Then
                    .Item(col, fil).Value = True
                    .Rows(fil).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192) 'Color.White
                ElseIf valor = True Then
                    .Item(col, fil).Value = False
                    .Rows(fil).DefaultCellStyle.BackColor = Color.White 'Color.FromArgb(255, 255, 192)
                End If
            End If
        End With
    End Sub

    Private Sub dgvPermisos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermisos.CellEnter
           End Sub

    Private Sub dgvPermisos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPermisos.CellFormatting

        With dgvPermisos
            'e.CellStyle.SelectionBackColor = .Rows(e.RowIndex).DefaultCellStyle.BackColor
            dgvPermisos.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = .Rows(e.RowIndex).DefaultCellStyle.BackColor
        End With
    End Sub
End Class