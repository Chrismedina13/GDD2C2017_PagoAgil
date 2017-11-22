--Me conecto a la base de datos a usar
USE [GD2C2017]
GO

/** CREACION DE SCHEMA **/

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'pero_compila')
BEGIN
    EXEC ('CREATE SCHEMA pero_compila AUTHORIZATION gd')
END
GO

/** FIN CREACION DE SCHEMA**/


/** VALIDACION DE TABLAS **/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.FuncionalidadXRol'))
    DROP TABLE pero_compila.FuncionalidadXRol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.RolXUsuario'))
    DROP TABLE pero_compila.RolXUsuario
        
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Funcionalidad'))
    DROP TABLE pero_compila.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Rol'))
    DROP TABLE pero_compila.Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.UsuarioXSucursal'))
    DROP TABLE pero_compila.UsuarioXSucursal


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.FacturasXPago'))
    DROP TABLE pero_compila.FacturasXPago

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.ItemXFactura'))
    DROP TABLE pero_compila.ItemXFactura

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Usuario'))
    DROP TABLE pero_compila.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Factura'))
    DROP TABLE pero_compila.Factura


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Item'))
    DROP TABLE pero_compila.Item

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Empresa'))
    DROP TABLE pero_compila.Empresa


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Rubro'))
    DROP TABLE pero_compila.Rubro

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.PagoFactura'))
    DROP TABLE pero_compila.PagoFactura

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.MedioPago'))
    DROP TABLE pero_compila.MedioPago


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Sucursal'))
    DROP TABLE pero_compila.Sucursal

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Cliente'))
    DROP TABLE pero_compila.Cliente



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Localidad'))
    DROP TABLE pero_compila.Localidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Rendicion_Facturas'))
    DROP TABLE pero_compila.Rendicion_Facturas

/**IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Devolucion'))
    DROP TABLE pero_compila.Devolucion
**/


/** FIN VALIDACION DE TABLAS **/

/** CREACION TABLAS **/

create table [pero_compila].Funcionalidad(
funcionalidad_Id int primary key identity,
funcionalidad_descripcion nvarchar(255) not null,
)


create table [pero_compila].Rol(
rol_Id int primary key identity,
rol_nombre nvarchar(255) not null,
rol_estado bit default 1
)


create table [pero_compila].FuncionalidadXRol(
funcionalidadXRol_Id int primary key identity,
funcionalidadXRol_rol int not null references [pero_compila].Rol,
funcionalidadXRol_funcionalidad int not null references [pero_compila].Funcionalidad ,
)

create table [pero_compila].Usuario(
usuario_Id int primary key identity,
usuario_username varchar(255) unique not null,
usuario_password varchar(255) not null,
usuario_intentos int default 0,
)

create table [pero_compila].RolXUsuario(
rolXUsuario_Id int primary key identity,
rolXUsuario_usuario int not null references [pero_compila].Usuario,
rolXUsuario_rol int not null references [pero_compila].Rol,
)

create table [pero_compila].Localidad(
localidad_Id int primary key identity,
localidad_nombre nvarchar(255),
localidad_provincia nvarchar(255),
localidad_pais nvarchar(255)
)

create table [pero_compila].Sucursal(
sucursal_Id int primary key identity,
sucursal_direccion nvarchar(255),
sucursal_nombre nvarchar(255),
sucursal_localidad int not null references [pero_compila].Localidad,
sucursal_CP int,
sucursal_estado bit default 1 
)

create table [pero_compila].UsuarioXSucursal(
usuarioXSucursal_Id int primary key identity,
usuarioXSucursal_sucursal int not null references [pero_compila].Sucursal,
usuarioXSucursal_usuario int not null references [pero_compila].Usuario
)


create table [pero_compila].MedioPago (
medioPago_Id int primary key identity,
medioPago_descripcion nvarchar(250) not null,
)


create table [pero_compila].Rubro (
rubro_Id int primary key identity,
rubro_descripcion nvarchar(250) not null,
)


create table [pero_compila].Item (
item_Id int primary key identity,
item_descripcion nvarchar(250),
item_precio numeric(18,2)
)

