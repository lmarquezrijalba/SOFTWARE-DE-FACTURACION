Public Class FrmAperturarCaja
    'CAJAS QUE NO ESTEN CERRADAS
    '----------------------------
    Dim sqlCajas As String = "SELECT * FROM tb_cajas WHERE CAJ_Aperturado <> 2"
    'Dim TipoMoneda As String

    Private Sub FrmAperturarCaja_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        lblFechaApertura.Text = Format(Now, "dd/MM/yyyy")
        modProcedimientos.crearBotones(sqlCajas, panelCajas, 205, 132, 5)

        lblCodCajero.Text = USU_CODIGO
        lblNombCajero.Text = UCase(USU_NOMBRE)

        'If MDIPrincipal.mnuCrearNuevasCajas.Enabled = True Then
        'cmdNuevo.Visible = True
        'Else
        'cmdNuevo.Visible = False
        'End If

        'If MDIPrincipal.mnuAdministraTodasCajas.Enabled = True Then
        'cmdListaUsuarios.Visible = True
        'Else
        'cmdListaUsuarios.Visible = False
        'End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdRefrescar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        modProcedimientos.crearBotones(sqlCajas, panelCajas, 205, 132, 5)
    End Sub

    Private Sub chkActivar_CheckedChanged(sender As Object, e As EventArgs)
        If chkActivar.Checked Then
            txtNroSerie.Enabled = True
            txtDocumInic.Enabled = True
            txtDocumFin.Enabled = True

            txtNroSerie.Focus()
        Else
            txtNroSerie.Enabled = False
            txtDocumInic.Enabled = False
            txtDocumFin.Enabled = False
        End If
    End Sub

    Private Sub cmdListaUsuarios_Click(sender As Object, e As EventArgs) Handles cmdListaUsuarios.Click
        NOMB_VENTANA_ACTIVA = Me.Text
        FrmListaUsuarios.ShowDialog()
    End Sub

    Private Sub txtMontoinic_S_Click(sender As Object, e As EventArgs) Handles txtMontoinic_S.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoinic_S)
    End Sub

    Private Sub txtMontoinic_S_GotFocus(sender As Object, e As EventArgs) Handles txtMontoinic_S.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoinic_S)
    End Sub

    Private Sub txtMontoinic_S_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoinic_S.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtMontoinic_S)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub txtMontoinic_D_Click(sender As Object, e As EventArgs) Handles txtMontoinic_D.Click
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoinic_D)
    End Sub

    Private Sub txtMontoinic_D_GotFocus(sender As Object, e As EventArgs) Handles txtMontoinic_D.GotFocus
        modProcedimientos.SELEC_TODO_TEXTO(txtMontoinic_D)
    End Sub

    Private Sub txtMontoinic_D_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoinic_D.KeyPress
        modProcedimientos.SOLO_NUMEROS_DEC(sender, e, txtMontoinic_D)
        modProcedimientos.Saltar(e)
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        cmdNuevo.Enabled = False
        FrmCrearCaja.ShowDialog()
    End Sub

    Private Sub txtMontoinic_S_LostFocus(sender As Object, e As EventArgs) Handles txtMontoinic_S.LostFocus
        txtMontoinic_S.Text = Format(CType(txtMontoinic_S.Text, Decimal), "#,##0.00")
    End Sub

    Private Sub txtNroSerie_Click(sender As Object, e As EventArgs)
        modProcedimientos.SELEC_TODO_TEXTO(txtNroSerie)
    End Sub

    Private Sub txtNroSerie_GotFocus(sender As Object, e As EventArgs)
        modProcedimientos.SELEC_TODO_TEXTO(txtNroSerie)
    End Sub

    Private Sub txtNroSerie_KeyPress(sender As Object, e As KeyPressEventArgs)
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtDocumInic_Click(sender As Object, e As EventArgs)
        modProcedimientos.SELEC_TODO_TEXTO(txtDocumInic)
    End Sub

    Private Sub txtDocumInic_GotFocus(sender As Object, e As EventArgs)
        modProcedimientos.SELEC_TODO_TEXTO(txtDocumInic)
    End Sub

    Private Sub txtDocumInic_KeyPress(sender As Object, e As KeyPressEventArgs)
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtDocumFin_Click(sender As Object, e As EventArgs)
        modProcedimientos.SELEC_TODO_TEXTO(txtDocumFin)
    End Sub

    Private Sub txtDocumFin_GotFocus(sender As Object, e As EventArgs)
        modProcedimientos.SELEC_TODO_TEXTO(txtDocumFin)
    End Sub

    Private Sub txtDocumFin_KeyPress(sender As Object, e As KeyPressEventArgs)
        modProcedimientos.SOLO_NUMEROS(sender, e)
    End Sub

    Private Sub txtMontoinic_D_LostFocus(sender As Object, e As EventArgs) Handles txtMontoinic_D.LostFocus
        txtMontoinic_D.Text = Format(CType(txtMontoinic_D.Text, Decimal), "#,##0.00")
    End Sub

    Private Sub cmdCalendario_Click(sender As Object, e As EventArgs) Handles cmdCalendario.Click
        NOMB_VENTANA_ACTIVA = Me.Text
        FrmCalendario.ShowDialog()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class