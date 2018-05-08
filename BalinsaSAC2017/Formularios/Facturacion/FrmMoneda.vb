Public Class FrmMoneda

    Private Sub cmdSoles_Click(sender As Object, e As EventArgs) Handles cmdSoles.Click
        SIMBOLO_MONEDA = "S/" : MONEDA = "Soles"

        Me.Close()
        FrmRegistroFactura.lblMoneda.Text = Mid(MONEDA, 1, 1)
        FrmRegistroFactura.MdiParent = MDIPrincipal
        FrmRegistroFactura.Show()

        'NOMB_VENTANA_ACTIVA = "Nueva Factura"
    End Sub

    Private Sub cmdDolares_Click(sender As Object, e As EventArgs) Handles cmdDolares.Click
        SIMBOLO_MONEDA = "$" : MONEDA = "Dolares"

        Me.Close()
        FrmRegistroFactura.lblMoneda.Text = Mid(MONEDA, 1, 1)
        FrmRegistroFactura.MdiParent = MDIPrincipal
        FrmRegistroFactura.Show()

        'NOMB_VENTANA_ACTIVA = "Nueva Factura"
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class