Public Class FrmRegistroCiudades

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmRegistroCiudades_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If objFunciones.estaVentanaAbierta(FrmRegistroClientes) Then
            With FrmRegistroClientes
                '.Hide()

                modProcedimientos.llenarCiudades(.cboCiudad)
                '.MdiParent = MDIPrincipal
                '.Show()
            End With
        Else
            Me.Hide()
            'FrmRegistroClientes.Hide()
        End If
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim sqlVerificar As String
        Dim sqlRegCiudad As String
        Dim ID As String = txtCiudad.Text

        sqlVerificar = "SELECT PROV_Nombre FROM tb_provincias WHERE PROV_Nombre='" & ID & "'"
        sqlRegCiudad = "INSERT INTO tb_provincias (PROV_Nombre, PROV_Activo) " & _
                       "VALUES('" & txtCiudad.Text & "','" & chkActivar.Checked & "')"

        Try
            If objFunciones.verificarRegistro(sqlVerificar) = False Then
                If (objFunciones.Ejecutar(sqlRegCiudad)) Then
                    txtCiudad.Text = ""
                    txtCiudad.Focus()
                End If
            Else
                MsgBox("La Ciudad " & ID & " ya se encuentra registrada", vbCritical, "¡Aviso!")
                txtCiudad.Focus()
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub txtCiudad_Click(sender As Object, e As EventArgs) Handles txtCiudad.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtCiudad)
    End Sub

    Private Sub txtCiudad_GotFocus(sender As Object, e As EventArgs) Handles txtCiudad.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtCiudad)
    End Sub

    Private Sub txtCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCiudad.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtCiudad, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtCiudad_TextChanged(sender As Object, e As EventArgs) Handles txtCiudad.TextChanged
        If Len(txtCiudad.Text) > 0 Then
            cmdRegistrar.Enabled = True
            chkActivar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
            chkActivar.Enabled = False
        End If
    End Sub

    Private Sub FrmRegistroCiudades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRegistroCiudades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class