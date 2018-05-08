Imports System.Data.SqlClient

Public Class FrmValidar
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.txtContrasena.BackColor = Color.FromArgb(255, 255, 192)
        Me.txtContrasena.ForeColor = Color.Black
        Me.Close()
    End Sub

    Private Sub FrmValidar_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtContrasena.Text = ""
        txtContrasena.Focus()
    End Sub

    Private Sub txtContrasena_GotFocus(sender As Object, e As EventArgs) Handles txtContrasena.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasena)
    End Sub

    Private Sub txtContrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub FrmValidar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdValidar_Click(sender As Object, e As EventArgs) Handles cmdValidar.Click

        Dim sqlValidar As String

        Try
            sqlValidar = "SELECT U.USU_Codigo, U.USU_Login, U.USU_Contrasena, " & _
                         "U.USU_Nombres, U.USU_Activo, NU.NUSU_Descripcion " & _
                         "FROM tb_usuarios U, tb_niv_usuarios NU " & _
                         "WHERE U.NUSU_Codigo = NU.NUSU_Codigo AND " & _
                         "U.USU_Codigo = '" & COD_RECIBIDOR & "' AND " & _
                         "U.USU_Contrasena='" & objEncriptacion.Encripta(txtContrasena.Text) & "'"

            If (txtContrasena.Text = "") Then
                MsgBox("Ingrese su contraseña.", vbExclamation, "Completar")
                txtContrasena.Focus()
            Else
                'modConexion.Conectar_Servidor()

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlValidar, cnn)
                sqlda.Fill(dt)



                If dt.Rows.Count > 0 Then
                    With FrmRegistrarMovimientos
                        .txtImporte.Enabled = True
                        .txtImporte.Focus()

                        .panelEstado.Visible = True
                        '.panelEstado.BackColor = Color.DarkTurquoise
                        '.panelEstado.ForeColor = Color.White

                        .txtObservacion.Focus()
                        .cmdRegistrar.Enabled = True
                    End With

                    Me.txtContrasena.BackColor = Color.FromArgb(255, 255, 192)
                    Me.txtContrasena.ForeColor = Color.Black
                    Me.Close()
                Else
                    With FrmRegistrarMovimientos
                        .txtImporte.Enabled = False

                        .panelEstado.Visible = True
                        .cmdRegistrar.Enabled = False
                    End With

                    Me.txtContrasena.BackColor = Color.FromArgb(254, 92, 92)
                    Me.txtContrasena.ForeColor = Color.Yellow
                    Me.txtContrasena.Focus()
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

End Class