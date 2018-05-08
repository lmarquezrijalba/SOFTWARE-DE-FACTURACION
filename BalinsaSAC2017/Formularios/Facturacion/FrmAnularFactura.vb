Public Class FrmAnularFactura
    Dim SQLAnularFactura As String
    Dim numFACT As Integer

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    '   VALIDACIONES
    '-----------------------------
    Private Sub txtNroFactura_LostFocus(sender As Object, e As EventArgs) Handles txtNroFactura.LostFocus
        txtNroFactura.Text = objFunciones.autocompletarNumero(txtNroFactura.Text, 6, txtNroFactura)
    End Sub

    Private Sub txtTalonario_Click(sender As Object, e As EventArgs) Handles txtTalonario.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtTalonario)
    End Sub

    Private Sub txtTalonario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTalonario.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtTalonario_LostFocus(sender As Object, e As EventArgs) Handles txtTalonario.LostFocus
        txtTalonario.Text = objFunciones.autocompletarNumero(txtTalonario.Text, 4, txtTalonario)
    End Sub

    Private Sub txtNroFactura_Click(sender As Object, e As EventArgs) Handles txtNroFactura.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtNroFactura)
    End Sub

    Private Sub txtNroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroFactura.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub FrmAnularFactura_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        lblInforme.Text = ""
        txtTalonario.Focus()
    End Sub

    Private Sub cmdAnular_Click(sender As Object, e As EventArgs) Handles cmdAnular.Click
        Dim sqlNumFACT, SQLFacturas As String

        SQLFacturas = "SELECT FAC_Codigo, FAC_Fecha, FAC_Observacion, FAC_Subtotal, " & _
                      "FAC_valIGV, FAC_Total, FAC_Activo, FAC_Moneda " & _
                      "FROM tb_facturas"

        sqlNumFACT = "SELECT FAC_Codigo FROM tb_facturas " & _
                     "WHERE FAC_Codigo='" & txtTalonario.Text & txtNroFactura.Text & "' AND " & _
                     "CONVERT(VARCHAR(10), FAC_Fecha, 103)='" & Format(dtpFecha.Value, "dd/MM/yyyy") & "'"

        numFACT = objFunciones.getnumeroRegs(sqlNumFACT)

        SQLAnularFactura = "UPDATE tb_facturas SET " & _
                           "FAC_Activo='0' " & _
                           "WHERE FAC_Codigo='" & txtTalonario.Text & txtNroFactura.Text & "' AND " & _
                           "CONVERT(VARCHAR(10), FAC_Fecha, 103)='" & Format(dtpFecha.Value, "dd/MM/yyyy") & "'"

        If numFACT = 0 Then
            lblInforme.Text = "La factura Nº " & txtTalonario.Text & "-" & txtNroFactura.Text & _
                              " no se encuentra registrada en el sistema."
        Else
            If MsgBox("Esta a punto de anular la FACTURA N° " & _
                       txtTalonario.Text & "-" & txtNroFactura.Text & vbNewLine & _
                       " confirma su acción?",
                       vbQuestion + vbYesNo, "Anular Factura") = vbYes Then

                If objFunciones.Ejecutar(SQLAnularFactura) Then
                    lblInforme.Text = "La factura Nº " & txtTalonario.Text & "-" & txtNroFactura.Text & _
                                      " ha pasado al estado de (ANULADA)."
                    Me.Close()
                    modProcedimientos.listarFacturas(FrmListaFacturas.dgvListarFacturas, Format(dtpFecha.Value, "yyyy"))
                End If
            End If
        End If
    End Sub
End Class