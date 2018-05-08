Imports System.Windows.Forms
Imports System.Data.SqlClient

Imports System.Globalization

Imports CrystalDecisions.Shared.Interop
'Imports Scripting
Imports System.Net
Imports System.Net.Dns
Imports System.IO

'Private Declare Function AnimateWindow Lib "user32" (ByVal hwnd As Long, ByVal dwTime As Long, ByVal dwFlags As Long) As Long

Public Class MDIPrincipal
    Dim EJECUTAR_SEG As Boolean = True

    Dim WithEvents CLIENTE As New WebClient

    Dim verB_Estados As Boolean
    Dim verB_Menus As Boolean
    Dim verB_Herramientas

    Dim SE_ACT As Boolean
    Dim Desc As String
    Dim Frec As Integer
    Dim Hora_Programada, Fecha_Programada As Date
    Dim Dom, Lun, Mar, Mie, Jue, Vie, Sab As Boolean
    Dim Dia As String

    Dim DIR As String

    Dim cont, cont_REQ As Integer

    Dim filaSelecReq As Integer
    Dim filaSelecCot As Integer

    Dim MES_ACTUAL As Integer = Format(Now, "MM")
    Dim NUM_MESSELEC As Integer = MES_ACTUAL

    Dim sqlConfigSys As String = "SELECT * FROM tb_configsis"

    Dim SQLRequerientos As String =
    "SELECT R.REQ_Codigo, R.REQ_Tipo, R.REQ_Fecha, R.REQ_Descripcion, " & _
    "R.REQ_Estado, R.REQ_Estado, C.CLI_RazonSocial, " & _
    "ISNULL(R.REQ_FechaSeg, '01/01/1900') AS REQ_FechaSeg, U.USU_Nombres " & _
    "FROM tb_requerimientos R, tb_usuarios U, tb_clientes C " & _
    "WHERE U.USU_Codigo=R.USU_Codigo AND " & _
    "R.CLI_Codigo=C.CLI_Codigo AND R.REQ_Estado='0' " & _
    "ORDER BY R.REQ_FechaSeg ASC"

    Dim SQLCotizaciones As String =
    "SELECT SUBSTRING(Co.COT_Codigo, 1, 8) AS Indice, " & _
    "(SELECT CLI_RazonSocial FROM tb_clientes C  WHERE C.CLI_Codigo=Co.CLI_Codigo) AS Cliente," & _
    "(SELECT U.USU_ApePaterno+' '+U.USU_ApeMaterno+', '+U.USU_Nombres FROM tb_usuarios U  WHERE U.USU_Codigo=Co.USU_Codigo) AS Registro, " & _
    "(SELECT COUNT(COT_Codigo) from tb_cotizaciones WHERE SUBSTRING(COT_Codigo, 1, 8)=SUBSTRING(Co.COT_Codigo, 1, 8)) AS NumCotiz " & _
    "FROM tb_cotizaciones Co " & _
    "WHERE Co.COT_Estado='1' " & _
    "GROUP BY SUBSTRING(Co.COT_Codigo, 1, 8), Co.CLI_Codigo, Co.USU_Codigo " & _
    "ORDER BY Indice"

    '"SELECT Co.COT_Codigo, Co.COT_Fecha,  Co.COT_Moneda, Co.COT_CONIGV, Co.COT_IGV, COT_Descripcion, COT_Estado, " & _
    '"(SELECT C.CLI_RazonSocial FROM tb_clientes C WHERE C.CLI_Codigo=Co.CLI_Codigo) AS Cliente, " & _
    '"(SELECT U.USU_Nombres FROM tb_usuarios U WHERE U.USU_Codigo=Co.USU_Codigo) AS Registro, " & _
    '"(SELECT SUM(Dc.DCOT_Precio * Dc.DCOT_Cant) FROM tb_detalle_cotizaciones Dc WHERE Dc.COT_Codigo=Co.COT_Codigo)AS TotCotizado, " & _
    '"(SELECT SUM(Dc.DCOT_Precio * Dc.DCOT_Cant)*(18/(CONVERT(FLOAT, 100))) FROM tb_detalle_cotizaciones Dc WHERE Dc.COT_Codigo=Co.COT_Codigo)AS TotIGV " & _
    '"FROM tb_cotizaciones Co " & _
    '"WHERE Co.COT_Estado='1'"


    Private Sub MDIPrincipal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        With FrmIGV
            .Top = (Me.Height - .Height) - 175
            .Left = (Me.Width - .Width) - 35
        End With

        'If panelAlerta.Visible Then
        With panelAlerta
            .Top = (Me.Height - .Height) - 72
            .Left = (Me.Width - .Width) - 25
        End With
        'End If
    End Sub

    Private Sub MDIPrincipal_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If e.Cancel = True Then
        Else
            If MsgBox("Desea salir realmente del sistema." & vbNewLine & vbNewLine & _
                      "Antes de cerrar el sistema, confirme que ha guardado toda su información. " & _
                      "De no hacerlo asi se perderá toda la información.", vbQuestion + vbYesNo, "Advertencia") = vbYes Then

                Dim SQLConectado As String = "UPDATE tb_usuarios SET " & _
                                             "USU_Conectado='" & 0 & "' " & _
                                             "WHERE USU_Codigo='" & USU_CODIGO & "'"

                objFunciones.Ejecutar(SQLConectado)
                End
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub mnuCerrarSesion_Click(sender As Object, e As EventArgs) Handles mnuCerrarSesion.Click
        Inicio_Session = False

        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

        Dim SQLConectado As String = "UPDATE tb_usuarios SET " & _
                                     "USU_Conectado='" & 0 & "' " & _
                                     "WHERE USU_Codigo='" & USU_CODIGO & "'"

        objFunciones.Ejecutar(SQLConectado)

        cnn.Close()

        FrmAcceso.Show()
    End Sub

    'BOTONES Y MENUS
    '----------------
    Private Sub cmdUsuario_Click(sender As Object, e As EventArgs)
        FrmRegistroUsuarios.MdiParent = Me
        FrmRegistroUsuarios.Show()
    End Sub

    Private Sub cmdCliente_Click(sender As Object, e As EventArgs) Handles cmdCliente.Click
        FrmRegistroClientes.MdiParent = Me
        FrmRegistroClientes.Show()
    End Sub

    Private Sub cmdFactura_Click(sender As Object, e As EventArgs) Handles cmdFactura.Click
        NOMB_VENTANA_ACTIVA = "Registrar Factura"
        FrmRegistroFactura.cmdRegistrar.Text = "Registrar"
        If objFunciones.estaVentanaAbierta(FrmRegistroFactura) Then
            FrmRegistroFactura.Close()
        End If
        FrmRegistroFactura.picImagen.Image = Image.FromFile(Application.StartupPath & "\Iconos\regFactura.png")
        FrmMoneda.MdiParent = Me
        FrmMoneda.Show()
    End Sub

    Private Sub mnuRegistrarNiveles_Click(sender As Object, e As EventArgs) Handles mnuRegistrarNiveles.Click
        NOMB_VENTANA_ACTIVA = "Niveles"

        If objFunciones.estaVentanaAbierta(FrmNiveles) Then
            FrmNiveles.Close()
        End If

        With FrmNiveles
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub mnuRegistrarUsuario_Click(sender As Object, e As EventArgs) Handles mnuRegistrarUsuario.Click
        FrmRegistroUsuarios.MdiParent = Me
        FrmRegistroUsuarios.Show()
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub mnuRegistroClientes_Click(sender As Object, e As EventArgs) Handles mnuRegistroClientes.Click
        FrmRegistroClientes.MdiParent = Me
        FrmRegistroClientes.Show()
    End Sub

    Private Sub mnuListaClientes_Click(sender As Object, e As EventArgs) Handles mnuListaClientes.Click
        NOMB_VENTANA_ACTIVA = "Cartera de Clientes"
        FrmCarteraClientes.ShowDialog()
    End Sub

    Private Sub mnuGeneraFactura_Click(sender As Object, e As EventArgs) Handles mnuEmitirFactura.Click
        NOMB_VENTANA_ACTIVA = "Emitir Factura"
        FrmRegistroFactura.cmdRegistrar.Text = "Registrar"

        If objFunciones.estaVentanaAbierta(FrmRegistroFactura) Then
            FrmRegistroFactura.Close()
        End If

        FrmRegistroFactura.picImagen.Image = Image.FromFile(Application.StartupPath & "\Iconos\emiFactura.png")
        FrmMoneda.MdiParent = Me
        FrmMoneda.Show()
    End Sub

    Private Sub mnuAnulaFactura_Click(sender As Object, e As EventArgs) Handles mnuAnulaFactura.Click
        FrmAnularFactura.ShowDialog()
    End Sub

    Private Sub mnuIGV_Click(sender As Object, e As EventArgs) Handles mnuIGV.Click
        REG_IGV = "IGV"

        With FrmIGV
            .TopMost = True

            '.MdiParent = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub mnuProvincias_Click(sender As Object, e As EventArgs) Handles mnuProvincias.Click
        FrmRegistroCiudades.ShowDialog()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub mnuBCrearConcepto_Click(sender As Object, e As EventArgs)
        FrmRegistrarConceptos.ShowDialog()
    End Sub

    Private Sub AperturarCajaToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        FrmAperturarCaja.MdiParent = Me
        FrmAperturarCaja.Show()
    End Sub

    Private Sub AperturarCajaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmAperturarCaja.MdiParent = Me
        FrmAperturarCaja.Show()
    End Sub

    Private Sub CierreDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmCambiarContrasena.MdiParent = Me
        FrmCambiarContrasena.Show()
    End Sub

    Private Sub mnuRegistrarConcepto_Click(sender As Object, e As EventArgs) Handles mnuRegistrarConcepto.Click
        FrmRegistrarConceptos.ShowDialog()
    End Sub

    Private Sub mnuListarMovimientos_Click(sender As Object, e As EventArgs)
        'FrmListarMovimientos.panelFiltro.Visible = True
        FrmListaEgresos.ShowDialog()
    End Sub

    Private Sub mnuMovimientosCaja_Click(sender As Object, e As EventArgs)
        NOMB_VENTANA_ACTIVA = "Registrar Movimientos"
    End Sub

    Private Sub mnuBRegistrarConcepto_Click(sender As Object, e As EventArgs)
        FrmRegistrarConceptos.ShowDialog()
    End Sub

    Private Sub mnuBMovCaja_Click(sender As Object, e As EventArgs)
        NOMB_VENTANA_ACTIVA = "Registrar Movimientos"
    End Sub

    Private Sub mnuBListadoDeMovimientos_Click(sender As Object, e As EventArgs)
        'FrmListarMovimientos.panelFiltro.Visible = True
        FrmListaEgresos.ShowDialog()
    End Sub

    Private Sub EstablecerPrivilegiosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        With FrmPermisos
            .lblCodNivelSelec.Text = USU_COD_NIVEL
            .ShowDialog()
        End With
    End Sub

    Private Sub mnuBarraDeEstados_Click(sender As Object, e As EventArgs) Handles mnuBarraDeEstados.Click
        If mnuBarraDeEstados.Checked Then
            My.Settings.verBarEstado = False
            mnuBarraDeEstados.Checked = False
            BarEstado.Visible = False
        Else
            My.Settings.verBarEstado = True
            mnuBarraDeEstados.Checked = True
            BarEstado.Visible = True
        End If

        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub mnuBarraDeHerramimentas_Click(sender As Object, e As EventArgs) Handles mnuBarraDeHerramimentas.Click
        If mnuBarraDeHerramimentas.Checked Then
            My.Settings.verBarHerramientas = False
            mnuBarraDeHerramimentas.Checked = False
            BarHerramienta.Visible = False
        Else
            My.Settings.verBarHerramientas = True
            mnuBarraDeHerramimentas.Checked = True
            BarHerramienta.Visible = True
        End If

        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub mnuCambiarContrasena_Click(sender As Object, e As EventArgs) Handles mnuCambiarContrasena.Click
        FrmCambiarContrasena.MdiParent = Me
        FrmCambiarContrasena.Show()
    End Sub

    Private Sub VerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmListaArchivos.MdiParent = Me
        FrmListaArchivos.Show()
        FrmListaArchivos.Close()
        FrmListaArchivos.MdiParent = Me
        FrmListaArchivos.Show()
    End Sub

    Private Sub mnuRecordatorios_Click(sender As Object, e As EventArgs) Handles mnuRecordatorios.Click
        FrmNotas.ShowDialog()
    End Sub

    Private Sub BmnuRecordatorios_Click(sender As Object, e As EventArgs) Handles BmnuNotas.Click
        FrmNotas.ShowDialog()
    End Sub

    Private Sub tmrFechaHora_Tick(sender As Object, e As EventArgs) Handles tmrFechaHora.Tick
        tsslHora.Text = Format(Now, "H:mm:ss")
        tsslFecha.Text = Format(Now, "dddd, dd 'de' MMMM 'del' yyyy")
    End Sub

    Private Sub tmrRecordatorios_Tick(sender As Object, e As EventArgs) Handles tmrRecordatorios.Tick
        Dim sql_DSM As String
        Dim numRecDiarios As Integer

        sql_DSM = "SELECT * FROM tb_alerta_x_usuarios " & _
                  "WHERE USU_Codigo='" & USU_CODIGO & "' AND " & _
                  "ALERTA_Hora='" & Format(CDate(tsslHora.Text), "H:mm") & "' AND ALERTA_Activo='" & 1 & "'"

        Try
            'ALERTAS DIARIAS, SEMANALES O MENSUALES
            '-----------------------------------------
            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sql_DSM, cnn)
            sqlda.Fill(dt)
            numRecDiarios = dt.Rows.Count

            If numRecDiarios > 0 Then
                SE_ACT = True
                tmrRecordatorios.Stop()
                tmrDesactivar.Start()

                Hora_Programada = Format(CDate(dt.Rows(0).Item("ALERTA_Hora")), "H:mm")
                Fecha_Programada = Format(CDate(dt.Rows(0).Item("ALERTA_Fecha")), "dd/MM/yyyy")

                Frec = CInt(dt.Rows(0).Item("ALERTA_Frecuencia"))
                Desc = CStr(dt.Rows(0).Item("ALERTA_Descripcion"))
                Dom = CBool(dt.Rows(0).Item("ALERTA_Dom"))
                Lun = CBool(dt.Rows(0).Item("ALERTA_Lun"))
                Mar = CBool(dt.Rows(0).Item("ALERTA_Mar"))
                Mie = CBool(dt.Rows(0).Item("ALERTA_Mie"))
                Jue = CBool(dt.Rows(0).Item("ALERTA_Jue"))
                Vie = CBool(dt.Rows(0).Item("ALERTA_Vie"))
                Sab = CBool(dt.Rows(0).Item("ALERTA_Sab"))
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub tmrDesactivar_Tick(sender As Object, e As EventArgs) Handles tmrDesactivar.Tick
        Dim DiaProgramado As String
        Dim DiasSelec As String
        Dim fechaActual, DiaActual As String
        DiasSelec = ""

        Try
            If SE_ACT = True Then
                SE_ACT = False

                DiaProgramado = WeekdayName(Weekday(Fecha_Programada))
                fechaActual = CDate(Format(Now, "dd/MM/yyyy"))
                DiaActual = Format(Now, "dddd")

                lblBienvenida.Text = "Hola! " & StrConv(USU_NOMBRE, VbStrConv.ProperCase)
                lblDescripcion.Text = Desc

                If Frec = 0 Then 'DIAS SELECCIONADOS
                    If fechaActual >= Fecha_Programada Then
                        If (Dom = True And "domingo" = DiaActual) Or
                           (Lun = True And "lunes" = DiaActual) Or
                           (Mar = True And "martes" = DiaActual) Or
                           (Mie = True And "miércoles" = DiaActual) Or
                           (Jue = True And "jueves" = DiaActual) Or
                           (Vie = True And "viernes" = DiaActual) Or
                           (Sab = True And "sábado" = DiaActual) Then

                            If Dom = True Then
                                DiasSelec = DiasSelec & "Dom, "
                            End If

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

                            lblFrecuencia.Text = "Frecuencia : ( " & Mid(Trim(DiasSelec), 1, Len(Trim(DiasSelec)) - 1) & " )"

                            panelAlerta.Visible = True
                            modProcedimientos.playSonido(objFunciones.GetRutaSistema & "\Sonidos\", "Tono_1.WAV")
                        End If
                    End If
                ElseIf Frec = 1 Then ' DIARIAMENTE
                    If fechaActual >= Format(Fecha_Programada, "dd/MM/yyyy") Then
                        panelAlerta.Visible = True
                        lblFrecuencia.Text = "Frecuencia : ( Diariamente )"

                        modProcedimientos.playSonido(objFunciones.GetRutaSistema & "\Sonidos\", "Tono_1.WAV")
                        'modProcedimientos.reproducirTexto(Desc, 100, 0)
                    End If
                ElseIf Frec = 2 Then ' SEMANALMENTE
                    If fechaActual = Fecha_Programada.AddDays(7) Then
                        panelAlerta.Visible = True
                        lblFrecuencia.Text = "Frecuencia : ( Semanalmente )"

                        modProcedimientos.playSonido(objFunciones.GetRutaSistema & "\Sonidos\", "Tono_1.WAV")
                        modProcedimientos.reproducirTexto(Desc, 100, 0)
                    End If
                ElseIf Frec = 3 Then ' MENSUALMENTE
                    If fechaActual = Fecha_Programada.AddDays(30) Then
                        panelAlerta.Visible = True
                        lblFrecuencia.Text = "Frecuencia : ( Mensualmente )"

                        modProcedimientos.playSonido(objFunciones.GetRutaSistema & "\Sonidos\", "Tono_1.WAV")
                        modProcedimientos.reproducirTexto(Desc, 100, 0)
                    End If
                End If
            End If

            If CDate(tsslHora.Text).Second = 0 Then
                tmrRecordatorios.Start()
                tmrDesactivar.Stop()
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub lblCerrar_Click(sender As Object, e As EventArgs) Handles lblCerrar.Click
        panelAlerta.Visible = False
    End Sub

    Private Sub mnuRegistrarProductos_Click(sender As Object, e As EventArgs)
        FrmProductos.MdiParent = Me
        FrmProductos.Show()
    End Sub

    Private Sub mnuMarcasYModelos_Click(sender As Object, e As EventArgs)
        FrmMarcas.ShowDialog()
    End Sub

    'Private Sub mnuBCajaChica_Click(sender As Object, e As EventArgs) Handles mnuBCajaChica.Click
    '    FrmAperturarCaja.MdiParent = Me
    '    FrmAperturarCaja.Show()
    'End Sub

    Private Sub GastosGeneralesYAdministrativosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuGastosGeneralesAdministrativos.Click
        FrmRegistraGasto.MdiParent = Me
        FrmRegistraGasto.Show()
    End Sub

    Private Sub CajaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        NOMB_VENTANA_ACTIVA = "Reporte Egresos"
        FrmReportes.ShowDialog()
    End Sub

    Private Sub mnuUsuariosRegistrados_Click(sender As Object, e As EventArgs) Handles mnuUsuariosRegistrados.Click
        NOMB_VENTANA_ACTIVA = "Usuarios Conectados"
        FrmListaUsuarios.ShowDialog()
    End Sub

    Private Sub mnuListaIngresos_Click(sender As Object, e As EventArgs)
        FrmListaIngresos.ShowDialog()
    End Sub

    Private Sub mnuOperacionesCaja_Click(sender As Object, e As EventArgs) Handles mnuOperacionesCaja.Click
        FrmAperturarCaja.MdiParent = Me
        FrmAperturarCaja.Show()
    End Sub

    Private Sub mnuCatalogoProductos_Click(sender As Object, e As EventArgs) Handles mnuCatalogoProductos.Click
        FrmCatalogoProductos.ShowDialog()
    End Sub

    Private Sub mnuBCatalogoProductos_Click(sender As Object, e As EventArgs) Handles mnuBCatalogoProductos.Click
        FrmCatalogoProductos.ShowDialog()
    End Sub

    Private Sub CámarasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmCamaras.MdiParent = Me
        FrmCamaras.Show()
    End Sub

    Private Sub BmnuDeclararGastos_Click(sender As Object, e As EventArgs) Handles BmnuDeclararGastos.Click
        FrmRegistraGasto.MdiParent = Me
        FrmRegistraGasto.Show()
    End Sub

    Private Sub BmnuListadoCajas_Click(sender As Object, e As EventArgs) Handles BmnuListadoCajas.Click
        FrmAperturarCaja.MdiParent = Me
        FrmAperturarCaja.Show()
    End Sub

    Private Sub mnuBEmitirFactura_Click(sender As Object, e As EventArgs) Handles mnuBEmitirFactura.Click
        NOMB_VENTANA_ACTIVA = "Emitir Factura"
        FrmRegistroFactura.cmdRegistrar.Text = "Registrar"

        If objFunciones.estaVentanaAbierta(FrmRegistroFactura) Then
            FrmRegistroFactura.Close()
        End If

        FrmRegistroFactura.picImagen.Image = Image.FromFile(Application.StartupPath & "\Iconos\emiFactura.png")
        FrmMoneda.MdiParent = Me
        FrmMoneda.Show()
    End Sub

    Private Sub mnuListarFacturasGeneradas_Click(sender As Object, e As EventArgs) Handles mnuListarFacturasGeneradas.Click
        If objFunciones.estaVentanaAbierta(FrmRegistroFactura) Then
            FrmRegistroFactura.Close()
            FrmListaFacturas.ShowDialog()
        Else
            FrmListaFacturas.ShowDialog()
        End If
    End Sub

    Private Sub tsslVersionDispo_Click(sender As Object, e As EventArgs) Handles tsslVersionDispo.Click
        FrmActualizarVersion.ShowDialog()
        'Try
        '    objPDF.descargarInstaladorEn(RUTA_TEMP)

        '    If IO.File.Exists(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION) Then
        '        modProcedimientos.Extraer(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION,
        '                                  RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR)

        '        If IO.File.Exists(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION) Then
        '            Cursor = Cursors.WaitCursor
        '            modProcedimientos.Extraer(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION,
        '                                      RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR)

        '            If IO.File.Exists(RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR & "\setup.exe") Then
        '                Process.Start(RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR & "\setup.exe")
        '                End
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        'End Try
    End Sub

    Private Sub BmnuCalibraciones_Click(sender As Object, e As EventArgs) Handles BmnuCalibraciones.Click
        FrmCalibraciones.MdiParent = Me
        FrmCalibraciones.Show()
    End Sub

    Private Sub mnuCalibraciones_Click(sender As Object, e As EventArgs) Handles mnuCalibraciones.Click
        FrmCalibraciones.MdiParent = Me
        FrmCalibraciones.Show()
    End Sub

    Private Sub mnuVerEstadísticas_Click(sender As Object, e As EventArgs) Handles mnuVerEstadísticas.Click
        FrmEstadisticas.ShowDialog()
    End Sub

    Private Sub mnuAcercade_Click(sender As Object, e As EventArgs) Handles mnuAcercade.Click
        With FrmAcercade
            .MdiParent = Me
            .Show()
        End With

    End Sub

    Private Sub mnuAsignarPermisos_Click(sender As Object, e As EventArgs) Handles mnuAsignarPermisos.Click
        NOMB_VENTANA_ACTIVA = "Permisos"

        If objFunciones.estaVentanaAbierta(FrmNiveles) Then
            FrmNiveles.Close()
        End If

        With FrmNiveles
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub MDIPrincipal_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        'tmrCambios_en_Permisos.Start()

        '----ESTABLECEMOS DATOS GENERALES DEL SISTEMA----
        '------------------------------------------------
        Dia = Format(Now, "dddd")
        lblUsuario.Text = USU_LOGIN
        lblEstado.Text = LCase(USU_NIVEL)
        tsslVersion.Text = "versión " & Application.ProductVersion

        'CARGAR PERMISOS DE USUARIO
        '---------------------------
        modProcedimientos.escanPermisos(BarMenu)
        modProcedimientos.habilitarPermisos(BarHerramienta)

        '-----------------------------------------
        '-----HABILITAR MENU VER-----
        '-----------------------------------------
        If My.Settings.verBarHerramientas Then
            mnuBarraDeHerramimentas.Checked = True
            BarHerramienta.Visible = True
        Else
            mnuBarraDeHerramimentas.Checked = False
            BarHerramienta.Visible = False
        End If

        If My.Settings.verBarEstado Then
            mnuBarraDeEstados.Checked = True
            BarEstado.Visible = True
        Else
            mnuBarraDeEstados.Checked = False
            BarEstado.Visible = False
        End If

        If My.Settings.verListaReq And mnuVisualizarReq.Enabled Then
            mnuRequerimientos.Checked = True
            panelRequerimientos.Visible = True
        Else
            mnuRequerimientos.Checked = False
            panelRequerimientos.Visible = False
        End If

        '----------------------------------------
        '-----OCULTAR BOTONES DE FACTURACION-----
        '----------------------------------------
        If mnuRegistrarFactura.Enabled Then
            cmdFactura.Visible = True
        Else
            cmdFactura.Visible = False
        End If

        If mnuEmitirFactura.Enabled Then
            mnuBEmitirFactura.Visible = True
        Else
            mnuBEmitirFactura.Visible = False
        End If

        If Inicio_Session = True Then
            With FrmAcceso
                .txtUsuario.Text = ""
                .txtContrasena.Text = ""

                .Hide()
            End With
        End If
    End Sub

    Private Sub MDIPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            RUTA_TEMP = Path.GetTempPath()
            CARPETA_DESCARGA_INSTALADOR = "VERSIONES_TEMP"
            VERSION_INSTALADA = My.Application.Info.Version.ToString

            tmrCambios_en_Permisos.Start()

            'tmrReactivar.Stop()
            'tmrSeguimientos.Start()
            'tmrActualizarListaREQ.Start()

            '----ESTABLECEMOS PARAMETROS DE CONFIGURACION----
            '------------------------------------------------
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-PE")
            System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "," '"."
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "." '","
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "," '"."
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "." '","

            With dgvRequerimientos
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                .MultiSelect = False
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Vertical
                .Font = New Font(New FontFamily("Tahoma"), 8, FontStyle.Regular)

            End With

            With dgvCotizados
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                .MultiSelect = False
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Vertical
                .Font = New Font(New FontFamily("Tahoma"), 8, FontStyle.Regular)
            End With

            modProcedimientos.listarRequerimientos(SQLRequerientos, dgvRequerimientos)
            modProcedimientos.listarCotizaciones(SQLCotizaciones, dgvCotizados)
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "(MDIPrincipal, MDIPrincipal_Load)")
        End Try
    End Sub

    Private Sub tmrCambios_en_Permisos_Tick(sender As Object, e As EventArgs) Handles tmrCambios_en_Permisos.Tick
        Try
            'If ESCAN_PERMISOS Then
            '----PRODUCTOS----
            '-----------------
            If mnuRegistrarCategoria.Enabled Then
                FrmCatalogoProductos.cmdNuevaCategoria.Visible = True
            Else
                FrmCatalogoProductos.cmdNuevaCategoria.Visible = False
            End If

            If mnuRegistrarNuevasMarcas.Enabled Then
                FrmProductos.cmdMarcas.Visible = True
                FrmCalibraciones.cmdMarcas.Visible = True
            Else
                FrmProductos.cmdMarcas.Visible = False
                FrmCalibraciones.cmdMarcas.Visible = False
            End If

            With FrmCatalogoProductos
                If mnuAgregarNuevoProducto.Enabled Then
                    .cmdNuevo.Visible = True
                Else
                    .cmdNuevo.Visible = False
                End If

                If mnuEliminarProducto.Enabled Then
                    .cmdEliminar.Visible = True
                Else
                    .cmdEliminar.Visible = False
                End If

                If mnuEditarProductosExistentes.Enabled Then
                    .cmdModificar.Visible = True
                Else
                    .cmdModificar.Visible = False
                End If
            End With

            '----USUARIOS----
            '----------------
            If mnuUsuariosRegistrados.Enabled Then
                mnuUsuariosRegistrados.Visible = True
            Else
                mnuUsuariosRegistrados.Visible = False
            End If

            '----COTIZACIONES----
            '--------------------
            With FrmListaCotizaciones
                If mnuAprobarCotizaciones.Enabled Then
                    .cmdAprobar.Visible = True
                Else
                    .cmdAprobar.Visible = False
                End If

                If mnuModificarCotizaciones.Enabled Then
                    .cmdModificarCot.Enabled = True
                Else
                    .cmdModificarCot.Enabled = False
                End If
            End With

            With FrmRegistrarRequerimiento
                If mnuEliminarRequerimiento.Enabled Then
                    .cmdEliminar.Visible = True
                Else
                    .cmdEliminar.Visible = False
                End If
            End With

            If mnuVisualizarReq.Enabled And mnuRequerimientos.Checked Then
                mnuRequerimientos.Visible = True
                mnuRequerimientos.Checked = True

                tmrActualizarListaREQ.Start()
            ElseIf mnuVisualizarReq.Enabled And mnuRequerimientos.Checked = False Then
                mnuRequerimientos.Visible = True
                mnuRequerimientos.Checked = False

                tmrActualizarListaREQ.Stop()
            Else
                panelRequerimientos.Visible = False
                mnuRequerimientos.Visible = False

                tmrActualizarListaREQ.Stop()
            End If

            My.Settings.Save()
            My.Settings.Reload()

            If mnuActivarAlertasReq.Enabled And EJECUTAR_SEG Then
                HabilitarSeguimiento()
                EJECUTAR_SEG = False
            End If

            '----CAJAS----
            '-------------
            If mnuOperacionesCaja.Enabled Then

            Else
                If objFunciones.estaVentanaAbierta(FrmAperturarCaja) Then
                    FrmAperturarCaja.Close()
                End If
            End If

            If mnuCrearNuevasCajas.Enabled Then
                FrmAperturarCaja.cmdNuevo.Visible = True
            Else
                FrmAperturarCaja.cmdNuevo.Visible = False
            End If

            If mnuRegistrarConcepto.Enabled Then
                FrmRegistrarMovimientos.cmdConceptos.Visible = True
            Else
                If objFunciones.estaVentanaAbierta(FrmRegistrarConceptos) Then
                    FrmRegistrarConceptos.Close()
                End If
                FrmRegistrarMovimientos.cmdConceptos.Visible = False
            End If

            If mnuGastosGeneralesAdministrativos.Enabled Then

            Else
                If objFunciones.estaVentanaAbierta(FrmRegistraGasto) Then
                    FrmRegistraGasto.Close()
                End If
            End If

            'CLIENTES
            '------------
            If mnuProvincias.Enabled Then
                FrmRegistroClientes.cmdAgregar.Enabled = True
            Else
                FrmRegistroClientes.cmdAgregar.Enabled = False
            End If

            If mnuListaClientes.Enabled Then
                FrmRegistroClientes.cmdListarClientes.Visible = True
            Else
                FrmRegistroClientes.cmdListarClientes.Visible = False
            End If

            If mnuEliminarClientesDelSistema.Enabled Then
                FrmRegistroClientes.cmdEliminar.Visible = True
            Else
                FrmRegistroClientes.cmdEliminar.Visible = False
            End If

            'FACTURACION
            '--------------
            If mnuAnulaFactura.Enabled Then
                mnuAnulaFactura.Visible = True
                FrmAnularFactura.cmdAnular.Visible = True
                FrmListaFacturas.cmdAnular.Visible = True
                FrmRegistroFactura.cmdAnularFactura.Visible = True
            Else
                mnuAnulaFactura.Visible = False
                FrmAnularFactura.cmdAnular.Visible = False
                FrmListaFacturas.cmdAnular.Visible = False
                FrmRegistroFactura.cmdAnularFactura.Visible = False
            End If

            If mnuModificarIGV.Enabled Then
                FrmRegistroFactura.cmdIGV.Visible = True
            Else
                FrmRegistroFactura.cmdIGV.Visible = False
            End If

            If mnuListarFacturasGeneradas.Enabled Then
                FrmRegistroFactura.cmdListar.Visible = True
            Else
                FrmRegistroFactura.cmdListar.Visible = False
            End If

            If mnuVerEstadísticas.Enabled Then
                FrmListaFacturas.cmdEstadisticas.Visible = True
            Else
                FrmListaFacturas.cmdEstadisticas.Visible = False
            End If
            'End If

            '===============================================================

            If cnn.State = ConnectionState.Closed Then
                Conectar_Servidor()
            End If

            dt = New Data.DataTable
            sqlda = New SqlDataAdapter(sqlConfigSys, cnn)
            sqlda.Fill(dt)

            IGV = CInt(dt.Rows(0).Item("IGV"))
            IGV_CONFIG = CInt(dt.Rows(0).Item("IGVConfig"))
            ENMANTENIMIENTO = CBool(dt.Rows(0).Item("enMantenimiento"))
            VERSION_DISPO = CStr(dt.Rows(0).Item("versionDisponible").ToString)
            LANZAR_ACTUALIZACION = CBool(dt.Rows(0).Item("activarInstalacion"))
            'REG_MENUS = CBool(dt.Rows(0).Item("activarRegMenus"))
            EXTENSION = Trim(CStr(dt.Rows(0).Item("Extension").ToString))
            ESCAN_PERMISOS = CBool(dt.Rows(0).Item("escanearPermisos").ToString)

            tmrCambios_en_Permisos.Stop()
            'tmrCambios_en_Permisos.Enabled = False

            If ESCAN_PERMISOS Then
                modProcedimientos.escanPermisos(BarMenu)
                modProcedimientos.habilitarPermisos(BarHerramienta)

                objFunciones.Ejecutar("UPDATE tb_configsis SET escanearPermisos='0'")
            End If

            '-------VERIFICAR NUEVA VERSION DISPONIBLE-------
            '------------------------------------------------
            If VERSION_INSTALADA < VERSION_DISPO And INSTALARVERSION Then 'And LANZAR_ACTUALIZACION And INSTALARVERSION Then
                tsslVersionDispo.Visible = True
                tsslVersionDispo.Text = "Versión " & VERSION_DISPO & " disponible (Descargala aqui)"

                FrmActualizarVersion.ShowDialog()
            ElseIf VERSION_INSTALADA < VERSION_DISPO Then
                tsslVersionDispo.Visible = True
            Else
                tsslVersionDispo.Visible = False
            End If

            If ENMANTENIMIENTO = True And ADMISTRA_SISTEM = False Then
                Dim SQLConectado As String = "UPDATE tb_usuarios SET " & _
                                             "USU_Conectado='" & 0 & "' " & _
                                             "WHERE USU_Codigo='" & USU_CODIGO & "'"

                objFunciones.Ejecutar(SQLConectado)
                FrmEnMantenimiento.ShowDialog()
            Else
                If IGV <= 0 Then
                    If MsgBox("El sistema no ha encontrado un valor de igv asignado." & vbNewLine & vbNewLine & _
                              "¿Deseas configurar el valor del igv ahora?", vbQuestion + vbYesNo, "Configurar") = vbYes Then

                        With FrmIGV
                            REG_IGV = "IGV"

                            .ShowDialog()
                        End With
                    Else
                        End
                    End If
                Else
                    'tmrCambios_en_Permisos.Start()
                    'tmrRecordatorios.Start()
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "(MDIPrincipal, tmrCambios_en_Permisos_Tick())")
        End Try
    End Sub

    Private Sub mnuDatosDeLaEmpresa_Click(sender As Object, e As EventArgs) Handles mnuDatosDeLaEmpresa.Click
        FrmConfigEmpresa.MdiParent = Me
        FrmConfigEmpresa.Show()
    End Sub

    Private Sub mnuProgramarDatosDeActualización_Click(sender As Object, e As EventArgs) Handles mnuProgramarDatosDeActualización.Click
        FrmConfigActualizaSistema.MdiParent = Me
        FrmConfigActualizaSistema.Show()
    End Sub

    Private Sub mnuProgramarMantenimientoDelSistema_Click(sender As Object, e As EventArgs) Handles mnuProgramarMantenimientoDelSistema.Click
        FrmConfigMantenimiento.MdiParent = Me
        FrmConfigMantenimiento.Show()
    End Sub

    Private Sub cmdSeguimiento_Click(sender As Object, e As EventArgs)
        With FrmRegistrarRequerimiento
            .chkActivar.Checked = True

            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub dgvRequerimientos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequerimientos.CellDoubleClick
        Dim sqlDatosRequerimiento As String
        Dim fila, numReg As Integer
        Dim IDRequerim, Tipo As String

        'CARGAR DETALLE REQUERIM
        '--------------------------------
        Try
            If Not IsNothing(dgvRequerimientos.CurrentRow) And e.RowIndex >= 0 Then
                fila = CInt(dgvRequerimientos.CurrentRow.Index)
                IDRequerim = dgvRequerimientos.Item(0, fila).Value

                sqlDatosRequerimiento =
                "SELECT R.REQ_Codigo, R.REQ_Tipo, R.REQ_Fecha, R.REQ_Descripcion, C.CLI_Codigo, " & _
                "R.REQ_Estado, R.REQ_Estado, C.CLI_RazonSocial, R.REQ_Observacion, " & _
                "ISNULL(R.REQ_FechaSeg, '01/01/1900') AS REQ_FechaSeg, U.USU_Nombres " & _
                "FROM tb_requerimientos R, tb_usuarios U, tb_clientes C " & _
                "WHERE U.USU_Codigo=R.USU_Codigo AND " & _
                "R.CLI_Codigo=C.CLI_Codigo AND R.REQ_Estado='0' AND " & _
                "R.REQ_Codigo='" & IDRequerim & "' " & _
                "ORDER BY R.REQ_FechaSeg ASC"

                dtaux = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlDatosRequerimiento, cnn)
                sqlda.Fill(dtaux)

                numReg = dtaux.Rows.Count

                If numReg > 0 Then
                    With FrmRegistrarRequerimiento
                        .lblIDReq.Text = CStr(Trim(dtaux.Rows(0).Item("REQ_Codigo")))
                        .lblIDCliente.Text = CStr(Trim(dtaux.Rows(0).Item("CLI_Codigo")))
                        .txtCliente.Text = CStr(dtaux.Rows(0).Item("CLI_RazonSocial"))
                        .txtDescripcion.Text = CStr(dtaux.Rows(0).Item("REQ_Descripcion").ToString)
                        .txtObservacion.Text = CStr(dtaux.Rows(0).Item("REQ_Observacion").ToString)
                        .lblFechaReq.Text = Format(dtaux.Rows(0).Item("REQ_Fecha"), "dd/MM/yyyy")

                        Tipo = CStr(dtaux.Rows(0).Item("REQ_Tipo"))

                        If dtaux.Rows(0).Item("REQ_FechaSeg") = "01/01/1900" Then
                            .dtpFecha.Value = Format(Now, "dd/MM/yyyy")
                        Else
                            .dtpFecha.Value = Format(Now, dtaux.Rows(0).Item("REQ_FechaSeg"))
                        End If

                        If Tipo = "B" Then
                            .opt_B.Checked = True
                        ElseIf Tipo = "C" Then
                            .opt_C.Checked = True
                        End If

                        .chkActivar.Checked = True
                        .txtDescripcion.Enabled = True
                        .chkActivar.Visible = True
                        .cmdNuevo.Visible = False
                        .cmdEliminar.Visible = True
                        .cmdRegistrar.Text = "Modificar"

                        .dgvListaClientes.Visible = False

                        .MdiParent = Me
                        .Show()
                    End With
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "(MDIPrincipal, dgvRequerimientos_CellDoubleClick)")
        End Try
    End Sub

    'Private Sub tmrSeguimientos_Tick(sender As Object, e As EventArgs) Handles tmrSeguimientos.Tick
    Private Sub HabilitarSeguimiento()
        Dim Desc, Clie, Obs As String
        Dim numReq, P, Nuev_Pos As Integer
        Dim Pos_Inic As Integer = Me.Height - 38 '(Me.Height + BarEstado.Height) '- 20

        Dim SQLSegRequerim As String =
        "SELECT R.REQ_Codigo, R.REQ_Fecha, R.REQ_Descripcion, R.REQ_Observacion, " & _
        "R.REQ_Estado, R.REQ_Estado, C.CLI_RazonSocial, " & _
        "ISNULL(R.REQ_FechaSeg, '01/01/1900') AS REQ_FechaSeg, U.USU_Nombres " & _
        "FROM tb_requerimientos R, tb_usuarios U, tb_clientes C " & _
        "WHERE REQ_FechaSeg='" & Format(Now, "dd/MM/yyyy") & "' AND " & _
        "U.USU_Codigo = R.USU_Codigo AND " & _
        "R.CLI_Codigo=C.CLI_Codigo AND R.REQ_Estado='0' " & _
        "ORDER BY R.REQ_FechaSeg ASC"

        If cnn.State = ConnectionState.Closed Then
            Conectar_Servidor()
        End If

        dt = New Data.DataTable
        sqlda = New SqlDataAdapter(SQLSegRequerim, cnn)
        sqlda.Fill(dt)
        numReq = dt.Rows.Count

        If numReq > 0 Then
            If numReq <= 4 Then
                For i = 0 To numReq - 1
                    Clie = CStr(dt.Rows(i).Item("CLI_RazonSocial"))
                    Desc = CStr(dt.Rows(i).Item("REQ_Descripcion").ToString)
                    Obs = CStr(dt.Rows(i).Item("REQ_Observacion").ToString)

                    Dim Avisos As New FrmAlertas

                    With Avisos
                        .lblCliente.Text = Clie

                        If Desc = "" Or IsNothing(Desc) Then
                            .lblDescSeguim.Text = Obs
                        Else
                            .lblDescSeguim.Text = Desc
                        End If

                        .Visible = True
                        .TopMost = True
                        .Top = Pos_Inic
                        .Left = 5 '(Me.Width - .Width) - 30

                        Nuev_Pos = (Pos_Inic + .Height) + 20

                        For P = Pos_Inic + 15 To Nuev_Pos
                            Pos_Inic -= 1
                            .Top = Pos_Inic
                        Next

                        Nuev_Pos += .Height - 15
                    End With
                Next
            Else
                Dim Avisos As New FrmAlertas

                With Avisos
                    .lblCliente.Text = "Tiene ( " & numReq & " ) nuevas visitas pendientes para hoy"
                    .lblDescSeguim.Text = "Revise la lista del lado derecho de la pantalla " & _
                                          "principal del sistema. " & vbNewLine & vbNewLine & _
                                          "Los marcador de color azul son sus visitas programadas."

                    .Visible = True
                    .TopMost = True
                    .Top = Pos_Inic
                    .Left = 5 '(Me.Width - .Width) - 30

                    Nuev_Pos = (Pos_Inic + .Height) + 20

                    For P = Pos_Inic + 15 To Nuev_Pos
                        Pos_Inic -= 1
                        .Top = Pos_Inic
                    Next

                    Nuev_Pos += .Height - 15
                End With
            End If
        End If
    End Sub

    Private Sub tmrReactivar_Tick(sender As Object, e As EventArgs) Handles tmrReactivar.Tick
        cont += 1

        If cont = 300 Then '15 min
            'tmrSeguimientos.Start()
            HabilitarSeguimiento()
        End If
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        With FrmRegistrarRequerimiento
            .txtCliente.Enabled = False
            .cmdRegistrar.Enabled = False

            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            panelporCotizar.Visible = True
            panelCotizaciones.Visible = False
            panelEstado.Visible = True
            lblEst.Visible = True
        ElseIf TabControl1.SelectedIndex = 1 Then
            panelporCotizar.Visible = False
            panelCotizaciones.Visible = True
            panelEstado.Visible = False
            lblEst.Visible = False
        End If
    End Sub

    Private Sub dgvRequerimientos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequerimientos.CellEnter
        Dim fila As Integer
        Dim Fecha As Date
        Dim FechaActual As Date

        'CARGAR DETALLE REQUERIM
        '--------------------------------
        Try
            If Not IsNothing(dgvRequerimientos.CurrentRow) And e.RowIndex >= 0 Then
                fila = CInt(dgvRequerimientos.CurrentRow.Index)
                filaSelecReq = fila
                Fecha = CDate(dgvRequerimientos.Item(3, fila).Value)
                FechaActual = Format(Now, "dd/MM/yyyy")

                With dgvRequerimientos
                    If Fecha = "01/01/1900" Then
                        lblEst.Text = "PENDIENTES..."
                        panelEstado.BackColor = Color.FromArgb(255, 250, 240)

                        .Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                        .Item(2, e.RowIndex).Style.SelectionForeColor = Color.SlateGray 'Color.FromArgb(245, 245, 245)
                    ElseIf Fecha > FechaActual Then
                        lblEst.Text = "PROXIMOS"
                        panelEstado.BackColor = Color.FromArgb(239, 243, 244)

                        .Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                        .Item(2, e.RowIndex).Style.SelectionForeColor = Color.FromArgb(94, 158, 160)
                    ElseIf Fecha < FechaActual Then
                        lblEst.Text = "PASADAS"
                        panelEstado.BackColor = Color.FromArgb(220, 20, 59)

                        .Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                        .Item(2, e.RowIndex).Style.SelectionForeColor = Color.FromArgb(250, 240, 230)
                    ElseIf Fecha = FechaActual Then
                        lblEst.Text = "PARA HOY"
                        panelEstado.BackColor = Color.FromArgb(135, 206, 235)

                        .Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                        .Item(2, e.RowIndex).Style.SelectionForeColor = Color.FromArgb(252, 245, 229)
                    End If
                End With
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "MDIPrincipal")
        End Try
    End Sub

    Private Sub dgvRequerimientos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRequerimientos.CellFormatting

        e.CellStyle.SelectionBackColor = dgvRequerimientos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor
    End Sub

    Private Sub dgvRequerimientos_Resize(sender As Object, e As EventArgs) Handles dgvRequerimientos.Resize
        With dgvRequerimientos
            Dim ancho As Integer = .Width - 20

            .Columns(1).Width = (ancho * 12) / 100
            .Columns(2).Width = (ancho * 88) / 100
        End With
    End Sub

    Private Sub cmdCotizar_Click(sender As Object, e As EventArgs) Handles cmdCotizar.Click
        Dim numReg As Integer
        Dim IDRequerim As String
        NOMB_VENTANA_ACTIVA = "Guardar proforma "

        With FrmProforma
            If dgvRequerimientos.Rows.Count > 0 Then
                IDRequerim = Trim(dgvRequerimientos.Item(0, filaSelecReq).Value)


                Dim SQLSegRequerim As String =
                "SELECT R.REQ_Codigo, R.REQ_Fecha, R.REQ_Descripcion, C.CLI_Codigo, " & _
                "R.REQ_Estado, R.REQ_Estado, C.CLI_RazonSocial, R.REQ_Observacion, " & _
                "ISNULL(R.REQ_FechaSeg, '01/01/1900') AS REQ_FechaSeg, U.USU_Nombres " & _
                "FROM tb_requerimientos R, tb_usuarios U, tb_clientes C " & _
                "WHERE U.USU_Codigo=R.USU_Codigo AND " & _
                "R.CLI_Codigo=C.CLI_Codigo AND R.REQ_Estado='0' AND " & _
                "R.REQ_Codigo='" & IDRequerim & "' " & _
                "ORDER BY R.REQ_FechaSeg ASC"

                dtaux = New Data.DataTable
                sqlda = New SqlDataAdapter(SQLSegRequerim, cnn)
                sqlda.Fill(dtaux)

                numReg = dtaux.Rows.Count

                If numReg > 0 Then
                    .lblIDReq.Text = IDRequerim
                    .lblIDCliente.Text = CStr(dtaux.Rows(0).Item("CLI_Codigo"))
                    .txtCliente.Text = CStr(dtaux.Rows(0).Item("CLI_RazonSocial"))
                    .dgvListaClientes.Visible = False
                    .txtDescripcion.Text = CStr(dtaux.Rows(0).Item("REQ_Descripcion").ToString)
                End If

                .MdiParent = Me
                .Show()
            End If
        End With

    End Sub

    Private Sub tmrActualizarListaREQ_Tick(sender As Object, e As EventArgs) Handles tmrActualizarListaREQ.Tick
        cont_REQ += 1

        If cont_REQ = 300 Then '5 min
            modProcedimientos.listarRequerimientos(SQLRequerientos, dgvRequerimientos)
            modProcedimientos.listarCotizaciones(SQLCotizaciones, dgvCotizados)
            cont_REQ = 0
        End If
    End Sub

    Private Sub cmdRefrescar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        modProcedimientos.listarRequerimientos(SQLRequerientos, dgvRequerimientos)
        modProcedimientos.listarCotizaciones(SQLCotizaciones, dgvCotizados)
    End Sub

    Private Sub dgvCotizados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCotizados.CellDoubleClick
        Dim SQLCotizaciones, IDCotizacion As String

        With dgvCotizados
            IDCotizacion = .Item(0, filaSelecCot).Value

            With FrmListaCotizaciones

                SQLCotizaciones =
                "SELECT Co.COT_Codigo, Co.COT_Fecha, Co.COT_Descripcion, Co.COT_Moneda, Co.COT_Importe, " & _
                "(Co.COT_Importe * (CAST(Co.COT_IGV AS FLOAT) / 100)) AS ImporteIGV, " & _
                "Co.COT_CONIGV, Co.COT_CONINST, U.USU_Nombres, Co.COT_estado " & _
                "FROM tb_cotizaciones Co, tb_usuarios U " & _
                "WHERE Co.USU_Codigo=U.USU_Codigo AND " & _
                "SUBSTRING(Co.COT_Codigo, 1, 8)='" & IDCotizacion & "'"

                modProcedimientos.listarTodasCotizaciones(SQLCotizaciones, .dgvCotizaciones)

                .MdiParent = Me
                .Show()
            End With
        End With
    End Sub

    Private Sub dgvCotizados_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCotizados.CellFormatting
        e.CellStyle.SelectionBackColor = dgvCotizados.Item(e.ColumnIndex, e.RowIndex).Style.BackColor
    End Sub

    Private Sub dgvCotizados_Resize(sender As Object, e As EventArgs) Handles dgvCotizados.Resize
        With dgvCotizados
            Dim ancho As Integer = .Width - 20

            .Columns(1).Width = (ancho * 12) / 100
            .Columns(2).Width = (ancho * 88) / 100
        End With
    End Sub

    Private Sub GenerarRequerimiento_Click(sender As Object, e As EventArgs) Handles GenerarRequerimiento.Click
        FrmRegistrarRequerimiento.MdiParent = Me
        FrmRegistrarRequerimiento.Show()
    End Sub

    Private Sub mnuGenerarCotizacion_Click(sender As Object, e As EventArgs) Handles mnuGenerarCotizacion.Click
        NOMB_VENTANA_ACTIVA = "Guardar proforma "
        FrmProforma.MdiParent = Me
        FrmProforma.Show()
    End Sub

    Private Sub dgvCotizados_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCotizados.CellEnter
        Dim fila As Integer
        Dim Fecha As Date
        Dim FechaActual As Date

        'CARGAR DETALLE REQUERIM
        '--------------------------------
        Try
            With dgvCotizados
                If Not IsNothing(.CurrentRow) And e.RowIndex >= 0 Then
                    fila = CInt(.CurrentRow.Index)
                    filaSelecCot = fila
                    'Fecha = CDate(dgvRequerimientos.Item(3, fila).Value)
                    'FechaActual = Format(Now, "dd/MM/yyyy")


                    'If Fecha = "01/01/1900" Then
                    'lblEst.Text = "PENDIENTES..."
                    'panelEstado.BackColor = Color.FromArgb(255, 250, 240)

                    '.Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                    '.Item(2, e.RowIndex).Style.SelectionForeColor = Color.SlateGray 'Color.FromArgb(245, 245, 245)
                    'ElseIf Fecha > FechaActual Then
                    'lblEst.Text = "EN ESPERA..."
                    'panelEstado.BackColor = Color.FromArgb(244, 237, 227)

                    .Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                    .Item(2, e.RowIndex).Style.SelectionForeColor = Color.FromArgb(173, 244, 214)
                    'ElseIf Fecha < FechaActual Then
                    'lblEst.Text = "PASADAS"
                    'panelEstado.BackColor = Color.FromArgb(220, 20, 59)

                    '.Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                    '.Item(2, e.RowIndex).Style.SelectionForeColor = Color.FromArgb(250, 240, 230)
                    'ElseIf Fecha = FechaActual Then
                    'lblEst.Text = "PARA HOY"
                    'panelEstado.BackColor = Color.FromArgb(135, 206, 235)

                    '.Item(1, e.RowIndex).Style.SelectionForeColor = Color.White
                    '.Item(2, e.RowIndex).Style.SelectionForeColor = Color.FromArgb(252, 245, 229)
                    'End If
                End If
            End With
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "MDIPrincipal")
        End Try
    End Sub

    Private Sub mnuRequerimientos_Click(sender As Object, e As EventArgs) Handles mnuRequerimientos.Click
        If mnuRequerimientos.Checked Then
            My.Settings.verListaReq = False
            mnuRequerimientos.Checked = False

            panelRequerimientos.Visible = False
        Else
            My.Settings.verListaReq = True
            mnuRequerimientos.Checked = True

            panelRequerimientos.Visible = True
        End If

        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub mnuListaDeCotizaciones_Click(sender As Object, e As EventArgs) Handles mnuListaDeCotizaciones.Click
        With FrmListaCotizaciones
            .MdiParent = Me
            .Show()

            .chkTodas.Checked = True
        End With
    End Sub

    Private Sub mnuSoftwares_Click(sender As Object, e As EventArgs) Handles mnuSoftwares.Click
        FrmAsistenciaTecnica.ShowDialog()
    End Sub

    Private Sub BmnuSoftwares_Click(sender As Object, e As EventArgs) Handles BmnuSoftwares.Click
        FrmAsistenciaTecnica.ShowDialog()
    End Sub

    Private Sub IngresarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarToolStripMenuItem.Click
        NOMB_VENTANA_ACTIVA = "Registrar Permisos"

        If objFunciones.estaVentanaAbierta(FrmPermisos) Or objFunciones.estaVentanaAbierta(FrmNiveles) Then
            FrmNiveles.Close()
            FrmPermisos.Close()
        End If

        With FrmRegistrarPermiso
            .MdiParent = Me
            .Show()
        End With
    End Sub

    
    Private Sub mnuBEntrada_Click(sender As Object, e As EventArgs) Handles mnuBEntrada.Click

    End Sub

   

  

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles mnuIngresoEquipos.Click
        Form1.MdiParent = Me
        Form1.Show()


    End Sub
End Class
