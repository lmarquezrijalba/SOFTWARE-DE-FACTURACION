<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistrarMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrarMovimientos))
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.cmdConceptos = New System.Windows.Forms.Button()
        Me.cboCajasNoPrincipales = New System.Windows.Forms.ComboBox()
        Me.cboConceptos = New System.Windows.Forms.ComboBox()
        Me.lblSeleotorga = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.cboRecibidor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optDolares = New System.Windows.Forms.RadioButton()
        Me.optSoles = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.panelEstado = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.lblstrMoneda = New System.Windows.Forms.Label()
        Me.lblCodCaja = New System.Windows.Forms.Label()
        Me.lblCambiar = New System.Windows.Forms.Label()
        Me.lblNomRespCaja = New System.Windows.Forms.Label()
        Me.lblNombCaja = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.cmdRegistrar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalCaja_Dolares = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalCaja_Soles = New System.Windows.Forms.Label()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        Me.panelEstado.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'picLinea
        '
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(0, 61)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(750, 2)
        Me.picLinea.TabIndex = 24
        Me.picLinea.TabStop = False
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.cmdConceptos)
        Me.gbEstado.Controls.Add(Me.cboCajasNoPrincipales)
        Me.gbEstado.Controls.Add(Me.cboConceptos)
        Me.gbEstado.Controls.Add(Me.lblSeleotorga)
        Me.gbEstado.Controls.Add(Me.txtObservacion)
        Me.gbEstado.Controls.Add(Me.cboRecibidor)
        Me.gbEstado.Controls.Add(Me.Label3)
        Me.gbEstado.Controls.Add(Me.Label1)
        Me.gbEstado.Controls.Add(Me.optDolares)
        Me.gbEstado.Controls.Add(Me.optSoles)
        Me.gbEstado.Controls.Add(Me.Label7)
        Me.gbEstado.Location = New System.Drawing.Point(8, 69)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(565, 188)
        Me.gbEstado.TabIndex = 26
        Me.gbEstado.TabStop = False
        '
        'cmdConceptos
        '
        Me.cmdConceptos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdConceptos.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConceptos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConceptos.Location = New System.Drawing.Point(266, 16)
        Me.cmdConceptos.Name = "cmdConceptos"
        Me.cmdConceptos.Size = New System.Drawing.Size(24, 24)
        Me.cmdConceptos.TabIndex = 145
        Me.cmdConceptos.Text = "..."
        Me.cmdConceptos.UseVisualStyleBackColor = True
        '
        'cboCajasNoPrincipales
        '
        Me.cboCajasNoPrincipales.BackColor = System.Drawing.Color.White
        Me.cboCajasNoPrincipales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCajasNoPrincipales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCajasNoPrincipales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajasNoPrincipales.FormattingEnabled = True
        Me.cboCajasNoPrincipales.Items.AddRange(New Object() {"Seleccione colaborador"})
        Me.cboCajasNoPrincipales.Location = New System.Drawing.Point(373, 17)
        Me.cboCajasNoPrincipales.Name = "cboCajasNoPrincipales"
        Me.cboCajasNoPrincipales.Size = New System.Drawing.Size(179, 21)
        Me.cboCajasNoPrincipales.TabIndex = 145
        Me.cboCajasNoPrincipales.Visible = False
        '
        'cboConceptos
        '
        Me.cboConceptos.BackColor = System.Drawing.Color.White
        Me.cboConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConceptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConceptos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConceptos.FormattingEnabled = True
        Me.cboConceptos.Items.AddRange(New Object() {"Seleccione colaborador"})
        Me.cboConceptos.Location = New System.Drawing.Point(108, 17)
        Me.cboConceptos.Name = "cboConceptos"
        Me.cboConceptos.Size = New System.Drawing.Size(156, 21)
        Me.cboConceptos.TabIndex = 4
        '
        'lblSeleotorga
        '
        Me.lblSeleotorga.AutoSize = True
        Me.lblSeleotorga.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleotorga.ForeColor = System.Drawing.Color.Black
        Me.lblSeleotorga.Location = New System.Drawing.Point(293, 20)
        Me.lblSeleotorga.Name = "lblSeleotorga"
        Me.lblSeleotorga.Size = New System.Drawing.Size(74, 13)
        Me.lblSeleotorga.TabIndex = 132
        Me.lblSeleotorga.Text = "Se le otorga a"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(108, 44)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(444, 85)
        Me.txtObservacion.TabIndex = 6
        '
        'cboRecibidor
        '
        Me.cboRecibidor.BackColor = System.Drawing.Color.White
        Me.cboRecibidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecibidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRecibidor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecibidor.FormattingEnabled = True
        Me.cboRecibidor.Items.AddRange(New Object() {"Seleccione colaborador"})
        Me.cboRecibidor.Location = New System.Drawing.Point(373, 17)
        Me.cboRecibidor.Name = "cboRecibidor"
        Me.cboRecibidor.Size = New System.Drawing.Size(179, 21)
        Me.cboRecibidor.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Detalle Movim."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Tipo de Moneda"
        '
        'optDolares
        '
        Me.optDolares.AutoSize = True
        Me.optDolares.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDolares.ForeColor = System.Drawing.Color.Gray
        Me.optDolares.Location = New System.Drawing.Point(108, 161)
        Me.optDolares.Name = "optDolares"
        Me.optDolares.Size = New System.Drawing.Size(119, 17)
        Me.optDolares.TabIndex = 3
        Me.optDolares.TabStop = True
        Me.optDolares.Text = "Dólares Americanos"
        Me.optDolares.UseVisualStyleBackColor = True
        '
        'optSoles
        '
        Me.optSoles.AutoSize = True
        Me.optSoles.Checked = True
        Me.optSoles.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSoles.ForeColor = System.Drawing.Color.Gray
        Me.optSoles.Location = New System.Drawing.Point(108, 138)
        Me.optSoles.Name = "optSoles"
        Me.optSoles.Size = New System.Drawing.Size(89, 17)
        Me.optSoles.TabIndex = 2
        Me.optSoles.TabStop = True
        Me.optSoles.Text = "Nuevos Soles"
        Me.optSoles.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(15, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Por Concepto de"
        '
        'panelEstado
        '
        Me.panelEstado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelEstado.Controls.Add(Me.Label2)
        Me.panelEstado.Controls.Add(Me.txtImporte)
        Me.panelEstado.Controls.Add(Me.lblstrMoneda)
        Me.panelEstado.Location = New System.Drawing.Point(386, 263)
        Me.panelEstado.Name = "panelEstado"
        Me.panelEstado.Size = New System.Drawing.Size(187, 52)
        Me.panelEstado.TabIndex = 140
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 13)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "verifique tipo moneda"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporte
        '
        Me.txtImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtImporte.Location = New System.Drawing.Point(74, 23)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(104, 21)
        Me.txtImporte.TabIndex = 7
        Me.txtImporte.Text = "0,00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblstrMoneda
        '
        Me.lblstrMoneda.BackColor = System.Drawing.Color.Transparent
        Me.lblstrMoneda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstrMoneda.ForeColor = System.Drawing.Color.Black
        Me.lblstrMoneda.Location = New System.Drawing.Point(3, 26)
        Me.lblstrMoneda.Name = "lblstrMoneda"
        Me.lblstrMoneda.Size = New System.Drawing.Size(65, 13)
        Me.lblstrMoneda.TabIndex = 129
        Me.lblstrMoneda.Text = "Monto S/."
        Me.lblstrMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodCaja
        '
        Me.lblCodCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodCaja.ForeColor = System.Drawing.Color.Green
        Me.lblCodCaja.Location = New System.Drawing.Point(541, 63)
        Me.lblCodCaja.Name = "lblCodCaja"
        Me.lblCodCaja.Size = New System.Drawing.Size(32, 13)
        Me.lblCodCaja.TabIndex = 143
        Me.lblCodCaja.Text = "4887788"
        Me.lblCodCaja.Visible = False
        '
        'lblCambiar
        '
        Me.lblCambiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCambiar.Image = CType(resources.GetObject("lblCambiar.Image"), System.Drawing.Image)
        Me.lblCambiar.Location = New System.Drawing.Point(528, 0)
        Me.lblCambiar.Name = "lblCambiar"
        Me.lblCambiar.Size = New System.Drawing.Size(53, 57)
        Me.lblCambiar.TabIndex = 142
        '
        'lblNomRespCaja
        '
        Me.lblNomRespCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblNomRespCaja.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomRespCaja.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lblNomRespCaja.Location = New System.Drawing.Point(277, 32)
        Me.lblNomRespCaja.Name = "lblNomRespCaja"
        Me.lblNomRespCaja.Size = New System.Drawing.Size(254, 13)
        Me.lblNomRespCaja.TabIndex = 137
        Me.lblNomRespCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNombCaja
        '
        Me.lblNombCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblNombCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombCaja.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lblNombCaja.Location = New System.Drawing.Point(274, 17)
        Me.lblNombCaja.Name = "lblNombCaja"
        Me.lblNombCaja.Size = New System.Drawing.Size(257, 13)
        Me.lblNombCaja.TabIndex = 133
        Me.lblNombCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 322)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(608, 2)
        Me.PictureBox1.TabIndex = 111
        Me.PictureBox1.TabStop = False
        '
        'cmdListar
        '
        Me.cmdListar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdListar.Image = CType(resources.GetObject("cmdListar.Image"), System.Drawing.Image)
        Me.cmdListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdListar.Location = New System.Drawing.Point(14, 330)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(133, 28)
        Me.cmdListar.TabIndex = 10
        Me.cmdListar.Text = "Lista de movimientos"
        Me.cmdListar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'cmdRegistrar
        '
        Me.cmdRegistrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRegistrar.Image = CType(resources.GetObject("cmdRegistrar.Image"), System.Drawing.Image)
        Me.cmdRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRegistrar.Location = New System.Drawing.Point(400, 330)
        Me.cmdRegistrar.Name = "cmdRegistrar"
        Me.cmdRegistrar.Size = New System.Drawing.Size(106, 28)
        Me.cmdRegistrar.TabIndex = 8
        Me.cmdRegistrar.Text = "Registrar Mov."
        Me.cmdRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRegistrar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(507, 330)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(66, 28)
        Me.cmdCerrar.TabIndex = 9
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.lblCambiar)
        Me.Panel2.Controls.Add(Me.lblNomRespCaja)
        Me.Panel2.Controls.Add(Me.lblTotalCaja_Dolares)
        Me.Panel2.Controls.Add(Me.lblNombCaja)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblTotalCaja_Soles)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 60)
        Me.Panel2.TabIndex = 144
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(132, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "TOTAL DOLARES :"
        '
        'lblTotalCaja_Dolares
        '
        Me.lblTotalCaja_Dolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCaja_Dolares.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalCaja_Dolares.Location = New System.Drawing.Point(132, 19)
        Me.lblTotalCaja_Dolares.Name = "lblTotalCaja_Dolares"
        Me.lblTotalCaja_Dolares.Size = New System.Drawing.Size(122, 26)
        Me.lblTotalCaja_Dolares.TabIndex = 148
        Me.lblTotalCaja_Dolares.Text = "0,00"
        Me.lblTotalCaja_Dolares.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "TOTAL SOLES :"
        '
        'lblTotalCaja_Soles
        '
        Me.lblTotalCaja_Soles.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCaja_Soles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalCaja_Soles.Location = New System.Drawing.Point(4, 19)
        Me.lblTotalCaja_Soles.Name = "lblTotalCaja_Soles"
        Me.lblTotalCaja_Soles.Size = New System.Drawing.Size(122, 26)
        Me.lblTotalCaja_Soles.TabIndex = 147
        Me.lblTotalCaja_Soles.Text = "0,00"
        Me.lblTotalCaja_Soles.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'FrmRegistrarMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 365)
        Me.Controls.Add(Me.lblCodCaja)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.panelEstado)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.cmdRegistrar)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.picLinea)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistrarMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Movimientos"
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.panelEstado.ResumeLayout(False)
        Me.panelEstado.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cboRecibidor As System.Windows.Forms.ComboBox
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents cmdRegistrar As System.Windows.Forms.Button
    Friend WithEvents optDolares As System.Windows.Forms.RadioButton
    Friend WithEvents optSoles As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblstrMoneda As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents lblSeleotorga As System.Windows.Forms.Label
    Friend WithEvents cboConceptos As System.Windows.Forms.ComboBox
    Friend WithEvents panelEstado As System.Windows.Forms.Panel
    Friend WithEvents lblNomRespCaja As System.Windows.Forms.Label
    Friend WithEvents lblNombCaja As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCambiar As System.Windows.Forms.Label
    Friend WithEvents lblCodCaja As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCaja_Dolares As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCaja_Soles As System.Windows.Forms.Label
    Friend WithEvents cboCajasNoPrincipales As System.Windows.Forms.ComboBox
    Friend WithEvents cmdConceptos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
