create database PDB;

create table Login
(
uid int identity(1,1) primary key,
u_name varchar(30),
pwd varchar(20),
)

insert into Login values('Geojith','12345')

select * from Login

create table Pat_registration
(
p_id int identity(1,1) primary key,
f_name varchar(50),
l_name varchar(50),
age int,
gender varchar(20),
address varchar(100),
phno decimal(12,0),
l_id int,
foreign key (l_id) references Login(uid) on delete cascade
);


