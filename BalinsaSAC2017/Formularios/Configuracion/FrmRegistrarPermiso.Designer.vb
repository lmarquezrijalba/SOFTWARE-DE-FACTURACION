<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistrarPermiso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvpermisos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Txtdescrip = New System.Windows.Forms.TextBox()
        Me.TxtModulo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RBtnActivar = New System.Windows.Forms.RadioButton()
        Me.RBtnDesactivar = New System.Windows.Forms.RadioButton()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvpermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvpermisos
        '
        Me.dgvpermisos.AllowUserToAddRows = False
        Me.dgvpermisos.AllowUserToDeleteRows = False
        Me.dgvpermisos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvpermisos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvpermisos.Location = New System.Drawing.Point(12, 44)
        Me.dgvpermisos.Name = "dgvpermisos"
        Me.dgvpermisos.RowHeadersWidth = 40
        Me.dgvpermisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvpermisos.Size = New System.Drawing.Size(443, 328)
        Me.dgvpermisos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(115, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PERMISOS REGISTRADOS"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Location = New System.Drawing.Point(382, 388)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.BtnNuevo.TabIndex = 2
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Location = New System.Drawing.Point(382, 414)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCerrar.TabIndex = 3
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'Txtdescrip
        '
        Me.Txtdescrip.Enabled = False
        Me.Txtdescrip.Location = New System.Drawing.Point(81, 391)
        Me.Txtdescrip.Name = "Txtdescrip"
        Me.Txtdescrip.Size = New System.Drawing.Size(295, 20)
        Me.Txtdescrip.TabIndex = 4
        '
        'TxtModulo
        '
        Me.TxtModulo.Enabled = False
        Me.TxtModulo.Location = New System.Drawing.Point(81, 417)
        Me.TxtModulo.Name = "TxtModulo"
        Me.TxtModulo.Size = New System.Drawing.Size(295, 20)
        Me.TxtModulo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 393)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 423)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Modulo"
        '
        'RBtnActivar
        '
        Me.RBtnActivar.AutoSize = True
        Me.RBtnActivar.Enabled = False
        Me.RBtnActivar.Location = New System.Drawing.Point(164, 443)
        Me.RBtnActivar.Name = "RBtnActivar"
        Me.RBtnActivar.Size = New System.Drawing.Size(58, 17)
        Me.RBtnActivar.TabIndex = 8
        Me.RBtnActivar.TabStop = True
        Me.RBtnActivar.Text = "Activar"
        Me.RBtnActivar.UseVisualStyleBackColor = True
        '
        'RBtnDesactivar
        '
        Me.RBtnDesactivar.AutoSize = True
        Me.RBtnDesactivar.Enabled = False
        Me.RBtnDesactivar.Location = New System.Drawing.Point(228, 443)
        Me.RBtnDesactivar.Name = "RBtnDesactivar"
        Me.RBtnDesactivar.Size = New System.Drawing.Size(76, 17)
        Me.RBtnDesactivar.TabIndex = 9
        Me.RBtnDesactivar.TabStop = True
        Me.RBtnDesactivar.Text = "Desactivar"
        Me.RBtnDesactivar.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(465, 481)
        Me.ShapeContainer1.TabIndex = 10
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -5
        Me.LineShape1.X2 = 471
        Me.LineShape1.Y1 = 380
        Me.LineShape1.Y2 = 380
        '
        'Column1
        '
        Me.Column1.HeaderText = "N°"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 40
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "Modulo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Estado"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 60
        '
        'FrmRegistrarPermiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 481)
        Me.Controls.Add(Me.RBtnDesactivar)
        Me.Controls.Add(Me.RBtnActivar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtModulo)
        Me.Controls.Add(Me.Txtdescrip)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvpermisos)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistrarPermiso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Permisos"
        CType(Me.dgvpermisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvpermisos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents Txtdescrip As System.Windows.Forms.TextBox
    Friend WithEvents TxtModulo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RBtnActivar As System.Windows.Forms.RadioButton
    Friend WithEvents RBtnDesactivar As System.Windows.Forms.RadioButton
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
