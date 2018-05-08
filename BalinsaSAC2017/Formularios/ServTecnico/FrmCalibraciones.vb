Imports System.Data.SqlClient
Imports System.IO

Public Class FrmCalibraciones

    Private ds As DataSet
    Private da As SqlDataAdapter
    Private posicion, posicionfinal, Con As Integer
    Private IDCalibracion As String

    Dim IDCategoria, NombCategoria, SQLCalibraciones As String

    Dim sqlMarcas As String
    Dim sqlBuscaBalanza As String = "SELECT CAT_Codigo, CAT_Nombre FROM tb_categorias " & _
                                    "WHERE esBalanza='" & 1 & "'"
    Dim sqlListarModelos_x_Marca As String
    Dim ofd As New OpenFileDialog
    Dim rutaArchivo As String : Dim archivoBinario() As Byte
    Dim ofdabrir As New OpenFileDialog
    Dim numReg As Integer


    Private Sub FrmCalibraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim numReg As Integer = 0
        posicion = 0
        picImagen.SizeMode = PictureBoxSizeMode.StretchImage
        picImagen.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
        picImagen.Cursor = Cursors.Hand

        With dgvModelos
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.CellBorderStyle = DataGridViewCellBorderStyle.None

            'For Each column In .Columns
            'column.SortMode = DataGridViewColumnSortMode.NotSortable
            'Next
        End With

        Try
            dtaux = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlBuscaBalanza, cnn)
            sqlda.Fill(dtaux)

            numReg = dtaux.Rows.Count

            If numReg > 0 Then
                IDCategoria = CStr(dtaux.Rows(0).Item("CAT_Codigo").ToString)
                NombCategoria = CStr(dtaux.Rows(0).Item("CAT_Nombre").ToString)
            End If

            sqlMarcas = "SELECT MAR_Codigo, MAR_Nombre " & _
                        "FROM tb_marcas WHERE CAT_Codigo='" & IDCategoria & "'"

            modProcedimientos.llenarMarcas_x_Categoria(cboMarca, sqlMarcas)

            sqlListarModelos_x_Marca = "SELECT * FROM tb_calibraciones WHERE MAR_Codigo='" & _
                                       cboMarca.SelectedValue & "'"

            modProcedimientos.listarCalibraciones(dgvModelos, sqlListarModelos_x_Marca)
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HelpLink, ex.Message, Me.Text)
        End Try

    End Sub

    Private Sub cmdMarcas_Click(sender As Object, e As EventArgs) Handles cmdMarcas.Click
        NOMB_VENTANA_ACTIVA = "Calibraciones"

        With FrmMarcas
            .lblIDCategoria.Text = IDCategoria
            .lblTipoProducto.Text = NombCategoria

            .ShowDialog()
        End With
    End Sub

    Private Sub cboMarca_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboMarca.SelectionChangeCommitted
        MDIPrincipal.Cursor = Cursors.WaitCursor

        sqlListarModelos_x_Marca = "SELECT * FROM tb_calibraciones " & _
                                   "WHERE MAR_Codigo='" & cboMarca.SelectedValue & "'"

        modProcedimientos.listarCalibraciones(dgvModelos, sqlListarModelos_x_Marca)

        MDIPrincipal.Cursor = Cursors.Default
        'Dim sqlCalibraciones As String = "SELECT * from tb_calibraciones " & _
        '                             "WHERE CAT_Codigo='" & & "'"

        'modProcedimientos.listarModelos(Of Date, Sql)()
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdFiltrar_Click(sender As Object, e As EventArgs) Handles cmdFiltrar.Click
        ofd.Filter = "Archivos Pdf|*.pdf|Word|*.docx|Todos|*.*" '"BMP|*.bmp|GIF|*.gif|JPG|*.jpg|PNG|*.png|TIFF|*.tiff"
        ofd.Multiselect = False
        ofd.Title = "Seleccione archivo"

        If ofd.ShowDialog = DialogResult.OK Then
            'txtModelo.Text = objFunciones.obtenerSoloTituloArchivo(Trim(ofd.FileName))
            rutaArchivo = Trim(ofd.FileName)
            lblRuta.Text = rutaArchivo
        End If
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim arrayBytes() As Byte
        Dim Extension As String

        Dim sqlVerificar As String = "SELECT Modelo FROM tb_calibraciones WHERE Modelo='" & txtModelo.Text & "'"

        Try
            If cboMarca.Text = "" Then
                MsgBox("Error." & vbNewLine & vbNewLine & _
                       "Necesita seleccionar la marca de la calibración a registrar, de no " & _
                       "encontrarla en la lista registrela y vuelva a seleccionar.", vbCritical, "Verifique")
                cboMarca.Focus()
            ElseIf txtModelo.Text = "" Then
                MsgBox("Error." & vbNewLine & vbNewLine & _
                       "Necesita asignar el modelo de la calibración a registrar.", vbCritical, "Verifique")
                txtModelo.Focus()
            ElseIf lblRuta.Text = "" Then
                MsgBox("Error." & vbNewLine & vbNewLine & _
                       "Seleccione el archivo a guardar en la base de datos.", vbCritical, "Verifique")
                cmdFiltrar.Focus()
            Else
                arrayBytes = System.IO.File.ReadAllBytes(rutaArchivo)
                Extension = System.IO.Path.GetExtension(lblRuta.Text)

                If cmdRegistrar.Text = "Guardar" Then
                    If objFunciones.verificarRegistro(sqlVerificar) = False Then
                        objPDF.guardarPDFS(cboMarca.SelectedValue, txtModelo.Text, arrayBytes,
                                           objImagenes.ImageToByteArray(picImagen.Image), Extension)
                        txtModelo.Clear()
                        lblRuta.Text = ""
                        txtModelo.Enabled = False
                        cmdFiltrar.Enabled = False
                        picImagen.SizeMode = PictureBoxSizeMode.StretchImage
                        picImagen.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
                        picImagen.Cursor = Cursors.Hand
                        cmdRegistrar.Text = "Guardar"
                        cmdNuevo.Text = "Nuevo"
                        cmdRegistrar.Enabled = False
                    Else
                        MsgBox("Error al intentar registrar la calibración" & vbNewLine & vbNewLine & _
                               "El modelo " & txtModelo.Text & " ya se encuentra registrado " & _
                               "en el sistema. Verifiquelo.", vbCritical, "Ya existe.")
                    End If
                ElseIf cmdRegistrar.Text = "Modificar" Then
                    objPDF.editarPDFS(dgvModelos.Item(0, dgvModelos.CurrentRow.Index).Value,
                                      cboMarca.SelectedValue, txtModelo.Text, arrayBytes,
                                      objImagenes.ImageToByteArray(picImagen.Image), Extension)
                    txtModelo.Clear()
                    lblRuta.Text = ""
                    picImagen.SizeMode = PictureBoxSizeMode.StretchImage
                    picImagen.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
                    picImagen.Cursor = Cursors.Hand
                    cmdRegistrar.Text = "Guardar"
                    cmdNuevo.Text = "Nuevo"
                End If

                modProcedimientos.listarCalibraciones(dgvModelos, sqlListarModelos_x_Marca)
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub dgvModelos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModelos.CellContentClick
        Dim fil, col As Integer

        With dgvModelos
            fil = .CurrentCell.RowIndex
            col = .CurrentCell.ColumnIndex

            If col = 2 Then
                objPDF.descargarArchivo(dgvModelos, fil)
            End If
        End With
    End Sub

    Private Sub picImagen_Click(sender As Object, e As EventArgs) Handles picImagen.Click
        Dim rutaImagen As String

        Try
            ofdabrir.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los Archivos (*.*)|*.*"
            ofdabrir.Title = "Seleccionar la imagen"
            ofdabrir.ShowDialog()

            rutaImagen = ofdabrir.FileName

            If IO.File.Exists(rutaImagen) Then 'Windows.Forms.DialogResult.OK Then
                picImagen.Image = Image.FromFile(rutaImagen)
            Else
                picImagen.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtModelo, e)
    End Sub

    Private Sub txtModelo_TextChanged(sender As Object, e As EventArgs) Handles txtModelo.TextChanged
        lblModelo.Text = txtModelo.Text
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        If cmdNuevo.Text = "Nuevo" Then
            picImagen.SizeMode = PictureBoxSizeMode.StretchImage
            picImagen.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
            picImagen.Cursor = Cursors.Hand
            txtModelo.Text = ""
            lblRuta.Text = ""
            txtModelo.Enabled = True
            cmdFiltrar.Enabled = True
            cmdRegistrar.Enabled = True
            cmdRegistrar.Text = "Guardar"
        ElseIf cmdNuevo.Text = "Cancelar" Then
            txtModelo.Text = ""
            lblRuta.Text = ""
            txtModelo.Enabled = False
            cmdFiltrar.Enabled = False
            cmdRegistrar.Enabled = False
            cmdRegistrar.Text = "Guardar"
            picImagen.SizeMode = PictureBoxSizeMode.StretchImage
            picImagen.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
            picImagen.Cursor = Cursors.Hand

        End If
    End Sub

    Private Sub cmdEscanear_Click(sender As Object, e As EventArgs) Handles cmdEscanear.Click
        ''Al terminar el escaneo se generara un pdf, no un tif
        'Dim fileName As String 'nombre del archivo que generaremos
        'Dim N As Integer
        ''numero de escaneos seguidos que realizaremos, lo suyo es que sea 1, pero esto es a gusto del consumidor
        'N = 1
        'fileName = String.Format(rutaDondeSeGuardaraElArchivo + nombreArchivo + ".pdf", 1)
        ''ponemos la ruta, el nombre del archivo y el tipo de archivo (en este caso .pdf)

        'Call EZTwain.LogFile(1)
        'Call EZTwain.SetHideUI(1)
        'If EZTwain.OpenDefaultSource() Then
        '    Call EZTwain.SelectFeeder(1)
        '    'esta linea es la que define que es un escaner flatbed, para ponerlo ADF el 1 lo ponemos false 
        '    '(si no funciona ponganse en contacto conmigo)
        '    Call EZTwain.SetPixelType(2)
        '    'yo escaneo en color (provad con otros numeros para ver otros tipos de escaneo, como el blanco-negro)
        '    Call EZTwain.SetBitDepth(1)
        '    Call EZTwain.SetResolution(300)
        '    'resolucion de la imagen
        '    Call EZTwain.SetAutoScan(1)
        '    'ESTA LINEA ES NUESTRA SALVADORA, ya que es la encargada de decirle al escaner que escanee y punto, 
        '    'sin mostrar ventanas adicionales ni nada, que escanee con los parametros que le hemos dado y ya esta

        '    Call EZTwain.SetRegion(0, 0, 10.1, 10.1) 'area que decidimos escanear

        '    EZTwain.AcquireToFilename(Me.Handle, fileName) 'esta linea realiza el escaneo y la creacion del documento
        'End If
        'If EZTwain.LastErrorCode() <> 0 Then
        '    Call EZTwain.ReportLastError("Unable to scan.")
        'End If
    End Sub

    Private Sub dgvModelos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModelos.CellEnter

        If e.RowIndex >= 0 Then
            Con = e.RowIndex
            With dgvModelos
                IDCalibracion = .Item(0, e.RowIndex).Value

                SQLCalibraciones = "SELECT CAL_Codigo, Modelo, Imagen " & _
                                   "FROM tb_calibraciones " & _
                                   "WHERE CAL_Codigo='" & IDCalibracion & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(SQLCalibraciones, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    IDCategoria = CStr(dt.Rows(0).Item("CAL_Codigo").ToString)
                    txtModelo.Text = Trim(CStr(dt.Rows(0).Item("Modelo")).ToString)
                    picImagen.Image = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(0).Item("Imagen"), Byte()))
                End If
            End With
        End If
    End Sub

    Private Sub dgvModelos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvModelos.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            With dgvModelos
                IDCalibracion = .Item(0, e.RowIndex).Value

                SQLCalibraciones = "SELECT CAL_Codigo, Modelo, Imagen " & _
                                   "FROM tb_calibraciones " & _
                                   "WHERE CAL_Codigo='" & IDCalibracion & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(SQLCalibraciones, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    IDCategoria = CStr(dt.Rows(0).Item("CAL_Codigo").ToString)
                    txtModelo.Text = Trim(CStr(dt.Rows(0).Item("Modelo")).ToString)
                    picImagen.Image = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(0).Item("Imagen"), Byte()))
                    cmdRegistrar.Text = "Modificar"
                End If
            End With
        End If
    End Sub

    
    Private Sub dgvModelos_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModelos.CellMouseEnter

        If e.RowIndex >= 0 Then
            With dgvModelos
                IDCalibracion = .Item(0, e.RowIndex).Value

                SQLCalibraciones = "SELECT CAL_Codigo, Modelo, Imagen " & _
                                   "FROM tb_calibraciones " & _
                                   "WHERE CAL_Codigo='" & IDCalibracion & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(SQLCalibraciones, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    IDCategoria = CStr(dt.Rows(0).Item("CAL_Codigo").ToString)
                    txtModelo.Text = Trim(CStr(dt.Rows(0).Item("Modelo")).ToString)
                    picImagen.Image = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(0).Item("Imagen"), Byte()))
                End If
            End With
        End If
    End Sub
End Class