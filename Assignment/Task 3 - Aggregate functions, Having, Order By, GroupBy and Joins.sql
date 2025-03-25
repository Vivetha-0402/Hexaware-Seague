use SISDB

--1--the total payments made by a specific student. 

select s.Student_ID ,s.First_name as Student_Name,sum(p.amount) as Total_Payments from Students as s
right join 
payments as p
on s.Student_ID=p.Student_ID
where s.Student_ID=15
group by s.Student_ID,s.First_name

--2--list of courses along with the count of students enrolled in each course.

select c.Course_ID,c.Course_name,count(e.student_ID) as students_Count from Enrollments as e
join
Courses as c
on c.Course_ID=e.Course_ID
group by c.Course_ID,c.Course_name


--3--names of students who have not enrolled in any course. 


select s.Student_ID,s.First_name as Student_Name from Students as s
left join
Enrollments as e
on s.Student_ID=e.Student_ID
where e.Enrollment_ID is null

--4--Retrieve the first name, last name of students, and the names of the courses they are enrolled in.

select s.First_name as First_Name,s.Last_name as Last_Name,c.course_name from Students as s
join Enrollments as e on e.Student_ID=s.Student_ID
join Courses as c on e.Course_ID=c.Course_ID

--5--List the names of teachers and the courses they are assigned to.


select t.First_name as Teacher_Name,c.Course_Name from Teacher as t
join courses as c
on c.Teacher_ID=t.Teacher_ID

--6--Retrieve a list of students and their enrollment dates for a specific course. 

select s.Student_ID,s.First_name as Student_Name,c.Course_name,e.Enrollment_date from Students as s
join Enrollments as e
on s.Student_ID=e.Student_ID
join courses as c on e.Course_ID=c.Course_ID
where c.Course_ID=101

--7Names of students who have not made any payments.

select s.first_name as Student_Name from Students as s
left join 
payments as p
on s.Student_ID=p.Student_ID
where p.Payment_ID is null

--8courses that have no enrollments. 

select c.Course_ID,c.course_name from Courses as c
left join enrollments as e
on e.Course_ID=c.Course_ID
where Enrollment_ID is null

--9-- students who are enrolled in more than one course. 

select e.student_id, s.First_name as Student_Name, count(e.student_id) as enrollmentcount
from enrollments as e
join students as s on e.student_id = s.Student_ID
group by e.student_id, s.First_name
having count(e.student_id) > 1;


--10--teachers who are not assigned to any courses. 

select t.teacher_ID ,t.First_Name as Teacher_Name from teacher as t
left join courses as c
on t.Teacher_ID=c.teacher_ID
where c.Teacher_ID is null



---one student should enroll in multiple courses
