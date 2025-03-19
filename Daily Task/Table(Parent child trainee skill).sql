--Accessing Database--
use marchdb

--Table Trainee--

create table TraineeSkills
(
TraineeID int identity(100,1) not null,
Trainee_Name varchar(50),
SkillID int not null,
Trainee_Skill varchar(50),
constraint PKK_TSID primary key (TraineeID,SkillID)
)

select * from TraineeSkills

---Parent & child table with primary & forieng key
--Parent
create table Skill(
ID int identity(200,1) primary key not null,
Name varchar(50)
)

--Child
create table PgTraineee(
ID int identity(100,1) primary key not null,
Name varchar(50),
Skill int not null,
constraint FK_Skill foreign key(Skill) references Skill(ID)
)

insert into Skill values('C#'),('C++'),('Java'),('Python'),('AI'),('Data Science')
select * from Skill
 
insert into PgTraineee values('Vivetha',200),
('Rakshana',201),
('Samaya',202),
('Darathy',203)

select * from Skill
select * from PgTraineee

--cannot delete bcoz they are interlinked 
delete from Skill where ID=200

--so delete the record first from trainee and then go with skill
delete from PgTraineee where Skill=200
select * from PgTraineee

delete from Skill where ID=200
select * from Skill

update Skill set Name='C#' where id =201
select * from Skill