Public Class FrmAsistenciaTecnica
    Dim CAT As String = "RL"

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        With FrmRegAsistencia
            .lblIDAsistencia.Text = objFunciones.Generar_Codigo("SELECT COUNT(AST_Codigo) FROM tb_asistencia_tecnicas", "0000", "A-")
            .lblCat.Text = CAT
            .lblIDCliente.Text = ""
            .txtCliente.Text = ""
            .cboCiudad.Text = "Seleccione"
            .dgvAsistencias.Rows.Clear()
            .cmdGuardar.Text = "Guardar datos"

            .ShowDialog()
        End With
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmAsistenciaTecnica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = 0
        modProcedimientos.listarAsistenciasTecnicas(dgvRiceLake, "RL")
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        With TabControl1
            If .SelectedIndex = 0 Then
                CAT = "RL"
                modProcedimientos.listarAsistenciasTecnicas(dgvRiceLake, CAT)
            ElseIf .SelectedIndex = 1 Then
                CAT = "CM"
                modProcedimientos.listarAsistenciasTecnicas(dgvCamiones, CAT)
            ElseIf .SelectedIndex = 2 Then
                CAT = "CA"
            End If
        End With
    End Sub

    Private Sub dgvRiceLake_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRiceLake.CellFormatting
        dgvRiceLake.Cursor = Cursors.Hand

        e.CellStyle.SelectionBackColor = dgvRiceLake.Rows(e.RowIndex).DefaultCellStyle.BackColor
        e.CellStyle.SelectionForeColor = Color.FromArgb(55, 62, 70) 'dgvRiceLake.Rows(e.RowIndex).DefaultCellStyle.BackColor
    End Sub

    Private Sub dgvCamiones_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCamiones.CellFormatting
        dgvCamiones.Cursor = Cursors.Hand

        e.CellStyle.SelectionBackColor = dgvCamiones.Rows(e.RowIndex).DefaultCellStyle.BackColor
        e.CellStyle.SelectionForeColor = Color.FromArgb(55, 62, 70) 'dgvRiceLake.Rows(e.RowIndex).DefaultCellStyle.BackColor
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim IDAsist As String = ""
        Dim Ciudad As String = ""
        Dim fecha As Date

        Try
            With FrmRegAsistencia
                If CAT = "RL" Then
                    IDAsist = dgvRiceLake.Item(dgvRiceLake.CurrentCell.ColumnIndex, 0).Value
                    Ciudad = dgvRiceLake.Item(dgvRiceLake.CurrentCell.ColumnIndex, 2).Value
                    fecha = Format(CDate(dgvRiceLake.Item(dgvRiceLake.CurrentCell.ColumnIndex, dgvRiceLake.CurrentCell.RowIndex).Value), "dd/MM/yyyy")
                ElseIf CAT = "CM" Then
                    IDAsist = dgvCamiones.Item(dgvCamiones.CurrentCell.ColumnIndex, 0).Value
                    Ciudad = dgvCamiones.Item(dgvCamiones.CurrentCell.ColumnIndex, 2).Value
                    fecha = Format(CDate(dgvCamiones.Item(dgvCamiones.CurrentCell.ColumnIndex, dgvCamiones.CurrentCell.RowIndex).Value), "dd/MM/yyyy")
                ElseIf CAT = "CA" Then

                End If

                .cmdGuardar.Text = "Modificar datos"
                .lblIDAsistencia.Text = IDAsist
                .lblCat.Text = CAT
                .cboCiudad.SelectedText = Ciudad
                .dtpFecha.Value = fecha

                modProcedimientos.listar_DetalleAsistencias("SELECT DAST_Codigo, DAST_Fecha, DAST_Estado, " & _
                                                            "UPPER(DATENAME(WEEKDAY, DAST_Fecha)) AS Dia " & _
                                                            "FROM tb_detalle_asistencias " & _
                                                            "WHERE AST_Codigo='" & IDAsist & "' AND DAST_Estado='1'", .dgvAsistencias)
                .ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class