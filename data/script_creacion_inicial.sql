USE [GD1C2016]
GO
IF NOT EXISTS ( SELECT  * FROM sys.schemas WHERE name = 'Class' ) 
    EXEC('CREATE SCHEMA Class');
GO
--Drop procedure, trigger y view
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('class.VerificarPublicacionesGratis'))
		drop PROCEDURE Class.VerificarPublicacionesGratis
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('class.CrearPublicacion'))
		drop PROCEDURE Class.CrearPublicacion
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('class.ModificarPublicacion'))
		drop PROCEDURE Class.ModificarPublicacion
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('class.NuevaOferta'))
		drop PROCEDURE Class.NuevaOferta
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('class.Insertar_Compra'))
		drop PROCEDURE Class.Insertar_Compra
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'TR' AND OBJECT_ID = OBJECT_ID('class.emitir_factura_subasta'))
		drop trigger class.emitir_factura_subasta
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'Calificaciones' and type='V')
		drop view class.Calificaciones
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('class.Nueva_Calificacion'))
		drop PROCEDURE Class.Nueva_Calificacion
		
GO
--Drop de constraint si ya existen

IF OBJECT_ID('Class.FK_Calificacion_Publicacion', 'F') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Publicacion
IF OBJECT_ID('Class.FK_Calificacion_Compra', 'F') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Compra
IF OBJECT_ID('Class.FK_Compra_Publicacion', 'F') IS NOT NULL
		alter table Class.Compra drop CONSTRAINT FK_Compra_Publicacion
IF OBJECT_ID('Class.FK_Compra_Usuario', 'F') IS NOT NULL
		alter table Class.Compra drop CONSTRAINT FK_Compra_Usuario
IF OBJECT_ID('Class.FK_RolUsuario_Rol', 'F') IS NOT NULL
		alter table Class.rolUsuario drop CONSTRAINT FK_RolUsuario_Rol
IF OBJECT_ID('Class.FK_RolUsuario_Usuario', 'F') IS NOT NULL
		alter table Class.rolUsuario drop CONSTRAINT FK_RolUsuario_Usuario
IF OBJECT_ID('Class.FK_Usuario_Rol', 'F') IS NOT NULL
		alter table Class.Usuario drop CONSTRAINT FK_Usuario_Rol
IF OBJECT_ID('Class.FK_Calificacion_Usuario_1', 'F') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Usuario_1
IF OBJECT_ID('Class.FK_Calificacion_Usuario_2', 'F') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Usuario_2
IF OBJECT_ID('Class.FK_Compra_Usuario', 'F') IS NOT NULL
		alter table Class.Compra drop CONSTRAINT FK_Compra_Usuario
IF OBJECT_ID('Class.FK_Subasta_Usuario', 'F') IS NOT NULL
		alter table Class.Subasta drop CONSTRAINT FK_Subasta_Usuario
IF OBJECT_ID('Class.FK_Publicacion_Usuario', 'F') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Usuario
IF OBJECT_ID('Class.FK_Persona_Usuario', 'F') IS NOT NULL
		alter table Class.Persona drop CONSTRAINT FK_Persona_Usuario
IF OBJECT_ID('Class.FK_Empresa_Usuario', 'F') IS NOT NULL
		alter table Class.Empresa drop CONSTRAINT FK_Empresa_Usuario
IF OBJECT_ID('Class.FK_Detalle_Publicacion', 'F') IS NOT NULL
		alter table Class.Detalle drop CONSTRAINT FK_Detalle_Publicacion
IF OBJECT_ID('Class.FK_Detalle_TipoItem', 'F') IS NOT NULL
		alter table Class.Detalle drop CONSTRAINT FK_Detalle_TipoItem
IF OBJECT_ID('Class.FK_Factura_Publicacion', 'F') IS NOT NULL
		alter table Class.Factura drop CONSTRAINT FK_Factura_Publicacion
IF OBJECT_ID('Class.FK_Subasta_Publicacion', 'F') IS NOT NULL
		alter table Class.Subasta drop CONSTRAINT FK_Subasta_Publicacion
IF OBJECT_ID('Class.FK_Publicacion_Visibilidad', 'F') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Visibilidad
IF OBJECT_ID('Class.FK_Publicacion_Rubro', 'F') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Rubro
IF OBJECT_ID('Class.FK_Publicacion_TipoPublicacion', 'F') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_TipoPublicacion
IF OBJECT_ID('Class.FK_Publicacion_Estado', 'F') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Estado
IF OBJECT_ID('Class.FK_RolFuncionalidad_Rol', 'F') IS NOT NULL
		alter table Class.RolFuncionalidad drop CONSTRAINT FK_RolFuncionalidad_Rol
IF OBJECT_ID('Class.FK_RolFuncionalidad_Funcionalidad', 'F') IS NOT NULL

IF OBJECT_ID('Class.FK_Calificacion_Publicacion') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Publicacion
IF OBJECT_ID('Class.FK_Calificacion_Compra') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Compra
IF OBJECT_ID('Class.FK_Compra_Publicacion') IS NOT NULL
		alter table Class.Compra drop CONSTRAINT FK_Compra_Publicacion
IF OBJECT_ID('Class.FK_Compra_Usuario') IS NOT NULL
		alter table Class.Compra drop CONSTRAINT FK_Compra_Usuario
IF OBJECT_ID('Class.FK_RolUsuario_Rol') IS NOT NULL
		alter table Class.rolUsuario drop CONSTRAINT FK_RolUsuario_Rol
IF OBJECT_ID('Class.FK_RolUsuario_Usuario') IS NOT NULL
		alter table Class.rolUsuario drop CONSTRAINT FK_RolUsuario_Usuario
