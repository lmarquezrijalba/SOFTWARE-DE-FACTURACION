Imports System.Data.SqlClient

Public Class clsMenus
    Dim Modulo As String = ""
    Dim Modulo2 As String = ""
    Dim esSubMenu As Boolean

    Dim IDPermiso As Integer
    'Dim numPermiso As Integer

    Public Sub registraPermiso(ByVal subMenuItems As ToolStripItemCollection,
                               ByVal sGuiones As String, Optional menuPrincipal As String = "")

        Dim subMenu As String = ""
        Dim sqlVerificar, sqlRegPermisos As String

        '---QUITAMOS TODOS LOS PERMISOS REGISTRADOS---
        '---------------------------------------------
        For Each subItem As ToolStripItem In subMenuItems
            If subItem.GetType Is GetType(ToolStripMenuItem) Then
                Modulo = menuPrincipal
                subMenu = subItem.Text '= strNomMenu

                If CType(subItem, ToolStripMenuItem).DropDownItems.Count > 0 Then
                    Modulo2 = menuPrincipal
                    subMenu = subItem.Text
                    Modulo = menuPrincipal

                    IDPermiso = IDPermiso
                    registraPermiso(CType(subItem, ToolStripMenuItem).DropDownItems, sGuiones & "-")
                End If

                sqlVerificar = "SELECT PER_Descripcion FROM tb_permisos " & _
                               "WHERE PER_Descripcion='" & subMenu & "'"

                IDPermiso += 1

                If Modulo <> "" Then
                    sqlRegPermisos = "INSERT INTO tb_permisos(PER_Codigo, PER_Descripcion, PER_NombModulo, PER_Activo) " & _
                                     "VALUES('" & IDPermiso & "', '" & subMenu & "', '" & Modulo.Replace("&", "") & "', '" & 1 & "')"
                Else
                    sqlRegPermisos = "INSERT INTO tb_permisos(PER_Codigo, PER_Descripcion, PER_NombModulo, PER_Activo) " & _
                                     "VALUES('" & IDPermiso & "', '" & subMenu & "', '" & Modulo2.Replace("&", "") & "', '" & 1 & "')"
                End If

                If objFunciones.verificarRegistro(sqlVerificar) = False Then
                    objFunciones.Ejecutar(sqlRegPermisos)
                End If
            End If
        Next
    End Sub

    Public Sub validarPermisos(ByVal subMenuItems As ToolStripItemCollection, ByVal sGuiones As String)

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

        For Each subItem As ToolStripItem In subMenuItems
            If subItem.GetType Is GetType(ToolStripMenuItem) Then
                subMenu = subItem.Text '= strNomMenu

                If CType(subItem, ToolStripMenuItem).DropDownItems.Count > 0 Then
                    subMenu = subItem.Text
                    'registraPermiso(CType(subItem, ToolStripMenuItem).DropDownItems, sGuiones & "-")
                    validarPermisos(CType(subItem, ToolStripMenuItem).DropDownItems, sGuiones & "-")
                End If

                'RESTRINGIMOS PRIVILEGIOS
                '-------------------------
                For i = 0 To numPermisos
                    obtModuloAsignado = CStr(dt.Rows(i).Item("PER_Descripcion"))

                    If subMenu = obtModuloAsignado Then 'tag
                        subItem.Enabled = True
                        'subItem.Visible = True
                        Exit For
                    Else
                        subItem.Enabled = False
                        'subItem.Visible = False
                    End If
                Next
            End If
        Next
    End Sub
End Class
