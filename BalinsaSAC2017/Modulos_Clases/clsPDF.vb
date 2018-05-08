Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class clsPDF

    Public Function getByteArchivo(ruta As String) As Byte()
        Dim arrayBytes() As Byte = System.IO.File.ReadAllBytes(ruta)

        Return arrayBytes
    End Function

    Public Sub guardarPDFS(Marca As String, Modelo As String, Archivo As Byte(),
                           foto As Byte(), Extension As String)

        Dim Consulta As String =
        "INSERT INTO tb_calibraciones(MAR_Codigo, Modelo, Archivo, Imagen, Extension) " & _
        "VALUES (@IDMarca, @Modelo, @Archivo, @Imagen, @Extension)"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = Marca
        cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
        cmd.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = Archivo
        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
        cmd.Parameters.Add("@Extension", SqlDbType.Char).Value = Extension

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()

            MsgBox("El archivo se registró con exito...", vbInformation, "¡Exito!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub editarPDFS(IDCalibracion As String, Marca As String, Modelo As String, Archivo As Byte(),
                          foto As Byte(), Extension As String)

        Dim Consulta As String =
        "UPDATE tb_calibraciones SET " & _
        "MAR_Codigo = @IDMarca, " & _
        "Modelo = @Modelo, " & _
        "Archivo = @Archivo, " & _
        "Imagen = @Imagen, " & _
        "Extension = @Extension " & _
        "WHERE CAL_Codigo = @IDCalibracion"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@IDCalibracion", SqlDbType.Int).Value = IDCalibracion
        cmd.Parameters.Add("@IDMarca", SqlDbType.Char).Value = Marca
        cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo
        cmd.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = Archivo
        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = foto
        cmd.Parameters.Add("@Extension", SqlDbType.Char).Value = Extension

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()

            MsgBox("El archivo se modificó con exito...", vbInformation, "¡Exito!")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub descargarArchivo(Grida As DataGridView, fila As Integer)
        Dim loPSI As New ProcessStartInfo
        Dim loProceso As New Process
        Dim Extension As String = ""
        Dim aBytDocumento() As Byte = Nothing
        Dim oFileStream As FileStream
        Dim rutaTemporal As String = Path.GetTempPath()


        Dim lsQuery As String = "SELECT * FROM tb_calibraciones WHERE CAL_Codigo='" & _
                                Grida.Item(0, fila).Value & "'"

        Try
            'Using cnn
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If

            Using loComando As New SqlCommand(lsQuery, cnn)
                Using drDocumentos As SqlDataReader = loComando.ExecuteReader(CommandBehavior.SingleRow)
                    If drDocumentos.Read() Then
                        aBytDocumento = CType(drDocumentos("Archivo"), Byte())
                        Extension = Trim(CStr(drDocumentos("Extension").ToString))
                    End If
                End Using
            End Using

            oFileStream = New FileStream(rutaTemporal & Grida.Item(1, fila).Value & Extension, FileMode.CreateNew, FileAccess.Write)
            oFileStream.Write(aBytDocumento, 0, aBytDocumento.Length)
            oFileStream.Close()
            'End Using

            loPSI.FileName = rutaTemporal & Grida.Item(1, fila).Value & Extension
            loProceso = Process.Start(loPSI)

        Catch Exp As Exception
            If MsgBox("Archivo ya descargado" & vbNewLine & vbNewLine & _
                      "El archivo al cual estas intentanto acceder, ya se encuentra en este equipo. " & _
                      "Deseas abrirlo ahora?", vbInformation + vbYesNo + vbDefaultButton1, "Confirmar") = vbYes Then
                loPSI.FileName = rutaTemporal & Grida.Item(1, fila).Value & Extension
                loProceso = Process.Start(loPSI)
            End If
        End Try
    End Sub

    Public Sub guardarInstalador(versionDispo As String, Archivo As Byte(), Extension As String, Lanzar As Boolean)

        Dim Consulta As String =
        "UPDATE tb_configsis SET " & _
        "versionDisponible = @Version, " & _
        "archivoInstalador = @Archivo, " & _
        "activarInstalacion = @Lanzar, " & _
        "Extension = @Extension " & _
        "WHERE ID='UNICO'"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@Version", SqlDbType.VarChar).Value = versionDispo
        cmd.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = Archivo
        cmd.Parameters.Add("@Extension", SqlDbType.Char).Value = Extension
        cmd.Parameters.Add("@Lanzar", SqlDbType.Char).Value = Lanzar

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()

            INSTALARVERSION = True
            FrmConfigActualizaSistema.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub descargarInstaladorEn(rutaInstalador As String)
        Try
            Dim Extension As String = "" ': Dim Version As String
            Dim aBytDocumento() As Byte = Nothing
            Dim oFileStream As FileStream
            Dim lsQuery As String = "SELECT * FROM tb_configsis WHERE ID='UNICO'"
            Dim loPSI As New ProcessStartInfo
            Dim loProceso As New Process

            Using cnn
                Using cmd As New SqlCommand(lsQuery, cnn)
                    If Not cnn.State = ConnectionState.Open Then
                        cnn.Open()
                    End If
                    Using drDocumentos As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                        If drDocumentos.Read() Then
                            aBytDocumento = CType(drDocumentos("archivoInstalador"), Byte())
                            Extension = Trim(CStr(drDocumentos("Extension").ToString))
                        End If
                    End Using
                End Using '"C:\PEPE.PDF"

                If Not IO.File.Exists(rutaInstalador & "\instalador " & VERSION_DISPO & Extension) Then
                    oFileStream = New FileStream(rutaInstalador & "\instalador " & VERSION_DISPO & Extension, FileMode.CreateNew, FileAccess.Write)

                    oFileStream.Write(aBytDocumento, 0, aBytDocumento.Length)
                    oFileStream.Close()
                End If
            End Using

            'loPSI.FileName = rutaInstalador & "\instalador " & VERSION_DISPO & Extension
            'loProceso = Process.Start(loPSI)
        Catch Exp As Exception
            MessageBox.Show(Exp.Message, "xxx", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class
