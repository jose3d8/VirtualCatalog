Create Table Usuarios (
IdUsuario int  identity(1,1) primary key,
 Nombre varchar(50) NOT NULL,
 Clave varchar(10) NOT NULL,
 ConfirmarClave varchar(10) NOT NULL,
 Email varchar(50) NOT NULL,
 esActivo bit);
 go
 Create Table Rutas (
 IdRuta int identity(1,1) primary key,
 Descripcion varchar (100) NOT NULL
 );
 go
 Create table RutaDetalle (
 Id int identity(1,1) primary key,
 IdRuta int NOT NULL,
 IdCliente int NOT NULL,
 OrdenVisita varchar NOT NULL);
 go
 Create table Ventas (
 IdVenta int identity(1,1) primary key,
 Fecha DateTime NOT NULL,
 IdCliente int NOT NULL,
 Monto float NOT NULL);
 go
 Create table VentasDetalle(
 Id int identity(1,1) primary key,
 IdVenta int NOT NULL,
 IdProducto int NOT NULL,
 Cantidad int NOT NULL,
 Precio float NOT NULL,
 IdOferta int NOT NULL,
 );
 go
 Create table Clientes (
 IdCliente int identity(1,1) primary key,
 Nombre varchar(50) NOT NULL,
 Apellido varchar(50) NOT NULL,
 Direccion varchar (100) NOT NULL,
 Email varchar (100),
 Telefono varchar(12) NOT NULL,
 Celular varchar(12) NOT NULL,
 FechaIngreso DateTime NOT NULL,
 );
 go
 Create table Productos (
 IdProducto int identity(1,1) primary key,
 Descripcion varchar (100) NOT NULL,
 Precio float NOT NULL,
 Existencia int NOT NULL,
 );
 go
 Create table Ofertas (
 IdOferta int identity(1,1) primary key,
 IdProducto int NOT NULL,
 PrecioOferta float NOT NULL,
 );
 go
 Create table Configuraciones (
 Id int identity (1,1) Primary key,
 Config varchar,
 Valor int NOT NULL,
 );