Create Table Usuarios (
IdUsuario int  identity(1,1) primary key,
 Nombre varchar(50),
 Clave varchar(10),
 Email varchar(50),
 esActivo bit);

 Create Table Rutas (
 IdRuta int identity(1,1) primary key,
 Descripcion varchar (100)
 );

 Create table RutaDetalle (
 Id int identity(1,1) primary key,
 IdRuta int,
 IdCliente int,
 OrdenVisita varchar);

 Create table Ventas (
 IdVenta int identity(1,1) primary key,
 Fecha DateTime,
 IdCliente int,
 Monto float);

 Create table VentasDetalle(
 Id int identity(1,1) primary key,
 IdVenta int,
 IdProducto int,
 Cantidad int,
 Precio float,
 IdOferta int,
 );

 Create table Clientes (
 IdCliente int identity(1,1) primary key,
 Nombre varchar(50),
 Apellido varchar(50),
 Direccion varchar (100),
 Email varchar (50),
 Telefono varchar(12),
 Celular varchar(12),
 FechaIngreso DateTime,
 );

 Create table Productos (
 IdProducto int identity(1,1) primary key,
 Descripcion varchar (100),
 Precio float,
 Existencia float,
 );

 Create table Ofertas (
 IdOferta int identity(1,1) primary key,
 IdProducto int,
 PrecioOferta float,
 );

 Create table Configuraciones (
 Id int identity(1,1) primary key,
 Config varchar,
 Valor int(10),
 );


