Public Class FrmActualizarVersion
    Private Sub FrmActualizarVersion_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        INSTALARVERSION = False
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        INSTALARVERSION = False
        Me.Close()
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        MDIPrincipal.Cursor = Cursors.WaitCursor

        If EXTENSION = ".zip" And LANZAR_ACTUALIZACION Then
            objPDF.descargarInstaladorEn(RUTA_TEMP)

            If IO.File.Exists(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION) Then
                modProcedimientos.Extraer(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION,
                                          RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR)

                If IO.File.Exists(RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR & "\setup.exe") Then
                    Process.Start(RUTA_TEMP & CARPETA_DESCARGA_INSTALADOR & "\setup.exe")
                    End
                End If
            End If
            'LANZAR_ACTUALIZACION = False
        ElseIf EXTENSION = ".exe" And LANZAR_ACTUALIZACION Then
            objPDF.descargarInstaladorEn(RUTA_TEMP)

            If IO.File.Exists(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION) Then
                Process.Start(RUTA_TEMP & "instalador " & VERSION_DISPO & EXTENSION)
                End
            End If
            'LANZAR_ACTUALIZACION = False
            'Else
            'LANZAR_ACTUALIZACION = False
        End If
    End Sub

    Private Sub FrmActualizarVersion_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        With MDIPrincipal
            Me.Top = .Height - (Me.Height + 20)
            Me.Left = .Width - (Me.Width + 20)
        End With

    End Sub

    Private Sub FrmActualizarVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblversDispo.Text = "versión " & VERSION_DISPO
    End Sub
End Class