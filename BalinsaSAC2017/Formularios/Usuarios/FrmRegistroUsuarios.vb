Public Class FrmRegistroUsuarios
    Dim COD_NIVEL As String
    Dim codGenerado As String

    Private Sub Limpiar()
        With Me
            .txtDNI.Text = ""
            .txtApPaterno.Text = ""
            .txtApMaterno.Text = ""
            .txtNombres.Text = ""
            .cboNiveles.Text = ""
            .txtDomicilio.Text = ""
            .txtFijo.Text = ""
            .txtMovil.Text = ""
            .txtLogin.Text = ""
            .txtContrasena.Text = ""
        End With
    End Sub

    Private Sub Habilitar(estado As Boolean)
        If estado Then
            txtDNI.Enabled = True
            txtApPaterno.Enabled = True
            txtApMaterno.Enabled = True
            txtNombres.Enabled = True
            cboNiveles.Enabled = True
            cmdRefrescar.Enabled = True
            txtDomicilio.Enabled = True
            txtFijo.Enabled = True
            txtMovil.Enabled = True
            dtpFechaNac.Enabled = True
            dtpFechaAlta.Enabled = True

            txtContrasena.Enabled = True

            txtDNI.Focus()
            cmdNuevo.Enabled = False
            cmdRegistrar.Enabled = True
        Else
            txtDNI.Enabled = False
            txtApPaterno.Enabled = False
            txtApMaterno.Enabled = False
            txtNombres.Enabled = False
            cboNiveles.Enabled = False
            cmdRefrescar.Enabled = False
            txtDomicilio.Enabled = False
            txtFijo.Enabled = False
            txtMovil.Enabled = False
            dtpFechaNac.Enabled = False
            dtpFechaAlta.Enabled = False

            txtContrasena.Enabled = False

            cmdNuevo.Enabled = True
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmRegistroUsuarios_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        modProcedimientos.llenarNivUsuario(cboNiveles)
        Habilitar(False)
    End Sub

    Private Sub cmdListaUsuarios_Click(sender As Object, e As EventArgs)
        'NOMB_VENTANA_ACTIVA = Me.Text
        'FrmListaUsuarios.ShowDialog()
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click

        Dim ID, FechaAlta As String
        Dim sqlVerificar, sqlRegUsuarios As String
        Dim pri_Nombre, apePaterno, pri_apeMaterno, GEN_LOGIN As String

        Try
            If Len(txtDNI.Text) < 1 And Len(txtDNI.Text) < 8 Then
                txtDNI.BackColor = Color.FromArgb(254, 92, 92)
                txtDNI.Focus()

                cmdRegistrar.Enabled = False
                Exit Sub
            ElseIf Len(txtApPaterno.Text) = 0 Then
                txtApPaterno.BackColor = Color.FromArgb(254, 92, 92)
                txtApPaterno.Focus()

                Exit Sub
            ElseIf Len(txtApMaterno.Text) = 0 Then
                txtApMaterno.BackColor = Color.FromArgb(254, 92, 92)
                txtApMaterno.Focus()

                Exit Sub
            ElseIf Len(txtNombres.Text) = 0 Then
                txtNombres.BackColor = Color.FromArgb(254, 92, 92)
                txtNombres.Focus()

                Exit Sub
            ElseIf Len(txtDomicilio.Text) = 0 Then
                txtDomicilio.BackColor = Color.FromArgb(254, 92, 92)
                txtDomicilio.Focus()

                Exit Sub
            ElseIf COD_NIVEL = "" Then
                cboNiveles.BackColor = Color.FromArgb(254, 92, 92)
                cboNiveles.Focus()

                Exit Sub
            Else
                ID = txtLogin.Text
                FechaAlta = Format(Now, "dd/MM/yyyy hh:mm:ss")
                pri_Nombre = Mid(txtNombres.Text, 1, 1)
                apePaterno = Trim(txtApPaterno.Text)
                pri_apeMaterno = Mid(txtApMaterno.Text, 1, 1)

                If txtLogin.Enabled = False Then
                    GEN_LOGIN = LCase(pri_Nombre & apePaterno & pri_apeMaterno)
                    txtLogin.Text = GEN_LOGIN
                Else
                    GEN_LOGIN = txtLogin.Text
                    txtLogin.Text = GEN_LOGIN
                End If

                'txtContrasena.Text = objEncriptacion.Encripta(txtContrasena.Text)

                sqlVerificar = "SELECT USU_Login FROM tb_usuarios WHERE USU_Login='" & GEN_LOGIN & "' OR " & _
                                           "USU_DNI='" & txtDNI.Text & "'"

                sqlRegUsuarios = "INSERT INTO tb_usuarios(USU_Codigo, NUSU_Codigo, USU_ApePaterno, " & _
                                 "USU_ApeMaterno, USU_Nombres, USU_Domicilio, USU_Telefono, USU_Movil, " & _
                                 "USU_DNI, USU_Login, USU_Contrasena, USU_FechaAlta, USU_Conectado, USU_Activo) " & _
                                 "VALUES('" & codGenerado & "','" & COD_NIVEL & "','" & txtApPaterno.Text & "','" & _
                                 txtApMaterno.Text & "','" & txtNombres.Text & "','" & _
                                 txtDomicilio.Text & "','" & txtFijo.Text & "','" & _
                                 txtMovil.Text & "','" & txtDNI.Text & "','" & txtLogin.Text & "','" & _
                                 objEncriptacion.Encripta(txtContrasena.Text) & "','" & FechaAlta & "','" & _
                                 0 & "','" & 1 & "')"

                If objFunciones.verificarRegistro(sqlVerificar) = False Then
                    If (objFunciones.Ejecutar(sqlRegUsuarios)) Then
                        MsgBox("Los datos del usuario se registrarón con exito", vbInformation, "Correcto")
                        Habilitar(False)
                    End If
                Else
                    txtLogin.Text = ""
                    txtContrasena.Text = ""

                    MsgBox("El usuario ya se encuentra registrado.", vbCritical, "¡Aviso!")
                    txtLogin.Enabled = True
                    txtLogin.Focus()
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub cboNiveles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNiveles.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub cboNiveles_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboNiveles.SelectionChangeCommitted
        Dim value As Object = cboNiveles.SelectedValue

        If (value IsNot Nothing) Then
            COD_NIVEL = CStr(value)
            cboNiveles.Enabled = False
        End If
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        Dim sqlGenerar As String
        Dim Anio As String = Format(Now, "yy")

        Limpiar()

        'AUTOGERAR CODIGO DEL CONCEPTO
        '-----------------------------
        sqlGenerar = "SELECT COUNT(USU_Codigo) FROM tb_usuarios"
        codGenerado = objFunciones.Generar_Codigo(sqlGenerar, "0000", Anio)

        lblCodUsuario.Text = codGenerado

        Habilitar(True)
    End Sub

    Private Sub cmdRefrescar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        modProcedimientos.llenarNivUsuario(cboNiveles)
        cboNiveles.Enabled = True
    End Sub

    Private Sub cmdCerrar_Click_1(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmRegistroUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFijo.MaxLength = 12
        txtMovil.MaxLength = 12
    End Sub

    Private Sub txtDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDNI.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtDNI_TextChanged(sender As Object, e As EventArgs) Handles txtDNI.TextChanged
        If Len(txtDNI.Text) >= 0 And Len(txtDNI.Text) < 8 Then
            txtDNI.BackColor = Color.FromArgb(254, 92, 92)
            txtDNI.ForeColor = Color.White
            txtDNI.Focus()
        Else
            txtDNI.BackColor = Color.White
            txtDNI.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtApPaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApPaterno.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtApPaterno, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtApPaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApPaterno.TextChanged
        If Len(txtApPaterno.Text) = 0 Then
            txtApPaterno.BackColor = Color.FromArgb(254, 92, 92)
            txtApPaterno.Focus()
        Else
            txtApPaterno.BackColor = Color.White
        End If
    End Sub

    Private Sub txtApMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApMaterno.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtApMaterno, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtApMaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApMaterno.TextChanged
        If Len(txtApMaterno.Text) = 0 Then
            txtApMaterno.BackColor = Color.FromArgb(254, 92, 92)
            txtApMaterno.Focus()
        Else
            txtApMaterno.BackColor = Color.White
        End If
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtNombres, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtNombres_TextChanged(sender As Object, e As EventArgs) Handles txtNombres.TextChanged
        If Len(txtNombres.Text) = 0 Then
            txtNombres.BackColor = Color.FromArgb(254, 92, 92)
            txtNombres.Focus()
        Else
            txtNombres.BackColor = Color.White
        End If
    End Sub

    Private Sub txtDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDomicilio.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDomicilio, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtDomicilio_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilio.TextChanged
        If Len(txtDomicilio.Text) = 0 Then
            txtDomicilio.BackColor = Color.FromArgb(254, 92, 92)
            txtDomicilio.Focus()
        Else
            txtDomicilio.BackColor = Color.White
        End If
    End Sub

    Private Sub txtFijo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFijo.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtMovil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMovil.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub dtpFechaNac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaNac.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub dtpFechaAlta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaAlta.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtLogin_TextChanged(sender As Object, e As EventArgs) Handles txtLogin.TextChanged
        If Len(txtLogin.Text) = 0 Then
            txtLogin.BackColor = Color.FromArgb(254, 92, 92)
            txtLogin.Focus()
        Else
            txtLogin.BackColor = Color.White
        End If
    End Sub

    Private Sub txtContrasena_Click(sender As Object, e As EventArgs) Handles txtContrasena.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasena)
    End Sub

    Private Sub txtContrasena_GotFocus(sender As Object, e As EventArgs) Handles txtContrasena.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtContrasena)
    End Sub

    Private Sub txtContrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        modProcedimientos.Saltar(e)
    End Sub
End Class