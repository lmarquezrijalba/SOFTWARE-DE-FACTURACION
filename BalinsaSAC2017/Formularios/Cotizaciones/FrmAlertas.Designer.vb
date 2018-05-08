<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAlertas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlertas))
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblDescSeguim = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tmrReactivar = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCliente.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.White
        Me.lblCliente.Location = New System.Drawing.Point(60, 35)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(214, 33)
        Me.lblCliente.TabIndex = 10
        Me.lblCliente.Text = "SR. XXXXXXXXXX XXXXXX XXXXXX XXXX"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescSeguim
        '
        Me.lblDescSeguim.BackColor = System.Drawing.Color.Transparent
        Me.lblDescSeguim.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescSeguim.ForeColor = System.Drawing.Color.Linen
        Me.lblDescSeguim.Location = New System.Drawing.Point(12, 68)
        Me.lblDescSeguim.Name = "lblDescSeguim"
        Me.lblDescSeguim.Size = New System.Drawing.Size(262, 71)
        Me.lblDescSeguim.TabIndex = 6
        Me.lblDescSeguim.Text = "Aqui se mostraran todas las alertas programadas por el usario del sistema y se po" & _
    "dran programar diariamente, semanalmente, mensualmente o seleccionar los dias de" & _
    " aviso."
        Me.lblDescSeguim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(2, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 43)
        Me.Label5.TabIndex = 9
        '
        'lblClose
        '
        Me.lblClose.BackColor = System.Drawing.Color.White
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Image = CType(resources.GetObject("lblClose.Image"), System.Drawing.Image)
        Me.lblClose.Location = New System.Drawing.Point(260, 1)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(24, 21)
        Me.lblClose.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(-1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(288, 22)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Nuevo Seguimiento Detectado"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrReactivar
        '
        '
        'FrmAlertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Coral
        Me.ClientSize = New System.Drawing.Size(286, 148)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.lblDescSeguim)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAlertas"
        Me.Text = "Aviso"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblDescSeguim As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tmrReactivar As System.Windows.Forms.Timer
End Class
