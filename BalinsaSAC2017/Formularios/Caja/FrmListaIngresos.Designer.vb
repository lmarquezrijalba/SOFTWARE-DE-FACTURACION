<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaIngresos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaIngresos))
        Me.dgvDetalleIngresos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTextoEncabezado = New System.Windows.Forms.Label()
        Me.lblNombreCaja = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCodCaja = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblQueda_Dol = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.lblQueda_Sol = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboRango = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboAnio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        CType(Me.dgvDetalleIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDetalleIngresos
        '
        Me.dgvDetalleIngresos.AllowUserToAddRows = False
        Me.dgvDetalleIngresos.AllowUserToDeleteRows = False
        Me.dgvDetalleIngresos.BackgroundColor = System.Drawing.Color.Gray
        Me.dgvDetalleIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleIngresos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5, Me.Column4, Me.Column3, Me.Column6, Me.Column7, Me.Column8})
        Me.dgvDetalleIngresos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleIngresos.EnableHeadersVisualStyles = False
        Me.dgvDetalleIngresos.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvDetalleIngresos.Location = New System.Drawing.Point(0, 60)
        Me.dgvDetalleIngresos.Name = "dgvDetalleIngresos"
        Me.dgvDetalleIngresos.ReadOnly = True
        Me.dgvDetalleIngresos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvDetalleIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleIngresos.Size = New System.Drawing.Size(745, 264)
        Me.dgvDetalleIngresos.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Nro. Ope."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Proveniente"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 240
        '
        'Column5
        '
        Me.Column5.Frozen = True
        Me.Column5.HeaderText = "Detalle"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 480
        '
        'Column4
        '
        Me.Column4.Frozen = True
        Me.Column4.HeaderText = "Concepto"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 185
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Fecha"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column6
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "Importe S/."
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column7.Frozen = True
        Me.Column7.HeaderText = "Importe $."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column8.Frozen = True
        Me.Column8.HeaderText = "Estado"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 60)
        Me.Panel1.TabIndex = 129
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblTextoEncabezado)
        Me.Panel2.Controls.Add(Me.lblNombreCaja)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblCodCaja)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(353, 60)
        Me.Panel2.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(52, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "LISTA DE INGRESOS REGISTRADOS EN"
        '
        'lblTextoEncabezado
        '
        Me.lblTextoEncabezado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoEncabezado.Location = New System.Drawing.Point(58, 27)
        Me.lblTextoEncabezado.Name = "lblTextoEncabezado"
        Me.lblTextoEncabezado.Size = New System.Drawing.Size(604, 27)
        Me.lblTextoEncabezado.TabIndex = 134
        Me.lblTextoEncabezado.Text = "Lista todos los ingresos realizados, pudiendo visualizarlos por semanas o por mes" & _
    ". Selecciona la frecuencia por la que deseas filtrar para mostrar los registros." & _
    ""
        '
        'lblNombreCaja
        '
        Me.lblNombreCaja.AutoSize = True
        Me.lblNombreCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCaja.ForeColor = System.Drawing.Color.Gray
        Me.lblNombreCaja.Location = New System.Drawing.Point(264, 7)
        Me.lblNombreCaja.Name = "lblNombreCaja"
        Me.lblNombreCaja.Size = New System.Drawing.Size(36, 13)
        Me.lblNombreCaja.TabIndex = 29
        Me.lblNombreCaja.Text = "CAJA"
        Me.lblNombreCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 48)
        Me.PictureBox1.TabIndex = 132
        Me.PictureBox1.TabStop = False
        '
        'lblCodCaja
        '
        Me.lblCodCaja.ForeColor = System.Drawing.Color.Red
        Me.lblCodCaja.Location = New System.Drawing.Point(544, 6)
        Me.lblCodCaja.Name = "lblCodCaja"
        Me.lblCodCaja.Size = New System.Drawing.Size(36, 13)
        Me.lblCodCaja.TabIndex = 28
        Me.lblCodCaja.Text = "ID"
        Me.lblCodCaja.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.lblQueda_Dol)
        Me.Panel5.Controls.Add(Me.lblCaja)
        Me.Panel5.Controls.Add(Me.lblQueda_Sol)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(353, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(363, 60)
        Me.Panel5.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "SALDO CAJA $."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblQueda_Dol
        '
        Me.lblQueda_Dol.BackColor = System.Drawing.Color.Transparent
        Me.lblQueda_Dol.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueda_Dol.ForeColor = System.Drawing.Color.Brown
        Me.lblQueda_Dol.Location = New System.Drawing.Point(7, 29)
        Me.lblQueda_Dol.Name = "lblQueda_Dol"
        Me.lblQueda_Dol.Size = New System.Drawing.Size(171, 27)
        Me.lblQueda_Dol.TabIndex = 34
        Me.lblQueda_Dol.Text = "0,00"
        Me.lblQueda_Dol.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(189, 19)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(171, 13)
        Me.lblCaja.TabIndex = 33
        Me.lblCaja.Text = "SALDO CAJA S/."
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblQueda_Sol
        '
        Me.lblQueda_Sol.BackColor = System.Drawing.Color.Transparent
        Me.lblQueda_Sol.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueda_Sol.ForeColor = System.Drawing.Color.Brown
        Me.lblQueda_Sol.Location = New System.Drawing.Point(184, 29)
        Me.lblQueda_Sol.Name = "lblQueda_Sol"
        Me.lblQueda_Sol.Size = New System.Drawing.Size(176, 27)
        Me.lblQueda_Sol.TabIndex = 32
        Me.lblQueda_Sol.Text = "0,00"
        Me.lblQueda_Sol.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Location = New System.Drawing.Point(716, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 60)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "I"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(105, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Frecuencia"
        '
        'cboRango
        '
        Me.cboRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRango.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboRango.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRango.FormattingEnabled = True
        Me.cboRango.Items.AddRange(New Object() {"Mes", "Semanas"})
        Me.cboRango.Location = New System.Drawing.Point(179, 11)
        Me.cboRango.Name = "cboRango"
        Me.cboRango.Size = New System.Drawing.Size(116, 24)
        Me.cboRango.TabIndex = 27
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 324)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(745, 48)
        Me.Panel4.TabIndex = 132
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.cboAnio)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.cmdCerrar)
        Me.Panel3.Controls.Add(Me.cboRango)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(367, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(378, 48)
        Me.Panel3.TabIndex = 131
        '
        'cboAnio
        '
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAnio.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.FormattingEnabled = True
        Me.cboAnio.Items.AddRange(New Object() {"Semanas", "Mes"})
        Me.cboAnio.Location = New System.Drawing.Point(39, 12)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(60, 24)
        Me.cboAnio.TabIndex = 131
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Año"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(301, 8)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(66, 28)
        Me.cmdCerrar.TabIndex = 130
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'FrmListaIngresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 372)
        Me.Controls.Add(Me.dgvDetalleIngresos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmListaIngresos"
        Me.Text = "Lista de ingresos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvDetalleIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDetalleIngresos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboRango As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreCaja As System.Windows.Forms.Label
    Friend WithEvents lblCodCaja As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblQueda_Dol As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblQueda_Sol As System.Windows.Forms.Label
    Friend WithEvents cboAnio As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTextoEncabezado As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
