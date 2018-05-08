Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Font
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Text

Public Class clsCODBarras

    Public Function llenarFuentes(ByVal directorioFuentes As String, ByVal Combo As ComboBox)
        Dim Directorio As DirectoryInfo
        Dim Archivo As FileInfo()

        Try
            Directorio = New DirectoryInfo(directorioFuentes)

            If (Directorio.Exists) Then

                Archivo = Directorio.GetFiles()

                For Each fuentes As FileInfo In Archivo
                    If fuentes.Extension = ".TTF" Or fuentes.Extension = ".ttf" Then
                        Combo.Items.Add(fuentes.Name)
                    End If
                Next

                Combo.SelectedIndex = 0 'Fuente por default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return True
    End Function

    Public Function getFuente(ByVal directorioFuentes As String, ByVal Tamanio As Integer,
                              ByVal strFuente As String) As Font

        'Dim pfc As PrivateFontCollection = New PrivateFontCollection()
        'Dim fontFamily As FontFamily
        Dim Fuente As Font

        Dim pfc As New PrivateFontCollection
        Dim familia As FontFamily

        Try
            pfc.AddFontFile(directorioFuentes & "\" & strFuente)
            familia = pfc.Families(0)

            Fuente = New Font(familia, Tamanio)

            'Label1.Font = Fuente
            'pfc.AddFontFile(directorioFuentes & "\" & strFuente)
            'fontFamily = pfc.Families(0)

            'Fuente = New Font(fontFamily, Tamanio)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

        Return Fuente
    End Function

    Public Function FormatoCodigoBarras(ByVal code As String) As String
        Dim barcode As String = String.Empty

        Try
            barcode = String.Format("{0}", code)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

        Return barcode
    End Function
End Class
