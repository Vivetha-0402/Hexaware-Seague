--Accessing Database--
use marchdb

--Table Trainee--
create table PgetTrainee(
Trainee_id int identity(100,1)not null,
Trainee_name varchar(50),
Skill_id int not null ,
Trainee_skill varchar(50),
constraint PK_TSID
)