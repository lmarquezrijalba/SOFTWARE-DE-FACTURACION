Public Class FrmAcercade

    Private Sub FrmAcercade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "SISTEMA INTEGRADO DE GESTIÓN, BALINSA S.A.C. " & Format(Now, "yyyy")
        Label2.Text = "versión " & My.Application.Info.Version.ToString & "."
        Label3.Text = "Copyrigyh (C) 2015-" & Format(Now, "yyyy") & ". Reservados todos los derechos."
        Label6.Text = Environment.MachineName & "."
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Me.Close()
    End Sub
End Class