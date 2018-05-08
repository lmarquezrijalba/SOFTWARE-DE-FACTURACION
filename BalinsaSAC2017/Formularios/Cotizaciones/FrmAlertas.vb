Public Class FrmAlertas
    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        MDIPrincipal.tmrReactivar.Start()
        Me.Close()
    End Sub
End Class