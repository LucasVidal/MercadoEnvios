USE [GD1C2016]
GO
IF NOT EXISTS ( SELECT  * FROM sys.schemas WHERE name = 'Class' ) 
    EXEC('CREATE SCHEMA [DB] AUTHORIZATION [dbo]');
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
		IdRol			int NOT NULL,
		LoginFallidos	int NOT NULL DEFAULT 0,
		TipoDocumento	nvarchar(4) NOT NULL,
		Mail			nvarchar(255) NOT NULL,
		Telefono		nvarchar(20),
		Ciudad			nvarchar(100),
		Calle			nvarchar(200) not null,
		Numero			numeric(9) not null,
		Piso			numeric(9),
		Depto			nvarchar(100),
		Localidad		nvarchar(100),
		CodigoPostal	nvarchar(100) not null,
		FechaCreacion	date NOT NULL,
		PublicacionesGratuitas int not null,
		CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Class.Rol (IdRol)
);


CREATE TABLE Class.Persona
(
		IdUsuario		int not null,
		Nombre			nvarchar(255) NOT NULL,
		Apellido		nvarchar(255) NOT NULL,
		Dni				numeric(18,0) NOT NULL,
		FechaNac		date NOT NULL,
		CONSTRAINT FK_Persona_Usuario FOREIGN KEY (IdUsuario) REFERENCES Class.Usuario (IdUsuario)
);

