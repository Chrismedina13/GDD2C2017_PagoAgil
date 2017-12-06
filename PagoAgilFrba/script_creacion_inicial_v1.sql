--Me conecto a la base de datos a usar
USE [GD2C2017]
GO
----------------------------------------------------------------------------------------------
								/** CREACION DE SCHEMA **/
----------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'pero_compila')
BEGIN
    EXEC ('CREATE SCHEMA pero_compila AUTHORIZATION gd')
END
GO


----------------------------------------------------------------------------------------------
								/** FIN CREACION DE SCHEMA**/
----------------------------------------------------------------------------------------------



----------------------------------------------------------------------------------------------
								/** VALIDACION DE TABLAS **/
----------------------------------------------------------------------------------------------
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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Item'))
    DROP TABLE pero_compila.Item

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Devolucion'))
    DROP TABLE pero_compila.Devolucion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.DevolucionesXFactura'))
    DROP TABLE pero_compila.DevolucionesXFactura


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Usuario'))
    DROP TABLE pero_compila.ItemPago


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Rendicion_Facturas'))
    DROP TABLE pero_compila.ItemRendicion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Usuario'))
    DROP TABLE pero_compila.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.PagoFactura'))
    DROP TABLE pero_compila.PagoFactura


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Factura'))
    DROP TABLE pero_compila.Factura

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Empresa'))
    DROP TABLE pero_compila.Empresa

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'pero_compila.Rubro'))
    DROP TABLE pero_compila.Rubro

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


----------------------------------------------------------------------------------------------
							/** FIN VALIDACION DE TABLAS **/
----------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------
							/** VALIDACION DE PROCEDURES **/
----------------------------------------------------------------------------------------------


IF EXISTS (SELECT name FROM sysobjects WHERE name='registrarUsuario' AND type='p')
	DROP PROCEDURE [pero_compila].registrarUsuario
GO	
IF EXISTS (SELECT name FROM sysobjects WHERE name='login' AND type='p')
	DROP PROCEDURE [pero_compila].login
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name='[pero_compila].[sp_alta_solo_rol]')
	DROP PROCEDURE [pero_compila].[sp_alta_solo_rol]
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='pero_compila.sp_get_roles')
	DROP PROCEDURE pero_compila.sp_get_roles
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='pero_compila.sp_update_rol')
	DROP PROCEDURE pero_compila.sp_update_rol
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='pero_compila.sp_alta_rol')
	DROP PROCEDURE pero_compila.sp_alta_rol
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_clientes')
	DROP PROCEDURE pero_compila.sp_get_clientes
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_empresas')
	DROP PROCEDURE pero_compila.sp_get_empresas
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_items')
	DROP PROCEDURE pero_compila.sp_get_items
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_facturas')
	DROP PROCEDURE pero_compila.sp_get_facturas
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_usuarioXSucursal')
	DROP PROCEDURE pero_compila.sp_alta_usuarioXSucursal
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_funcionalidades')
	DROP PROCEDURE pero_compila.sp_alta_funcionalidades
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_item')
	DROP PROCEDURE pero_compila.sp_alta_item
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_factura')
	DROP PROCEDURE pero_compila.sp_alta_factura
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_pasar_a_pagada')
	DROP PROCEDURE pero_compila.sp_pasar_a_pagada
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='filtrarFacturas')
	DROP PROCEDURE pero_compila.filtrarFacturas
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_eliminar_factura')
	DROP PROCEDURE pero_compila.sp_eliminar_factura
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_update_factura')
	DROP PROCEDURE pero_compila.sp_update_factura
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_Pago_Factura')
	DROP PROCEDURE pero_compila.sp_alta_Pago_Factura
GO
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_cheque')
	DROP PROCEDURE pero_compila.sp_alta_cheque
GO	
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_tarjCredito')
	DROP PROCEDURE pero_compila.sp_alta_tarjCredito
GO	
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_tarjDebito')
	DROP PROCEDURE pero_compila.sp_alta_tarjDebito
GO
	
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_efectivo')
	DROP PROCEDURE pero_compila.sp_alta_efectivo
GO	
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_rendicion')
	DROP PROCEDURE pero_compila.sp_alta_rendicion
GO

----------------------------------------------------------------------------------------------
							/** FIN VALIDACION DE PROCEDURES **/
----------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------
								/** CREACION TABLAS **/
