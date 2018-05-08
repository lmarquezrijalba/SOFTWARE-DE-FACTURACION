CREATE DATABASE BD_BALINSA

USE BD_BALINSA

create table tb_configsis(
ID varchar(5) not null primary key,
IGV int not null default(0),
IGVConfig int  not null default(0),
enMantenimiento bit not null,
versionDisponible text not null,
archivoInstalador varbinary(MAX),
Extension char(10),
activarInstalacion bit not null default(0),
escanearPermisos bit not null default(0)
);

insert into tb_configsis values('UNICO', 0, 0, 0, '1.0.5.0', NULL, NULL, 0, 0);

create table tb_empresa(
EMP_RUC char(11) not null primary key,
EMP_RazonSocial varchar(50) not null,
EMP_Direccion varchar(80) not null,
EMP_Referencia varchar(80),
EMP_Fijos text,
EMP_Moviles text,
EMP_Email varchar(50),
EMP_Frase varchar(100),
EMP_Logo image
);

create table tb_niv_usuarios(
NUSU_Codigo int not null identity(1,1) primary key,
NUSU_Descripcion varchar(30) not null,
NUSU_Administra bit not null,
NUSU_Activo bit not null
);

insert into tb_niv_usuarios values('ADMINISTRADOR', 1, 1);

create table tb_permisos(
PER_Codigo int not null primary key,
PER_Descripcion varchar(50) not null,
PER_NombModulo varchar(50) not null,
PER_Activo bit not null
);

create table tb_permisos_x_nivel(
PXN_Codigo int not null identity(1,1) primary key,
PER_Codigo int not null foreign key references tb_permisos(PER_Codigo) on update cascade on delete cascade,
NUSU_Codigo int not null foreign key references tb_niv_usuarios(NUSU_Codigo) on update cascade
);

create table tb_usuarios(
USU_Codigo char(6) not null primary key,
NUSU_Codigo int not null foreign key references tb_niv_usuarios(NUSU_Codigo) on update cascade,
USU_ApePaterno varchar(50) not null,
USU_ApeMaterno varchar(50) not null,
USU_Nombres varchar(50) not null,
USU_Domicilio varchar(80) not null,
USU_Telefono char(12),
USU_Movil char(12),
USU_DNI char(8) not null,
USU_Login varchar(15) not null,
USU_Contrasena varchar(MAX) not null,
USU_FechaAlta datetime not null,
USU_Activo bit not null,
USU_Conectado bit
);

insert into tb_usuarios values('150001', '1', 'AD', 'IN', 'ADMIN', 'S/N', '', '', '00000000', 'admin+', 
'14CE151B', '19/10/2015', 1)

-----------notas x ususario--------------
-----------------------------------------
create table tb_alerta_x_usuarios(
ALERTA_Codigo int not null identity(1,1) primary key,
USU_Codigo char(6) not null foreign key references tb_usuarios(USU_Codigo) on update cascade,
ALERTA_Fecha date not null,
ALERTA_Hora char(5),
ALERTA_Descripcion text,
ALERTA_Frecuencia tinyint, --0->Desactivado 1->Diario 2->Semanal 3->Mensual / 4->Anual
ALERTA_Dom bit,
ALERTA_Lun bit,
ALERTA_Mar bit,
ALERTA_Mie bit,
ALERTA_Jue bit,
ALERTA_Vie bit,
ALERTA_Sab bit,
ALERTA_Activo bit
);

create table tb_notas_x_usuarios(
NOT_Codigo int not null identity(1,1) primary key,
NOT_Titulo varchar(200) not null,
USU_Codigo char(6) not null foreign key references tb_usuarios(USU_Codigo) on update cascade,
NOT_FechaHora datetime not null,
NOT_Descripcion text,
NOT_Activo bit default(1)
);

create table tb_clientes(
CLI_Codigo char(10) not null primary key,
USU_Codigo char(6) not null foreign key references tb_usuarios(USU_Codigo) on update cascade,
CLI_RazonSocial varchar(150) not null,
CLI_RUC char(11) not null,
CLI_Tipo char(1) not null,
CLI_Ciudad varchar(50),
CLI_DireccionLegal text,
CLI_Direccion1 text,
CLI_Direccion2 text,
CLI_Observacion text,
CLI_Activo bit
);

