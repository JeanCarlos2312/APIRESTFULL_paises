create database BD_PAIS
go

use BD_PAIS
go

create table Pais(
Id int identity(1,1),
Descripcion varchar(50),
Capital varchar(20),
primary key(Id)
)
go

insert into Pais values('Argentina','Buenos Aires')
insert into Pais values('Perú','Lima')
insert into Pais values('Colombia','Bogota')
insert into Pais values('Ecuador','Quito')
insert into Pais values('España','Madrid')
insert into Pais values('Chile','Santiago de Chile')
insert into Pais values('Francia','Paris')
go