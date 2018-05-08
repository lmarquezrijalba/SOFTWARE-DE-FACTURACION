Imports System.Data.SqlClient

Public Class FrmFiltraProductos

    Dim sqlFiltrar As String

    Private Sub FrmFiltraProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim sqlConsulta As String =
        '"SELECT P.PRD_Codigo, M.MAR_Nombre, P.PRD_Modelo, P.PRD_Nombre, P.PRD_Moneda, " & _
        '"P.PRD_Precio, P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen " & _
        '"FROM tb_productos P, tb_marcas M " & _
        '"WHERE P.MAR_Codigo = M.MAR_Codigo " & _
        '"ORDER BY MAR_Nombre"

        Dim sqlConsulta As String = "SELECT P.PRD_Codigo, " & _
        "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre, " & _
        "P.PRD_Modelo, P.PRD_Nombre, P.PRD_Moneda, P.PRD_Precio, " & _
        "P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen " & _
        "FROM tb_productos P " & _
        "ORDER BY MAR_Nombre"

        modProcedimientos.filtrarProductos(dgvProductos, sqlConsulta)
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        Dim fila As Integer = e.RowIndex
        Dim Nro As Integer = 1
        Dim numReg As Integer

        Dim sqlConsulta, getIDProducto, Producto As String
        Dim Precio, Importe As Double
        Dim N, Cant As Integer

        Dim subTotal, Total, valIGV As Double

        Try
            If fila >= 0 Then
                getIDProducto = dgvProductos.Item(0, fila).Value

                sqlConsulta = "SELECT * FROM tb_productos " & _
                              "WHERE PRD_Codigo='" & getIDProducto & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlConsulta, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count - 1

                If numReg >= 0 Then
                    Producto = CStr(dt.Rows(0).Item("PRD_Nombre"))
                    Precio = CDbl(dt.Rows(0).Item("PRD_Precio"))
                    Cant = 1
                    Importe = Precio * Cant

                    With FrmProforma.dgvDetalleCotizacion
                        .Rows.Add()
                        N = .RowCount

                        .Item(0, N - 1).Value = getIDProducto
                        .Item(1, N - 1).Value = N
                        .Item(2, N - 1).Value = Producto
                        .Item(3, N - 1).Value = Format(Precio, "#,##0.00")
                        .Item(4, N - 1).Value = Cant
                        .Item(5, N - 1).Value = Format(Importe, "#,##0.00")

                        subTotal = objFunciones.Sumar_Columna(FrmProforma.dgvDetalleCotizacion, 5)
                        valIGV = subTotal * (IGV / 100)
                        Total = subTotal + valIGV

                        With FrmProforma
                            .lblSubTotal.Text = Format(subTotal, "#,##0.00")
                            .lblIGV.Text = Format(valIGV, "#,##0.00")
                            .lblMateriales.Text = Format(Total, "#,##0.00")
                        End With
                    End With
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name)
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtFiltro_Click(sender As Object, e As EventArgs) Handles txtFiltro.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtFiltro)
    End Sub

    Private Sub txtFiltro_GotFocus(sender As Object, e As EventArgs) Handles txtFiltro.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtFiltro)
    End Sub

    Private Sub txtFiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltro.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtFiltro, e)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        If optModelo.Checked Then
            sqlFiltrar = "SELECT P.*, " & _
                         "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre " & _
                         "FROM tb_productos P " & _
                         "WHERE P.PRD_Modelo LIKE '" & txtFiltro.Text & "%'"
        ElseIf optMarca.Checked Then
            sqlFiltrar = "SELECT P.*, M.MAR_Nombre, " & _
                         "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre " & _
                         "FROM tb_productos P, tb_marcas M " & _
                         "WHERE MAR_Nombre LIKE '" & txtFiltro.Text & "%'"
        End If

        modProcedimientos.filtrarProductos(dgvProductos, sqlFiltrar)
    End Sub

    Private Sub optModelo_CheckedChanged(sender As Object, e As EventArgs) Handles optModelo.CheckedChanged
        txtFiltro.Focus()
    End Sub

    Private Sub optMarca_CheckedChanged(sender As Object, e As EventArgs) Handles optMarca.CheckedChanged
        txtFiltro.Focus()
    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub
End Class