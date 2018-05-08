<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroContactos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroContactos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picTarjeta = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmdAñadir = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ofdAbrir = New System.Windows.Forms.OpenFileDialog()
        Me.lblIDContacto = New System.Windows.Forms.Label()
        Me.lblFilaSelec = New System.Windows.Forms.Label()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(389, 60)
        Me.Panel1.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(67, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(296, 27)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Ingrese todos los datos del contacto al cual quiere hacer referencia, luego pulse" & _
    " sobre el botón Guardar."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(60, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(174, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "INGRESO DE NUEVO CONTACTO"
        '
        'picImagen
        '
        Me.picImagen.Image = CType(resources.GetObject("picImagen.Image"), System.Drawing.Image)
        Me.picImagen.Location = New System.Drawing.Point(8, 8)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(45, 45)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 14
        Me.picImagen.TabStop = False
        '
        'picLinea
        '
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(0, 61)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(425, 2)
        Me.picLinea.TabIndex = 26
        Me.picLinea.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Contacto"
        '
        'txtContacto
        '
        Me.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContacto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContacto.Location = New System.Drawing.Point(80, 153)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(297, 21)
        Me.txtContacto.TabIndex = 0
        '
        'txtCargo
        '
        Me.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargo.Location = New System.Drawing.Point(80, 179)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(297, 21)
        Me.txtCargo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Cargo"
        '
        'txtFono
        '
        Me.txtFono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFono.Location = New System.Drawing.Point(80, 205)
        Me.txtFono.Multiline = True
        Me.txtFono.Name = "txtFono"
        Me.txtFono.Size = New System.Drawing.Size(297, 28)
        Me.txtFono.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Telefono"
        '
        'txtCorreo
        '
        Me.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCorreo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorreo.Location = New System.Drawing.Point(80, 239)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(297, 21)
        Me.txtCorreo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Correo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 324)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(425, 2)
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'picTarjeta
        '
        Me.picTarjeta.BackColor = System.Drawing.Color.White
        Me.picTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTarjeta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picTarjeta.Image = CType(resources.GetObject("picTarjeta.Image"), System.Drawing.Image)
        Me.picTarjeta.Location = New System.Drawing.Point(240, 69)
        Me.picTarjeta.Name = "picTarjeta"
        Me.picTarjeta.Size = New System.Drawing.Size(119, 68)
        Me.picTarjeta.TabIndex = 37
        Me.picTarjeta.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(229, 68)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Si desea agregar una tarjeta de presentación del contacto. Por favor posicione el" & _
    " puntero del mouse sobre la tarjeta mostrada y precione click, luego seleccione " & _
    "la imagen deseada."
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(313, 332)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(64, 28)
        Me.cmdCerrar.TabIndex = 6
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(0, 143)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(425, 2)
        Me.PictureBox3.TabIndex = 41
        Me.PictureBox3.TabStop = False
        '
        'cmdAñadir
        '
        Me.cmdAñadir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAñadir.Image = CType(resources.GetObject("cmdAñadir.Image"), System.Drawing.Image)
        Me.cmdAñadir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAñadir.Location = New System.Drawing.Point(207, 332)
        Me.cmdAñadir.Name = "cmdAñadir"
        Me.cmdAñadir.Size = New System.Drawing.Size(105, 28)
        Me.cmdAñadir.TabIndex = 5
        Me.cmdAñadir.Text = "Actualizar datos"
        Me.cmdAñadir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAñadir.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(80, 266)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(297, 49)
        Me.txtObservacion.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 284)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Observ."
        '
        'ofdAbrir
        '
        Me.ofdAbrir.FileName = "OpenFileDialog1"
        '
        'lblIDContacto
        '
        Me.lblIDContacto.AutoSize = True
        Me.lblIDContacto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDContacto.Location = New System.Drawing.Point(8, 332)
        Me.lblIDContacto.Name = "lblIDContacto"
        Me.lblIDContacto.Size = New System.Drawing.Size(62, 13)
        Me.lblIDContacto.TabIndex = 44
        Me.lblIDContacto.Text = "IDContacto"
        Me.lblIDContacto.Visible = False
        '
        'lblFilaSelec
        '
        Me.lblFilaSelec.AutoSize = True
        Me.lblFilaSelec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilaSelec.Location = New System.Drawing.Point(8, 347)
        Me.lblFilaSelec.Name = "lblFilaSelec"
        Me.lblFilaSelec.Size = New System.Drawing.Size(46, 13)
        Me.lblFilaSelec.TabIndex = 45
        Me.lblFilaSelec.Text = "filaSelec"
        Me.lblFilaSelec.Visible = False
        '
        'lblZoom
        '
        Me.lblZoom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblZoom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZoom.Image = CType(resources.GetObject("lblZoom.Image"), System.Drawing.Image)
        Me.lblZoom.Location = New System.Drawing.Point(360, 117)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(23, 20)
        Me.lblZoom.TabIndex = 46
        '
        'FrmRegistroContactos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 369)
        Me.Controls.Add(Me.lblFilaSelec)
        Me.Controls.Add(Me.lblIDContacto)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdAñadir)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.picTarjeta)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCargo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picLinea)
        Me.Controls.Add(Me.lblZoom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistroContactos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos del contacto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents picTarjeta As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdAñadir As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ofdAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblIDContacto As System.Windows.Forms.Label
    Friend WithEvents lblFilaSelec As System.Windows.Forms.Label
    Friend WithEvents lblZoom As System.Windows.Forms.Label
End Class