IF OBJECT_ID('Class.FK_Usuario_Rol') IS NOT NULL
		alter table Class.Usuario drop CONSTRAINT FK_Usuario_Rol
IF OBJECT_ID('Class.FK_Calificacion_Usuario_1') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Usuario_1
IF OBJECT_ID('Class.FK_Calificacion_Usuario_2') IS NOT NULL
		alter table Class.Calificacion drop CONSTRAINT FK_Calificacion_Usuario_2
IF OBJECT_ID('Class.FK_Compra_Usuario') IS NOT NULL
		alter table Class.Compra drop CONSTRAINT FK_Compra_Usuario
IF OBJECT_ID('Class.FK_Subasta_Usuario') IS NOT NULL
		alter table Class.Subasta drop CONSTRAINT FK_Subasta_Usuario
IF OBJECT_ID('Class.FK_Publicacion_Usuario') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Usuario
IF OBJECT_ID('Class.FK_Persona_Usuario') IS NOT NULL
		alter table Class.Persona drop CONSTRAINT FK_Persona_Usuario
IF OBJECT_ID('Class.FK_Empresa_Usuario') IS NOT NULL
		alter table Class.Empresa drop CONSTRAINT FK_Empresa_Usuario
IF OBJECT_ID('Class.FK_Detalle_Publicacion') IS NOT NULL
		alter table Class.Detalle drop CONSTRAINT FK_Detalle_Publicacion
IF OBJECT_ID('Class.FK_Detalle_TipoItem') IS NOT NULL
		alter table Class.Detalle drop CONSTRAINT FK_Detalle_TipoItem
IF OBJECT_ID('Class.FK_Factura_Publicacion') IS NOT NULL
		alter table Class.Factura drop CONSTRAINT FK_Factura_Publicacion
IF OBJECT_ID('Class.FK_Subasta_Publicacion') IS NOT NULL
		alter table Class.Subasta drop CONSTRAINT FK_Subasta_Publicacion
IF OBJECT_ID('Class.FK_Publicacion_Visibilidad') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Visibilidad
IF OBJECT_ID('Class.FK_Publicacion_Rubro') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Rubro
IF OBJECT_ID('Class.FK_Publicacion_TipoPublicacion') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_TipoPublicacion
IF OBJECT_ID('Class.FK_Publicacion_Estado') IS NOT NULL
		alter table Class.Publicacion drop CONSTRAINT FK_Publicacion_Estado
IF OBJECT_ID('Class.FK_RolFuncionalidad_Rol') IS NOT NULL
		alter table Class.RolFuncionalidad drop CONSTRAINT FK_RolFuncionalidad_Rol
IF OBJECT_ID('Class.FK_RolFuncionalidad_Funcionalidad') IS NOT NULL
		alter table Class.RolFuncionalidad drop CONSTRAINT FK_RolFuncionalidad_Funcionalidad

--Drop de tablas si ya existen
IF OBJECT_ID('Class.Compra', 'U') IS NOT NULL
		DROP TABLE Class.Compra;
IF OBJECT_ID('Class.Detalle', 'U') IS NOT NULL
		DROP TABLE Class.Detalle;
IF OBJECT_ID('Class.TipoItem', 'U') IS NOT NULL
		DROP TABLE Class.TipoItem;
IF OBJECT_ID('Class.Factura', 'U') IS NOT NULL
		DROP TABLE Class.Factura;
IF OBJECT_ID('Class.Pregunta', 'U') IS NOT NULL
		DROP TABLE Class.Pregunta;
IF OBJECT_ID('Class.Calificacion', 'U') IS NOT NULL
		DROP TABLE Class.Calificacion;
IF OBJECT_ID('Class.Subasta', 'U') IS NOT NULL
		DROP TABLE Class.Subasta;
IF OBJECT_ID('Class.Publicacion', 'U') IS NOT NULL
		DROP TABLE Class.Publicacion;
IF OBJECT_ID('Class.Estado', 'U') IS NOT NULL
		DROP TABLE Class.Estado;
IF OBJECT_ID('Class.Visibilidad', 'U') IS NOT NULL
		DROP TABLE Class.Visibilidad;
IF OBJECT_ID('Class.Rubro', 'U') IS NOT NULL
		DROP TABLE Class.Rubro;
IF OBJECT_ID('Class.TipoPublicacion', 'U') IS NOT NULL
		DROP TABLE Class.TipoPublicacion;
IF OBJECT_ID('Class.Empresa', 'U') IS NOT NULL
		DROP TABLE Class.Empresa;
IF OBJECT_ID('Class.Persona', 'U') IS NOT NULL
		DROP TABLE Class.Persona;
IF OBJECT_ID('Class.rolUsuario', 'U') IS NOT NULL
		DROP TABLE Class.rolUsuario;
IF OBJECT_ID('Class.Usuario', 'U') IS NOT NULL
		DROP TABLE Class.Usuario;
IF OBJECT_ID('Class.RolFuncionalidad', 'U') IS NOT NULL
		DROP TABLE Class.RolFuncionalidad;
IF OBJECT_ID('Class.Funcionalidad', 'U') IS NOT NULL
		DROP TABLE Class.Funcionalidad;
IF OBJECT_ID('Class.Rol', 'U') IS NOT NULL
		DROP TABLE Class.Rol;
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name='psencriptar')
		DROP FUNCTION Class.psencriptar;
GO

--Creación de tablas
CREATE TABLE Class.Rol
(
		IdRol			int IDENTITY(1,1) PRIMARY KEY,
		Nombre			nvarchar(255) NOT NULL,
		EstaHabilitado	bit NOT NULL
);


CREATE TABLE Class.Funcionalidad
(
		IdFuncionalidad	int IDENTITY(1,1) PRIMARY KEY,
		Nombre			nvarchar(255) NOT NULL
);


