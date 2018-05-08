Imports System.Data.SqlClient

Public Class FrmCambiarContrasena
    Dim sqlUsuario, sqlCambiarPass As String
    Dim Codigo, Usuario, Contrasena As String
    Dim numReg As Integer

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmCambiarContrasena_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        sqlUsuario = "SELECT * FROM tb_usuarios WHERE USU_Codigo='" & USU_CODIGO & "'"

        dt = New Data.DataTable
        sqlda = New SqlDataAdapter(sqlUsuario, cnn)
        sqlda.Fill(dt)

        numReg = dt.Rows.Count

        Codigo = CStr(dt.Rows(0).Item("USU_Codigo"))
        Usuario = CStr(dt.Rows(0).Item("USU_Nombres"))
        Contrasena = CStr(dt.Rows(0).Item("USU_Contrasena"))

        Me.Text = "Cambiar contraseña del usuario: " & LCase(Usuario)
    End Sub

    Private Sub cmdCambiarContraseña_Click(sender As Object, e As EventArgs) Handles cmdCambiarContraseña.Click

        If numReg > 0 Then

            sqlCambiarPass = "UPDATE tb_usuarios SET USU_Contrasena='" & _
                             objEncriptacion.Encripta(txtContrasenaRep.Text) & "' " & _
                             "WHERE USU_Codigo='" & Codigo & "'"

            If Len(txtContrasenaAct.Text) = 0 Then
                MsgBox("Ingrese su contraseña actual.", vbCritical, "¡Verifique!")
                txtContrasenaAct.Focus()
            ElseIf Len(txtContrasenaNuv.Text) = 0 Then
                MsgBox("Este campo no puede estar vacio. Corrija", vbCritical, "¡Verifique!")
                txtContrasenaNuv.Focus()
            ElseIf Len(txtContrasenaRep.Text) = 0 Then
                MsgBox("Este campo no puede estar vacio. Corrija", vbCritical, "¡Verifique!")
                txtContrasenaRep.Focus()
            ElseIf Contrasena <> objEncriptacion.Encripta(txtContrasenaAct.Text) Then
                MsgBox("La contraseña actual no coincide con la registrada en el sistema. Por favor revise.", vbCritical, "¡Verificar!")
                txtContrasenaAct.Focus()
            ElseIf (txtContrasenaNuv.Text <> txtContrasenaRep.Text) Then
                MsgBox("La confirmacion de la contraseña no coincide con la ingresada. Por favor revise.", vbCritical, "¡Verificar!")
                txtContrasenaRep.Focus()
            Else
                If objFunciones.Ejecutar(sqlCambiarPass) Then
                    'MsgBox("Estimado " & LCase(Usuario) & " su contraseña ha sido modificada con exito.", vbInformation, "¡Exito!")
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txtContrasenaAct_Click(sender As Object, e As EventArgs) Handles txtContrasenaAct.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasenaAct)
    End Sub

    Private Sub txtContrasenaAct_GotFocus(sender As Object, e As EventArgs) Handles txtContrasenaAct.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasenaAct)
    End Sub

    Private Sub txtContrasenaAct_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasenaAct.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtContrasenaNuv_Click(sender As Object, e As EventArgs) Handles txtContrasenaNuv.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasenaNuv)
    End Sub

    Private Sub txtContrasenaNuv_GotFocus(sender As Object, e As EventArgs) Handles txtContrasenaNuv.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasenaNuv)
    End Sub

    Private Sub txtContrasenaNuv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasenaNuv.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtContrasenaRep_Click(sender As Object, e As EventArgs) Handles txtContrasenaRep.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasenaRep)
    End Sub

    Private Sub txtContrasenaRep_GotFocus(sender As Object, e As EventArgs) Handles txtContrasenaRep.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasenaRep)
    End Sub

    Private Sub txtContrasenaRep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasenaRep.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub FrmCambiarContrasena_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmCambiarContrasena_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class