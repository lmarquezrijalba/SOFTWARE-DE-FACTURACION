Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmEstadisticas
    Dim sqlFiltroSoles As String
    Dim numReg As Integer
    Dim TotSoles As Double
    Dim TotDolares As Double

    Dim ToolTipProvider As New ToolTip
    Dim CArea As ChartArea

    Private Sub FrmEstadisticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cboAnio
            Dim anioInicio As Integer = 2013
            Dim anioActual As Integer = Format(Now, "yyyy")

            cboAnio.Items.Clear()

            For c = anioActual To anioInicio Step -1
                cboAnio.Items.Add(c)
            Next
        End With

        cboTipo.SelectedIndex = 2
        chartEstadisticas.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
        chartEstadisticas.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Column
        cboAnio.Text = Format(Now, "yyyy")
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        Try
            Dim series As New Series
            For Each Series In chartEstadisticas.Series
                Series.Points.Clear()
            Next

            CArea = chartEstadisticas.ChartAreas(0)
            CArea.BackColor = Color.Azure
            CArea.ShadowColor = Color.Red

            '~~> Formatting X Axis
            CArea.AxisX.MajorGrid.Enabled = False   '~~> Removed the X axis major grids
            CArea.AxisX.LabelStyle.Font = New System.Drawing.Font("Tahoma", 9.0F, System.Drawing.FontStyle.Bold) '~~> Setting Font, Font Size and Italicizing
            CArea.AxisX.Interval = 1

            '~~> Formatting Y Axis
            CArea.AxisY.MajorGrid.Enabled = False   '~~> Removed the Y axis major grids
            CArea.AxisY.LabelStyle.Format = "#,##0.00" '~~> Formatting Y axis to display values in %age
            'CArea.AxisY.Interval = 4000
            Dim Mes As Integer
            For Mes = 1 To 12
                sqlFiltroSoles =
                "SELECT " & _
                "(SELECT SUM(F1.FAC_Total) FROM tb_facturas F1 " & _
                "WHERE F1.FAC_Activo='1' AND F1.FAC_Moneda='S' AND DATEPART(MONTH, F1.FAC_Fecha)='" & Mes & "' AND " & _
                "DATEPART(YEAR, F1.FAC_Fecha)='" & cboAnio.Text & "') AS Soles, " & _
                "(SELECT SUM(F2.FAC_Total) FROM tb_facturas F2 " & _
                "WHERE F2.FAC_Activo='1' AND F2.FAC_Moneda='D' AND DATEPART(MONTH, F2.FAC_Fecha)='" & Mes & "' AND " & _
                "DATEPART(YEAR, F2.FAC_Fecha)='" & cboAnio.Text & "') AS Dolares " & _
                "FROM tb_facturas " & _
                "WHERE DATEPART(YEAR, FAC_Fecha)='" & cboAnio.Text & "' " & _
                "GROUP BY DATEPART(YEAR, FAC_Fecha)"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlFiltroSoles, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    If IsNumeric(dt.Rows(0).Item("Soles")) Then
                        TotSoles = Format(CDbl(dt.Rows(0).Item("Soles")), "#,##0.00")
                    Else
                        TotSoles = 0
                    End If

                    If IsNumeric(dt.Rows(0).Item("Dolares")) Then
                        TotDolares = Format(CDbl(dt.Rows(0).Item("Dolares")), "#,##0.00")
                    Else
                        TotDolares = 0
                    End If

                    chartEstadisticas.Series("Soles").IsValueShownAsLabel = True
                    chartEstadisticas.Series("Soles").LabelForeColor = Color.Blue
                    chartEstadisticas.Series("Soles").LabelFormat = "#,##0.00"
                    chartEstadisticas.Series("Soles").Font = New System.Drawing.Font("Tahoma", 7.0F, System.Drawing.FontStyle.Bold)
                    chartEstadisticas.Series("Soles").Points.AddXY(Mid(objFunciones.obtenerNombreMes(Mes), 1, 3), TotSoles)

                    chartEstadisticas.Series("Dolares").IsValueShownAsLabel = True
                    chartEstadisticas.Series("Dolares").LabelForeColor = Color.Blue
                    chartEstadisticas.Series("Dolares").LabelFormat = "#,##0.00"
                    chartEstadisticas.Series("Dolares").Font = New System.Drawing.Font("Tahoma", 7.0F, System.Drawing.FontStyle.Bold)
                    chartEstadisticas.Series("Dolares").Points.AddXY(Mid(objFunciones.obtenerNombreMes(Mes), 1, 3), TotDolares)
                End If
            Next
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub chartEstadisticas_MouseDown(sender As Object, e As MouseEventArgs) Handles chartEstadisticas.MouseDown
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = chartEstadisticas.HitTest(e.X, e.Y)

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            ToolTipProvider.SetToolTip(chartEstadisticas, Format(h.Series.Points(h.PointIndex).YValues(0), "#,##0.00")) ', h.Series.Points(h.PointIndex).XValue & " x " & h.Series.Points(h.PointIndex).YValues(0))
        End If
    End Sub

    Private Sub cboTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipo.SelectionChangeCommitted
        With chartEstadisticas
            If cboTipo.Text = "Area" Then
                .Series(0).BorderWidth = 2
                .Series(1).BorderWidth = 2
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Area
                .Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Area
            ElseIf cboTipo.Text = "Barra" Then
                .Series(0).BorderWidth = 1
                .Series(1).BorderWidth = 1
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                .Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            ElseIf cboTipo.Text = "Columna" Then
                .Series(0).BorderWidth = 1
                .Series(1).BorderWidth = 1
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
                .Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Column
            ElseIf cboTipo.Text = "Linea" Then
                .Series(0).BorderWidth = 3
                .Series(1).BorderWidth = 3
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
                .Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
                'ElseIf cboTipo.Text = "Pie" Then
                '.Series(0).BorderWidth = 1
                '.Series(1).BorderWidth = 1
                '.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
                '.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            ElseIf cboTipo.Text = "Punto" Then
                .Series(0).BorderWidth = 1
                .Series(1).BorderWidth = 1
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Point
                .Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Point
            End If
        End With
    End Sub

    Private Sub chk3D_CheckedChanged(sender As Object, e As EventArgs) Handles chk3D.CheckedChanged
        Try
            CArea.Area3DStyle.Enable3D = chk3D.Checked
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

   
End Class