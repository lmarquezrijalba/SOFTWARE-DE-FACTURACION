Imports System.Data.SqlClient
Imports System.Net

Imports System.Text
Imports System.Security.Cryptography

Public Class clsFunciones

    Public Function GetRutaSistema() As String
        Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory() 'My.Application.Info.DirectoryPath
        Return ruta
    End Function

    Public Function GetRutaAbsoluta() As String
        Dim rutaAbsoluta As String = System.AppDomain.CurrentDomain.BaseDirectory() 'Application.StartupPath.ToString
        Dim ruta As String = rutaAbsoluta.Replace("\bin\Debug\", "")

        Return ruta
    End Function

    Public Function obtenerNombreMes(ByVal numeroMes As Integer) As String
        Dim nombreMes As String = ""

        Try
            nombreMes = MonthName(numeroMes)
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)
        End Try

        Return UCase(nombreMes)
    End Function

    Public Function obtenerNumeroMes(ByVal Mes As String) As Integer
        Dim numMes As Integer

        Try
            Select Case Mes
                Case "ENERO"
                    numMes = 1
                Case "FEBRERO"
                    numMes = 2
                Case "MARZO"
                    numMes = 3
                Case "ABRIL"
                    numMes = 4
                Case "MAYO"
                    numMes = 5
                Case "JUNIO"
                    numMes = 6
                Case "JULIO"
                    numMes = 7
                Case "AGOSTO"
                    numMes = 8
                Case "SEPTIEMBRE"
                    numMes = 9
                Case "OCTUBRE"
                    numMes = 10
                Case "NOVIEMBRE"
                    numMes = 11
                Case "DICIEMBRE"
                    numMes = 12
            End Select
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)
        End Try

        Return numMes
    End Function

    Public Function getNombreProcedimiento() As String
        Dim st As New System.Diagnostics.StackTrace()
        Dim nombreMetodo As String = st.GetFrame(1).GetMethod().Name

        Return nombreMetodo
    End Function

    Public Function getNombrePC() As String
        Dim PCName As String = CStr(My.Computer.Name)
        Return PCName
    End Function

    Public Function getIP() As String
        Dim valorIp As String

        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) _
                  i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()

        Return valorIp
    End Function

    Public Function getnumeroRegs(ByVal sql As String) As Integer
        Dim cantidad As Integer

        Try
            sqlda = New SqlDataAdapter(sql, cnn)
            dt = New DataTable
            sqlda.Fill(dt)

            cantidad = CInt(dt.Rows.Count)

            'cnn.Close()
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)
        End Try

        Return cantidad
    End Function

    Public Function estaVentanaAbierta(ByVal Myform As Form)
        Dim objForm As Form
        Dim blnAbierto As Boolean = False
        blnAbierto = False
        For Each objForm In My.Application.OpenForms
            If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                blnAbierto = True
            End If
        Next

        Return blnAbierto
    End Function

    Public Function Generar_Codigo(ByVal sql As String,
                                   Optional Cadena_de_Ceros As String = "",
                                   Optional COD_ALTERNATIVO As String = "") As String

        Dim Autogenerado As String = ""
        Dim contador, correlativo As Integer

        Try
            sqlda = New SqlDataAdapter(sql, cnn)
            dt = New DataTable
            sqlda.Fill(dt)

            contador = CInt(dt.Rows(0).Item(0))
            correlativo = CInt(contador + 1)

            Autogenerado = COD_ALTERNATIVO & Format(correlativo, Cadena_de_Ceros)

            'cnn.Close()
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)
        End Try

        Generar_Codigo = Autogenerado
    End Function

    Public Function verificarRegistro(ByVal sqlVerificar As String) As Boolean
        Dim existe As Boolean = False

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlVerificar, cnn)
            sqlda.Fill(dt)

            If CInt(dt.Rows.Count) > 0 Then
                existe = True
            Else
                existe = False
            End If

            cnn.Close()
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)
        End Try

        Return existe
    End Function

    Public Function Ejecutar(ByVal sqlProceso As String) As Boolean

        Dim sqlCmd As SqlCommand

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            sqlCmd = cnn.CreateCommand
            sqlCmd.CommandText = sqlProceso
            sqlCmd.ExecuteScalar()

            cnn.Close()
        
            Return True
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)

            Return False
        End Try
    End Function

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "," Then  '.
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = UCase(palabras & "con " & dec & "/100 ") ' & MONEDA)
            Else
                Letras = UCase(palabras) ' & MONEDA)
            End If
        Else
            Letras = ""
        End If
    End Function


    Public Function GenerarContrasena(ByVal numeroCaracteres As Integer) As String
        Dim letras(51) As String ' Dimensionamos un array para almacenar letras MAYUSC y MIN 
        Dim n As Integer

        ' Rellenamos el array. 
        For item As Int32 = 65 To 90
            letras(n) = Chr(item)
            letras(n + 1) = letras(n).ToLower
            n += 2
        Next

        Dim cadenaAleatoria As String = String.Empty

        ' Iniciamos el generador de números aleatorios 
        Dim rnd As New Random(DateTime.Now.Millisecond)

        For n = 0 To numeroCaracteres
            Dim numero As Integer = rnd.Next(0, 51)
            cadenaAleatoria &= letras(numero)
        Next

        Return cadenaAleatoria
    End Function

    Public Function Sumar_Columna(ByVal Grida As DataGridView, ByVal Columna As Integer) As Double
        Dim total As Double = 0
        Dim iTotal As Integer = Grida.Rows.Count

        Try
            For i = 0 To iTotal - 1
                'Double.parse()<---es para convertir a double el valor que se encuentre entre lso parentesis
                'me.datagridview1(4,i).value <----toma todos los valores de la columna 4... 4 es el numero de columna y i es el numero de fila asi toma todos los 
                'valores de esa columna, recuerda que las columnas inician en 0... asi que la 4 enrealidad sera la 5 visualmente
                total += CDbl(Grida.Item(Columna, i).Value)
            Next

            Return total
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones" & " " & objFunciones.getNombreProcedimiento)
        End Try

    End Function

    'Public Function obtenerArchivosDirectorio(ByRef rutaDirectorio As String) As List(Of String)
    'Dim listaRutas As List(Of String) = New List(Of String)
    'Dim ruta As String

    '    ruta = rutaDirectorio

    'Dim rutas As String

    '    rutas = Dir(ruta)

    '    Do While rutas <> ""
    ''listaRutas.Add(Path.GetDirectoryName(rutaDirectorio) + "\" + rutas)
    '        listaRutas.Add(Path.GetDirectoryName(rutaDirectorio) + "\" + rutas)
    '        rutas = Dir()
    '    Loop

    '    Return listaRutas
    'End Function


    Public Function SumarLista(Grida As DataGridView, Columna As Integer) As Double
        Dim suma As Double = 0

        For i = 0 To Grida.Rows.Count - 1
            suma += CStr(Grida.Item(Columna, i).Value)
        Next

        Return suma
    End Function

    Public Function PrimerDiaDelMes(ByVal Fecha As Date) As Date
        PrimerDiaDelMes = DateSerial(Year(Fecha), Month(Fecha), 1)
    End Function

    'para saber el ultimo dia del mes 
    Public Function UltimoDiaDelMes(ByVal Fecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function

    Public Function NumeroSemana(ByVal fecha As Date) As Integer
        Dim sFecha As String
        sFecha = "01/" & Month(fecha) & "/" & Year(fecha)
        NumeroSemana = DatePart("ww", fecha, vbMonday) - DatePart("ww", DateValue(sFecha), vbMonday) + 1
    End Function

    Public Function esAnioBiciesto(ByVal Anio As Integer) As Boolean
        If (Anio Mod 4 = 0 And Anio Mod 100 <> 0 Or Anio Mod 400 = 0) Then
            esAnioBiciesto = True
        Else
            esAnioBiciesto = False
        End If

        Return esAnioBiciesto
    End Function

    Public Function WeeksInMonth(dateValue As DateTime) As Integer

        Dim month As Integer = dateValue.Month  ' Mes
        Dim year As Integer = dateValue.Year    ' Año

        ' Primer día del mes
        Dim firstDay As New DateTime(year, month, 1)

        ' Último día del mes
        Dim lastDay As New DateTime(year, month, DateTime.DaysInMonth(year, month))

        ' Primera semana del mes
        Dim firstWeek As Integer = DatePart(DateInterval.WeekOfYear, firstDay, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)

        ' Como el primer día del mes se supone que está incluido dentro
        ' de la primera semana de dicho mes, le restamos una unidad.
        '
        firstWeek -= 1

        ' Última semana del mes
        Dim lastWeek As Integer = DatePart(DateInterval.WeekOfYear, lastDay, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)

        ' Devolvemos la diferencia entre los números de semana obtenidos.
        Return lastWeek - firstWeek

    End Function

    Public Function obtPrimerLunes_Mes(ByVal FechaInicio As Date) As Date
        Dim PrimerLunesMes As Date = FechaInicio

        For i = 1 To 7
            If PrimerLunesMes.DayOfWeek <> DayOfWeek.Monday Then
                PrimerLunesMes = FechaInicio.AddDays(i)
            Else
                Exit For
            End If
        Next

        Return PrimerLunesMes
    End Function

    Public Function obtFechaFin(ByVal FechaInicio As Date) As Date
        Dim fechaFin As Date '= FechaInicio.AddDays(6)

        If FechaInicio.DayOfWeek = DayOfWeek.Monday Then
            fechaFin = FechaInicio.AddDays(6)
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Tuesday Then
            fechaFin = FechaInicio.AddDays(5)
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Wednesday Then
            fechaFin = FechaInicio.AddDays(4)
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Thursday Then
            fechaFin = FechaInicio.AddDays(3)
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Friday Then
            fechaFin = FechaInicio.AddDays(2)
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Saturday Then
            fechaFin = FechaInicio.AddDays(1)
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Sunday Then
            fechaFin = FechaInicio
        End If

        Return fechaFin
    End Function

    Public Function semanaActual(ByVal primerDia As Date, ByVal ultimoDia As Date) As Integer
        Dim semActual As Integer = (DateDiff("w", primerDia, ultimoDia) + 2)

        Return semActual
    End Function

    Public Function convertMoneda(ByVal Monto As String) As String
        Dim Real As String

        Real = Monto.Replace(",", ".")
        Return Real
    End Function

    ''CODIGO DE AUTOGENERAR CODIGO
    ''-----------------------------
    'Public Function GenerarID() As Integer
    '    cnn.Open()

    '    sqlcmd = New SqlCommand("AUTOGENERAR_PRODUCTOS", cnn)
    'Dim PARAM As New SqlParameter("@PRD_Codigo", SqlDbType.Int)
    '    PARAM.Direction = ParameterDirection.Output

    '    With sqlcmd
    '        .CommandType = CommandType.StoredProcedure
    '        .Parameters.Add(PARAM)
    '        .ExecuteNonQuery()

    ''cnn.Close()

    '        Return .Parameters("@PRD_Codigo").Value
    '    End With

    ''TXTCODIGO.TEXTBOX = FORMAT(OBJ.GenerarCodigo, "000")
    'End Function

    'CODIGO DE AUTOGENERAR CODIGO
    '-----------------------------
    Public Function GenerarCodigo(Nombre_ProcAlmacenado As String, Nombre_Parametro As String) As Integer

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        sqlcmd = New SqlCommand(Nombre_ProcAlmacenado, cnn)
        Dim PARAM As New SqlParameter(Nombre_Parametro, SqlDbType.Int)
        PARAM.Direction = ParameterDirection.Output

        With sqlcmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(PARAM)
            .ExecuteNonQuery()

            'cnn.Close()

            Return .Parameters(Nombre_Parametro).Value
        End With
    End Function

    Public Function autocompletarNumero(Numero As String, numCaracteres As Integer, Texto As TextBox) As String
        Dim tamanioNumero As Integer = Len(Numero)
        Dim cadenaCeros As String = ""
        Dim numeroResultante As String = ""

        If IsNumeric(Numero) Then
            For i = 1 To (numCaracteres - tamanioNumero)
                cadenaCeros &= "0"
            Next

            Texto.BackColor = Color.White
            numeroResultante = cadenaCeros & Numero
        Else
            Texto.BackColor = Color.FromArgb(220, 72, 59)
            'MsgBox("Ingrese un valor para este campo", vbCritical, "Ingrese")
        End If

        Return numeroResultante
    End Function

    'MANTENIMIENTO A CONTACTOS X CLIENTE
    '------------------------------------
    Public Sub InsertContactos(CLI_Codigo As String, CON_Nombres As String, CON_Cargo As String,
                               CON_Telefono As String, CON_Correo As String, CON_Observ As String, _
                               CON_Tarjeta As Byte())


        Dim Consulta As String =
        "INSERT INTO tb_contato_x_clientes(CLI_Codigo, CON_Nombres, CON_Cargo, " & _
        "CON_Telefono, CON_Correo, CON_Observacion, CON_Tarjeta) VALUES(@IDCliente, @Contacto, " & _
        "@Cargo, @Fono, @Correo, @Obsv, @Tarjeta)"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@IDCliente", SqlDbType.VarChar).Value = CLI_Codigo
        cmd.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = CON_Nombres
        cmd.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = CON_Cargo
        cmd.Parameters.Add("@Fono", SqlDbType.Text).Value = CON_Telefono
        cmd.Parameters.Add("@Correo", SqlDbType.Text).Value = CON_Correo
        cmd.Parameters.Add("@Obsv", SqlDbType.Text).Value = CON_Observ
        cmd.Parameters.Add("@Tarjeta", SqlDbType.Image).Value = CON_Tarjeta

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            'cnn.Close()
            'MsgBox("El producto se registró con exito...", vbInformation, "¡Exito!")
        Catch ex As Exception
            'cnn.Close()
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Sub UpdateContacto(CON_Codigo As String, CLI_Codigo As String, CON_Nombres As String, _
                              CON_Cargo As String, CON_Telefono As String, CON_Correo As String, _
                              CON_Observ As String, CON_Tarjeta As Byte())

        Dim Consulta As String =
        "UPDATE tb_contato_x_clientes SET " & _
        "CLI_Codigo = @IDCliente, " & _
        "CON_Nombres = @Contacto, " & _
        "CON_Cargo = @Cargo, " & _
        "CON_Telefono = @Fono, " & _
        "CON_Correo = @Correo, " & _
        "CON_Observacion = @Obsv, " & _
        "CON_Tarjeta = @Tarjeta " & _
        "WHERE CON_Codigo=@Codigo"

        Dim cmd As New SqlCommand(Consulta, cnn)

        cmd.Parameters.Add("@Codigo", SqlDbType.Char).Value = CON_Codigo
        cmd.Parameters.Add("@IDCliente", SqlDbType.Char).Value = CLI_Codigo
        cmd.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = CON_Nombres
        cmd.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = CON_Cargo
        cmd.Parameters.Add("@Fono", SqlDbType.Text).Value = CON_Telefono
        cmd.Parameters.Add("@Correo", SqlDbType.Text).Value = CON_Correo
        cmd.Parameters.Add("@Obsv", SqlDbType.Text).Value = CON_Observ
        cmd.Parameters.Add("@Tarjeta", SqlDbType.Image).Value = CON_Tarjeta

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Try
            cmd.ExecuteNonQuery()
            'cnn.Close()
            'MsgBox("El producto se actualizó con exito...", vbInformation, "¡Exito!")
        Catch ex As Exception
            'cnn.Close()
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Function obtenerSoloTituloArchivo(ByVal fileName As String) As String
        Dim fi As New System.IO.FileInfo(fileName)
        Return fi.Name
    End Function

    'Public Function getNumReg_FiltroClientes(ByVal Criterio As Integer, Filtro As String,
    '                                         selecBalanza As Boolean, selecCamara As Boolean) As Integer

    '    Dim Consulta As String = ""
    '    Dim Campo As String = ""
    '    Dim numeroRegistros As Integer = 0

    '    Try
    '        '0:cliente | 1:ciudad | 2:empleado
    '        '---------------------------------
    '        If Criterio = 0 Then
    '            Campo = "CLI_RazonSocial"
    '        ElseIf Criterio = 1 Then
    '            Campo = "CLI_Ciudad"
    '        ElseIf Criterio = 2 Then
    '            Campo = "USU_Nombres"
    '        End If

    '        If selecBalanza = True And selecCamara = False Then
    '            Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
    '                       "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
    '                       "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
    '                       "FROM tb_clientes C, tb_usuarios U " & _
    '                       "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
    '                       "C.CLI_Tipo='B' AND " & _
    '                       "C.CLI_Activo='" & 1 & "' AND " & _
    '                       Campo & " LIKE '" & Filtro & "%'"
    '        ElseIf selecCamara = True And selecBalanza = False Then
    '            Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
    '                       "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
    '                       "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
    '                       "FROM tb_clientes C, tb_usuarios U " & _
    '                       "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
    '                       "C.CLI_Tipo='C' AND " & _
    '                       "C.CLI_Activo='" & 1 & "' AND " & _
    '                       Campo & " LIKE '" & Filtro & "%'"
    '        ElseIf selecCamara = True And selecBalanza = True Then
    '            Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
    '                       "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
    '                       "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
    '                       "FROM tb_clientes C, tb_usuarios U " & _
    '                       "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
    '                       "C.CLI_Activo='" & 1 & "' AND " & _
    '                       Campo & " LIKE '" & Filtro & "%'"
    '        Else
    '            Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
    '                       "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
    '                       "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
    '                       "FROM tb_clientes C, tb_usuarios U " & _
    '                       "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
    '                       "C.CLI_Tipo='" & 0 & "' AND " & _
    '                       "C.CLI_Activo='" & 1 & "' AND " & _
    '                       Campo & " LIKE '" & Filtro & "%'"
    '        End If

    '        dt = New Data.DataTable
    '        sqlda = New SqlDataAdapter(Consulta, cnn)
    '        sqlda.Fill(dt)

    '        cnn.Close()

    '        numeroRegistros = dt.Rows.Count
    '    Catch ex As Exception
    '        modProcedimientos.MostrarError(ex.HResult, ex.Message, "clsFunciones")
    '    End Try

    '    getNumReg_FiltroClientes = numeroRegistros
    'End Function

    Public Function obtener_id()
        Try
            Dim consulta As String = "Select PER_Codigo from tb_permisos"
            Dim id As Integer
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(consulta, cnn)
            sqlda.Fill(dt)
            id = dt.Rows.Count
            Return id
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Function
End Class
