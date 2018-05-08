Public Class FrmNotas
    Private Sub Guardar()
        Dim sqlInsertNota As String

        sqlInsertNota = "INSERT INTO tb_notas_x_usuarios(NOT_Titulo, USU_Codigo, NOT_FechaHora, " & _
                        "NOT_Descripcion, NOT_Activo) " & _
                        "VALUES('" & txtTitulo.Text & "', '" & USU_CODIGO & "', '" & _
                        Format(Now, "dd/MM/yyyy H:mm:ss") & "', '" & rtbNota.Text & "', '" & 1 & "')"

        If Len(txtTitulo.Text) = 0 Then
            MsgBox("No se pudo registrar" & vbNewLine & vbNewLine & _
                   "Debe ingresar un título para la nota a registrar.", vbCritical, "Error al registrar.")
            txtTitulo.BackColor = Color.FromArgb(171, 97, 107)
            txtTitulo.ForeColor = Color.White
            txtTitulo.Focus()
        ElseIf objFunciones.Ejecutar(sqlInsertNota) Then
            MsgBox("Se registro con exito." & vbNewLine & vbNewLine & _
                   txtTitulo.Text & " se encuentra ahora registrado en el sistema.", vbInformation, "¡Exito!")
            txtTitulo.BackColor = Color.White
            txtTitulo.ForeColor = Color.Black
            txtTitulo.Text = ""
            rtbNota.Text = ""

            txtTitulo.Focus()
        End If
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        If cmdRegistrar.Text = "Registrar" Then
            Guardar()
        ElseIf cmdRegistrar.Text = "Modificar" Then
            Dim sqlUpdateNota As String

            sqlUpdateNota = "UPDATE tb_notas_x_usuarios SET " & _
                            "NOT_Titulo='" & txtTitulo.Text & "', " & _
                            "USU_Codigo='" & USU_CODIGO & "', " & _
                            "NOT_Descripcion='" & rtbNota.Text & "' " & _
                            "WHERE NOT_Codigo='" & lblIDNota.Text & "'"

            If objFunciones.Ejecutar(sqlUpdateNota) Then
                MsgBox("Se modificó los datos de la nota satisfactoriamente.", vbInformation, "Exitó.")
            End If
        End If
    End Sub

    Private Sub txtTitulo_Click(sender As Object, e As EventArgs)
        'modProcedimientos.SELEC_TODO_TEXTO(txtTitulo)
    End Sub

    Private Sub txtTitulo_GotFocus(sender As Object, e As EventArgs)
        'modProcedimientos.SELEC_TODO_TEXTO(txtTitulo)
    End Sub

    Private Sub txtTitulo_KeyPress(sender As Object, e As KeyPressEventArgs)
        'modProcedimientos.A_MAYUSCULAS(txtTitulo, e)
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub rtbNota_TextChanged(sender As Object, e As EventArgs) Handles rtbNota.TextChanged
        If Len(rtbNota.Text) > 0 Then
            cmdRegistrar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub BuscarNotaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmBuscarNota.ShowDialog()
    End Sub

    Private Sub NuevaNotaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RegistrarNotaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Guardar()
    End Sub

    Private Sub FrmNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdRegistrar.Text = "Registrar"
        txtTitulo.BackColor = Color.White
        txtTitulo.ForeColor = Color.Black
        txtTitulo.Text = ""
        rtbNota.Text = ""

        txtTitulo.Focus()
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        cmdRegistrar.Text = "Registrar"
        txtTitulo.BackColor = Color.White
        txtTitulo.ForeColor = Color.Black
        txtTitulo.Text = ""
        rtbNota.Text = ""

        txtTitulo.Focus()
    End Sub

    Private Sub tsbBuscar_Click(sender As Object, e As EventArgs) Handles tsbBuscar.Click
        FrmBuscarNota.ShowDialog()
    End Sub
End Class