CREATE TABLE Class.RolFuncionalidad
(
		IdRol			int not null,
		IdFuncionalidad	int not null,
		TienePermisos	bit NOT NULL,
		CONSTRAINT FK_RolFuncionalidad_Rol FOREIGN KEY (IdRol) REFERENCES Class.Rol (IdRol),
		CONSTRAINT FK_RolFuncionalidad_Funcionalidad FOREIGN KEY (IdFuncionalidad) REFERENCES Class.Funcionalidad (IdFuncionalidad),
		PRIMARY KEY (IdRol, IdFuncionalidad)
);

CREATE TABLE Class.Usuario
(
		IdUsuario		int IDENTITY(1,1) PRIMARY KEY,
		Usuario			nvarchar(255) UNIQUE NOT NULL,
		Clave			varbinary(4000) NOT NULL,
		EstaHabilitado	bit NOT NULL,		
		LoginFallidos	int NOT NULL DEFAULT 0,
		Mail			nvarchar(255) NOT NULL,
		Telefono		nvarchar(20),
		Ciudad			nvarchar(100),
		Calle			nvarchar(200) not null,
		Numero			nvarchar(9) not null,
		Piso			nvarchar(9),
		Depto			nvarchar(100),
		Localidad		nvarchar(100),
		CodigoPostal	nvarchar(100) not null,
		PublicacionesGratuitas int not null,
);


CREATE TABLE Class.Persona
(
		IdUsuario		int not null,
		Nombre			nvarchar(255) NOT NULL,
		Apellido		nvarchar(255) NOT NULL,
		TipoDocumento	nvarchar(4) NOT NULL,
		Dni				nvarchar(20) NOT NULL,
		FechaNac		date NOT NULL,
		FechaCreacion	date NOT NULL,
		CONSTRAINT FK_Persona_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);

CREATE TABLE Class.Empresa
(
		IdUsuario		int not null,
		RazonSocial		nvarchar(255) NOT NULL,
		Cuit			nvarchar(24) NOT NULL,
		NombreContacto	nvarchar(255),
		Rubro			nvarchar(255),
		CONSTRAINT FK_Empresa_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);

CREATE TABLE Class.rolUsuario
(
		Orden		int not null,
		IdUsuario	int NOT NULL,
		IdRol		int not null
		CONSTRAINT FK_RolUsuario_Rol FOREIGN KEY (IdRol) REFERENCES Class.Rol (IdRol),
		CONSTRAINT FK_RolUsuario_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);

CREATE TABLE Class.TipoPublicacion
(
		IdTipo			int IDENTITY(1,1) PRIMARY KEY not null,
		Descripcion		nvarchar(255) NOT NULL
);

CREATE TABLE Class.Rubro
(
		IdRubro			int IDENTITY(1,1) PRIMARY KEY not null,
		Desc_corta		nvarchar(50) NOT NULL,
		Desc_larga		nvarchar(255) NOT NULL
);

CREATE TABLE Class.Visibilidad
(
		IdVisibilidad	int IDENTITY(1,1) PRIMARY KEY not null,
		Descripcion		nvarchar(50) NOT NULL,
		Grado			int NOT NULL,
		Porcentaje		numeric(18,2) not null,
		Costo			numeric(18,2) not null,
		TieneEnvio		bit not null,
		CostoEnvio		numeric(18,2) not null
);

CREATE TABLE Class.Estado
(
		IdEstado		int IDENTITY(1,1) PRIMARY KEY not null,
		Descripcion		nvarchar(50) NOT NULL
);

CREATE TABLE Class.Publicacion
(
		IdPublicacion		int IDENTITY(1,1) PRIMARY KEY not null,
		Descripcion			nvarchar(510) NOT NULL,
		Stock				int NOT NULL,
		FechaInicio			date not null,
		FechaVencimiento	date not null,
		Precio				numeric(18,2) not null,
		IdRubro				int not null,
		IdVisibilidad		int not null,
		IdUsuario			int not null,
		IdEstado			int not null,
		IdTipo				int not null,
		Envio				bit not null,
		IdAnterior			numeric(18,0),
		CONSTRAINT FK_Publicacion_Visibilidad FOREIGN KEY (IdVisibilidad) REFERENCES Class.Visibilidad (IdVisibilidad),
		CONSTRAINT FK_Publicacion_Rubro FOREIGN KEY (IdRubro) REFERENCES Class.Rubro (IdRubro),
		CONSTRAINT FK_Publicacion_TipoPublicacion FOREIGN KEY (IdTipo) REFERENCES Class.TipoPublicacion (IdTipo),
		CONSTRAINT FK_Publicacion_Estado FOREIGN KEY (IdEstado) REFERENCES Class.Estado (IdEstado),
		CONSTRAINT FK_Publicacion_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);

CREATE TABLE Class.Subasta
(
		IdPublicacion	int not null,
		IdUsuario		int not null,
		Monto			numeric(18,2) not null,
		FechayHora		datetime not null,
		CONSTRAINT FK_Subasta_Publicacion FOREIGN KEY (IdPublicacion) REFERENCES Class.Publicacion (IdPublicacion),
		CONSTRAINT FK_Subasta_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);


CREATE TABLE Class.Factura
(
		IdFactura		int IDENTITY(1,1) PRIMARY KEY not null,
		IdPublicacion	int not null,
		Numero			numeric(18,0),
		Total			numeric(18,2) not null,
		Fecha			date not null,
		FormaPago		nvarchar(50) NOT NULL,
		CONSTRAINT FK_Factura_Publicacion FOREIGN KEY (IdPublicacion) REFERENCES Class.Publicacion (IdPublicacion)
);

CREATE TABLE Class.TipoItem
(
		IdItem		int IDENTITY(1,1) PRIMARY KEY not null,
		Descripcion		nvarchar(50) NOT NULL
);

