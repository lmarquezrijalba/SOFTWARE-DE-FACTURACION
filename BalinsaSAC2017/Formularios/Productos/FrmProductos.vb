Imports System.Data.SqlClient

Public Class FrmProductos
    Dim Cat As String
    Dim rutaImagen, Op As String
    Dim esBalanza As Boolean
    Dim Tipo As Integer = 1

    Private Sub cmdMarcas_Click(sender As Object, e As EventArgs) Handles cmdMarcas.Click
        With FrmMarcas
            .lblIDCategoria.Text = lblIDCategoria.Text
            .lblTipoProducto.Text = lblCategoria.Text

            .ShowDialog()
        End With
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub picImagenes_Click(sender As Object, e As EventArgs) Handles picFotografia.Click
        Try
            'ofdAbrir.Filter = "Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"
            ofdAbrir.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los Archivos (*.*)|*.*"
            ofdAbrir.Title = "Seleccionar la imagen"
            ofdAbrir.ShowDialog()

            rutaImagen = ofdAbrir.FileName

            If rutaImagen <> "OpenFileDialog1" Then 'Windows.Forms.DialogResult.OK Then
                picFotografia.Image = Image.FromFile(rutaImagen)
            Else
                picFotografia.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub FrmRegistroProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRegistroProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlGenerar, Anio, Mes As String
        modProcedimientos.Listar_Tipos(Tipo, cboTipoEstructura)
        'lblCodBarras.Font = objCODBarras.getFuente(Application.StartupPath & "\Fuentes", 30, "Code39.TTF")

        Anio = Format(Now, "yy")
        Mes = Format(Now, "MM")
        sqlGenerar = "SELECT COUNT(PRD_Codigo) FROM tb_productos"

        lblNroCodBarras.Text = Cat & objFunciones.Generar_Codigo(sqlGenerar, "0000", Mes & "-") & Anio
        lblCodBarras.Text = Cat & objFunciones.Generar_Codigo(sqlGenerar, "0000", Mes & "-") & Anio
        picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
        'picFotografia.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")

        'VERIFICAMOS SI ES DE LA CATEGORIA BALANZAS
        '-------------------------------------------
        Dim index, numReg As Integer
        Dim sqlverificarBalanza, IDCategoria As String

        With FrmCatalogoProductos.TabControl1
            index = .SelectedIndex

            If index >= 0 Then
                IDCategoria = .Controls(index).Name
                sqlverificarBalanza = "SELECT CAT_Codigo, CAT_Nombre, esBALANZA, CAT_Activo " & _
                                      "FROM tb_categorias " & _
                                      "WHERE CAT_Codigo='" & IDCategoria & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlverificarBalanza, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    esBalanza = CBool(dt.Rows(0).Item("esBALANZA"))

                    If esBalanza Then
                        cboTipoBalanza.Visible = True
                        Label13.Visible = True
                    Else
                        cboTipoBalanza.Visible = False
                        Label13.Visible = False
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim Precio As String
        Dim Dscto, Stock As Integer
        Dim SQLListarProductos, sqlVerificar As String
        Dim Index As Integer = FrmCatalogoProductos.TabControl1.SelectedIndex
        Dim ID As String = FrmCatalogoProductos.TabControl1.Controls(Index).Name

        SQLListarProductos = "SELECT P.PRD_Codigo, " & _
        "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre, " & _
        "P.PRD_Modelo, P.PRD_Nombre, P.PRD_Moneda, P.PRD_Precio, " & _
        "P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen " & _
        "FROM tb_productos P " & _
        "WHERE P.CAT_Codigo='" & ID & "' AND " & _
        "PRD_Activo='1' " & _
        "ORDER BY MAR_Nombre"

        sqlVerificar = "SELECT PRD_Modelo FROM tb_productos WHERE PRD_Modelo='" & txtModelo.Text & "'"

        Precio = txtPrecio.Text
        Dscto = Val(txtDscto.Text)
        Stock = Val(txtStock.Text)

        If cboTipoBalanza.SelectedIndex < 0 And esBalanza Then
            MsgBox("Debe seleccionar el tipo de balanza a registrar", vbCritical, "Corregir!")
            cboTipoBalanza.Focus()
        ElseIf cboMarca.SelectedIndex = 0 And esBalanza = False Then
            MsgBox("Seleccione la marca del producto a registrar", vbCritical, "Corregir!")
            cboMarca.Focus()
        Else
            If cmdGuardar.Text = "Guardar datos" Then
                If objFunciones.verificarRegistro(sqlVerificar) = False Or txtModelo.Visible = False Then
                    If esBalanza Then
                        If Op = "Completa" Then

                            objImagenes.InsertRegistro_Balanzas(lblIDCategoria.Text,
                                                                lblCodBarras.Text, txtProducto.Text, cboMoneda.Text, txtPrecio.Text,
                                                                txtDscto.Text, txtStock.Text,
                                                                objImagenes.ImageToByteArray(picFotografia.Image), 1,
                                                                cboTipoBalanza.Text,
                                                                txtEspecif.Text,
                                                                cboMarca.SelectedValue, txtModelo.Text,
                                                                cboEstructura.Text, TxtMedidas.Text, Tipo)

                        ElseIf Op = "Partes" Then
                            If Tipo = 0 Then
                                objImagenes.InsertRegistro_Balanzas(lblIDCategoria.Text,
                                                                    lblCodBarras.Text, txtProducto.Text, cboMoneda.Text, txtPrecio.Text,
                                                                    txtDscto.Text, txtStock.Text,
                                                                    objImagenes.ImageToByteArray(picFotografia.Image), 1,
                                                                    cboTipoBalanza.Text,
                                                                    txtEspecif.Text,
                                                                    cboMarca.SelectedValue, txtModelo.Text,
                                                                    cboEstructura.Text, TxtMedidas.Text, Tipo)

                            ElseIf Tipo = 1 Then
                                objImagenes.InsertRegistro_Balanzas(lblIDCategoria.Text,
                                                                    lblCodBarras.Text, txtProducto.Text, cboMoneda.Text, txtPrecio.Text,
                                                                    txtDscto.Text, txtStock.Text,
                                                                    objImagenes.ImageToByteArray(picFotografia.Image), 1,
                                                                    cboTipoBalanza.Text,
                                                                    txtEspecif.Text,
                                                                    cboMarca.SelectedValue, txtModelo.Text,
                                                                    cboEstructura.Text, TxtMedidas.Text, Tipo)

                            End If

                        End If
                    Else
                        objImagenes.InsertRegistro_Camaras(lblIDCategoria.Text, cboMarca.SelectedValue, txtModelo.Text,
                                                           lblCodBarras.Text, txtProducto.Text, cboMoneda.Text, txtPrecio.Text,
                                                           txtDscto.Text, txtStock.Text,
                                                           objImagenes.ImageToByteArray(picFotografia.Image), 1,
                                                           txtEspecif.Text)
                    End If

                    Me.Close()

                    FrmCatalogoProductos.TabControl1.SelectedIndex = Index
                    modProcedimientos.listarProductos(GridaProductos(Index), SQLListarProductos, True)
                Else
                    MsgBox("No se pudo registrar el producto." & vbNewLine & vbNewLine & _
                           "El modelo del producto que desea registrar, ya se encuentra " & _
                           "almacenada en la base de datos.", vbCritical, "¡Verifique!")
                End If
            ElseIf cmdGuardar.Text = "Cambiar datos" Then
                If esBalanza Then
                    objImagenes.UpdateRegistro_Balanzas(lblIDProducto.Text, lblIDCategoria.Text,
                                                        lblCodBarras.Text, txtProducto.Text, cboMoneda.Text, txtPrecio.Text,
                                                        txtDscto.Text, txtStock.Text,
                                                        objImagenes.ImageToByteArray(picFotografia.Image), 1,
                                                        cboTipoBalanza.Text,
                                                        txtEspecif.Text,
                                                        cboMarca.SelectedValue, txtModelo.Text,
                                                        cboEstructura.Text, TxtMedidas.Text)
                Else
                    objImagenes.UpdateRegistro_Camaras(lblIDProducto.Text, lblIDCategoria.Text, cboMarca.SelectedValue, txtModelo.Text,
                                                       lblCodBarras.Text, txtProducto.Text, cboMoneda.Text, txtPrecio.Text,
                                                       txtDscto.Text, txtStock.Text,
                                                       objImagenes.ImageToByteArray(picFotografia.Image), 1,
                                                       txtEspecif.Text)
                End If

                Me.Close()

                FrmCatalogoProductos.TabControl1.SelectedIndex = Index
                modProcedimientos.listarProductos(GridaProductos(Index), SQLListarProductos, True)
            End If
        End If
    End Sub

    Private Sub cboTipoBalanza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoBalanza.SelectedIndexChanged

        If cboTipoBalanza.SelectedIndex = 0 Then '<-- completa
            Op = "Completa"
            cboMarca.Enabled = True
            cboTipoEstructura.Enabled = True
            TxtMedidas.Enabled = True
            txtModelo.Enabled = True
            cboEstructura.Enabled = False
        ElseIf cboTipoBalanza.SelectedIndex = 1 Then '<-- por partes+
            Op = "Partes"
            cboMarca.Enabled = False
            cboTipoEstructura.Enabled = False
            TxtMedidas.Enabled = False
            txtModelo.Enabled = False
            cboEstructura.Enabled = True
        Else
            cboEstructura.Enabled = False
        End If
    End Sub

    Private Sub cboEstructura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstructura.SelectedIndexChanged
        If cboEstructura.SelectedIndex = 0 Then
            cboMarca.Enabled = False
            txtModelo.Enabled = False
            cboTipoEstructura.Enabled = False
            TxtMedidas.Enabled = False
            cboMarca.SelectedIndex = 0
            cboTipoEstructura.SelectedIndex = 0
        ElseIf cboEstructura.SelectedIndex = 1 Then
            Tipo = 0
            cboTipoEstructura.SelectedIndex = 0
            TxtMedidas.Clear()
            cboMarca.Enabled = True
            txtModelo.Enabled = True
            cboTipoEstructura.Enabled = False
            TxtMedidas.Enabled = False
            cmdMarcas.Enabled = True
        ElseIf cboEstructura.SelectedIndex = 2 Then
            Tipo = 1
            cboMarca.SelectedIndex = 0
            txtModelo.Clear()
            cboMarca.Enabled = False
            txtModelo.Enabled = False
            cboTipoEstructura.Enabled = True
            TxtMedidas.Enabled = True
            cmdMarcas.Enabled = False
        End If
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs)
        modProcedimientos.A_MAYUSCULAS(txtModelo, e)
    End Sub

    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtProducto, e)
    End Sub

    Private Sub txtEspecif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEspecif.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtEspecif, e)
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtPrecio)
    End Sub

    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtDscto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDscto.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtPlataforma_KeyPress(sender As Object, e As KeyPressEventArgs)
        modProcedimientos.SOLO_NUMEROS_PLATAF(sender, e, TxtMedidas)
    End Sub

End Class