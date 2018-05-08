Public Class FrmNiveles

    Private Sub FrmNiveles_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        cmdRegistrar.Enabled = False
        modProcedimientos.listarNiveles(dgvNiveles)
    End Sub

    Private Sub dgvNiveles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNiveles.CellClick
        Dim fila, columna As Integer

        If e.ColumnIndex = 2 Then
            fila = CInt(e.RowIndex)
            columna = CInt(e.ColumnIndex)

            'MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)

            With FrmPermisos
                .lblCodNivelSelec.Text = CStr(dgvNiveles.Item(0, fila).Value)
                .lblNivel.Text = CStr(dgvNiveles.Item(1, fila).Value)

                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub txtNivel_Click(sender As Object, e As EventArgs) Handles txtNivel.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtNivel)
    End Sub

    Private Sub txtNivel_GotFocus(sender As Object, e As EventArgs) Handles txtNivel.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtNivel)
    End Sub

    Private Sub txtNivel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNivel.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtNivel, e)
        modProcedimientos.Saltar(e)
    End Sub


    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim ID As String = txtNivel.Text
        Dim sqlVerificar, sqlRegNiveles As String

        sqlVerificar = "SELECT NUSU_Descripcion FROM tb_niv_usuarios WHERE NUSU_Descripcion='" & ID & "'"

        sqlRegNiveles = "INSERT INTO tb_niv_usuarios( NUSU_Descripcion, NUSU_Administra, NUSU_Activo) " & _
                         "VALUES('" & txtNivel.Text & "','0" & "','" & 1 & "')"

        Try
            If objFunciones.verificarRegistro(sqlVerificar) = False Then
                If (objFunciones.Ejecutar(sqlRegNiveles)) Then
                    modProcedimientos.listarNiveles(dgvNiveles)
                    txtNivel.Text = ""
                    txtNivel.Focus()
                    cmdRegistrar.Enabled = False
                End If
            Else
                MsgBox("El nivel " & txtNivel.Text & " ya se encuentra registrado", vbCritical, "¡Aviso!")
                txtNivel.Focus()
                cmdRegistrar.Enabled = False
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub txtNivel_TextChanged(sender As Object, e As EventArgs) Handles txtNivel.TextChanged
        If Len(txtNivel.Text) > 0 Then
            cmdRegistrar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub FrmNiveles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvNiveles
            If NOMB_VENTANA_ACTIVA = "Niveles" Then
                Label1.Text = "NIVELES DE USUARIO"
                Label2.Text = "Ingrese el nivel de usuario a registrar, posteriormente podrá asignarle los " & _
                              "permisos necesario para trabajar con el sistema"

                .Columns(1).Width = 305
                .Columns(2).Visible = False
                panelBottom.Visible = True
            ElseIf NOMB_VENTANA_ACTIVA = "Permisos" Then
                Label1.Text = "ASIGNAR PERMISOS DE USUARIO"
                Label2.Text = "Seleccione el nivel de usuario a asignarle los permisos necesarios, " & _
                              "luego seleccione todos los permisos a ser asignados "

                .Columns(1).Width = 184
                .Columns(2).Visible = True
                panelBottom.Visible = False
            End If
        End With
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class