----------------------------------------------------------------------------------------------

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
sucursal_CP int unique,
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
medioPago_nroCheque int,
medioPago_nroTarjCredito int,
medioPago_nroTarjDebito int,
medioPago_fechaVtoTarjeta datetime,
medioPago_codVerificacionTarjeta int,
medioPago_dniTitular numeric(18,0),
medioPago_monto numeric(18,2),
medioPago_entidadAPagar nvarchar(255)
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

--El importe es lo que recibe el "RAPIPAGO"
--El Total es lo que recibe la Empresa.....
create table [pero_compila].Rendicion_Facturas (
rendicion_facturas_Id int primary key identity,
rendicion_facturas_fecha datetime ,
rendicion_facturas_cantidad int ,
rendicion_facturas_facturas nvarchar(255),
rendicion_facturas_empresa nvarchar(255),
rendicion_facturas_porcentaje numeric(18,2),
rendicion_facturas_total numeric(18,2),
rendicion_facturas_nro numeric(18,0),
rendicion_facturas_importeRecaudado numeric	(18,2)

)


create table [pero_compila].ItemRendicion(
itemRendicion_Id int primary key identity,
itemRendicion_nro numeric(18,0) ,
itemRendicion_importe numeric(18,2),
itemRendicion_rendicionFactura int not null references [pero_compila].Rendicion_Facturas,
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
factura_enviadoAPago bit default 0,
factura_estado bit default 1
FOREIGN KEY (factura_cliente_dni, factura_cliente_mail) REFERENCES pero_compila.Cliente
)


create table [pero_compila].PagoFactura (
pagoFactura_Id int primary key identity,
pagoFactura_factura int not null references [pero_compila].Factura,
pagoFactura_sucursal int not null references [pero_compila].Sucursal,
pagoFactura_cliente_dni numeric(18,0) not null,
pagoFactura_cliente_mail nvarchar(255) not null,
pagoFactura_medioPago int not null references [pero_compila].MedioPago,
pagoFactura_fecha_cobro datetime not null,
pagoFactura_importe decimal(18,2) not null default 0,
pagoFactura_estado bit default 1,
pagoFactura_nro numeric(18,2),
FOREIGN KEY (pagoFactura_cliente_dni, pagoFactura_cliente_mail) REFERENCES pero_compila.Cliente(cliente_dni,cliente_email)
)


create table [pero_compila].ItemPago(
itemPago_Id int primary key identity,
itemPago_nro int ,
itemPago_pagoFactura int not null references [pero_compila].PagoFactura,
)

create table [pero_compila].FacturasXPago (
facturasXPago_Id int primary key identity,
facturasXPago_pago int not null references [pero_compila].PagoFactura,
facturasXPago_factura int not null references [pero_compila].Factura
)

create table [pero_compila].ItemXFactura(
itemXFactura_Id int primary key identity,
itemXFactura_item int not null references [pero_compila].Item,
itemXFactura_factura int not null references [pero_compila].Factura,
itemXFactura_cantidad int
)

create table [pero_compila].Devolucion(
devolucion_Id int primary key identity,
devolucion_usuario int not null references [pero_compila].Usuario,
devolucion_cliente_dni numeric(18,0),
devolucion_cliente_email nvarchar(255),
devolucion_motivo nvarchar(250) not null,
devolucion_fecha datetime not null,
FOREIGN KEY (devolucion_cliente_dni, devolucion_cliente_email) REFERENCES pero_compila.Cliente(cliente_dni,cliente_email),
)

create table [pero_compila].DevolucionesXFactura(

devolucionesXFactura_Id int primary key identity,
devolucionesXFactura_devolucion int not null references [pero_compila].Devolucion,
devolucionesXFactura_factura int not null references [pero_compila].Factura,
)

/** *********************FIN CREACION TABLAS ***********************/

		

-------------------------------------------------------------------------------------------
								/*STORED PROCEDURES*/
-------------------------------------------------------------------------------------------

	



			/**********************REGISTRAR USUARIO*********************/




GO
--falta que se agreguen las sucursales
create PROCEDURE [pero_compila].[registrarUsuario](@user varchar(100),@pass varchar(100),@rol int)
AS
BEGIN

	if(@user IN (SELECT usuario_username from pero_compila.Usuario))
			THROW 51000, 'Elija otro nombre de Usuario', 1;
	else
		INSERT INTO pero_compila.Usuario (usuario_username,usuario_password,usuario_intentos) 
				VALUES (@user,HASHBYTES('SHA2_256', @pass),0)
		INSERT INTO pero_compila.RolXUsuario(rolXUsuario_rol,rolXUsuario_usuario)
				VALUES(@rol,@@IDENTITY)
		Select Max(usuario_ID) from [pero_compila].[Usuario]	
