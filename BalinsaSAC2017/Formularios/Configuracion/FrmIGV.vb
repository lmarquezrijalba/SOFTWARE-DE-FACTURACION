Public Class FrmIGV
    Dim sqlActualizaIGV As String
    Dim sqlActualizaIGVCONF As String

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Hide()
    End Sub

    Private Sub cmdAccesar_Click(sender As Object, e As EventArgs) Handles cmdAccesar.Click
        If IsNumeric(CDbl(txtIGV.Text)) And CDbl(txtIGV.Text) > 0 Then

            If REG_IGV = "IGV" Then
                sqlActualizaIGV = "UPDATE tb_configsis SET " & _
                                  "IGV='" & CInt(txtIGV.Text) & "' " & _
                                  "WHERE ID='UNICO'"

                IGV = txtIGV.Text
            ElseIf REG_IGV = "IGV Config" Then
                sqlActualizaIGV = "UPDATE tb_configsis SET " & _
                                  "IGVConfig='" & CInt(txtIGV.Text) & "' " & _
                                  "WHERE ID='UNICO'"

                IGV_CONFIG = txtIGV.Text
            End If

            If objFunciones.Ejecutar(sqlActualizaIGV) Then
                MDIPrincipal.tmrCambios_en_Permisos.Start()

                With FrmRegistroFactura
                    Dim subTot As Double : Dim valIGV As Double

                    .lblIGV.Text = "I.G.V. " & txtIGV.Text & "%"
                    subTot = CDbl(.lblSub.Text)

                    If NOMB_VENTANA_ACTIVA = "Emitir Factura" Then
                        valIGV = subTot * (IGV / 100)
                    Else
                        valIGV = subTot * (IGV_CONFIG / 100)
                    End If

                    .lblMontoIGV.Text = Format(valIGV, "#,##0.00")
                    .lblTot.Text = Format(subTot + valIGV, "#,##0.00")
                End With

                Me.Close()
            End If
        Else
            MsgBox("Error al establecer igv." & vbNewLine & vbNewLine & _
                   "Ingrese un valor diferente de ( cero ) para la asignación porcentual.", vbCritical, "¡Corregir!")
            txtIGV.Focus()
        End If
    End Sub

    Private Sub FrmIGV_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True

        With MDIPrincipal
            Me.Top = (.Height - Me.Height) - 50
            Me.Left = (.Width - Me.Width) - 35
        End With

        If REG_IGV = "IGV" Then
            txtIGV.Text = IGV
        ElseIf REG_IGV = "IGV Config" Then
            txtIGV.Text = IGV_CONFIG
        End If
    End Sub

    Private Sub txtIGV_Click(sender As Object, e As EventArgs) Handles txtIGV.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtIGV)
    End Sub

    Private Sub txtIGV_GotFocus(sender As Object, e As EventArgs) Handles txtIGV.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtIGV)
    End Sub

    Private Sub txtIGV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIGV.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub FrmIGV_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmIGV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class