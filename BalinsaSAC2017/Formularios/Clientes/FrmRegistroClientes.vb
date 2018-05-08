Imports System.Data.SqlClient

Public Class FrmRegistroClientes
    Dim codGenerado As String
    Dim sqlContador As String = "SELECT * FROM tb_clientes WHERE CLI_Activo='1'"

    Dim sqlVerificaContacto As String
    Dim Codigo, Contacto, Cargo, Fono, Correo, Observ As String
    Dim Tarjeta() As Byte

    Private Sub registraContactos(IDCliente As String)
        Dim sqlConsulta As String = "SELECT * FROM tb_contato_x_clientes " & _
                                    "WHERE CLI_Codigo='" & IDCliente & "'"
        With dgvContactos
            For c = 0 To dgvContactos.Rows.Count - 1
                Codigo = dgvContactos.Item(0, c).Value
                Contacto = dgvContactos.Item(1, c).Value
                Cargo = dgvContactos.Item(2, c).Value
                Fono = dgvContactos.Item(3, c).Value
                Correo = dgvContactos.Item(4, c).Value
                Observ = dgvContactos.Item(6, c).Value

                If Not IsNumeric(Codigo) Then
                    Tarjeta = dgvContactos.Item(5, c).Value
                    objFunciones.InsertContactos(IDCliente, Contacto, Cargo, Fono, Correo, Observ, Tarjeta)
                End If
            Next
            modProcedimientos.listarContact_x_Cliente(dgvContactos, sqlConsulta)
        End With
    End Sub

    Private Sub Habilitar(estado As Boolean)
        If estado Then
            lblCodigo.Text = codGenerado
            txtRS.Enabled = True : txtRS.Text = ""
            txtRUC.Enabled = True : txtRUC.Text = ""
            cboCiudad.Enabled = True : cboCiudad.SelectedIndex = 0
            txtDirLegal.Enabled = True : txtDirLegal.Text = ""
            txtDirec1.Enabled = True : txtDirec1.Text = ""
            txtDirec2.Enabled = True : txtDirec2.Text = ""
            txtObservaciones.Enabled = True : txtObservaciones.Text = ""

            lblAgregar.Enabled = True : lblQuitar.Enabled = True

            cmdNuevo.Enabled = False
            'cmdListarClientes.Enabled = True
            cmdRegistrar.Enabled = True
            cmdCancelar.Enabled = True
            cmdEliminar.Enabled = False
        Else
            txtRS.Enabled = False
            txtRUC.Enabled = False
            cboCiudad.Enabled = False
            txtDirLegal.Enabled = False
            txtDirec1.Enabled = False
            txtDirec2.Enabled = False
            txtObservaciones.Enabled = False

            lblAgregar.Enabled = False : lblQuitar.Enabled = False

            cmdNuevo.Enabled = True
            'cmdListarClientes.Enabled = False
            cmdRegistrar.Enabled = False
            cmdCancelar.Enabled = False
            cmdEliminar.Enabled = False
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtRS_Click(sender As Object, e As EventArgs) Handles txtRS.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtRS)
    End Sub

    Private Sub txtRS_GotFocus(sender As Object, e As EventArgs) Handles txtRS.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtRS)
    End Sub

    Private Sub txtRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRS.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtRS, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub cmdListarClientes_Click(sender As Object, e As EventArgs) Handles cmdListarClientes.Click
        NOMB_VENTANA_ACTIVA = "Registrar Clientes"
        FrmCarteraClientes.ShowDialog()
    End Sub

    Private Sub FrmRegistroClientes_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        lblNumRegistros.Text = objFunciones.getnumeroRegs(sqlContador)
        modProcedimientos.llenarCiudades(cboCiudad)

        If MDIPrincipal.mnuProvincias.Enabled Then
            cmdAgregar.Visible = True
        Else
            cmdAgregar.Visible = False
        End If

        If MDIPrincipal.mnuListaClientes.Enabled Then
            cmdListarClientes.Visible = True
        Else
            cmdListarClientes.Visible = False
        End If

        If BLOQUEAR = True Then
            Habilitar(False)
        End If
    End Sub

    Private Sub FrmRegistroClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Habilitar(False)
        txtRUC.MaxLength = 11

        With dgvContactos
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With
    End Sub

    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Dim ID As String = txtRS.Text
        Dim sqlVerificar As String
        Dim sqlInsertCliente, sqlUpdateCliente As String
        Dim sqlGenerar As String ="SELECT COUNT(CLI_Codigo) FROM tb_clientes"

        If txtRUC.Text = "" Then
            sqlVerificar = "SELECT CLI_Razonsocial FROM tb_clientes " & _
                           "WHERE CLI_RazonSocial='" & ID & "'"
        Else
            sqlVerificar = "SELECT CLI_Razonsocial FROM tb_clientes " & _
                           "WHERE CLI_RazonSocial='" & ID & "' OR " & _
                           "CLI_RUC='" & txtRUC.Text & "'"
        End If


        sqlInsertCliente =
            "INSERT INTO tb_clientes (CLI_Codigo, USU_Codigo, CLI_RazonSocial, CLI_RUC, CLI_Ciudad, " & _
            "CLI_DireccionLegal, CLI_Direccion1, CLI_Direccion2, CLI_Observacion, CLI_tipo, CLI_Activo) " & _
            "VALUES('" & lblCodigo.Text & "','" & USU_CODIGO & "','" & Trim(txtRS.Text) & "','" & _
            txtRUC.Text & "','" & cboCiudad.Text & "','" & txtDirLegal.Text & "','" & _
            txtDirec1.Text & "','" & txtDirec2.Text & "','" & txtObservaciones.Text & "','" &
            lblTipoCliente.Text & "','" & 1 & "')"

        sqlUpdateCliente =
            "UPDATE tb_clientes SET " & _
            "CLI_RazonSocial='" & Trim(txtRS.Text) & "', " & _
            "CLI_RUC='" & txtRUC.Text & "', " & _
            "CLI_Ciudad='" & cboCiudad.Text & "', " & _
            "CLI_DireccionLegal='" & txtDirLegal.Text & "', " & _
            "CLI_Direccion1='" & txtDirec1.Text & "', " & _
            "CLI_Direccion2='" & txtDirec2.Text & "', " & _
            "CLI_Tipo='" & lblTipoCliente.Text & "', " & _
            "CLI_Observacion='" & txtObservaciones.Text & "' " & _
            "WHERE CLI_Codigo='" & lblCodigo.Text & "'"

        Try
            If lblMantenimiento.Text = "Nuevo" Then
                If objFunciones.verificarRegistro(sqlVerificar) = False Then
                    If Len(txtRS.Text) = 0 Then
                        MsgBox("No se puede registrar al cliente" & vbNewLine & vbNewLine & _
                               "Debe ingresar la razón social del cliente a ser registrada.", vbCritical, "Ingrese")
                        txtRS.Focus()
                    Else
                        'GENERAMOS NUEVO CODIGO Y LO MOSTRAMOS
                        '--------------------------------------
                        codGenerado = objFunciones.Generar_Codigo(sqlGenerar, "000000000", "C")
                        lblCodigo.Text = codGenerado

                        If (objFunciones.Ejecutar(sqlInsertCliente)) Then

                            Call registraContactos(codGenerado) 'INSERTAMOS LOS CONTACTOS X CLIENTE
                            lblNumRegistros.Text = objFunciones.getnumeroRegs(sqlContador)
                            Habilitar(False)
                        End If
                    End If
                Else
                    'GENERAMOS NUEVO CODIGO Y LO MOSTRAMOS
                    '--------------------------------------
                    codGenerado = objFunciones.Generar_Codigo(sqlGenerar, "000000000", "C")
                    lblCodigo.Text = codGenerado

                    Call registraContactos(codGenerado) 'INSERTAMOS LOS CONTACTOS X CLIENTE

                    If lblMantenimiento.Text = "Nuevo" Then
                        MsgBox("El cliente [ " & ID & " ] y/o el número de RUC " & _
                               txtRUC.Text & " ya se encuentra registrado, verifique los datos " & _
                               "de registro por favor.", vbCritical, "¡Aviso!")
                    End If
                End If
            ElseIf lblMantenimiento.Text = "Editar" Then
                If objFunciones.Ejecutar(sqlUpdateCliente) Then
                    Call registraContactos(lblCodigo.Text)

                    MsgBox("En hora buena." & vbNewLine & vbNewLine & _
                           "Los cambios realizados en los datos del cliente se realizarón con exito.", vbInformation, "Hecho")
                    Habilitar(False)
                    cmdListarClientes.Enabled = True
                End If
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        lblMantenimiento.Text = "Nuevo"
        dgvContactos.Rows.Clear()

        ''AUTOGERAR CODIGO
        ''-----------------
        codGenerado = objFunciones.Generar_Codigo("SELECT COUNT(CLI_Codigo) FROM tb_clientes", "000000000", "C")
        lblCodigo.Text = codGenerado

        Habilitar(True)
    End Sub

    Private Sub txtRUC_Click(sender As Object, e As EventArgs) Handles txtRUC.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtRUC)
    End Sub

    Private Sub txtRUC_GotFocus(sender As Object, e As EventArgs) Handles txtRUC.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtRUC)
    End Sub

    Private Sub txtRUC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRUC.KeyPress
        modProcedimientos.SOLO_NUMEROS(sender, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtDirLegal_Click(sender As Object, e As EventArgs) Handles txtDirLegal.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtDirLegal)
    End Sub

    Private Sub txtDirLegal_GotFocus(sender As Object, e As EventArgs) Handles txtDirLegal.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtDirLegal)
    End Sub

    Private Sub txtDirLegal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDirLegal.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDirLegal, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtObservaciones_Click(sender As Object, e As EventArgs) Handles txtObservaciones.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtObservaciones)
    End Sub

    Private Sub txtObservaciones_GotFocus(sender As Object, e As EventArgs) Handles txtObservaciones.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtObservaciones)
    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtObservaciones, e)
        'If txtObservaciones.Text <> "" Then
        'modProcedimientos.Saltar(e)
        'End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        lblCodigo.Text = ""
        cmdListarClientes.Enabled = True

        Habilitar(False)
    End Sub

    Private Sub lblMantenimiento_TextChanged(sender As Object, e As EventArgs) Handles lblMantenimiento.TextChanged
        If lblMantenimiento.Text = "Nuevo" Then
            cmdRegistrar.Text = "Registrar"
        ElseIf lblMantenimiento.Text = "Editar" Then
            cmdRegistrar.Text = "Modificar"
        End If
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim sqlBaja As String

        sqlBaja = "UPDATE tb_clientes SET " & _
                  "CLI_Activo='" & 0 & "' " & _
                  "WHERE CLI_Codigo='" & lblCodigo.Text & "'"
        Try
            If MDIPrincipal.mnuEliminarClientesDelSistema.Enabled Then
                If MsgBox("Realmente desea dar de baja al cliente " & vbNewLine & _
                          txtRS.Text, vbQuestion + vbYesNo + vbDefaultButton2) = vbYes Then
                    If objFunciones.Ejecutar(sqlBaja) Then

                        lblCodigo.Text = ""
                        txtRS.Text = ""
                        txtRUC.Text = ""
                        cboCiudad.SelectedIndex = 0
                        txtDirLegal.Text = ""
                        txtObservaciones.Text = ""

                        Habilitar(False)

                        cmdListarClientes.Enabled = True

                        lblNumRegistros.Text = objFunciones.getnumeroRegs(sqlContador)
                    End If
                Else
                    Habilitar(False)
                End If
            Else
                MsgBox("No se pudo elimimar el cliente" & vbNewLine & vbNewLine & _
                       "Lo sentimos pero no cuentas con permiso para realizar esta acción, " & _
                       "de persistir con la eliminación de este cliente. Comunicate con el " & _
                       "administrador del sistema o con alguna otra persona responsable.", vbCritical, "Atención")
            End If
        Catch ex As Exception
            modProcedimientos.MostrarError(ex.HResult, ex.Message, Me.Name & " " & objFunciones.getNombreProcedimiento)
        End Try
    End Sub

    Private Sub txtDirec1_Click(sender As Object, e As EventArgs) Handles txtDirec1.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtDirec1)
    End Sub

    Private Sub txtDirec1_GotFocus(sender As Object, e As EventArgs) Handles txtDirec1.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtDirec2)
    End Sub

    Private Sub txtDirec1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDirec1.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDirec1, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtDirec2_Click(sender As Object, e As EventArgs) Handles txtDirec2.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtDirec2)
    End Sub

    Private Sub txtDirec2_GotFocus(sender As Object, e As EventArgs) Handles txtDirec2.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtDirec2)
    End Sub

    Private Sub txtDirec2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDirec2.KeyPress
        modProcedimientos.A_MAYUSCULAS(txtDirec2, e)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        BLOQUEAR = False
        FrmRegistroCiudades.ShowDialog()
    End Sub

    Private Sub lblAgregar_Click(sender As Object, e As EventArgs) Handles lblAgregar.Click
        With FrmRegistroContactos
            .picTarjeta.Image = Image.FromFile(objFunciones.GetRutaSistema & "\Iconos\sin imagen.jpg")
            .txtContacto.Text = ""
            .txtCargo.Text = ""
            .txtCorreo.Text = ""
            .txtFono.Text = ""
            .txtObservacion.Text = ""
            .txtContacto.Focus()

            .cmdAñadir.Text = "Añadir contacto"
            .ShowDialog()
        End With
    End Sub

    Private Sub lblQuitar_Click(sender As Object, e As EventArgs) Handles lblQuitar.Click
        Dim sqlDelete As String

        With dgvContactos
            If Not IsNothing(.CurrentRow) Then

                If MsgBox("Realmente deseas quitar la fila seleccionada.", _
                          vbQuestion + vbYesNo + vbDefaultButton2, "Quitar elemento") = vbYes Then

                    If Not IsNumeric(.Item(0, .CurrentRow.Index).Value) Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        sqlDelete = "DELETE FROM tb_contato_x_clientes WHERE CON_Codigo='" & _
                                    .Item(0, .CurrentRow.Index).Value & "'"
                        If objFunciones.Ejecutar(sqlDelete) Then
                            .Rows.Remove(.CurrentRow)
                        End If
                    End If

                End If
            End If
        End With
    End Sub

    Private Sub LimpiarCampos()
        With FrmRegistroContactos
            .lblIDContacto.Text = ""
            .txtContacto.Text = ""
            .txtCargo.Text = ""
            .txtFono.Text = ""
            .txtCorreo.Text = ""
            .txtObservacion.Text = ""
            '.picTarjeta.Image = imagen
        End With
    End Sub

    Private Sub dgvContactos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContactos.CellDoubleClick
        Dim sqlContacto As String
        Dim IDContacto, ID_Cliente, Contacto, Cargo, Fono, Correo, Observ As String
        Dim imagen As Image
        Dim numReg, fila As Integer

        Call LimpiarCampos()

        fila = e.RowIndex

        If fila >= 0 Then
            'With FrmRegistroContactos
            '.lblFilaSelec.Text = fila

            '.lblIDContacto.Text = dgvContactos.Item(0, fila).Value
            '.txtContacto.Text = dgvContactos.Item(1, fila).Value
            '.txtCargo.Text = dgvContactos.Item(2, fila).Value
            '.txtFono.Text = dgvContactos.Item(3, fila).Value
            '.txtCorreo.Text = dgvContactos.Item(4, fila).Value
            'If Not IsNumeric(.lblIDContacto.Text) Then
            '.picTarjeta.Image = objImagenes.ByteArrayToImage(DirectCast(dgvContactos.Item(5, fila).Value, Byte()))
            'Else
            '.picTarjeta.Image = dgvContactos.Item(5, fila).Value
            'End If
            '.txtObservacion.Text = dgvContactos.Item(6, fila).Value

            With FrmRegistroContactos
                IDContacto = dgvContactos.Item(0, e.RowIndex).Value
                sqlContacto = "SELECT * FROM tb_contato_x_clientes WHERE CON_Codigo='" & IDContacto & "'"

                dt = New Data.DataTable
                sqlda = New SqlDataAdapter(sqlContacto, cnn)
                sqlda.Fill(dt)

                numReg = dt.Rows.Count - 1

                If numReg >= 0 Then
                    ID_Cliente = CStr(dt.Rows(0).Item("CLI_Codigo"))
                    Contacto = CStr(dt.Rows(0).Item("CON_Nombres").ToString)
                    Cargo = CStr(dt.Rows(0).Item("CON_Cargo").ToString)
                    Fono = CStr(dt.Rows(0).Item("CON_Telefono").ToString)
                    Correo = CStr(dt.Rows(0).Item("CON_Correo").ToString)
                    Observ = CStr(dt.Rows(0).Item("CON_Observacion").ToString)
                    imagen = objImagenes.ByteArrayToImage(DirectCast(dt.Rows(0).Item("CON_Tarjeta"), Byte()))

                    .lblIDContacto.Text = IDContacto
                    .txtContacto.Text = Contacto
                    .txtCargo.Text = Cargo
                    .txtFono.Text = Fono
                    .txtCorreo.Text = Correo
                    .txtObservacion.Text = Observ
                    .picTarjeta.Image = imagen

                    .cmdAñadir.Text = "Actualizar datos"
                    .ShowDialog()
                End If
            End With
        End If
    End Sub

    Private Sub lblConectar_Click(sender As Object, e As EventArgs) Handles lblConectar.Click
        System.Diagnostics.Process.Start("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias")
    End Sub

    Private Sub lblTipoCliente_TextChanged(sender As Object, e As EventArgs) Handles lblTipoCliente.TextChanged
        If lblTipoCliente.Text = "B" Then
            lblDescTipoCliente.Text = "MARCADO COMO CLIENTE DE BALANZAS"
        ElseIf lblTipoCliente.Text = "C" Then
            lblDescTipoCliente.Text = "MARCADO COMO CLIENTE DE CAMARAS"
        Else
            lblDescTipoCliente.Text = "PULSE EL ATAJO DE TECLADO O PULSE CLICK SOBRE LA INICIAL DE ASIGNACIÓN."
        End If
    End Sub

    Private Sub mnuCamaras_Click(sender As Object, e As EventArgs) Handles mnuCamaras.Click
        lblTipoCliente.Text = "C"
    End Sub

    Private Sub mnuBalanzas_Click(sender As Object, e As EventArgs) Handles mnuBalanzas.Click
        lblTipoCliente.Text = "B"
    End Sub

    Private Sub lblTipoCliente_Click(sender As Object, e As EventArgs) Handles lblTipoCliente.Click
        If lblTipoCliente.Text = "0" Or lblTipoCliente.Text = "-" Then
            lblTipoCliente.Text = "B"
        ElseIf lblTipoCliente.Text = "B" Then
            lblTipoCliente.Text = "C"
        ElseIf lblTipoCliente.Text = "C" Then
            lblTipoCliente.Text = "B"
        End If
    End Sub
End Class