CREATE TABLE Class.Detalle
(
		IdFactura		int not null,
		IdItem			int not null,
		Cantidad		int not null,
		Monto			numeric(18,2) not null,
		CONSTRAINT FK_Detalle_Factura FOREIGN KEY (IdFactura) REFERENCES Class.Factura (IdFactura),
		CONSTRAINT FK_Detalle_TipoItem FOREIGN KEY (IdItem) REFERENCES Class.TipoItem (IdItem)
);

CREATE TABLE Class.Compra
(
		IdCompra		int IDENTITY(1,1) PRIMARY KEY not null,
		IdPublicacion	int not null,
		IdUsuario		int not null,
		Fecha			date not null,
		Cantidad		int not null,
		Monto			numeric(18,2) not null,
		CONSTRAINT FK_Compra_Publicacion FOREIGN KEY (IdPublicacion) REFERENCES Class.Publicacion (IdPublicacion),
		CONSTRAINT FK_Compra_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);

CREATE TABLE Class.Calificacion
(
		IdPublicacion	int not null,
		IdUsuarioPub	int not null,
		IdUsuarioCom	int not null,
		IdCompra		int not null,
		Calificacion	int not null,
		Detalle			varchar(255),
		FechayHora		datetime,
		CONSTRAINT FK_Calificacion_Publicacion FOREIGN KEY (IdPublicacion) REFERENCES Class.Publicacion (IdPublicacion),
		CONSTRAINT FK_Calificacion_Usuario_1 FOREIGN KEY (IdUsuarioPub) REFERENCES Class.Usuario (IdUsuario),
		CONSTRAINT FK_Calificacion_Usuario_2 FOREIGN KEY (IdUsuarioCom) REFERENCES Class.Usuario (IdUsuario),
		CONSTRAINT FK_Calificacion_Compra FOREIGN KEY (IdCompra) REFERENCES Class.Compra (IdCompra)
);

GO
create function [Class].[psencriptar] (@pass nvarchar(4000))
returns nvarchar(4000) as
begin
return(select hashbytes('sha2_256',@pass))
end;
GO

BEGIN TRAN
insert into class.rol values ('Administrador','1')
insert into class.rol values ('Cliente','1')
insert into class.rol values ('Empresa','1')

insert into class.Funcionalidad values ('USUARIO')
insert into class.Funcionalidad values ('ROLES')
insert into class.Funcionalidad values ('VISIBILIDAD')
insert into class.Funcionalidad values ('CALIFICAR')
insert into class.Funcionalidad values ('COMPRA')
insert into class.Funcionalidad values ('FACTURAS')
insert into class.Funcionalidad values ('PUBLICACION')
insert into class.Funcionalidad values ('HISTORIAL')
insert into class.Funcionalidad values ('LISTADO ESTADISTICO')

insert into class.RolFuncionalidad values (1,1,1)
insert into class.RolFuncionalidad values (1,2,1)
insert into class.RolFuncionalidad values (1,3,1)
insert into class.RolFuncionalidad values (1,4,1)
insert into class.RolFuncionalidad values (1,5,1)
insert into class.RolFuncionalidad values (1,6,1)
insert into class.RolFuncionalidad values (1,7,1)
insert into class.RolFuncionalidad values (1,8,1)
insert into class.RolFuncionalidad values (1,9,1)

insert into class.RolFuncionalidad values (2,1,0)
insert into class.RolFuncionalidad values (2,2,0)
insert into class.RolFuncionalidad values (2,3,0)
insert into class.RolFuncionalidad values (2,4,1)
insert into class.RolFuncionalidad values (2,5,1)
insert into class.RolFuncionalidad values (2,6,0)
insert into class.RolFuncionalidad values (2,7,1)
insert into class.RolFuncionalidad values (2,8,1)
insert into class.RolFuncionalidad values (2,9,0)

insert into class.RolFuncionalidad values (3,1,0)
insert into class.RolFuncionalidad values (3,2,0)
insert into class.RolFuncionalidad values (3,3,0)
insert into class.RolFuncionalidad values (3,4,1)
insert into class.RolFuncionalidad values (3,5,1)
insert into class.RolFuncionalidad values (3,6,0)
insert into class.RolFuncionalidad values (3,7,1)
insert into class.RolFuncionalidad values (3,8,1)
insert into class.RolFuncionalidad values (3,9,0)

insert into class.Usuario (usuario,clave,EstaHabilitado,LoginFallidos,mail,calle,Numero,CodigoPostal,PublicacionesGratuitas) values
('admin',convert(varbinary,Class.psencriptar('w23e')),1,'0','','',0,'',0)

insert into class.Usuario (usuario,clave,EstaHabilitado,LoginFallidos,mail,calle,numero,piso,Depto,CodigoPostal,PublicacionesGratuitas)
(select Publ_Cli_Dni usuario,convert(varbinary,Class.psencriptar(CONVERT(nvarchar(4000), Publ_Cli_Dni))),1,0,Publ_Cli_Mail mail,Publ_Cli_Dom_Calle calle,Publ_Cli_Nro_Calle nro,Publ_Cli_Piso piso,Publ_Cli_Depto depto,
Publ_Cli_Cod_Postal postal,0 from gd_esquema.Maestra where not(Publ_Cli_Dni is null)  
group by Publ_Cli_Dni,Publ_Cli_Mail,Publ_Cli_Dom_Calle,Publ_Cli_Nro_Calle,Publ_Cli_Piso,Publ_Cli_Depto,Publ_Cli_Cod_Postal union
select Cli_Dni usuario,convert(varbinary,Class.psencriptar(CONVERT(nvarchar(4000), Cli_Dni))),1,0,Cli_Mail mail ,Cli_Dom_Calle calle ,Cli_Nro_Calle nro,Cli_Piso,Cli_Depto depto,
Cli_Cod_Postal postal,0 from gd_esquema.Maestra where not(Cli_Dni is null)  
group by Cli_Dni,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal)


