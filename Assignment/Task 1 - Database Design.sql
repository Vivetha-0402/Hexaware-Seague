--Create the database named "SISDB"--

create database SISDB

use SISDB


create table Students(
Student_ID int identity(1,1) primary key not null,
First_name varchar(50)not null,
Last_name varchar(50),
Date_of_Birth date ,
Email varchar(100)not null,
Phone_number varchar(15)not null
)


create table Teacher(
Teacher_ID int identity(10,1)primary key not null,
First_name varchar(50)not null,
Last_name varchar(50),
Email varchar(250)
)

create table Courses(
Course_ID int identity(100,1) primary key not null,
Course_name varchar(50)not null,
Credits tinyint,
Teacher_ID int,
constraint FK_Teacher foreign key (Teacher_ID) REFERENCES Teacher(Teacher_ID)
)

create table Enrollments(
Enrollment_ID int identity(1001,1)primary key not null,
Student_ID int ,
Course_ID int,
Enrollment_date date,
Constraint FK_Student_Enrollment foreign key (Student_ID) references Students(Student_ID),
Constraint FK_Course foreign key (Course_ID) references Courses(Course_ID)
)

create table Payments(
Payment_ID varchar(50) primary key not null,
Student_ID int ,
Amount int,
Payment_Date date,
constraint FK_Student_payment foreign key(Student_ID) references Students(Student_ID)
)


insert into Students(First_name,Last_name,Date_of_Birth,Email,Phone_number) values 
('Vivetha','Harini','2004-02-04','vivethaharini@gmail.com','9876543211'),
('Janalyn','Maroula','2003-08-05','janalynmaroula@gmail.com','6543211987'),
('Divya','Dharshini','2003-08-05','divyadharshini@gmail.com','9876565411'),
('Nivethaa','T','2003-09-30','nivethaat@gmail.com','9898543211'),
('Darathy','J','2004-04-26','darathyj@gmail.com','9876983211'),
('Lakshmi','S','1978-06-05','lakshmis@gmail.com','9876549811'),
('Senthil','Kumar','2003-09-03','senthilkumar@gmail.com','9876543298'),
('Lakshmanan','O','2004-06-05','lakshmanano@gmail.com','8776543211'),
('Aarthi','Nivetha','2001-11-08','aarthinivetha@gmail.com','9887543211'),
('Vidhya','L','2004-02-26','vidhyal@gmail.com','9887543211'),
('Rakshana','A','2003-11-21','rakshanaa@gmail.com','9876873211'),
('Samaya','Midhun','2004-02-06','samayamidhun@gmail.com','9876548711'),
('Sudha','B','2004-04-16','sudhab@gmail.com','9876543871'),
('Nivetha','K','2004-04-09','nivethak@gmail.com','9887543871'),
('Pradeep','T','2003-11-27','pradeept@gmail.com','9876548711'),
('Nideesh','A.G','2004-01-14','nideeshag@gmail.com','9876543651'),
('Sowmiya','K','2004-03-30','sowmiyak@gmail.com','9876565211'),
('Swathi','G','2003-12-16','swathig@gmail.com','9656543211'),
('Nickshana','Grace','2003-10-01','nickshanagrace@gmail.com','9876565211'),
('Manju','Ragavi','2004-05-27','manjuragavi@gmail.com','9876653211')


select*from Students

--Insert records for Teacher--


insert into Teacher (First_name,Last_name,Email)values('Varsha','Patel','varshapatel@gmail.com'),
('Teena','X','teenax@gmail.com'),
('Nancy','Xavier','nancyxavier@gmail.com'),
('Azhagu','Meenal','azhagumeenal@gmail.com'),
('Deepa','K','deepaK@gmail.com'),
('Selva','Rani','selvarani@gmail.com'),
('Bama','Devi','bamadevi@gmail.com'),
('Rani','K','ranik@gmail.com'),
('Dhivya','R','dhivyar@gmail.com'),
('Sathyanathan','R','sathyanathanr@gmail.com'),
('Ravi','Kumar','ravikumar@gmail.com'),
('Priyadharshini','R','priyadharshinir@gmail.com'),
('Yuvarani','K','yuvaranik@gmail.com'),
('Seetha','S','seethas@gmail.com'),
('Harini','P','harinip@gmail.com')


select*from Teacher


--inserting records for table Courses--
--Single course is assigned with multiple teachers--(One to Many Relationship)

insert into Courses (Course_name,Credits,Teacher_ID) values('C#',7,15),
('sql',6,12),
('Artificial Intelligence',3,11),
('Cloud Computing',2,16),
('Operating Systems',2,22),
('Social Engineering',1,13),
('Social Engineering',1,10),
('Software Engineering',1,23),
('ARVR',5,20),
('ARVR',5,21),
('Salesforce',4,24),
('Agile',6,18),
('Agile',6,19),
('IoT',4,14),
('Python',3,17)

select*from Courses


--Inserting records for table Enrollments--
--multiple enrollments for single course--(Many to One Relationship)

insert into Enrollments (Student_ID,Course_ID,Enrollment_date)values(1,101,'2021-10-05'),
(2,110,'2021-10-06'),
(3,106,'2021-10-25'),
(4,109,'2021-10-05'),
(5,111,'2021-10-05'),
(6,104,'2021-10-05'),
(7,107,'2021-10-05'),
(8,102,'2021-10-05'),
(2,101,'2021-10-06'),
(10,105,'2021-10-06'),
(11,103,'2021-10-06'),
(1,113,'2021-10-06'),
(13,108,'2021-10-06'),
(2,111,'2021-10-15'),
(15,101,'2021-10-15'),
(16,112,'2021-10-25'),
(17,114,'2021-10-25'),
(8,101,'2021-10-25'),
(19,113,'2021-10-25'),
(20,101,'2021-10-25'),
(2,101,'2021-10-25')

select*from Enrollments

--Inserting records into Payments table--

insert into Payments(Payment_ID,Student_ID,Amount,Payment_Date) values
('PAY240319001',1,85000,'2021-10-05'),('PAY240319002',2,60000,'2021-10-05'),
('PAY240319003',3,25000,'2021-10-05'),('PAY240319004',4,115000,'2021-10-05'),
('PAY240319005',5,4325,'2021-10-05'),('PAY240319006',6,75960,'2021-10-05'),
('PAY240319007',7,150000,'2021-10-05'),('PAY240319008',8,14000,'2021-10-05'),
('PAY240319009',2,93000,'2021-10-05'),('PAY240319010',10,86500,'2021-10-05'),
('PAY2403190011',11,78000,'2021-10-05'),('PAY2403190012',1,94000,'2021-11-05'),
('PAY2403190013',13,15200,'2021-11-05'),('PAY2403190014',2,65000,'2021-11-05'),
('PAY2403190015',15,74000,'2021-11-05'),('PAY2403190016',16,95000,'2021-11-08'),
('PAY2403190017',17,36000,'2021-11-08'),('PAY2403190018',8,61000,'2021-11-08'),
('PAY2403190019',19,93000,'2021-11-08'),('PAY2403190020',20,28600,'2021-11-08')

select*from Payments