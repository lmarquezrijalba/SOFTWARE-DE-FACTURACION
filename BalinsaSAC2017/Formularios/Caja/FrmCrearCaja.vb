Public Class FrmCrearCaja

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click

        Dim sqlRegCajas As String

        sqlRegCajas = "INSERT INTO tb_cajas(USU_Codigo, CAJ_Nombre, " & _
                      "CAJ_Principal, CAJ_Aperturado) " & _
                      "VALUES('" & USU_CODIGO & "','" & _
                      txtNombEquipo.Text & "','" & chkDetectar.Checked & "','" & 0 & "')"

        Try
            'If objFunciones.verificarRegistro(sqlVerificar) = False Then
            If (objFunciones.Ejecutar(sqlRegCajas)) Then
                txtNombEquipo.Text = ""
                txtNombEquipo.Focus()
                cmdRegistrar.Enabled = False

                Me.Close()
            End If
            'Else
            'MsgBox("La caja " & ID & " ya se encuentra registrada", vbCritical, "¡Aviso!")
            'txtNombEquipo.Focus()
            'End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub cmdDetectar_KeyPress(sender As Object, e As KeyPressEventArgs)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub cmdAsignar_Click(sender As Object, e As EventArgs)
        FrmListaUsuarios.ShowDialog()
    End Sub

    Private Sub chkDetectar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetectar.CheckedChanged
        If chkDetectar.Checked Then
            lblEsCajaPrincipal.Text = "MARCADO COMO PRINCIPAL"
        Else
            lblEsCajaPrincipal.Text = ""
        End If
    End Sub

    Private Sub txtNombEquipo_Click(sender As Object, e As EventArgs) Handles txtNombEquipo.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtNombEquipo)
    End Sub

    Private Sub txtNombEquipo_GotFocus(sender As Object, e As EventArgs) Handles txtNombEquipo.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtNombEquipo)
    End Sub

    Private Sub txtNombEquipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombEquipo.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtNombEquipo, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub FrmCrearCaja_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        With FrmAperturarCaja
            .Hide()

            .MdiParent = MDIPrincipal
            .Show()
        End With
    End Sub

    Private Sub FrmCrearCaja_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If MDIPrincipal.mnuOperacionesCajas.Enabled = True Then
        'chkDetectar.Visible = True
        'Else
        'chkDetectar.Visible = False
        'End If
    End Sub

    Private Sub FrmCrearCaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub txtNombEquipo_TextChanged(sender As Object, e As EventArgs) Handles txtNombEquipo.TextChanged
        If Len(txtNombEquipo.Text) > 0 Then
            'txtNombEquipo.Text = ""
            ' txtNombEquipo.Focus()

            cmdRegistrar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub FrmCrearCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdRegistrar.Enabled = False
    End Sub

End Class