insert into class.persona (IdUsuario,Nombre,Apellido,TipoDocumento,Dni,FechaNac,FechaCreacion)
(select usuario.idusuario,Publ_Cli_Nombre nombre,Publ_Cli_Apeliido apellido,'DNI',Publ_Cli_Dni dni,Publ_Cli_Fecha_Nac fec_nac, getdate()
from gd_esquema.Maestra join class.usuario on ltrim(rtrim(Publ_Cli_Dni))=usuario where not(Publ_Cli_Dni is null)  
group by usuario.idusuario,Publ_Cli_Nombre,Publ_Cli_Apeliido,Publ_Cli_Dni,Publ_Cli_Fecha_Nac
union
select usuario.idusuario,Cli_Nombre nombre,Cli_Apeliido apellido,'DNI',Cli_Dni dni,Cli_Fecha_Nac fec_nac, getdate()
from gd_esquema.Maestra join class.usuario on ltrim(rtrim(Cli_Dni))=usuario where not(Cli_Dni is null)  
group by usuario.idusuario,Cli_Nombre,Cli_Apeliido,Cli_Dni,Cli_Fecha_Nac)

insert into class.Usuario (usuario,clave,EstaHabilitado,LoginFallidos,mail,calle,numero,piso,Depto,CodigoPostal,PublicacionesGratuitas)
(select replace(Publ_Empresa_Cuit,'-','') usuario,convert(varbinary,Class.psencriptar(CONVERT(nvarchar(4000), replace(Publ_Empresa_Cuit,'-',''))))
,1,0,Publ_Empresa_Mail mail,Publ_Empresa_Dom_Calle calle,Publ_Empresa_Nro_Calle nro,Publ_Empresa_Piso piso,Publ_Empresa_Depto depto,
Publ_Empresa_Cod_Postal postal,0 from gd_esquema.Maestra where not(Publ_Empresa_Cuit is null)  
group by Publ_Empresa_Cuit,Publ_Empresa_Mail,Publ_Empresa_Dom_Calle,Publ_Empresa_Nro_Calle,Publ_Empresa_Piso,
Publ_Empresa_Depto,Publ_Empresa_Cod_Postal)

insert into class.empresa (IdUsuario,RazonSocial,cuit)
(select usuario.idusuario,Publ_Empresa_Razon_Social,replace(Publ_Empresa_Cuit,'-','')
from gd_esquema.Maestra join class.usuario on replace(Publ_Empresa_Cuit,'-','')=usuario where not(Publ_Empresa_Cuit is null)  
group by usuario.idusuario,Publ_Empresa_Razon_Social,Publ_Empresa_Cuit)

insert into class.rolUsuario values ('1','1','1')
insert into class.rolUsuario values ('2','1','2')
insert into class.rolUsuario values ('3','1','3')
--Inserto los clientes en class.rolUsuario con el único rol que tienen al principio(Rol empresa='3')
insert into class.rolUsuario (orden,idusuario,idrol)(select '1',usuario.idusuario,'2' from gd_esquema.Maestra join class.usuario on ltrim(rtrim(Publ_Cli_Dni))=usuario 
where not(Publ_Cli_Dni is null) group by usuario.idusuario union 
select '1',usuario.idusuario,'2' from gd_esquema.Maestra join class.usuario on ltrim(rtrim(Cli_Dni))=usuario where not(Cli_Dni is null) group by usuario.idusuario)

--Inserto las empresas en class.rolUsuario con el único rol que tienen al principio(Rol empresa='3')
insert into class.rolUsuario (orden,idusuario,idrol)(select '1',
usuario.idusuario,'3' from gd_esquema.Maestra join class.usuario on replace(Publ_Empresa_Cuit,'-','')=usuario where not(Publ_Empresa_Cuit is null) 
group by usuario.idusuario )

insert into Class.TipoPublicacion (Descripcion) (select distinct(publicacion_tipo) from gd_esquema.Maestra)

--Por defecto, la descripción larga es igual a la descripción corta
insert into class.Rubro (Desc_corta,Desc_larga)(select Publicacion_Rubro_Descripcion,Publicacion_Rubro_Descripcion from gd_esquema.Maestra group by Publicacion_Rubro_Descripcion)

--Cargo la tabla de visibilidad, por defecto, ninguna tendrá costo de envío ni lo tendrá habilitado
insert into class.visibilidad (Descripcion,grado,Porcentaje,Costo,TieneEnvio,CostoEnvio)
(select Publicacion_Visibilidad_Desc,row_number() OVER(ORDER BY Publicacion_Visibilidad_Precio DESC),Publicacion_Visibilidad_Porcentaje,Publicacion_Visibilidad_Precio,0,0 from gd_esquema.Maestra group by publicacion_visibilidad_cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Precio,Publicacion_Visibilidad_Porcentaje)

--Cargo tabla de estados
insert into class.Estado (Descripcion) values ('Borrador')
insert into class.Estado (Descripcion) values ('Activa')
insert into class.Estado (Descripcion) values ('Pausada')
insert into class.Estado (Descripcion) values ('Finalizada')

