Public Class FrmCalendario
    Dim fecha As Date

    Private Sub cmdSeleccionar_Click(sender As Object, e As EventArgs) Handles cmdSeleccionar.Click
        fecha = mcCalendario.SelectionRange.Start()

        If NOMB_VENTANA_ACTIVA = "Aperturar Caja" Then
            FrmAperturarCaja.lblFechaApertura.Text = fecha
        End If

        Me.Close()
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmCalendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = mcCalendario.Width + 16
    End Sub
End Class