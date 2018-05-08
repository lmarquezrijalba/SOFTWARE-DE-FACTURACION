Imports System.Data.SqlClient

Public Class FrmActualizarCaja

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdRegistrarAprobar_Click(sender As Object, e As EventArgs) Handles cmdRegistrarAprobar.Click
        Dim sqlRegistrar, sqlOperacion, sqlCajas As String
        Dim OPNro, IDCaja, NombCaja, Tipo, Fecha, Detalle, Concepto, Proveniente As String

        Dim QuedaSoles, Soles, QuedaDolares, Dolares As Double
        Dim Mes As String

        Mes = Format(Now, "MM")
        IDCaja = lblIDCaja.Text
        Fecha = Format(CDate(txtFecha.Text & " " & Format(Now, "H:mm:ss")), "dd/MM/yyyy H:mm:ss")
        NombCaja = lblNombCaja.Text

        sqlCajas = "SELECT * FROM tb_cajas WHERE CAJ_Aperturado <> 2"

        'OBTENEMOS LOS DATOS DE LA "CAJA A INGRESAR"
        '-------------------------------------------
        QuedaSoles = Format(MONTO_ACT_CAJASEL_SOL, "#,##0.00") 'dt.Rows(0).Item("DCAJ_MontoActual_Soles")
        QuedaDolares = Format(MONTO_ACT_CAJASEL_USD, "#,##0.00") 'dt.Rows(0).Item("DCAJ_MontoActual_Dolares")
        Soles = CDbl(txtMontoSoles.Text)
        Dolares = CDbl(txtMontoDolares.Text)
        Detalle = "SE REGISTRÓ UN MONTO DE S/ " & Format(Soles, "#,##0.00") & " Y $ " & Format(Dolares, "#,##0.00") '& " HACIA " & NombCaja
        Proveniente = txtProveniente.Text
        Tipo = "I"
        Concepto = "I002"

        '------GENERAR CODIGO DE OPERACION------
        '---------------------------------------
        sqlOperacion = "SELECT COUNT(MCAJ_Codigo) FROM tb_movimiento_cajas " & _
                       "WHERE CAJ_Codigo='" & IDCaja & "' AND " & _
                       "DATEPART(MONTH, MCAJ_FechaHora)='" & Mes & "' AND " & _
                       "MCAJ_Tipo='I'"

        OPNro = objFunciones.Generar_Codigo(sqlOperacion, "0000")

        sqlRegistrar = "INSERT INTO tb_movimiento_cajas(MCAJ_NroOperacion, CAJ_Codigo, CON_Codigo, MCAJ_Pagador, " & _
                       "MCAJ_Recibidor, MCAJ_Tipo, MCAJ_FechaHora, MCAJ_MontoSoles, MCAJ_MontoDolares, " & _
                       "MCAJ_Detalle, MCAJ_Proveniente, MCAJ_Activo) VALUES('" & OPNro & "', '" & IDCaja & "', '" & Concepto & "', '" & _
                       USU_CODIGO & "', '" & USU_CODIGO & "', '" & Tipo & "', '" & Fecha & "', '" & objFunciones.convertMoneda(Soles) & "', '" & _
                       objFunciones.convertMoneda(Dolares) & "', '" & Detalle & "', '" & Proveniente & "', '" & 0 & "')"

        If Len(txtProveniente.Text) = 0 Then
            MsgBox("No se pudo registrar el ingreso." & vbNewLine & vbNewLine & _
                   "Por favor ingrese de donde proviene el dinero a ser registrado.", vbCritical, "Error")

            txtProveniente.Focus()
        ElseIf IsNothing(txtMontoSoles.Text) Then
            MsgBox("No se pudo registrar el ingreso." & vbNewLine & vbNewLine & _
                   "El valor a ingresar no puede ser un valor vacio", vbCritical, "Error")

            txtMontoSoles.Focus()
        ElseIf IsNothing(txtMontoDolares.Text) Then
            MsgBox("No se pudo registrar el ingreso." & vbNewLine & vbNewLine & _
                   "El valor a ingresar no puede ser un valor vacio", vbCritical, "Error")

            txtMontoDolares.Focus()
        Else
            If CDbl(txtMontoSoles.Text) <> 0 Or CDbl(txtMontoDolares.Text) <> 0 Then
                If objFunciones.Ejecutar(sqlRegistrar) Then
                    txtProveniente.Text = ""
                    txtMontoSoles.Text = "0,00"
                    txtMontoDolares.Text = "0,00"

                    modProcedimientos.crearBotones(sqlCajas, FrmAperturarCaja.panelCajas, 205, 132, 5)

                    Me.Close()
                End If
            Else
                MsgBox("No se pudo ingresar el monto asignado." & vbNewLine & vbNewLine & _
                       "El monto a ingresar debe ser mayor a cero para poder realizar el ingreso", vbCritical, "¡Corregir!")
            End If
        End If
    End Sub

    Private Sub FrmActualizarCaja_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtProveniente.Focus()
        txtFecha.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub FrmActualizarCaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub txtProveniente_Click(sender As Object, e As EventArgs) Handles txtProveniente.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtProveniente)
    End Sub

    Private Sub txtProveniente_GotFocus(sender As Object, e As EventArgs) Handles txtProveniente.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtProveniente)
    End Sub

    Private Sub txtProveniente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProveniente.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtProveniente, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtMontoSoles_Click(sender As Object, e As EventArgs) Handles txtMontoSoles.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoSoles)
    End Sub

    Private Sub txtMontoSoles_GotFocus(sender As Object, e As EventArgs) Handles txtMontoSoles.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoSoles)
    End Sub

    Private Sub txtMontoSoles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoSoles.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtMontoSoles)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtMontoDolares_Click(sender As Object, e As EventArgs) Handles txtMontoDolares.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoDolares)
    End Sub

    Private Sub txtMontoDolares_GotFocus(sender As Object, e As EventArgs) Handles txtMontoDolares.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoDolares)
    End Sub

    Private Sub txtMontoDolares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoDolares.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtMontoDolares)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtMontoSoles_LostFocus(sender As Object, e As EventArgs) Handles txtMontoSoles.LostFocus
        txtMontoSoles.Text = Format(CDbl(txtMontoSoles.Text), "#,##0.00")
    End Sub

    Private Sub txtMontoDolares_LostFocus(sender As Object, e As EventArgs) Handles txtMontoDolares.LostFocus
        txtMontoDolares.Text = Format(CDbl(txtMontoDolares.Text), "#,##0.00")
    End Sub
End Class