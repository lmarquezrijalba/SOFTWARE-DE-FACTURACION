Imports System.Data.SqlClient

Public Class FrmCamaras

    Private Sub llenarCategorias(ByVal Combo As ComboBox, ByVal Consulta As String,
                                 ByVal ID As String, ByVal Desc As String)
        Dim numReg As Integer

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = Desc '"CAT_Nombre"
                    .ValueMember = ID '"CAT_Codigo"
                End With
            End If


        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Private Sub FrmCamaras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 2 To 32
            cboCantidad.Items.Add(i)
        Next
    End Sub

    Private Sub cboCantidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCantidad.SelectedIndexChanged
        If cboCantidad.Text > 1 And cboCantidad.Text < 5 Then
            lblNroDVR.Text = 4 & " DVRs"
        ElseIf cboCantidad.Text > 3 And cboCantidad.Text < 9 Then
            lblNroDVR.Text = 8 & " DVRs"
        ElseIf cboCantidad.Text > 7 And cboCantidad.Text < 17 Then
            lblNroDVR.Text = 16 & " DVRs"
        ElseIf cboCantidad.Text > 16 And cboCantidad.Text < 33 Then
            lblNroDVR.Text = 32 & " DVRs"
        End If
    End Sub

End Class