create table [pero_compila].Rendicion_Facturas (
rendicion_facturas_fecha_Id int primary key identity,
rendicion_facturas_cantidad int ,
rendicion_facturas_facturas nvarchar(255),
rendicion_facturas_importe numeric(18,2),
rendicion_facturas_empresa nvarchar(255),
rendicion_facturas_porcentaje int,
rendicion_facturas_total int


)

create table [pero_compila].Cliente (
cliente_nombre nvarchar(255),
cliente_apellido nvarchar(255),
cliente_dni  numeric(18,0) ,
cliente_email nvarchar(255),
cliente_telefono nvarchar(255),
cliente_direccion nvarchar(255),
cliente_CP nvarchar(255),
cliente_localidad int not null references [pero_compila].Localidad,
cliente_fecha_nacimiento datetime,
cliente_estado bit default 1
PRIMARY KEY (cliente_dni,cliente_email)
)


create table [pero_compila].Empresa (
empresa_Id int primary key identity,
empresa_nombre nvarchar(255),
empresa_cuit nvarchar(50) unique,
empresa_direccion  nvarchar(255) not null,
empresa_rubro int not null references [pero_compila].Rubro,
empresa_estado bit default 1
)


create table [pero_compila].Factura (
factura_Id int primary key identity,
factura_empresa int not null references [pero_compila].Empresa,
factura_cod_factura nvarchar(255),
factura_cliente_dni numeric(18,0),
factura_cliente_mail nvarchar(255),
factura_fecha_alta datetime not null,
factura_fecha_vencimiento datetime not null,
factura_total decimal(18,2) not null default 0,
FOREIGN KEY (factura_cliente_dni, factura_cliente_mail) REFERENCES pero_compila.Cliente(cliente_dni,cliente_email)
)


create table [pero_compila].PagoFactura (
pagoFactura_Id int primary key identity,
pagoFactura_factura int not null references [pero_compila].Factura,
pagoFactura_sucursal int not null references [pero_compila].Sucursal,
pagoFactura_cliente int not null references [pero_compila].Cliente,
pagoFactura_medioPago int not null references [pero_compila].MedioPago,
pagoFactura_fecha_cobro datetime not null,
pagoFactura_importe decimal(18,2) not null default 0,
pagoFactura_estado bit default 1
)


create table [pero_compila].FacturasXPago (
facturasXPago_Id int primary key identity,
facturasXPago_pago int not null references [pero_compila].PagoFactura,
facturasXPago_factura int not null references [pero_compila].Factura
)

create table [pero_compila].ItemXFactura(
itemXFactura_Id int primary key identity,
itemXFactura_item int not null references [pero_compila].Item,
itemXFactura_factura int not null references [pero_compila].Factura
)

/** FIN CREACION TABLAS **/

		


	
/*STORED PROCEDURES*/


										/*REGISTRAR USUARIO*/
--**********
--NOMBRE	: registrarUsuario [STORED PROCEDURE]
--OBJETIVO  : dar de alta a un usuario (habilitados o no)                         
--**********


IF EXISTS (SELECT name FROM sysobjects WHERE name='registrarUsuario' AND type='p')
	DROP PROCEDURE [pero_compila].registrarUsuario
GO	

GO
CREATE PROCEDURE [pero_compila].registrarUsuario(@user varchar(100),@pass varchar(100))
AS
BEGIN
	if(@user IN (SELECT usuario_username from pero_compila.Usuario))
			THROW 51000, 'Elija otro nombre de Usuario', 1;
	else
		INSERT INTO pero_compila.Usuario (usuario_username,usuario_password,usuario_intentos) 
				VALUES (@user,HASHBYTES('SHA2_256', @pass),0)
END

/*FIN REGISTRAR USUARIO*/
/*LOGIN */
--**********
--NOMBRE	: login [STORED PROCEDURE]
--OBJETIVO  : iniciar sesion              
--**********

IF EXISTS (SELECT name FROM sysobjects WHERE name='login' AND type='p')
	DROP PROCEDURE [pero_compila].login
