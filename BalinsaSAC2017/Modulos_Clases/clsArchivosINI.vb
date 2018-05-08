Public Class clsArchivosINI
    ' Funciones del API de Windows para ficheros INI
    Private Declare Ansi Function GetPrivateProfileString _
      Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpDefault As String, _
      ByVal lpReturnedString As System.Text.StringBuilder, _
      ByVal nSize As Integer, ByVal lpFileName As String) _
      As Integer

    Private Declare Ansi Function WritePrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpString As String, _
      ByVal lpFileName As String) As Integer

    Private Declare Ansi Function GetPrivateProfileInt _
      Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal nDefault As Integer, _
      ByVal lpFileName As String) As Integer

    Private Declare Ansi Function FlushPrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As Integer, _
      ByVal lpKeyName As Integer, ByVal lpString As Integer, _
      ByVal lpFileName As String) As Integer

    Dim strFilename As String

    ' Constructor, para aceptar el fichero INI
    Public Sub New(ByVal Filename As String)
        strFilename = Filename
    End Sub

    ''Propiedad sólo lectura con nombre de fichero
    'ReadOnly Property FileName() As String
    '    Get
    '        Return strFilename
    '    End Get
    'End Property

    'Función para leer cadena de texto (string) de fichero INI
    Public Function ObtenerString(ByVal Section As String, _
      ByVal Key As String, ByVal [Default] As String) As String
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)

        intCharCount = GetPrivateProfileString(Section, Key, _
           [Default], objResult, objResult.Capacity, strFilename)
        If intCharCount > 0 Then
            ObtenerString = Left(objResult.ToString, intCharCount)
        Else
            ObtenerString = ""
        End If
    End Function

    'Función para leer un valor numérico del fichero INI
    Public Function ObtenerInteger(ByVal Section As String, _
      ByVal Key As String, ByVal [Default] As Integer) As Integer
        Return GetPrivateProfileInt(Section, Key, _
           [Default], strFilename)
    End Function

    'Función para leer un valor booleano de fichero INI
    Public Function ObtenerBoolean(ByVal Section As String, _
      ByVal Key As String, ByVal [Default] As Boolean) As Boolean
        Return (GetPrivateProfileInt(Section, Key, _
           CInt([Default]), strFilename) = 1)
    End Function

    'Función para escribir valor de cadena (string) en fichero INI
    Public Sub EscribirString(ByVal Section As String, _
      ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, strFilename)
        Flush()
    End Sub

    'Función para escribir valor numérico en fichero INI
    Public Sub EscribirInteger(ByVal Section As String, _
      ByVal Key As String, ByVal Value As Integer)
        ' Writes an integer to your INI file
        EscribirString(Section, Key, CStr(Value))
        Flush()
    End Sub

    'Función para escribir valor booleano en fichero INI
    Public Sub EscribirBoolean(ByVal Section As String, _
    ByVal Key As String, ByVal Value As Boolean)
        ' Writes a boolean to your INI file
        EscribirString(Section, Key, CStr(Math.Abs(CInt(Value))))
        Flush()
    End Sub

    'Guarda los cambios de la caché en fichero INI
    Private Sub Flush()
        FlushPrivateProfileString(0, 0, 0, strFilename)
    End Sub
End Class