--Cargo la tabla de publicaciones, por defecto todas las publicaciones estarán activas. La aplicacion se encargará de actualizar el estado al que corresponda con el primer loguin
insert into class.Publicacion (Descripcion,Stock,FechaInicio,FechaVencimiento,precio,IdRubro,IdVisibilidad,idusuario,IdEstado,IdTipo,Envio,IdAnterior) 
(select Publicacion_Descripcion,Publicacion_Stock,publicacion_fecha,Publicacion_Fecha_Venc,Publicacion_Precio,IdRubro,IdVisibilidad,case when persona.idusuario is null then empresa.idusuario else persona.idusuario end,'2',IdTipo,0,publicacion_cod
from gd_esquema.Maestra join class.Rubro on Publicacion_Rubro_Descripcion=Rubro.Desc_corta join class.Visibilidad on Publicacion_Visibilidad_Desc=Visibilidad.Descripcion 
join class.TipoPublicacion on Maestra.Publicacion_Tipo=TipoPublicacion.Descripcion
left join class.Persona on Publ_Cli_Dni=Persona.Dni left join class.Empresa on replace(Publ_Empresa_Cuit,'-','')=empresa.Cuit
group by publicacion_cod,Publicacion_Descripcion,Publicacion_Stock,publicacion_fecha,Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Visibilidad_Desc,IdRubro,IdVisibilidad,IdTipo,
persona.IdUsuario,empresa.IdUsuario 
) order by publicacion_cod

--Cargo tabla de subastas, tendrá todas las ofertas por cada publicación, incluso la oferta ganadora
insert into class.subasta (IdPublicacion,IdUsuario,Monto,FechayHora)
(select publicacion.IdPublicacion,persona.IdUsuario,Oferta_Monto,Oferta_Fecha from gd_esquema.Maestra join class.Publicacion on maestra.Publicacion_Cod=Publicacion.IdAnterior 
join class.persona on cli_dni=persona.dni where Publicacion_Tipo='subasta' and not (Oferta_Fecha is null)) order by Publicacion_cod,Oferta_Monto

--Cargo la tabla de facturas
insert into class.factura (IdPublicacion,Numero,Total,Fecha,FormaPago)
(select publicacion.IdPublicacion,Factura_Nro,Factura_Total,Factura_Fecha,Forma_Pago_Desc
from gd_esquema.Maestra join  class.Publicacion on maestra.Publicacion_Cod=Publicacion.IdAnterior  where not(factura_nro is null) 
group by publicacion.IdPublicacion,Publicacion_Cod,Factura_Nro,Factura_Total,Factura_Fecha,Forma_Pago_Desc) order by Maestra.Publicacion_cod 

--Cargo los tipos de item de las facturas
insert into class.TipoItem (Descripcion) values('Costo de publicacion')
insert into class.TipoItem (Descripcion) values('Costo de venta')
insert into class.TipoItem (Descripcion) values('Costo de envio')

--Cargo la tabla de detale de las facturas. Si el monto el igual al costo de la visibilidad de la publicación, pongo como tipo de item "costo de publicación", caso contrario "costo de venta"
--No tengo en cuenta a las publicaciones gratuitas ya que estas no generan facturación
insert into class.Detalle (IdFactura,IdItem,Cantidad,Monto)
(select IdFactura,case when item_factura_monto=publicacion_visibilidad_precio and Item_Factura_Cantidad=1 then '1' else '2' end,Item_Factura_Cantidad,item_factura_monto 
from gd_esquema.Maestra join class.factura on Factura_Nro=factura.Numero where not(factura_nro is null) and Publicacion_Visibilidad_Cod<>'10006')
order by publicacion_cod

--Me falta meter el detalle de la factura para las publicaciones gratuitas

--Cargo tabla de compras
insert into class.compra (IdPublicacion,IdUsuario,Fecha,Cantidad,monto)
(select Publicacion.IdPublicacion,persona.IdUsuario,Compra_Fecha,Compra_Cantidad,Compra_Cantidad*publicacion_precio monto
from gd_esquema.maestra join class.Publicacion on Publicacion_Cod=publicacion.idanterior 
join class.Persona on Cli_Dni=persona.Dni
where publicacion_tipo='Compra Inmediata' and not(Compra_Cantidad is null) and calificacion_codigo is null)
order by publicacion_cod,Compra_Fecha

insert into class.compra (IdPublicacion,IdUsuario,Fecha,Cantidad,monto)
(select Publicacion.IdPublicacion,persona.IdUsuario,Compra_Fecha,Compra_Cantidad,
(select top 1 Oferta_Monto from gd_esquema.maestra m2 where m2.Publicacion_Cod=m1.Publicacion_Cod 
and m2.Cli_Dni=m1.Cli_Dni and m2.Compra_Cantidad is null and m2.Calificacion_Codigo is null order by oferta_monto desc)
from gd_esquema.maestra m1 join class.Publicacion on Publicacion_Cod=publicacion.idanterior
join class.Persona on Cli_Dni=persona.Dni 
where publicacion_tipo='subasta' and not(m1.Compra_Cantidad is null) and Calificacion_Cant_Estrellas is null) 
order by Publicacion_Cod,Compra_Fecha

insert into class.Calificacion (IdPublicacion,IdUsuarioPub,IdUsuarioCom,IdCompra,Calificacion)
(select Publicacion.IdPublicacion,case when empresa.IdUsuario is null then p2.IdUsuario else empresa.IdUsuario end idusuariopub,p1.IdUsuario,compra.IdCompra,
floor(case when (Calificacion_Cant_Estrellas % 2) =1 then (Calificacion_Cant_Estrellas+1)/2 else Calificacion_Cant_Estrellas/2 end)
from gd_esquema.Maestra m1 join class.Persona p1 on Cli_Dni=p1.Dni
join class.Publicacion on Publicacion_Cod=publicacion.idanterior
join class.Compra on p1.IdUsuario=compra.IdUsuario and compra.IdPublicacion=Publicacion.IdPublicacion 
left join class.empresa on replace(m1.Publ_Empresa_Cuit,'-','')=empresa.Cuit
left join class.Persona p2 on Publ_Cli_Dni=p2.Dni
where not(m1.Calificacion_Codigo is null)
group by Publicacion.IdPublicacion,case when empresa.IdUsuario is null then p2.IdUsuario else empresa.IdUsuario end,p1.IdUsuario,compra.IdCompra,publicacion.idanterior,Calificacion_Cant_Estrellas)
order by Publicacion.IdPublicacion

