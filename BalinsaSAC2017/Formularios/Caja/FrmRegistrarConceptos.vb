Public Class FrmRegistrarConceptos
    Dim sqlConceptos As String
    Dim ID_Concepto As String

    Private Sub FrmConceptos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If MDIPrincipal.mnuOperacionesCajas.Enabled = True Then
        cboTipo.Visible = True
        lblTipo.Visible = True
        txtConcepto.Left = 74
        lblConcepto.Left = 74

        sqlConceptos = "SELECT CON_Codigo, CON_Descripcion, CON_Tipo " & _
                       "FROM tb_conceptos"
        'Else
        'cboTipo.Visible = False
        'lblTipo.Visible = False
        'txtConcepto.Left = 19
        'lblConcepto.Left = 19

        'sqlConceptos = "SELECT CON_Codigo, CON_Descripcion, CON_Tipo " & _
        '               "FROM tb_conceptos " & _
        '               "WHERE CON_Codigo<>'0' AND CON_Tipo='E'"
        'End If

        modProcedimientos.listarConceptos(dgvConceptos, sqlConceptos)
    End Sub

    Private Sub FrmConceptos_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If objFunciones.estaVentanaAbierta(FrmRegistrarMovimientos) Then
            With FrmRegistrarMovimientos
                modProcedimientos.llenarConceptosdeCajaxTipo(.cboConceptos)
            End With
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub FrmRegistrarConceptos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmConceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'modProcedimientos.setearGrida(dgvConceptos)
    End Sub

    Private Sub txtConcepto_Click(sender As Object, e As EventArgs) Handles txtConcepto.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtConcepto)
    End Sub

    Private Sub txtConcepto_GotFocus(sender As Object, e As EventArgs) Handles txtConcepto.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtConcepto)
    End Sub

    Private Sub txtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConcepto.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtConcepto, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click

        Dim codGenerado As String
        Dim ID As String = txtConcepto.Text
        Dim Tipo As String

        'AUTOGERAR CODIGO DEL CONCEPTO
        '-----------------------------
        Dim sqlGenerar As String = "SELECT COUNT(CON_Codigo) FROM tb_conceptos"
        Dim sqlRegNiveles As String : Dim sqlModNiveles As String
        Dim sqlVerificar As String = "SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Descripcion='" & ID & "'"

        Tipo = cboTipo.Text
        codGenerado = objFunciones.Generar_Codigo(sqlGenerar, "000", Mid(txtConcepto.Text, 1, 1))
        sqlRegNiveles = "INSERT INTO tb_conceptos (CON_Codigo, CON_Tipo, CON_Descripcion, CON_RetornaDin) " & _
                        "VALUES('" & codGenerado & "', '" & Tipo & "', '" & txtConcepto.Text & "', '" & _
                        chkRetornaDinero.Checked & "')"
        sqlModNiveles = "UPDATE tb_conceptos SET " & _
                        "CON_Tipo='" & Tipo & "', " & _
                        "CON_Descripcion='" & txtConcepto.Text & "', " & _
                        "CON_RetornaDin='" & chkRetornaDinero.Checked & "' " & _
                        "WHERE CON_Codigo='" & ID_Concepto & "'"

        Try
            If cmdRegistrar.Text = "Registrar" Then
                If objFunciones.verificarRegistro(sqlVerificar) = False Then
                    If (objFunciones.Ejecutar(sqlRegNiveles)) Then
                        modProcedimientos.listarConceptos(dgvConceptos, sqlConceptos)

                        txtConcepto.Text = ""
                        txtConcepto.Focus()
                        chkRetornaDinero.Checked = False

                        cmdRegistrar.Enabled = False
                    End If
                Else
                    MsgBox("El concepto " & ID & " ya se encuentra registrado", vbCritical, "¡Aviso!")
                    txtConcepto.Focus()
                End If
            ElseIf cmdRegistrar.Text = "Modificar" Then
                If MsgBox("Desea cambiar los datos del concepto", vbQuestion + vbYesNo + vbDefaultButton2) = vbYes Then
                    If (objFunciones.Ejecutar(sqlModNiveles)) Then
                        MsgBox("Hecho." & vbNewLine & vbNewLine & _
                               "Los datos del concepto " & txtConcepto.Text & " se modificarón correctamente.", vbInformation, "Correcto")
                    End If
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub dgvConceptos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConceptos.CellEnter
        Dim fila As Integer = e.RowIndex

        With dgvConceptos
            If fila >= 0 Then
                ID_Concepto = CStr(.Item(0, fila).Value.ToString)
                txtConcepto.Text = CStr(.Item(1, fila).Value.ToString)
                cboTipo.Text = CStr(.Item(2, fila).Value.ToString)
                cmdRegistrar.Text = "Modificar"
                cmdNuevo.Enabled = True
            End If
        End With
    End Sub

    Private Sub dgvConceptos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvConceptos.KeyDown

        Dim fila As Integer
        Dim sqlDelete As String

        If e.KeyCode = 46 Then
            'Dim fila1 As 
            With dgvConceptos
                If .Rows.Count > 0 Then
                    fila = dgvConceptos.CurrentRow.Index

                    If Not IsNothing(.CurrentRow) Then

                        sqlDelete = "DELETE FROM tb_conceptos WHERE CON_Codigo='" & _
                                      dgvConceptos.Item(0, fila).Value & "'"

                        If Trim(CStr(dgvConceptos.Item(0, fila).Value)) <> "0" And _
                           Trim(CStr(dgvConceptos.Item(0, fila).Value)) <> "T001" And _
                           Trim(CStr(dgvConceptos.Item(0, fila).Value)) <> "A007" And _
                           Trim(CStr(dgvConceptos.Item(0, fila).Value)) <> "I002" Then
                            If MsgBox("Realmente deseas quitar la fila seleccionada.", _
                                      vbQuestion + vbYesNo + vbDefaultButton2, "Quitar elemento") = vbYes Then

                                '.Rows.RemoveAt(.CurrentRow.Index)
                                .Rows.RemoveAt(fila)

                                If (objFunciones.Ejecutar(sqlDelete)) Then
                                    dgvConceptos.Focus()
                                End If
                            End If
                        Else
                            MsgBox("Eliminación denegada." & vbNewLine & vbNewLine & _
                                   "El concepto no puede ser eliminado, por ser parte del sistema.", vbCritical, "Prohibido")
                        End If
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub txtConcepto_TextChanged(sender As Object, e As EventArgs) Handles txtConcepto.TextChanged
        If cboTipo.Visible = True Then
            If Len(txtConcepto.Text) > 0 And cboTipo.Text <> "" Then
                cmdRegistrar.Enabled = True
            Else
                cmdRegistrar.Enabled = False
            End If
        Else
            If Len(txtConcepto.Text) > 0 Then
                cmdRegistrar.Enabled = True
            Else
                cmdRegistrar.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        cmdRegistrar.Text = "Registrar"
        cmdNuevo.Enabled = False
    End Sub
End Class