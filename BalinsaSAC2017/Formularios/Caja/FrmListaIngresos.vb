Public Class FrmListaIngresos
    Dim anioInicio, anioActual As Integer

    Private Sub FrmListaIngresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        anioInicio = CInt(2015)
        anioActual = Format(Now, "yyyy")

        'LLENAMOS COMBO CON AÑOS
        '--------------------------------
        cboAnio.Items.Clear()
        'cboAnio.Items.Add("Seleccione")
        For i = anioActual To anioInicio Step -1
            cboAnio.Items.Add(i)
        Next

        cboAnio.Text = anioActual
        'cboAnio.SelectedIndex = 0
        Dim column As DataGridViewColumn

        'modProcedimientos.setearGridaEstatica(dgvDetalleIngresos)z
        With dgvDetalleIngresos
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None

            For Each column In .Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With

        modProcedimientos.listarMov_Ingreso(dgvDetalleIngresos, lblCodCaja.Text, "Mes", cboAnio.Text)
    End Sub

    Private Sub dgvDetalleIngresos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetalleIngresos.CellFormatting
        e.CellStyle.SelectionBackColor = dgvDetalleIngresos.Rows(e.RowIndex).DefaultCellStyle.BackColor

        If dgvDetalleIngresos.Item(7, e.RowIndex).Value <> "GENERADO" And
           dgvDetalleIngresos.Item(7, e.RowIndex).Value <> "PENDIENTE" And
           dgvDetalleIngresos.Item(7, e.RowIndex).Value <> "TERMINADO" Then
            e.CellStyle.SelectionForeColor = dgvDetalleIngresos.Rows(e.RowIndex).DefaultCellStyle.ForeColor 'Color.Yellow
            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        Else
            e.CellStyle.SelectionForeColor = Color.Yellow
            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboRango_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRango.SelectionChangeCommitted
        modProcedimientos.listarMov_Ingreso(dgvDetalleIngresos, lblCodCaja.Text, cboRango.Text, cboAnio.Text)
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        If cboAnio.Text <> anioActual Then
            modProcedimientos.listarMov_Ingreso(dgvDetalleIngresos, lblCodCaja.Text, "Mes", cboAnio.Text)
            cboRango.Text = ""
            cboRango.Enabled = False
        Else
            modProcedimientos.listarMov_Ingreso(dgvDetalleIngresos, lblCodCaja.Text, "Mes", cboAnio.Text)
            cboRango.Text = "Mes"
            cboRango.Enabled = True
        End If
    End Sub

    Private Sub FrmListaIngresos_Resize(sender As Object, e As EventArgs) Handles Me.Resize


        lblTextoEncabezado.Width = Panel2.Width - 50

        With dgvDetalleIngresos
            Dim ancho As Integer = .Width - 20

            .Columns(0).Width = (ancho * 4) / 100
            .Columns(1).Width = (ancho * 16) / 100
            .Columns(2).Width = (ancho * 32) / 100
            .Columns(3).Width = (ancho * 12) / 100
            .Columns(4).Width = (ancho * 6) / 100
            .Columns(5).Width = (ancho * 10) / 100
            .Columns(6).Width = (ancho * 10) / 100
            .Columns(7).Width = (ancho * 10) / 100
        End With
    End Sub

    Private Sub cboAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedIndexChanged

    End Sub

    Private Sub dgvDetalleIngresos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleIngresos.CellContentClick

    End Sub
End Class