GO
COMMIT TRAN

GO

CREATE PROCEDURE Class.VerificarPublicacionesGratis(@id_Usuario int)
AS
	BEGIN
		DECLARE @parametro_retorno int;

		BEGIN
			SELECT @parametro_retorno = PublicacionesGratuitas
			FROM Class.Usuario 
			WHERE idUsuario = @id_Usuario
		END
		return @parametro_retorno;
	END
GO

CREATE PROCEDURE Class.CrearPublicacion(@rubro varchar(max),@id_User int,@tipoPubl varchar(max),@tipoVisib varchar(max),@estado varchar(max),
											@descripcion varchar(max),@fecha_Vencim datetime, @fecha_Inicio datetime,
											@stock numeric(18,0),  @monto numeric(18,2),@permiteEnvio varchar(1),@fechaSistema datetime,@publicaciones_gratis tinyint)
AS 
	BEGIN
		declare @envio bit;
		if (@permiteEnvio ='N')
			set @envio=0
		ELSE
			set @envio=1
		BEGIN TRY
			begin tran
			insert into class.Publicacion(Descripcion,Stock,FechaInicio,FechaVencimiento,Precio,IdRubro,IdVisibilidad,IdUsuario,IdEstado,IdTipo,Envio)
			values(@descripcion,@stock,@fecha_Inicio,@fecha_Vencim,@monto,@rubro,@tipoVisib,@id_User,@estado,@tipoPubl,@envio)
			if @estado=2 --Si la publicación tiene estado activa, emite la factura por el costo de publicacion, caso contrario, se emitirá cuando se active
			begin
				declare @costo numeric(18,2)
				if (@publicaciones_gratis >0)
					begin
						--Descuento 1 a la cantidad ed publicaciones gratis y seteo el costo de publicacion en 0 para que emita la factura en 0
						update class.Usuario set PublicacionesGratuitas=PublicacionesGratuitas-@publicaciones_gratis where IdUsuario=@id_User
						set @costo=0
					end 
				else
					begin
						--Busco el costo de publicación seleccionada
						select @costo=Costo from class.Visibilidad where IdVisibilidad=@tipoVisib
					end
				DECLARE @id_publi int 
				select  top 1 @id_publi=IdPublicacion from class.Publicacion order by IdPublicacion desc
				DECLARE @ultima_factura numeric(18,0)
				declare @ult_idfactura int
				select  top 1 @ultima_factura=Numero from class.Factura order by Numero desc
				insert into class.factura (IdPublicacion,Numero,Total,Fecha,FormaPago)
				values(@id_publi,@ultima_factura+1,@costo,@fechaSistema,'Efectivo')
				select  top 1 @ult_idfactura=idfactura from class.Factura order by idfactura desc
				insert into class.detalle (idfactura,IdItem,Cantidad,Monto) values(@ult_idfactura,1,1,@costo)
			end
			commit tran

		END TRY
		BEGIN CATCH
			rollback tran
		END CATCH;
	end
GO


CREATE PROCEDURE Class.ModificarPublicacion(@idpublicación int,@rubro varchar(max),@estado varchar(max),@descripcion varchar(max),@stock numeric(18,0),  @monto numeric(18,2),@fechaSistema datetime,@publicaciones_gratis tinyint)
AS 
	BEGIN
		BEGIN TRY
			begin tran
			update class.Publicacion set Descripcion=@descripcion,idrubro=@rubro,IdEstado=@estado,Stock=@stock,Precio=@monto where IdPublicacion=@idpublicación
			--Si la publicación tiene estado activa, emite la factura si es que no se emitió todavia
			if not(exists(select 1 from class.Factura join class.Detalle on factura.IdFactura=Detalle.IdFactura where detalle.IdItem=1 and IdPublicacion=@idpublicación)) and @estado='2'
				begin
					declare @id_user int
					declare @tipoVisib int
					select @id_user=IdUsuario,@tipoVisib=IdVisibilidad from class.Publicacion where IdPublicacion=@idpublicación
					declare @costo numeric(18,2)
					if (@publicaciones_gratis >0)
						begin
							--Descuento 1 a la cantidad ed publicaciones gratis y seteo el costo de publicacion en 0 para que emita la factura en 0
							update class.Usuario set PublicacionesGratuitas=PublicacionesGratuitas-@publicaciones_gratis where IdUsuario=@id_User
							set @costo=0
						end 
					else
						begin
							--Busco el costo de publicación seleccionada
							select @costo=Costo from class.Visibilidad where IdVisibilidad=@tipoVisib
						end
					--Emito factura con detalle
					DECLARE @ultima_factura numeric(18,0)
					declare @ult_idfactura int
					select  top 1 @ultima_factura=Numero from class.Factura order by Numero desc
					insert into class.factura (IdPublicacion,Numero,Total,Fecha,FormaPago)
					values(@idpublicación,@ultima_factura+1,@costo,@fechaSistema,'Efectivo')
					select  top 1 @ult_idfactura=idfactura from class.Factura order by idfactura desc
					insert into class.detalle (idfactura,IdItem,Cantidad,Monto) values(@ult_idfactura,1,1,@costo)
				end
			commit tran
		END TRY
		BEGIN CATCH
			rollback tran
		END CATCH;
	end
GO


