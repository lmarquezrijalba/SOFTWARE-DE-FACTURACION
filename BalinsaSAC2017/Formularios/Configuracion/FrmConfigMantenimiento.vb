Public Class FrmConfigMantenimiento

    Dim rutaStart As String = Application.StartupPath & "\Iconos\start.png"
    Dim rutaStop As String = Application.StartupPath & "\Iconos\stop.png"

 
    Private Sub FrmConfigMantenimiento_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If enMantenimiento = True Then
            cmdIniciar.Text = "Detener proceso"
            cmdIniciar.Image = Image.FromFile(rutaStop)
        Else
            cmdIniciar.Text = "Iniciar proceso  "
            cmdIniciar.Image = Image.FromFile(rutaStart)
        End If
    End Sub

    Private Sub cmdIniciar_Click(sender As Object, e As EventArgs) Handles cmdIniciar.Click
        Dim sqlInicia, sqlDetiene, sqlAsignar As String

        sqlInicia = "UPDATE tb_configsis SET " & _
                    "enMantenimiento='" & 1 & "' " & _
                    "WHERE ID='UNICO'"

        sqlDetiene = "UPDATE tb_configsis SET " & _
                     "enMantenimiento='" & 0 & "' " & _
                     "WHERE ID='UNICO'"

        'sqlAsignar = "UPDATE tb_configsis SET " & _
        '             "activarRegMenus='" & chkRegMenues.Checked & "' " & _
        '             "WHERE ID='UNICO'"

        If enMantenimiento = True Then
            If objFunciones.Ejecutar(sqlDetiene) Then
                cmdIniciar.Text = "Iniciar proceso  "
                cmdIniciar.Image = Image.FromFile(rutaStart)
            End If
        Else
            If objFunciones.Ejecutar(sqlInicia) Then
                cmdIniciar.Text = "Detener proceso"
                cmdIniciar.Image = Image.FromFile(rutaStop)
            End If
        End If

        If chkRegMenues.Checked = True Then
            'objFunciones.Ejecutar(sqlAsignar)

            '---REGISTRAMOS MENUS DEL SISTEMA----
            '------------------------------------
            objFunciones.Ejecutar("DELETE tb_permisos")
            modProcedimientos.escanItemsMenu(MDIPrincipal.BarMenu)

            'objFunciones.Ejecutar("UPDATE tb_configsis SET activarRegMenus='0' WHERE ID='UNICO'")
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmConfigMantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkRegMenues.Checked = REG_MENUS
    End Sub
End Class