<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigActualizaSistema
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigActualizaSistema))
        Me.lblRutaInst_O = New System.Windows.Forms.Label()
        Me.cmdRutaOrigen = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdAplicar = New System.Windows.Forms.Button()
        Me.picLineaB = New System.Windows.Forms.PictureBox()
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCarpeta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkLanzarActualizacion = New System.Windows.Forms.CheckBox()
        CType(Me.picLineaB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRutaInst_O
        '
        Me.lblRutaInst_O.BackColor = System.Drawing.Color.White
        Me.lblRutaInst_O.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaInst_O.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRutaInst_O.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaInst_O.Location = New System.Drawing.Point(115, 110)
        Me.lblRutaInst_O.Name = "lblRutaInst_O"
        Me.lblRutaInst_O.Size = New System.Drawing.Size(306, 22)
        Me.lblRutaInst_O.TabIndex = 50
        Me.lblRutaInst_O.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRutaOrigen
        '
        Me.cmdRutaOrigen.BackColor = System.Drawing.SystemColors.Info
        Me.cmdRutaOrigen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRutaOrigen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRutaOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdRutaOrigen.Location = New System.Drawing.Point(423, 110)
        Me.cmdRutaOrigen.Name = "cmdRutaOrigen"
        Me.cmdRutaOrigen.Size = New System.Drawing.Size(22, 22)
        Me.cmdRutaOrigen.TabIndex = 1
        Me.cmdRutaOrigen.Text = "...."
        Me.cmdRutaOrigen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(5, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Origen del instalador"
        '
        'txtVersion
        '
        Me.txtVersion.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersion.Location = New System.Drawing.Point(115, 78)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(161, 22)
        Me.txtVersion.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(5, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Versión disponible"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Location = New System.Drawing.Point(385, 247)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(60, 25)
        Me.cmdCerrar.TabIndex = 4
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdAplicar
        '
        Me.cmdAplicar.Location = New System.Drawing.Point(285, 247)
        Me.cmdAplicar.Name = "cmdAplicar"
        Me.cmdAplicar.Size = New System.Drawing.Size(99, 25)
        Me.cmdAplicar.TabIndex = 3
        Me.cmdAplicar.Text = "Aplicar cambios"
        Me.cmdAplicar.UseVisualStyleBackColor = True
        '
        'picLineaB
        '
        Me.picLineaB.Image = CType(resources.GetObject("picLineaB.Image"), System.Drawing.Image)
        Me.picLineaB.Location = New System.Drawing.Point(-1, 239)
        Me.picLineaB.Name = "picLineaB"
        Me.picLineaB.Size = New System.Drawing.Size(500, 2)
        Me.picLineaB.TabIndex = 51
        Me.picLineaB.TabStop = False
        '
        'picLinea
        '
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(0, 61)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(500, 2)
        Me.picLinea.TabIndex = 53
        Me.picLinea.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 60)
        Me.Panel1.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Ingrese los datos de conexión actualización del sistema" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Configuración de actualización del sistema"
        '
        'picImagen
        '
        Me.picImagen.Image = CType(resources.GetObject("picImagen.Image"), System.Drawing.Image)
        Me.picImagen.Location = New System.Drawing.Point(8, 8)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(45, 45)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 15
        Me.picImagen.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(5, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Carpeta Destino"
        '
        'txtCarpeta
        '
        Me.txtCarpeta.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarpeta.Location = New System.Drawing.Point(115, 144)
        Me.txtCarpeta.Name = "txtCarpeta"
        Me.txtCarpeta.Size = New System.Drawing.Size(330, 22)
        Me.txtCarpeta.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(280, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 22)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Ingrese la versiòn que estarà disponible para los usuarios."
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(113, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(332, 40)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Ingrese la carpeta donde se descargar el instalador"
        '
        'chkLanzarActualizacion
        '
        Me.chkLanzarActualizacion.AutoSize = True
        Me.chkLanzarActualizacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLanzarActualizacion.Location = New System.Drawing.Point(322, 212)
        Me.chkLanzarActualizacion.Name = "chkLanzarActualizacion"
        Me.chkLanzarActualizacion.Size = New System.Drawing.Size(123, 17)
        Me.chkLanzarActualizacion.TabIndex = 58
        Me.chkLanzarActualizacion.Text = "Lanzar Actualización"
        Me.chkLanzarActualizacion.UseVisualStyleBackColor = True
        '
        'FrmConfigActualizaSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 284)
        Me.Controls.Add(Me.chkLanzarActualizacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCarpeta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.picLinea)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picLineaB)
        Me.Controls.Add(Me.lblRutaInst_O)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdAplicar)
        Me.Controls.Add(Me.cmdRutaOrigen)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfigActualizaSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización del sistema"
        CType(Me.picLineaB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRutaInst_O As System.Windows.Forms.Label
    Friend WithEvents cmdRutaOrigen As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdAplicar As System.Windows.Forms.Button
    Friend WithEvents picLineaB As System.Windows.Forms.PictureBox
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCarpeta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkLanzarActualizacion As System.Windows.Forms.CheckBox
End Class
