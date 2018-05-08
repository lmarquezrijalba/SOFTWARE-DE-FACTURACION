Public Class FrmConfigConexion
    Dim cadenaConexion, conexionExitosa As String

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        If objFunciones.estaVentanaAbierta(MDIPrincipal) Then
            Me.Close()
        Else
            End
        End If
    End Sub

    Private Sub cmdAplicar_Click(sender As Object, e As EventArgs) Handles cmdAplicar.Click

        'Dim ActualizarVersion As String
        MDIPrincipal.tmrCambios_en_Permisos.Stop()

        Try
            'If txtNomb_User_Server.Text = "" Then
            'MsgBox("No se pudierón aplicar los cambios." & vbNewLine & vbNewLine & _
            '       "Ingrese un nombre de usuario de servidor válido", vbCritical, "Corregir!")
            'TabControl1.SelectedIndex = 1
            'Else
            If chkSeguridadInteg.Checked Then
                cadenaConexion = "Data Source=" & txtServidor.Text & "; Initial Catalog=" & txtBD.Text & _
                                 "; Integrated Security=" & chkSeguridadInteg.Checked
            Else
                cadenaConexion = "data source=" & txtServidor.Text & "; initial catalog=" & txtBD.Text & _
                                 "; user id=" & txtUsuario.Text & "; password=" & txtContrasena.Text
            End If

            If modConexion.verificarConexion(cadenaConexion) Then
                Archivo_Ini.EscribirString("Conexion Servidor", "strConexion",
                                           objEncriptacion.Encripta(cadenaConexion))

                If chkSeguridadInteg.Checked Then
                    Archivo_Ini.EscribirString("Conexion Servidor", "Servidor",
                                               objEncriptacion.Encripta(txtServidor.Text))
                    Archivo_Ini.EscribirString("Conexion Servidor", "BaseDatos",
                                               objEncriptacion.Encripta(txtBD.Text))

                    Archivo_Ini.EscribirString("Conexion Servidor", "IntSecurity",
                                                objEncriptacion.Encripta(chkSeguridadInteg.Checked))
                Else
                    Archivo_Ini.EscribirString("Conexion Servidor", "Servidor",
                                               objEncriptacion.Encripta(txtServidor.Text))
                    Archivo_Ini.EscribirString("Conexion Servidor", "BaseDatos",
                                               objEncriptacion.Encripta(txtBD.Text))
                    Archivo_Ini.EscribirString("Conexion Servidor", "Usuario",
                                               objEncriptacion.Encripta(txtUsuario.Text))
                    Archivo_Ini.EscribirString("Conexion Servidor", "Password",
                                               objEncriptacion.Encripta(txtContrasena.Text))

                    Archivo_Ini.EscribirString("Conexion Servidor", "IntSecurity",
                                                objEncriptacion.Encripta(chkSeguridadInteg.Checked))
                End If


                'ActualizarVersion = "UPDATE tb_configsis SET versionDisponible='" & _
                '                    My.Application.Info.Version.ToString & "', " & _
                '                    "carpetaInstalador='" & lblCarpeta.Text & "' " & _
                '                    "WHERE ID='UNICO'"

                'With Archivo_Ini
                'If TabControl1.TabPages.Count > 1 Then
                'If chkSeguridadInteg.Checked Then
                '.EscribirString("Conexion Servidor", "Servidor", objEncriptacion.Encripta(txtServidor.Text))
                '.EscribirString("Conexion Servidor", "BaseDatos", objEncriptacion.Encripta(txtBD.Text))
                '.EscribirString("Conexion Servidor", "IntSecurity", chkSeguridadInteg.Checked)
                'Else
                '.EscribirString("Conexion Servidor", "Servidor", objEncriptacion.Encripta(txtServidor.Text))
                '.EscribirString("Conexion Servidor", "BaseDatos", objEncriptacion.Encripta(txtBD.Text))
                '.EscribirString("Conexion Servidor", "Usuario", objEncriptacion.Encripta(txtUsuario.Text))
                '.EscribirString("Conexion Servidor", "Password", objEncriptacion.Encripta(txtContrasena.Text))
                'End If
                'End If

                '.EscribirString("ConexRemota", "Servidor", txtIP.Text)
                '.EscribirString("ConexRemota", "RecursoCompartido", txtCarpeta.Text)
                '.EscribirString("ConexRemota", "usu", txtNomb_User_Server.Text)
                '.EscribirString("ConexRemota", "pass", objEncriptacion.Encripta(txtPass_User_Server.Text))
                '.EscribirString("ConexRemota", "rutaEjecutable", lblRutaInst_D.Text)
                '.EscribirString("ConexRemota", "carpetaInstalador", lblCarpeta.Text)

                'If objFunciones.Ejecutar(ActualizarVersion) Then
                'Shell("cmd.exe /k NET USE \\" & txtIP.Text & "\" & txtCarpeta.Text & " /user:" & System.Windows.Forms.SystemInformation.ComputerName & "\" & _
                '      txtNomb_User_Server.Text & " " & txtPass_User_Server.Text & "", AppWinStyle.Hide)

                'My.Computer.FileSystem.CopyDirectory(lblRutaInst_O.Text, lblRutaInst_D.Text,
                '                                     FileIO.UIOption.AllDialogs,
                '                                     FileIO.UICancelOption.DoNothing) ' FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                MsgBox("La conexión ha sido establecida con exito.", vbInformation, "¡Exito!")
                'instalarVersion = True
                MDIPrincipal.tmrCambios_en_Permisos.Start()
                Me.Hide()
                FrmAcceso.Show()
                'End If
                'End With
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub txtServidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServidor.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtBD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBD.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtContrasena_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub chkSeguridadInteg_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeguridadInteg.CheckedChanged
        If chkSeguridadInteg.Checked Then
            txtUsuario.Enabled = False
            txtContrasena.Enabled = False
        Else
            txtUsuario.Enabled = True
            txtContrasena.Enabled = True
        End If
    End Sub

    Private Sub txtIP_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCarpeta_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmConfigConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'With Archivo_Ini
        'txtServidor.Text = objEncriptacion.DesEncripta(.ObtenerString("Conexion Servidor", "Servidor", ""))
        'txtBD.Text = objEncriptacion.DesEncripta(.ObtenerString("Conexion Servidor", "BaseDatos", ""))
        'txtUsuario.Text = objEncriptacion.DesEncripta(.ObtenerString("Conexion Servidor", "Usuario", ""))
        'txtContrasena.Text = objEncriptacion.DesEncripta(.ObtenerString("Conexion Servidor", "Password", ""))
        'chkSeguridadInteg.Checked = CBool(.ObtenerString("Conexion Servidor", "IntSecurity", "False"))

        'txtIP.Text = .ObtenerString("ConexRemota", "Servidor", "")
        'txtCarpeta.Text = .ObtenerString("ConexRemota", "RecursoCompartido", "")
        'txtNomb_User_Server.Text = .ObtenerString("ConexRemota", "usu", "")
        'txtPass_User_Server.Text = objEncriptacion.DesEncripta(.ObtenerString("ConexRemota", "pass", ""))
        'lblRutaInst_D.Text = .ObtenerString("ConexRemota", "rutaEjecutable", "")
        'End With
    End Sub

    Private Sub FrmConfigConexion_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ''TabControl1.TabPages(0).Parent = TabControl1
        'TabPage1.Parent = TabControl1
    End Sub

    'Private Sub cmdRutaOrigen_Click(sender As Object, e As EventArgs)

    'End Sub
End Class