CREATE PROCEDURE Class.NuevaOferta(@idpublicación int,@idusuario int,@monto int,@fechaSistema datetime)
AS 
	BEGIN
		BEGIN TRY
			begin tran
			insert into class.subasta values(@idpublicación,@idusuario,@monto,@fechaSistema)
			commit tran
		END TRY
		BEGIN CATCH
			rollback tran
		END CATCH;
	end
GO

CREATE PROCEDURE Class.Insertar_Compra(@idpublicación int,@idusuario int,@monto int,@cantidad int,@fechaSistema datetime)
AS 
	BEGIN
		BEGIN TRY
			begin tran
			declare @stock int
			declare @tipoVisib int
			declare @porcentaje numeric(18,2)
			declare @idfactura int
			declare @tieneenvio bit
			declare @costoenvio numeric(18,2)
			declare @montototal numeric(18,2)
			select @stock=stock,@tipoVisib=IdVisibilidad,@tieneenvio=Envio from class.Publicacion where IdPublicacion=@idpublicación
			select @porcentaje=Porcentaje,@costoenvio=CostoEnvio from class.Visibilidad where IdVisibilidad=@tipoVisib
			set @stock=@stock-@cantidad 
			if @stock=0 --Si no queda mas en stock, finalizo la publicacion
				update class.Publicacion set stock=0,IdEstado=4 where IdPublicacion=@idpublicación
			else
				update class.Publicacion set stock=@stock where IdPublicacion=@idpublicación
			insert into class.compra (IdPublicacion,IdUsuario,Fecha,Cantidad,Monto) values(@idpublicación,@idusuario,@fechaSistema,@cantidad,@monto*@cantidad)
			if @tieneenvio=1
				set @montototal=@monto*@cantidad*@porcentaje+@costoenvio
			else
				set @montototal=@monto*@cantidad*@porcentaje
			--Actualizo el total de la factura con el monto del producto*la cantidad comprada* el porcentaje de comision
			update class.factura set total=total+@montototal where IdPublicacion=@idpublicación
			select @idfactura=idfactura from class.Factura where IdPublicacion=@idpublicación
			insert into class.detalle values(@idfactura,2,@cantidad,@monto*@cantidad*@porcentaje)
			--Falta agregar costo de envio a la factura
			if @tieneenvio=1
				insert into class.detalle values(@idfactura,3,1,@costoenvio)
			commit tran
		END TRY
		BEGIN CATCH
			rollback tran
		END CATCH;
	end
GO

create trigger class.emitir_factura_subasta on class.publicacion after update
as
	declare @idpublicacion int
	declare @idvisibilidad int 
	declare @estado int
	declare @tieneenvio bit
	declare @porcentaje numeric(18,2)
	declare @montototal numeric(18,2)
	declare @monto numeric(18,2)
	declare @costoenvio numeric(18,2)
	declare @idfactura int

	declare @fecha datetime
	declare @usuario_comprador int
	begin try
	begin tran
		DECLARE Cursor_publicaciones CURSOR FOR select IdPublicacion,IdVisibilidad,IdEstado,Envio from inserted where IdAnterior=0 and idtipo=2
		OPEN Cursor_publicaciones
		FETCH NEXT FROM Cursor_publicaciones into @idpublicacion,@idvisibilidad,@estado,@tieneenvio
		WHILE @@FETCH_STATUS = 0  
			BEGIN  
				if @estado=4  and (exists(select top 1 monto from class.Subasta where IdPublicacion=@idpublicacion))
				--Genero las facturas si es que alguien oferto por esa publicacion
				--Además, ingreso registro de compra para la maxima oferta de la subasta
				begin
					select @porcentaje=Porcentaje,@costoenvio=CostoEnvio from class.Visibilidad where IdVisibilidad=@idvisibilidad
					select top 1 @monto=monto,@fecha=FechayHora,@usuario_comprador=IdUsuario from class.Subasta where IdPublicacion=@idpublicacion order by monto desc
					if @tieneenvio=1
						set @montototal=@monto*@porcentaje+@costoenvio
					else
						set @montototal=@monto*@porcentaje
					--Actualizo el total de la factura con el monto del producto*la cantidad comprada* el porcentaje de comision
					update class.factura set total=total+@montototal where IdPublicacion=@idpublicacion
					select @idfactura=idfactura from class.Factura where IdPublicacion=@idpublicacion
					insert into class.detalle values(@idfactura,2,1,@monto*@porcentaje)
					--agrego costo de envio a la factura si tiene envio
					if @tieneenvio=1
						insert into class.detalle values(@idfactura,3,1,@costoenvio)
					insert into class.Compra (IdPublicacion,IdUsuario,Fecha,Cantidad,Monto) values(@idpublicacion,@usuario_comprador,@fecha,1,@monto)
				END
				FETCH NEXT FROM Cursor_publicaciones into @idpublicacion,@idvisibilidad,@estado,@tieneenvio
			END
		CLOSE Cursor_publicaciones
		DEALLOCATE Cursor_publicaciones
	commit tran
	END TRY
	BEGIN CATCH
		rollback tran
	END CATCH;
GO

--Creo vista con las calificaciones de los usuarios
CREATE VIEW class.Calificaciones 
AS  
select idusuariopub idusuario,sum(calificacion)/count(*) calificacion from class.Calificacion group by idusuariopub
GO

--Ingresar nueva calificacion
CREATE PROCEDURE Class.Nueva_Calificacion(@idpublicación int,@idusuarioPub int,@idusuarioCom int,@idcompra int,@calificacion int,@detalle varchar(255),@fechaSistema datetime)
AS 
	BEGIN
		BEGIN TRY
			begin tran
			insert into class.Calificacion values(@idpublicación,@idusuarioPub,@idusuarioCom ,@idcompra,@calificacion,@detalle,@fechaSistema)
			commit tran
		END TRY
		BEGIN CATCH
			rollback tran
		END CATCH;
	end
GO