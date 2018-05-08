Public Class FrmRegistrarPermiso
    Dim estado As Boolean
    Dim Id_new As Integer
    Dim id As Integer
    Dim proceso As Integer
    Private Sub FrmRegistrarPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modProcedimientos.Listar_Permisos(dgvpermisos)
    End Sub
    Private Sub RBtnActivar_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnActivar.CheckedChanged
        estado = True
    End Sub

    Private Sub RBtnDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnDesactivar.CheckedChanged
        estado = False
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Dim descrip, modulo, consulta As String
        If BtnNuevo.Text = "Nuevo" Then
            dgvpermisos.Enabled = False
            proceso = 0
            Txtdescrip.Enabled = True
            TxtModulo.Enabled = True
            RBtnActivar.Enabled = True
            RBtnDesactivar.Enabled = True
            BtnNuevo.Text = "Guardar"
            BtnCerrar.Text = "Cancelar"
        ElseIf BtnNuevo.Text = "Guardar" Then
            If Txtdescrip.Text <> "" And TxtModulo.Text <> "" Then
                If proceso = 0 Then
                    Id_new = objFunciones.obtener_id() + 1
                    descrip = Txtdescrip.Text
                    modulo = TxtModulo.Text
                    consulta = "INSERT INTO tb_permisos (PER_Codigo,PER_Descripcion,PER_NombModulo,PER_Activo) values (" & CStr(Id_new) & ", '" & descrip & "','" & modulo & "','" & estado & "')"
                    If objFunciones.Ejecutar(consulta) Then
                        Txtdescrip.Clear()
                        TxtModulo.Clear()
                        RBtnActivar.Checked = False
                        RBtnDesactivar.Checked = False
                    End If
                    BtnNuevo.Text = "Nuevo"
                    BtnCerrar.Text = "Cerrar"
                    Txtdescrip.Enabled = False
                    TxtModulo.Enabled = False
                    RBtnActivar.Enabled = False
                    RBtnDesactivar.Enabled = False
                ElseIf proceso = 1 Then
                    Id_new = id
                    descrip = Txtdescrip.Text
                    modulo = TxtModulo.Text
                    consulta = "UPDATE tb_permisos SET PER_Activo = '" & estado & "' WHERE PER_Codigo = " & CStr(Id_new) & ""
                    If objFunciones.Ejecutar(consulta) Then
                        Txtdescrip.Clear()
                        TxtModulo.Clear()
                        RBtnActivar.Checked = False
                        RBtnDesactivar.Checked = False
                    End If
                    BtnNuevo.Text = "Nuevo"
                    BtnCerrar.Text = "Cerrar"
                    Txtdescrip.Enabled = False
                    TxtModulo.Enabled = False
                    RBtnActivar.Enabled = False
                    RBtnDesactivar.Enabled = False
                End If
                dgvpermisos.Enabled = True
            Else
                MsgBox("No se puede registrar." & vbNewLine & vbNewLine & _
                    "Verifique que los campos esten llenos.", vbCritical, "Ingrese")
            End If
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        ElseIf BtnCerrar.Text = "Cancelar" Then
            BtnCerrar.Text = "Cerrar"
            BtnNuevo.Text = "Nuevo"
            Txtdescrip.Clear()
            TxtModulo.Clear()
            RBtnActivar.Checked = False
            RBtnDesactivar.Checked = False
            Txtdescrip.Enabled = False
            TxtModulo.Enabled = False
            RBtnActivar.Enabled = False
            RBtnDesactivar.Enabled = False
        End If
        dgvpermisos.Enabled = True
    End Sub

    Private Sub dgvpermisos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpermisos.CellDoubleClick

        Dim fila_selec As Integer = e.RowIndex
        id = dgvpermisos.Item(0, fila_selec).Value
        Txtdescrip.Text = dgvpermisos.Item(1, fila_selec).Value
        TxtModulo.Text = dgvpermisos.Item(2, fila_selec).Value
        estado = dgvpermisos.Item(3, fila_selec).Value
        If estado = True Then
            RBtnActivar.Checked = True
        Else
            RBtnDesactivar.Checked = True
        End If
        BtnNuevo.Text = "Modificar"
        proceso = 1
        RBtnActivar.Enabled = True
        RBtnDesactivar.Enabled = True
        BtnNuevo.Text = "Guardar"
        BtnCerrar.Text = "Cancelar"

    End Sub
End Class