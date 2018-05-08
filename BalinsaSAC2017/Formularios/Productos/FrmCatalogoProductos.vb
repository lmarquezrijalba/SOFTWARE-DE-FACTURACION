Imports System.Data.SqlClient

Public Class FrmCatalogoProductos
    Dim index As Integer : Dim ID As String
    Dim sqlProductos As String : Dim sqlMarcas As String : Dim sqlMarcas2 As String
    Dim fila As Integer
    Dim Tab_Selec As Integer = 0

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        Try
            With FrmProductos
                .cmdGuardar.Text = "Guardar datos"
                .lblIDCategoria.Text = TabControl1.SelectedTab.Name
                .lblCategoria.Text = TabControl1.SelectedTab.Text
                .picFotografia.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")

                .txtModelo.Text = ""
                .txtEspecif.Text = ""
                .txtProducto.Text = ""
                .txtPrecio.Text = ""
                .txtStock.Text = "0"
                .txtDscto.Text = "0"

                .ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCatalogoProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdNuevaCategoria_Click(sender As Object, e As EventArgs) Handles cmdNuevaCategoria.Click
        FrmCategorias.ShowDialog()
    End Sub

    Private Sub FrmCatalogoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modProcedimientos.AgregarTABS_Categorias(TabControl1, True)
        cargarDatos()
    End Sub

    Private Sub cargarDatos()

        index = TabControl1.SelectedIndex

        If index >= 0 Then
            ID = TabControl1.Controls(index).Name

            sqlMarcas = "SELECT '0' AS MAR_Codigo, 'Seleccione' AS MAR_Nombre " & _
            "UNION SELECT MAR_Codigo, MAR_Nombre " & _
            "FROM tb_marcas " & _
            "WHERE CAT_Codigo='" & ID & "'"

            modProcedimientos.llenarMarcas_x_Categoria(FrmProductos.cboMarca, sqlMarcas)


            sqlProductos = "SELECT P.PRD_Codigo, " & _
            "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre, " & _
            "ISNULL(P.PRD_Modelo, 'NO REGISTRA') AS PRD_Modelo, P.PRD_Nombre, P.PRD_Moneda, P.PRD_Precio, " & _
            "P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen " & _
            "FROM tb_productos P " & _
            "WHERE P.CAT_Codigo='" & ID & "' AND " & _
            "PRD_Activo='1' " & _
            "ORDER BY MAR_Nombre"

            modProcedimientos.listarProductos(GridaProductos(index), sqlProductos, True)
            TabControl1.SelectedIndex = index
        End If
    End Sub

    Private Sub cmdRefrescar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        modProcedimientos.AgregarTABS_Categorias(TabControl1, True)
        TabControl1.SelectedIndex = 0
        cargarDatos()
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim ID_Producto As String
        Dim Index As Integer = TabControl1.SelectedIndex

        Dim sqlProductos As String : Dim numReg As Integer

        Dim Modelo, ID_Marca, Marca, Estructura, Plataforma, CodBarras, NombProd,
            Moneda, Precio, Dscto, Stock, Especific, IDCategoria As String
        Dim imagen As Image

        Try
            Dim fila As Integer = GridaProductos(Index).CurrentRow.Index
            ID_Producto = GridaProductos(Index).Item(0, fila).Value

            sqlProductos = "SELECT ISNULL(P.PRD_Modelo, 'NO REGISTRA') AS PRD_Modelo, P.CAT_Codigo, P.PRD_Estructura, P.PRD_Plataforma, P.PRD_CodBarras, P.PRD_Nombre, " & _
            "ISNULL((SELECT MAR_Codigo FROM tb_marcas WHERE MAR_Codigo=P.MAR_Codigo), 0) AS MAR_Codigo, " & _
            "ISNULL((SELECT MAR_Nombre FROM tb_marcas WHERE MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS Marca, " & _
            "P.PRD_Moneda, P.PRD_Precio, P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen, P.PRD_Activo, " & _
            "(SELECT C.esBALANZA FROM tb_categorias C WHERE C.CAT_Codigo=P.CAT_Codigo) AS esBALANZA " & _
            "FROM tb_productos P " & _
            "WHERE PRD_Codigo='" & ID_Producto & "'"

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlProductos, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            If numReg >= 0 Then
                IDCategoria = CStr(dt.Rows(0).Item("CAT_Codigo").ToString)
                ID_Marca = Trim(CStr(dt.Rows(0).Item("MAR_Codigo")))
                Marca = CStr(dt.Rows(0).Item("Marca"))
                Modelo = CStr(dt.Rows(0).Item("PRD_Modelo"))
                Estructura = CStr(dt.Rows(0).Item("PRD_Estructura").ToString)
                Plataforma = CStr(dt.Rows(0).Item("PRD_Plataforma").ToString)
                CodBarras = CStr(dt.Rows(0).Item("PRD_CodBarras"))
                NombProd = CStr(dt.Rows(0).Item("PRD_Nombre"))
                Moneda = CStr(dt.Rows(0).Item("PRD_Moneda"))
                Precio = CDbl(dt.Rows(0).Item("PRD_Precio"))
                Dscto = CStr(dt.Rows(0).Item("PRD_Dscto"))
                Stock = CStr(dt.Rows(0).Item("PRD_Stock"))
                Especific = CStr(dt.Rows(0).Item("PRD_Especificaciones").ToString)
                imagen = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(0).Item("PRD_Imagen"), Byte()))

                With FrmProductos
                    .cmdGuardar.Text = "Cambiar datos"
                    .lblIDProducto.Text = ID_Producto
                    .lblIDCategoria.Text = IDCategoria
                    .txtModelo.Text = Modelo
                    .cboEstructura.Text = Estructura
                    .TxtMedidas.Text = Plataforma
                    .lblCodBarras.Text = CodBarras
                    .txtProducto.Text = NombProd
                    .txtEspecif.Text = Especific

                    If Moneda = "S" Then
                        .cboMoneda.Text = "SOLES"
                    ElseIf Moneda = "D" Then
                        .cboMoneda.Text = "DÓLARES"
                    End If

                    .txtPrecio.Text = Precio
                    .txtDscto.Text = Dscto
                    .txtStock.Text = Stock
                    .txtEspecif.Text = Especific
                    .picFotografia.Image = imagen

                    If Marca = "NO REGISTRA" Then
                        .cboTipoBalanza.SelectedIndex = 1
                    Else
                        .cboTipoBalanza.SelectedIndex = 0
                        .cboMarca.Text = Marca
                    End If

                    .ShowDialog()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Try
            Dim Index As Integer = TabControl1.SelectedIndex
            Dim fila As Integer = GridaProductos(Index).CurrentRow.Index
            Dim ID_Producto As String = GridaProductos(Index).Item(0, fila).Value
            Dim sqlDelete As String = "UPDATE tb_productos SET PRD_Activo = 0 " & _
                                      "WHERE PRD_Codigo='" & ID_Producto & "'"
            If MsgBox("Realmente desea eliminar el producto seleccionado?", vbQuestion + vbYesNo + vbDefaultButton2, "Confirme acción") = vbYes Then
                If objFunciones.Ejecutar(sqlDelete) Then
                    cargarDatos()
                End If
            End If
        Catch ex As Exception
            'modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub FrmCatalogoProductos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Dim anchoGrida As Integer

        'With GridaProductos(CInt(TabControl1.SelectedIndex))
        'anchoGrida = .Width - 20

        '.Columns(0).Width = (anchoGrida * 7) / 100
        ''.Columns(1).Width = (anchoGrida * 7) / 100
        ''.Columns(2).Width = (anchoGrida * 45) / 100
        '.Columns(3).Width = (anchoGrida * 45) / 100
        '.Columns(4).Width = (anchoGrida * 5) / 100
        '.Columns(5).Width = (anchoGrida * 10) / 100
        '.Columns(6).Width = (anchoGrida * 10) / 100
        '.Columns(7).Width = (anchoGrida * 7) / 100
        'End With
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Tab_Selec = TabControl1.SelectedIndex
        cargarDatos()

        If Tab_Selec >= 0 Then
            If GridaProductos(Tab_Selec).RowCount = 0 Then
                cmdNuevo.Enabled = True
                cmdModificar.Enabled = False
                cmdEliminar.Enabled = False
            Else
                cmdNuevo.Enabled = True
                cmdModificar.Enabled = True
                cmdEliminar.Enabled = True
            End If
        End If
    End Sub
End Class