drop database if exists AAStore 
go
create database AAStore
go
use AAStore
go
create table Roles
(
	RoleId INT Primary Key Identity(1,1),
	RoleName nvarchar(10) not null
)
go

create table Users
(
	UserId INT Primary Key Identity(1,1),
	UserName VARCHAR(50),
	UserDOB DATE,
	UserEmail nvarchar(50),
	UserContactNo nvarchar(10),
	UserPassword nvarchar(50),
	RoleId int foreign key references Roles(RoleId)
)
go 

create table Category
(
CategoryId	int Primary Key Identity(1,1),
CategoryName	nvarchar(100)
)
go

create table Company
(
CompanyId	int Primary Key Identity(1,1),
CompanyName	nvarchar(50),
CategoryId	int foreign key references Category(CategoryId)
)
go

create table Products
(
ProductId	int Primary Key Identity(1,1),
ProductName	nvarchar(100),
Price	int,
PImage	nvarchar(100),
CategoryId	int foreign key references Category(CategoryId),
CompanyId	int foreign key references Company(CompanyId)
)
go

create table AddressMaster 
(
AddressId	int Primary Key Identity(1,1),
Address_Details	nvarchar(max),
City	nvarchar(100),
State	nvarchar(100),
PinCode	int,
UserId	int foreign key references Users(UserId),
)
go

Create table OrderMaster
(
OrderId	int Primary Key Identity(1,1),
ProductId int foreign key references Products(ProductId),
UserId	int foreign key references Users(UserId),
AddressId int foreign key references AddressMaster(AddressId)
)
go

create table ManuBar
(
MenuId int Primary Key Identity(1,1),
MenuName nvarchar(50)
)