GO
go	
CREATE PROCEDURE [pero_compila].[login](@user VARCHAR(100), @pass varchar(100), @ret smallint output)
AS 
BEGIN

  IF EXISTS( SELECT 1 FROM pero_compila.Usuario   WHERE usuario_username = @user )
  
     BEGIN

	    IF ( SELECT usuario_password FROM pero_compila.Usuario WHERE usuario_username = @user) = HASHBYTES('SHA2_256', @pass)
		    BEGIN
			  UPDATE pero_compila.Usuario
              SET usuario_intentos = 0
              WHERE usuario_username = @user
				set @ret = 0 -- user + psw correctos
			END
           
		  ELSE
		   BEGIN 

            UPDATE pero_compila.Usuario
            SET usuario_intentos =usuario_intentos + 1
            WHERE usuario_username = @user
    
    
	       UPDATE pero_compila.Usuario
           --SET ACTIVO = 0
			set usuario_intentos = 3
           WHERE usuario_username = @user
          -- AND usuario_intentos = 3
		   
		   SET @ret = -2 -- fallo en los intentos de login
		   
		   END
      END

   ELSE
		SET @ret= -1 -- no esta activo y usuario incorrecto
END

   
/*FIN LOGIN */

/*ABM ROL*/
--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_rol						------------TODO falta pasarle la lista de funcionalidades---------------
--OBJETIVO  : dar de alta un rol                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='[pero_compila].[sp_alta_solo_rol]')
	DROP PROCEDURE [pero_compila].[sp_alta_solo_rol]
GO
go
create procedure [pero_compila].[sp_alta_solo_rol] 
(@nombre varchar(255), @habilitado  bit)
as
begin
	declare @id int
	insert into pero_compila.Rol (rol_nombre, rol_estado)
	values(@nombre, @habilitado)
	
	Select Max(rol_Id) from [pero_compila].[Rol]
	--select @id = scope_identity()[pero_compila].[Rol]
end

/*
Obtiene todos los roles que se encuentran habilitados
*/
IF EXISTS (SELECT name FROM sysobjects WHERE name='pero_compila.sp_get_roles')
	DROP PROCEDURE pero_compila.sp_get_roles
GO
go
create procedure pero_compila.sp_get_roles

as
begin
	select * from pero_compila.Rol where rol_estado=1
end
GO
/*
Realiza el update de los roles de acuerdo a un identificador(id)
*/
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_update_rol')
	DROP PROCEDURE pero_compila.sp_update_rol
GO											
go
create procedure pero_compila.sp_update_rol
 (@id numeric(10,0), @nombre varchar(255), @habilitado bit)	
as
begin

update pero_compila.Rol
set rol_nombre = @nombre, rol_estado = @habilitado
where rol_ID = @id

end
GO
/*
Realiza el alta de una funcionalidad
*/
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_funcionalidades')
	DROP PROCEDURE pero_compila.sp_alta_funcionalidades
GO											
go
create procedure pero_compila.sp_alta_funcionalidades
(@idRol int, @idFuncionalidad  int)
as
begin
	insert into pero_compila.FuncionalidadXRol
	(funcionalidadXRol_rol, funcionalidadXRol_funcionalidad)
	values(@idRol, @idFuncionalidad)
	--select @@IDENTITY
end
go
--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_rol						------------TODO falta pasarle la lista de funcionalidades---------------
--OBJETIVO  : dar de alta un rol                                 
--=============================================================================================================

/*FIN DE STORED PROCEDURES*/

/* CARGA DE DATOS */



					/*Rol*/
insert into [pero_compila].Rol (rol_nombre) values
('Administrativo'), 
('Cobrador');

					/*Funcionalidad*/
insert into pero_compila.Funcionalidad (funcionalidad_descripcion) values
('ABM de Rol'),
('Registro de usuarios'),
('ABM de Clientes'),
('ABM de Empresas'),
('ABM de Sucursales'),
('ABM de Facturas'),
('Registro de pago de facturas'),
('Rendicion de facturas cobradas'),
('Devoluciones'),
('Listado estadistico');

					/*RolXFuncionalidad*/
insert into [pero_compila].FuncionalidadXRol (funcionalidadXRol_rol, funcionalidadXRol_funcionalidad) values
(1,1), (1,2), (1,3), (1,4),(1,5),(1,6),(1,7),(2,7),(2,8),(1,10),(2,9),(2,10);

					/*Usuarios*/
/*Usuario pedido*/
insert into pero_compila.Usuario (usuario_username, usuario_password) values
('admin',HASHBYTES('SHA2_256','w23e'))

			/*Localidad*/

