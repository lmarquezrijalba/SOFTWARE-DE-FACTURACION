Public Class FrmMarcas
    Dim sqlMarcas As String
    Dim sqlInsertar, sqlActualizar, sqlVerificar, sqlEliminar As String
    Dim sqlMarcasxCat As String

    Private Sub FrmMarcas_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If objFunciones.estaVentanaAbierta(FrmProductos) Then
            Me.Hide()

            With FrmProductos
                sqlMarcasxCat = "SELECT '0' AS MAR_Codigo, 'Seleccione' AS MAR_Nombre " & _
                                "UNION(SELECT MAR_Codigo, MAR_Nombre " & _
                                "FROM tb_marcas " & _
                                "WHERE CAT_Codigo='" & lblIDCategoria.Text & "')"

                modProcedimientos.llenarMarcas_x_Categoria(.cboMarca, sqlMarcasxCat)
            End With
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub FrmMarcas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmMarcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'modProcedimientos.setearGrida(dgvMarcas)
        Dim sqlGenerar As String

        sqlMarcas = "SELECT * FROM tb_marcas WHERE CAT_Codigo='" & lblIDCategoria.Text & "'"

        sqlGenerar = "SELECT COUNT(MAR_Codigo) FROM tb_marcas"
        lblCodigo.Text = objFunciones.Generar_Codigo(sqlGenerar, "0000")

        cmdRegistrar.Enabled = True
        cmdEliminar.Enabled = False
        txtNombre.Text = ""

        modProcedimientos.listarMarcas(dgvMarcas, sqlMarcas)
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        sqlVerificar = "SELECT MAR_Nombre FROM tb_marcas " & _
                       "WHERE MAR_Nombre='" & txtNombre.Text & "' AND " & _
                       "CAT_Codigo='" & lblIDCategoria.Text & "'"

        sqlInsertar = "INSERT INTO tb_marcas(MAR_Codigo, CAT_Codigo, MAR_Nombre, MAR_Activo) " & _
                      "VALUES('" & lblCodigo.Text & "', '" & lblIDCategoria.Text & "', '" & _
                      txtNombre.Text & "', '" & 1 & "')"

        sqlActualizar = "UPDATE tb_marcas SET " & _
                        "CAT_Codigo='" & lblIDCategoria.Text & "', '" & _
                        "MAR_Nombre='" & txtNombre.Text & "'"

        If cmdRegistrar.Text = "Registrar" Then
            If Len(txtNombre.Text) = 0 Then
                MsgBox("No se pudo registrar la categoria." & vbNewLine & vbNewLine & _
                       "Ingrese el nombre de la categoria a ser registrar", vbCritical, "¡Aviso!")

                txtNombre.Focus()

            Else
                If objFunciones.verificarRegistro(sqlVerificar) = False Then
                    If objFunciones.Ejecutar(sqlInsertar) Then
                        modProcedimientos.listarMarcas(dgvMarcas, sqlMarcas)

                        cmdRegistrar.Enabled = False
                        cmdEliminar.Enabled = True

                        Me.Close()
                    End If
                Else
                    MsgBox("La marca ya se encuentra registrada.", vbCritical, "¡Verifique!")
                End If
            End If
        ElseIf cmdRegistrar.Text = "Modificar" Then
            If objFunciones.Ejecutar(sqlActualizar) Then
                modProcedimientos.listarMarcas(dgvMarcas, sqlMarcas)

                cmdRegistrar.Enabled = False
                cmdEliminar.Enabled = True
            End If
        End If

        If NOMB_VENTANA_ACTIVA = "Calibraciones" Then
            With FrmCalibraciones
                modProcedimientos.llenarMarcas_x_Categoria(.cboMarca, sqlMarcas)
            End With
        End If
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        sqlEliminar = "UPDATE tb_marcas SET " & _
                      "MAR_Estado='" & 0 & "' " & _
                      "WHERE MAR_Codigo='" & lblCodigo.Text & "'"

        If objFunciones.Ejecutar(sqlEliminar) Then
            modProcedimientos.listarMarcas(dgvMarcas, sqlMarcas)
        End If
    End Sub

    Private Sub txtNombre_Click(sender As Object, e As EventArgs) Handles txtNombre.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtNombre)
    End Sub

    Private Sub txtNombre_GotFocus(sender As Object, e As EventArgs) Handles txtNombre.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtNombre)
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtNombre, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        If Len(txtNombre.Text) > 0 Then
            cmdRegistrar.Enabled = True
        Else
            cmdRegistrar.Enabled = False
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()

        cmdRegistrar.Enabled = False
        cmdEliminar.Enabled = False
    End Sub
End Class