END




								/*FIN REGISTRAR USUARIO*/


/**********************LOGIN********************* */
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

   
/**********************FIN LOGIN **********************/



/**********************ABM ROL**********************/

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
*********************Obtiene todos los roles que se encuentran habilitados*********************
*/
go
create procedure pero_compila.sp_get_roles

as
begin
	select * from pero_compila.Rol where rol_estado=1
end
/*
*********************Realiza el update de los roles de acuerdo a un identificador(id)*********************
*/

go
create procedure pero_compila.sp_update_rol
 (@id numeric(10,0), @nombre varchar(255), @habilitado bit)	
as
begin

update pero_compila.Rol
set rol_nombre = @nombre, rol_estado = @habilitado
where rol_ID = @id

end

/*
********************* alta los roles de acuerdo a un identificador(id)*********************
*/

GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [pero_compila].[sp_alta_rol] (@nombre varchar(255), @habilitado  bit,@funcionalidad varchar(255))
as
begin
	insert into pero_compila.Rol (rol_nombre, rol_estado)
	values(@nombre, @habilitado)
	insert into pero_compila.Funcionalidad (funcionalidad_descripcion)
	values (@funcionalidad)
end

/*
*********************Obtiene todos los clientes que se encuentran habilitados*********************
*/
GO
create procedure [pero_compila].[sp_get_clientes]

as
begin
	select * from pero_compila.Cliente where cliente_estado=1
end
/*
*********************Obtiene todas las empresas que se encuentran habilitados*********************
*/
GO

create procedure [pero_compila].[sp_get_empresas]

as
begin
	select * from pero_compila.Empresa where empresa_estado=1
end
/*
*********************Obtiene todos los items *********************
*/

GO
create procedure [pero_compila].[sp_get_items]

as
begin
	select distinct item_Id,item_descripcion,item_precio from pero_compila.Item
end

/*
*********************Obtiene todas las facturas*********************
*/

GO
create procedure [pero_compila].sp_get_facturas
as
begin
	select * from pero_compila.Factura where factura_enviadoAPago=0 and factura_estado=1
end


/*
*********************Alta del usuario con sucursales*********************
*/

go
create procedure pero_compila.sp_alta_usuarioXSucursal
(@idUsuario int, @idSucursal  int)
as
begin
	insert into pero_compila.UsuarioXSucursal
	(usuarioXSucursal_usuario, usuarioXSucursal_sucursal)
	values(@idUsuario, @idSucursal)
	--select @@IDENTITY
end
go
/*
*********************Realiza el alta de una funcionalidad*********************
*/

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

/*
*********************Realiza el alta de un item*********************
*/

create procedure [pero_compila].[sp_alta_item] (@descripcion nvarchar(255), @precio numeric(18,2),@cantidad int,@idFactura int)
as
begin
	insert into pero_compila.Item (item_descripcion, item_precio)
	values(@descripcion, @precio)
	insert into pero_compila.ItemXFactura(itemXFactura_item,itemXFactura_cantidad,itemXFactura_factura)
	values(@@IDENTITY,@cantidad,@idFactura)
end


/*
*************************ALTA DE FACTURA *******************************
*/

GO
create procedure [pero_compila].[sp_alta_factura] 
(@cliente_dni numeric(18,0),@cliente_mail nvarchar(255),
@empresaId int,
@cod_factura nvarchar(255),
@fecha_alta datetime,@fecha_vencimiento datetime,
@total decimal(18,2))
as
begin
	insert into pero_compila.Factura ([factura_cliente_dni],[factura_cliente_mail],[factura_empresa],[factura_cod_factura],
	[factura_fecha_alta],[factura_fecha_vencimiento],[factura_total])
	values(@cliente_dni,@cliente_mail,@empresaId,@cod_factura,
	@fecha_alta,@fecha_vencimiento,@total)
end
/*
*********************PASA UNA FACTURA A ESTADO PAGA*********************
*/

