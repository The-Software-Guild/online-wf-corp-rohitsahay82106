use master;
Go

if exists (select * from sysdatabases where name='GuildCars')
		drop database GuildCars
go

create Database GuildCars;
GO
