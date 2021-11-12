/*Crear base de datos empresa 1*/
create database EnsamblajeComputadoras
go

use EnsamblajeComputadoras
go

/*Entidades de la empresa 1*/
create table Clientes1
(
	IdCliente varchar(9) primary key,
	Nombre varchar(20),
	Apellido varchar(20),
	Correo varchar(20),
	Ciudad varchar(20),
	Pais varchar(20),
	ComprasRealizadas int,
	Estado varchar(10),
	CodigoCliente varchar(15),
	RedSocial varchar(15),
	Edad int,
	FechaCompra date
);
set dateformat dmy;
go

create table Inventario 
(
	IdProducto varchar (9),
	Categoria varchar (10),
	Cantidad int,
	NombreProducto varchar (10),
)
go

create table Categorias 
(
	NombreCategoria varchar (9),
	Descripcion varchar (10)
)
go

create table Proveedores
(
	NombreProveedor varchar (9),
	Identificacion varchar (10),
	Direccion int,
	Telefono varchar (10),
	Correo varchar (20)
)
go

create table Tarifas
(
	NombreCategoria varchar (9),
	Precio float,
	NombreProducto varchar (10),
	IdProducto varchar (9)
)
go

create table Factura
(
	IdCliente varchar(9) primary key,
	IdFactura varchar(9),
	NumeroFactura varchar(9),
	Fecha datetime,
	IVA varchar(9)
)
go

insert into Clientes1 values ('123456789','Juan Pablo','Pérez Hernandez','jperez@sitic.com.co','Medellín','Colombia',3,'Inactivo','2T4RR4','Instagram',34,'15/02/2019');


create database ConstruccionRed1
go

use ConstruccionRed1
go

create table Clientes2
(
	IdCliente varchar(9) primary key,
	Nombre varchar(20),
	Apellido varchar(20),
	Correo varchar(20),
	Ciudad varchar(20),
	FechaNacimiento datetime,
	ComprasRealizadas int,
	Estado varchar(10),
	Empresa varchar(15),
	FechaCompra date
);
set dateformat dmy;
go

create table InventarioMateriales
(
	IdProducto varchar (9),
	Descripcion varchar (100),
	Cantidad int,
	NombreProducto varchar (10),
	Precio float
)
go

create table ProveedoresDeServicios
(
	NombreProveedor varchar (9),
	Identificacion varchar (10),
	Direccion int,
	Telefono varchar (10),
	Correo varchar (20),
	Servicio varchar (20),
	DescripServicio varchar (100)
)
go

create table Tarifas
(
	NombreOperacion varchar (9),
	Precio float,
	DescripOperacion varchar (100)
)
go

create table Factura
(
	IdCliente varchar(9) primary key,
	IdFactura varchar(9),
	NumeroFactura varchar(9),
	Fecha datetime,
	IVA varchar(9)
)
set dateformat dmy;
go

insert into Clientes2 values ('987654321','Miguel Ángel','Botina Zuluaga','mabotinaz@ms.net','Bogotá, Colombia','09/04/1984',2,'Activo','mITingServices','08/01/2020');