go
create procedure [PERO_COMPILA].sp_pasar_a_pagada(@cliente_dni numeric(18,0),
@cliente_mail nvarchar(255),@cod_factura nvarchar(255))
AS 
BEGIN
UPDATE pero_compila.Factura
              SET factura_enviadoAPago =1
              WHERE factura_cliente_dni = @cliente_dni and factura_cliente_mail =@cliente_mail
					and factura_cod_factura=@cod_factura

END

 /*
*********************FILTRA UNA FACTURA POR UNO O TODOS LOS CAMPOS*********************
*/

GO
create PROCEDURE [pero_compila].[filtrarFacturas]
	(@fechaAlta datetime,
	@fechaVencimiento datetime,
	@nroFactura int,
	@cliDni numeric(18,0),
	@empresaId int
	)
AS
BEGIN
	select * from pero_compila.Factura where factura_estado=1 and
											factura_enviadoAPago=0 and(
											 @fechaAlta is null or (factura_fecha_alta =@fechaAlta) or
											 @fechaVencimiento is null or (factura_fecha_vencimiento =@fechaVencimiento) or
											 @nroFactura is null or (factura_cod_factura =@nroFactura) or
											 @cliDni is null or (factura_cliente_dni =@cliDni) or
											 @empresaId is null or (factura_empresa =@empresaId))
END

 /*
********************ELIMINA FACTURA(PASA A ESTADO 0)*********************
*/

GO
CREATE PROCEDURE [pero_compila].[sp_eliminar_factura]
	(@codFactura int,
	@cli_dni numeric(18,0),
	@facturaID int
	)
AS
BEGIN
	update pero_compila.Factura Set factura_estado=0 where factura_cod_factura=@codFactura and factura_cliente_dni=@cli_dni and factura_Id=@facturaID
END

 /*
********************UPDATE DE FACTURA*********************
*/

GO
CREATE PROCEDURE [pero_compila].[sp_update_factura]
	(@facturaId int,
	@total numeric(18,2),
	@codFactura int,
	@cli_dni numeric(18,0),
	@empresaId int,
	@fechaAlta datetime,
	@fechaVto datetime
	)
AS
BEGIN
	update pero_compila.Factura set 
					factura_fecha_alta = @fechaAlta,
					factura_fecha_vencimiento =@fechaVto,
					factura_total=@total,
					factura_cod_factura=@codFactura,
					factura_cliente_dni=@cli_dni,
					factura_empresa=@empresaId
	
	where factura_id =@facturaId and ( factura_estado=1 and (
		 @fechaAlta is null or (factura_fecha_alta =@fechaAlta) or
		 @fechaVto is null or (factura_fecha_vencimiento =@fechaVto) or
		 @codFactura is null or (factura_cod_factura =@codFactura) or
		 @cli_dni is null or (factura_cliente_dni =@cli_dni) or
		 @empresaId is null or (factura_empresa =@empresaId)))
END



 /*
*********************DA DE ALTA EN UN PAGO_FACTURA*********************
*/

go
create procedure [PERO_COMPILA].sp_alta_Pago_Factura(@facturaId int,
        @sucursalId int,
        @cliente_dni int,
        @cliente_mail nvarchar(255),
        @medioPagoId int,
        @fechaCobro datetime,
        @importe numeric(18,2))
AS 
BEGIN
insert into pero_compila.PagoFactura(pagoFactura_factura,pagoFactura_sucursal,pagoFactura_cliente_dni,pagoFactura_cliente_mail,pagoFactura_medioPago,pagoFactura_fecha_cobro,pagoFactura_importe,pagoFactura_estado)
values (@facturaId ,@sucursalId ,
        @cliente_dni ,
        @cliente_mail ,
        @medioPagoId ,
        @fechaCobro ,
        @importe ,1)


END

/*
*********************dar de alta en un cheque*********************
*/

go
create procedure [PERO_COMPILA].sp_alta_cheque(@nroCheque INT, @dniTitular NUMERIC(18,0),
@destino NVARCHAR(255),@monto NUMERIC(18,2))
AS 
BEGIN
INSERT INTO pero_compila.MedioPago(medioPago_nroCheque,medioPago_dniTitular,medioPago_entidadAPagar,medioPago_monto,medioPago_descripcion)
values(@nroCheque , @dniTitular ,
@destino ,@monto,'Cheque' )
end


/*
*********************dar de alta en una tarj de credito *********************
*/