create table tb_contato_x_clientes(
CON_Codigo int identity(1,1) not null primary key,
CLI_Codigo char(10) not null foreign key references tb_clientes(CLI_Codigo) on update cascade on delete cascade,
CON_Nombres varchar(50),
CON_Cargo varchar(50),
CON_Telefono text,
CON_Correo text,
CON_Observacion text,
CON_Tarjeta image
);

create table tb_provincias(
PROV_Codigo int identity(1,1) not null  primary key,
PROV_Nombre varchar(50),
PROV_Activo bit not null
);

--------------------------------------------
--------------TERCERA PARTE-----------------
--------------------------------------------
create table tb_categorias(
CAT_Codigo int identity(1,1) not null primary key,
CAT_Nombre varchar(50) not null,
esBALANZA bit not null default(0),
CAT_Activo bit
);

create table tb_marcas(
MAR_Codigo char(4) not null primary key,
CAT_Codigo int not null foreign key references tb_categorias(CAT_Codigo) on update cascade,
MAR_Nombre varchar(50) not null,
MAR_Activo bit
);

create table tb_productos(
PRD_Codigo int identity(1,1) not null primary key,
MAR_Codigo char(4) foreign key references tb_marcas(MAR_Codigo)on update cascade,
PRD_Modelo varchar(50),
CAT_Codigo int,
PRD_Estructura varchar(50),
PRD_Plataforma varchar(50),
PRD_CodBarras char(10),
PRD_Nombre varchar(50),
PRD_Moneda char(1) not null,
PRD_Precio money not null default(0),
PRD_Dscto int,
PRD_Stock int,
PRD_Especificaciones text,
PRD_Imagen image,
PRD_Activo bit
);

ALTER TABLE tb_productos
ALTER COLUMN PRD_Moneda char(1)
---------------------------------------------------------
---------------DATOS DE LA FACTURA-----------------------
---------------------------------------------------------
create table tb_facturas(
FAC_Codigo char(10) not null primary key,
FAC_Talonario char(4) not null,
FAC_Nro char(6) not null,
FAC_GR char(10),
FAC_GRT char(10),
USU_Codigo_Registro char(6) not null,
USU_Codigo_Edito char(6),
CLI_Codigo char(10),
FAC_Moneda char(1) not null, -- (S) SOLES, (D) DOLARES
FAC_Tipo bit, -- (0) CONTADO, (1) CREDITO
FAC_Dias int default(0),
FAC_Fecha datetime not null,
FAC_IGV int not null,
FAC_Subtotal money not null,
FAC_valIGV money not null,
FAC_Total money not null,
FAC_Observacion text,
FAC_Activo bit not null -- (0) ANULADA, (1) OK
);

create table tb_detalle_facturas(
DFAC_Codigo int not null identity(1,1) primary key,
FAC_Codigo char(10) not null foreign key references tb_facturas(FAC_Codigo)on update cascade,
PRD_Codigo int foreign key references tb_productos(PRD_Codigo) on update cascade on delete cascade,
DFAC_Descripcion text not null,
DFAC_Cantidad int not null,
DFAC_Precio money not null,
DFAC_Dscto money not null default(0),
DFAC_Activo bit not null default(1),
);

-------------------------------------------------
---------------SEGUNDA PARTE---------------------
-------------------------------------------------
create table tb_conceptos(
CON_Codigo char(4) not null primary key,
CON_Descripcion varchar(30) not null,
CON_Tipo char(1) not null,
CON_RetornaDin bit not null,
CON_Activo bit not null default(1)
);

INSERT INTO tb_conceptos VALUES('0','OTROS','E', '1','1');
INSERT INTO tb_conceptos VALUES('T001','CIERRE DE CAJA','I', '0','1');
INSERT INTO tb_conceptos VALUES('I002','INGRESO DE DINERO A CAJA','I', '0','1');
INSERT INTO tb_conceptos VALUES('A007','APERTURA DE CAJA','I', '0','1');

create table tb_cajas(
CAJ_Codigo int not null identity(1,1) primary key,
USU_Codigo char(6) not null, --USUARIO REGISTRA CAJA
CAJ_Nombre varchar(50) not null,
CAJ_Principal bit not null,
CAJ_Aperturado tinyint not null
);

