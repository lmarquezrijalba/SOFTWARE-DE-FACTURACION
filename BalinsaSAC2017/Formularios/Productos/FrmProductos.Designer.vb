<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblIDProducto = New System.Windows.Forms.Label()
        Me.lblIDCategoria = New System.Windows.Forms.Label()
        Me.lblNroCodBarras = New System.Windows.Forms.Label()
        Me.lblCodBarras = New System.Windows.Forms.Label()
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.picFotografia = New System.Windows.Forms.PictureBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblImagen = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEspecif = New System.Windows.Forms.TextBox()
        Me.cmdMarcas = New System.Windows.Forms.Label()
        Me.txtDscto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.ofdAbrir = New System.Windows.Forms.OpenFileDialog()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cboTipoBalanza = New System.Windows.Forms.ComboBox()
        Me.cboEstructura = New System.Windows.Forms.ComboBox()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.LblMarca = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.LblModelo = New System.Windows.Forms.Label()
        Me.TxtMedidas = New System.Windows.Forms.TextBox()
        Me.BtnVistaPrevia = New System.Windows.Forms.Button()
        Me.cboTipoEstructura = New System.Windows.Forms.ComboBox()
        Me.LblEstructura = New System.Windows.Forms.Label()
        Me.LblMedidas = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFotografia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 60)
        Me.Panel1.TabIndex = 19
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(10, 8)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(49, 45)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 18
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(72, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(206, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Ingrese los datos del producto a registrar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(65, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Registrar Nuevo Producto"
        '
        'lblIDProducto
        '
        Me.lblIDProducto.ForeColor = System.Drawing.Color.Red
        Me.lblIDProducto.Location = New System.Drawing.Point(563, 371)
        Me.lblIDProducto.Name = "lblIDProducto"
        Me.lblIDProducto.Size = New System.Drawing.Size(81, 13)
        Me.lblIDProducto.TabIndex = 168
        Me.lblIDProducto.Text = "IDProducto"
        Me.lblIDProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIDProducto.Visible = False
        '
        'lblIDCategoria
        '
        Me.lblIDCategoria.ForeColor = System.Drawing.Color.Red
        Me.lblIDCategoria.Location = New System.Drawing.Point(624, 370)
        Me.lblIDCategoria.Name = "lblIDCategoria"
        Me.lblIDCategoria.Size = New System.Drawing.Size(81, 13)
        Me.lblIDCategoria.TabIndex = 167
        Me.lblIDCategoria.Text = "IDCategoria"
        Me.lblIDCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIDCategoria.Visible = False
        '
        'lblNroCodBarras
        '
        Me.lblNroCodBarras.BackColor = System.Drawing.Color.White
        Me.lblNroCodBarras.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroCodBarras.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblNroCodBarras.Location = New System.Drawing.Point(518, 103)
        Me.lblNroCodBarras.Name = "lblNroCodBarras"
        Me.lblNroCodBarras.Size = New System.Drawing.Size(188, 15)
        Me.lblNroCodBarras.TabIndex = 152
        Me.lblNroCodBarras.Text = "COD. BARRAS"
        Me.lblNroCodBarras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCodBarras
        '
        Me.lblCodBarras.BackColor = System.Drawing.Color.White
        Me.lblCodBarras.Font = New System.Drawing.Font("Bar-Code 39", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lblCodBarras.Location = New System.Drawing.Point(518, 63)
        Me.lblCodBarras.Name = "lblCodBarras"
        Me.lblCodBarras.Size = New System.Drawing.Size(188, 40)
        Me.lblCodBarras.TabIndex = 151
        Me.lblCodBarras.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picLinea
        '
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(0, 61)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(720, 2)
        Me.picLinea.TabIndex = 18
        Me.picLinea.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Categoria seleccionada"
        '
        'LblTipo
        '
        Me.LblTipo.AutoSize = True
        Me.LblTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo.Location = New System.Drawing.Point(278, 96)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(34, 13)
        Me.LblTipo.TabIndex = 25
        Me.LblTipo.Text = "Tipo :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Producto :"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 132)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(720, 2)
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'txtProducto
        '
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(73, 195)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProducto.Size = New System.Drawing.Size(438, 21)
        Me.txtProducto.TabIndex = 4
        '
        'picFotografia
        '
        Me.picFotografia.BackColor = System.Drawing.Color.White
        Me.picFotografia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFotografia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picFotografia.Location = New System.Drawing.Point(517, 168)
        Me.picFotografia.Name = "picFotografia"
        Me.picFotografia.Size = New System.Drawing.Size(188, 200)
        Me.picFotografia.TabIndex = 32
        Me.picFotografia.TabStop = False
        '
        'txtPrecio
        '
        Me.txtPrecio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(228, 222)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(94, 21)
        Me.txtPrecio.TabIndex = 6
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(179, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Precio :"
        '
        'lblImagen
        '
        Me.lblImagen.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblImagen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImagen.ForeColor = System.Drawing.Color.White
        Me.lblImagen.Location = New System.Drawing.Point(10, 69)
        Me.lblImagen.Name = "lblImagen"
        Me.lblImagen.Size = New System.Drawing.Size(56, 45)
        Me.lblImagen.TabIndex = 141
        Me.lblImagen.Text = "Categ."
        Me.lblImagen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStock
        '
        Me.txtStock.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.Location = New System.Drawing.Point(74, 249)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(94, 21)
        Me.txtStock.TabIndex = 7
        Me.txtStock.Text = "0"
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 144
        Me.Label8.Text = "Existencias :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 345)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Especif. :"
        '
        'txtEspecif
        '
        Me.txtEspecif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEspecif.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEspecif.Location = New System.Drawing.Point(74, 276)
        Me.txtEspecif.Multiline = True
        Me.txtEspecif.Name = "txtEspecif"
        Me.txtEspecif.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEspecif.Size = New System.Drawing.Size(437, 136)
        Me.txtEspecif.TabIndex = 9
        Me.txtEspecif.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmdMarcas
        '
        Me.cmdMarcas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdMarcas.Image = CType(resources.GetObject("cmdMarcas.Image"), System.Drawing.Image)
        Me.cmdMarcas.Location = New System.Drawing.Point(490, 93)
        Me.cmdMarcas.Name = "cmdMarcas"
        Me.cmdMarcas.Size = New System.Drawing.Size(22, 21)
        Me.cmdMarcas.TabIndex = 155
        '
        'txtDscto
        '
        Me.txtDscto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDscto.Location = New System.Drawing.Point(405, 222)
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.Size = New System.Drawing.Size(94, 21)
        Me.txtDscto.TabIndex = 8
        Me.txtDscto.Text = "0"
        Me.txtDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(328, 225)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Dscto. ( % ) :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Items.AddRange(New Object() {"SOLES", "DÓLARES"})
        Me.cboMoneda.Location = New System.Drawing.Point(74, 222)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(94, 21)
        Me.cboMoneda.TabIndex = 5
        '
        'ofdAbrir
        '
        Me.ofdAbrir.FileName = "OpenFileDialog1"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Image = CType(resources.GetObject("cmdGuardar.Image"), System.Drawing.Image)
        Me.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardar.Location = New System.Drawing.Point(542, 429)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(102, 28)
        Me.cmdGuardar.TabIndex = 10
        Me.cmdGuardar.Text = "Guardar datos"
        Me.cmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(645, 429)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(64, 28)
        Me.cmdCerrar.TabIndex = 11
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-1, 421)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(720, 2)
        Me.PictureBox2.TabIndex = 164
        Me.PictureBox2.TabStop = False
        '
        'cboTipoBalanza
        '
        Me.cboTipoBalanza.BackColor = System.Drawing.SystemColors.Info
        Me.cboTipoBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBalanza.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTipoBalanza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBalanza.FormattingEnabled = True
        Me.cboTipoBalanza.Items.AddRange(New Object() {"COMPLETA", "POR PARTES"})
        Me.cboTipoBalanza.Location = New System.Drawing.Point(319, 68)
        Me.cboTipoBalanza.Name = "cboTipoBalanza"
        Me.cboTipoBalanza.Size = New System.Drawing.Size(168, 21)
        Me.cboTipoBalanza.TabIndex = 1
        Me.cboTipoBalanza.Visible = False
        '
        'cboEstructura
        '
        Me.cboEstructura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstructura.Enabled = False
        Me.cboEstructura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboEstructura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstructura.FormattingEnabled = True
        Me.cboEstructura.Items.AddRange(New Object() {"Seleccione", "INDICADOR", "PLATAFORMA"})
        Me.cboEstructura.Location = New System.Drawing.Point(319, 93)
        Me.cboEstructura.Name = "cboEstructura"
        Me.cboEstructura.Size = New System.Drawing.Size(168, 21)
        Me.cboEstructura.TabIndex = 168
        '
        'cboMarca
        '
        Me.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMarca.FormattingEnabled = True
        Me.cboMarca.Location = New System.Drawing.Point(74, 140)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(168, 21)
        Me.cboMarca.TabIndex = 171
        '
        'LblMarca
        '
        Me.LblMarca.AutoSize = True
        Me.LblMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMarca.Location = New System.Drawing.Point(24, 143)
        Me.LblMarca.Name = "LblMarca"
        Me.LblMarca.Size = New System.Drawing.Size(43, 13)
        Me.LblMarca.TabIndex = 170
        Me.LblMarca.Text = "Marca :"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCategoria.Location = New System.Drawing.Point(72, 93)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(74, 16)
        Me.lblCategoria.TabIndex = 172
        Me.lblCategoria.Text = "CAMARAS"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(239, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 168
        Me.Label13.Text = "Tipo Balanza :"
        '
        'txtModelo
        '
        Me.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(319, 140)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(168, 21)
        Me.txtModelo.TabIndex = 174
        '
        'LblModelo
        '
        Me.LblModelo.AutoSize = True
        Me.LblModelo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModelo.Location = New System.Drawing.Point(264, 146)
        Me.LblModelo.Name = "LblModelo"
        Me.LblModelo.Size = New System.Drawing.Size(48, 13)
        Me.LblModelo.TabIndex = 175
        Me.LblModelo.Text = "Modelo :"
        '
        'TxtMedidas
        '
        Me.TxtMedidas.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtMedidas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMedidas.Location = New System.Drawing.Point(319, 167)
        Me.TxtMedidas.Name = "TxtMedidas"
        Me.TxtMedidas.Size = New System.Drawing.Size(168, 21)
        Me.TxtMedidas.TabIndex = 176
        '
        'BtnVistaPrevia
        '
        Me.BtnVistaPrevia.Location = New System.Drawing.Point(533, 390)
        Me.BtnVistaPrevia.Name = "BtnVistaPrevia"
        Me.BtnVistaPrevia.Size = New System.Drawing.Size(162, 21)
        Me.BtnVistaPrevia.TabIndex = 212
        Me.BtnVistaPrevia.Text = "Vista Previa"
        Me.BtnVistaPrevia.UseVisualStyleBackColor = True
        '
        'cboTipoEstructura
        '
        Me.cboTipoEstructura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEstructura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTipoEstructura.FormattingEnabled = True
        Me.cboTipoEstructura.Location = New System.Drawing.Point(74, 167)
        Me.cboTipoEstructura.Name = "cboTipoEstructura"
        Me.cboTipoEstructura.Size = New System.Drawing.Size(168, 21)
        Me.cboTipoEstructura.TabIndex = 213
        '
        'LblEstructura
        '
        Me.LblEstructura.AutoSize = True
        Me.LblEstructura.Location = New System.Drawing.Point(7, 172)
        Me.LblEstructura.Name = "LblEstructura"
        Me.LblEstructura.Size = New System.Drawing.Size(61, 13)
        Me.LblEstructura.TabIndex = 214
        Me.LblEstructura.Text = "Estructura :"
        '
        'LblMedidas
        '
        Me.LblMedidas.AutoSize = True
        Me.LblMedidas.Location = New System.Drawing.Point(259, 172)
        Me.LblMedidas.Name = "LblMedidas"
        Me.LblMedidas.Size = New System.Drawing.Size(53, 13)
        Me.LblMedidas.TabIndex = 216
        Me.LblMedidas.Text = "Medidas :"
        '
        'FrmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(719, 463)
        Me.Controls.Add(Me.LblMedidas)
        Me.Controls.Add(Me.LblEstructura)
        Me.Controls.Add(Me.cboTipoEstructura)
        Me.Controls.Add(Me.BtnVistaPrevia)
        Me.Controls.Add(Me.txtModelo)
        Me.Controls.Add(Me.LblModelo)
        Me.Controls.Add(Me.TxtMedidas)
        Me.Controls.Add(Me.lblIDProducto)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblIDCategoria)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.cboMarca)
        Me.Controls.Add(Me.LblMarca)
        Me.Controls.Add(Me.cboTipoBalanza)
        Me.Controls.Add(Me.txtDscto)
        Me.Controls.Add(Me.lblNroCodBarras)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblCodBarras)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboMoneda)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdMarcas)
        Me.Controls.Add(Me.picFotografia)
        Me.Controls.Add(Me.txtEspecif)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblImagen)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblTipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picLinea)
        Me.Controls.Add(Me.cboEstructura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de nuevos productos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFotografia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents picFotografia As System.Windows.Forms.PictureBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblImagen As System.Windows.Forms.Label
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEspecif As System.Windows.Forms.TextBox
    Friend WithEvents lblCodBarras As System.Windows.Forms.Label
    Friend WithEvents lblNroCodBarras As System.Windows.Forms.Label
    Friend WithEvents cmdMarcas As System.Windows.Forms.Label
    Friend WithEvents txtDscto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents ofdAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblIDCategoria As System.Windows.Forms.Label
    Friend WithEvents cboTipoBalanza As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstructura As System.Windows.Forms.ComboBox
    Friend WithEvents cboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents LblMarca As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblIDProducto As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents LblModelo As System.Windows.Forms.Label
    Friend WithEvents TxtMedidas As System.Windows.Forms.TextBox
    Friend WithEvents BtnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents cboTipoEstructura As System.Windows.Forms.ComboBox
    Friend WithEvents LblEstructura As System.Windows.Forms.Label
    Friend WithEvents LblMedidas As System.Windows.Forms.Label
End Class