GO
create procedure [pero_compila].[sp_alta_tarjCredito](@nroTarjCredit int,@fechaVtoTarjeta datetime,@codVerificacionTarjeta int, @dniTitular numeric(18,0),@monto numeric(18,2) )
as
begin
insert into pero_compila.MedioPago(medioPago_nroTarjCredito,medioPago_fechaVtoTarjeta,medioPago_codVerificacionTarjeta,medioPago_dniTitular,medioPago_monto,medioPago_descripcion)
values(@nroTarjCredit,@fechaVtoTarjeta ,@codVerificacionTarjeta, @dniTitular ,@monto,'Tarjeta de Crédito' )
end

/*
********************** dar de alta en efectivo*********************
*/	
GO
create procedure [pero_compila].[sp_alta_efectivo](@dniTitular NUMERIC(18,0),@monto NUMERIC(18,2))
AS 
BEGIN
INSERT INTO pero_compila.MedioPago(medioPago_dniTitular,medioPago_monto,medioPago_descripcion)
values( @dniTitular ,@monto,'Efectivo' )
end

/*
********************** dar de alta en una tarj de debito*********************
*/

GO
create procedure [pero_compila].[sp_alta_tarjDebito](@nroTarjDebito int,@fechaVtoTarjeta datetime,@codVerificacionTarjeta int, @dniTitular numeric(18,0),@monto numeric(18,2) )
as
begin
insert into pero_compila.MedioPago(medioPago_nroTarjDebito,medioPago_fechaVtoTarjeta,medioPago_codVerificacionTarjeta,medioPago_dniTitular,medioPago_monto,medioPago_descripcion)
values(@nroTarjDebito,@fechaVtoTarjeta ,@codVerificacionTarjeta, @dniTitular ,@monto,'Tarjeta de Débito' )
end

/*
********************** dar de alta una rendicion en una fecha*********************
*/
go
create procedure [PERO_COMPILA].sp_alta_rendicion(@rendicion_fecha datetime,
             @cantidad int,
             @empresa nvarchar(255),
             @porcentaje numeric(18,2),
             @total numeric(18,2),
			 @importeRecaudado numeric(18,2))
AS
BEGIN
insert into pero_compila.Rendicion_Facturas(
rendicion_facturas_fecha,
rendicion_facturas_cantidad,
rendicion_facturas_empresa,
rendicion_facturas_porcentaje,
rendicion_facturas_total,
rendicion_facturas_importeRecaudado)
values (@rendicion_fecha,@cantidad,@empresa,
             @porcentaje,@total,@importeRecaudado)

END




-----------------------------------------------------------------------------------------------------
									/*FIN DE STORED PROCEDURES*/
-----------------------------------------------------------------------------------------------------






-----------------------------------------------------------------------------------------------------
										/* CARGA DE DATOS */
-----------------------------------------------------------------------------------------------------

--Existen dos tipos de roles Administradores y Cobradores
					/*Rol*/
go
insert into [pero_compila].Rol (rol_nombre) values
('Administrativo'), 
('Cobrador');

					/*Funcionalidad*/
go
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

go
insert into [pero_compila].FuncionalidadXRol (funcionalidadXRol_rol, funcionalidadXRol_funcionalidad) values
(1,1), (1,2), (1,3), (1,4),(1,5),(1,6),(1,7),(2,7),(2,8),(1,10),(2,9),(2,10);

					/*Usuarios*/


/*Usuario pedido*/
go
insert into pero_compila.Usuario (usuario_username, usuario_password) values
('admin',HASHBYTES('SHA2_256','w23e'))

/*usuarios creados por el grupo*/ 
go
insert into pero_compila.Usuario (usuario_username, usuario_password) values 
	('cobrador',HASHBYTES('SHA2_256','cobrador'))
insert into pero_compila.Usuario (usuario_username,usuario_password) values
	('admingral',HASHBYTES('SHA2_256','admingral'))


					/*Localidad*/
go
insert into pero_compila.Localidad (localidad_nombre,localidad_provincia,localidad_pais)
values ('Capital Federal','Buenos Aires','Argentina')


					/*UsuariosXRoles*/
/*usuariosXRoles*/
insert into pero_compila.RolXUsuario (rolXUsuario_usuario, rolXUsuario_rol) values
	(1,1),(2,2),(3,1),(3,2);


                    /*Sucursal*/
