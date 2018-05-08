Public Class FrmListaArchivos
    Dim index As Integer
    Dim rutaImagen As String
    Dim RecCompartido As String

    Private Sub FrmListaArchivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imgList As New ImageList
        Dim strArch, ext, rutaArch As String
        Dim i As Integer = 0
        RecCompartido = "prueba"

        Try
            'Shell("cmd.exe /k NET USE \\" & PC_SERVIDOR & "\" & RecCompartido & " /user:" & DOMINIO_USUARIO & "\" & _
            '                  PC_SERV_USU & " " & PC_SERV_PASS & "", AppWinStyle.Hide)

            'strArch = Dir("\\" & PC_SERVIDOR & "\" & RecCompartido & "\*.*")

            rutaImagen = System.AppDomain.CurrentDomain.BaseDirectory()

            imgList.ImageSize = New Size(24, 24)
            imgList.ColorDepth = ColorDepth.Depth32Bit
            imgList.Images.Add(0, Bitmap.FromFile(rutaImagen & "\Iconos\pdf.png"))
            imgList.Images.Add(1, Bitmap.FromFile(rutaImagen & "\Iconos\word.png"))
            imgList.Images.Add(2, Bitmap.FromFile(rutaImagen & "\Iconos\excel.png"))

            With lvDocumentos
                .View = View.List
                .FullRowSelect = True
                .GridLines = True
                .MultiSelect = False

                .LargeImageList = imgList
                .SmallImageList = imgList

                Do While strArch <> Space(0)
                    rutaArch = "\\SERVER-PC\prueba\" & strArch
                    ext = System.IO.Path.GetExtension(rutaArch)

                    .Items.Add(strArch)

                    If ext = ".pdf" Then
                        .Items(i).ImageIndex = 0
                    ElseIf ext = ".doc" Or ext = ".docx" Then
                        .Items(i).ImageIndex = 1
                    ElseIf ext = ".xls" Or ext = ".xlsx" Then
                        .Items(i).ImageIndex = 2
                    End If

                    strArch = Dir()
                    i += 1
                Loop
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdAbrir_Click(sender As Object, e As EventArgs) Handles cmdAbrir.Click
        Dim ruta, nombArchivo As String

        nombArchivo = lvDocumentos.SelectedItems(0).Text
        'ruta = "\\" & PC_SERVIDOR & "\" & RecCompartido & "\" & nombArchivo

        Process.Start(ruta) '<-- ABRIMOS EL ARCHIVO SELECCIONADO
    End Sub

    Private Sub lvDocumentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvDocumentos.SelectedIndexChanged
        If lvDocumentos.SelectedItems.Count > 0 Then
            index = CInt(lvDocumentos.SelectedItems(0).Index)
        End If
    End Sub
End Class