<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.BarHerramienta = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmdCliente = New System.Windows.Forms.ToolStripButton()
        Me.mnuBCaja = New System.Windows.Forms.ToolStripSplitButton()
        Me.BmnuListadoCajas = New System.Windows.Forms.ToolStripMenuItem()
        Me.BmnuDeclararGastos = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdFactura = New System.Windows.Forms.ToolStripButton()
        Me.mnuBEmitirFactura = New System.Windows.Forms.ToolStripButton()
        Me.cmdAlamcen = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnuBEntrada = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBSalida = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBStock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.mnuBCatalogoProductos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.BmnuCalibraciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.BmnuSoftwares = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSalir = New System.Windows.Forms.ToolStripButton()
        Me.BmnuNotas = New System.Windows.Forms.ToolStripButton()
        Me.BarEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslConexion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslVersionDispo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblProxHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRecordatorios = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRegistrarUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsuariosRegistrados = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRegistrarNiveles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAsignarPermisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCambiarContrasena = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCerrarSesion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistroClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuListaClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdminClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarClientesDelSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmitirFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAnulaFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuVerEstadísticas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuListarFacturasGeneradas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistrarFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCorregirDatosFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuModificarIGV = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlmacenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistraEntradaAlmacen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistrarSalidaAlmacen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuStockProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDatosDeLaEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuIGV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProvincias = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuProgramarDatosDeActualización = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProgramarMantenimientoDelSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.IngresarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManualUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAcercade = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarMenu = New System.Windows.Forms.MenuStrip()
        Me.CajaChicaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistrarConcepto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGastosGeneralesAdministrativos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCrearNuevasCajas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdministraTodasCajas = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarRequerimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGenerarCotizacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuListaDeCotizaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVisualizarReq = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuActivarAlertasReq = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarRequerimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistrarCotización = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuModificarCotizaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAprobarCotizaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbrirCotizaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuestrosProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCatalogoProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistrarCategoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegistrarNuevasMarcas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAgregarNuevoProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarProductosExistentes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServicioTécnicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCalibraciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSoftwares = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIngresoEquipos = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBarraDeHerramimentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBarraDeEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRequerimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrFechaHora = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRecordatorios = New System.Windows.Forms.Timer(Me.components)
        Me.panelAlerta = New System.Windows.Forms.Panel()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblFrecuencia = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblBienvenida = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tmrDesactivar = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCambios_en_Permisos = New System.Windows.Forms.Timer(Me.components)
        Me.panelRequerimientos = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvRequerimientos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvCotizados = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panelCotizaciones = New System.Windows.Forms.Panel()
        Me.panelporCotizar = New System.Windows.Forms.Panel()
        Me.cmdRefrescar = New System.Windows.Forms.Button()
        Me.cmdCotizar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.lblEst = New System.Windows.Forms.Label()
        Me.panelEstado = New System.Windows.Forms.Label()
        Me.tmrSeguimientos = New System.Windows.Forms.Timer(Me.components)
        Me.tmrReactivar = New System.Windows.Forms.Timer(Me.components)
        Me.tmrActualizarListaREQ = New System.Windows.Forms.Timer(Me.components)
        Me.BarHerramienta.SuspendLayout()
        Me.BarEstado.SuspendLayout()
        Me.BarMenu.SuspendLayout()
        Me.panelAlerta.SuspendLayout()
        Me.panelRequerimientos.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvRequerimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvCotizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.panelporCotizar.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarHerramienta
        '
        Me.BarHerramienta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.lblUsuario, Me.ToolStripLabel1, Me.cmdCliente, Me.mnuBCaja, Me.cmdFactura, Me.mnuBEmitirFactura, Me.cmdAlamcen, Me.ToolStripLabel3, Me.mnuBCatalogoProductos, Me.ToolStripSplitButton1, Me.ToolStripSeparator2, Me.cmdSalir, Me.BmnuNotas})
        Me.BarHerramienta.Location = New System.Drawing.Point(0, 24)
        Me.BarHerramienta.Name = "BarHerramienta"
        Me.BarHerramienta.Size = New System.Drawing.Size(1131, 68)
        Me.BarHerramienta.TabIndex = 6
        Me.BarHerramienta.Text = "ToolStrip"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(22, 65)
        Me.ToolStripLabel2.Text = "     "
        '
        'lblUsuario
        '
        Me.lblUsuario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.Gray
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(0, 65)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Gray
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(66, 65)
        Me.ToolStripLabel1.Text = "Bienvenido :"
        '
        'cmdCliente
        '
        Me.cmdCliente.Enabled = False
        Me.cmdCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCliente.Image = CType(resources.GetObject("cmdCliente.Image"), System.Drawing.Image)
        Me.cmdCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCliente.Name = "cmdCliente"
        Me.cmdCliente.Size = New System.Drawing.Size(122, 65)
        Me.cmdCliente.Text = "Registrar nuevo cliente"
        Me.cmdCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuBCaja
        '
        Me.mnuBCaja.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BmnuListadoCajas, Me.BmnuDeclararGastos})
        Me.mnuBCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBCaja.Image = CType(resources.GetObject("mnuBCaja.Image"), System.Drawing.Image)
        Me.mnuBCaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuBCaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuBCaja.Name = "mnuBCaja"
        Me.mnuBCaja.Size = New System.Drawing.Size(64, 65)
        Me.mnuBCaja.Text = "Caja"
        Me.mnuBCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BmnuListadoCajas
        '
        Me.BmnuListadoCajas.Enabled = False
        Me.BmnuListadoCajas.Image = CType(resources.GetObject("BmnuListadoCajas.Image"), System.Drawing.Image)
        Me.BmnuListadoCajas.Name = "BmnuListadoCajas"
        Me.BmnuListadoCajas.Size = New System.Drawing.Size(199, 22)
        Me.BmnuListadoCajas.Text = "Listado de cajas"
        '
        'BmnuDeclararGastos
        '
        Me.BmnuDeclararGastos.Enabled = False
        Me.BmnuDeclararGastos.Image = CType(resources.GetObject("BmnuDeclararGastos.Image"), System.Drawing.Image)
        Me.BmnuDeclararGastos.Name = "BmnuDeclararGastos"
        Me.BmnuDeclararGastos.Size = New System.Drawing.Size(199, 22)
        Me.BmnuDeclararGastos.Text = "Declarar gastos generales"
        '
        'cmdFactura
        '
        Me.cmdFactura.Enabled = False
        Me.cmdFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFactura.Image = CType(resources.GetObject("cmdFactura.Image"), System.Drawing.Image)
        Me.cmdFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdFactura.Name = "cmdFactura"
        Me.cmdFactura.Size = New System.Drawing.Size(126, 65)
        Me.cmdFactura.Text = "Registrar nueva factura"
        Me.cmdFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuBEmitirFactura
        '
        Me.mnuBEmitirFactura.Enabled = False
        Me.mnuBEmitirFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBEmitirFactura.Image = CType(resources.GetObject("mnuBEmitirFactura.Image"), System.Drawing.Image)
        Me.mnuBEmitirFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.mnuBEmitirFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuBEmitirFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuBEmitirFactura.Name = "mnuBEmitirFactura"
        Me.mnuBEmitirFactura.Size = New System.Drawing.Size(108, 65)
        Me.mnuBEmitirFactura.Text = "Emitir nueva factura"
        Me.mnuBEmitirFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuBEmitirFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmdAlamcen
        '
        Me.cmdAlamcen.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBEntrada, Me.mnuBSalida, Me.ToolStripMenuItem5, Me.mnuBStock})
        Me.cmdAlamcen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAlamcen.Image = CType(resources.GetObject("cmdAlamcen.Image"), System.Drawing.Image)
        Me.cmdAlamcen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdAlamcen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAlamcen.Name = "cmdAlamcen"
        Me.cmdAlamcen.Size = New System.Drawing.Size(64, 65)
        Me.cmdAlamcen.Text = "Almacen"
        Me.cmdAlamcen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuBEntrada
        '
        Me.mnuBEntrada.Enabled = False
        Me.mnuBEntrada.Image = CType(resources.GetObject("mnuBEntrada.Image"), System.Drawing.Image)
        Me.mnuBEntrada.Name = "mnuBEntrada"
        Me.mnuBEntrada.Size = New System.Drawing.Size(225, 22)
        Me.mnuBEntrada.Text = "Registrar entrada de productos"
        '
        'mnuBSalida
        '
        Me.mnuBSalida.Enabled = False
        Me.mnuBSalida.Image = CType(resources.GetObject("mnuBSalida.Image"), System.Drawing.Image)
        Me.mnuBSalida.Name = "mnuBSalida"
        Me.mnuBSalida.Size = New System.Drawing.Size(225, 22)
        Me.mnuBSalida.Text = "Registrar salida de productos"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(222, 6)
        '
        'mnuBStock
        '
        Me.mnuBStock.Enabled = False
        Me.mnuBStock.Image = CType(resources.GetObject("mnuBStock.Image"), System.Drawing.Image)
        Me.mnuBStock.Name = "mnuBStock"
        Me.mnuBStock.Size = New System.Drawing.Size(225, 22)
        Me.mnuBStock.Text = "Existencias de productos"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(13, 65)
        Me.ToolStripLabel3.Text = "  "
        '
        'mnuBCatalogoProductos
        '
        Me.mnuBCatalogoProductos.Enabled = False
        Me.mnuBCatalogoProductos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBCatalogoProductos.Image = CType(resources.GetObject("mnuBCatalogoProductos.Image"), System.Drawing.Image)
        Me.mnuBCatalogoProductos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.mnuBCatalogoProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuBCatalogoProductos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuBCatalogoProductos.Name = "mnuBCatalogoProductos"
        Me.mnuBCatalogoProductos.Size = New System.Drawing.Size(120, 65)
        Me.mnuBCatalogoProductos.Text = "Catálogo de productos"
        Me.mnuBCatalogoProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuBCatalogoProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BmnuCalibraciones, Me.BmnuSoftwares})
        Me.ToolStripSplitButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(99, 65)
        Me.ToolStripSplitButton1.Text = "Servicio Técnico"
        Me.ToolStripSplitButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BmnuCalibraciones
        '
        Me.BmnuCalibraciones.Enabled = False
        Me.BmnuCalibraciones.Image = CType(resources.GetObject("BmnuCalibraciones.Image"), System.Drawing.Image)
        Me.BmnuCalibraciones.Name = "BmnuCalibraciones"
        Me.BmnuCalibraciones.Size = New System.Drawing.Size(192, 22)
        Me.BmnuCalibraciones.Text = "Manuales y calibraciones"
        '
        'BmnuSoftwares
        '
        Me.BmnuSoftwares.Enabled = False
        Me.BmnuSoftwares.Image = CType(resources.GetObject("BmnuSoftwares.Image"), System.Drawing.Image)
        Me.BmnuSoftwares.Name = "BmnuSoftwares"
        Me.BmnuSoftwares.Size = New System.Drawing.Size(192, 22)
        Me.BmnuSoftwares.Text = "Asistencia Técnica"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 68)
        '
        'cmdSalir
        '
        Me.cmdSalir.Enabled = False
        Me.cmdSalir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Image = CType(resources.GetObject("cmdSalir.Image"), System.Drawing.Image)
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(87, 65)
        Me.cmdSalir.Text = "Salir del sistema"
        Me.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BmnuNotas
        '
        Me.BmnuNotas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BmnuNotas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BmnuNotas.Enabled = False
        Me.BmnuNotas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BmnuNotas.Image = CType(resources.GetObject("BmnuNotas.Image"), System.Drawing.Image)
        Me.BmnuNotas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BmnuNotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BmnuNotas.Name = "BmnuNotas"
        Me.BmnuNotas.Size = New System.Drawing.Size(52, 65)
        Me.BmnuNotas.Text = "Notas"
        Me.BmnuNotas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BmnuNotas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarEstado
        '
        Me.BarEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslConexion, Me.tsslVersionDispo, Me.lblEstado, Me.tsslHora, Me.tsslFecha, Me.lblProxHora, Me.tsslVersion})
        Me.BarEstado.Location = New System.Drawing.Point(0, 503)
        Me.BarEstado.Name = "BarEstado"
        Me.BarEstado.Size = New System.Drawing.Size(1131, 25)
        Me.BarEstado.TabIndex = 7
        Me.BarEstado.Text = "StatusStrip"
        '
        'tsslConexion
        '
        Me.tsslConexion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsslConexion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslConexion.Image = CType(resources.GetObject("tsslConexion.Image"), System.Drawing.Image)
        Me.tsslConexion.Name = "tsslConexion"
        Me.tsslConexion.Size = New System.Drawing.Size(87, 20)
        Me.tsslConexion.Text = "Sin conexión"
        Me.tsslConexion.Visible = False
        '
        'tsslVersionDispo
        '
        Me.tsslVersionDispo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsslVersionDispo.ForeColor = System.Drawing.Color.BlueViolet
        Me.tsslVersionDispo.IsLink = True
        Me.tsslVersionDispo.LinkColor = System.Drawing.Color.DeepPink
        Me.tsslVersionDispo.Name = "tsslVersionDispo"
        Me.tsslVersionDispo.Size = New System.Drawing.Size(238, 20)
        Me.tsslVersionDispo.Text = "Versión 4.0.1.9 disponible (Descargala aqui)"
        Me.tsslVersionDispo.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 20)
        Me.lblEstado.Text = "Estado"
        '
        'tsslHora
        '
        Me.tsslHora.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tsslHora.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tsslHora.Image = CType(resources.GetObject("tsslHora.Image"), System.Drawing.Image)
        Me.tsslHora.Name = "tsslHora"
        Me.tsslHora.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.tsslHora.Size = New System.Drawing.Size(65, 20)
        Me.tsslHora.Text = "16:29"
        '
        'tsslFecha
        '
        Me.tsslFecha.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tsslFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tsslFecha.Image = CType(resources.GetObject("tsslFecha.Image"), System.Drawing.Image)
        Me.tsslFecha.Name = "tsslFecha"
        Me.tsslFecha.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.tsslFecha.Size = New System.Drawing.Size(74, 20)
        Me.tsslFecha.Text = "octubre"
        '
        'lblProxHora
        '
        Me.lblProxHora.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblProxHora.Name = "lblProxHora"
        Me.lblProxHora.Size = New System.Drawing.Size(0, 20)
        '
        'tsslVersion
        '
        Me.tsslVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tsslVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tsslVersion.Name = "tsslVersion"
        Me.tsslVersion.Size = New System.Drawing.Size(49, 20)
        Me.tsslVersion.Text = "versión"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRecordatorios, Me.ToolStripMenuItem8, Me.mnuRegistrarUsuario, Me.mnuUsuariosRegistrados, Me.ToolStripMenuItem13, Me.mnuRegistrarNiveles, Me.mnuAsignarPermisos, Me.ToolStripMenuItem2, Me.mnuCambiarContrasena, Me.ToolStripMenuItem11, Me.mnuCerrarSesion, Me.ToolStripMenuItem3, Me.mnuSalir})
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.UsuariosToolStripMenuItem.Text = "Us&uarios"
        '
        'mnuRecordatorios
        '
        Me.mnuRecordatorios.Enabled = False
        Me.mnuRecordatorios.Image = CType(resources.GetObject("mnuRecordatorios.Image"), System.Drawing.Image)
        Me.mnuRecordatorios.Name = "mnuRecordatorios"
        Me.mnuRecordatorios.Size = New System.Drawing.Size(208, 22)
        Me.mnuRecordatorios.Text = "Notas"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(205, 6)
        '
        'mnuRegistrarUsuario
        '
        Me.mnuRegistrarUsuario.Enabled = False
        Me.mnuRegistrarUsuario.Image = CType(resources.GetObject("mnuRegistrarUsuario.Image"), System.Drawing.Image)
        Me.mnuRegistrarUsuario.Name = "mnuRegistrarUsuario"
        Me.mnuRegistrarUsuario.Size = New System.Drawing.Size(208, 22)
        Me.mnuRegistrarUsuario.Text = "Registrar nuevo usuario"
        '
        'mnuUsuariosRegistrados
        '
        Me.mnuUsuariosRegistrados.Enabled = False
        Me.mnuUsuariosRegistrados.Name = "mnuUsuariosRegistrados"
        Me.mnuUsuariosRegistrados.Size = New System.Drawing.Size(208, 22)
        Me.mnuUsuariosRegistrados.Text = "Usuarios conectados"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(205, 6)
        '
        'mnuRegistrarNiveles
        '
        Me.mnuRegistrarNiveles.Enabled = False
        Me.mnuRegistrarNiveles.Image = CType(resources.GetObject("mnuRegistrarNiveles.Image"), System.Drawing.Image)
        Me.mnuRegistrarNiveles.Name = "mnuRegistrarNiveles"
        Me.mnuRegistrarNiveles.Size = New System.Drawing.Size(208, 22)
        Me.mnuRegistrarNiveles.Text = "Registrar niveles de usuario"
        '
        'mnuAsignarPermisos
        '
        Me.mnuAsignarPermisos.Enabled = False
        Me.mnuAsignarPermisos.Image = CType(resources.GetObject("mnuAsignarPermisos.Image"), System.Drawing.Image)
        Me.mnuAsignarPermisos.Name = "mnuAsignarPermisos"
        Me.mnuAsignarPermisos.Size = New System.Drawing.Size(208, 22)
        Me.mnuAsignarPermisos.Text = "Asignar permisos de usuario"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(205, 6)
        Me.ToolStripMenuItem2.Tag = "1"
        '
        'mnuCambiarContrasena
        '
        Me.mnuCambiarContrasena.Enabled = False
        Me.mnuCambiarContrasena.Image = CType(resources.GetObject("mnuCambiarContrasena.Image"), System.Drawing.Image)
        Me.mnuCambiarContrasena.Name = "mnuCambiarContrasena"
        Me.mnuCambiarContrasena.Size = New System.Drawing.Size(208, 22)
        Me.mnuCambiarContrasena.Text = "Cambiar contraseña"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(205, 6)
        '
        'mnuCerrarSesion
        '
        Me.mnuCerrarSesion.Enabled = False
        Me.mnuCerrarSesion.Image = CType(resources.GetObject("mnuCerrarSesion.Image"), System.Drawing.Image)
        Me.mnuCerrarSesion.Name = "mnuCerrarSesion"
        Me.mnuCerrarSesion.Size = New System.Drawing.Size(208, 22)
        Me.mnuCerrarSesion.Text = "Cambiar de usuario"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(205, 6)
        '
        'mnuSalir
        '
        Me.mnuSalir.Enabled = False
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(208, 22)
        Me.mnuSalir.Text = "Salir del sistema"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRegistroClientes, Me.mnuListaClientes, Me.mnuAdminClientes, Me.mnuEliminarClientesDelSistema})
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.MantenimientoToolStripMenuItem.Text = "&Clientes"
        '
        'mnuRegistroClientes
        '
        Me.mnuRegistroClientes.Enabled = False
        Me.mnuRegistroClientes.Image = CType(resources.GetObject("mnuRegistroClientes.Image"), System.Drawing.Image)
        Me.mnuRegistroClientes.Name = "mnuRegistroClientes"
        Me.mnuRegistroClientes.Size = New System.Drawing.Size(205, 22)
        Me.mnuRegistroClientes.Text = "Registrar nuevo cliente"
        '
        'mnuListaClientes
        '
        Me.mnuListaClientes.Enabled = False
        Me.mnuListaClientes.Image = CType(resources.GetObject("mnuListaClientes.Image"), System.Drawing.Image)
        Me.mnuListaClientes.Name = "mnuListaClientes"
        Me.mnuListaClientes.Size = New System.Drawing.Size(205, 22)
        Me.mnuListaClientes.Text = "Listar clientes registrados"
        '
        'mnuAdminClientes
        '
        Me.mnuAdminClientes.Enabled = False
        Me.mnuAdminClientes.Name = "mnuAdminClientes"
        Me.mnuAdminClientes.Size = New System.Drawing.Size(205, 22)
        Me.mnuAdminClientes.Text = "Administrar clientes"
        Me.mnuAdminClientes.Visible = False
        '
        'mnuEliminarClientesDelSistema
        '
        Me.mnuEliminarClientesDelSistema.Enabled = False
        Me.mnuEliminarClientesDelSistema.Name = "mnuEliminarClientesDelSistema"
        Me.mnuEliminarClientesDelSistema.Size = New System.Drawing.Size(205, 22)
        Me.mnuEliminarClientesDelSistema.Text = "Eliminar clientes del sistema"
        Me.mnuEliminarClientesDelSistema.Visible = False
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEmitirFactura, Me.mnuAnulaFactura, Me.ToolStripMenuItem6, Me.mnuVerEstadísticas, Me.ToolStripMenuItem12, Me.mnuListarFacturasGeneradas, Me.mnuRegistrarFactura, Me.mnuCorregirDatosFactura, Me.mnuModificarIGV})
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.InformesToolStripMenuItem.Text = "&Facturación"
        '
        'mnuEmitirFactura
        '
        Me.mnuEmitirFactura.Enabled = False
        Me.mnuEmitirFactura.Image = CType(resources.GetObject("mnuEmitirFactura.Image"), System.Drawing.Image)
        Me.mnuEmitirFactura.Name = "mnuEmitirFactura"
        Me.mnuEmitirFactura.Size = New System.Drawing.Size(218, 22)
        Me.mnuEmitirFactura.Text = "Emitir nueva factura"
        '
        'mnuAnulaFactura
        '
        Me.mnuAnulaFactura.Enabled = False
        Me.mnuAnulaFactura.Image = CType(resources.GetObject("mnuAnulaFactura.Image"), System.Drawing.Image)
        Me.mnuAnulaFactura.Name = "mnuAnulaFactura"
        Me.mnuAnulaFactura.Size = New System.Drawing.Size(218, 22)
        Me.mnuAnulaFactura.Text = "Anular factura existente"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(215, 6)
        '
        'mnuVerEstadísticas
        '
        Me.mnuVerEstadísticas.Enabled = False
        Me.mnuVerEstadísticas.Image = CType(resources.GetObject("mnuVerEstadísticas.Image"), System.Drawing.Image)
        Me.mnuVerEstadísticas.Name = "mnuVerEstadísticas"
        Me.mnuVerEstadísticas.Size = New System.Drawing.Size(218, 22)
        Me.mnuVerEstadísticas.Text = "Visualizar gráficos estadísticos"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(215, 6)
        '
        'mnuListarFacturasGeneradas
        '
        Me.mnuListarFacturasGeneradas.Enabled = False
        Me.mnuListarFacturasGeneradas.Image = CType(resources.GetObject("mnuListarFacturasGeneradas.Image"), System.Drawing.Image)
        Me.mnuListarFacturasGeneradas.Name = "mnuListarFacturasGeneradas"
        Me.mnuListarFacturasGeneradas.Size = New System.Drawing.Size(218, 22)
        Me.mnuListarFacturasGeneradas.Text = "Listar facturas generadas"
        Me.mnuListarFacturasGeneradas.Visible = False
        '
        'mnuRegistrarFactura
        '
        Me.mnuRegistrarFactura.Enabled = False
        Me.mnuRegistrarFactura.Name = "mnuRegistrarFactura"
        Me.mnuRegistrarFactura.Size = New System.Drawing.Size(218, 22)
        Me.mnuRegistrarFactura.Text = "Registrar nueva factura"
        Me.mnuRegistrarFactura.Visible = False
        '
        'mnuCorregirDatosFactura
        '
        Me.mnuCorregirDatosFactura.Enabled = False
        Me.mnuCorregirDatosFactura.Name = "mnuCorregirDatosFactura"
        Me.mnuCorregirDatosFactura.Size = New System.Drawing.Size(218, 22)
        Me.mnuCorregirDatosFactura.Text = "Corregir datos de facturación"
        Me.mnuCorregirDatosFactura.Visible = False
        '
        'mnuModificarIGV
        '
        Me.mnuModificarIGV.Enabled = False
        Me.mnuModificarIGV.Name = "mnuModificarIGV"
        Me.mnuModificarIGV.Size = New System.Drawing.Size(218, 22)
        Me.mnuModificarIGV.Text = "Modificar ( % ) IGV"
        Me.mnuModificarIGV.Visible = False
        '
        'AlmacenToolStripMenuItem
        '
        Me.AlmacenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRegistraEntradaAlmacen, Me.mnuRegistrarSalidaAlmacen, Me.ToolStripMenuItem7, Me.mnuStockProducto})
        Me.AlmacenToolStripMenuItem.Name = "AlmacenToolStripMenuItem"
        Me.AlmacenToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.AlmacenToolStripMenuItem.Text = "&Almacen"
        '
        'mnuRegistraEntradaAlmacen
        '
        Me.mnuRegistraEntradaAlmacen.Enabled = False
        Me.mnuRegistraEntradaAlmacen.Image = CType(resources.GetObject("mnuRegistraEntradaAlmacen.Image"), System.Drawing.Image)
        Me.mnuRegistraEntradaAlmacen.Name = "mnuRegistraEntradaAlmacen"
        Me.mnuRegistraEntradaAlmacen.Size = New System.Drawing.Size(225, 22)
        Me.mnuRegistraEntradaAlmacen.Text = "Registrar entrada de productos"
        '
        'mnuRegistrarSalidaAlmacen
        '
        Me.mnuRegistrarSalidaAlmacen.Enabled = False
        Me.mnuRegistrarSalidaAlmacen.Image = CType(resources.GetObject("mnuRegistrarSalidaAlmacen.Image"), System.Drawing.Image)
        Me.mnuRegistrarSalidaAlmacen.Name = "mnuRegistrarSalidaAlmacen"
        Me.mnuRegistrarSalidaAlmacen.Size = New System.Drawing.Size(225, 22)
        Me.mnuRegistrarSalidaAlmacen.Text = "Registrar salida de productos"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(222, 6)
        Me.ToolStripMenuItem7.Tag = "11"
        '
        'mnuStockProducto
        '
        Me.mnuStockProducto.Enabled = False
        Me.mnuStockProducto.Image = CType(resources.GetObject("mnuStockProducto.Image"), System.Drawing.Image)
        Me.mnuStockProducto.Name = "mnuStockProducto"
        Me.mnuStockProducto.Size = New System.Drawing.Size(225, 22)
        Me.mnuStockProducto.Text = "Existencias de productos"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDatosDeLaEmpresa, Me.ToolStripMenuItem10, Me.mnuIGV, Me.mnuProvincias, Me.ToolStripMenuItem9, Me.mnuProgramarDatosDeActualización, Me.mnuProgramarMantenimientoDelSistema, Me.ToolStripSeparator1, Me.IngresarToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.OpcionesToolStripMenuItem.Text = "Con&figuración"
        '
        'mnuDatosDeLaEmpresa
        '
        Me.mnuDatosDeLaEmpresa.Enabled = False
        Me.mnuDatosDeLaEmpresa.Name = "mnuDatosDeLaEmpresa"
        Me.mnuDatosDeLaEmpresa.Size = New System.Drawing.Size(253, 22)
        Me.mnuDatosDeLaEmpresa.Text = "Datos de la empresa"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(250, 6)
        Me.ToolStripMenuItem10.Tag = "13"
        '
        'mnuIGV
        '
        Me.mnuIGV.Enabled = False
        Me.mnuIGV.Image = CType(resources.GetObject("mnuIGV.Image"), System.Drawing.Image)
        Me.mnuIGV.Name = "mnuIGV"
        Me.mnuIGV.Size = New System.Drawing.Size(253, 22)
        Me.mnuIGV.Text = "Cambiar porcentaje del IGV"
        '
        'mnuProvincias
        '
        Me.mnuProvincias.Enabled = False
        Me.mnuProvincias.Image = CType(resources.GetObject("mnuProvincias.Image"), System.Drawing.Image)
        Me.mnuProvincias.Name = "mnuProvincias"
        Me.mnuProvincias.Size = New System.Drawing.Size(253, 22)
        Me.mnuProvincias.Text = "Registrar nuevas ciudades"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(250, 6)
        '
        'mnuProgramarDatosDeActualización
        '
        Me.mnuProgramarDatosDeActualización.Enabled = False
        Me.mnuProgramarDatosDeActualización.Image = CType(resources.GetObject("mnuProgramarDatosDeActualización.Image"), System.Drawing.Image)
        Me.mnuProgramarDatosDeActualización.Name = "mnuProgramarDatosDeActualización"
        Me.mnuProgramarDatosDeActualización.Size = New System.Drawing.Size(253, 22)
        Me.mnuProgramarDatosDeActualización.Text = "Programar datos de actualización"
        '
        'mnuProgramarMantenimientoDelSistema
        '
        Me.mnuProgramarMantenimientoDelSistema.Enabled = False
        Me.mnuProgramarMantenimientoDelSistema.Image = CType(resources.GetObject("mnuProgramarMantenimientoDelSistema.Image"), System.Drawing.Image)
        Me.mnuProgramarMantenimientoDelSistema.Name = "mnuProgramarMantenimientoDelSistema"
        Me.mnuProgramarMantenimientoDelSistema.Size = New System.Drawing.Size(253, 22)
        Me.mnuProgramarMantenimientoDelSistema.Text = "Programar mantenimiento del sistema"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(250, 6)
        '
        'IngresarToolStripMenuItem
        '
        Me.IngresarToolStripMenuItem.Enabled = False
        Me.IngresarToolStripMenuItem.Name = "IngresarToolStripMenuItem"
        Me.IngresarToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.IngresarToolStripMenuItem.Text = "Registrar nuevos permisos"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManualUsuario, Me.mnuAcercade})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AyudaToolStripMenuItem.Text = "A&yuda"
        '
        'mnuManualUsuario
        '
        Me.mnuManualUsuario.Enabled = False
        Me.mnuManualUsuario.Name = "mnuManualUsuario"
        Me.mnuManualUsuario.Size = New System.Drawing.Size(175, 22)
        Me.mnuManualUsuario.Text = "Manual del usuario"
        '
        'mnuAcercade
        '
        Me.mnuAcercade.Enabled = False
        Me.mnuAcercade.Name = "mnuAcercade"
        Me.mnuAcercade.Size = New System.Drawing.Size(175, 22)
        Me.mnuAcercade.Text = "Acerca del sistema..."
        '
        'BarMenu
        '
        Me.BarMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.MantenimientoToolStripMenuItem, Me.CajaChicaToolStripMenuItem, Me.CotizacionesToolStripMenuItem, Me.NuestrosProductosToolStripMenuItem, Me.InformesToolStripMenuItem, Me.AlmacenToolStripMenuItem, Me.ServicioTécnicoToolStripMenuItem, Me.VerToolStripMenuItem1, Me.OpcionesToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(1131, 24)
        Me.BarMenu.TabIndex = 5
        Me.BarMenu.Text = "MenuStrip"
        '
        'CajaChicaToolStripMenuItem
        '
        Me.CajaChicaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesCaja, Me.mnuRegistrarConcepto, Me.ToolStripMenuItem1, Me.mnuGastosGeneralesAdministrativos, Me.mnuCrearNuevasCajas, Me.mnuAdministraTodasCajas})
        Me.CajaChicaToolStripMenuItem.Name = "CajaChicaToolStripMenuItem"
        Me.CajaChicaToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.CajaChicaToolStripMenuItem.Text = "C&aja"
        '
        'mnuOperacionesCaja
        '
        Me.mnuOperacionesCaja.Enabled = False
        Me.mnuOperacionesCaja.Image = CType(resources.GetObject("mnuOperacionesCaja.Image"), System.Drawing.Image)
        Me.mnuOperacionesCaja.Name = "mnuOperacionesCaja"
        Me.mnuOperacionesCaja.Size = New System.Drawing.Size(199, 22)
        Me.mnuOperacionesCaja.Text = "Listado de cajas"
        '
        'mnuRegistrarConcepto
        '
        Me.mnuRegistrarConcepto.Enabled = False
        Me.mnuRegistrarConcepto.Name = "mnuRegistrarConcepto"
        Me.mnuRegistrarConcepto.Size = New System.Drawing.Size(199, 22)
        Me.mnuRegistrarConcepto.Text = "Registrar concepto"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(196, 6)
        Me.ToolStripMenuItem1.Tag = "7"
        '
        'mnuGastosGeneralesAdministrativos
        '
        Me.mnuGastosGeneralesAdministrativos.Enabled = False
        Me.mnuGastosGeneralesAdministrativos.Image = CType(resources.GetObject("mnuGastosGeneralesAdministrativos.Image"), System.Drawing.Image)
        Me.mnuGastosGeneralesAdministrativos.Name = "mnuGastosGeneralesAdministrativos"
        Me.mnuGastosGeneralesAdministrativos.Size = New System.Drawing.Size(199, 22)
        Me.mnuGastosGeneralesAdministrativos.Text = "Declarar gastos generales"
        '
        'mnuCrearNuevasCajas
        '
        Me.mnuCrearNuevasCajas.Enabled = False
        Me.mnuCrearNuevasCajas.Name = "mnuCrearNuevasCajas"
        Me.mnuCrearNuevasCajas.Size = New System.Drawing.Size(199, 22)
        Me.mnuCrearNuevasCajas.Text = "Crear nuevas cajas"
        Me.mnuCrearNuevasCajas.Visible = False
        '
        'mnuAdministraTodasCajas
        '
        Me.mnuAdministraTodasCajas.Enabled = False
        Me.mnuAdministraTodasCajas.Name = "mnuAdministraTodasCajas"
        Me.mnuAdministraTodasCajas.Size = New System.Drawing.Size(199, 22)
        Me.mnuAdministraTodasCajas.Text = "Administra todas las caja"
        Me.mnuAdministraTodasCajas.Visible = False
        '
        'CotizacionesToolStripMenuItem
        '
        Me.CotizacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarRequerimiento, Me.mnuGenerarCotizacion, Me.ToolStripMenuItem14, Me.mnuListaDeCotizaciones, Me.mnuVisualizarReq, Me.mnuActivarAlertasReq, Me.mnuEliminarRequerimiento, Me.mnuRegistrarCotización, Me.mnuModificarCotizaciones, Me.mnuAprobarCotizaciones, Me.mnuAbrirCotizaciones})
        Me.CotizacionesToolStripMenuItem.Name = "CotizacionesToolStripMenuItem"
        Me.CotizacionesToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.CotizacionesToolStripMenuItem.Text = "C&otizaciones"
        '
        'GenerarRequerimiento
        '
        Me.GenerarRequerimiento.Enabled = False
        Me.GenerarRequerimiento.Image = CType(resources.GetObject("GenerarRequerimiento.Image"), System.Drawing.Image)
        Me.GenerarRequerimiento.Name = "GenerarRequerimiento"
        Me.GenerarRequerimiento.Size = New System.Drawing.Size(233, 22)
        Me.GenerarRequerimiento.Text = "Generar nuevo requerimiento"
        '
        'mnuGenerarCotizacion
        '
        Me.mnuGenerarCotizacion.Enabled = False
        Me.mnuGenerarCotizacion.Image = CType(resources.GetObject("mnuGenerarCotizacion.Image"), System.Drawing.Image)
        Me.mnuGenerarCotizacion.Name = "mnuGenerarCotizacion"
        Me.mnuGenerarCotizacion.Size = New System.Drawing.Size(233, 22)
        Me.mnuGenerarCotizacion.Text = "Generar nueva cotizacion"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(230, 6)
        '
        'mnuListaDeCotizaciones
        '
        Me.mnuListaDeCotizaciones.Enabled = False
        Me.mnuListaDeCotizaciones.Image = CType(resources.GetObject("mnuListaDeCotizaciones.Image"), System.Drawing.Image)
        Me.mnuListaDeCotizaciones.Name = "mnuListaDeCotizaciones"
        Me.mnuListaDeCotizaciones.Size = New System.Drawing.Size(233, 22)
        Me.mnuListaDeCotizaciones.Text = "Lista de cotizaciones"
        '
        'mnuVisualizarReq
        '
        Me.mnuVisualizarReq.Enabled = False
        Me.mnuVisualizarReq.Name = "mnuVisualizarReq"
        Me.mnuVisualizarReq.Size = New System.Drawing.Size(233, 22)
        Me.mnuVisualizarReq.Text = "Mostrar lista de requerimientos"
        Me.mnuVisualizarReq.Visible = False
        '
        'mnuActivarAlertasReq
        '
        Me.mnuActivarAlertasReq.Enabled = False
        Me.mnuActivarAlertasReq.Name = "mnuActivarAlertasReq"
        Me.mnuActivarAlertasReq.Size = New System.Drawing.Size(233, 22)
        Me.mnuActivarAlertasReq.Text = "Activar alertas de requerimientos"
        Me.mnuActivarAlertasReq.Visible = False
        '
        'mnuEliminarRequerimiento
        '
        Me.mnuEliminarRequerimiento.Enabled = False
        Me.mnuEliminarRequerimiento.Name = "mnuEliminarRequerimiento"
        Me.mnuEliminarRequerimiento.Size = New System.Drawing.Size(233, 22)
        Me.mnuEliminarRequerimiento.Text = "Eliminar requerimiento"
        Me.mnuEliminarRequerimiento.Visible = False
        '
        'mnuRegistrarCotización
        '
        Me.mnuRegistrarCotización.Enabled = False
        Me.mnuRegistrarCotización.Name = "mnuRegistrarCotización"
        Me.mnuRegistrarCotización.Size = New System.Drawing.Size(233, 22)
        Me.mnuRegistrarCotización.Text = "Registrar nueva cotización"
        Me.mnuRegistrarCotización.Visible = False
        '
        'mnuModificarCotizaciones
        '
        Me.mnuModificarCotizaciones.Enabled = False
        Me.mnuModificarCotizaciones.Name = "mnuModificarCotizaciones"
        Me.mnuModificarCotizaciones.Size = New System.Drawing.Size(233, 22)
        Me.mnuModificarCotizaciones.Text = "Modificar cotizaciones creadas"
        Me.mnuModificarCotizaciones.Visible = False
        '
        'mnuAprobarCotizaciones
        '
        Me.mnuAprobarCotizaciones.Enabled = False
        Me.mnuAprobarCotizaciones.Name = "mnuAprobarCotizaciones"
        Me.mnuAprobarCotizaciones.Size = New System.Drawing.Size(233, 22)
        Me.mnuAprobarCotizaciones.Text = "Aprobar cotizaciones creadas"
        Me.mnuAprobarCotizaciones.Visible = False
        '
        'mnuAbrirCotizaciones
        '
        Me.mnuAbrirCotizaciones.Enabled = False
        Me.mnuAbrirCotizaciones.Name = "mnuAbrirCotizaciones"
        Me.mnuAbrirCotizaciones.Size = New System.Drawing.Size(233, 22)
        Me.mnuAbrirCotizaciones.Text = "Abrir cotizaciones creadas"
        Me.mnuAbrirCotizaciones.Visible = False
        '
        'NuestrosProductosToolStripMenuItem
        '
        Me.NuestrosProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCatalogoProductos, Me.mnuRegistrarCategoria, Me.mnuRegistrarNuevasMarcas, Me.ToolStripMenuItem4, Me.mnuAgregarNuevoProducto, Me.mnuEliminarProducto, Me.mnuEditarProductosExistentes})
        Me.NuestrosProductosToolStripMenuItem.Name = "NuestrosProductosToolStripMenuItem"
        Me.NuestrosProductosToolStripMenuItem.Size = New System.Drawing.Size(113, 20)
        Me.NuestrosProductosToolStripMenuItem.Text = "Nuestros &Productos"
        Me.NuestrosProductosToolStripMenuItem.Visible = False
        '
        'mnuCatalogoProductos
        '
        Me.mnuCatalogoProductos.Enabled = False
        Me.mnuCatalogoProductos.Image = CType(resources.GetObject("mnuCatalogoProductos.Image"), System.Drawing.Image)
        Me.mnuCatalogoProductos.Name = "mnuCatalogoProductos"
        Me.mnuCatalogoProductos.Size = New System.Drawing.Size(206, 22)
        Me.mnuCatalogoProductos.Text = "Catálogo de productos"
        '
        'mnuRegistrarCategoria
        '
        Me.mnuRegistrarCategoria.Enabled = False
        Me.mnuRegistrarCategoria.Name = "mnuRegistrarCategoria"
        Me.mnuRegistrarCategoria.Size = New System.Drawing.Size(206, 22)
        Me.mnuRegistrarCategoria.Text = "Registrar nuevas categoria"
        '
        'mnuRegistrarNuevasMarcas
        '
        Me.mnuRegistrarNuevasMarcas.Enabled = False
        Me.mnuRegistrarNuevasMarcas.Name = "mnuRegistrarNuevasMarcas"
        Me.mnuRegistrarNuevasMarcas.Size = New System.Drawing.Size(206, 22)
        Me.mnuRegistrarNuevasMarcas.Text = "Registrar nuevas marcas"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(203, 6)
        Me.ToolStripMenuItem4.Visible = False
        '
        'mnuAgregarNuevoProducto
        '
        Me.mnuAgregarNuevoProducto.Enabled = False
        Me.mnuAgregarNuevoProducto.Name = "mnuAgregarNuevoProducto"
        Me.mnuAgregarNuevoProducto.Size = New System.Drawing.Size(206, 22)
        Me.mnuAgregarNuevoProducto.Text = "Agregar nuevo producto"
        Me.mnuAgregarNuevoProducto.Visible = False
        '
        'mnuEliminarProducto
        '
        Me.mnuEliminarProducto.Enabled = False
        Me.mnuEliminarProducto.Name = "mnuEliminarProducto"
        Me.mnuEliminarProducto.Size = New System.Drawing.Size(206, 22)
        Me.mnuEliminarProducto.Text = "Eliminar producto existente"
        Me.mnuEliminarProducto.Visible = False
        '
        'mnuEditarProductosExistentes
        '
        Me.mnuEditarProductosExistentes.Enabled = False
        Me.mnuEditarProductosExistentes.Name = "mnuEditarProductosExistentes"
        Me.mnuEditarProductosExistentes.Size = New System.Drawing.Size(206, 22)
        Me.mnuEditarProductosExistentes.Text = "Editar productos existentes"
        Me.mnuEditarProductosExistentes.Visible = False
        '
        'ServicioTécnicoToolStripMenuItem
        '
        Me.ServicioTécnicoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCalibraciones, Me.mnuSoftwares, Me.mnuIngresoEquipos})
        Me.ServicioTécnicoToolStripMenuItem.Name = "ServicioTécnicoToolStripMenuItem"
        Me.ServicioTécnicoToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ServicioTécnicoToolStripMenuItem.Text = "Servicio &Técnico"
        '
        'mnuCalibraciones
        '
        Me.mnuCalibraciones.Enabled = False
        Me.mnuCalibraciones.Image = CType(resources.GetObject("mnuCalibraciones.Image"), System.Drawing.Image)
        Me.mnuCalibraciones.Name = "mnuCalibraciones"
        Me.mnuCalibraciones.Size = New System.Drawing.Size(264, 22)
        Me.mnuCalibraciones.Text = "Manuales y calibraciones"
        '
        'mnuSoftwares
        '
        Me.mnuSoftwares.Enabled = False
        Me.mnuSoftwares.Image = CType(resources.GetObject("mnuSoftwares.Image"), System.Drawing.Image)
        Me.mnuSoftwares.Name = "mnuSoftwares"
        Me.mnuSoftwares.Size = New System.Drawing.Size(264, 22)
        Me.mnuSoftwares.Text = "Asistencia Técnica"
        '
        'mnuIngresoEquipos
        '
        Me.mnuIngresoEquipos.Enabled = False
        Me.mnuIngresoEquipos.Name = "mnuIngresoEquipos"
        Me.mnuIngresoEquipos.Size = New System.Drawing.Size(264, 22)
        Me.mnuIngresoEquipos.Text = "Ingreso de Equipos a Servicios Tecnicos"
        '
        'VerToolStripMenuItem1
        '
        Me.VerToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBarraDeHerramimentas, Me.mnuBarraDeEstados, Me.mnuRequerimientos})
        Me.VerToolStripMenuItem1.Name = "VerToolStripMenuItem1"
        Me.VerToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.VerToolStripMenuItem1.Text = "V&er"
        '
        'mnuBarraDeHerramimentas
        '
        Me.mnuBarraDeHerramimentas.Checked = True
        Me.mnuBarraDeHerramimentas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuBarraDeHerramimentas.Name = "mnuBarraDeHerramimentas"
        Me.mnuBarraDeHerramimentas.Size = New System.Drawing.Size(197, 22)
        Me.mnuBarraDeHerramimentas.Text = "Barra de herramimentas"
        '
        'mnuBarraDeEstados
        '
        Me.mnuBarraDeEstados.Checked = True
        Me.mnuBarraDeEstados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuBarraDeEstados.Name = "mnuBarraDeEstados"
        Me.mnuBarraDeEstados.Size = New System.Drawing.Size(197, 22)
        Me.mnuBarraDeEstados.Text = "Barra de estados"
        '
        'mnuRequerimientos
        '
        Me.mnuRequerimientos.Checked = True
        Me.mnuRequerimientos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRequerimientos.Name = "mnuRequerimientos"
        Me.mnuRequerimientos.Size = New System.Drawing.Size(197, 22)
        Me.mnuRequerimientos.Text = "Lista de requerimientos..."
        '
        'tmrFechaHora
        '
        Me.tmrFechaHora.Enabled = True
        '
        'tmrRecordatorios
        '
        Me.tmrRecordatorios.Interval = 1000
        '
        'panelAlerta
        '
        Me.panelAlerta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.panelAlerta.Controls.Add(Me.lblDescripcion)
        Me.panelAlerta.Controls.Add(Me.lblFrecuencia)
        Me.panelAlerta.Controls.Add(Me.Label1)
        Me.panelAlerta.Controls.Add(Me.lblCerrar)
        Me.panelAlerta.Controls.Add(Me.lblBienvenida)
        Me.panelAlerta.Controls.Add(Me.Label4)
        Me.panelAlerta.Location = New System.Drawing.Point(12, 107)
        Me.panelAlerta.Name = "panelAlerta"
        Me.panelAlerta.Size = New System.Drawing.Size(390, 156)
        Me.panelAlerta.TabIndex = 9
        Me.panelAlerta.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.Gray
        Me.lblDescripcion.Location = New System.Drawing.Point(126, 40)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(253, 94)
        Me.lblDescripcion.TabIndex = 1
        Me.lblDescripcion.Text = "Aqui se mostraran todas las alertas programadas por el usario del sistema y se po" & _
    "dran programar diariamente, semanalmente, mensualmente o seleccionar los dias de" & _
    " aviso."
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFrecuencia
        '
        Me.lblFrecuencia.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrecuencia.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblFrecuencia.Location = New System.Drawing.Point(11, 134)
        Me.lblFrecuencia.Name = "lblFrecuencia"
        Me.lblFrecuencia.Size = New System.Drawing.Size(368, 18)
        Me.lblFrecuencia.TabIndex = 5
        Me.lblFrecuencia.Text = "---"
        Me.lblFrecuencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 109)
        Me.Label1.TabIndex = 4
        '
        'lblCerrar
        '
        Me.lblCerrar.BackColor = System.Drawing.Color.White
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.Image = CType(resources.GetObject("lblCerrar.Image"), System.Drawing.Image)
        Me.lblCerrar.Location = New System.Drawing.Point(366, 1)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(24, 21)
        Me.lblCerrar.TabIndex = 2
        '
        'lblBienvenida
        '
        Me.lblBienvenida.Font = New System.Drawing.Font("Nirmala UI", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBienvenida.Location = New System.Drawing.Point(56, 22)
        Me.lblBienvenida.Name = "lblBienvenida"
        Me.lblBienvenida.Size = New System.Drawing.Size(323, 18)
        Me.lblBienvenida.TabIndex = 0
        Me.lblBienvenida.Text = "Hola!"
        Me.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(390, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Alerta programada"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrDesactivar
        '
        Me.tmrDesactivar.Interval = 1000
        '
        'tmrCambios_en_Permisos
        '
        '
        'panelRequerimientos
        '
        Me.panelRequerimientos.Controls.Add(Me.TabControl1)
        Me.panelRequerimientos.Controls.Add(Me.Panel2)
        Me.panelRequerimientos.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRequerimientos.Location = New System.Drawing.Point(810, 92)
        Me.panelRequerimientos.Name = "panelRequerimientos"
        Me.panelRequerimientos.Size = New System.Drawing.Size(321, 411)
        Me.panelRequerimientos.TabIndex = 12
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(88, 25)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(321, 381)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvRequerimientos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(313, 348)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "POR COTIZAR"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvRequerimientos
        '
        Me.dgvRequerimientos.AllowUserToAddRows = False
        Me.dgvRequerimientos.AllowUserToDeleteRows = False
        Me.dgvRequerimientos.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequerimientos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRequerimientos.ColumnHeadersHeight = 28
        Me.dgvRequerimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgvRequerimientos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvRequerimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRequerimientos.Location = New System.Drawing.Point(3, 3)
        Me.dgvRequerimientos.Name = "dgvRequerimientos"
        Me.dgvRequerimientos.ReadOnly = True
        Me.dgvRequerimientos.Size = New System.Drawing.Size(307, 342)
        Me.dgvRequerimientos.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "ITEM"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "POR COTIZAR"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column4
        '
        Me.Column4.HeaderText = "Estado"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Fecha"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvCotizados)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(313, 348)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "COTIZADOS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvCotizados
        '
        Me.dgvCotizados.AllowUserToAddRows = False
        Me.dgvCotizados.AllowUserToDeleteRows = False
        Me.dgvCotizados.BackgroundColor = System.Drawing.Color.White
        Me.dgvCotizados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCotizados.ColumnHeadersHeight = 28
        Me.dgvCotizados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgvCotizados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCotizados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCotizados.Location = New System.Drawing.Point(3, 3)
        Me.dgvCotizados.Name = "dgvCotizados"
        Me.dgvCotizados.ReadOnly = True
        Me.dgvCotizados.Size = New System.Drawing.Size(307, 342)
        Me.dgvCotizados.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "ITEM"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "COTIZADOS"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.panelCotizaciones)
        Me.Panel2.Controls.Add(Me.panelporCotizar)
        Me.Panel2.Controls.Add(Me.lblEst)
        Me.Panel2.Controls.Add(Me.panelEstado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 381)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(321, 30)
        Me.Panel2.TabIndex = 2
        '
        'panelCotizaciones
        '
        Me.panelCotizaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelCotizaciones.Location = New System.Drawing.Point(194, 0)
        Me.panelCotizaciones.Name = "panelCotizaciones"
        Me.panelCotizaciones.Size = New System.Drawing.Size(220, 30)
        Me.panelCotizaciones.TabIndex = 139
        Me.panelCotizaciones.Visible = False
        '
        'panelporCotizar
        '
        Me.panelporCotizar.Controls.Add(Me.cmdRefrescar)
        Me.panelporCotizar.Controls.Add(Me.cmdCotizar)
        Me.panelporCotizar.Controls.Add(Me.cmdAgregar)
        Me.panelporCotizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelporCotizar.Location = New System.Drawing.Point(0, 0)
        Me.panelporCotizar.Name = "panelporCotizar"
        Me.panelporCotizar.Size = New System.Drawing.Size(194, 30)
        Me.panelporCotizar.TabIndex = 138
        '
        'cmdRefrescar
        '
        Me.cmdRefrescar.Image = CType(resources.GetObject("cmdRefrescar.Image"), System.Drawing.Image)
        Me.cmdRefrescar.Location = New System.Drawing.Point(160, 2)
        Me.cmdRefrescar.Name = "cmdRefrescar"
        Me.cmdRefrescar.Size = New System.Drawing.Size(26, 26)
        Me.cmdRefrescar.TabIndex = 151
        Me.cmdRefrescar.UseVisualStyleBackColor = True
        '
        'cmdCotizar
        '
        Me.cmdCotizar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCotizar.Image = CType(resources.GetObject("cmdCotizar.Image"), System.Drawing.Image)
        Me.cmdCotizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCotizar.Location = New System.Drawing.Point(76, 2)
        Me.cmdCotizar.Name = "cmdCotizar"
        Me.cmdCotizar.Size = New System.Drawing.Size(78, 26)
        Me.cmdCotizar.TabIndex = 150
        Me.cmdCotizar.Text = "Cotizar..."
        Me.cmdCotizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCotizar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.Image = CType(resources.GetObject("cmdAgregar.Image"), System.Drawing.Image)
        Me.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAgregar.Location = New System.Drawing.Point(6, 2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(70, 26)
        Me.cmdAgregar.TabIndex = 149
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'lblEst
        '
        Me.lblEst.AutoSize = True
        Me.lblEst.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEst.Location = New System.Drawing.Point(219, 10)
        Me.lblEst.Name = "lblEst"
        Me.lblEst.Size = New System.Drawing.Size(49, 11)
        Me.lblEst.TabIndex = 136
        Me.lblEst.Text = "Eliminados"
        '
        'panelEstado
        '
        Me.panelEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(6, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.panelEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelEstado.Location = New System.Drawing.Point(200, 9)
        Me.panelEstado.Name = "panelEstado"
        Me.panelEstado.Size = New System.Drawing.Size(13, 13)
        Me.panelEstado.TabIndex = 134
        '
        'tmrSeguimientos
        '
        Me.tmrSeguimientos.Interval = 5
        '
        'tmrReactivar
        '
        Me.tmrReactivar.Interval = 1000
        '
        'tmrActualizarListaREQ
        '
        Me.tmrActualizarListaREQ.Interval = 1000
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 528)
        Me.Controls.Add(Me.panelRequerimientos)
        Me.Controls.Add(Me.BarHerramienta)
        Me.Controls.Add(Me.BarMenu)
        Me.Controls.Add(Me.BarEstado)
        Me.Controls.Add(Me.panelAlerta)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.BarMenu
        Me.Name = "MDIPrincipal"
        Me.Text = "Sistema Integrago de Gestion Administrativa, Ventas y Almacen - Balinsa S.A.C 201" & _
    "5"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarHerramienta.ResumeLayout(False)
        Me.BarHerramienta.PerformLayout()
        Me.BarEstado.ResumeLayout(False)
        Me.BarEstado.PerformLayout()
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        Me.panelAlerta.ResumeLayout(False)
        Me.panelRequerimientos.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvRequerimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvCotizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelporCotizar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BarEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents BarHerramienta As System.Windows.Forms.ToolStrip
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdAlamcen As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents mnuBEntrada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBSalida As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarNiveles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCambiarContrasena As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistroClientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuListaClientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEmitirFactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAnulaFactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlmacenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistraEntradaAlmacen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarSalidaAlmacen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStockProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIGV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProvincias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAcercade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents cmdFactura As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents VerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBarraDeHerramimentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBarraDeEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuManualUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CajaChicaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuOperacionesCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarConcepto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCerrarSesion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BmnuNotas As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRecordatorios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents BmnuCalibraciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BmnuSoftwares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServicioTécnicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCalibraciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSoftwares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrFechaHora As System.Windows.Forms.Timer
    Friend WithEvents tsslHora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrRecordatorios As System.Windows.Forms.Timer
    Friend WithEvents panelAlerta As System.Windows.Forms.Panel
    Friend WithEvents lblBienvenida As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents mnuBCatalogoProductos As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblProxHora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmrDesactivar As System.Windows.Forms.Timer
    Friend WithEvents lblFrecuencia As System.Windows.Forms.Label
    Friend WithEvents NuestrosProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCatalogoProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdminClientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGastosGeneralesAdministrativos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUsuariosRegistrados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCrearNuevasCajas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrCambios_en_Permisos As System.Windows.Forms.Timer
    Friend WithEvents mnuAdministraTodasCajas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarCategoria As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsslVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuListarFacturasGeneradas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBCaja As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents BmnuListadoCajas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BmnuDeclararGastos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarFactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBEmitirFactura As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuCorregirDatosFactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsslVersionDispo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuModificarIGV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVerEstadísticas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAsignarPermisos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDatosDeLaEmpresa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProgramarDatosDeActualización As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProgramarMantenimientoDelSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents panelRequerimientos As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblEst As System.Windows.Forms.Label
    Friend WithEvents panelEstado As System.Windows.Forms.Label
    Friend WithEvents tmrSeguimientos As System.Windows.Forms.Timer
    Friend WithEvents tmrReactivar As System.Windows.Forms.Timer
    Friend WithEvents mnuRegistrarNuevasMarcas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsslConexion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents panelporCotizar As System.Windows.Forms.Panel
    Friend WithEvents cmdCotizar As System.Windows.Forms.Button
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents mnuRequerimientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvRequerimientos As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents panelCotizaciones As System.Windows.Forms.Panel
    Friend WithEvents tmrActualizarListaREQ As System.Windows.Forms.Timer
    Friend WithEvents cmdRefrescar As System.Windows.Forms.Button
    Friend WithEvents dgvCotizados As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CotizacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuListaDeCotizaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerarRequerimiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGenerarCotizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuVisualizarReq As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuActivarAlertasReq As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarClientesDelSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAgregarNuevoProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditarProductosExistentes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarRequerimiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuModificarCotizaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegistrarCotización As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAprobarCotizaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbrirCotizaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IngresarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIngresoEquipos As System.Windows.Forms.ToolStripMenuItem

End Class