go       
insert into pero_compila.Sucursal(sucursal_CP,sucursal_direccion,sucursal_nombre,sucursal_localidad)
select distinct Sucursal_Codigo_Postal,Sucursal_Dirección,Sucursal_Nombre,localidad_Id
from gd_esquema.Maestra m, pero_compila.Localidad l
where Sucursal_Dirección not like 'null'

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

					/*Cliente*/
INSERT INTO [pero_compila].[Cliente]([cliente_nombre],[cliente_apellido],
[cliente_dni],[cliente_email]
,[cliente_direccion],[cliente_CP],[cliente_localidad]
,[cliente_fecha_nacimiento],[cliente_estado])
select distinct m.[Cliente-Nombre],m.[Cliente-Apellido],m.[Cliente-Dni],
m.[Cliente_Mail],m.[Cliente_Direccion],m.[Cliente_Codigo_Postal],l.localidad_id,m.[Cliente-Fecha_Nac],1
from gd_esquema.Maestra m , pero_compila.Localidad l
GO

					/*Factura*/
go
insert into pero_compila.Factura(factura_cliente_dni,factura_cliente_mail,factura_empresa, factura_cod_factura,factura_fecha_alta, factura_fecha_vencimiento,factura_total)
select distinct m.[Cliente-Dni],m.[Cliente_Mail], empresa_Id, m.Nro_Factura, m.Factura_Fecha, m.Factura_Fecha_Vencimiento, m.Factura_Total
from gd_esquema.Maestra m,pero_compila.Cliente c, pero_compila.Empresa e
order by factura_fecha_vencimiento 

						/*Item X Factura*/

insert into pero_compila.ItemXFactura(itemXFactura_factura,itemXFactura_cantidad,itemXFactura_item)
SELECT DISTINCT f.factura_Id,m.ItemFactura_Cantidad,i.item_Id
FROM pero_compila.Factura f
JOIN GD2C2017.gd_esquema.Maestra m
		ON f.factura_cod_factura = m.Nro_Factura
JOIN pero_compila.Item i ON (i.item_precio=m.ItemFactura_Monto)
WHERE f.factura_Id IS NOT NULL



					/*Rendicion_Facturas*/
GO
SET IDENTITY_INSERT pero_compila.Rendicion_Facturas ON
GO

INSERT INTO pero_compila.Rendicion_Facturas(rendicion_facturas_Id ,
rendicion_facturas_fecha,
rendicion_facturas_empresa,rendicion_facturas_porcentaje,
rendicion_facturas_total,rendicion_facturas_nro )
SELECT DISTINCT m.Rendicion_Nro,
				m.Rendicion_Fecha,
				e.empresa_id,
				ROUND((m.ItemRendicion_Importe/m.Factura_Total*100), 2),
				m.ItemRendicion_Importe,
				m.Rendicion_Nro
FROM GD2C2017.gd_esquema.Maestra m, pero_compila.Empresa e
WHERE m.Rendicion_Nro IS NOT NULL
SET IDENTITY_INSERT pero_compila.Rendicion_Facturas OFF
GO



				/*Medio de Pago*/
insert into pero_compila.MedioPago (medioPago_descripcion)
select distinct FormaPagoDescripcion from gd_esquema.Maestra where FormaPagoDescripcion not like 'null'


				/*Pago_Factura*/
insert into pero_compila.PagoFactura (pagoFactura_factura,pagoFactura_sucursal,pagoFactura_cliente_dni,
pagoFactura_cliente_mail,pagoFactura_medioPago,pagoFactura_fecha_cobro,pagoFactura_importe,pagoFactura_estado,
pagoFactura_nro)
SELECT DISTINCT	f.factura_Id,s.Sucursal_Id, m.[Cliente-Dni],m.Cliente_Mail,fp.medioPago_Id,m.Pago_Fecha, m.Total,1,m.Nro_Factura
FROM GD2C2017.gd_esquema.Maestra m 
JOIN pero_compila.Factura f 
		ON m.Nro_Factura = f.factura_cod_factura
JOIN pero_compila.Sucursal s 
		ON s.sucursal_CP = m.Sucursal_Codigo_Postal
JOIN pero_compila.MedioPago fp 
		ON m.FormaPagoDescripcion = fp.medioPago_descripcion
WHERE Pago_nro IS NOT NULL


-----------------------------------------------------------------------------------------------------
										/*FIN CARGA DE DATOS */
-----------------------------------------------------------------------------------------------------