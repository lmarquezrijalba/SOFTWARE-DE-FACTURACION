Imports System.Data.SqlClient

Public Class FrmListaProductos
    Dim index As Integer
    Dim ID, sqlProductos As String

    Private Sub cargarDatos()
        index = TabControl1.SelectedIndex

        If index >= 0 Then
            ID = TabControl1.Controls(index).Name
            Label1.Text = "FILTRO DE PRODUCTOS (" & TabControl1.Controls(index).Text & ")"

            sqlProductos = "SELECT P.PRD_Codigo, " & _
            "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre, " & _
            "ISNULL(P.PRD_Modelo, 'NO REGISTRA') AS PRD_Modelo, P.PRD_Nombre, P.PRD_Moneda, P.PRD_Precio, " & _
            "P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen " & _
            "FROM tb_productos P " & _
            "WHERE P.CAT_Codigo='" & ID & "' AND " & _
            "PRD_Activo='1' " & _
            "ORDER BY MAR_Nombre"

            modProcedimientos.listarProductos(GridaProductos(index), sqlProductos, False)
            TabControl1.SelectedIndex = index
        End If
    End Sub

    Private Sub FrmListaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        modProcedimientos.AgregarTABS_Categorias(TabControl1, False)
        cargarDatos()
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        cargarDatos()
    End Sub

End Class