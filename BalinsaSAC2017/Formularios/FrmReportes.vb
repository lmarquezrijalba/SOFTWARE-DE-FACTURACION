Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmReportes
    Dim rpt_id As New ReportDocument
    Dim rutaReporte As String

    'Dim RpDatos As New CrystalDecisions.Shared.ParameterValues()

    Private Sub FrmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlCajas As String = ""

        Cursor = Cursors.Default

        If MDIPrincipal.mnuAdministraTodasCajas.Enabled Then
            sqlCajas = "SELECT '0' AS CAJ_Codigo, 'Seleccione caja disponible' AS CAJ_Nombre " & _
                       "UNION SELECT CAJ_Codigo, CAJ_Nombre " & _
                       "FROM tb_cajas"
        Else
            sqlCajas = "SELECT '0' AS CAJ_Codigo, 'Seleccione caja disponible' AS CAJ_Nombre " & _
                       "UNION SELECT CAJ_Codigo, CAJ_Nombre " & _
                       "FROM tb_cajas " & _
                       "WHERE C.USU_Codigo='" & USU_CODIGO & "'"
        End If

        modProcedimientos.llenarCajas(cboCajas, sqlCajas)
    End Sub

    Private Sub cboCajas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCajas.SelectionChangeCommitted
        modReportes.cargarRPT_CierreCaja(CrystalReportViewer1, cboCajas.SelectedValue)
    End Sub
End Class