create table tb_movimiento_cajas(
MCAJ_Codigo int not null identity(1,1) primary key,
MCAJ_NroOperacion char(4) not null,
CAJ_Codigo int not null foreign key references tb_cajas(CAJ_Codigo) on update cascade on delete cascade,
CON_Codigo char(4) not null foreign key references tb_conceptos(CON_Codigo) on update cascade,
MCAJ_Pagador char(6) not null,
MCAJ_Recibidor char(6),
MCAJ_Tipo char(1) not null,
MCAJ_FechaHora datetime not null,
MCAJ_MontoSoles money default(0),
MCAJ_MontoDolares money default(0),
MCAJ_Proveniente text,
MCAJ_Detalle text,
MCAJ_Activo char(1) not null  --> 1-->GENERADOS, 2-->PENDIENTES, 0-->TERMINADOS, X-->Eliminados
);

alter table tb_movimiento_cajas
alter column MCAJ_Activo char(1)

create table tb_detalle_gastos(
DGAS_Codigo int not null identity(1,1) primary key,
MCAJ_Codigo int not null foreign key references tb_movimiento_cajas(MCAJ_Codigo) on update cascade on delete cascade,
DGAS_Descripcion text not null,
DGAS_MontoSoles money not null default(0),
DGAS_MontoDolares money not null default(0),
DGAS_Activo bit not null
);

--=======================================
--CALIBRACIONES
--=======================================
create table tb_calibraciones(
CAL_Codigo int not null identity(1,1) primary key,
MAR_Codigo char(4) not null,
Modelo varchar(50),
Archivo varbinary(MAX) not null,
CAL_Imagen image,
extension char(6) not null
);

--========================================
--COTIZACIONES
--========================================
create table tb_requerimientos(
REQ_Codigo char(10) not null primary key,
CLI_Codigo char(10) not null foreign key references tb_clientes(CLI_Codigo) on update cascade,
USU_Codigo char(6) not null,
REQ_Tipo char(1) not null, --(B)BALANZAS / (C)CAMARAS
REQ_Fecha date not null,
REQ_FechaSeg date,
REQ_Descripcion text,
REQ_Observacion text,
REQ_Estado char(1) --(0)SIN COTIZAR / (1)COTIZADO / (X)ELIMINADO
);

create table tb_cotizaciones(
COT_Codigo char(10) not null primary key,
CLI_Codigo char(10) not null foreign key references tb_clientes(CLI_Codigo) on update cascade,
USU_Codigo char(6) not null,
COT_Descripcion text not null,
COT_Garantia text, --TIEMPO DE LA GARANTIA
COT_Fecha datetime not null, --DE LA COTIZACION
COT_FechaSeg date,
COT_Dias int, --DE ENTREGA
COT_Valides int, --EN DIAS
COT_IGV int not null,
COT_PORMAT int, --% DE MATERIALES
COT_CONINST bit not null, --INCLUIDO INSTALACION
COT_CONIGV bit not null, --INCLUIDO IGV
COT_VERPREC bit not null,
COT_Moneda char(1), --(S)SOLES / (D)DOLARES
COT_Importe money, --SUBTOTAL DE LA COTIZACION
COT_FormaPago text,
COT_Observacion text,
COT_Estado char(1) --(1)REGISTRADA / (2)APROBADA
);

create table tb_detalle_cotizaciones(
DCOT_Codigo int not null identity(1,1) primary key,
COT_Codigo char(10) not null foreign key references tb_cotizaciones(COT_Codigo) on update cascade,
PRD_Codigo int foreign key references tb_productos(PRD_Codigo) on update cascade,
DCOT_Precio money,
DCOT_Cant int,
DCOT_Activo bit default(1)
);

create table tb_asistencia_tecnicas(
AST_Codigo char(6) primary key not null,
CLI_Codigo char(10) not null foreign key references tb_clientes(CLI_Codigo) on update cascade,
AST_Ciudad varchar(80),
AST_Tipo char(2) not null, --> (RL)RICE LAKE / (CM)CAMIONES / (CA)CAMARAS
AST_Activo bit default(1)
);

create table tb_detalle_asistencias(
DAST_Codigo int identity(1,1)primary key not null,
AST_Codigo char(6) not null foreign key references tb_asistencia_tecnicas(AST_Codigo) on update cascade,
DAST_Fecha date,
DAST_Estado bit default(1) --> (0)VENCIDO (1)ACTIVO
);