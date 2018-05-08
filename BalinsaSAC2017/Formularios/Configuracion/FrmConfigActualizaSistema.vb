Public Class FrmConfigActualizaSistema
    Dim folderDlg As New FolderBrowserDialog
    Dim ofd As New OpenFileDialog
    Dim rutaInstalador As String = ""

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmConfigActualizaSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtVersion.Text = VERSION_DISPO
        lblRutaInst_O.Text = rutaInstalador
        txtCarpeta.Text = CARPETA_DESCARGA_INSTALADOR
        chkLanzarActualizacion.Checked = LANZAR_ACTUALIZACION

        'txtIP.Text = PC_SERVIDOR
        'txtNomb_User_Server.Text = PC_SERV_USU
        'txtPass_User_Server.Text = PC_SERV_PASS

        ' txtCarpeta.Text = RECURSOCOMPARTIDO
        'txtRutaInstalador.Text = RUTA_INSTALADOR
    End Sub

    Private Sub cmdAplicar_Click(sender As Object, e As EventArgs) Handles cmdAplicar.Click
        Try
            If rutaInstalador <> "" Then
                Dim arrayBytes() As Byte = System.IO.File.ReadAllBytes(rutaInstalador)
                Dim Extension As String = System.IO.Path.GetExtension(rutaInstalador)
                objPDF.guardarInstalador(txtVersion.Text, arrayBytes, Extension, chkLanzarActualizacion.Checked)

                MDIPrincipal.tmrCambios_en_Permisos.Start()
            Else
                MsgBox("No seleccionó archivo" & vbNewLine & vbNewLine & _
                       "Seleccione la ruta donde se encuentra el archivo instalador a cargar", vbCritical, "Seleccione")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub cmdRutaOrigen_Click(sender As Object, e As EventArgs) Handles cmdRutaOrigen.Click
        Dim Extension As String

        ofd.Filter = "Archivos Zip|*.zip|Archivos Exe|*.exe"
        ofd.Title = "Seleccione instalador"

        If ofd.ShowDialog = DialogResult.OK Then
            rutaInstalador = ofd.FileName 'objFunciones.obtenerSoloTituloArchivo(ofd.FileName)
            lblRutaInst_O.Text = rutaInstalador
            Extension = System.IO.Path.GetExtension(ofd.FileName)

            If Extension = ".zip" Then
                Label4.Text = "El instalador estará disponible en la siguiente dirección de carpeta de su  computador: " & _
                              RUTA_TEMP & txtCarpeta.Text '& "\instalador " & txtVersion.Text & Extension
            ElseIf Extension = ".exe" Then
                Label4.Text = "El instalador estará disponible en la siguiente dirección de carpeta de su  computador: " & _
                              RUTA_TEMP '& "\instalador " & txtVersion.Text & Extension
            End If
        End If
    End Sub

    Private Sub cmdRutaDestino_Click(sender As Object, e As EventArgs)
        'Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        'Dim posI As Integer

        'folderDlg.Description = "Seleccione la carpeta del instalador"
        'folderDlg.ShowNewFolderButton = True

        'If (folderDlg.ShowDialog() = DialogResult.OK) Then
        'CARPETA_DESCARGA_INSTALADOR = folderDlg.SelectedPath
        'txtCarpeta.Text = CARPETA_DESCARGA_INSTALADOR 'folderDlg.SelectedPath
        ''posI = InStrRev(lblRutaInst_O.Text, "\")
        ''nombreFolder = Mid(folderDlg.SelectedPath, posI + 1, Len(folderDlg.SelectedPath))
        ''lblCarpeta.Text = nombreFolder
        ''CARPETA_DESCARGA_INSTALADOR
        ''lblRutaInstalador.Text = "\\" & txtIP.Text & "\" & txtCarpeta.Text & "\Versiones\" & nombreFolder
        'End If
    End Sub

    Private Sub txtCarpeta_TextChanged(sender As Object, e As EventArgs) Handles txtCarpeta.TextChanged
        If Len(txtCarpeta.Text) > 0 Then
            Label4.Text = ""
            cmdRutaOrigen.Enabled = True
        Else
            Label4.Text = "Ingrese la carpeta donde se descargará el instalador"
            cmdRutaOrigen.Enabled = False
        End If
    End Sub
End Class