Imports System.Data.SqlClient

Public Class FrmBuscarNota
    Dim sqlNotas, sqlFiltro As String

    Private Sub FrmBuscarNota_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmBuscarNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlNotas = "SELECT * FROM tb_notas_x_usuarios " & _
                   "WHERE USU_Codigo='" & USU_CODIGO & "' AND " & _
                   "NOT_Activo='" & 1 & "' AND " & _
                   "USU_Codigo='" & USU_CODIGO & "'"

        modProcedimientos.listarNotas_x_Usu(sqlNotas, dgvNotas)
    End Sub

    Private Sub txtTitulo_TextChanged(sender As Object, e As EventArgs) Handles txtTitulo.TextChanged
        sqlFiltro = "SELECT * FROM tb_notas_x_usuarios " & _
                    "WHERE NOT_Titulo LIKE '" & txtTitulo.Text & "%' " & _
                    "AND NOT_Activo='" & 1 & "' AND " & _
                    "USU_Codigo='" & USU_CODIGO & "'"

        modProcedimientos.listarNotas_x_Usu(sqlFiltro, dgvNotas)
    End Sub

    Private Sub dgvNotas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotas.CellDoubleClick
        Dim ID, Consulta As String
        Dim fila, numReg As Integer

        fila = dgvNotas.CurrentRow.Index
        ID = dgvNotas.Item(0, fila).Value

        Consulta = "SELECT * FROM tb_notas_x_usuarios " & _
                   "WHERE NOT_Codigo='" & ID & "'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With FrmNotas
                    .lblIDNota.Text = ID
                    .txtTitulo.Text = dt.Rows(0).Item("NOT_Titulo")
                    .rtbNota.Text = dt.Rows(0).Item("NOT_Descripcion")
                    .cmdRegistrar.Text = "Modificar"
                End With
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub mcCalendario_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mcCalendario.DateChanged
        Dim Consulta As String
        Dim fecha As Date

        fecha = mcCalendario.SelectionRange.Start()

        Consulta = "SELECT * FROM tb_notas_x_usuarios " & _
                   "WHERE CONVERT(VARCHAR(10), NOT_FechaHora, 103)='" & fecha & "' AND " & _
                   "NOT_Activo='" & 1 & "' AND " & _
                   "USU_Codigo='" & USU_CODIGO & "'"

        modProcedimientos.listarNotas_x_Usu(Consulta, dgvNotas)
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgvNotas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotas.CellContentClick

    End Sub
End Class