Imports System.Data.SqlClient

Public Class FrmEnMantenimiento
    Dim enMantenim As Boolean
    Dim cont As Integer = 20

    Private Sub tmrVerificaMantenimiento_Tick(sender As Object, e As EventArgs) Handles tmrVerificaMantenimiento.Tick
        lblContador.Text = cont & " s."
        cont -= 1
    End Sub

    Private Sub FrmEnMantenimiento_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tmrVerificaMantenimiento.Start()
    End Sub

    Private Sub lblContador_TextChanged(sender As Object, e As EventArgs) Handles lblContador.TextChanged
        If lblContador.Text = "-1 s." Then
            End
        End If
    End Sub
End Class