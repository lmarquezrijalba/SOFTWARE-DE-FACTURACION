Imports System.Data.SqlClient

Public Class FrmListaCotizaciones
    Dim filaSelecCot As Integer
    Dim IDCotiz As String = ""
    Dim SQLCotizaciones As String = ""

    Dim Sel As Boolean = False

    Private Sub FrmListaCotizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim column As DataGridViewColumn
        With dgvCotizaciones
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            '.CellBorderStyle = DataGridViewCellBorderStyle.None

            For Each column In .Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With
    End Sub

    Private Sub dgvCotizaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCotizaciones.CellDoubleClick
        Dim IDCotizacion As String = ""

        If MDIPrincipal.mnuAbrirCotizaciones.Enabled Then
            With dgvCotizaciones
                If e.RowIndex >= 0 Then
                    Cursor = Cursors.WaitCursor

                    IDCotizacion = .Item(0, e.RowIndex).Value

                    With FrmReportes
                        NOMB_VENTANA_ACTIVA = "Vista Previa Cotizacion"
                        modReportes.cargarRPT_Cotizacion(.CrystalReportViewer1, IDCotizacion)

                        .panelCajas.Visible = False
                        .ShowDialog()

                        Cursor = Cursors.Default
                    End With
                End If
            End With
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdAprobar_Click(sender As Object, e As EventArgs) Handles cmdAprobar.Click
        Dim SQLAprobar As String

        With dgvCotizaciones
            Dim IDCotizacion As String = .Item(0, MARCAR_FILA).Value

            SQLAprobar = "UPDATE tb_cotizaciones SET COT_Estado='2' WHERE COT_Codigo='" & IDCotizacion & "'"

            If MsgBox("Esta apunto de aprobar la cotización:" & vbNewLine & vbNewLine & _
                      "Nro. " & IDCotizacion & "." & vbNewLine & _
                      "De aprobar dicha cotización pasará de la lista de cotizaciones pendientes, " & _
                      "hacia la lista de cotizaciones aprobadas. " & vbNewLine & vbNewLine & _
                      "Confirma la aprobación ?", vbQuestion + vbYesNo + vbDefaultButton1, _
                      "Confirmar") = vbYes Then

                If objFunciones.Ejecutar(SQLAprobar) Then
                    SQLCotizaciones =
                    "SELECT Co.COT_Codigo, Co.COT_Fecha, Co.COT_Descripcion, Co.COT_Moneda, Co.COT_Importe, " & _
                    "(Co.COT_Importe * (CAST(Co.COT_IGV AS FLOAT) / 100)) AS ImporteIGV, " & _
                    "Co.COT_CONIGV, Co.COT_CONINST, U.USU_Nombres, Co.COT_estado " & _
                    "FROM tb_cotizaciones Co, tb_usuarios U " & _
                    "WHERE Co.USU_Codigo=U.USU_Codigo AND " & _
                    "SUBSTRING(Co.COT_Codigo, 1, 8)='" & Mid(IDCotizacion, 1, 8) & "'"

                    modProcedimientos.listarTodasCotizaciones(SQLCotizaciones, dgvCotizaciones)
                    'modProcedimientos.listarCotizaciones(SQLCotizaciones, dgvCotizados)
                End If
            End If
        End With
    End Sub

    Private Sub dgvCotizaciones_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCotizaciones.CellFormatting
        With dgvCotizaciones
            e.CellStyle.SelectionBackColor = .Rows(e.RowIndex).DefaultCellStyle.BackColor

            If .Item(7, e.RowIndex).Value <> "APROBADA" Then
                e.CellStyle.SelectionForeColor = Color.Black
                'e.CellStyle.SelectionForeColor = .Rows(e.RowIndex).DefaultCellStyle.ForeColor 'Color.Yellow
                'e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
            Else
                e.CellStyle.SelectionForeColor = Color.Yellow
            End If

            e.CellStyle.Font = New Drawing.Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
        End With
    End Sub

    Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
        If chkTodas.Checked Then
            SQLCotizaciones =
            "SELECT Co.COT_Codigo, Co.COT_Fecha, Co.COT_Descripcion, Co.COT_Moneda, Co.COT_Importe, " & _
            "(Co.COT_Importe * (CAST(Co.COT_IGV AS FLOAT) / 100)) AS ImporteIGV, " & _
            "Co.COT_CONIGV, Co.COT_CONINST, U.USU_Nombres, Co.COT_estado " & _
            "FROM tb_cotizaciones Co, tb_usuarios U " & _
            "WHERE Co.USU_Codigo=U.USU_Codigo"
        Else
            SQLCotizaciones =
            "SELECT Co.COT_Codigo, Co.COT_Fecha, Co.COT_Descripcion, Co.COT_Moneda, Co.COT_Importe, " & _
            "(Co.COT_Importe * (CAST(Co.COT_IGV AS FLOAT) / 100)) AS ImporteIGV, " & _
            "Co.COT_CONIGV, Co.COT_CONINST, U.USU_Nombres, Co.COT_estado " & _
            "FROM tb_cotizaciones Co, tb_usuarios U " & _
            "WHERE Co.USU_Codigo=U.USU_Codigo AND " & _
            "SUBSTRING(Co.COT_Codigo, 1, 8)='" & Mid(MDIPrincipal.dgvCotizados.Item(0, MDIPrincipal.dgvCotizados.CurrentRow.Index).Value, 1, 8) & "'"
        End If

        modProcedimientos.listarTodasCotizaciones(SQLCotizaciones, dgvCotizaciones)
    End Sub

    Private Sub dgvCotizaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCotizaciones.CellClick
        MARCAR_FILA = e.RowIndex
    End Sub

    Private Sub cmdModificarCot_Click(sender As Object, e As EventArgs) Handles cmdModificarCot.Click
        Dim numCot As Integer = 0 : Dim numDetCot As Integer = 0
        Dim subTotal As Double = 0 : Dim Tot As Double = 0
        Dim MontoIGV As Double = 0 : Dim Materia As Double = 0

        Try
            IDCotiz = dgvCotizaciones.Item(0, MARCAR_FILA).Value

            If dgvCotizaciones.Item(7, MARCAR_FILA).Value <> "APROBADA" Then
                Dim SQLDatosCotizados As String =
                "SELECT Co.COT_Codigo, C.CLI_Codigo, C.CLI_RazonSocial AS Cliente, " & _
                "U.USU_Codigo, U.USU_Nombres AS Registro, Co.COT_PORMAT, " & _
                "Co.COT_Garantia, Co.COT_Fecha, Co.COT_Dias, Co.COT_Valides, Co.COT_IGV, " & _
                "Co.COT_CONINST, Co.COT_CONIGV, Co.COT_VERPREC, Co.COT_Moneda, " & _
                "Co.COT_FormaPago, Co.COT_Descripcion, Co.COT_Observacion, Co.COT_Estado " & _
                "FROM tb_cotizaciones Co, tb_clientes C, tb_usuarios U " & _
                "WHERE Co.CLI_Codigo=C.CLI_Codigo AND " & _
                "Co.USU_Codigo=U.USU_Codigo AND " & _
                "Co.COT_Codigo='" & IDCotiz & "'"

                dtaux = New Data.DataTable
                sqlda = New SqlDataAdapter(SQLDatosCotizados, cnn)
                sqlda.Fill(dtaux)

                numCot = dtaux.Rows.Count

                Dim SQLDetalle As String =
                "SELECT Dc.DCOT_Codigo, P.PRD_Codigo, P.PRD_Nombre, Dc.DCOT_Precio, Dc.DCOT_Cant, " & _
                "(Dc.DCOT_Precio * Dc.DCOT_Cant) AS Importe " & _
                "FROM tb_detalle_cotizaciones Dc, tb_productos P " & _
                "WHERE DC.PRD_Codigo=P.PRD_Codigo AND " & _
                "Dc.COT_Codigo='" & IDCotiz & "' AND " & _
                "Dc.DCOT_Activo='1'"

                modProcedimientos.listar_Detalle_Cotizacion(SQLDetalle, FrmProforma.dgvDetalleCotizacion)

                If numCot >= 0 Then
                    With FrmProforma
                        .lblIDCotiz.Text = dtaux.Rows(0).Item("COT_Codigo")
                        .lblIDCliente.Text = dtaux.Rows(0).Item("CLI_Codigo")
                        .txtCliente.Text = dtaux.Rows(0).Item("Cliente")
                        .lblAsesor.Text = dtaux.Rows(0).Item("Registro")
                        .txtDescripcion.Text = dtaux.Rows(0).Item("COT_Descripcion").ToString
                        .lblFecha.Text = Format(dtaux.Rows(0).Item("COT_Fecha"), "dd/MM/yyyy")

                        If CInt(dtaux.Rows(0).Item("COT_Valides")) > 9 Then
                            .cboDiasValidos.Text = CInt(dtaux.Rows(0).Item("COT_Valides"))
                        Else
                            .cboDiasValidos.Text = "0" & CInt(dtaux.Rows(0).Item("COT_Valides"))
                        End If

                        If CInt(dtaux.Rows(0).Item("COT_Dias")) > 9 Then
                            .cboDiasEntrega.Text = CInt(dtaux.Rows(0).Item("COT_Dias"))
                        Else
                            .cboDiasEntrega.Text = "0" & dtaux.Rows(0).Item("COT_Dias")
                        End If

                        .txtFormaPago.Text = dtaux.Rows(0).Item("COT_FormaPago")
                        .txtGarantia.Text = dtaux.Rows(0).Item("COT_Garantia")
                        .txtObservacion.Text = dtaux.Rows(0).Item("COT_Observacion")

                        .chkIncIGV.Checked = dtaux.Rows(0).Item("COT_CONIGV")
                        .chkIncINS.Checked = dtaux.Rows(0).Item("COT_CONINST")
                        .chkMostrarPrecios.Checked = dtaux.Rows(0).Item("COT_VERPREC")

                        If dtaux.Rows(0).Item("COT_Moneda") = "S" Then
                            .lblMoneda.Text = "SOLES"
                        ElseIf dtaux.Rows(0).Item("COT_Moneda") = "D" Then
                            .lblMoneda.Text = "DÓLARES"
                        End If

                        subTotal = objFunciones.Sumar_Columna(FrmProforma.dgvDetalleCotizacion, 5)
                        .dgvListaClientes.Visible = False
                        .cmdGuardar.Text = "Modificar proforma "
                        .panelDet.Visible = False

                        .MdiParent = MDIPrincipal
                        .Show()

                        .lblIDCotiz.Text = dtaux.Rows(0).Item("COT_Codigo")
                        .lblAsesor.Text = dtaux.Rows(0).Item("Registro")
                        .chkIncIGV.Checked = dtaux.Rows(0).Item("COT_CONIGV")
                        .chkIncINS.Checked = dtaux.Rows(0).Item("COT_CONINST")
                        .txtMateriales.Text = CInt(dtaux.Rows(0).Item("COT_PORMAT"))

                        'CALCULAMOS EL TOTAL
                        '-------------------------
                        If .chkIncIGV.Checked Then
                            MontoIGV = 0
                        Else
                            MontoIGV = subTotal * (IGV / 100)
                        End If

                        .lblSubTotal.Text = Format(subTotal, "#,##0.00")

                        Tot = subTotal + MontoIGV
                        Materia = Tot * (.txtMateriales.Text / 100)
                        .lblMateriales.Text = Format(Materia, "#,##0.00")

                        .lblIGV.Text = Format(MontoIGV, "#,##0.00")
                        .lblTotal.Text = Format(Tot + Materia, "#,##0.00")

                        'dgvCotizaciones.Rows(MARCAR_FILA).Selected = True
                    End With
                End If
            Else
                MsgBox("Aviso." & vbNewLine & vbNewLine & _
                       "No puedes modificar una cotización que ya fue aprobrada.", vbExclamation, "Aviso")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "(FrmListaCotizaciones, cmdModificarCot_Click())")
        End Try
    End Sub
End Class