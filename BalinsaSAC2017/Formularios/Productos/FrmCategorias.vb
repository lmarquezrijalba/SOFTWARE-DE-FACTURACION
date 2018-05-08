Public Class FrmCategorias

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim sqlInsert, sqlVerificar As String

        sqlVerificar = "SELECT CAT_Nombre FROM tb_categorias WHERE CAT_Nombre='" & txtCategoria.Text & "'"

        sqlInsert = "INSERT INTO tb_categorias(CAT_Nombre, esBALANZA, CAT_Activo) " & _
                    "VALUES('" & txtCategoria.Text & "', '" & chkBalanza.Checked & "', '" & 1 & "')"

        If objFunciones.verificarRegistro(sqlVerificar) = False Then
            If objFunciones.Ejecutar(sqlInsert) Then

                With FrmCatalogoProductos
                    modProcedimientos.AgregarTABS_Categorias(.TabControl1, True)

                    Dim sqlProductos As String =
                    "SELECT P.PRD_Codigo, " & _
                    "ISNULL((SELECT M.MAR_Nombre FROM tb_marcas M WHERE M.MAR_Codigo=P.MAR_Codigo), 'NO REGISTRA') AS MAR_Nombre, " & _
                    "ISNULL(P.PRD_Modelo, 'NO REGISTRA') AS PRD_Modelo, P.PRD_Nombre, P.PRD_Moneda, P.PRD_Precio, " & _
                    "P.PRD_Dscto, P.PRD_Stock, P.PRD_Especificaciones, P.PRD_Imagen " & _
                    "FROM tb_productos P " & _
                    "WHERE P.CAT_Codigo='" & .TabControl1.TabPages(0).Name & "' AND " & _
                    "PRD_Activo='1' " & _
                    "ORDER BY MAR_Nombre"

                    .TabControl1.SelectedIndex = 0
                    modProcedimientos.listarProductos(GridaProductos(.TabControl1.SelectedIndex), sqlProductos, True)
                End With

                Me.Close()
            End If
        Else
            MsgBox("No se pudo registrar la categoria." & vbNewLine & vbNewLine & _
                   "La categoria que desea registrar, ya se ecuentra registrada", vbCritical, "¡Verifique!")

            txtCategoria.Text = ""
            txtCategoria.Focus()
        End If
    End Sub

    Private Sub txtCategoria_Click(sender As Object, e As EventArgs) Handles txtCategoria.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtCategoria)
    End Sub

    Private Sub txtCategoria_GotFocus(sender As Object, e As EventArgs) Handles txtCategoria.GotFocus
        'modProcedimientos.SELEC_TODO_TEXTO(txtCategoria)
    End Sub

    Private Sub txtCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCategoria.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtCategoria, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        If Len(txtCategoria.Text) > 0 Then
            cmdGuardar.Enabled = True
        Else
            cmdGuardar.Enabled = False
        End If
    End Sub

    Private Sub FrmCategorias_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim sqlVerificar As String

        chkBalanza.Checked = False
        txtCategoria.Text = ""
        txtCategoria.Focus()

        sqlVerificar = "SELECT * from tb_categorias WHERE esBALANZA='1'"

        If objFunciones.verificarRegistro(sqlVerificar) Then
            chkBalanza.Visible = False
        Else
            chkBalanza.Visible = True
        End If
    End Sub

    Private Sub FrmCategorias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub
End Class