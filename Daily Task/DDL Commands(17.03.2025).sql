--Create Database--
create database TestData

--Select Database--
select*from master.sys.databases
select name from master.sys.databases
select*from master.sys.master_files

--call store procedures to get list of databases--
exec sp_databases

--Alter database--
alter database TestData modify name=marchdb

--Delete database--
drop database marchdb

--Check if database is exist or not--
drop database if exists TestData

--Example--

create database Test3

alter database Test3 modify name=march1

--create table using schema--
create table employee(
Emp_id int,
Emp_name varchar(max),
Phone_number bigint,
email varchar(max),
DOB date,
license varchar(50),
passport varchar(50)
)

--Alter table by adding Column--
 
 alter table employee add emailid varchar(50) null

 --Alter Column name--

 alter table employee alter column emp_name varchar(max)null

 --delete column--

 alter table employee drop column emailid 

 --alter table by adding primary key

 alter table employee alter column Emp_id int not null

 alter table employee alter column Emp_Id int  not null

alter table employee add constraint PK_Id primary key(Id)

-- create Employee salary table--

create table Employee_salary(
salary_Id int primary key not null
)

sp_help 'Employee_salary';

--delete table from database

--drop table Employee--

--Use marchDB

--add new record in table

insert into employee(Emp_id,Emp_name,phone_number,email,license,passport,dob)
values(101,'Vive',7548884071,'abc@gmail.com','Lic102','psp32q','2004-02-04')

insert into employee(Emp_id,Emp_name,phone_number,email,license,passport,dob)
values(102,'Harini',9150870573,'def@gmail.com','Lic103','psp32q','2003-11-27')

insert into employee(Emp_id,Emp_name,phone_number,email,license,passport,dob)
values(103,'Lakshmi',9791990090,'ghi@gmail.com','Lic106','psp32q','1978-06-05')

insert into employee(Emp_id,Emp_name,phone_number,email,license,passport,dob)
values(104,'Aarthi',7548834899,'jkl@gmail.com','Lic101','psp32q','2003-11-08')


--view structure
sp_help 'employee'

--retrieve all records from table

select * from employee

select * from employee where Emp_id=102

select * from employee where Emp_name='Harini'

--foramtting result set by giving alloy names(Alternate names)

select e.Emp_Id as Employee_ID,
e.Emp_name as Employee_name,
e.Phone_number as Employee_phonenumber,
e.email as Employee_emailid,
e.dob as Employee_dob,
e.license as Employee_license,
e.passport as Employee_passport,
e.email as Employee_emailid
from employee e

--altering table

alter table employee drop column employee_emailid

select * from employee

update employee set Emp_name='samaya',Phone_number=6789543234,license='adf33',passport='padaew23',email='aca@gmail.com'
where Emp_id=102

--Adding a record --

insert into employee (Emp_id, Emp_name, Phone_number, Email, DOB, License, Passport)values (105, 'Akcs', 9876543210, 'doe@gmail.com', '1990-05-15', 'Lic107', 'psp45x');

--remove record from table

delete from employee where Emp_id=105

 select*from employee











