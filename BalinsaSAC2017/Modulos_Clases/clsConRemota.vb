Imports System
Imports System.Management

Public Class clsConRemota
    'Public Function getPropiedad(ByVal propiedad As String, Optional tipo As String = "OperatingSystem") As String
    'Dim valorPropiedad As String = ""

    'Dim objMgmt As New Management.ManagementObject
    'Dim objMOS As Management.ManagementObjectSearcher

    '    Try
    '        objMOS = New Management.ManagementObjectSearcher("SELECT " & propiedad & " FROM Win32_" & tipo)
    '        For Each objMgmt In objMOS.Get
    '            valorPropiedad = objMgmt.Item(propiedad).ToString()
    '        Next
    '    Catch ex As Management.ManagementException
    '        Select Case ex.ErrorCode.ToString
    '            Case "InvalidClass"
    '                MsgBox("Se requiere un tipo valido")
    '            Case "InvalidQuery"
    '                MsgBox("Se requiere una propiedad valida")
    '            Case Else
    '                MsgBox("Error de Consulta Inesperado")
    '        End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " " & ex.GetType().ToString)
    '    End Try

    '    Return valorPropiedad
    'End Function

    'tuModulo.getPropiedad("Workgroup","ComputerSystem")

End Class

