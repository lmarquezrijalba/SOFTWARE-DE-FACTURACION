<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTerminarMovimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTerminarMovimiento))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblNombCaja = New System.Windows.Forms.Label()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.lblCambiar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblstrDesembolso = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDetalleMov = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.lblIDCaja = New System.Windows.Forms.Label()
        Me.lblIDMov = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdTerminar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDevolver = New System.Windows.Forms.Label()
        Me.lblGastado = New System.Windows.Forms.Label()
        Me.lblstrDevolver = New System.Windows.Forms.Label()
        Me.lblstrGastado = New System.Windows.Forms.Label()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvDetalleMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'picLinea
        '
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(-1, 73)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(370, 2)
        Me.picLinea.TabIndex = 68
        Me.picLinea.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lblImporte)
        Me.Panel1.Controls.Add(Me.lblNombCaja)
        Me.Panel1.Controls.Add(Me.lblOp)
        Me.Panel1.Controls.Add(Me.lblCambiar)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblstrDesembolso)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(369, 67)
        Me.Panel1.TabIndex = 67
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblImporte.Location = New System.Drawing.Point(171, 44)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(35, 14)
        Me.lblImporte.TabIndex = 74
        Me.lblImporte.Text = "0,00"
        Me.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombCaja
        '
        Me.lblNombCaja.AutoSize = True
        Me.lblNombCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblNombCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNombCaja.Location = New System.Drawing.Point(171, 25)
        Me.lblNombCaja.Name = "lblNombCaja"
        Me.lblNombCaja.Size = New System.Drawing.Size(109, 13)
        Me.lblNombCaja.TabIndex = 73
        Me.lblNombCaja.Text = "NOMBRE DE LA CAJA"
        Me.lblNombCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOp
        '
        Me.lblOp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblOp.Location = New System.Drawing.Point(171, 7)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(48, 13)
        Me.lblOp.TabIndex = 72
        Me.lblOp.Text = "---"
        Me.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambiar
        '
        Me.lblCambiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCambiar.Image = CType(resources.GetObject("lblCambiar.Image"), System.Drawing.Image)
        Me.lblCambiar.Location = New System.Drawing.Point(3, 1)
        Me.lblCambiar.Name = "lblCambiar"
        Me.lblCambiar.Size = New System.Drawing.Size(57, 66)
        Me.lblCambiar.TabIndex = 143
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(62, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Nro. Operación   :"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Retiró de caja    :"
        '
        'lblstrDesembolso
        '
        Me.lblstrDesembolso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstrDesembolso.Location = New System.Drawing.Point(62, 44)
        Me.lblstrDesembolso.Name = "lblstrDesembolso"
        Me.lblstrDesembolso.Size = New System.Drawing.Size(103, 13)
        Me.lblstrDesembolso.TabIndex = 145
        Me.lblstrDesembolso.Text = "Desembolsó S/. :"
        '
        'Column3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Importe"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Concepto"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 250
        '
        'dgvDetalleMov
        '
        Me.dgvDetalleMov.AllowUserToAddRows = False
        Me.dgvDetalleMov.AllowUserToDeleteRows = False
        Me.dgvDetalleMov.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalleMov.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetalleMov.ColumnHeadersHeight = 24
        Me.dgvDetalleMov.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3})
        Me.dgvDetalleMov.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleMov.Location = New System.Drawing.Point(0, 67)
        Me.dgvDetalleMov.Name = "dgvDetalleMov"
        Me.dgvDetalleMov.ReadOnly = True
        Me.dgvDetalleMov.RowHeadersVisible = False
        Me.dgvDetalleMov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleMov.Size = New System.Drawing.Size(369, 188)
        Me.dgvDetalleMov.TabIndex = 70
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblMoneda)
        Me.Panel3.Controls.Add(Me.lblIDCaja)
        Me.Panel3.Controls.Add(Me.lblIDMov)
        Me.Panel3.Controls.Add(Me.cmdCerrar)
        Me.Panel3.Controls.Add(Me.cmdTerminar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 300)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(369, 42)
        Me.Panel3.TabIndex = 154
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMoneda.Location = New System.Drawing.Point(21, 20)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(27, 13)
        Me.lblMoneda.TabIndex = 159
        Me.lblMoneda.Text = "S/D"
        Me.lblMoneda.Visible = False
        '
        'lblIDCaja
        '
        Me.lblIDCaja.AutoSize = True
        Me.lblIDCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblIDCaja.Location = New System.Drawing.Point(66, 5)
        Me.lblIDCaja.Name = "lblIDCaja"
        Me.lblIDCaja.Size = New System.Drawing.Size(33, 13)
        Me.lblIDCaja.TabIndex = 158
        Me.lblIDCaja.Text = "IDCaj"
        Me.lblIDCaja.Visible = False
        '
        'lblIDMov
        '
        Me.lblIDMov.AutoSize = True
        Me.lblIDMov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblIDMov.Location = New System.Drawing.Point(21, 5)
        Me.lblIDMov.Name = "lblIDMov"
        Me.lblIDMov.Size = New System.Drawing.Size(39, 13)
        Me.lblIDMov.TabIndex = 155
        Me.lblIDMov.Text = "IDMov"
        Me.lblIDMov.Visible = False
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(293, 6)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(66, 28)
        Me.cmdCerrar.TabIndex = 157
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdTerminar
        '
        Me.cmdTerminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTerminar.Image = CType(resources.GetObject("cmdTerminar.Image"), System.Drawing.Image)
        Me.cmdTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTerminar.Location = New System.Drawing.Point(186, 6)
        Me.cmdTerminar.Name = "cmdTerminar"
        Me.cmdTerminar.Size = New System.Drawing.Size(106, 28)
        Me.cmdTerminar.TabIndex = 156
        Me.cmdTerminar.Text = "Terminar Oper."
        Me.cmdTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdTerminar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblDevolver)
        Me.Panel2.Controls.Add(Me.lblGastado)
        Me.Panel2.Controls.Add(Me.lblstrDevolver)
        Me.Panel2.Controls.Add(Me.lblstrGastado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 255)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(369, 45)
        Me.Panel2.TabIndex = 155
        '
        'lblDevolver
        '
        Me.lblDevolver.BackColor = System.Drawing.Color.Transparent
        Me.lblDevolver.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevolver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDevolver.Location = New System.Drawing.Point(270, 23)
        Me.lblDevolver.Name = "lblDevolver"
        Me.lblDevolver.Size = New System.Drawing.Size(89, 20)
        Me.lblDevolver.TabIndex = 146
        Me.lblDevolver.Text = "0,00"
        Me.lblDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastado
        '
        Me.lblGastado.BackColor = System.Drawing.Color.Transparent
        Me.lblGastado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGastado.Location = New System.Drawing.Point(270, 1)
        Me.lblGastado.Name = "lblGastado"
        Me.lblGastado.Size = New System.Drawing.Size(89, 22)
        Me.lblGastado.TabIndex = 150
        Me.lblGastado.Text = "0,00"
        Me.lblGastado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblstrDevolver
        '
        Me.lblstrDevolver.BackColor = System.Drawing.Color.Transparent
        Me.lblstrDevolver.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstrDevolver.Location = New System.Drawing.Point(122, 27)
        Me.lblstrDevolver.Name = "lblstrDevolver"
        Me.lblstrDevolver.Size = New System.Drawing.Size(145, 13)
        Me.lblstrDevolver.TabIndex = 149
        Me.lblstrDevolver.Text = "Por Devolver :"
        Me.lblstrDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblstrGastado
        '
        Me.lblstrGastado.BackColor = System.Drawing.Color.Transparent
        Me.lblstrGastado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstrGastado.Location = New System.Drawing.Point(125, 6)
        Me.lblstrGastado.Name = "lblstrGastado"
        Me.lblstrGastado.Size = New System.Drawing.Size(142, 13)
        Me.lblstrGastado.TabIndex = 151
        Me.lblstrGastado.Text = "Tot.  Gastado :"
        Me.lblstrGastado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmTerminarMovimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(369, 342)
        Me.Controls.Add(Me.dgvDetalleMov)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.picLinea)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTerminarMovimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Terminar Operación"
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvDetalleMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblOp As System.Windows.Forms.Label
    Friend WithEvents lblNombCaja As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents lblCambiar As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblstrDesembolso As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDetalleMov As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents lblIDCaja As System.Windows.Forms.Label
    Friend WithEvents lblIDMov As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdTerminar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblDevolver As System.Windows.Forms.Label
    Friend WithEvents lblGastado As System.Windows.Forms.Label
    Friend WithEvents lblstrDevolver As System.Windows.Forms.Label
    Friend WithEvents lblstrGastado As System.Windows.Forms.Label
End Class
