Imports System.Data.SqlClient

Public Class FrmRegistroRecordatorios
    'Dim Fecha_Actual, Fecha_Programada, Fecha_Dia, Fecha_Semana, Fecha_Mes As Date
    Dim Dia_Actual As String
    Dim ID As String

    Private Sub Habilitar(estado As Boolean)
        If estado Then
            txtDescripcion.Enabled = True
            dtpFecha.Enabled = True
            dtpHora.Enabled = True

            cmdNuevo.Enabled = False
            cmdRegistrar.Enabled = True
            'cmdBorrar.Enabled = False
        Else
            txtDescripcion.Enabled = False
            dtpFecha.Enabled = False
            dtpHora.Enabled = False

            cmdNuevo.Enabled = True
            cmdRegistrar.Enabled = False
            cmdBorrar.Enabled = True
        End If

    End Sub

    Private Sub FrmRegistroRecordatorios_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Fecha_Actual = Format(Now, "dd/MM/yyyy")
        'Fecha_Dia = Fecha_Actual.AddDays(1)
        'Fecha_Semana = Fecha_Actual.AddDays(7)
        'Fecha_Mes = Fecha_Actual.AddDays(30)

        Dia_Actual = Format(Now, "dddd")
    End Sub

    Private Sub FrmRegistroRecordatorios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRegistroRecordatorios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Habilitar(False)

        'modProcedimientos.setearGrida(dgvDetalle)
        modProcedimientos.listarRecordatorios_x_Usu(dgvDetalle, USU_CODIGO)
    End Sub


    Private Sub cmdNuevo_MouseLeave(sender As Object, e As EventArgs) Handles cmdNuevo.MouseLeave
        cmdNuevo.ForeColor = Color.Black
    End Sub

    Private Sub cmdNuevo_MouseMove(sender As Object, e As MouseEventArgs) Handles cmdNuevo.MouseMove
        cmdNuevo.ForeColor = Color.Blue
    End Sub

    Private Sub cmdCambiar_MouseLeave(sender As Object, e As EventArgs)
        cmdRegistrar.ForeColor = Color.Black
    End Sub

    Private Sub cmdCambiar_MouseMove(sender As Object, e As MouseEventArgs)
        cmdRegistrar.ForeColor = Color.Blue
    End Sub

    Private Sub cmdCancelar_MouseLeave(sender As Object, e As EventArgs)
        cmdCancelar.ForeColor = Color.Black
    End Sub

    Private Sub cmdCancelar_MouseMove(sender As Object, e As MouseEventArgs)
        cmdCancelar.ForeColor = Color.Blue
    End Sub

    Private Sub cmdBorrar_MouseLeave(sender As Object, e As EventArgs)
        cmdBorrar.ForeColor = Color.Black
    End Sub

    Private Sub cmdBorrar_MouseMove(sender As Object, e As MouseEventArgs)
        cmdBorrar.ForeColor = Color.Blue
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDescripcion, e)
    End Sub

    Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        Dim fila, numReg, Frec As Integer
        Dim sqlConsulta As String
        Dim Dom, Lun, Mar, Mie, Jue, Vie, Sab As Boolean

        Dim Fecha, Hora As Date

        Try
            If e.RowIndex >= 0 Then
                fila = CInt(e.RowIndex)
                ID = CStr(dgvDetalle.Item(0, fila).Value)
                sqlConsulta = "SELECT * from tb_notas_x_usuario WHERE NOT_Codigo='" & ID & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlConsulta, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count - 1

                If numReg >= 0 Then
                    cmdRegistrar.Text = "Modificar"
                    cmdRegistrar.Enabled = True
                    cmdBorrar.Enabled = True
                    Habilitar(True)

                    Frec = CInt(dt.Rows(0).Item("NOT_Frecuencia"))
                    Dom = CBool(dt.Rows(0).Item("NOT_Dom"))
                    Lun = CBool(dt.Rows(0).Item("NOT_Lun"))
                    Mar = CBool(dt.Rows(0).Item("NOT_Mar"))
                    Mie = CBool(dt.Rows(0).Item("NOT_Mie"))
                    Jue = CBool(dt.Rows(0).Item("NOT_Jue"))
                    Vie = CBool(dt.Rows(0).Item("NOT_Vie"))
                    Sab = CBool(dt.Rows(0).Item("NOT_Sab"))

                    Fecha = Format(dt.Rows(0).Item("NOT_Fecha"), "dd/MM/yyyy")
                    Hora = CDate(dt.Rows(0).Item("NOT_Hora"))

                    dtpFecha.Value = Fecha 'Format(dt.Rows(0).Item("NOT_Fecha"), "dddd dd 'de' MMMM 'de' yyyy")
                    dtpHora.Text = Hora 'Format(CDate(dt.Rows(0).Item("NOT_Hora")), "H:mm")
                    txtDescripcion.Text = CStr(dt.Rows(0).Item("NOT_Descripcion"))

                    If Frec = 0 Then
                        optDesactivado.Checked = True
                    ElseIf Frec = 1 Then
                        optDiario.Checked = True
                    ElseIf Frec = 2 Then
                        optSemanal.Checked = True
                    ElseIf Frec = 3 Then
                        optMensual.Checked = True
                    End If

                    chkDomingo.Checked = Dom
                    chkLunes.Checked = Lun
                    chkMartes.Checked = Mar
                    chkMiercoles.Checked = Mie
                    chkJueves.Checked = Jue
                    chkViernes.Checked = Vie
                    chkSabado.Checked = Sab
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub quitarChecks()
        chkDomingo.Checked = False
        chkLunes.Checked = False
        chkMartes.Checked = False
        chkMiercoles.Checked = False
        chkJueves.Checked = False
        chkViernes.Checked = False
        chkSabado.Checked = False

        gbDias.Enabled = False
    End Sub

    Private Sub optDiario_CheckedChanged(sender As Object, e As EventArgs) Handles optDiario.CheckedChanged
        quitarChecks()
    End Sub

    Private Sub optSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles optSemanal.CheckedChanged
        quitarChecks()
    End Sub

    Private Sub optMensual_CheckedChanged(sender As Object, e As EventArgs) Handles optMensual.CheckedChanged
        quitarChecks()
    End Sub

    Private Sub optDesactivado_CheckedChanged(sender As Object, e As EventArgs) Handles optDesactivado.CheckedChanged
        gbDias.Enabled = True
    End Sub

    Private Sub cmdNuev_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        dtpFecha.Value = Format(Now, "dd/MM/yyyy")
        dtpHora.Text = Format(Now, "H:mm")
        txtDescripcion.Text = ""
        txtDescripcion.Focus()

        optDesactivado.Checked = True

        chkDomingo.Checked = False
        chkLunes.Checked = False
        chkMartes.Checked = False
        chkMiercoles.Checked = False
        chkJueves.Checked = False
        chkViernes.Checked = False
        chkSabado.Checked = False

        cmdRegistrar.Text = "Registrar"
        cmdBorrar.Enabled = False
        Habilitar(True)
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim sqlSentencia As String = ""
        Dim Fech As Date
        Dim Desc, Dia, Hor As String
        Dim Frec As Integer

        Dim Dom, Lun, Mar, Mie, Jue, Vie, Sab As Boolean

        MDIPrincipal.tmrRecordatorios.Start()

        'ID = dgvDetalle.Rows.Item(0, 1)
        Fech = Format(dtpFecha.Value, "dd/MM/yyyy")
        Hor = Format(dtpHora.Value, "H:mm")
        Dia = Format(dtpFecha.Value, "dddd")
        Desc = txtDescripcion.Text

        If optDesactivado.Checked Then
            Frec = 0
        ElseIf optDiario.Checked Then
            Frec = 1
        ElseIf optSemanal.Checked Then
            Frec = 2
        ElseIf optMensual.Checked Then
            Frec = 3
        End If

        Dom = chkDomingo.Checked
        Lun = chkLunes.Checked
        Mar = chkMartes.Checked
        Mie = chkMiercoles.Checked
        Jue = chkJueves.Checked
        Vie = chkViernes.Checked
        Sab = chkSabado.Checked

        If cmdRegistrar.Text = "Registrar" Then
            sqlSentencia = "INSERT INTO tb_notas_x_usuario(USU_Codigo, NOT_Fecha, NOT_Hora, " & _
                           "NOT_Descripcion, NOT_Frecuencia, NOT_Dom, NOT_Lun, NOT_Mar, NOT_Mie, NOT_Jue, " & _
                           "NOT_Vie, NOT_Sab, NOT_Estado) VALUES('" & USU_CODIGO & "', '" & Fech & "', '" & _
                            Hor & "', '" & Desc & "', '" & Frec & "', '" & Dom & "', '" & _
                            Lun & "', '" & Mar & "', '" & Mie & "', '" & Jue & "', '" & Vie & "', '" & Sab & "', '" & _
                            1 & "')"
        Else
            sqlSentencia = "UPDATE tb_notas_x_usuario SET " & _
                           "NOT_Fecha='" & Fech & "', " & _
                           "NOT_Hora='" & Hor & "', " & _
                           "NOT_Descripcion='" & Desc & "', " & _
                           "NOT_Frecuencia='" & Frec & "', " & _
                           "NOT_Dom='" & Dom & "', " & _
                           "NOT_Lun='" & Lun & "', " & _
                           "NOT_Mar='" & Mar & "', " & _
                           "NOT_Mie='" & Mie & "', " & _
                           "NOT_Jue='" & Jue & "', " & _
                           "NOT_Vie='" & Vie & "', " & _
                           "NOT_Sab='" & Sab & "' " & _
                           "WHERE NOT_Codigo='" & ID & "'"
        End If

        'If MsgBox("Realmente desea programar el siguiente recordatorio?", vbQuestion + vbYesNo + vbDefaultButton2) = vbYes Then
        If objFunciones.Ejecutar(sqlSentencia) Then
            modProcedimientos.listarRecordatorios_x_Usu(dgvDetalle, USU_CODIGO)
            Habilitar(False)
        End If
        'End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Habilitar(False)
    End Sub

    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim sqlBorrar As String
        sqlBorrar = "UPDATE tb_notas_x_usuario SET " & _
                    "NOT_Estado='" & 0 & "' " & _
                    "WHERE NOT_Codigo='" & ID & "'"

        If MsgBox("Realmente deseas borrar?", vbYesNo + vbQuestion + vbDefaultButton2, "Confirmar") = vbYes Then
            If objFunciones.Ejecutar(sqlBorrar) Then
                modProcedimientos.listarRecordatorios_x_Usu(dgvDetalle, USU_CODIGO)
            End If
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class