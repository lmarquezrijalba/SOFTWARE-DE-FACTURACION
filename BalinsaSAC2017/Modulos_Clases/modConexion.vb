Imports System.Data.SqlClient
'Imports MySql.Data.MySqlClient

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module modConexion

    Public Inicio_Session As Boolean = False

    Public cnn As New SqlConnection
    'Public cnnMySQL As New MySqlConnection
    Public cnnInfo As New ConnectionInfo

    Public sqldr As SqlDataReader
    Public sqlcmd As SqlCommand
    Public sqlda As SqlDataAdapter
    Public dt As DataTable : Public dtaux As DataTable
    Public ds As DataSet

    '   DATOS DEL SERVIDOR
    '-------------------------------------
    Dim ruta As String = objFunciones.GetRutaSistema
    Public rutaConfig As String = System.AppDomain.CurrentDomain.BaseDirectory() & "Boot.INI"
    'objFunciones.GetRutaSistema & "\Configuracion.ini"
    Public Archivo_Ini As New clsArchivosINI(rutaConfig)

    'Public SERVIDOR, BASEDATOS, USUARIO_BD, PASSWORD As String
    'Public INTEGRIDAD_REF As Boolean

    '   DATOS DE PARAMETROS
    '---------------------------------------
    'Public VALOR_IGV As Integer

    '****************************************
    'DATOS DEL CONFIGURACION DEL SERVIDOR
    '****************************************
    Public SERVIDOR As String : Public BASE_DATOS As String
    Public USUARIO_BD As String : Public PASS As String

    '   DATOS DEL USUARIO CONECTADO
    '-------------------------------------
    Public USU_CODIGO, USU_NOMBRE_LARGO, USU_NOMBRE,
           USU_LOGIN, USU_CONTRASENA, USU_COD_NIVEL, USU_NIVEL As String
    Public IDENT_NIVEL As Integer
    Public ADMISTRA_SISTEM As Boolean
    Public IGV As Integer : Public IGV_CONFIG As String
    Public ENMANTENIMIENTO As Boolean
    Public VERSION_INSTALADA As String
    Public VERSION_DISPO As String
    Public CARPETA_DESCARGA_INSTALADOR As String
    Public RUTA_MISDOCUMENTOS As String
    Public LANZAR_ACTUALIZACION As Boolean
    Public ESCAN_PERMISOS As Boolean

    Public NOMB_PC_CLIENTE As String
    Public NOMB_USER_CLIENTE As String


    Public REG_IGV As String
    ''CONEXION REMOTA
    ''**************************************************************************************************
    ''Shell("cmd.exe /k NET USE \\Servidor\RecursoCompartido /user:Dominio\usuario password")
    ''Public RECURSOCOMPARTIDO As String : Public DOMINIO_USUARIO As String
    'Public RUTA_INSTALADOR As String
    'Public ARCHIVO_ZIP As String

    ''Public PC_SERVIDOR As String : Public PC_SERV_USU As String : Public PC_SERV_PASS As String
    Public INSTALARVERSION As Boolean = True
    ''**************************************************************************************************

    Public Function verificarConexion(ByVal strConexion As String) As Boolean
        Try
            cnn.ConnectionString = strConexion

            Using cnn
                cnn.Open()
            End Using
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, "modConexion")

            Return False
        End Try

        Return True
    End Function

    Public Sub Conectar_Servidor()
        Dim cadConexion As String = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "strConexion", ""))

        Try
            cnn.ConnectionString = cadConexion

            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error al conectarse")
        End Try
    End Sub

    'Public Sub Conectar_Servidor_MySQL()
    'Dim cadConexion As String
    '    cadConexion = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "strConexion", ""))

    '    Try
    '        cnnMySQL.ConnectionString = cadConexion

    '        If Not cnnMySQL.State = ConnectionState.Open Then
    '            cnnMySQL.Open()
    '        End If

    ''cnnMySQL = New MySqlConnection()
    ''cnnMySQL.ConnectionString =
    ''    "server=" & txtServidor.Text & ";" &
    ''    "user id=" & txtUsuario.Text & ";" &
    ''    "password=" & txtContrasena.Text & ";" &
    ''    "port=" & txtPuerto.Text & ";" &
    ''    "database=" & lsBD.Text & ";"

    ''cnnMySQL.Open()

    ''If lsBD.Text <> "" Then
    ''bePanelNumTablas.Text = CStr(numeroTablas())
    ''End If
    ''bePanel2.Text = "Conectado a servidor " &
    ''txtServidor.Text()
    '    Catch ex As Exception
    '        MsgBox("Error al conectar al servidor MySQL " &
    '               vbCrLf & vbCrLf & ex.Message,
    '               MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    Private Sub Conectar_Serv_CR()
        cnnInfo.ServerName = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "Servidor", ""))
        cnnInfo.DatabaseName = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "BaseDatos", ""))
        cnnInfo.UserID = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "Usuario", ""))
        cnnInfo.Password = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "Password", ""))
        cnnInfo.IntegratedSecurity = objEncriptacion.DesEncripta(Archivo_Ini.ObtenerString("Conexion Servidor", "IntSecurity", ""))
    End Sub

    Public Sub Conectar_DBLogon(ByVal ConnectionInfo As ConnectionInfo, ByVal ReportDocument As ReportDocument)
        Conectar_Serv_CR()

        Dim myTables As Tables = ReportDocument.Database.Tables

        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = ConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub
End Module
