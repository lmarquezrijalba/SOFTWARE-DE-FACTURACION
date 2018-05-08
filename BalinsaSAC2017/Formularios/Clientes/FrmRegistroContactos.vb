Public Class FrmRegistroContactos

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmRegistroContactos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub cambiarAntesEditar(filaSelec As Integer)
        With FrmRegistroClientes.dgvContactos

            .Item(1, filaSelec).Value = txtContacto.Text
            .Item(2, filaSelec).Value = txtCargo.Text
            .Item(3, filaSelec).Value = txtFono.Text
            .Item(4, filaSelec).Value = txtCorreo.Text
            .Item(5, filaSelec).Value = objImagenes.ImageToByteArray(picTarjeta.Image)
            .Item(6, filaSelec).Value = txtObservacion.Text
        End With
    End Sub

    Private Sub cmdAñadir_Click(sender As Object, e As EventArgs) Handles cmdAñadir.Click
        'Dim sqlUpdate As String
        Dim fila As Integer

        If cmdAñadir.Text = "Añadir contacto" Then
            With FrmRegistroClientes.dgvContactos
                fila = .Rows.Count
                .Rows.Add()

                .Item(1, fila).Value = txtContacto.Text
                .Item(2, fila).Value = txtCargo.Text
                .Item(3, fila).Value = txtFono.Text
                .Item(4, fila).Value = txtCorreo.Text
                .Item(5, fila).Value = objImagenes.ImageToByteArray(picTarjeta.Image)
                .Item(6, fila).Value = txtObservacion.Text
            End With

            Me.Close()
        ElseIf cmdAñadir.Text = "Actualizar datos" Then
            If Not IsNumeric(lblIDContacto.Text) Then
                Call cambiarAntesEditar(lblFilaSelec.Text)
            Else
                With FrmRegistroClientes
                    objFunciones.UpdateContacto(lblIDContacto.Text, .lblCodigo.Text,
                                                txtContacto.Text, txtCargo.Text, txtFono.Text, txtCorreo.Text,
                                                txtObservacion.Text, objImagenes.ImageToByteArray(picTarjeta.Image))

                    Dim sqlConsulta As String = "SELECT * FROM tb_contato_x_clientes " & _
                                                "WHERE CLI_Codigo='" & .lblCodigo.Text & "'"

                    modProcedimientos.listarContact_x_Cliente(.dgvContactos, sqlConsulta)
                End With
            End If

            Me.Close()
        End If
    End Sub

    Private Sub FrmRegistroContactos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picTarjeta.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub picTarjeta_Click(sender As Object, e As EventArgs) Handles picTarjeta.Click
        Try
            Dim rutaImagen As String = ""

            'ofdAbrir.Filter = "Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"
            ofdAbrir.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los Archivos (*.*)|*.*"
            ofdAbrir.Title = "Seleccionar la imagen"
            ofdAbrir.ShowDialog()

            rutaImagen = ofdAbrir.FileName

            If rutaImagen <> "OpenFileDialog1" Then 'Windows.Forms.DialogResult.OK Then
                picTarjeta.Image = Image.FromFile(rutaImagen)
            Else
                picTarjeta.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub txtContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContacto.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtContacto, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtCargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCargo.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtCargo, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtFono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFono.KeyPress
        modProcedimientos.SOLO_TELEFONOS(sender, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtCorreo, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtObservacion, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub lblZoom_Click(sender As Object, e As EventArgs) Handles lblZoom.Click
        FrmZoomTarjeta.ShowDialog()
    End Sub
End Class