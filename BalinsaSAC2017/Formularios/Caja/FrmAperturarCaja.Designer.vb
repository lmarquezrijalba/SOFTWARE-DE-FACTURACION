<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAperturarCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturarCaja))
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelCajas = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblFechaApertura = New System.Windows.Forms.Label()
        Me.cmdCalendario = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdListaUsuarios = New System.Windows.Forms.Button()
        Me.lblCodCajero = New System.Windows.Forms.Label()
        Me.lblNombCajero = New System.Windows.Forms.Label()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cmdRefrescar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panelSerie = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkActivar = New System.Windows.Forms.CheckBox()
        Me.txtDocumFin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDocumInic = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNroSerie = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtMontoinic_D = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMontoinic_S = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.panelSerie.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picLinea
        '
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(0, 61)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(608, 2)
        Me.picLinea.TabIndex = 131
        Me.picLinea.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(653, 60)
        Me.Panel1.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(459, 27)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Seleccione la caja a aperturar, su usuario , el monto  y el rango de la factura c" & _
    "on el que inicia."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "APERTURA DE CAJAS POR SERVICIO"
        '
        'panelCajas
        '
        Me.panelCajas.AutoScroll = True
        Me.panelCajas.BackColor = System.Drawing.Color.White
        Me.panelCajas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCajas.Location = New System.Drawing.Point(0, 119)
        Me.panelCajas.Name = "panelCajas"
        Me.panelCajas.Size = New System.Drawing.Size(653, 255)
        Me.panelCajas.TabIndex = 134
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEstado)
        Me.Panel2.Controls.Add(Me.lblFechaApertura)
        Me.Panel2.Controls.Add(Me.cmdCalendario)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.cmdListaUsuarios)
        Me.Panel2.Controls.Add(Me.lblCodCajero)
        Me.Panel2.Controls.Add(Me.lblNombCajero)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(653, 59)
        Me.Panel2.TabIndex = 133
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstado.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Green
        Me.lblEstado.Location = New System.Drawing.Point(108, 30)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(533, 21)
        Me.lblEstado.TabIndex = 55
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechaApertura
        '
        Me.lblFechaApertura.BackColor = System.Drawing.Color.White
        Me.lblFechaApertura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaApertura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFechaApertura.Location = New System.Drawing.Point(530, 5)
        Me.lblFechaApertura.Name = "lblFechaApertura"
        Me.lblFechaApertura.Size = New System.Drawing.Size(85, 21)
        Me.lblFechaApertura.TabIndex = 60
        Me.lblFechaApertura.Text = "14/12/2015"
        Me.lblFechaApertura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCalendario
        '
        Me.cmdCalendario.Font = New System.Drawing.Font("Bernard MT Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCalendario.Image = CType(resources.GetObject("cmdCalendario.Image"), System.Drawing.Image)
        Me.cmdCalendario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCalendario.Location = New System.Drawing.Point(617, 3)
        Me.cmdCalendario.Name = "cmdCalendario"
        Me.cmdCalendario.Size = New System.Drawing.Size(24, 24)
        Me.cmdCalendario.TabIndex = 59
        Me.cmdCalendario.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(432, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "FECHA APER.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 15)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "EST. CAJA :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 15)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "ENCARGADO :"
        '
        'cmdListaUsuarios
        '
        Me.cmdListaUsuarios.Font = New System.Drawing.Font("Bernard MT Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdListaUsuarios.Location = New System.Drawing.Point(182, 3)
        Me.cmdListaUsuarios.Name = "cmdListaUsuarios"
        Me.cmdListaUsuarios.Size = New System.Drawing.Size(24, 24)
        Me.cmdListaUsuarios.TabIndex = 1
        Me.cmdListaUsuarios.Text = "..."
        Me.cmdListaUsuarios.UseVisualStyleBackColor = True
        '
        'lblCodCajero
        '
        Me.lblCodCajero.BackColor = System.Drawing.Color.White
        Me.lblCodCajero.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodCajero.ForeColor = System.Drawing.Color.Black
        Me.lblCodCajero.Location = New System.Drawing.Point(108, 5)
        Me.lblCodCajero.Name = "lblCodCajero"
        Me.lblCodCajero.Size = New System.Drawing.Size(72, 21)
        Me.lblCodCajero.TabIndex = 37
        Me.lblCodCajero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombCajero
        '
        Me.lblNombCajero.BackColor = System.Drawing.SystemColors.Control
        Me.lblNombCajero.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombCajero.ForeColor = System.Drawing.Color.Gray
        Me.lblNombCajero.Location = New System.Drawing.Point(212, 9)
        Me.lblNombCajero.Name = "lblNombCajero"
        Me.lblNombCajero.Size = New System.Drawing.Size(214, 15)
        Me.lblNombCajero.TabIndex = 52
        Me.lblNombCajero.Text = "Sin seleccionar"
        Me.lblNombCajero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNuevo.Image = CType(resources.GetObject("cmdNuevo.Image"), System.Drawing.Image)
        Me.cmdNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNuevo.Location = New System.Drawing.Point(424, 72)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(122, 28)
        Me.cmdNuevo.TabIndex = 0
        Me.cmdNuevo.Text = "Crear Nueva Caja"
        Me.cmdNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdRefrescar
        '
        Me.cmdRefrescar.Font = New System.Drawing.Font("Bernard MT Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefrescar.Image = CType(resources.GetObject("cmdRefrescar.Image"), System.Drawing.Image)
        Me.cmdRefrescar.Location = New System.Drawing.Point(547, 72)
        Me.cmdRefrescar.Name = "cmdRefrescar"
        Me.cmdRefrescar.Size = New System.Drawing.Size(25, 28)
        Me.cmdRefrescar.TabIndex = 8
        Me.cmdRefrescar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.panelSerie)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.cmdNuevo)
        Me.Panel3.Controls.Add(Me.cmdCancelar)
        Me.Panel3.Controls.Add(Me.txtMontoinic_D)
        Me.Panel3.Controls.Add(Me.cmdRefrescar)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtMontoinic_S)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 374)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(653, 107)
        Me.Panel3.TabIndex = 132
        '
        'panelSerie
        '
        Me.panelSerie.Controls.Add(Me.Label9)
        Me.panelSerie.Controls.Add(Me.chkActivar)
        Me.panelSerie.Controls.Add(Me.txtDocumFin)
        Me.panelSerie.Controls.Add(Me.Label3)
        Me.panelSerie.Controls.Add(Me.txtDocumInic)
        Me.panelSerie.Controls.Add(Me.Label10)
        Me.panelSerie.Controls.Add(Me.txtNroSerie)
        Me.panelSerie.Controls.Add(Me.Label13)
        Me.panelSerie.Location = New System.Drawing.Point(3, 11)
        Me.panelSerie.Name = "panelSerie"
        Me.panelSerie.Size = New System.Drawing.Size(303, 49)
        Me.panelSerie.TabIndex = 147
        Me.panelSerie.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(3, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Serie Factura :"
        '
        'chkActivar
        '
        Me.chkActivar.AutoSize = True
        Me.chkActivar.Location = New System.Drawing.Point(81, 22)
        Me.chkActivar.Name = "chkActivar"
        Me.chkActivar.Size = New System.Drawing.Size(15, 14)
        Me.chkActivar.TabIndex = 66
        Me.chkActivar.UseVisualStyleBackColor = True
        '
        'txtDocumFin
        '
        Me.txtDocumFin.Enabled = False
        Me.txtDocumFin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumFin.Location = New System.Drawing.Point(211, 17)
        Me.txtDocumFin.MaxLength = 6
        Me.txtDocumFin.Name = "txtDocumFin"
        Me.txtDocumFin.Size = New System.Drawing.Size(61, 23)
        Me.txtDocumFin.TabIndex = 69
        Me.txtDocumFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(211, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Termina"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDocumInic
        '
        Me.txtDocumInic.Enabled = False
        Me.txtDocumInic.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumInic.Location = New System.Drawing.Point(149, 17)
        Me.txtDocumInic.MaxLength = 6
        Me.txtDocumInic.Name = "txtDocumInic"
        Me.txtDocumInic.Size = New System.Drawing.Size(61, 23)
        Me.txtDocumInic.TabIndex = 68
        Me.txtDocumInic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(150, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Inicia"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNroSerie
        '
        Me.txtNroSerie.Enabled = False
        Me.txtNroSerie.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroSerie.Location = New System.Drawing.Point(98, 17)
        Me.txtNroSerie.MaxLength = 4
        Me.txtNroSerie.Name = "txtNroSerie"
        Me.txtNroSerie.Size = New System.Drawing.Size(50, 23)
        Me.txtNroSerie.TabIndex = 67
        Me.txtNroSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(99, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 15)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Serie"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(650, 2)
        Me.PictureBox1.TabIndex = 146
        Me.PictureBox1.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(578, 72)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(63, 28)
        Me.cmdCancelar.TabIndex = 66
        Me.cmdCancelar.Text = "Cerrar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'txtMontoinic_D
        '
        Me.txtMontoinic_D.BackColor = System.Drawing.Color.White
        Me.txtMontoinic_D.Enabled = False
        Me.txtMontoinic_D.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoinic_D.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMontoinic_D.Location = New System.Drawing.Point(517, 37)
        Me.txtMontoinic_D.Name = "txtMontoinic_D"
        Me.txtMontoinic_D.Size = New System.Drawing.Size(124, 23)
        Me.txtMontoinic_D.TabIndex = 7
        Me.txtMontoinic_D.Text = "0.00"
        Me.txtMontoinic_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(392, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "APERT. DOLARES :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMontoinic_S
        '
        Me.txtMontoinic_S.BackColor = System.Drawing.Color.White
        Me.txtMontoinic_S.Enabled = False
        Me.txtMontoinic_S.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoinic_S.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMontoinic_S.Location = New System.Drawing.Point(517, 8)
        Me.txtMontoinic_S.Name = "txtMontoinic_S"
        Me.txtMontoinic_S.Size = New System.Drawing.Size(124, 23)
        Me.txtMontoinic_S.TabIndex = 6
        Me.txtMontoinic_S.Text = "0.00"
        Me.txtMontoinic_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(406, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "APERT. SOLES :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmAperturarCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 481)
        Me.Controls.Add(Me.panelCajas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.picLinea)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAperturarCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aperturar Caja"
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.panelSerie.ResumeLayout(False)
        Me.panelSerie.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panelCajas As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCalendario As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblNombCajero As System.Windows.Forms.Label
    Friend WithEvents lblCodCajero As System.Windows.Forms.Label
    Friend WithEvents cmdListaUsuarios As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMontoinic_S As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaApertura As System.Windows.Forms.Label
    Friend WithEvents cmdRefrescar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMontoinic_D As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents panelSerie As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkActivar As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocumFin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDocumInic As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNroSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