/*insert into pero_compila.Localidad (localidad_nombre,localidad_provincia,localidad_pais)
values ('Capital Federal','Buenos Aires','Argentina')*/



					/*Clientes*/
insert into pero_compila.Cliente (cliente_nombre, cliente_apellido,cliente_dni,cliente_email,cliente_direccion,cliente_CP,cliente_localidad,cliente_fecha_nacimiento)
select distinct m.[Cliente-Nombre], m.[Cliente-Apellido],m.[Cliente-Dni],m.Cliente_Mail,m.Cliente_Direccion,m.Cliente_Codigo_postal,l.localidad_Id, m.[Cliente-Fecha_Nac]
from gd_esquema.Maestra m, pero_compila.Localidad l 
--order by cast( m.[Cliente-Dni] as varchar(255))


/*usuarios*/ 
insert into pero_compila.Usuario (usuario_username, usuario_password) values 
	('cobrador',HASHBYTES('SHA2_256','cobrador'))
insert into pero_compila.Usuario (usuario_username,usuario_password) values
	('admingral',HASHBYTES('SHA2_256','admingral'))



					/*UsuariosXRoles*/
/*usuariosXRoles*/
insert into pero_compila.RolXUsuario (rolXUsuario_usuario, rolXUsuario_rol) values
	(1,1),(2,2),(3,1),(3,2);

		



	
                    /*Sucursal*/
insert into pero_compila.Sucursal(sucursal_CP,sucursal_direccion,sucursal_nombre,sucursal_localidad)
select distinct Sucursal_Codigo_Postal,Sucursal_Dirección,Sucursal_Nombre,localidad_Id
from gd_esquema.Maestra m, pero_compila.Localidad l



				/*UsuarioXSucursal*/
insert into pero_compila.UsuarioXSucursal (usuarioXSucursal_sucursal, usuarioXSucursal_usuario)
select distinct  s.sucursal_Id,u.usuario_ID
from pero_compila.Sucursal s , pero_compila.Usuario u

				/*Rubro*/
insert into pero_compila.Rubro (rubro_descripcion)
select distinct Rubro_Descripcion
from gd_esquema.Maestra
	

				/*Empresa*/
insert into pero_compila.Empresa (empresa_nombre,empresa_cuit,empresa_direccion,empresa_rubro)
select distinct Empresa_Nombre,Empresa_Cuit,Empresa_Direccion,rubro_Id
from gd_esquema.Maestra m , pero_compila.Rubro r

					
					
					/*Item*/
insert into pero_compila.Item( item_precio)
select distinct ItemFactura_Monto
from gd_esquema.Maestra m
/*falta la descripcion*/

					/*Factura*/
insert into pero_compila.Factura(factura_cliente_dni,factura_cliente_mail,factura_empresa, factura_cod_factura,factura_fecha_alta, factura_fecha_vencimiento,factura_total)
select distinct m.[Cliente-Dni],m.[Cliente_Mail], empresa_Id, m.Nro_Factura, m.Factura_Fecha, m.Factura_Fecha_Vencimiento, m.Factura_Total
from gd_esquema.Maestra m,pero_compila.Cliente c, pero_compila.Empresa e
order by factura_fecha_vencimiento 



					/*Rendicion_Facturas*/
/* 
insert into [pero_compila].Rendicion_Facturas  ( rendicion_facturas_fecha_Id,rendicion_facturas_cantidad,rendicion_facturas_facturas, rendicion_facturas_importe, rendicion_facturas_empresa, rendicion_facturas_porcentaje,rendicion_facturas_total)



					/*Cliente*/
INSERT INTO [pero_compila].[Cliente]([cliente_nombre],[cliente_apellido],
[cliente_dni],[cliente_email]
,[cliente_direccion],[cliente_CP],[cliente_localidad]
,[cliente_fecha_nacimiento],[cliente_estado])
select distinct m.[Cliente-Nombre],m.[Cliente-Apellido],m.[Cliente-Dni],
m.[Cliente_Mail],m.[Cliente_Direccion],m.[Cliente_Codigo_Postal],l.localidad_id,m.[Cliente-Fecha_Nac],1
from gd_esquema.Maestra m , pero_compila.Localidad l
GO



--INSERT INTO WARRIORS.Usuarios (usuario_username,usuario_password,usuario_intentosFallidos)
--			VALUES ('admin','w23e',0)
