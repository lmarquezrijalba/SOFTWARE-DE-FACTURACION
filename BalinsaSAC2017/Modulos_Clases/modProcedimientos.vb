Imports System.Data.SqlClient
Imports System.Speech

Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Font
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Text

Imports Ionic.Zip 'comprimir / descomprimir archivos

Module modProcedimientos

    Dim objMenus As New clsMenus
    Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

    Public NOMBRES_CAJA() As String
    Public REG_MENUS As Boolean
    Public i, c, F, j, S, M, Mes As Integer

    Public MARCAR_FILA As Integer = 0
    Public RUTA_TEMP As String
    Public EXTENSION As String

    'VARIABLES DE CAJA SELECCIONADA
    '---------------------------------
    Public COD_CAJERO, NOMB_CAJERO As String
    Public ES_CAJA_PRINCIPAL, ES_CAJA_APERTURADA As Boolean
    Public TOTAL_CAJA_SOL, TOTAL_CAJA_USD As Double
    Public ULTIMO_ING_SOL, ULTIMO_ING_USD As Double
    Public FECHA_APERTURA As String
    Public MONTO_ACT_CAJASEL_SOL, MONTO_ACT_CAJASEL_USD As Double
    Public MONTO_APERT_SOL, MONTO_APERT_USD As Double

    Dim btns() As Label : Dim btnsAbrir() As Button : Dim btnsCerrar() As Button
    Dim btnsIngreso() As Button : Dim btnsMovimiento() As Button
    Dim btnsListIngresos() As Button : Dim btnsListEgresos() As Button
    Dim btnsCajaActiva() As Label

    Public anioActual As Integer
    Public objFunciones As New clsFunciones
    Public objEncriptacion As New clsEncriptacion
    Public objCODBarras As New clsCODBarras
    Public objImagenes As New clsImagenes
    Public objPDF As New clsPDF

    Public altoPantalla As Integer = desktopSize.Height
    Public anchPantalla As Integer = desktopSize.Width

    Public MONEDA, SIMBOLO_MONEDA As String
    'Public TIPO_INGRESO As String
    Public COD_RECIBIDOR, COD_CONCEPTO As String

    'Public COD_CAJA As String    06-12-15
    Public ESCAJA_PRINCIPAL As Boolean

    Public NOMB_VENTANA_ACTIVA As String

    Dim numCajasCreadas, numCajasActCreadas As Integer

    

    'DATOS DE CAJA ACTIVA
    '---------------------
    'Public MONTO_CAJA_ACTIVA_SELC_SOL, MONTO_CAJA_ACTIVA_SELC_DOL As Double
    'Public NOMB_CAJA_ACTIVA_SELC, COD_CAJA_ACTIVA_SELC, NOMB_CAJERO_ACTIVO_SELC As String

    Public CAJA_SELECCIONADA As Boolean
    Public BLOQUEAR As Boolean = True

    Dim DiasSelec, strFrecuencia As String

    Public GridaProductos() As DataGridView

    Public TIPO_CLIENTE As String

    'Public fuente As Font
    'Public directorioFuentes As String

    Public Sub SOLO_NUMEROS(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub SOLO_TELEFONOS(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/"c Then
            e.Handled = False
        ElseIf e.KeyChar = "*"c Then
            e.Handled = False
        ElseIf e.KeyChar = "#"c Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub SOLO_NUMEROS_DEC(ByVal sender As Object, ByVal e As KeyPressEventArgs, texto As TextBox)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "."c Then
            e.Handled = True
            texto.Text += ","
            texto.SelectionStart = texto.Text.Length
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub SOLO_NUMEROS_PLATAF(ByVal sender As Object, ByVal e As KeyPressEventArgs, texto As TextBox)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "x"c Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub SOLO_LETRAS(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub A_MAYUSCULAS(Texto As TextBox, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then
            Texto.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Public Sub SELEC_TODO_TEXTO(Texto As TextBox)
        If (Not String.IsNullOrEmpty(Texto.Text)) Then
            Texto.SelectionStart = 0
            Texto.SelectionLength = Texto.Text.Length
        End If
    End Sub

    Public Sub Saltar(ByVal e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub listarRequerimientos(ByVal Consulta As String, ByVal GRIDA As DataGridView)
        Dim numReg As Integer
        Dim IDReq, Cliente, Descrip, Estado, Registro, Tipo, strTipo, Fecha As String
        Dim FechaSeg As Date
        Dim fechaActual As Date = Format(Now, "dd/MM/yyyy")

        'Try
        dt = New Data.DataTable
        sqlda = New SqlDataAdapter(Consulta, cnn)
        sqlda.Fill(dt)

        numReg = dt.Rows.Count - 1

        GRIDA.Rows.Clear()

        If numReg >= 0 Then
            For i = 0 To numReg
                IDReq = CStr(dt.Rows(i).Item("REQ_Codigo"))
                Cliente = CStr(dt.Rows(i).Item("CLI_RazonSocial"))
                Descrip = CStr(dt.Rows(i).Item("REQ_Descripcion").ToString)
                Estado = CStr(dt.Rows(i).Item("REQ_Estado"))
                Registro = CStr(dt.Rows(i).Item("USU_Nombres"))
                Fecha = Format(dt.Rows(i).Item("REQ_Fecha"), "dd/MM/yyyy")
                FechaSeg = Format(dt.Rows(i).Item("REQ_FechaSeg"), "dd/MM/yyyy")
                Tipo = CStr(dt.Rows(i).Item("REQ_Tipo").ToString)

                If Tipo = "B" Then
                    strTipo = "BALANZA"
                ElseIf Tipo = "C" Then
                    strTipo = "CÁMARA"
                End If
                'GRIDA.RowTemplate.Height = 42

                If FechaSeg = "01/01/1900" Then
                    GRIDA.Rows.Add(IDReq, i + 1, vbNewLine & _
                                   Cliente & " (" & strTipo & ")" & vbNewLine & vbNewLine & _
                                   "       Fecha: SIN PROGRAMAR " & "    Registró: " & Registro & vbNewLine,
                                   FechaSeg, Estado)
                Else
                    GRIDA.Rows.Add(IDReq, i + 1, vbNewLine & _
                                   Cliente & " (" & strTipo & ")" & vbNewLine & vbNewLine & _
                                   "       Fecha: " & FechaSeg & "    Registró: " & Registro & vbNewLine,
                                   FechaSeg, Estado)
                End If

                If FechaSeg = "01/01/1900" Then
                    GRIDA.Item(1, i).Style.BackColor = Color.Goldenrod 'FromArgb(189, 195, 199)
                    GRIDA.Item(1, i).Style.ForeColor = Color.White
                    GRIDA.Item(2, i).Style.BackColor = Color.FloralWhite 'FromArgb(105, 105, 105)
                    GRIDA.Item(2, i).Style.ForeColor = Color.Silver 'FromArgb(119, 116, 150)
                ElseIf FechaSeg = fechaActual Then
                    GRIDA.Item(1, i).Style.BackColor = Color.FromArgb(6, 108, 182)
                    GRIDA.Item(1, i).Style.ForeColor = Color.White
                    GRIDA.Item(2, i).Style.BackColor = Color.SkyBlue 'Color.FromArgb(205, 180, 140)
                    GRIDA.Item(2, i).Style.ForeColor = Color.FromArgb(244, 244, 244)
                ElseIf FechaSeg > fechaActual Then
                    GRIDA.Item(1, i).Style.BackColor = Color.FromArgb(189, 195, 199)
                    GRIDA.Item(1, i).Style.ForeColor = Color.White
                    GRIDA.Item(2, i).Style.BackColor = Color.FromArgb(239, 243, 244)
                    GRIDA.Item(2, i).Style.ForeColor = Color.FromArgb(119, 116, 150)
                ElseIf FechaSeg < fechaActual Then
                    GRIDA.Item(1, i).Style.BackColor = Color.FromArgb(166, 42, 42)
                    GRIDA.Item(1, i).Style.ForeColor = Color.White
                    GRIDA.Item(2, i).Style.BackColor = Color.FromArgb(220, 20, 59)
                    GRIDA.Item(2, i).Style.ForeColor = Color.FromArgb(255, 192, 203)
                End If

                GRIDA.Rows(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Next
        End If
        'cnn.Close()
        'Catch ex As Exception
        'MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        'End Try
    End Sub

    Public Sub listarCotizaciones(ByVal Consulta As String, ByVal GRIDA As DataGridView)
        Dim numReg, valIGV, numCotizaciones As Integer
        Dim Indice, Fecha, Moneda, Cliente, Registro, Descrip, Estado, Simb, strTotal As String
        Dim SubTot, Tot, MontoIGV As Double

        Dim incluyeIGV As Boolean

        Dim fechaActual As Date = Format(Now, "dd/MM/yyyy")

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            GRIDA.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    Indice = CStr(dt.Rows(i).Item("Indice"))
                    Cliente = CStr(dt.Rows(i).Item("Cliente"))
                    Registro = CStr(dt.Rows(i).Item("Registro"))
                    numCotizaciones = CInt(dt.Rows(i).Item("NumCotiz"))

                    GRIDA.Rows.Add(Indice, i + 1, vbNewLine & _
                                   Cliente & vbNewLine & _
                                   "==============================" & vbNewLine & _
                                   "   N° Raíz: " & Indice & vbNewLine & _
                                   "   Cotizó: " & Registro & vbNewLine & vbNewLine & _
                                   "                              [ " & numCotizaciones & " ] cotizaciones pendientes." & vbNewLine, Indice, Indice)

                    GRIDA.Item(1, i).Style.BackColor = Color.FromArgb(103, 131, 47)
                    GRIDA.Item(1, i).Style.ForeColor = Color.White
                    GRIDA.Item(2, i).Style.BackColor = Color.FromArgb(71, 188, 133)
                    GRIDA.Item(2, i).Style.ForeColor = Color.FromArgb(92, 58, 74)

                    GRIDA.Rows(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Next
            End If
            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", listarCotizaciones)")
        End Try
    End Sub

    Public Sub listar_Detalle_Cotizacion(Consulta As String, GRIDA As DataGridView)
        Dim numDetCot As Integer = 0

        Try
            Dim dtaux1 As DataTable = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dtaux1)

            numDetCot = dtaux1.Rows.Count

            GRIDA.Rows.Clear()

            For i = 0 To numDetCot - 1
                GRIDA.Rows.Add(dtaux1.Rows(i).Item("DCOT_Codigo"), i + 1, dtaux1.Rows(i).Item("PRD_Nombre"),
                          Format(dtaux1.Rows(i).Item("DCOT_Precio"), "#,##0.00"),
                          dtaux1.Rows(i).Item("DCOT_Cant"),
                          Format(dtaux1.Rows(i).Item("Importe"), "#,##0.00"),
                          dtaux1.Rows(i).Item("PRD_Codigo"))
            Next
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "(modProcedimientos, listar_Detalle_Cotizacion())")
        End Try
    End Sub

    Public Sub listarTodasCotizaciones(ByVal Consulta As String, ByVal GRIDA As DataGridView)
        Dim numReg As Integer
        Dim IDCotizacion, Fecha, Descrip, Moneda, Simb, Registro, Estado, strEstado, strIGV, strINST As String
        Dim Importe As Double

        Dim incluyeIGV, incluyeINST As Boolean

        Dim fechaActual As Date = Format(Now, "dd/MM/yyyy")

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            GRIDA.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    IDCotizacion = CStr(dt.Rows(i).Item("COT_Codigo"))
                    Descrip = CStr(dt.Rows(i).Item("COT_Descripcion").ToString)
                    Estado = CStr(dt.Rows(i).Item("COT_Estado"))
                    Registro = CStr(dt.Rows(i).Item("USU_Nombres"))
                    Fecha = Format(dt.Rows(i).Item("COT_Fecha"), "dd/MM/yyyy")
                    Moneda = CStr(dt.Rows(i).Item("COT_Moneda"))
                    Importe = dt.Rows(i).Item("COT_Importe")
                    incluyeIGV = CBool(dt.Rows(i).Item("COT_CONIGV"))
                    incluyeINST = CBool(dt.Rows(i).Item("COT_CONINST"))

                    If incluyeIGV Then
                        'Tot = SubTot + MontoIGV
                        strIGV = ""
                    Else
                        'Tot = SubTot
                        strIGV = " + IGV"
                    End If

                    If incluyeINST Then
                        strINST = "SI"
                    Else
                        strINST = "NO"
                    End If

                    If Moneda = "S" Then
                        Simb = "SOL"
                    ElseIf Moneda = "D" Then
                        Simb = "USD"
                    End If

                    If Estado = 1 Then
                        strEstado = "EN ESPERA"
                    ElseIf Estado = 2 Then
                        strEstado = "APROBADA"
                    End If

                    GRIDA.RowTemplate.Height = 23

                    'If FechaSeg = "01/01/1900" Then
                    GRIDA.Rows.Add(IDCotizacion, Fecha, Descrip, Simb,
                                   Format(Importe, "#,##0.00") & strIGV,
                                   strINST, Registro, strEstado)

                    If Estado = 1 Then
                        GRIDA.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244)
                        GRIDA.Rows(i).DefaultCellStyle.ForeColor = Color.FromArgb(136, 134, 137)
                    ElseIf Estado = 2 Then
                        GRIDA.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(20, 178, 203)
                        GRIDA.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If

                    'GRIDA.Rows(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Next
            End If
            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", listarCotizaciones)")
        End Try
    End Sub

    Public Sub listarNotas_x_Usu(ByVal Consulta As String, ByVal GRIDA As DataGridView)
        Dim numReg As Integer
        Dim IDNota, Titulo As String

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            GRIDA.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    IDNota = CStr(dt.Rows(i).Item("NOT_Codigo"))
                    Titulo = CStr(dt.Rows(i).Item("NOT_Titulo"))

                    GRIDA.RowTemplate.Height = 23
                    GRIDA.Rows.Add(IDNota, Titulo)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarRecordatorios_x_Usu(ByVal Grida As DataGridView, ByVal IDUsuario As String)
        Dim numReg As Integer
        Dim sqlRecordatorios As String
        Dim codRecordatorio, Fecha, Hora, Frec, Descripcion As String
        Dim Lun, Mar, Mie, Jue, Vie, Sab, Dom As Boolean

        Lun = False : Jue = False
        Mar = False : Vie = False
        Mie = False : Sab = False : Dom = False

        'strFrecuencia = ""

        sqlRecordatorios = "SELECT * FROM tb_notas_x_usuario " & _
                           "WHERE USU_Codigo='" & IDUsuario & "' " & _
                           "AND NOT_Estado='" & 1 & "'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlRecordatorios, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    DiasSelec = ""

                    codRecordatorio = CStr(dt.Rows(i).Item("NOT_Codigo"))
                    Fecha = CDate(dt.Rows(i).Item("NOT_Fecha"))
                    Frec = CInt(dt.Rows(i).Item("NOT_Frecuencia"))
                    Hora = Format(CDate(dt.Rows(i).Item("NOT_Hora")), "H:mm")
                    Descripcion = CStr(dt.Rows(i).Item("NOT_Descripcion"))
                    Dom = CBool(dt.Rows(i).Item("NOT_Dom"))
                    Lun = CBool(dt.Rows(i).Item("NOT_Lun"))
                    Mar = CBool(dt.Rows(i).Item("NOT_Mar"))
                    Mie = CBool(dt.Rows(i).Item("NOT_Mie"))
                    Jue = CBool(dt.Rows(i).Item("NOT_Jue"))
                    Vie = CBool(dt.Rows(i).Item("NOT_Vie"))
                    Sab = CBool(dt.Rows(i).Item("NOT_Sab"))

                    If Frec = 0 Then
                        If Lun = True Then
                            DiasSelec = DiasSelec & "Lun, "
                        End If

                        If Mar = True Then
                            DiasSelec = DiasSelec & "Mar, "
                        End If

                        If Mie = True Then
                            DiasSelec = DiasSelec & "Mie, "
                        End If

                        If Jue = True Then
                            DiasSelec = DiasSelec & "Jue, "
                        End If

                        If Vie = True Then
                            DiasSelec = DiasSelec & "Vie, "
                        End If

                        If Sab = True Then
                            DiasSelec = DiasSelec & "Sab, "
                        End If

                        'strFrecuencia = "Frecuencia : ( " & Mid(Trim(DiasSelec), 1, Len(Trim(DiasSelec)) - 1) & " )"
                        strFrecuencia = Mid(Trim(DiasSelec), 1, Len(Trim(DiasSelec)) - 1)
                    ElseIf Frec = 1 Then
                        strFrecuencia = "Diaria"
                    ElseIf Frec = 2 Then
                        strFrecuencia = "Semanal"
                    ElseIf Frec = 3 Then
                        strFrecuencia = "Mensual"
                    End If

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codRecordatorio, Fecha, Hora, strFrecuencia, Descripcion)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarPermisos(ByVal Grida As DataGridView, ByVal IDNivel As String)
        Dim numReg As Integer
        Dim sqlPermisosAsign As String
        Dim Modulo, desPermiso As String
        Dim codPermisos, codSelec As Integer

        sqlPermisosAsign = "SELECT P.PER_Codigo, P.PER_NombModulo, P.PER_Descripcion, " & _
                           "(SELECT PN.PER_Codigo FROM tb_permisos_x_nivel PN " & _
                           "WHERE PN.PER_Codigo=P.PER_Codigo " & _
                           "AND PN.NUSU_Codigo='" & IDNivel & "') AS Selec " & _
                           "FROM tb_permisos P " & _
                           "WHERE PER_Activo='" & 1 & "' " & _
                           "ORDER BY PER_NombModulo, PER_Descripcion ASC"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlPermisosAsign, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1
            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codPermisos = CInt(dt.Rows(i).Item("PER_Codigo"))
                    Modulo = CStr(dt.Rows(i).Item("PER_NombModulo"))
                    desPermiso = CStr(dt.Rows(i).Item("PER_Descripcion"))

                    If Not IsDBNull(dt.Rows(i).Item("Selec")) Then
                        codSelec = CInt(dt.Rows(i).Item("Selec"))
                    End If

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codPermisos, Modulo, desPermiso)

                    If codPermisos = codSelec Then
                        Grida.Item(3, i).Value = True
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192)
                    Else
                        Grida.Item(3, i).Value = False
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarGastos_x_Mov(ByVal Grida As DataGridView, ByVal IDMov As String)
        Dim numReg As Integer
        Dim sqlDetalleGasto, Concepto
        Dim MontoSoles As String
        Dim MontoDolares As String

        sqlDetalleGasto = "SELECT DGAS_Descripcion, DGAS_MontoSoles, " & _
                          "DGAS_MontoDolares " & _
                          "FROM tb_detalle_gastos " & _
                          "WHERE MCAJ_Codigo ='" & IDMov & "'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlDetalleGasto, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count
            Grida.Rows.Clear()

            If numReg > 0 Then
                For i = 0 To numReg - 1
                    Concepto = CStr(dt.Rows(i).Item("DGAS_Descripcion"))
                    MontoSoles = Format(CDbl(dt.Rows(i).Item("DGAS_MontoSoles")), "#,##0.00")
                    MontoDolares = Format(CDbl(dt.Rows(i).Item("DGAS_MontoDolares")), "#,##0.00")

                    Grida.RowTemplate.Height = 23

                    If MontoSoles = 0 Or MontoSoles = "" Then
                        Grida.Rows.Add(Concepto, MontoDolares)
                    ElseIf MontoDolares = 0 Or MontoDolares = "" Then
                        Grida.Rows.Add(Concepto, MontoSoles)
                    End If
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", listarGastos_x_Mov())")
        End Try
    End Sub

    Public Sub listarProductos(ByVal Grida As DataGridView, ByVal Consulta As String, ByVal Completa As Boolean)
        Dim numReg As Integer
        Dim codProducto, Marca, Modelo, NombProducto, Moneda, Especificaciones, DescProd, SimboloMoneda As String
        Dim Precio As Double
        Dim Dscto, Stock As Integer
        Dim Imagen As Image

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count
            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg - 1
                    codProducto = CStr(dt.Rows(i).Item("PRD_Codigo"))
                    Marca = CStr(dt.Rows(i).Item("MAR_Nombre").ToString)
                    Modelo = CStr(dt.Rows(i).Item("PRD_Modelo").ToString)
                    NombProducto = CStr(dt.Rows(i).Item("PRD_Nombre").ToString)

                    If Marca = "NO REGISTRA" And Modelo <> "NO REGISTRA" Then
                        DescProd = NombProducto & " MOD. " & Modelo
                    ElseIf Modelo = "NO REGISTRA" And Marca <> "NO REGISTRA" Then
                        DescProd = NombProducto & " MAR. " & Marca
                    ElseIf Marca = "NO REGISTRA" And Modelo = "NO REGISTRA" Then
                        DescProd = NombProducto
                    ElseIf Marca <> "NO REGISTRA" And Modelo <> "NO REGISTRA" Then
                        DescProd = NombProducto & " MAR. " & Marca & " MOD. " & Modelo
                    End If

                    Moneda = CStr(dt.Rows(i).Item("PRD_Moneda"))

                    If Moneda = "S" Then
                        SimboloMoneda = "SOL"
                    ElseIf Moneda = "D" Then
                        SimboloMoneda = "USD"
                    End If

                    Precio = CDbl(dt.Rows(i).Item("PRD_Precio"))
                    Dscto = CInt(dt.Rows(i).Item("PRD_Dscto"))
                    Stock = CInt(dt.Rows(i).Item("PRD_Stock"))
                    Especificaciones = CStr(dt.Rows(i).Item("PRD_Especificaciones").ToString)

                    Imagen = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(i).Item("PRD_Imagen"), Byte())).GetThumbnailImage(45, 45, Nothing, IntPtr.Zero)

                    Grida.RowTemplate.Height = 45
                    Grida.Font = New Font(New FontFamily("Courier New"), 8, FontStyle.Bold)

                    If Completa = True Then
                        Grida.Columns(5).DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 239, 240)
                        Grida.Columns(5).DefaultCellStyle.SelectionForeColor = Color.FromArgb(192, 54, 35)
                        Grida.Columns(5).DefaultCellStyle.BackColor = Color.FromArgb(235, 239, 240)

                        Grida.Rows.Add(codProducto, Marca, Modelo, DescProd, SimboloMoneda, Format(Precio, "#,##0.00"), Dscto, Stock, Imagen)
                    Else
                        Grida.Columns(3).DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 239, 240)
                        Grida.Columns(3).DefaultCellStyle.SelectionForeColor = Color.FromArgb(192, 54, 35)
                        Grida.Columns(3).DefaultCellStyle.BackColor = Color.FromArgb(235, 239, 240)

                        Grida.Rows.Add(codProducto, DescProd, SimboloMoneda, Format(Precio, "#,##0.00"), Imagen)
                    End If
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarCalibraciones(ByVal Grida As DataGridView, ByVal Consulta As String)
        Dim numReg As Integer
        Dim IDCalibracion, Modelo As String
        'Dim Imagen As Image

        Try
            dtaux = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dtaux)

            numReg = dtaux.Rows.Count
            Grida.Rows.Clear()

            If numReg > 0 Then
                Grida.RowTemplate.Height = 24

                For i = 0 To numReg - 1
                    IDCalibracion = CStr(dtaux.Rows(i).Item("CAL_Codigo"))
                    Modelo = CStr(dtaux.Rows(i).Item("Modelo"))

                    Grida.Rows.Add(IDCalibracion, Modelo, "Abrir...")
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", listarCalibraciones())")
        End Try
    End Sub

    Public Sub filtrarProductos(ByVal Grida As DataGridView, ByVal Consulta As String)
        Dim numReg As Integer
        Dim codProducto, Marca, Modelo, NombProducto, Moneda, Especificaciones As String
        Dim Precio As String
        Dim Dscto, Stock As Integer
        Dim Imagen As Image

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1
            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codProducto = CStr(dt.Rows(i).Item("PRD_Codigo"))
                    Marca = CStr(dt.Rows(i).Item("MAR_Nombre").ToString)
                    Modelo = CStr(dt.Rows(i).Item("PRD_Modelo").ToString)
                    NombProducto = CStr(dt.Rows(i).Item("PRD_Nombre"))
                    Moneda = CStr(dt.Rows(i).Item("PRD_Moneda"))
                    Precio = Format(CDbl(dt.Rows(i).Item("PRD_Precio")), "#,##0.00")
                    Dscto = CInt(dt.Rows(i).Item("PRD_Dscto"))
                    Stock = CInt(dt.Rows(i).Item("PRD_Stock"))
                    Especificaciones = CStr(dt.Rows(i).Item("PRD_Especificaciones").ToString)

                    Imagen = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(i).Item("PRD_Imagen"), Byte())).GetThumbnailImage(40, 40, Nothing, IntPtr.Zero)

                    Grida.RowTemplate.Height = 40
                    Grida.Rows.Add(codProducto, NombProducto & " MARCA: " & Marca & " MODELO: " & Modelo, Stock, Precio, Imagen)
                Next
            End If

            ''cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", filtrarProductos())")
        End Try
    End Sub

    Public Sub listarContact_x_Cliente(ByVal Grida As DataGridView, ByVal Consulta As String)
        Dim numReg As Integer
        Dim IDContacto, Nombres, Cargo, Fono, Correo, Observ As String
        Dim Imagen As Image

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1
            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    IDContacto = CInt(dt.Rows(i).Item("CON_Codigo"))
                    Nombres = CStr(dt.Rows(i).Item("CON_Nombres").ToString)
                    Cargo = CStr(dt.Rows(i).Item("CON_Cargo").ToString)
                    Fono = CStr(dt.Rows(i).Item("CON_Telefono").ToString)
                    Correo = CStr(dt.Rows(i).Item("CON_Correo").ToString)
                    Observ = CStr(dt.Rows(i).Item("CON_Observacion").ToString)

                    Imagen = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(i).Item("CON_Tarjeta"), Byte())).GetThumbnailImage(100, 40, Nothing, IntPtr.Zero)

                    Grida.RowTemplate.Height = 40
                    Grida.Rows.Add(IDContacto, Nombres, Cargo, Fono, Correo, Imagen, Observ)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarUsuarios(ByVal Consulta As String, ByVal Grida As DataGridView)
        Dim numReg As Integer
        Dim codUsuario, desNivel, usuNombres, usuLogin, strAlta As String
        Dim estConexion, Alta As Boolean

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1
            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codUsuario = CStr(dt.Rows(i).Item("USU_Codigo"))
                    desNivel = CStr(dt.Rows(i).Item("NUSU_Descripcion"))
                    usuNombres = CStr(dt.Rows(i).Item("USU_Nombres"))
                    usuLogin = CStr(dt.Rows(i).Item("USU_Login"))
                    estConexion = CBool(dt.Rows(i).Item("USU_Conectado"))
                    Alta = CBool(dt.Rows(i).Item("USU_Activo"))

                    If Alta Then
                        strAlta = "Activo"
                    Else
                        strAlta = "Baja"
                    End If

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codUsuario, desNivel, usuNombres, usuLogin, estConexion, strAlta)

                    If estConexion Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(159, 215, 180)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    ElseIf estConexion = False And Alta = True Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.White
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    ElseIf estConexion = False And Alta = False Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(244, 143, 118)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarNiveles(ByVal Grida As DataGridView)
        Dim numReg As Integer
        Dim sqlNiveles As String
        Dim codNivel, desNivel As String

        sqlNiveles = "SELECT * FROM tb_niv_usuarios"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlNiveles, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codNivel = CStr(dt.Rows(i).Item("NUSU_Codigo"))
                    desNivel = CStr(dt.Rows(i).Item("NUSU_Descripcion"))

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codNivel, desNivel)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarCategorias(ByVal Combo As ComboBox, Consulta As String)
        Dim numReg As Integer

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = "CAT_Nombre"
                    .ValueMember = "CAT_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarCajasActivas(ByVal Combo As ComboBox, Consulta As String)
        Dim numReg As Integer

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            'If numReg > 0 Then
            With Combo
                .DataSource = dt
                .DisplayMember = "CAJ_Nombre"
                .ValueMember = "CAJ_Codigo"
            End With
            'End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarCiudades(ByVal Combo As ComboBox)
        Dim numReg As Integer
        Dim sqlConceptos As String

        sqlConceptos = "SELECT '0' AS PROV_Codigo, 'Seleccione' AS PROV_Nombre " & _
                       "UNION SELECT PROV_Codigo, PROV_Nombre " & _
                       "FROM tb_provincias"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlConceptos, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = "PROV_Nombre"
                    .ValueMember = "PROV_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarConceptosdeCajaxTipo(ByVal Combo As ComboBox)
        Dim numReg As Integer
        Dim sqlConceptos As String

        sqlConceptos = "SELECT CON_Codigo, CON_Descripcion " & _
                       "FROM tb_conceptos " & _
                       "WHERE CON_Tipo='E'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlConceptos, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then

                With Combo
                    .DataSource = dt
                    .DisplayMember = "CON_Descripcion"
                    .ValueMember = "CON_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarUsuarios(ByVal Combo As ComboBox)
        Dim numReg As Integer
        Dim sqlUsuarios As String

        sqlUsuarios = "SELECT '0' AS USU_Codigo, 'Seleccione' AS USU_Nombres " & _
                      "UNION SELECT USU_Codigo, USU_Nombres " & _
                      "FROM tb_usuarios " & _
                      "WHERE USU_Activo='" & 1 & "'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlUsuarios, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = "USU_Nombres"
                    .ValueMember = "USU_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarDetalleGasto(ByVal Combo As ComboBox)
        Dim numReg As Integer
        Dim sqlDetalle As String
        Dim IDMov, IDConcepto, DesConcep, FechaMov, MontoMov_Sol, MontoMov_Dol, DetalleMov As String
        Dim Detalle As String = ""

        Dim comboSource As New Dictionary(Of String, String)()

        sqlDetalle = "SELECT MC.MCAJ_Codigo, MC.MCAJ_FechaHora, MC.MCAJ_Detalle, MC.MCAJ_MontoSoles, " & _
                     "MC.MCAJ_MontoDolares, C.CON_Codigo, C.CON_Descripcion " & _
                     "FROM tb_movimiento_cajas MC, tb_conceptos C " & _
                     "WHERE C.CON_Codigo=MC.CON_Codigo AND " & _
                     "MC.MCAJ_Recibidor='" & USU_CODIGO & "' AND " & _
                     "MC.CON_Codigo<>'T001' AND MC.MCAJ_Activo='" & 1 & "'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlDetalle, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                comboSource.Add("0", "Seleccione")

                For i = 0 To numReg - 1
                    IDConcepto = CStr(dt.Rows(i).Item("CON_Codigo"))
                    DesConcep = CStr(dt.Rows(i).Item("CON_Descripcion"))
                    IDMov = CStr(dt.Rows(i).Item("MCAJ_Codigo"))
                    FechaMov = Format((dt.Rows(i).Item("MCAJ_FechaHora")), "dd/MM/yyyy")
                    MontoMov_Sol = Format((dt.Rows(i).Item("MCAJ_MontoSoles")), "#,##0.00")
                    MontoMov_Dol = Format((dt.Rows(i).Item("MCAJ_MontoDolares")), "#,##0.00")
                    DetalleMov = CStr(dt.Rows(i).Item("MCAJ_Detalle"))

                    If MontoMov_Sol = 0 Then
                        If DesConcep = "Seleccione" Then
                            Detalle = "[ " & MontoMov_Dol & " ] " & DetalleMov '& " IMPORTE: " & MontoMov
                        Else
                            Detalle = "[ " & MontoMov_Dol & " ] " & DesConcep '& " IMPORTE: " & MontoMov
                        End If
                    ElseIf MontoMov_Dol = 0 Then
                        If DesConcep = "Seleccione" Then
                            Detalle = "[ " & MontoMov_Sol & " ] " & DetalleMov '& " IMPORTE: " & MontoMov
                        Else
                            Detalle = "[ " & MontoMov_Sol & " ] " & DesConcep '& " IMPORTE: " & MontoMov
                        End If
                    End If

                    comboSource.Add(IDMov, Detalle)

                    With Combo
                        .DataSource = New BindingSource(comboSource, Nothing)
                        .DisplayMember = "Value"
                        .ValueMember = "Key"
                    End With
                Next
            Else
                comboSource.Add("0", "No tiene gastos pendientes")

                With Combo
                    .DataSource = New BindingSource(comboSource, Nothing)
                    .DisplayMember = "Value"
                    .ValueMember = "Key"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarNivUsuario(ByVal Combo As ComboBox)
        Dim numReg As Integer
        Dim sqlNiveles As String

        sqlNiveles = "SELECT NUSU_Codigo, NUSU_Descripcion " & _
                     "FROM tb_niv_usuarios"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlNiveles, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = "NUSU_Descripcion"
                    .ValueMember = "NUSU_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub llenarCajas(ByVal Combo As ComboBox, ByVal Consulta As String)
        Dim numReg As Integer

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = "CAJ_Nombre"
                    .ValueMember = "CAJ_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarClientesFactura(ByVal GRIDA As DataGridView, ByVal Parametro As String)
        Dim numReg As Integer
        Dim ID_Cliente, RazonSocial As String
        Dim sqlCliente As String

        sqlCliente = "SELECT CLI_Codigo, CLI_RazonSocial " & _
                     "FROM tb_clientes " & _
                     "WHERE CLI_RazonSocial LIKE '%" & Parametro & "%' AND " & _
                     "CLI_Activo='1'"

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlCliente, cnn)
            sqlda.Fill(dt)

            'cnn.Close()

            numReg = dt.Rows.Count

            GRIDA.Rows.Clear()

            If numReg > 0 Then
                GRIDA.Visible = True

                For i = 0 To numReg - 1
                    ID_Cliente = CStr(dt.Rows(i).Item("CLI_Codigo"))
                    RazonSocial = CStr(dt.Rows(i).Item("CLI_RazonSocial"))

                    GRIDA.RowTemplate.Height = 23
                    GRIDA.Rows.Add(ID_Cliente, RazonSocial)
                Next
            Else
                GRIDA.Visible = False
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub MostrarError(ByVal NumError As Integer, ByVal DescError As String, _
                            ByVal Origen As String)
        Try
            'cnn.Close()

            With FrmMostrarErrores
                .txtDetalle.Text = "Error Nro : " & NumError & vbNewLine & _
                                    Origen & vbNewLine & vbNewLine & _
                                    DescError

                .ShowDialog()
            End With
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")

        End Try
    End Sub

    'Public Sub listarClientes(ByVal Consulta As String, ByVal Grida As DataGridView)
    '    Dim numReg As Integer
    '    Dim codCliente, UsuarioRegistro, RS, RUC, Ciudad, DirecLegal, observ As String

    '    Try
    '        dt = New Data.DataTable
    '        sqlda = New SqlDataAdapter(Consulta, cnn)
    '        sqlda.Fill(dt)

    '        numReg = dt.Rows.Count - 1

    '        Grida.Rows.Clear()

    '        If numReg >= 0 Then
    '            For i = 0 To numReg
    '                codCliente = CStr(dt.Rows(i).Item("CLI_Codigo"))
    '                UsuarioRegistro = CStr(dt.Rows(i).Item("USU_Nombres"))
    '                RS = CStr(dt.Rows(i).Item("CLI_RazonSocial"))
    '                RUC = CStr(dt.Rows(i).Item("CLI_RUC"))
    '                Ciudad = CStr(dt.Rows(i).Item("CLI_Ciudad"))
    '                DirecLegal = CStr(dt.Rows(i).Item("CLI_DireccionLegal").ToString)
    '                observ = CStr(dt.Rows(i).Item("CLI_Observacion").ToString)

    '                Grida.RowTemplate.Height = 23
    '                Grida.Rows.Add(codCliente, RUC, RS, DirecLegal, Ciudad, UsuarioRegistro)
    '            Next
    '        End If

    '        'cnn.Close()
    '    Catch ex As Exception
    '        MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", listarClientes())")
    '    End Try
    'End Sub

    Public Sub filtrar_Clientes(ByVal Grida As DataGridView, ByVal Criterio As Integer,
                                ByVal MostrarRegistros As Label,
                                ByVal Filtro As String, Optional Balanza As Boolean = False,
                                Optional Camara As Boolean = False)


        Dim Consulta As String = ""
        Dim Campo As String = ""
        Dim numReg, numVentas_x_Cliente As Integer
        Dim codCliente, UsuarioRegistro, RS, RUC, Ciudad, DirecLegal, observ As String

        Try
            '0:cliente | 1:ciudad | 2:empleado
            '---------------------------------
            If Criterio = 0 Then
                Campo = "CLI_RazonSocial"
            ElseIf Criterio = 1 Then
                Campo = "CLI_Ciudad"
            ElseIf Criterio = 2 Then
                Campo = "USU_Nombres"
            End If

            If Balanza = True And Camara = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Tipo='B' AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = True And Balanza = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Tipo='C' AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = True And Balanza = True Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = False And Balanza = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, " & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            End If

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            'cnn.Close()

            numReg = dt.Rows.Count
            MostrarRegistros.Text = numReg

            Grida.Rows.Clear()

            If numReg > 0 Then
                For i = 0 To numReg - 1
                    codCliente = CStr(dt.Rows(i).Item("CLI_Codigo").ToString)
                    UsuarioRegistro = CStr(dt.Rows(i).Item("USU_Nombres").ToString)
                    RS = CStr(dt.Rows(i).Item("CLI_RazonSocial").ToString)
                    RUC = CStr(dt.Rows(i).Item("CLI_RUC").ToString)
                    Ciudad = CStr(dt.Rows(i).Item("CLI_Ciudad").ToString)
                    DirecLegal = CStr(dt.Rows(i).Item("CLI_DireccionLegal").ToString)
                    observ = CStr(dt.Rows(i).Item("CLI_Observacion").ToString)
                    numVentas_x_Cliente = CInt(dt.Rows(i).Item("NVent").ToString)

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codCliente, i + 1, RUC, RS, DirecLegal, Ciudad, UsuarioRegistro, numVentas_x_Cliente)

                    If numVentas_x_Cliente > 0 Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(239, 249, 218)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Else
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub filtrar_Clientes_Impresion(ByVal Grida As DataGridView, ByVal Criterio As Integer,
                               ByVal MostrarRegistros As Label,
                               ByVal Filtro As String, Optional Balanza As Boolean = False,
                               Optional Camara As Boolean = False)


        Dim Consulta As String = ""
        Dim Campo As String = ""
        Dim numReg, numVentas_x_Cliente As Integer
        Dim RS, observ, clientes, cargo, telefono, correo As String

        Try
            '0:cliente | 1:ciudad | 2:empleado
            '---------------------------------
            If Criterio = 0 Then
                Campo = "CLI_RazonSocial"
            ElseIf Criterio = 1 Then
                Campo = "CLI_Ciudad"
            ElseIf Criterio = 2 Then
                Campo = "USU_Nombres"
            End If

            If Balanza = True And Camara = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, CC.CON_CARGO, CC.CON_NOMBRES, CC.CON_TELEFONO," & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, CC.CON_CORREO," & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U, tb_contato_x_clientes CC " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND C.CLI_CODIGO = CC.CLI_CODIGO AND " & _
                           "C.CLI_Tipo='B' AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = True And Balanza = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, CC.CON_CARGO, CC.CON_NOMBRES, CC.CON_TELEFONO," & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, CC.CON_CORREO," & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U, tb_contato_x_clientes CC " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND C.CLI_CODIGO = CC.CLI_CODIGO AND " & _
                           "C.CLI_Tipo='C' AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = True And Balanza = True Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, CC.CON_CARGO, CC.CON_NOMBRES, CC.CON_TELEFONO," & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, CC.CON_CORREO," & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U, tb_contato_x_clientes CC " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND C.CLI_CODIGO = CC.CLI_CODIGO AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = False And Balanza = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, CC.CON_CARGO, CC.CON_NOMBRES, CC.CON_TELEFONO," & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo, CC.CON_CORREO," & _
                           "(SELECT COUNT(F.FAC_Codigo) FROM tb_facturas F WHERE F.CLI_Codigo=C.CLI_Codigo AND F.FAC_Activo='1') AS NVent " & _
                           "FROM tb_clientes C, tb_usuarios U, tb_contato_x_clientes CC " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND C.CLI_CODIGO = CC.CLI_CODIGO AND " & _
                           "C.CLI_Activo='" & 1 & "' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            End If

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            'cnn.Close()

            numReg = dt.Rows.Count
            MostrarRegistros.Text = numReg

            Grida.Rows.Clear()

            If numReg > 0 Then
                For i = 0 To numReg - 1
                    RS = CStr(dt.Rows(i).Item("CLI_RazonSocial").ToString)
                    observ = CStr(dt.Rows(i).Item("CLI_Observacion").ToString)
                    clientes = CStr(dt.Rows(i).Item("CON_NOMBRES").ToString)
                    cargo = CStr(dt.Rows(i).Item("CON_CARGO").ToString)
                    telefono = CStr(dt.Rows(i).Item("CON_TELEFONO").ToString)
                    correo = CStr(dt.Rows(i).Item("CON_CORREO").ToString)

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(i + 1, RS, clientes, cargo, telefono, correo, observ)

                    If numVentas_x_Cliente > 0 Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(239, 249, 218)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Else
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub


    Public Sub listarMarcas(ByVal Grida As DataGridView, ByVal Consulta As String)
        Dim numReg As Integer
        Dim codMarca, Desc, Estado As String

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codMarca = CStr(dt.Rows(i).Item("MAR_Codigo"))
                    Desc = CStr(dt.Rows(i).Item("MAR_Nombre"))
                    Estado = CStr(dt.Rows(i).Item("MAR_Activo"))

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codMarca, Desc, Estado)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarModelos(ByVal Grida As DataGridView, Consulta As String)
        Dim numReg As Integer
        Dim codModelo, Desc, Estado As String

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codModelo = CStr(dt.Rows(i).Item("MOD_Codigo"))
                    Desc = CStr(dt.Rows(i).Item("MOD_Descripcion"))
                    Estado = CStr(dt.Rows(i).Item("MOD_Estado"))

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codModelo, Desc, Estado)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarConceptos(ByVal Grida As DataGridView, ByVal Consulta As String)
        Dim numReg As Integer
        Dim codConcepto, conDescripcion, conTipo As String

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codConcepto = CStr(dt.Rows(i).Item("CON_Codigo"))
                    conDescripcion = CStr(dt.Rows(i).Item("CON_Descripcion"))
                    conTipo = CStr(dt.Rows(i).Item("CON_Tipo"))

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codConcepto, conDescripcion, conTipo)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarFacturas(ByVal Grida As DataGridView, ByVal Anio As String)

        Dim sqlFacturas_x_Mes As String = ""

        Dim numReg As Integer
        Dim nroFactura, strFactura, Fecha, Observ, strActivo As String
        Dim Activo As Boolean
        Dim Moneda As String = "" : Dim Simb As String = ""
        Dim Subtot, valIGV, Tot As Double

        Dim SOL_Sum_SubTotal As Double : Dim USD_Sum_SubTotal As Double
        Dim SOL_Sum_IGV As Double : Dim USD_Sum_IGV As Double
        Dim SOL_Sum_Total As Double : Dim USD_Sum_Total As Double

        Dim RegSOL As Integer : Dim RegDOL As Integer
        Try
            Grida.Rows.Clear()

            For Mes = 1 To 12
                sqlFacturas_x_Mes =
                "SELECT FAC_Codigo, FAC_Fecha, FAC_Observacion, FAC_Subtotal, " & _
                "FAC_valIGV, FAC_Total, FAC_Activo, FAC_Moneda " & _
                "FROM tb_facturas " & _
                "WHERE DATEPART(YEAR, FAC_Fecha)='" & Anio & "' AND " & _
                "DATEPART(MONTH, FAC_Fecha)='" & Mes & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlFacturas_x_Mes, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    Grida.Rows.Add("", "", objFunciones.obtenerNombreMes(Mes) & " DEL " & Anio, "", "", "", "", "")
                    Grida.Rows(Grida.RowCount - 1).Height = 30
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(136, 134, 137)
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

                    SOL_Sum_SubTotal = 0 : USD_Sum_SubTotal = 0
                    SOL_Sum_IGV = 0 : USD_Sum_IGV = 0
                    SOL_Sum_Total = 0 : USD_Sum_Total = 0

                    RegSOL = 0 : RegDOL = 0

                    For i = 0 To numReg - 1
                        nroFactura = CStr(dt.Rows(i).Item("FAC_Codigo"))
                        Fecha = Format(dt.Rows(i).Item("FAC_Fecha"), "dd/MM/yyyy")
                        Observ = CStr(dt.Rows(i).Item("FAC_Observacion").ToString)
                        Subtot = dt.Rows(i).Item("FAC_Subtotal")
                        valIGV = dt.Rows(i).Item("FAC_valIGV")
                        Tot = dt.Rows(i).Item("FAC_Total")
                        Activo = dt.Rows(i).Item("FAC_Activo")
                        Moneda = dt.Rows(i).Item("FAC_Moneda")

                        If Activo Then
                            strActivo = "ACTIVA"
                        Else
                            strActivo = "ANULADA"
                        End If

                        If Moneda = "S" Then
                            Simb = "SOL"
                            RegSOL += 1
                        ElseIf Moneda = "D" Then
                            Simb = "USD"
                            RegDOL += 1
                        End If

                        If Activo And Moneda = "S" Then
                            SOL_Sum_SubTotal += Subtot
                            SOL_Sum_IGV += valIGV
                            SOL_Sum_Total += Tot
                        ElseIf Activo And Moneda = "D" Then
                            USD_Sum_SubTotal += Subtot
                            USD_Sum_IGV += valIGV
                            USD_Sum_Total += Tot
                        End If

                        strFactura = Mid(nroFactura, 1, 4) & "-" & Mid(nroFactura, 5, 6)

                        Grida.RowTemplate.Height = 23
                        Grida.Rows.Add(strFactura, Fecha, Observ, Simb, Format(Subtot, "#,##0.00"), Format(valIGV, "#,##0.00"), Format(Tot, "#,##0.00"), strActivo)

                        If Activo = True Then
                            Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(0, 130, 156)
                            Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                        ElseIf Activo = False Then
                            Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(217, 47, 0)
                            Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                        End If
                    Next

                    Grida.Rows.Add("", "", "", "Tot.",
                                  "S/ " & Format(SOL_Sum_SubTotal, "#,##0.00"),
                                  "S/ " & Format(SOL_Sum_IGV, "#,##0.00"),
                                  "S/ " & Format(SOL_Sum_Total, "#,##0.00"),
                                   RegSOL & " Reg.")

                    'Grida.Item(2, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Grida.Item(7, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Font = New Drawing.Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)

                    '.CellBorderStyle = DataGridViewCellBorderStyle.None

                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(198, 204, 204)
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.Blue

                    Grida.Rows.Add("", "", "", "Tot.",
                                   "$ " & Format(USD_Sum_SubTotal, "#,##0.00"),
                                   "$ " & Format(USD_Sum_IGV, "#,##0.00"),
                                   "$ " & Format(USD_Sum_Total, "#,##0.00"),
                                   RegDOL & " Reg.")

                    'Grida.Item(2, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Grida.Item(7, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Font = New Drawing.Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)

                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(198, 204, 204)
                    Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.Blue
                End If
            Next

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub filtrarFacturas(ByVal IDCliente As String, ByVal Grida As DataGridView,
                               ByVal Anio As String)

        Dim sqlFiltrarFacturas As String = ""

        Dim numReg As Integer
        Dim nroFactura, strFactura, Fecha, Observ, strActivo As String
        Dim Activo As Boolean
        Dim Moneda As String = "" : Dim Simb As String = ""
        Dim Subtot, valIGV, Tot As Double

        Dim SOL_Sum_SubTotal As Double : Dim USD_Sum_SubTotal As Double
        Dim SOL_Sum_IGV As Double : Dim USD_Sum_IGV As Double
        Dim SOL_Sum_Total As Double : Dim USD_Sum_Total As Double

        Dim RegSOL As Integer : Dim RegDOL As Integer

        Try
            Grida.Rows.Clear()

            'For Mes = 1 To 12
            sqlFiltrarFacturas =
            "SELECT F.FAC_Codigo, F.FAC_Fecha, F.FAC_Observacion, F.FAC_Subtotal, " & _
            "F.FAC_valIGV, F.FAC_Total, F.FAC_Activo, F.FAC_Moneda, C.CLI_RazonSocial " & _
            "FROM tb_facturas F, tb_clientes C " & _
            "WHERE C.CLI_Codigo=F.CLI_Codigo AND " & _
            "C.CLI_Codigo='" & IDCliente & "' " & _
            "ORDER BY F.FAC_Codigo"

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlFiltrarFacturas, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                Grida.Rows.Add("", "", "FACTURAS DE " & dt.Rows(0).Item("CLI_RazonSocial"), "", "", "", "", "")
                Grida.Rows(Grida.RowCount - 1).Height = 30
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(136, 134, 137)
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.White

                SOL_Sum_SubTotal = 0 : USD_Sum_SubTotal = 0
                SOL_Sum_IGV = 0 : USD_Sum_IGV = 0
                SOL_Sum_Total = 0 : USD_Sum_Total = 0

                RegSOL = 0 : RegDOL = 0

                For i = 0 To numReg - 1
                    nroFactura = CStr(dt.Rows(i).Item("FAC_Codigo"))
                    Fecha = Format(dt.Rows(i).Item("FAC_Fecha"), "dd/MM/yyyy")
                    Observ = CStr(dt.Rows(i).Item("FAC_Observacion").ToString)
                    Subtot = dt.Rows(i).Item("FAC_Subtotal")
                    valIGV = dt.Rows(i).Item("FAC_valIGV")
                    Tot = dt.Rows(i).Item("FAC_Total")
                    Activo = dt.Rows(i).Item("FAC_Activo")
                    Moneda = dt.Rows(i).Item("FAC_Moneda")

                    If Activo Then
                        strActivo = "ACTIVA"
                    Else
                        strActivo = "ANULADA"
                    End If

                    If Moneda = "S" Then
                        Simb = "SOL"
                        RegSOL += 1
                    ElseIf Moneda = "D" Then
                        Simb = "USD"
                        RegDOL += 1
                    End If

                    If Activo And Moneda = "S" Then
                        SOL_Sum_SubTotal += Subtot
                        SOL_Sum_IGV += valIGV
                        SOL_Sum_Total += Tot
                    ElseIf Activo And Moneda = "D" Then
                        USD_Sum_SubTotal += Subtot
                        USD_Sum_IGV += valIGV
                        USD_Sum_Total += Tot
                    End If

                    strFactura = Mid(nroFactura, 1, 4) & "-" & Mid(nroFactura, 5, 6)

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(strFactura, Fecha, Observ, Simb, Format(Subtot, "#,##0.00"), Format(valIGV, "#,##0.00"), Format(Tot, "#,##0.00"), strActivo)

                    If Activo = True Then
                        Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(0, 130, 156)
                        Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                    ElseIf Activo = False Then
                        Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(217, 47, 0)
                        Grida.Rows(Grida.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
                    End If
                Next

                Grida.Rows.Add("", "", "", "Tot.",
                              "S/ " & Format(SOL_Sum_SubTotal, "#,##0.00"),
                              "S/ " & Format(SOL_Sum_IGV, "#,##0.00"),
                              "S/ " & Format(SOL_Sum_Total, "#,##0.00"),
                               RegSOL & " Reg.")

                Grida.Item(7, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Font = New Drawing.Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)


                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(198, 204, 204)
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.Blue

                Grida.Rows.Add("", "", "", "Tot.",
                               "$ " & Format(USD_Sum_SubTotal, "#,##0.00"),
                               "$ " & Format(USD_Sum_IGV, "#,##0.00"),
                               "$ " & Format(USD_Sum_Total, "#,##0.00"),
                               RegDOL & " Reg.")

                'Grida.Item(2, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Grida.Item(7, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Font = New Drawing.Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)

                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(198, 204, 204)
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.Blue
            End If
            'Next

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarDetalleFactura(ByVal Consulta As String, ByVal GRIDA As DataGridView)
        Dim numReg As Integer
        Dim dfacCodigo, IDFactura, IDProducto, descProducto As String
        Dim cant As Integer
        Dim precio, Dscto As Double

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            GRIDA.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    dfacCodigo = CStr(dt.Rows(i).Item("DFAC_Codigo"))
                    IDFactura = CStr(dt.Rows(i).Item("FAC_Codigo"))
                    IDProducto = CStr(dt.Rows(i).Item("PRD_Codigo").ToString)
                    descProducto = CStr(dt.Rows(i).Item("DFAC_Descripcion").ToString)
                    cant = CInt(dt.Rows(i).Item("DFAC_Cantidad"))
                    precio = dt.Rows(i).Item("DFAC_Precio")
                    Dscto = dt.Rows(i).Item("DFAC_Dscto")

                    GRIDA.RowTemplate.Height = 23
                    GRIDA.Rows.Add(cant, descProducto, Format(precio, "#,##0.00"), Format(cant * precio, "#,##0.00"), dfacCodigo)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Public Sub listarMovimCaja(ByVal Consulta As String, ByVal Grida As DataGridView)

        Dim codMovimiento, NroOperacion, IDCaja, Caja, Fecha, TipoMov, Consepto, Pagador,
            Recibidor, Detalle, MontoSoles, MontoDolares, strConsepto, IDConcepto As String

        Dim TotGastado_Soles, TotGastado_Dolares As Double
        Dim ADevolverSoles As String = "0,00" : Dim ADevolverDolares As String = "0,00"

        Dim Estado As Integer : Dim strEstado As String = ""
        Dim numReg As Integer

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codMovimiento = CStr(dt.Rows(i).Item("MCAJ_Codigo"))
                    IDConcepto = Trim(CStr(dt.Rows(i).Item("CON_Codigo")))
                    NroOperacion = CStr(dt.Rows(i).Item("MCAJ_NroOperacion"))
                    IDCaja = CStr(dt.Rows(i).Item("CAJ_Codigo"))
                    Caja = CStr(dt.Rows(i).Item("Caja"))
                    Fecha = Format(dt.Rows(i).Item("MCAJ_FechaHora"), "dd/MM/yyy")
                    TipoMov = CStr(dt.Rows(i).Item("MCAJ_Tipo"))
                    Consepto = CStr(dt.Rows(i).Item("Consepto"))
                    Pagador = CStr(dt.Rows(i).Item("Pagador"))
                    Recibidor = CStr(dt.Rows(i).Item("Recibidor"))
                    Detalle = CStr(dt.Rows(i).Item("Detalle"))
                    MontoSoles = Format(dt.Rows(i).Item("MCAJ_MontoSoles"), "#,##0.00")
                    MontoDolares = Format(dt.Rows(i).Item("MCAJ_MontoDolares"), "#,##0.00")
                    TotGastado_Soles = Format(dt.Rows(i).Item("DevolverSoles"), "#,##0.00")
                    TotGastado_Dolares = Format(dt.Rows(i).Item("DevolverDolares"), "#,##0.00")

                    Estado = CInt(dt.Rows(i).Item("Estado"))

                    'ADevolverDolares = Format(MontoDolares - TotGastado_Dolares, "#,##0.00")
                    'ADevolverSoles = Format(MontoSoles - TotGastado_Soles, "#,##0.00")

                    If IDConcepto = "0" Then 'OTROS CONCEPTOS
                        strConsepto = ""
                    Else
                        strConsepto = Consepto
                    End If

                    If Estado = 1 Then
                        strEstado = "GENERADO"
                        ADevolverDolares = Format(MontoDolares - TotGastado_Dolares, "#,##0.00")
                        ADevolverSoles = Format(MontoSoles - TotGastado_Soles, "#,##0.00")
                    ElseIf Estado = 2 Then
                        strEstado = "PENDIENTE"
                        ADevolverDolares = Format(MontoDolares - TotGastado_Dolares, "#,##0.00")
                        ADevolverSoles = Format(MontoSoles - TotGastado_Soles, "#,##0.00")
                    ElseIf Estado = 0 Then
                        strEstado = "TERMINADO"
                        ADevolverDolares = Format(MontoDolares - TotGastado_Dolares, "#,##0.00") '"0,00"
                        ADevolverSoles = Format(0, "#,##0.00") '"0,00"
                        'MontoSoles - TotGastado_Soles
                    End If

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codMovimiento, NroOperacion, Caja, Fecha, TipoMov, strConsepto, Detalle, Pagador, _
                                   Recibidor, MontoSoles, ADevolverSoles, TotGastado_Soles, MontoDolares, _
                                   ADevolverDolares, TotGastado_Dolares, strEstado, IDCaja)

                    If Estado = 1 Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(136, 134, 137)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    ElseIf Estado = 2 Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(220, 131, 129)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    ElseIf Estado = 0 Then
                        Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(62, 189, 146)
                        Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If
                Next

                Grida.Rows.Add()

                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.Font = New Drawing.Font("Tahoma", 7, FontStyle.Bold, GraphicsUnit.Point)
                Grida.Rows(Grida.RowCount - 1).DefaultCellStyle.ForeColor = Color.Black

                Grida.Item(8, Grida.RowCount - 1).Value = "Tot. --->> "
                Grida.Item(8, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight

                Grida.Item(0, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(1, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(2, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(3, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(4, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(5, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(6, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(7, Grida.RowCount - 1).Style.BackColor = Grida.BackgroundColor
                Grida.Item(8, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(9, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(10, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(11, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(12, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(13, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(14, Grida.RowCount - 1).Style.BackColor = Color.Yellow
                Grida.Item(15, Grida.RowCount - 1).Style.BackColor = Color.Yellow

                Grida.Item(9, Grida.RowCount - 1).Value = Format(objFunciones.Sumar_Columna(Grida, 9), "#,##0.00")
                Grida.Item(10, Grida.RowCount - 1).Value = Format(objFunciones.Sumar_Columna(Grida, 10), "#,##0.00")
                Grida.Item(11, Grida.RowCount - 1).Value = Format(objFunciones.Sumar_Columna(Grida, 11), "#,##0.00")
                Grida.Item(12, Grida.RowCount - 1).Value = Format(objFunciones.Sumar_Columna(Grida, 12), "#,##0.00")
                Grida.Item(13, Grida.RowCount - 1).Value = Format(objFunciones.Sumar_Columna(Grida, 13), "#,##0.00")
                Grida.Item(14, Grida.RowCount - 1).Value = Format(objFunciones.Sumar_Columna(Grida, 14), "#,##0.00")

                Grida.Item(15, Grida.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Grida.Item(15, Grida.RowCount - 1).Value = numReg + 1 & " Ope." 'Format(objFunciones.Sumar_Columna(Grida, 12), "#,##0.00")
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    'Public Sub colorFilaMovimientos(ByVal Grida As DataGridView, ByVal Columna As Integer)
    '    For i = 0 To Grida.Rows.Count - 1
    '        If CStr(Grida.Item(Columna, i).Value) = "GENERADO" Then
    '            Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(189, 189, 189)
    '            Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
    '        ElseIf CStr(Grida.Item(Columna, i).Value) = "PENDIENTE" Then
    '            Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(220, 131, 129)
    '            Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
    '        ElseIf CStr(Grida.Item(Columna, i).Value) = "TERMINADO" Then
    '            Grida.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(158, 204, 151)
    '            Grida.Rows(i).DefaultCellStyle.ForeColor = Color.White
    '        End If
    '    Next
    'End Sub

    Public Sub crearBotones(ByVal sqlListar As String, ByVal panelContenedor As Panel, _
                            ByVal anchoBoton As Integer, ByVal altoBoton As Integer,
                            ByVal Espacio As Integer)

        Dim X As Integer = Espacio
        Dim Y As Integer = Espacio
        Dim rutaIcono As String = Application.StartupPath & "\Iconos\cash_register_642.png"

        Dim numReg As Integer
        Dim IDCaja As String
        Dim Aperturado, esPrincipal As Boolean

        Dim sqlCajasAperturadas As String
        Dim SQLResumen As String

        Dim totCaja_SOL, totCaja_USD As String
        Dim totGasto_SOL, totGasto_USD As Double
        Dim totDesemb_SOL, totDesemb_USD As String
        Dim totRetorna_SOL, totRetorna_USD As Double
        Dim queda_SOL, queda_USD As Double
        Dim ultimoIng_SOL, ultimoIng_USD As Double
        Dim fechaApertura As String


        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlListar, cnn)
            sqlda.Fill(dt)

            numReg = CInt(dt.Rows.Count - 1)
            numCajasCreadas = numReg

            panelContenedor.Controls.Clear()

            'CREAMOS LOS BOTONES
            '=========================
            ReDim Preserve btns(numReg)
            ReDim Preserve btnsAbrir(numReg)
            ReDim Preserve btnsCerrar(numReg)
            ReDim Preserve btnsIngreso(numReg)
            ReDim Preserve btnsMovimiento(numReg)

            ReDim Preserve btnsListEgresos(numReg)
            ReDim Preserve btnsListIngresos(numReg)

            ReDim Preserve NOMBRES_CAJA(numReg)

            If numReg >= 0 Then
                For i = 0 To numReg
                    btns(i) = New Label
                    btnsAbrir(i) = New Button
                    btnsCerrar(i) = New Button
                    btnsIngreso(i) = New Button
                    btnsMovimiento(i) = New Button

                    btnsListEgresos(i) = New Button
                    btnsListIngresos(i) = New Button

                    Aperturado = CBool(dt.Rows(i).Item("CAJ_Aperturado"))
                    IDCaja = CStr(dt.Rows(i).Item("CAJ_Codigo"))
                    esPrincipal = CBool(dt.Rows(i).Item("CAJ_Principal"))

                    With btns(i)
                        .Tag = i

                        .Name = IDCaja '"btn_" & i
                        .Size = New Size(anchoBoton, altoBoton)
                        .FlatStyle = FlatStyle.Standard
                        .Font = New Font(New FontFamily("Calibri"), 8, FontStyle.Bold)
                        .Text = CStr(dt.Rows(i).Item("CAJ_Nombre"))
                        NOMBRES_CAJA(i) = CStr(dt.Rows(i).Item("CAJ_Nombre"))
                        .TextAlign = ContentAlignment.BottomCenter
                        .Cursor = Cursors.Hand
                        .Image = Image.FromFile(rutaIcono)
                        .ImageAlign = ContentAlignment.TopCenter

                        'CARGAR DETALLE DE CAJA
                        '--------------------------
                        sqlCajasAperturadas =
                        "SELECT C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres, " & _
                        "ISNULL((SELECT SUM(MCAJ_MontoSoles) FROM tb_movimiento_cajas WHERE CAJ_Codigo='" & IDCaja & _
                        "' AND MCAJ_Tipo='I' AND MCAJ_Activo='0'), 0.00) AS TOTAL_ING_SOL, " & _
                        "ISNULL((SELECT SUM(MCAJ_MontoDolares) FROM tb_movimiento_cajas WHERE CAJ_Codigo='" & IDCaja & _
                        "' AND MCAJ_Tipo='I' AND MCAJ_Activo='0'), 0.00) AS TOTAL_ING_USD, " & _
                        "(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CON_Codigo='A007' AND CAJ_Codigo='" & IDCaja & "') AS FECHAAPERTURA, " & _
                        "ISNULL((SELECT TOP 1 MCAJ_MontoSoles FROM tb_movimiento_cajas " & _
                        "WHERE CAJ_Codigo='" & IDCaja & "' AND MCAJ_Tipo='I' ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_SOL, " & _
                        "ISNULL((SELECT TOP 1 MCAJ_MontoDolares FROM tb_movimiento_cajas " & _
                        "WHERE CAJ_Codigo='" & IDCaja & "' AND MCAJ_Tipo='I' ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_USD " & _
                        "FROM tb_cajas C, tb_movimiento_cajas MC, tb_usuarios U " & _
                        "WHERE C.CAJ_Codigo = MC.CAJ_Codigo AND " & _
                        "C.USU_Codigo = U.USU_Codigo AND " & _
                        "MCAJ_Tipo='I' AND C.CAJ_Codigo='" & IDCaja & "' " & _
                        "GROUP BY C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres"

                        Dim dt_Detalle = New Data.DataTable
                        Dim sqlda_Detalle = New SqlDataAdapter(sqlCajasAperturadas, cnn)
                        sqlda_Detalle.Fill(dt_Detalle)
                        Dim numRegAct = dt_Detalle.Rows.Count

                        SQLResumen =
                        "SELECT MC.MCAJ_MontoSoles AS DESEMBOLSOS_SOL, " & _
                        "ISNULL((SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_SOL, " & _
                        "ISNULL((MC.MCAJ_MontoSoles - (SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE " & _
                        "MC.MCAJ_Codigo=DG.MCAJ_Codigo AND MC.MCAJ_Activo='0')), 0.00) AS RETORNO_SOL, " & _
                        " MC.MCAJ_MontoDolares AS DESEMBOLSOS_USD, " & _
                        "ISNULL((SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_USD, " & _
                        "ISNULL((MC.MCAJ_MontoDolares - (SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG WHERE " & _
                        "MC.MCAJ_Codigo=DG.MCAJ_Codigo AND MC.MCAJ_Activo='0')), 0.00) AS RETORNO_USD " & _
                        "FROM tb_movimiento_cajas MC " & _
                        "WHERE MC.CAJ_Codigo='" & IDCaja & "' AND MC.CON_Codigo<>'A007' AND MCAJ_Tipo='E'"

                        Dim numRegResumen As Integer
                        Dim dt_Resumen = New Data.DataTable
                        Dim sqlda_Resumen = New SqlDataAdapter(SQLResumen, cnn)
                        sqlda_Resumen.Fill(dt_Resumen)
                        numRegResumen = dt_Resumen.Rows.Count

                        totDesemb_SOL = 0 : totDesemb_USD = 0
                        totGasto_SOL = 0 : totGasto_USD = 0
                        totRetorna_SOL = 0 : totRetorna_USD = 0
                        For S = 0 To numRegResumen - 1
                            totDesemb_SOL += CDbl(dt_Resumen.Rows(S).Item("DESEMBOLSOS_SOL"))
                            totGasto_SOL += CDbl(dt_Resumen.Rows(S).Item("GASTOS_SOL"))
                            totGasto_USD += CDbl(dt_Resumen.Rows(S).Item("GASTOS_USD"))

                            totDesemb_USD += CDbl(dt_Resumen.Rows(S).Item("DESEMBOLSOS_USD"))
                            totRetorna_SOL += CDbl(dt_Resumen.Rows(S).Item("RETORNO_SOL"))
                            totRetorna_USD += CDbl(dt_Resumen.Rows(S).Item("RETORNO_USD"))
                        Next

                        'VERIFICAR EL ESTADO DE LA APERTURA
                        '----------------------------------
                        If numRegAct > 0 Then
                            totCaja_SOL = dt_Detalle.Rows(0).Item("TOTAL_ING_SOL")
                            queda_SOL = ((totCaja_SOL - totDesemb_SOL) + totRetorna_SOL) 'Format(totCaja_SOL - totGasto_SOL, "#,##0.00")
                            totCaja_USD = dt_Detalle.Rows(0).Item("TOTAL_ING_USD")
                            queda_USD = ((totCaja_USD - totDesemb_USD) + totRetorna_USD) 'Format(totCaja_USD - totGasto_USD, "#,##0.00")

                            fechaApertura = Format(dt_Detalle.Rows(0).Item("FECHAAPERTURA"), "dd/MM/yyyy H:mm:ss")
                            ultimoIng_SOL = dt_Detalle.Rows(0).Item("ULT_ING_SOL")
                            ultimoIng_USD = dt_Detalle.Rows(0).Item("ULT_ING_USD")

                            'If ultimoIng_SOL > 0 Or ultimoIng_USD > 0 Then
                            .Text = .Text & vbNewLine & _
                                    "ULT. ING. SOL: " & Format(ultimoIng_SOL, "#,##0.00") & "   USD: " & Format(ultimoIng_USD, "#,##0.00") & vbNewLine & _
                                    "SALDO SOL: " & Format(queda_SOL, "#,##0.00") & "   USD: " & Format(queda_USD, "#,##0.00") & vbNewLine & _
                                    "(" & fechaApertura & ")" & vbNewLine
                            'Else
                            '.Text = .Text & vbNewLine & _
                            '        "ULT. ING. DOL: " & Monto_so & "   USD: " & Monto_dol & vbNewLine & _
                            '        "SALDO SOL: " & queda_SOL & "   USD: " & Queda_dol & vbNewLine & _
                            '        "(" & FechAp & ")" & vbNewLine
                            'End If

                            If esPrincipal Then
                                .BackColor = Color.FromArgb(93, 191, 255)
                                .ForeColor = Color.White
                            Else
                                .BackColor = Color.FromArgb(22, 160, 92)
                                .ForeColor = Color.Azure
                            End If
                        Else
                            .Text = .Text & vbNewLine & _
                                    "(SIN APERTURAR)" & vbNewLine
                            .BackColor = Color.FromArgb(254, 92, 92)
                            .ForeColor = Color.Yellow
                        End If

                        .Location = New Point(X, Y)
                        X += (anchoBoton + Espacio)

                        If (.Location.X + anchoBoton) >= Val(panelContenedor.Width) Then
                            Y += (btnsAbrir(i - 1).Top + (btnsAbrir(i).Height * 2) + Espacio)
                            X = Espacio

                            .Location = New Point(X, Y)

                            X += (anchoBoton + Espacio)
                        End If

                        panelContenedor.Controls.Add(btns(i))
                        AddHandler .Click, AddressOf btnCaja_Click
                        AddHandler .DoubleClick, AddressOf btnCaja_DblClick
                    End With

                    With btnsAbrir(i)
                        .Name = "cmdAbrirCaja_" & i
                        .Tag = i
                        .Visible = False
                        .Font = New Font(New FontFamily("Tahoma"), 7, FontStyle.Regular)
                        .Text = "Aper."
                        .Cursor = Cursors.Hand
                        .FlatStyle = FlatStyle.Flat
                        .BackColor = Color.FromArgb(147, 215, 168)
                        .ForeColor = Color.White
                        .Width = 40
                        .Height = 25

                        If Aperturado Then
                            .Enabled = False
                            .BackColor = SystemColors.Control 'System.Drawing.SystemColors.Window ' Color.Gray
                        Else
                            .Enabled = True
                            .BackColor = Color.FromArgb(147, 215, 168)
                        End If

                        Dim X_PRE As Integer = btns(i).Left
                        Dim Y_PRE As Integer = (btns(i).Top + btns(i).Height)

                        .Location = New Point(X_PRE, Y_PRE)
                        '.Location = New Point(50, 50)

                        panelContenedor.Controls.Add(btnsAbrir(i))
                        AddHandler .Click, AddressOf btnAperturar_Click
                    End With

                    If Not (esPrincipal) Then
                        With btnsCerrar(i)
                            .Name = "cmdCerrarCaja_" & i
                            .Tag = i
                            .Visible = False
                            .Font = New Font(New FontFamily("Tahoma"), 7, FontStyle.Regular)
                            .Text = "Cerrar"
                            .Cursor = Cursors.Hand
                            .FlatStyle = FlatStyle.Flat
                            '.Enabled = False
                            .BackColor = Color.FromArgb(194, 86, 83)
                            .ForeColor = Color.White
                            .Width = 60
                            .Height = 25

                            If Aperturado Then
                                .BackColor = Color.FromArgb(254, 92, 92)
                                .Enabled = True
                            Else
                                .BackColor = SystemColors.Control
                                .Enabled = False
                            End If

                            'Dim X_PRE As Integer = btnsAbrir(i).Left + btnsAbrir(i).Width
                            'Dim Y_PRE As Integer = (btns(i).Top + btns(i).Height)

                            '.Location = New Point(X_PRE, Y_PRE)
                            .Location = New Point(50, 50)

                            panelContenedor.Controls.Add(btnsCerrar(i))
                            AddHandler .Click, AddressOf btnCerrar_Click
                        End With
                    End If

                    With btnsIngreso(i)
                        .Name = "cmdIngresoCaja_" & i
                        .Tag = i
                        .Visible = False
                        .Font = New Font(New FontFamily("Tahoma"), 7, FontStyle.Regular)
                        .Text = "Ingresar"
                        .Cursor = Cursors.Hand
                        .FlatStyle = FlatStyle.Flat
                        .BackColor = Color.FromArgb(72, 170, 197)
                        .ForeColor = Color.White
                        .Width = 60
                        .Height = 25

                        'Dim X_PRE As Integer = ((btns(i).Width + btns(i).Left) - btnsIngreso(i).Width) '+ Espacio
                        'Dim Y_PRE As Integer = (btns(i).Top + btns(i).Height)

                        '.Location = New Point(X_PRE, Y_PRE)
                        .Location = New Point(50, 50)

                        panelContenedor.Controls.Add(btnsIngreso(i))
                        AddHandler .Click, AddressOf btnIngreso_Click
                    End With

                    With btnsMovimiento(i)
                        .Name = "cmdMovimCaja_" & i
                        .Tag = i
                        .Visible = False
                        .Font = New Font(New FontFamily("Tahoma"), 7, FontStyle.Regular)
                        .Text = "Pagar"
                        .Cursor = Cursors.Hand
                        .FlatStyle = FlatStyle.Flat
                        .BackColor = Color.FromArgb(115, 39, 148)
                        .ForeColor = Color.White
                        .Width = 45
                        .Height = 25

                        'Dim X_PRE As Integer = (btnsIngreso(i).Left - btnsMovimiento(i).Width) '((btns(i).Width + btns(i).Left) - btnsMovimiento(i).Width) '+ Espacio
                        'Dim Y_PRE As Integer = (btns(i).Top + btns(i).Height)

                        '.Location = New Point(X_PRE, Y_PRE)
                        .Location = New Point(50, 50)

                        panelContenedor.Controls.Add(btnsMovimiento(i))
                        AddHandler .Click, AddressOf btnMovimiento_Click
                    End With

                    With btnsListIngresos(i)
                        .Name = "cmdListaIngreso_" & i
                        .Tag = i
                        .Visible = False
                        .Font = New Font(New FontFamily("Tahoma"), 7, FontStyle.Regular)
                        .Text = "Lista de Ingresos"
                        .Cursor = Cursors.Hand
                        .FlatStyle = FlatStyle.Flat
                        .BackColor = Color.FromArgb(66, 209, 245)
                        .ForeColor = Color.White
                        .Width = btns(i).Width / 2 '45
                        .Height = 25

                        'Dim X_PRE As Integer = (btnsIngreso(i).Left - btnsMovimiento(i).Width) '((btns(i).Width + btns(i).Left) - btnsMovimiento(i).Width) '+ Espacio
                        'Dim Y_PRE As Integer = (btns(i).Top + btns(i).Height)

                        '.Location = New Point(X_PRE, Y_PRE)
                        .Location = New Point(50, 50)

                        panelContenedor.Controls.Add(btnsListIngresos(i))
                        AddHandler .Click, AddressOf btnListaIngresos_Click
                    End With

                    With btnsListEgresos(i)
                        .Name = "cmdListaEgreso_" & i
                        .Tag = i
                        .Visible = False
                        .Font = New Font(New FontFamily("Tahoma"), 7, FontStyle.Regular)
                        .Text = "Lista de Egresos"
                        .Cursor = Cursors.Hand
                        .FlatStyle = FlatStyle.Flat
                        .BackColor = Color.FromArgb(66, 209, 245)
                        .ForeColor = Color.White
                        .Width = (btns(i).Width / 2) '45
                        .Height = 25

                        'Dim X_PRE As Integer = (btnsIngreso(i).Left - btnsMovimiento(i).Width) '((btns(i).Width + btns(i).Left) - btnsMovimiento(i).Width) '+ Espacio
                        'Dim Y_PRE As Integer = (btns(i).Top + btns(i).Height)

                        '.Location = New Point(X_PRE, Y_PRE)
                        .Location = New Point(50, 50)

                        panelContenedor.Controls.Add(btnsListEgresos(i))
                        AddHandler .Click, AddressOf btnListaEgresos_Click
                    End With
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Private Sub btnListaIngresos_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim btn As Button = sender
        Dim IDCaja As String

        Try
            index = CInt(btn.Tag)
            IDCaja = CStr(btns(index).Name)

            With FrmListaIngresos
                .lblCodCaja.Text = IDCaja
                .lblNombreCaja.Text = NOMBRES_CAJA(index) 'btns(index).Text
                '.lblCaja.Text = "SALDO EN " & CStr(btns(index).Text)

                .lblQueda_Sol.Text = Format(MONTO_ACT_CAJASEL_SOL, "#,##0.00")
                .lblQueda_Dol.Text = Format(MONTO_ACT_CAJASEL_USD, "#,##0.00")

                .ShowDialog()
            End With
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub btnListaEgresos_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim btn As Button = sender
        Dim IDCaja As String
        Dim sqlMovimientos As String
        Dim Mes As Integer

        Try
            index = CInt(btn.Tag)
            IDCaja = CStr(btns(index).Name)
            Mes = Format(Now, "MM")

            sqlMovimientos =
                "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
                "(SELECT CAJ_Nombre FROM tb_cajas WHERE CAJ_Codigo = MC.CAJ_Codigo) AS Caja, " & _
                "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo = MC.CON_Codigo) AS Consepto, " & _
                "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Pagador) AS Pagador, " & _
                "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Recibidor) AS Recibidor, " & _
                "(SELECT COALESCE(SUM(DGAS_MontoSoles), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverSoles, " & _
                "(SELECT COALESCE(SUM(DGAS_MontoDolares), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverDolares, " & _
                "MCAJ_MontoSoles, MCAJ_MontoDolares, MCAJ_Detalle AS Detalle, MCAJ_Activo AS Estado " & _
                "FROM tb_movimiento_cajas MC, tb_conceptos C, tb_cajas CA " & _
                "WHERE MC.CON_Codigo = C.CON_Codigo AND " & _
                "MC.CAJ_Codigo = CA.CAJ_Codigo AND " & _
                "MC.MCAJ_Tipo='E' AND " & _
                "MC.CAJ_Codigo='" & IDCaja & "' AND " & _
                "DATEPART(MONTH, MC.MCAJ_FechaHora)='" & Mes & "'"

            With FrmListaEgresos
                .lblCodCaja.Text = IDCaja
                '.lblCaja.Text = "SALDO EN " & CStr(btns(index).Text)

                .lblQueda_Sol.Text = Format(MONTO_ACT_CAJASEL_SOL, "#,##0.00")
                .lblQueda_Dol.Text = Format(MONTO_ACT_CAJASEL_USD, "#,##0.00")

                modProcedimientos.listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
                .ShowDialog()
            End With
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub btnCaja_Click(sender As Object, e As EventArgs)
        Dim SQLDetalleCaja_Apert, SQLDetalleCaja, SQLResumen As String

        Dim index, numRegApertura, numRegDetalle, numRegResumen As Integer
        'Dim esPrincipal, estaAperturada As Boolean

        Dim btn As Label = sender
        Dim IDCaja As String

        Dim totDesemb_SOL, totDesemb_USD As Double
        Dim totGasto_SOL, totGasto_USD As Double
        Dim totRetorna_SOL, totRetorna_USD As Double

        Try
            index = CInt(btn.Tag)
            IDCaja = CStr(btns(index).Name)

            'POSICIONAR BOTONES
            '------------------------
            btnsIngreso(index).Top = btns(index).Top + btns(index).Height
            btnsIngreso(index).Left = (btns(index).Left + btns(index).Width) - btnsIngreso(index).Width

            btnsMovimiento(index).Top = btns(index).Top + btns(index).Height
            btnsMovimiento(index).Left = (btnsIngreso(index).Left - btnsMovimiento(index).Width)

            btnsCerrar(index).Top = btns(index).Top + btns(index).Height
            btnsCerrar(index).Left = (btnsMovimiento(index).Left - btnsCerrar(index).Width)

            btnsAbrir(index).Top = btns(index).Top + btns(index).Height
            btnsAbrir(index).Left = btns(index).Left

            btnsListIngresos(index).Top = btnsIngreso(index).Top + btnsIngreso(index).Height
            btnsListIngresos(index).Left = btns(index).Left

            btnsListEgresos(index).Top = btnsIngreso(index).Top + btnsIngreso(index).Height
            btnsListEgresos(index).Left = btnsListIngresos(index).Left + btnsListIngresos(index).Width

            'OCULTAR / MOSTRAR BOTONES AL SELECCIONAR CAJA
            '-----------------------------------------------
            For c = 0 To numCajasCreadas
                If c <> index Then
                    btnsAbrir(c).Visible = False
                    btnsCerrar(c).Visible = False
                    btnsIngreso(c).Visible = False
                    btnsMovimiento(c).Visible = False

                    btnsListIngresos(c).Visible = False
                    btnsListEgresos(c).Visible = False
                End If
            Next

            'CARGAR DETALLE DE CAJA
            '--------------------------
            SQLDetalleCaja_Apert =
            "SELECT U.USU_Codigo, U.USU_Nombres, C.CAJ_Codigo, C.CAJ_Nombre, C.CAJ_Principal, C.CAJ_Aperturado, " & _
            "(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CAJ_Codigo=C.CAJ_Codigo AND " & _
            "CON_Codigo='A007') AS FECHA_APERT, " & _
            "(SELECT MCAJ_MontoSoles FROM tb_movimiento_cajas WHERE CAJ_Codigo=C.CAJ_Codigo AND " & _
            "CON_Codigo='A007') AS APERTURO_SOL, " & _
            "(SELECT MCAJ_MontoDolares FROM tb_movimiento_cajas WHERE CAJ_Codigo=C.CAJ_Codigo AND " & _
            "CON_Codigo='A007') AS APERTURO_USD " & _
            "FROM tb_cajas C, tb_usuarios U " & _
            "WHERE U.USU_Codigo=C.USU_Codigo AND " & _
            "C.CAJ_Codigo='" & IDCaja & "'"

            Dim dt_DetalleAper = New Data.DataTable
            Dim sqlda_DetalleAper = New SqlDataAdapter(SQLDetalleCaja_Apert, cnn)
            sqlda_DetalleAper.Fill(dt_DetalleAper)
            numRegApertura = dt_DetalleAper.Rows.Count

            SQLDetalleCaja =
            "SELECT C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres, " & _
            "ISNULL((SELECT SUM(MCAJ_MontoSoles) FROM tb_movimiento_cajas WHERE CAJ_Codigo='" & IDCaja & _
            "' AND MCAJ_Tipo='I' AND MCAJ_Activo='0'), 0.00) AS TOTAL_ING_SOL, " & _
            "ISNULL((SELECT SUM(MCAJ_MontoDolares) FROM tb_movimiento_cajas WHERE CAJ_Codigo='" & IDCaja & _
            "' AND MCAJ_Tipo='I' AND MCAJ_Activo='0'), 0.00) AS TOTAL_ING_USD, " & _
            "(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CON_Codigo='A007' AND CAJ_Codigo='" & IDCaja & "') AS FECHAAPERTURA, " & _
            "ISNULL((SELECT TOP 1 ISNULL(MCAJ_MontoSoles, 0.00) FROM tb_movimiento_cajas " & _
            "WHERE CAJ_Codigo='" & IDCaja & "' AND MCAJ_Tipo='I' ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_SOL, " & _
            "ISNULL((SELECT TOP 1 ISNULL(MCAJ_MontoDolares, 0.00) FROM tb_movimiento_cajas " & _
            "WHERE CAJ_Codigo='" & IDCaja & "' AND MCAJ_Tipo='I' ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_USD " & _
            "FROM tb_cajas C, tb_movimiento_cajas MC, tb_usuarios U " & _
            "WHERE C.CAJ_Codigo = MC.CAJ_Codigo AND " & _
            "C.USU_Codigo = U.USU_Codigo AND " & _
            "MCAJ_Tipo='I' AND C.CAJ_Codigo='" & IDCaja & "' " & _
            "GROUP BY C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres"

            Dim dt_Detalle = New Data.DataTable
            Dim sqlda_Detalle = New SqlDataAdapter(SQLDetalleCaja, cnn)
            sqlda_Detalle.Fill(dt_Detalle)
            numRegDetalle = dt_Detalle.Rows.Count

            SQLResumen =
            "SELECT MC.MCAJ_MontoSoles AS DESEMBOLSOS_SOL, " & _
            "ISNULL((SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_SOL, " & _
            "ISNULL((MC.MCAJ_MontoSoles - (SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE " & _
            "MC.MCAJ_Codigo=DG.MCAJ_Codigo AND MC.MCAJ_Activo='0')), 0.00) AS RETORNO_SOL, " & _
            " MC.MCAJ_MontoDolares AS DESEMBOLSOS_USD, " & _
            "ISNULL((SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_USD, " & _
            "ISNULL((MC.MCAJ_MontoDolares - (SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG WHERE " & _
            "MC.MCAJ_Codigo=DG.MCAJ_Codigo AND MC.MCAJ_Activo='0')), 0.00) AS RETORNO_USD " & _
            "FROM tb_movimiento_cajas MC " & _
            "WHERE MC.CAJ_Codigo='" & IDCaja & "' AND MC.CON_Codigo<>'A007' AND MCAJ_Tipo='E'"

            Dim dt_Resumen = New Data.DataTable
            Dim sqlda_Resumen = New SqlDataAdapter(SQLResumen, cnn)
            sqlda_Resumen.Fill(dt_Resumen)
            numRegResumen = dt_Resumen.Rows.Count


            totDesemb_SOL = 0 : totDesemb_USD = 0
            totGasto_SOL = 0 : totGasto_USD = 0
            totRetorna_SOL = 0 : totRetorna_USD = 0
            For S = 0 To numRegResumen - 1
                totDesemb_SOL += CDbl(dt_Resumen.Rows(S).Item("DESEMBOLSOS_SOL"))
                totGasto_SOL += CDbl(dt_Resumen.Rows(S).Item("GASTOS_SOL"))
                totRetorna_SOL += CDbl(dt_Resumen.Rows(S).Item("RETORNO_SOL"))

                totDesemb_USD += CDbl(dt_Resumen.Rows(S).Item("DESEMBOLSOS_USD"))
                totGasto_USD += CDbl(dt_Resumen.Rows(S).Item("GASTOS_USD"))
                totRetorna_USD += CDbl(dt_Resumen.Rows(S).Item("RETORNO_USD"))
            Next

            COD_CAJERO = CStr(dt_DetalleAper.Rows(0).Item("USU_Codigo"))
            NOMB_CAJERO = CStr(dt_DetalleAper.Rows(0).Item("USU_Nombres"))
            ES_CAJA_PRINCIPAL = CBool(dt_DetalleAper.Rows(0).Item("CAJ_Principal"))
            ES_CAJA_APERTURADA = CBool(dt_DetalleAper.Rows(0).Item("CAJ_Aperturado"))

            If ES_CAJA_APERTURADA Then
                TOTAL_CAJA_SOL = dt_Detalle.Rows(0).Item("TOTAL_ING_SOL")
                MONTO_ACT_CAJASEL_SOL = ((TOTAL_CAJA_SOL - totDesemb_SOL) + totRetorna_SOL)
                TOTAL_CAJA_USD = dt_Detalle.Rows(0).Item("TOTAL_ING_USD")
                MONTO_ACT_CAJASEL_USD = ((TOTAL_CAJA_USD - totDesemb_USD) + totRetorna_USD)

                MONTO_APERT_SOL = dt_DetalleAper.Rows(0).Item("APERTURO_SOL")
                MONTO_APERT_USD = dt_DetalleAper.Rows(0).Item("APERTURO_USD")

                FECHA_APERTURA = Format(dt_DetalleAper.Rows(0).Item("FECHA_APERT"), "dd/MM/yyyy")
            End If

            With FrmAperturarCaja
                'If numRegDetalle > 0 Then 'SI ES CAJA APERTURADA
                If ES_CAJA_APERTURADA Then
                    .txtMontoinic_S.Enabled = False
                    .txtMontoinic_D.Enabled = False

                    .lblEstado.ForeColor = Color.Green 'Color.White
                    .lblEstado.Text = NOMBRES_CAJA(index) 'CStr(dt_DetalleAper.Rows(0).Item("CAJ_Nombre"))
                    .lblFechaApertura.Text = FECHA_APERTURA 'Format(dt_DetalleAper.Rows(0).Item("FECHA_APERT"), "dd/MM/yyyy")

                    .lblCodCajero.Text = COD_CAJERO 'CStr(dt_DetalleAper.Rows(0).Item("USU_Codigo"))
                    .lblNombCajero.Text = NOMB_CAJERO 'CStr(dt_DetalleAper.Rows(0).Item("USU_Nombres"))
                    .txtMontoinic_S.Text = Format(MONTO_APERT_SOL, "#,##0.00") 'Format(dt_DetalleAper.Rows(0).Item("APERTURO_SOL"), "#,##0.00")
                    .txtMontoinic_D.Text = Format(MONTO_APERT_USD, "#,##0.00") 'Format(dt_DetalleAper.Rows(0).Item("APERTURO_USD"), "#,##0.00")

                    '' SI ES EL USUARIO ASIGNADO Y ADEMAS TIENE PERMISOS DE ADMIN.
                    With MDIPrincipal
                        If .mnuAdministraTodasCajas.Enabled = True Then
                            btnsAbrir(index).Visible = True
                            btnsCerrar(index).Visible = True

                            btnsIngreso(index).Visible = True
                            btnsMovimiento(index).Visible = True
                            btnsListIngresos(index).Visible = True
                            btnsListEgresos(index).Visible = True
                        Else
                            If COD_CAJERO = USU_CODIGO Then
                                btnsAbrir(index).Visible = False

                                btnsCerrar(index).Top = btns(index).Top + btns(index).Height
                                btnsCerrar(index).Left = btns(index).Left
                                btnsCerrar(index).Visible = True

                                btnsIngreso(index).Visible = True
                                btnsMovimiento(index).Visible = True
                                btnsListIngresos(index).Visible = True
                                btnsListEgresos(index).Visible = True
                            Else
                                btnsAbrir(index).Visible = False
                                btnsCerrar(index).Visible = False

                                btnsIngreso(index).Visible = False
                                btnsMovimiento(index).Visible = False
                                btnsListIngresos(index).Visible = False
                                btnsListEgresos(index).Visible = False

                                MsgBox("No cuenta con permisos para accesar a esta caja" & vbNewLine & vbNewLine & _
                                       "La caja a la cual intenta accesar no ha sido asignada a su usuario", vbCritical, "Error de acceso")
                            End If
                        End If
                    End With
                Else ' LA CAJA SELECCIONADA ESTA CERRADA
                    btnsAbrir(index).Visible = True
                    btnsAbrir(index).Left = btns(index).Left
                    btnsCerrar(index).Visible = False

                    .lblEstado.ForeColor = Color.FromArgb(254, 92, 92)
                    .lblEstado.Text = NOMBRES_CAJA(index) & " CERRADA"

                    .lblCodCajero.Text = USU_CODIGO
                    .lblNombCajero.Text = USU_NOMBRE

                    .txtMontoinic_S.Enabled = True
                    .txtMontoinic_S.Text = "0.00"
                    .txtMontoinic_S.Focus()

                    .txtMontoinic_D.Enabled = True
                    .txtMontoinic_D.Text = "0.00"

                    .txtNroSerie.Text = ""
                    .txtDocumInic.Text = ""
                    .txtDocumFin.Text = ""
                End If
            End With

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    Private Sub btnAperturar_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim IDCaja As String

        Dim btn As Button = sender

        Dim FechaApertura, IDCajero As String
        Dim Serie, FacINI, FacFIN As String
        Dim Moneda As String = ""
        Dim Importe_SOL, Importe_DOL As Double

        Dim sqlCajas As String = "SELECT * FROM tb_cajas WHERE CAJ_Aperturado <> 2"
        Dim sqlMovimiento As String : Dim sqlOperacion As String
        Dim OPERACION_NRO As String
        Dim Fecha As String = Format(Now, "dd/MM/yyyy H:mm:ss")
        Dim Mes As String = Format(Now, "MM")
        Dim Concep, Tipo, Detalle As String
        Dim Proviene As String = "APERTURA DE " & NOMBRES_CAJA(index).ToString

        index = CInt(btn.Tag)
        IDCaja = CStr(btns(index).Name)
        IDCajero = CStr(FrmAperturarCaja.lblCodCajero.Text)
        FechaApertura = CStr(Format(Now, "dd/MM/yyyy hh:mm:ss"))
        Importe_SOL = CDbl(FrmAperturarCaja.txtMontoinic_S.Text)
        Importe_DOL = CType(FrmAperturarCaja.txtMontoinic_D.Text, Decimal)

        Serie = CStr(FrmAperturarCaja.txtNroSerie.Text)
        FacINI = CStr(FrmAperturarCaja.txtDocumInic.Text)
        FacFIN = CStr(FrmAperturarCaja.txtDocumFin.Text)

        Concep = "A007" : Tipo = "I"
        Detalle = "SE APERTURÓ " & NOMBRES_CAJA(index).ToString & " CON S/ " & Importe_SOL & " $ " & Importe_DOL

        sqlOperacion = "SELECT COUNT(MCAJ_Codigo) FROM tb_movimiento_cajas " & _
                       "WHERE CAJ_Codigo='" & IDCaja & "' AND " & _
                       "DATEPART(MONTH, MCAJ_FechaHora)='" & Mes & "' AND " & _
                       "MCAJ_Tipo='E'"

        OPERACION_NRO = objFunciones.Generar_Codigo(sqlOperacion, "0000")

        sqlMovimiento = "INSERT INTO tb_movimiento_cajas(MCAJ_NroOperacion, CAJ_Codigo, " & _
                        "CON_Codigo, MCAJ_Pagador, MCAJ_Recibidor, MCAJ_Tipo, MCAJ_FechaHora, " & _
                        "MCAJ_MontoSoles, MCAJ_MontoDolares, MCAJ_Proveniente, " & _
                        "MCAJ_Detalle, MCAJ_Activo) " & _
                        "VALUES('" & OPERACION_NRO & "','" & IDCaja & "','" & _
                        Concep & "','" & IDCajero & "','" & IDCajero & "','" & _
                        Tipo & "','" & Fecha & "','" & _
                        objFunciones.convertMoneda(Importe_SOL) & "','" & _
                        objFunciones.convertMoneda(Importe_DOL) & "','" & _
                        Proviene & "','" & Detalle & "','" & 0 & "')"

        Try
            If Importe_SOL <= 0 And Importe_DOL <= 0 Then
                MsgBox("No se pudo aperturar la caja." & vbNewLine & _
                       "Ingrese un valor mayor a ( cero ) para realizar la apertura.", vbCritical, "¡Aviso!")
                FrmAperturarCaja.txtMontoinic_S.Focus()
                Exit Sub
            Else
                'If (objFunciones.Ejecutar(sqlAperturar)) Then
                If objFunciones.Ejecutar(sqlMovimiento) Then
                    With FrmAperturarCaja
                        .cmdNuevo.Enabled = True
                        crearBotones(sqlCajas, .panelCajas, 200, 132, 5)
                    End With
                End If
                'End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim btn As Button = sender

        Dim sqlContPendientes As String
        Dim numPendientes As Integer

        Dim IDCajaPrinc, NombCajaPrinc, NroOperacion As String
        Dim ImporteSoles_Princ, ImporteDolares_Princ As Double
        Dim IDCajaCerrar, NombCajaCerrar, IDConcepto, Detalle, Proveniente, TipoMov As String
        Dim ImporteSoles_Cerrar, ImporteDolares_Cerrar As Double
        Dim IDCajero, IDCajeroPrinc, FechaCierre As String
        Dim Serie, FacINI, FacFIN As String

        Dim sqlCajas As String = "SELECT * FROM tb_cajas WHERE CAJ_Aperturado <> 2" '--> CAJA NO SIN TERMINAR
        Dim sqlCajaPrinc, sqlOperacion As String

        Dim sqlInsertarMovimiento, sqlActualizarCaja As String

        Try
            index = CInt(btn.Tag)
            IDCajaCerrar = CStr(btns(index).Name)
            NombCajaCerrar = NOMBRES_CAJA(index)
            IDConcepto = "T001" '<-- CONCEPTO DE CIERRE DE CAJA
            Proveniente = "CIERRE DE CAJA"

            'OBTENEMOS NUMERO DE PENDIENTES
            '------------------------------
            sqlContPendientes = "SELECT * FROM tb_movimiento_cajas " & _
                                "WHERE CAJ_Codigo='" & IDCajaCerrar & "' AND " & _
                                "MCAJ_Activo<>'" & 0 & "'"

            numPendientes = objFunciones.getnumeroRegs(sqlContPendientes)  'dt.Rows.Count 'CStr(dt.Rows(0).Item("USU_Codigo"))

            'OBTENEMOS LOS DATOS DE LA "CAJA PRINCIPAL"
            '-------------------------------------------
            sqlCajaPrinc = "SELECT C.CAJ_Codigo, C.CAJ_Nombre, C.USU_Codigo, " & _
                           "Mc.MCAJ_MontoSoles, MC.MCAJ_MontoDolares " & _
                           "FROM tb_cajas C, tb_movimiento_cajas Mc " & _
                           "WHERE C.CAJ_Codigo=Mc.CAJ_Codigo AND " & _
                           "CON_Codigo='A007' AND CAJ_Principal='1'" '--> CAJA PRINCIPAL

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlCajaPrinc, cnn)
            sqlda.Fill(dt)

            IDCajeroPrinc = CStr(dt.Rows(0).Item("USU_Codigo"))
            IDCajaPrinc = CStr(dt.Rows(0).Item("CAJ_Codigo"))
            NombCajaPrinc = CStr(dt.Rows(0).Item("CAJ_Nombre"))
            ImporteSoles_Princ = Format(dt.Rows(0).Item("MCAJ_MontoSoles"), "#,##0.00")
            ImporteDolares_Princ = Format(dt.Rows(0).Item("MCAJ_MontoDolares"), "#,##0.00")
            ' CDbl(Format(CType(dt.Rows(0).Item("DCAJ_MontoActual_Soles"), Decimal), "#,##0.00"))

            'OBTENEMOS LOS DATOS DE LA "CAJA A ACERRAR"
            '-------------------------------------------
            NombCajaCerrar = NOMBRES_CAJA(index)
            IDCajero = CStr(FrmAperturarCaja.lblCodCajero.Text)
            FechaCierre = CStr(Format(Now, "dd/MM/yyyy hh:mm:ss"))
            ImporteSoles_Cerrar = MONTO_ACT_CAJASEL_SOL
            ImporteDolares_Cerrar = MONTO_ACT_CAJASEL_USD

            Serie = CStr(FrmAperturarCaja.txtNroSerie.Text)
            FacINI = CStr(FrmAperturarCaja.txtDocumInic.Text)
            FacFIN = CStr(FrmAperturarCaja.txtDocumFin.Text)
            TipoMov = "I"
            Detalle = "SE TRANSFIRIÓ S/. " & Format(ImporteSoles_Cerrar, "#,##0.00") & " Y " & " $. " & _
                      Format(ImporteDolares_Cerrar, "#,##0.00") & " DE " & NombCajaCerrar & " HACIA " & NombCajaPrinc

            If numPendientes > 0 Then
                MsgBox("La caja no puede ser cerrada." & vbNewLine & vbNewLine & _
                       "La " & NombCajaCerrar & " tiene ( " & numPendientes & " ) procesos pendientes." & vbNewLine & _
                       "actualicelos y vuelva a intentarlo.", vbCritical, "Actualizar")
            Else
                If MsgBox("La " & NombCajaCerrar & " esta apunto de cerrarse, de confirmar su acción " & _
                          "el sistema realizará las sgts. acciones:" & vbNewLine & vbNewLine & _
                          "1. Tranferirá S/ " & Format(ImporteSoles_Cerrar, "#,##0.00") & _
                          " y $ " & Format(ImporteDolares_Cerrar, "#,##0.00") & _
                          " hacia " & NombCajaPrinc & "." & vbNewLine & _
                          "2. Se cerrará de forma permanente " & NombCajaCerrar & "." & vbNewLine & vbNewLine & _
                          "Confirma el proceso de cirerre de la caja?", vbYesNo + vbQuestion + vbDefaultButton2, "Confirme") = vbYes Then

                    sqlOperacion = "SELECT COUNT(MCAJ_Codigo) FROM tb_movimiento_cajas " & _
                                   "WHERE CAJ_Codigo='" & IDCajaCerrar & "' AND " & _
                                   "DATEPART(MONTH, MCAJ_FechaHora)='" & Format(Now, "MM") & "'"

                    NroOperacion = objFunciones.Generar_Codigo(sqlOperacion, "0000")

                    'INSERTAMOS LA TRANSFERENCIA ENTRE CAJAS DE CAJA A CERRAR
                    '---------------------------------------------------------
                    sqlInsertarMovimiento =
                    "INSERT INTO tb_movimiento_cajas(CAJ_Codigo, CON_Codigo, MCAJ_NroOperacion, MCAJ_Pagador, " & _
                    "MCAJ_Recibidor, MCAJ_Tipo, MCAJ_FechaHora, MCAJ_MontoSoles, " & _
                    "MCAJ_MontoDolares, MCAJ_Detalle, MCAJ_Proveniente, MCAJ_Activo) " & _
                    "VALUES('" & IDCajaPrinc & "', '" & IDConcepto & "', '" & NroOperacion & "', '" & _
                    IDCajero & "', '" & IDCajeroPrinc & "', '" & _
                    TipoMov & "', '" & FechaCierre & "', '" & objFunciones.convertMoneda(ImporteSoles_Cerrar) & "', '" & _
                    objFunciones.convertMoneda(ImporteDolares_Cerrar) & "', '" & Detalle & "', '" & Proveniente & "', '" & 0 & "')"
                    'IDCajaCerrar

                    sqlActualizarCaja = "UPDATE tb_cajas SET " & _
                                        "CAJ_Aperturado='" & 2 & "' " & _
                                        "WHERE CAJ_Codigo='" & IDCajaCerrar & "'"

                    If (objFunciones.Ejecutar(sqlInsertarMovimiento)) Then
                        If (objFunciones.Ejecutar(sqlActualizarCaja)) Then
                            With FrmAperturarCaja
                                crearBotones(sqlCajas, .panelCajas, 200, 132, 5)
                            End With

                            MsgBox("La " & NombCajaCerrar & " ha sido cerrada con exito.", vbInformation, "¡Exito!")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & _
                                           objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub btnIngreso_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim btn As Button = sender
        Dim IDCaja As String

        Try
            index = CInt(btn.Tag)
            IDCaja = CStr(btns(index).Name)

            With FrmActualizarCaja
                .lblIDCaja.Text = IDCaja
                .lblNombCaja.Text = CStr(btns(index).Text)

                .ShowDialog()
            End With
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub btnCaja_DblClick(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim btn As Label = sender
        Dim IDCaja As String
        Dim Mes As Integer = Format(Now, "MM")
        Dim colorCerrado As Color

        Try
            index = CInt(btn.Tag)
            IDCaja = CStr(btns(index).Name)

            colorCerrado = btns(index).BackColor

            NOMB_VENTANA_ACTIVA = "Detalle_x_Caja"

            If colorCerrado <> Color.FromArgb(254, 92, 92) Then
                'If MDIPrincipal.mnuOperacionesCajas.Enabled = True Then
                With FrmListaEgresos
                    .lblCodCaja.Text = IDCaja

                    'LLENAMOS LA LISTA DE MOVIMIENTOS
                    '---------------------------------
                    Dim sqlMovimientos As String
                    Dim fecha As Date = Format(Now, "dd/MM/yyyy")

                    sqlMovimientos = "SELECT MC.CON_Codigo, MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
                    "(SELECT CAJ_Nombre FROM tb_cajas WHERE CAJ_Codigo = MC.CAJ_Codigo) AS Caja, " & _
                    "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo = MC.CON_Codigo) AS Consepto, " & _
                    "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Pagador) AS Pagador, " & _
                    "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Recibidor) AS Recibidor, " & _
                    "(SELECT COALESCE(SUM(DGAS_MontoSoles), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverSoles, " & _
                    "(SELECT COALESCE(SUM(DGAS_MontoDolares), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverDolares, " & _
                    "MCAJ_MontoSoles, MCAJ_MontoDolares, MCAJ_Detalle AS Detalle, MCAJ_Activo AS Estado " & _
                    "FROM tb_movimiento_cajas MC, tb_conceptos C, tb_cajas CA " & _
                    "WHERE MC.CON_Codigo = C.CON_Codigo AND " & _
                    "MC.CAJ_Codigo = CA.CAJ_Codigo AND " & _
                    "MC.MCAJ_Tipo='E' AND " & _
                    "MC.CAJ_Codigo='" & IDCaja & "' AND " & _
                    "DATEPART(MONTH, MC.MCAJ_FechaHora)='" & Mes & "'"

                    .lblQueda_Sol.Text = Format(MONTO_ACT_CAJASEL_SOL, "#,##0.00")
                    .lblQueda_Dol.Text = Format(MONTO_ACT_CAJASEL_USD, "#,##0.00")

                    listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
                    .ShowDialog()
                End With
                'Else
                'If USU_CODIGO = FrmAperturarCaja.lblCodCajero.Text Then
                'With FrmListaEgresos
                '.lblCodCaja.Text = IDCaja
                '.lblQueda_Sol.Text = ""
                '.lblQueda_Dol.Text = ""

                ''LLENAMOS LA LISTA DE MOVIMIENTOS
                ''---------------------------------
                'Dim sqlMovimientos As String
                'Dim fecha As Date = Format(Now, "dd/MM/yyyy")

                'sqlMovimientos = "SELECT MC.MCAJ_Codigo, MC.CAJ_Codigo, MC.MCAJ_NroOperacion, MC.MCAJ_FechaHora, MC.MCAJ_Tipo,  " & _
                '                 "(SELECT CAJ_Nombre FROM tb_cajas WHERE CAJ_Codigo = MC.CAJ_Codigo) AS Caja, " & _
                '                 "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo = MC.CON_Codigo) AS Consepto, " & _
                '                 "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Pagador) AS Pagador, " & _
                '                 "(SELECT USU_Nombres FROM tb_usuarios WHERE USU_Codigo = MC.MCAJ_Recibidor) AS Recibidor, " & _
                '                 "(SELECT COALESCE(SUM(DGAS_MontoSoles), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverSoles, " & _
                '                 "(SELECT COALESCE(SUM(DGAS_MontoDolares), 0) FROM tb_detalle_gastos WHERE MCAJ_Codigo=MC.MCAJ_Codigo) AS DevolverDolares, " & _
                '                 "MCAJ_MontoSoles, MCAJ_MontoDolares, MCAJ_Detalle AS Detalle, MCAJ_Activo AS Estado " & _
                '                 "FROM tb_movimiento_cajas MC, tb_conceptos C, tb_cajas CA " & _
                '                 "WHERE MC.CON_Codigo = C.CON_Codigo AND " & _
                '                 "MC.CAJ_Codigo = CA.CAJ_Codigo AND " & _
                '                 "MC.MCAJ_Tipo='E' AND " & _
                '                 "MC.CAJ_Codigo='" & IDCaja & "' AND " & _
                '                 "DATEPART(MONTH, MC.MCAJ_FechaHora)='" & Mes & "'"

                '.lblQueda_Sol.Text = SolesenCaja
                '.lblQueda_Dol.Text = DolaresenCaja

                'listarMovimCaja(sqlMovimientos, .dgvDetalleMov)
                'colorFilaMovimientos(.dgvDetalleMov, 15)
                '.dgvDetalleMov.Refresh()

                '.ShowDialog()
                'End With
                'Else
                'MsgBox("Sin autorización." & vbNewLine & vbNewLine & _
                '       "No cuenta con permisos para abrir los movimientos de esta caja", vbCritical, "Permiso denegado")
                'End If
                'End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub btnMovimiento_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim btn As Button = sender
        Dim IDCaja As String

        Dim totCaja_SOL, totCaja_USD As String
        Dim queda_SOL, queda_USD As Double
        Dim ultimoIng_SOL, ultimoIng_USD As Double
        Dim fechaApertura As String

        Try
            index = CInt(btn.Tag)
            IDCaja = CStr(btns(index).Name)

            ''CARGAR DETALLE DE CAJA
            ''--------------------------
            'SQLDetalle =
            '"SELECT C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres, " & _
            '"SUM(MC.MCAJ_MontoSoles) AS TOTAL_ING_SOL, " & _
            '"SUM(MC.MCAJ_MontoDolares) AS TOTAL_ING_USD, " & _
            '"(SELECT MCAJ_FechaHora FROM tb_movimiento_cajas WHERE CON_Codigo='A007' AND CAJ_Codigo='" & IDCaja & "') AS FECHAAPERTURA, " & _
            '"ISNULL((SELECT TOP 1 ISNULL(MCAJ_MontoSoles, 0.00) FROM tb_movimiento_cajas " & _
            '"WHERE CAJ_Codigo='" & IDCaja & "' AND MCAJ_Tipo='I' ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_SOL, " & _
            '"ISNULL((SELECT TOP 1 ISNULL(MCAJ_MontoDolares, 0.00) FROM tb_movimiento_cajas " & _
            '"WHERE CAJ_Codigo='" & IDCaja & "' AND MCAJ_Tipo='I' ORDER BY MCAJ_FechaHora DESC), 0.00) AS ULT_ING_USD " & _
            '"FROM tb_cajas C, tb_movimiento_cajas MC, tb_usuarios U " & _
            '"WHERE C.CAJ_Codigo = MC.CAJ_Codigo AND " & _
            '"C.USU_Codigo = U.USU_Codigo AND " & _
            '"MCAJ_Tipo='I' AND C.CAJ_Codigo='" & IDCaja & "' " & _
            '"GROUP BY C.CAJ_Codigo, C.CAJ_Nombre, U.USU_Codigo, U.USU_Nombres"

            'Dim dt_Detalle = New Data.DataTable
            'Dim sqlda_Detalle = New SqlDataAdapter(SQLDetalle, cnn)
            'sqlda_Detalle.Fill(dt_Detalle)
            'numRegDetalle = dt_Detalle.Rows.Count

            'SQLResumen =
            '"SELECT MC.MCAJ_MontoSoles AS DESEMBOLSOS_SOL, " & _
            '"ISNULL((SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_SOL, " & _
            '"ISNULL((MC.MCAJ_MontoSoles - (SELECT SUM(DG.DGAS_MontoSoles) FROM tb_detalle_gastos DG WHERE " & _
            '"MC.MCAJ_Codigo=DG.MCAJ_Codigo)), 0.00) AS RETORNO_SOL, " & _
            '" MC.MCAJ_MontoDolares AS DESEMBOLSOS_USD, " & _
            '"ISNULL((SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG WHERE MC.MCAJ_Codigo=DG.MCAJ_Codigo), 0.00) AS GASTOS_USD, " & _
            '"ISNULL((MC.MCAJ_MontoDolares - (SELECT SUM(DG.DGAS_MontoDolares) FROM tb_detalle_gastos DG WHERE " & _
            '"MC.MCAJ_Codigo=DG.MCAJ_Codigo)), 0.00) AS RETORNO_USD " & _
            '"FROM tb_movimiento_cajas MC " & _
            '"WHERE MC.CAJ_Codigo='" & IDCaja & "' AND MC.CON_Codigo<>'A007' AND MCAJ_Tipo='E'"

            'Dim dt_Resumen = New Data.DataTable
            'Dim sqlda_Resumen = New SqlDataAdapter(SQLResumen, cnn)
            'sqlda_Resumen.Fill(dt_Resumen)
            'numRegResumen = dt_Resumen.Rows.Count

            'totDesemb_SOL = 0 : totDesemb_USD = 0
            'totGasto_SOL = 0 : totGasto_USD = 0
            'totRetorna_SOL = 0 : totRetorna_USD = 0
            'For S = 0 To numRegResumen - 1
            'totDesemb_SOL += CDbl(dt_Resumen.Rows(S).Item("DESEMBOLSOS_SOL"))
            'totGasto_SOL += CDbl(dt_Resumen.Rows(S).Item("GASTOS_SOL"))
            'totRetorna_SOL += CDbl(dt_Resumen.Rows(S).Item("RETORNO_SOL"))

            'totDesemb_USD += CDbl(dt_Resumen.Rows(S).Item("DESEMBOLSOS_USD"))
            'totGasto_USD += CDbl(dt_Resumen.Rows(S).Item("GASTOS_USD"))
            'totRetorna_USD += CDbl(dt_Resumen.Rows(S).Item("RETORNO_USD"))
            'Next

            With FrmRegistrarMovimientos
                totCaja_SOL = TOTAL_CAJA_SOL 'Format(dt_Detalle.Rows(0).Item("TOTAL_ING_SOL"), "#,##0.00")
                queda_SOL = MONTO_ACT_CAJASEL_SOL 'Format(((totCaja_SOL - totDesemb_SOL) + totRetorna_SOL), "#,##0.00") 'Format(totCaja_SOL - totGasto_SOL, "#,##0.00")
                totCaja_USD = TOTAL_CAJA_USD 'Format(dt_Detalle.Rows(0).Item("TOTAL_ING_USD"), "#,##0.00")
                queda_USD = MONTO_ACT_CAJASEL_USD 'Format(((totCaja_USD - totDesemb_USD) + totRetorna_USD), "#,##0.00") 'Format(totCaja_USD - totGasto_USD, "#,##0.00")

                fechaApertura = FECHA_APERTURA 'Format(dt_Detalle.Rows(0).Item("FECHAAPERTURA"), "dd/MM/yyyy H:mm:ss")
                ultimoIng_SOL = ULTIMO_ING_SOL 'Format(dt_Detalle.Rows(0).Item("ULT_ING_SOL"), "#,##0.00")
                ultimoIng_USD = ultimoIng_USD 'Format(dt_Detalle.Rows(0).Item("ULT_ING_USD"), "#,##0.00")

                .lblCodCaja.Text = IDCaja 'CStr(dt_Detalle.Rows(0).Item("CAJ_Codigo"))
                .lblNombCaja.Text = NOMBRES_CAJA(index) 'CStr(dt_Detalle.Rows(0).Item("CAJ_Nombre"))
                .lblNomRespCaja.Text = NOMB_CAJERO 'CStr(dt_Detalle.Rows(0).Item("USU_Nombres"))
                .lblTotalCaja_Soles.Text = Format(MONTO_ACT_CAJASEL_SOL, "#,##0.00") 'queda_SOL
                .lblTotalCaja_Dolares.Text = Format(MONTO_ACT_CAJASEL_USD, "#,##0.00") 'queda_USD

                FrmAperturarCaja.Close()

                FrmRegistrarMovimientos.MdiParent = MDIPrincipal
                FrmRegistrarMovimientos.Show()
            End With

            'cnn.Close()

        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, FrmAperturarCaja.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    'MARCAS Y MODELOS DE PRODUCTOS
    '------------------------------
    Public Sub llenarMarcas_x_Categoria(ByVal Combo As ComboBox, ByVal Consulta As String)
        Dim numReg As Integer

        Try
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                With Combo
                    .DataSource = dt
                    .DisplayMember = "MAR_Nombre"
                    .ValueMember = "MAR_Codigo"
                End With
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    'PERMISOS POR NIVEL
    '-----------------------
    Public Sub escanItemsMenu(ByVal Menu As MenuStrip)
        Dim nombCabecera As String = ""

        For Each OpcionMenu As ToolStripMenuItem In Menu.Items
            nombCabecera = OpcionMenu.Text

            If OpcionMenu.DropDownItems.Count > 0 Then
                objMenus.registraPermiso(OpcionMenu.DropDownItems, "-", nombCabecera)
            End If
        Next
    End Sub

    Public Sub escanPermisos(ByVal Menu As MenuStrip)
        For Each OpcionMenu As ToolStripMenuItem In Menu.Items
            If OpcionMenu.DropDownItems.Count > 0 Then
                objMenus.validarPermisos(OpcionMenu.DropDownItems, "-")
            End If
        Next
    End Sub

    Public Sub habilitarPermisos(ByVal Boton As ToolStrip)
        Dim subMenu As String = ""
        Dim sqlPermAsignados As String
        Dim numPermisos As Integer
        Dim obtModuloAsignado As String

        sqlPermAsignados = "SELECT P.PER_Codigo, P.PER_Descripcion " & _
        "FROM tb_permisos P, tb_permisos_x_nivel PN " & _
        "WHERE PN.PER_Codigo=P.PER_Codigo AND " & _
        "PN.NUSU_Codigo='" & USU_COD_NIVEL & "'"

        dt = New Data.DataTable
        sqlda = New SqlDataAdapter(sqlPermAsignados, cnn)
        sqlda.Fill(dt)

        numPermisos = CInt(dt.Rows.Count) - 1

        '---------------------------------
        'RECORRER Menu
        '---------------------------------
        For Each OpcionBoton As ToolStripItem In Boton.Items
            If TypeOf OpcionBoton Is ToolStripButton Then
                For j = 0 To numPermisos 'Boton.Items.Count
                    obtModuloAsignado = CStr(dt.Rows(j).Item("PER_Descripcion"))

                    If OpcionBoton.Text = obtModuloAsignado Then 'tag
                        OpcionBoton.Enabled = True
                        Exit For
                    Else
                        OpcionBoton.Enabled = False
                    End If
                Next
            End If
        Next

        Dim subMenuItems As ToolStripItemCollection

        For Each OpcionBoton As ToolStripItem In Boton.Items
            If TypeOf OpcionBoton Is ToolStripSplitButton Then
                subMenuItems = CType(OpcionBoton, ToolStripSplitButton).DropDownItems

                For Each subItem As ToolStripItem In subMenuItems
                    subMenu = subItem.Text

                    'RESTRINGIMOS PRIVILEGIOS
                    '---------------------------------
                    For i = 0 To numPermisos
                        obtModuloAsignado = CStr(dt.Rows(i).Item("PER_Descripcion"))

                        If subMenu = obtModuloAsignado Then 'tag
                            subItem.Enabled = True
                            Exit For
                        Else
                            subItem.Enabled = False
                        End If
                    Next
                Next
            End If
        Next
    End Sub

    Public Sub reproducirTexto(ByVal Texto As Object, Volumen As Integer, Rate As Integer)
        Dim audio = CreateObject("SAPI.spvoice")

        audio.volume = Volumen
        audio.rate = Rate
        audio.speak(Texto)
    End Sub

    Public Sub playSonido(ByVal rutaArchivo As String, ByVal Archivo As String)
        Dim sonido As System.Media.SoundPlayer
        sonido = New System.Media.SoundPlayer(rutaArchivo & Archivo)

        sonido.Play()
    End Sub

    Public Sub listarMov_Ingreso(ByVal GRIDA As DataGridView, ByVal IDCaja As String, _
                                 ByVal Frecuencia As String, ByVal ANIO As Integer)
        Dim sqlMov_x_Fecha As String = ""
        Dim filaFecha, num, semanaAct As Integer
        Dim fechaActual, fechaInicio, fechaFin As Date
        Dim primerDia, ultimoDia As Date

        Dim DIA, MES As Integer

        DIA = Format(Now, "dd") : MES = Format(Now, "MM")

        If objFunciones.esAnioBiciesto(ANIO) Then
            fechaActual = DIA & "/" & MES & "/" & ANIO 'Format(Now, "dd/MM/yyyy")
        Else
            fechaActual = DIA - 1 & "/" & MES & "/" & ANIO
        End If

        primerDia = objFunciones.PrimerDiaDelMes(fechaActual)
        ultimoDia = objFunciones.UltimoDiaDelMes(fechaActual)

        fechaInicio = objFunciones.PrimerDiaDelMes(fechaActual)
        fechaFin = objFunciones.obtFechaFin(primerDia)

        semanaAct = objFunciones.semanaActual(primerDia, fechaActual)

        GRIDA.Rows.Clear()

        Try
            If ANIO = Format(Now, "yyyy") Then
                If Frecuencia = "Semanas" Then
                    For S As Integer = 1 To semanaAct '- 1
                        If fechaFin.AddDays(6) >= ultimoDia Then
                            fechaFin = ultimoDia
                        End If

                        If fechaFin <= ultimoDia Then
                            sqlMov_x_Fecha =
                                "SELECT MC.MCAJ_NroOperacion, MC.MCAJ_Detalle, CONVERT(varchar(10), MC.MCAJ_FechaHora, 103) AS MCAJ_FechaHora, " & _
                                "MC.MCAJ_Detalle, " & _
                                "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo=MC.CON_Codigo) AS Concepto, " & _
                                "MC.MCAJ_MontoSoles, MC.MCAJ_MontoDolares, MC.MCAJ_Activo, MCAJ_Proveniente " & _
                                "FROM tb_movimiento_cajas MC " & _
                                "WHERE CONVERT(varchar(10), MCAJ_FechaHora,103) BETWEEN '" & fechaInicio & "' AND '" & fechaFin & "' AND " & _
                                "MCAJ_Tipo='I' AND MC.CAJ_Codigo='" & IDCaja & "'"
                            'End If
                            num = objFunciones.getnumeroRegs(sqlMov_x_Fecha)
                            filaFecha = GRIDA.RowCount
                            llenarGrida(GRIDA, num, sqlMov_x_Fecha, fechaInicio, fechaFin, filaFecha)

                            fechaInicio = fechaFin.AddDays(1)
                            fechaFin = objFunciones.obtFechaFin(fechaInicio)
                        End If
                    Next
                ElseIf Frecuencia = "Mes" Then
                    sqlMov_x_Fecha =
                        "SELECT MC.MCAJ_NroOperacion, MC.MCAJ_Detalle, CONVERT(varchar(10),MC.MCAJ_FechaHora,103) AS MCAJ_FechaHora, MC.MCAJ_Detalle, " & _
                        "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo=MC.CON_Codigo) AS Concepto, " & _
                        "MC.MCAJ_MontoSoles, MC.MCAJ_MontoDolares, MC.MCAJ_Activo, MCAJ_Proveniente " & _
                        "FROM tb_movimiento_cajas MC " & _
                        "WHERE CONVERT(varchar(10), MCAJ_FechaHora,103) BETWEEN '" & fechaInicio & "' AND '" & ultimoDia & "' AND " & _
                        "MC.MCAJ_Tipo='I' AND MC.CAJ_Codigo='" & IDCaja & "'"

                    num = objFunciones.getnumeroRegs(sqlMov_x_Fecha)
                    filaFecha = GRIDA.RowCount
                    llenarGrida(GRIDA, num, sqlMov_x_Fecha, fechaInicio, ultimoDia, filaFecha)
                End If
            Else 'AGRUPAMOS INGRESOS POR MESES
                'fechaInicio = "01/01/" & ANIO
                'fechaFin = "31/12/" & ANIO

                For M = 1 To 12
                    fechaInicio = objFunciones.PrimerDiaDelMes(CDate("01/" & M & "/" & ANIO))
                    fechaFin = objFunciones.UltimoDiaDelMes(CDate("01/" & M & "/" & ANIO))

                    sqlMov_x_Fecha =
                        "SELECT MC.MCAJ_NroOperacion, MC.MCAJ_Detalle, CONVERT(varchar(10),MC.MCAJ_FechaHora,103) AS MCAJ_FechaHora, MC.MCAJ_Detalle, " & _
                        "(SELECT CON_Descripcion FROM tb_conceptos WHERE CON_Codigo=MC.CON_Codigo) AS Concepto, " & _
                        "MC.MCAJ_MontoSoles, MC.MCAJ_MontoDolares, MC.MCAJ_Activo, MCAJ_Proveniente " & _
                        "FROM tb_movimiento_cajas MC " & _
                        "WHERE DATEPART(MONTH, MCAJ_FechaHora)='" & M & "' AND " & _
                        "DATEPART(YEAR, MCAJ_FechaHora)='" & ANIO & "' AND " & _
                        "MC.MCAJ_Tipo='I' AND MC.CAJ_Codigo='" & IDCaja & "' " & _
                        "ORDER BY MCAJ_FechaHora"

                    '"WHERE MCAJ_FechaHora BETWEEN '" & fechaInicio & "' AND '" & fechaFin & "' AND " & _
                    num = objFunciones.getnumeroRegs(sqlMov_x_Fecha)
                    filaFecha = GRIDA.RowCount

                    llenarGrida(GRIDA, num, sqlMov_x_Fecha, fechaInicio, fechaFin, filaFecha)
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", listarMov_Ingreso())")
        End Try
    End Sub

    Private Sub llenarGrida(ByVal GRIDA As DataGridView, ByVal num As Integer, ByVal SQL As String,
                            ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FilaFecha As Integer)

        Dim filaActual, numReg As Integer
        Dim NroOp, Proveniente, FechaHora, Concepto, Detalle, Importe_Sol, Importe_Dol, Estado, strEstado As String
        Dim SumaSoles As Double = 0
        Dim SumaDolares As Double = 0

        If num > 0 Then
            GRIDA.Rows.Add()
            GRIDA.Rows(FilaFecha).DefaultCellStyle.Font = New Drawing.Font("Cour New", 7, FontStyle.Bold, GraphicsUnit.Point)
            GRIDA.Item(2, FilaFecha).Value = "[ " & Format(FechaInicio, "dd/MM/yyyy") & " - " & Format(FechaFin, "dd/MM/yyyy") & " ]" '<-FECHA
            GRIDA.Item(2, FilaFecha).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDA.Rows(FilaFecha).DefaultCellStyle.BackColor = Color.FromArgb(189, 189, 189)

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(SQL, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count

            If numReg > 0 Then
                For j = 0 To numReg - 1
                    NroOp = CStr(dt.Rows(j).Item("MCAJ_NroOperacion"))
                    Proveniente = CStr(dt.Rows(j).Item("MCAJ_Proveniente").ToString)
                    FechaHora = Format(CDate(dt.Rows(j).Item("MCAJ_FechaHora")), "dd/MM/yyyy") 'dt.Rows(j).Item("MCAJ_FechaHora") 'Format(dt.Rows(j).Item("MCAJ_FechaHora"), "dd/MM/yyyy")
                    Concepto = CStr(dt.Rows(j).Item("Concepto"))
                    Detalle = CStr(dt.Rows(j).Item("MCAJ_Detalle"))
                    Importe_Sol = Format(dt.Rows(j).Item("MCAJ_MontoSoles"), "#,##0.00")
                    Importe_Dol = Format(dt.Rows(j).Item("MCAJ_MontoDolares"), "#,##0.00")
                    Estado = CStr(dt.Rows(j).Item("MCAJ_Activo"))

                    If Estado = "0" Then
                        strEstado = "TERMINADO"
                    ElseIf Estado = "X" Then
                        strEstado = "ELIMINADO"
                    End If

                    GRIDA.Rows.Add(NroOp, Proveniente, Detalle, Concepto, FechaHora, Importe_Sol, Importe_Dol, strEstado)

                    If Estado = "0" Then
                        GRIDA.Rows(GRIDA.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(154, 154, 164)
                        GRIDA.Rows(GRIDA.RowCount - 1).DefaultCellStyle.ForeColor = Color.FromArgb(211, 210, 215)
                    Else
                        GRIDA.Rows(GRIDA.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(217, 47, 0)
                        GRIDA.Rows(GRIDA.RowCount - 1).DefaultCellStyle.ForeColor = Color.White
                    End If

                    GRIDA.Rows(GRIDA.RowCount - 1).DefaultCellStyle.Font = New Drawing.Font("Cour New", 9, FontStyle.Regular, GraphicsUnit.Point)
                    GRIDA.Item(0, GRIDA.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GRIDA.Item(3, GRIDA.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    GRIDA.Item(7, GRIDA.RowCount - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight

                    SumaSoles += Importe_Sol
                    SumaDolares += Importe_Dol
                Next

                filaActual = CInt(GRIDA.RowCount)

                'AGREGAR FILA CON LA SUMA DE LOS MONTOS
                '---------------------------------------
                GRIDA.Rows.Add()

                GRIDA.Rows(filaActual).DefaultCellStyle.Font = New Drawing.Font("Tahoma", 7, FontStyle.Bold, GraphicsUnit.Point)
                GRIDA.Rows(filaActual).DefaultCellStyle.BackColor = Color.Yellow

                GRIDA.Item(4, filaActual).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDA.Item(4, filaActual).Value = "Tot. -->> "
                GRIDA.Item(5, filaActual).Value = Format(SumaSoles, "#,##0.00")
                GRIDA.Item(6, filaActual).Value = Format(SumaDolares, "#,##0.00")
                GRIDA.Item(7, filaActual).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDA.Item(7, filaActual).Value = "Nº Reg = " & numReg

                FilaFecha = GRIDA.RowCount
            End If
        End If
    End Sub

    Public Sub AgregarTABS_Categorias(TabCategorias As TabControl, Completa As Boolean)
        '---------------------------------
        'AGREGAR TABPAGE POR CATEGORIAS
        '---------------------------------
        Dim sqlCategorias As String
        Dim ID_Categoria, Nomb_Categoria As String
        Dim numReg As Integer

        sqlCategorias = "SELECT CAT_Codigo, CAT_Nombre FROM tb_categorias ORDER BY CAT_Nombre"

        Try
            dtaux = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlCategorias, cnn)
            sqlda.Fill(dtaux)

            numReg = dtaux.Rows.Count

            ReDim Preserve GridaProductos(numReg)

            TabCategorias.TabPages.Clear()

            If numReg > 0 Then
                For i = 0 To numReg - 1
                    GridaProductos(i) = New DataGridView
                    ID_Categoria = CStr(dtaux.Rows(i).Item("CAT_Codigo"))
                    Nomb_Categoria = CStr(dtaux.Rows(i).Item("CAT_Nombre"))

                    'AGREGARMOS EL DATAGRIDVIEW
                    '----------------------------
                    With GridaProductos(i)
                        .Name = "dgv_" & Nomb_Categoria
                        .Dock = DockStyle.Fill
                        .Location = New Point(0, 0)

                        .BorderStyle = BorderStyle.None
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        '.CellBorderStyle = DataGridViewCellBorderStyle.None
                        .DefaultCellStyle.SelectionBackColor = Color.Red
                        .MultiSelect = False
                        .ReadOnly = True
                        .RowHeadersVisible = False
                        .RowTemplate.Height = 23
                        .AllowUserToAddRows = False
                        .AllowUserToDeleteRows = False
                        .AllowUserToOrderColumns = False
                        .AllowUserToResizeRows = False
                        .ColumnHeadersHeight = 42

                        If Completa Then
                            .Columns.Add(0, "CÓDIGO") : .Columns(0).Width = 50 : .Columns(0).Visible = False
                            .Columns.Add(1, "MARCA") : .Columns(1).Width = 120
                            .Columns.Add(2, "MODELO") : .Columns(2).Width = 145
                            .Columns.Add(3, "DESCRIPCIÓN DEL PRODUCTO") : .Columns(3).Width = 520
                            .Columns.Add(4, "MONEDA") : .Columns(4).Width = 60 : .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns.Add(5, "PRECIO") : .Columns(5).Width = 100 : .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Columns.Add(6, "DSCTO.") : .Columns(6).Width = 60 : .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns.Add(7, "STOCK") : .Columns(7).Width = 60 : .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                            Dim imagen As New DataGridViewImageColumn
                            imagen.HeaderText = "" : imagen.Width = 45 : .Columns.Add(imagen)
                        Else
                            .Columns.Add(0, "CÓDIGO") : .Columns(0).Width = 50 : .Columns(0).Visible = False
                            .Columns.Add(1, "DESCRIPCIÓN DEL PRODUCTO") : .Columns(1).Width = (66 * 682) / 100 '400
                            .Columns.Add(2, "MONEDA") : .Columns(2).Width = 60 : .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns.Add(3, "PRECIO") : .Columns(3).Width = 100 : .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                            Dim imagen As New DataGridViewImageColumn
                            imagen.HeaderText = "" : imagen.Width = 45 : .Columns.Add(imagen)
                        End If

                        TabCategorias.TabPages.Add(Nomb_Categoria)
                        TabCategorias.TabPages.Item(i).Name = ID_Categoria
                        TabCategorias.TabPages(i).Controls.Add(GridaProductos(i))

                        AddHandler .CellDoubleClick, AddressOf GRIDA_DblClick
                    End With
                Next
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", AgregarTABS_Categorias()" & ")")
        End Try
    End Sub

    Private Sub GRIDA_DblClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim fila As Integer = e.RowIndex

        Dim numReg, num As Integer
        Dim Existe As Boolean
        'Dim POS As Integer

        Dim sqlConsulta, getIDProducto As String

        Dim IDCategoria, ID_Marca, Marca, NombProducto, Modelo, DescProd As String
        Dim Estructura, Plataforma, CodBarras, Moneda, Especific As String
        Dim Precio, Dscto, Stock, Importe As Double
        Dim imagen As Image
        Dim N, Cant As Integer
        Dim subTotal, Total, valIGV, Materiales As Double

        Try
            If fila > -1 Then
                getIDProducto = sender.Item(0, fila).Value

                sqlConsulta = "SELECT P.PRD_Codigo, P.PRD_Nombre, " & _
                "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre, " & _
                "ISNULL(P.PRD_Modelo, 'NO REGISTRA') AS PRD_Modelo, P.PRD_Precio " & _
                "FROM tb_productos P " & _
                "WHERE P.PRD_Codigo='" & getIDProducto & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlConsulta, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count

                If numReg > 0 Then
                    NombProducto = CStr(dt.Rows(0).Item("PRD_Nombre"))
                    Marca = CStr(dt.Rows(0).Item("MAR_Nombre"))
                    Modelo = CStr(dt.Rows(0).Item("PRD_Modelo"))
                    Precio = CDbl(dt.Rows(0).Item("PRD_Precio"))

                    Dim numRegAgregados As Integer = FrmProforma.dgvDetalleCotizacion.RowCount
                    '----------------------------
                    'AGREGAR PRODUCTOS A PROFORMA
                    '----------------------------
                    If objFunciones.estaVentanaAbierta(FrmListaProductos) Then 'NOMB_VENTANA_ACTIVA = "" Then
                        With FrmProforma
                            N = numRegAgregados + 1

                            For Each fil As DataGridViewRow In .dgvDetalleCotizacion.Rows
                                If fil.Cells.Item(6).Value = getIDProducto Then
                                    .dgvDetalleCotizacion.Item(4, fil.Index).Value += 1
                                    Cant = .dgvDetalleCotizacion.Item(4, fil.Index).Value
                                    Importe = Precio * Cant
                                    .dgvDetalleCotizacion.Item(5, fil.Index).Value = Format(Importe, "#,##0.00")

                                    Existe = True
                                    Exit For
                                Else
                                    Existe = False
                                End If
                            Next

                            If Existe = False Then
                                Importe = Precio * 1

                                If Marca = "NO REGISTRA" And Modelo <> "NO REGISTRA" Then
                                    DescProd = NombProducto & " MOD. " & Modelo
                                ElseIf Modelo = "NO REGISTRA" And Marca <> "NO REGISTRA" Then
                                    DescProd = NombProducto & " MAR. " & Marca
                                ElseIf Marca = "NO REGISTRA" And Modelo = "NO REGISTRA" Then
                                    DescProd = NombProducto
                                ElseIf Marca <> "NO REGISTRA" And Modelo <> "NO REGISTRA" Then
                                    DescProd = NombProducto & " MAR. " & Marca & " MOD. " & Modelo
                                End If

                                .dgvDetalleCotizacion.Rows.Add("", N, DescProd, Format(Precio, "#,##0.00"), 1, Format(Importe, "#,##0.00"), getIDProducto)
                            End If

                            subTotal = objFunciones.Sumar_Columna(.dgvDetalleCotizacion, 5)

                            If .chkIncIGV.Checked Then
                                valIGV = subTotal * (IGV / 100)
                            Else
                                valIGV = 0
                            End If

                            Total = subTotal + valIGV
                            Materiales = Total * (.txtMateriales.Text / 100)
                            'subTotal = objFunciones.Sumar_Columna(.dgvDetalleCotizacion, 5)
                            'valIGV = subTotal * (IGV / 100)
                            'Total = subTotal + valIGV
                            'Materiales = Total * (.txtMateriales.Text / 100)

                            .lblMateriales.Text = Format(Materiales, "#,##0.00")
                            .lblSubTotal.Text = Format(subTotal, "#,##0.00")
                            .lblIGV.Text = Format(valIGV, "#,##0.00")
                            .lblTotal.Text = Format(Total + Materiales, "#,##0.00")
                        End With
                    ElseIf objFunciones.estaVentanaAbierta(FrmCatalogoProductos) Then
                        'EDITAR
                        '--------------------
                        If MDIPrincipal.mnuEditarProductosExistentes.Enabled Then
                            sqlConsulta =
                            "SELECT ISNULL(P.PRD_Modelo, 'NO REGISTRA') AS PRD_Modelo, P.CAT_Codigo, P.PRD_Estructura, P.PRD_Plataforma, P.PRD_CodBarras, P.PRD_Nombre, " & _
                            "ISNULL((SELECT MAR_Codigo FROM tb_marcas WHERE MAR_Codigo=P.MAR_Codigo), 0) AS MAR_Codigo, " & _
                            "ISNULL((SELECT MAR_Nombre FROM tb_marcas WHERE MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS Marca, " & _
                            "P.PRD_Moneda, P.PRD_Precio, P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen, P.PRD_Activo, " & _
                            "(SELECT C.esBALANZA FROM tb_categorias C WHERE C.CAT_Codigo=P.CAT_Codigo) AS esBALANZA " & _
                            "FROM tb_productos P " & _
                            "WHERE PRD_Codigo='" & getIDProducto & "'"

                            dtaux = New Data.DataTable
                            sqlda = New SqlDataAdapter(sqlConsulta, cnn)
                            sqlda.Fill(dtaux)

                            num = dtaux.Rows.Count

                            If num > 0 Then
                                IDCategoria = CStr(dtaux.Rows(0).Item("CAT_Codigo").ToString)
                                ID_Marca = Trim(CStr(dtaux.Rows(0).Item("MAR_Codigo")))
                                Marca = CStr(dtaux.Rows(0).Item("Marca"))
                                Modelo = CStr(dtaux.Rows(0).Item("PRD_Modelo"))
                                Estructura = CStr(dtaux.Rows(0).Item("PRD_Estructura").ToString)
                                Plataforma = CStr(dtaux.Rows(0).Item("PRD_Plataforma").ToString)
                                CodBarras = CStr(dtaux.Rows(0).Item("PRD_CodBarras"))
                                NombProducto = CStr(dtaux.Rows(0).Item("PRD_Nombre"))
                                Moneda = CStr(dtaux.Rows(0).Item("PRD_Moneda"))
                                Precio = CDbl(dtaux.Rows(0).Item("PRD_Precio"))
                                Dscto = CStr(dtaux.Rows(0).Item("PRD_Dscto"))
                                Stock = CStr(dtaux.Rows(0).Item("PRD_Stock"))
                                Especific = CStr(dtaux.Rows(0).Item("PRD_Especificaciones").ToString)
                                imagen = objImagenes.ByteArrayToImage(DirectCast(dtaux.Rows(0).Item("PRD_Imagen"), Byte()))

                                With FrmProductos
                                    .cmdGuardar.Text = "Cambiar datos"
                                    .lblIDProducto.Text = getIDProducto
                                    .lblIDCategoria.Text = IDCategoria
                                    .txtModelo.Text = Modelo
                                    .cboEstructura.Text = Estructura
                                    .TxtMedidas.Text = Plataforma
                                    .lblCodBarras.Text = CodBarras
                                    .txtProducto.Text = NombProducto

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

                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub EffectIn(ByVal Formulario As Form)
        Dim Effect As Double
        For Effect = 0.0 To 1.1 Step 0.1
            Formulario.Opacity = Effect
            Formulario.Refresh()
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Public Sub EffectOut(ByVal Formulario As Form)
        Dim Effect As Double
        For Effect = 1.1 To 0.0 Step -0.1
            Formulario.Opacity = Effect
            Formulario.Refresh()
            Threading.Thread.Sleep(100)
        Next

        If Effect <= 0.0 Then
            Formulario.Close()
        End If
    End Sub

    Public Sub Imprimir_filtroClientes(ByVal Grida As DataGridView, ByVal Criterio As Integer,
                                       ByVal mostrarRegistos As Label,
                                       ByVal Filtro As String, Optional Balanza As Boolean = False,
                                       Optional Camara As Boolean = False)

        Dim Consulta As String = ""
        Dim Campo As String = ""
        Dim numReg As Integer
        Dim codCliente, UsuarioRegistro, RS, RUC, Ciudad, DirecLegal, observ As String

        Try
            '0:cliente | 1:ciudad | 2:empleado
            '---------------------------------
            If Criterio = 0 Then
                Campo = "CLI_RazonSocial"
            ElseIf Criterio = 1 Then
                Campo = "CLI_Ciudad"
            ElseIf Criterio = 2 Then
                Campo = "USU_Nombres"
            End If

            If Balanza = True And Camara = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Tipo='B' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = True And Balanza = False Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Tipo='C' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            ElseIf Camara = True And Balanza = True Then
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            Else
                Consulta = "SELECT C.CLI_Codigo, U.USU_Nombres, C.CLI_RazonSocial, C.CLI_RUC, " & _
                           "C.CLI_Ciudad, C.CLI_DireccionLegal, C.CLI_Observacion, C.CLI_Tipo " & _
                           "FROM tb_clientes C, tb_usuarios U " & _
                           "WHERE C.USU_Codigo = U.USU_Codigo AND " & _
                           "C.CLI_Tipo='0' AND " & _
                           Campo & " LIKE '%" & Filtro & "%'"
            End If

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dt)

            numReg = dt.Rows.Count - 1
            mostrarRegistos.Text = numReg + 1

            Grida.Rows.Clear()

            If numReg >= 0 Then
                For i = 0 To numReg
                    codCliente = CStr(dt.Rows(i).Item("CLI_Codigo"))
                    UsuarioRegistro = CStr(dt.Rows(i).Item("USU_Nombres"))
                    RS = CStr(dt.Rows(i).Item("CLI_RazonSocial"))
                    RUC = CStr(dt.Rows(i).Item("CLI_RUC"))
                    Ciudad = CStr(dt.Rows(i).Item("CLI_Ciudad"))
                    DirecLegal = CStr(dt.Rows(i).Item("CLI_DireccionLegal").ToString)
                    observ = CStr(dt.Rows(i).Item("CLI_Observacion").ToString)

                    Grida.RowTemplate.Height = 23
                    Grida.Rows.Add(codCliente, RUC, RS, DirecLegal, Ciudad, UsuarioRegistro)
                Next
            End If

            'cnn.Close()
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try
    End Sub

    'COMPRIMIR / DESCOMPRIMIR ARCHIVOS
    '---------------------------------
    Public Sub Extraer(ZipAExtraer As String, DirectorioExtraccion As String)
        Using zip1 As ZipFile = ZipFile.Read(ZipAExtraer)
            Dim e As ZipEntry
            For Each e In zip1
                e.Extract(DirectorioExtraccion, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using
    End Sub

    Public Sub Comprimir(NombreZip As String)
        Using zip As ZipFile = New ZipFile()
            zip.AddFile("Archivo1")
            zip.AddFile("Archivo2")
            zip.AddFile("Archivo3")
            zip.Save(NombreZip)
        End Using
    End Sub

    Public Sub listarAsistenciasTecnicas(GRIDA As DataGridView, Tipo As String)
        Dim IDAsist, Cliente, Ciudad, Balanza As String

        Dim numAsist, numDetAsist As Integer
        Dim colEmpresa As New DataGridViewTextBoxColumn
        colEmpresa.Name = "Col_0"

        With GRIDA
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .GridColor = SystemColors.AppWorkspace

            .Columns.Clear()

            .Columns.Add(colEmpresa.Name, "")

            .Rows.Add(5)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True

            .Rows(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Rows(1).Height = 150

            .Rows(0).Visible = False
            .Item(0, 0).Value = ""
            .Item(0, 1).Value = "E" & vbNewLine & "M" & vbNewLine & "P" & _
                                vbNewLine & "R" & vbNewLine & "E" & vbNewLine & _
                                "S" & vbNewLine & "A" & vbNewLine & "S"
            .Item(0, 2).Value = "CIUDAD"
            .Item(0, 3).Value = ""
            .Item(0, 4).Value = "FECHA"
            .Rows(4).Height = 45

            Dim sqlAsistenc As String =
            "SELECT AT.AST_Codigo, C.CLI_RazonSocial, AT.AST_Ciudad " & _
            "FROM tb_asistencia_tecnicas AT, tb_clientes C " & _
            "WHERE AT.CLI_Codigo=C.CLI_Codigo AND " & _
            "AT.AST_Tipo='" & Tipo & "' AND " & _
            "AT.AST_Activo='1'"

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlAsistenc, cnn)
            sqlda.Fill(dt)

            numAsist = dt.Rows.Count
            Dim nA As Integer
            For nA = 1 To numAsist
                .Columns.Add("Col_" & nA, "")

                IDAsist = dt.Rows(nA - 1).Item("AST_Codigo")
                Cliente = dt.Rows(nA - 1).Item("CLI_RazonSocial")
                Ciudad = dt.Rows(nA - 1).Item("AST_Ciudad")
                Balanza = "BALANZA " & nA

                .Item(nA, 0).Value = IDAsist
                .Item(nA, 1).Value = Cliente
                If Ciudad <> "Seleccione" Then
                    .Item(nA, 2).Value = Ciudad
                End If
                .Item(nA, 3).Value = Balanza
                '.Item(0, 4).Value = "FECHA"
                .Columns(nA).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Dim sqlDetAsist As String =
                "SELECT UPPER(DATENAME(WEEKDAY, DAST_Fecha)) AS Dia, DAST_Fecha " & _
                "FROM tb_detalle_asistencias " & _
                "WHERE AST_Codigo='" & IDAsist & "' AND " & _
                "DAST_Estado='1'"

                dtaux = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlDetAsist, cnn)
                sqlda.Fill(dtaux)

                numDetAsist = dtaux.Rows.Count

                Dim numFilas As Integer = CInt(.Rows.Count)
                Dim ocupa As Integer = 4 + numDetAsist
                Dim pos As Integer = 4
                Dim A As Integer
                For A = 1 To (ocupa - numFilas)
                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Height = 45
                    .Item(0, .Rows.Count - 1).Style.BackColor = SystemColors.AppWorkspace
                Next

                For F = 0 To numDetAsist - 1
                    .Item(nA, pos).Value = dtaux.Rows(F).Item("Dia") & vbNewLine & dtaux.Rows(F).Item("DAST_Fecha")

                    If dtaux.Rows(F).Item("DAST_Fecha") = Format(Now, "dd/MM/yyyy") Then
                        .Item(nA, pos).Style.BackColor = Color.FromArgb(253, 236, 112)
                        .Item(nA, pos).Style.ForeColor = Color.FromArgb(52, 73, 94)
                    ElseIf dtaux.Rows(F).Item("DAST_Fecha") <= Format(Now, "dd/MM/yyyy") Then
                        .Item(nA, pos).Style.BackColor = Color.FromArgb(234, 101, 118)
                        .Item(nA, pos).Style.ForeColor = Color.FromArgb(255, 255, 255)
                    Else
                        .Item(nA, pos).Style.BackColor = Color.FromArgb(52, 156, 95)
                        .Item(nA, pos).Style.ForeColor = Color.FromArgb(255, 255, 255)
                    End If
                    pos += 1
                Next
            Next
        End With
    End Sub

    Public Sub listar_DetalleAsistencias(Consulta As String, GRIDA As DataGridView)
        Dim numDetCot As Integer = 0
        Dim ID, Fecha, Estado, Dia As String

        Try
            Dim dtaux1 As DataTable = New Data.DataTable
            sqlda = New SqlDataAdapter(Consulta, cnn)
            sqlda.Fill(dtaux1)

            numDetCot = dtaux1.Rows.Count

            GRIDA.Rows.Clear()

            For i = 0 To numDetCot - 1
                ID = dtaux1.Rows(i).Item("DAST_Codigo")
                Fecha = dtaux1.Rows(i).Item("DAST_Fecha")
                Estado = dtaux1.Rows(i).Item("DAST_Estado")
                Dia = dtaux1.Rows(i).Item("Dia")

                GRIDA.Rows.Add(ID, i + 1, Dia, Fecha, Estado)
            Next
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "(modProcedimientos, listar_DetalleAsistencias())")
        End Try
    End Sub

    Public Sub Listar_Permisos(ByVal GRIDA As DataGridView)
        Try
            Dim consulta As String = "Select * from tb_permisos"
            Dim id, descrip, modulo, activo As String
            Dim numReg As Integer
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(consulta, cnn)
            sqlda.Fill(dt)
            numReg = dt.Rows.Count
            GRIDA.Rows.Clear()
            If numReg > 0 Then
                GRIDA.Enabled = True
                For i = 0 To numReg - 1
                    id = CStr(dt.Rows(i).Item("PER_Codigo"))
                    descrip = CStr(dt.Rows(i).Item("PER_descripcion"))
                    modulo = CStr(dt.Rows(i).Item("PER_NombModulo"))
                    activo = CStr(dt.Rows(i).Item("PER_Activo"))
                    GRIDA.RowTemplate.Height = 23
                    GRIDA.Rows.Add(id, descrip, modulo, activo)
                  Next
            Else
                GRIDA.Enabled = False
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try

    End Sub

    Public Sub Listar_Tipos(ByVal tipo As Integer, ByVal cboEstructura As ComboBox)
        Try
            Dim consulta As String = "SELECT '0' as COD_Tipo,  'Seleccione' as NOM_Tipo " & _
                                     "UNION SELECT COD_Tipo,NOM_Tipo FROM tb_Tipo where CAT_Codigo = '" & tipo & "'"
            Dim numReg As Integer
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(consulta, cnn)
            sqlda.Fill(dt)
            numReg = dt.Rows.Count
            If numReg > 0 Then
                With cboEstructura
                    .DataSource = dt
                    .DisplayMember = "NOM_Tipo"
                    .ValueMember = "COD_Tipo"
                End With
            End If
        Catch ex As Exception
            MostrarError(ex.HResult, ex.Message, "(modProcedimientos" & ", " & objFunciones.getNombreProcedimiento & ")")
        End Try

    End Sub


    'Public Sub verificarVersion()
    'Dim MyVer As String = VERSION_INSTALADA 'Application.StartupPath & "\version.txt"
    'Dim lastVer As String = My.Application.Info.Version.ToString

    ''If My.Computer.FileSystem.FileExists(file) Then
    ''My.Computer.FileSystem.DeleteFile(file)
    ''End If

    ''My.Computer.Network.DownloadFile("", file)
    ''Dim lastver As String = My.Computer.FileSystem.ReadAllText(file)

    '    If Not MyVer = lastver Then
    '        MsgBox("Una actualización se encuentra disponible")
    '    Else

    '    End If
    'End Sub
End Module