CREATE TABLE Class.Empresa
(
		IdUsuario		int not null,
		RazonSocial		nvarchar(255) NOT NULL,
		Cuit			numeric(18,0) NOT NULL,
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
		CONSTRAINT FK_Detalle_Publicacion FOREIGN KEY (IdFactura) REFERENCES Class.Factura (IdFactura),
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

insert into class.RolFuncionalidad values (2,1,1)
insert into class.RolFuncionalidad values (2,2,1)
insert into class.RolFuncionalidad values (2,3,1)
insert into class.RolFuncionalidad values (2,4,1)
insert into class.RolFuncionalidad values (2,5,1)
insert into class.RolFuncionalidad values (2,6,1)
insert into class.RolFuncionalidad values (2,7,1)
insert into class.RolFuncionalidad values (2,8,1)
insert into class.RolFuncionalidad values (2,9,1)

insert into class.RolFuncionalidad values (3,1,1)
insert into class.RolFuncionalidad values (3,2,1)
insert into class.RolFuncionalidad values (3,3,1)
insert into class.RolFuncionalidad values (3,4,1)
insert into class.RolFuncionalidad values (3,5,1)
insert into class.RolFuncionalidad values (3,6,1)
insert into class.RolFuncionalidad values (3,7,1)
insert into class.RolFuncionalidad values (3,8,1)
insert into class.RolFuncionalidad values (3,9,1)

insert into class.Usuario (usuario,clave,EstaHabilitado,idrol,LoginFallidos,TipoDocumento,mail,calle,numero,CodigoPostal,FechaCreacion,PublicacionesGratuitas) values
('admin',convert(varbinary,Class.psencriptar('w23e')),'1','1','0','','','',0,'',getdate(),0)

insert into class.Usuario (usuario,clave,EstaHabilitado,idrol,LoginFallidos,TipoDocumento,mail,calle,numero,piso,Depto,CodigoPostal,FechaCreacion)
(select Publ_Cli_Dni usuario,convert(varbinary,Class.psencriptar(CONVERT(nvarchar(4000), Publ_Cli_Dni))),1,2,0,'DNI',Publ_Cli_Mail mail,Publ_Cli_Dom_Calle calle,Publ_Cli_Nro_Calle nro,Publ_Cli_Piso piso,Publ_Cli_Depto depto,
Publ_Cli_Cod_Postal postal,getdate() from gd_esquema.Maestra where not(Publ_Cli_Dni is null)  
group by Publ_Cli_Dni,Publ_Cli_Mail,Publ_Cli_Dom_Calle,Publ_Cli_Nro_Calle,Publ_Cli_Piso,Publ_Cli_Depto,Publ_Cli_Cod_Postal union
select Cli_Dni usuario,convert(varbinary,Class.psencriptar(CONVERT(nvarchar(4000), Cli_Dni))),1,2,0,'DNI',Cli_Mail mail ,Cli_Dom_Calle calle ,Cli_Nro_Calle nro,Cli_Piso,Cli_Depto depto,
Cli_Cod_Postal postal,getdate() from gd_esquema.Maestra where not(Cli_Dni is null)  
group by Cli_Dni,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal)


insert into class.persona (IdUsuario,Nombre,Apellido,Dni,FechaNac)
(select usuario.idusuario,Publ_Cli_Nombre nombre,Publ_Cli_Apeliido apellido,Publ_Cli_Dni dni,Publ_Cli_Fecha_Nac fec_nac
from gd_esquema.Maestra join class.usuario on ltrim(rtrim(Publ_Cli_Dni))=usuario where not(Publ_Cli_Dni is null)  
group by usuario.idusuario,Publ_Cli_Nombre,Publ_Cli_Apeliido,Publ_Cli_Dni,Publ_Cli_Fecha_Nac
union
select usuario.idusuario,Cli_Nombre nombre,Cli_Apeliido apellido,Cli_Dni dni,Cli_Fecha_Nac fec_nac
from gd_esquema.Maestra join class.usuario on ltrim(rtrim(Cli_Dni))=usuario where not(Cli_Dni is null)  
group by usuario.idusuario,Cli_Nombre,Cli_Apeliido,Cli_Dni,Cli_Fecha_Nac)

insert into class.Usuario (usuario,clave,EstaHabilitado,idrol,LoginFallidos,TipoDocumento,mail,calle,numero,piso,Depto,CodigoPostal,FechaCreacion)
(select replace(Publ_Empresa_Cuit,'-','') usuario,convert(varbinary,Class.psencriptar(CONVERT(nvarchar(4000), replace(Publ_Empresa_Cuit,'-',''))))
,1,2,0,'CUIT',Publ_Empresa_Mail mail,Publ_Empresa_Dom_Calle calle,Publ_Empresa_Nro_Calle nro,Publ_Empresa_Piso piso,Publ_Empresa_Depto depto,
Publ_Empresa_Cod_Postal postal,getdate() from gd_esquema.Maestra where not(Publ_Empresa_Cuit is null)  
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

--Carga de las calificaciones, hay que arreglarlo porque no se pueden cargar las calificaciones,
--ya que no funciona para las publicaciones en que un mismo cliente compro mas de 1 vez	
select * from class.Calificacion
insert into class.Calificacion (IdPublicacion,IdUsuarioPub,IdUsuarioCom,IdCompra,Calificacion)
(select Publicacion.IdPublicacion,case when empresa.IdUsuario is null then p2.IdUsuario else empresa.IdUsuario end idusuariopub,p1.IdUsuario,compra.IdCompra,'0'
 from gd_esquema.Maestra m1 join class.Persona p1 on Cli_Dni=p1.Dni
join class.Publicacion on Publicacion_Cod=publicacion.idanterior
join class.Compra on p1.IdUsuario=compra.IdUsuario and compra.IdPublicacion=Publicacion.IdPublicacion 
left join class.empresa on replace(m1.Publ_Empresa_Cuit,'-','')=empresa.Cuit
left join class.Persona p2 on Publ_Cli_Dni=p2.Dni
where not(m1.Calificacion_Codigo is null)
group by Publicacion.IdPublicacion,case when empresa.IdUsuario is null then p2.IdUsuario else empresa.IdUsuario end,p1.IdUsuario,compra.IdCompra,publicacion.idanterior)
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
											@stock numeric(18,0), @descripcion varchar(max), @monto numeric(18,2),
											@fecha_Vencim datetime, @fecha_Inicio datetime, @preguntas varchar(max),@permiteEnvio bit,@publicaciones_gratis tinyint)
AS 
	BEGIN
		begin tran
		insert into class.Publicacion(Descripcion,Stock,FechaInicio,FechaVencimiento,Precio,IdRubro,IdVisibilidad,IdUsuario,IdEstado,IdTipo,Envio)
		values(@descripcion,@stock,@fecha_Inicio,@fecha_Vencim,@monto,@rubro,@tipoVisib,@id_User,@estado,@tipoPubl,@permiteEnvio)
		if (@publicaciones_gratis >0)
		   update class.Usuario set PublicacionesGratuitas=PublicacionesGratuitas-@publicaciones_gratis where IdUsuario=@id_User
		else
		   begin
		      DECLARE @id_publi int 
			  select  top 1 @id_publi=IdPublicacion from class.Publicacion order by IdPublicacion desc
			  DECLARE @ultima_factura numeric(18,0)
			  declare @ult_idfactura int
			  select  top 1 @id_publi=Numero,@ult_idfactura=idfactura from class.Factura order by idfactura desc
			  insert into class.factura (IdPublicacion,Numero,Total,Fecha,FormaPago)
			  values(@id_publi+1,@ultima_factura+1,@monto,getdate(),'Efectivo')
			  insert into class.detalle (idfactura,IdItem,Cantidad,Monto) values(@ult_idfactura,1,1,@monto)
		   end
		commit tran
	end
GO
