use SISDB

--1--Insert  values into the students table

insert into students(First_name,Last_name,Date_of_Birth,Email,Phone_number) values('John','Doe','1995-08-15','john.doe@example.com',1234567890)

select*from Students

--2--Choose an existing student and course and insert a record into the "Enrollments" table with the enrollment date.

insert into Enrollments(Student_ID,Course_ID,Enrollment_date) values(6,106,'2021-11-27')

select*from Enrollments

--3--identify students without enrollments

update Teacher set Email='kumaravi@gmail.com' where Teacher_ID=20
select*from Teacher

--4--delete a specific enrollment record from the "Enrollments" table based on the student and course.

delete from Enrollments where Student_ID=18 and Course_ID=101

select*from Enrollments

--5--Update the "Courses" table to assign a specific teacher to a course. 

update courses set teacher_id = 15 
where course_id = 106;

select*from courses

--6--Delete a specific student from the "Students" table and remove all their enrollment records from the "Enrollments" table. 

delete from Enrollments where Student_ID=19
delete from Payments where Student_ID = 19;--Student_id is a foreign key in payment table
delete from Students where Student_ID=19

select*from students
select*from Enrollments

--7--Update the payment amount for a specific payment record in the "Payments" table. 

update Payments set Amount=50000 where Payment_ID='PAY240319005' 

select*from Payments where Payment_ID='PAY240319005' 