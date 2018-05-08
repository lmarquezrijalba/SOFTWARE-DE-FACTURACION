Imports System.Data.SqlClient
Imports System.IO

Imports System.Drawing.Imaging

Public Class clsImagenes

    Public Function Cargar() As DataTable
        Dim Consulta As String = "SELECT * FROM tb_productos"
        Dim cmd As New SqlCommand(Consulta, cnn)
        Dim adap As New SqlDataAdapter(cmd)
        adap.Fill(dt)

        Return dt
    End Function

    Public Sub UpdateRegistro_Camaras(ID_Producto As String, ID_Categoria As String, _
                                      ID_Marca As String, Modelo As String,
                                      CodBarras As String, NombProducto As String, _
                                      Moneda As String, Precio As String, Dscto As Integer, _
                                      Stock As Integer, foto As Byte(), Estado As Integer,
                                      Optional Especificaciones As String = "NULL")

        Dim Consulta As String =
        "UPDATE tb_productos SET " & _
        "CAT_Codigo = @IDCategoria, " & _
        "MAR_Codigo = @IDMarca, " & _
        "PRD_Modelo = @Modelo, " & _
        "PRD_CodBarras = @CodBarras, " & _
        "PRD_Nombre = @Nombre, " & _
        "PRD_Moneda = @Moneda, " & _
        "PRD_Precio = @Precio, " & _
        "PRD_Dscto = @Dscto, " & _
        "PRD_Stock = @Stock, " & _
        "PRD_Especificaciones = @Especificaciones, " & _
        "PRD_Imagen = @Imagen, " & _
        "PRD_Activo = @Estado " & _
        "WHERE PRD_Codigo=@IDProducto"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@IDProducto", SqlDbType.Int).Value = ID_Producto
        cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
        cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = ID_Marca
        cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
        cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
        cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
        cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
        cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
        cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
        cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado

        'cnn.Open()

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            MsgBox("El producto se actualizó con exito...", vbInformation, "¡Exito!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub InsertRegistro_Camaras(ID_Categoria As String, ID_Marca As String, Modelo As String,
                                      CodBarras As String, NombProducto As String, _
                                      Moneda As String, Precio As String, Dscto As Integer, _
                                      Stock As Integer, foto As Byte(), Estado As Integer,
                                      Optional Especificaciones As String = "NULL")

        Dim Consulta As String =
        "INSERT INTO tb_productos(CAT_Codigo, MAR_Codigo, PRD_Modelo, PRD_CodBarras, PRD_Nombre, " & _
        "PRD_Moneda, PRD_Precio, PRD_Dscto, PRD_Stock, PRD_Especificaciones, PRD_Imagen, " & _
        "PRD_Activo) VALUES (@IDCategoria, @IDMarca, @Modelo, @CodBarras, @Nombre, @Moneda, @Precio, " & _
        "@Dscto, @Stock, @Especificaciones, @Imagen, @Estado)"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
        cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = ID_Marca
        cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
        cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
        cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
        cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
        cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
        cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
        cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            MsgBox("El producto se registró con exito...", vbInformation, "¡Exito!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub InsertRegistro_Balanzas(ID_Categoria As String,
                                       CodBarras As String, NombProducto As String, Moneda As String, _
                                       Precio As String, Dscto As Integer, _
                                       Stock As Integer, foto As Byte(), _
                                       Estado As Integer, verifTipo As String, _
                                       Especificaciones As String,
                                       ID_Marca As String, Modelo As String, _
                                       Estructura As String, Plataforma As String, Tipo As Integer)

        Dim Consulta As String = ""

        If verifTipo = "COMPLETA" Then
            Consulta = "INSERT INTO tb_productos(CAT_Codigo, MAR_Codigo,COD_Tipo, PRD_Modelo, PRD_CodBarras, PRD_Nombre, " & _
            "PRD_Moneda, PRD_Precio, PRD_Dscto, PRD_Stock, PRD_Especificaciones, PRD_Imagen, " & _
            "PRD_Activo) VALUES (@IDCategoria, @IDMarca,@Tipo, @Modelo, @CodBarras, @Nombre, @Moneda, @Precio, " & _
            "@Dscto, @Stock, @Especificaciones, @Imagen, @Estado)"
        ElseIf verifTipo = "POR PARTES" Then
            If Tipo = 0 Then
                Consulta = "INSERT INTO tb_productos(CAT_Codigo, MAR_Codigo,COD_Tipo, PRD_Modelo, PRD_CodBarras, PRD_Nombre, " & _
                           "PRD_Moneda, PRD_Precio, PRD_Dscto, PRD_Stock, PRD_Especificaciones, PRD_Imagen, " & _
                           "PRD_Activo) VALUES (@IDCategoria, @IDMarca,@Tipo, @Modelo, @CodBarras, @Nombre, @Moneda, @Precio, " & _
                           "@Dscto, @Stock, @Especificaciones, @Imagen, @Estado)"

            ElseIf Tipo = 1 Then
                Consulta = "INSERT INTO tb_productos(CAT_Codigo, MAR_Codigo,COD_Tipo, PRD_Modelo, PRD_CodBarras, PRD_Nombre, " & _
                           "PRD_Moneda, PRD_Precio, PRD_Dscto, PRD_Stock, PRD_Especificaciones, PRD_Imagen, " & _
                           "PRD_Activo) VALUES (@IDCategoria, @IDMarca,@Tipo, @Modelo, @CodBarras, @Nombre, @Moneda, @Precio, " & _
                           "@Dscto, @Stock, @Especificaciones, @Imagen, @Estado)"
            End If
        End If

        Dim cmd As New SqlCommand(Consulta, cnn)

        If verifTipo = "COMPLETA" Then
            cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
            cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = ID_Marca
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
            cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
            cmd.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Estructura
            cmd.Parameters.Add("@Plataforma", SqlDbType.VarChar).Value = Plataforma
            cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
            cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
            cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
            cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
            cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
            cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado

        ElseIf verifTipo = "POR PARTES" Then
            If Tipo = 0 Then
                cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
                cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = ID_Marca
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
                cmd.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = "NULL"
                cmd.Parameters.Add("@Plataforma", SqlDbType.VarChar).Value = "NULL"
                cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
                cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
                cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
                cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
                cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
                cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado
            ElseIf Tipo = 1 Then
                cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
                cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = "NULL"
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = "NULL"
                cmd.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Estructura
                cmd.Parameters.Add("@Plataforma", SqlDbType.VarChar).Value = Plataforma
                cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
                cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
                cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
                cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
                cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
                cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado
            End If
        End If

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            MsgBox("El producto se registró con exito.", vbInformation, "¡Exito!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub UpdateRegistro_Balanzas(ID_Producto As String, ID_Categoria As String,
                                       CodBarras As String, NombProducto As String, Moneda As String, _
                                       Precio As String, Dscto As Integer, _
                                       Stock As Integer, foto As Byte(), _
                                       Estado As Integer, verifTipo As String, _
                                       Optional Especificaciones As String = "NULL",
                                       Optional ID_Marca As String = "NULL", Optional Modelo As String = "NULL", _
                                       Optional Estructura As String = "NULL", Optional Plataforma As String = "NULL")

        Dim Consulta As String = ""

        If verifTipo = "COMPLETA" Then
            Consulta = "UPDATE tb_productos SET " & _
            "CAT_Codigo = @IDCategoria, MAR_Codigo = @IDMarca, " & _
            "PRD_Modelo = @Modelo, PRD_CodBarras = @CodBarras, " & _
            "PRD_Nombre = @Nombre, PRD_Moneda = @Moneda, " & _
            "PRD_Precio = @Precio, PRD_Dscto = @Dscto, PRD_Stock = @Stock, " & _
            "PRD_Especificaciones = @Especificaciones, PRD_Imagen = @Imagen, " & _
            "PRD_Activo = @Estado " & _
            "WHERE PRD_Codigo = @IDProducto"
        ElseIf verifTipo = "POR PARTES" Then
            Consulta = "UPDATE tb_productos SET " & _
            "CAT_Codigo = @IDCategoria, PRD_Estructura = @Estructura, " & _
            "PRD_Plataforma = @Plataforma, PRD_CodBarras = @CodBarras, " & _
            "PRD_Nombre = @Nombre, PRD_Moneda = @Moneda, PRD_Precio = @Precio, " & _
            "PRD_Dscto = @Dscto, PRD_Stock = @Stock, PRD_Especificaciones = @Especificaciones, " & _
            "PRD_Imagen = @Imagen, PRD_Activo = @Estado " & _
            "WHERE PRD_Codigo = @IDProducto"
        End If

        Dim cmd As New SqlCommand(Consulta, cnn)

        If verifTipo = "COMPLETA" Then
            cmd.Parameters.Add("@IDProducto", SqlDbType.Int).Value = ID_Producto
            cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
            cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = ID_Marca
            cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
            cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
            cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
            cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
            cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
            cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
            cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado
        ElseIf verifTipo = "POR PARTES" Then
            cmd.Parameters.Add("@IDProducto", SqlDbType.Int).Value = ID_Producto
            cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = ID_Categoria
            cmd.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Estructura
            cmd.Parameters.Add("@Plataforma", SqlDbType.VarChar).Value = Plataforma
            cmd.Parameters.Add("@CodBarras", SqlDbType.Char).Value = CodBarras
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombProducto
            cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = Mid(Moneda, 1, 1)
            cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
            cmd.Parameters.Add("@Dscto", SqlDbType.Int).Value = Dscto
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock
            cmd.Parameters.Add("@Especificaciones", SqlDbType.Text).Value = Especificaciones
            cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado
        End If

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            MsgBox("El producto se actualizó con exito.", vbInformation, "¡Exito!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)

        Return Image.FromStream(ms)
    End Function

    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()

        Try
            imageIn.Save(ms, ImageFormat.Jpeg)
            Return ms.ToArray()
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsImagenes")
        End Try
    End Function
End Class
