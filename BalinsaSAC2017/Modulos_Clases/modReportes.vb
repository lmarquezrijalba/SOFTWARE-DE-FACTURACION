Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Module modReportes
    Dim rutaReporte As String
    Dim rpt_id As New ReportDocument

    Public Sub cargarRPT_CierreCaja(ByVal Visualizador As CrystalReportViewer, ByVal IDCaja As String)
        Try
            If NOMB_VENTANA_ACTIVA = "Reporte Egresos" Then
                rutaReporte = objFunciones.GetRutaAbsoluta & "\Reportes\crEgresos_x_Caja.rpt" 'Application.StartupPath & "\Formularios\Reportes\..\..\rptProforma.rdlc"
                'objFunciones.GetRutaAbsoluta & "\Formularios\Reportes\crEgresos_x_Caja.rpt"

                If Not IO.File.Exists(rutaReporte) Then 'vbCrLf & rutaReporte, _
                    MsgBox("No se puede abrir el reporte" & vbNewLine & vbNewLine & _
                           "El reporte no existe, o no se encuentra en la carpeta del sistema.", vbCritical, "¡Error!")

                    Exit Sub
                Else
                    rpt_id.Load(rutaReporte)
                    modConexion.Conectar_DBLogon(cnnInfo, rpt_id)

                    'ENVIAMOS VARIABLES A CR
                    '------------------------
                    rpt_id.SetParameterValue("IDCaja", IDCaja)

                    'ASIGNO EL REPORTE AL VISOR
                    '---------------------------
                    Visualizador.ReportSource = rpt_id
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error en el reporte")
        End Try
    End Sub

    Public Sub cargarRPT_Cotizacion(ByVal Visualizador As CrystalReportViewer, ByVal IDCotizacion As String)
        Try
            If NOMB_VENTANA_ACTIVA = "Vista Previa Cotizacion" Then
                rutaReporte = objFunciones.GetRutaAbsoluta & "\Reportes\rptCotizaciones.rpt"

                If Not IO.File.Exists(rutaReporte) Then 'vbCrLf & rutaReporte, _
                    MsgBox("No se puede abrir el reporte" & vbNewLine & vbNewLine & _
                           "El reporte no existe, o no se encuentra en la carpeta del sistema.", vbCritical, "¡Error!")

                    Exit Sub
                Else
                    rpt_id.Load(rutaReporte)
                    modConexion.Conectar_DBLogon(cnnInfo, rpt_id)

                    'ENVIAMOS VARIABLES A CR
                    '------------------------
                    rpt_id.SetParameterValue("IDCot", IDCotizacion)

                    'ASIGNO EL REPORTE AL VISOR
                    '---------------------------
                    Visualizador.ReportSource = rpt_id
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error en el reporte")
        End Try
    End Sub
End Module
