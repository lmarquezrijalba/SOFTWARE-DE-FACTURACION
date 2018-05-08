Imports System.Data.SqlClient

Public Class FrmAcceso
    Dim sqlLogin As String
    Dim CONT As Integer = 1
    'Dim conexion As String

    Private Sub cmdAccesar_Click(sender As Object, e As EventArgs) Handles cmdAccesar.Click
        Dim pass, login As String

        Try
            login = txtUsuario.Text
            pass = objEncriptacion.Encripta(txtContrasena.Text)

            sqlLogin = "SELECT U.USU_Codigo, U.USU_Login, U.USU_Contrasena, " & _
                       "U.USU_ApePaterno+' '+U.USU_ApeMaterno+' '+U.USU_Nombres AS NombreCompleto, " & _
                       "U.USU_Nombres, U.USU_Activo, NU.NUSU_Codigo, " & _
                       "NU.NUSU_Descripcion, NU.NUSU_Administra " & _
                       "FROM tb_usuarios U, tb_niv_usuarios NU " & _
                       "WHERE U.NUSU_Codigo = NU.NUSU_Codigo AND " & _
                       "U.USU_Login = '" & login & "' AND " & _
                       "U.USU_Contrasena='" & pass & "' AND " & _
                       "U.USU_Activo='" & 1 & "'"

            modConexion.Conectar_Servidor()

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlLogin, cnn)
            sqlda.Fill(dt)

            cnn.Close()

            If (txtUsuario.Text = "") Then
                MsgBox("Ingrese su nombre de usuario.", vbExclamation, "Completar")
                txtUsuario.Focus()
            ElseIf (txtContrasena.Text = "") Then
                MsgBox("Ingrese su contraseña.", vbExclamation, "Completar")
                txtContrasena.Focus()
            Else
                If dt.Rows.Count > 0 Then '<---SI LA VALIDACIÓN FUE EXITOSA
                    USU_CODIGO = dt.Rows(0).Item("USU_Codigo")
                    USU_LOGIN = dt.Rows(0).Item("USU_Login")
                    USU_NOMBRE = dt.Rows(0).Item("USU_Nombres")
                    USU_NOMBRE_LARGO = dt.Rows(0).Item("NombreCompleto")
                    USU_CONTRASENA = objEncriptacion.DesEncripta(CStr(dt.Rows(0).Item("USU_Contrasena")))
                    USU_COD_NIVEL = dt.Rows(0).Item("NUSU_Codigo")
                    USU_NIVEL = dt.Rows(0).Item("NUSU_Descripcion")
                    ADMISTRA_SISTEM = dt.Rows(0).Item("NUSU_Administra")

                    If USU_LOGIN <> txtUsuario.Text Then
                        MsgBox("El usuario " & txtUsuario.Text & " no se encuentra registrado en el sistema.",
                               vbCritical, "Verifique!")
                        txtUsuario.Focus()
                    ElseIf USU_CONTRASENA <> txtContrasena.Text Then
                        MsgBox("La contraseña ingresada no es la correcta, corrijala.",
                               vbCritical, "Verifique!")
                        txtContrasena.Focus()
                    Else

                    End If

                    'ACTUALIZAMOS ESTADO A "CONECTADO"
                    '----------------------------------
                    Dim SQLConectado As String = "UPDATE tb_usuarios SET " & _
                                                 "USU_Conectado='" & 1 & "' " & _
                                                 "WHERE USU_Codigo='" & USU_CODIGO & "'"

                    If objFunciones.Ejecutar(SQLConectado) Then
                        'INICIO DE SESION
                        '------------------------------------------
                        If Inicio_Session = False Then
                            CONT = 1
                            Inicio_Session = True

                            If chkRecordarUser.Checked Then
                                My.Settings.recordarUser = True
                                My.Settings.miUsuario = txtUsuario.Text
                            Else
                                My.Settings.recordarUser = False
                                My.Settings.miUsuario = ""
                            End If

                            My.Settings.Save()
                            My.Settings.Reload()

                            MDIPrincipal.Show()
                        End If
                    End If
                Else
                    If CONT < 3 Then
                        MsgBox("Contraseña y/o usuario incorecto. Tiene (" & 3 - CONT & ") intentos más" & vbNewLine & _
                               "Por favor intente nuevamente.", vbInformation, "Error de autenticación")

                        modProcedimientos.SELEC_TODO_TEXTO(txtUsuario)
                    Else
                        End
                    End If

                    CONT += 1
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "FrmAccesar, cmdAccesar_Click()")
        End Try
    End Sub

    Private Sub FrmAcceso_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'txtUsuario.Focus()
        chkRecordarUser.Checked = My.Settings.recordarUser
        txtUsuario.Text = My.Settings.miUsuario

        If txtUsuario.Text = "" Then
            txtUsuario.Focus()
        Else
            txtContrasena.Focus()
        End If

        MDIPrincipal.tmrCambios_en_Permisos.Stop()

        If Inicio_Session = False Then
            MDIPrincipal.Hide()
        End If
    End Sub

    Private Sub FrmAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MDIPrincipal.tmrCambios.Enabled = False
        Me.Focus()

        If Not IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory() & "Boot.INI") Then
            FrmConfigConexion.ShowDialog()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtUsuario_Click(sender As Object, e As EventArgs) Handles txtUsuario.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtUsuario)
    End Sub

    Private Sub txtUsuario_GotFocus(sender As Object, e As EventArgs) Handles txtUsuario.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtUsuario)
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        modProcedimientos.Saltar(e)
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

    Private Sub chkRecordarUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles chkRecordarUser.KeyPress
        modProcedimientos.Saltar(e)
    End Sub
End Class
