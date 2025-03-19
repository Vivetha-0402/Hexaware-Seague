use marchdb
--create table trainee--

create table Traineee(
id int identity(100,1) not null,
name varchar(50),
skills varchar(50)
)

--Insert values--
insert into Traineee values('vive','sql'),('jan','c'),('divya','mern'),('raksj','sql')

select*from Traineee

delete from Traineee where id='104'



--