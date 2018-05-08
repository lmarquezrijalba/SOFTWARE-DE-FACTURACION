Public Class FrmZoomTarjeta

    Private Sub FrmZoomTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            modProcedimientos.EffectOut(Me)
        End If
    End Sub

    Private Sub FrmZoomTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picZoom.Dock = DockStyle.Fill
        picZoom.SizeMode = PictureBoxSizeMode.StretchImage

        With FrmRegistroContactos
            picZoom.Image = .picTarjeta.Image
        End With

        modProcedimientos.EffectIn(Me)
    End Sub
End Class