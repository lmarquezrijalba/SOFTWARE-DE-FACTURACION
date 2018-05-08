Imports System.Data.SqlClient

Public Class FrmConfigEmpresa

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdAplicar_Click(sender As Object, e As EventArgs) Handles cmdAplicar.Click
        Dim SQLConf As String = ""
        Dim strRUC, strRS, strDireccion, strReferencia, strFonos, strCels, strEmail, strFrase As String
        Dim imagen As Byte()

        strRUC = txtRUC.Text
        strRS = txtRS.Text
        strDireccion = txtDireccion.Text
        strReferencia = txtReferencia.Text
        strFonos = txtFono.Text
        strCels = txtMoviles.Text
        strEmail = txtEmail.Text
        strFrase = txtFrase.Text
        imagen = objImagenes.ImageToByteArray(picLogo.Image)

        If cmdAplicar.Text = "Aplicar cambios" Then
            SQLConf = "INSERT INTO tb_empresa(EMP_RUC, EMP_RazonSocial, EMP_Direccion, EMP_Referencia, " & _
                      "EMP_Fijos, EMP_Moviles, EMP_Email, EMP_Frase, EMP_Logo) " & _
                      "VALUES (@RUC, @RS, @Direccion, @Referencia, @Fonos, @Cels, @Email, @Frase, @Logo)"
        ElseIf cmdAplicar.Text = "Modificar datos" Then
            SQLConf = "UPDATE tb_empresa SET " & _
                      "EMP_RazonSocial = @RS, " & _
                      "EMP_Direccion = @Direccion, " & _
                      "EMP_Referencia = @Referencia, " & _
                      "EMP_Fijos = @Fonos, " & _
                      "EMP_Moviles = @Cels, " & _
                      "EMP_Email = @Email, " & _
                      "EMP_Frase = @Frase, " & _
                      "EMP_Logo = @Logo " & _
                      "WHERE EMP_RUC = @RUC"
        End If

        Dim cmd As New SqlCommand(SQLConf, cnn)

        cmd.Parameters.Add("@RUC", SqlDbType.Char).Value = strRUC
        cmd.Parameters.Add("@RS", SqlDbType.VarChar).Value = strRS
        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = strDireccion
        cmd.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = strReferencia
        cmd.Parameters.Add("@Fonos", SqlDbType.Text).Value = strFonos
        cmd.Parameters.Add("@Cels", SqlDbType.Text).Value = strCels
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = strEmail
        cmd.Parameters.Add("@Frase", SqlDbType.VarChar).Value = strFrase
        cmd.Parameters.Add("@Logo", SqlDbType.Image).Value = imagen

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Registro Ingresado con Exito...", vbInformation, "¡Exito!")
            cmdAplicar.Text = "Modificar datos"

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            '
        End Try
    End Sub

    Private Sub FrmConfigEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sqlEmpresa As String
        Dim numReg As Integer

        Dim RUC As String
        Dim byteImagen As Byte()

        RUC = "20145236210"
        sqlEmpresa = "SELECT * FROM tb_empresa WHERE EMP_RUC='" & RUC & "'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlEmpresa, cnn)
            sqlda.Fill(dt)
            numReg = dt.Rows.Count

            If numReg > 0 Then
                cmdAplicar.Text = "Modificar datos"
                byteImagen = dt.Rows(0).Item("EMP_Logo")

                txtRUC.Text = dt.Rows(0).Item("EMP_RUC")
                txtRS.Text = dt.Rows(0).Item("EMP_RazonSocial")
                txtDireccion.Text = dt.Rows(0).Item("EMP_Direccion")
                txtReferencia.Text = dt.Rows(0).Item("EMP_Referencia")
                txtFono.Text = dt.Rows(0).Item("EMP_Fijos")
                txtMoviles.Text = dt.Rows(0).Item("EMP_Moviles")
                txtEmail.Text = dt.Rows(0).Item("EMP_Email")
                txtFrase.Text = dt.Rows(0).Item("EMP_Frase")
                picLogo.Image = objImagenes.ByteArrayToImage(byteImagen)
            Else
                MsgBox("No se ha registrado ningun dato de la empresa.", vbCritical, "No registrado")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub picLogo_Click(sender As Object, e As EventArgs) Handles picLogo.Click
        Dim rutaImagen As String

        Try
            'ofdAbrir.Filter = "Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"
            ofdAbrir.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los Archivos (*.*)|*.*"
            ofdAbrir.Title = "Seleccionar la imagen"
            ofdAbrir.ShowDialog()
            rutaImagen = ofdAbrir.FileName.ToString
            picLogo.Image = System.Drawing.Image.FromFile(rutaImagen)
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub txtRUC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRUC.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub


End Class