use SISDB



--1  Write an SQL query to calculate the average number of students enrolled in each course. Use aggregate functions and subqueries to achieve this.

select c.Course_ID,c.Course_Name,
(select count(e.Student_ID) 
from Enrollments  e 
where e.course_ID=c.course_ID) as Average_No_Of_Students
from courses  c

--join

select c.course_id, c.course_name, count(e.student_id)  as avg_students
from courses c
join enrollments e on c.course_id = e.course_id
group by c.course_id, c.course_name;


--2 Identify the student(s) who made the highest payment. Use a subquery to find the maximum payment amount and then retrieve the student(s) associated with that amount.
 

select s.Student_ID,s.First_Name as Student_Name,p.Amount as Highest_Payment from Students  s
join payments  p
on p.Student_ID=s.Student_ID
where p.Amount=(select max(Amount)  from payments)

--3 . Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the course(s) with the maximum enrollment count.

select c.course_id, c.course_name,(select count(*) 
from enrollments  e 
where e.course_id = c.course_id) as enrollment_count
from courses as c
where (select count(*) from enrollments as e 
where e.course_id = c.course_id) = (select max(enrollment_count) 
from (select count(*) as enrollment_count 
from enrollments 
group by course_id) as counts)

--4  Calculate the total payments made to courses taught by each teacher. Use subqueries to sum payments for each teacher's courses

select t.teacher_id, t.first_name,c.course_id, c.course_name,
(select sum(p.amount) from enrollments  e
join payments p on e.student_id = p.student_id
where e.course_id = c.course_id) as total_payments
from teacher t
join courses c on t.teacher_id = c.teacher_id

--5 Identify students who are enrolled in all available courses. Use subqueries to compare a student's enrollments with the total number of courses.

--It is not working
select s.student_id, s.First_name as Student_Name
from students s
where (
    select count(e.course_id) 
    from enrollments e 
    where e.student_id = s.student_id) = (select count(course_id) from courses)

--6 Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to find teachers with no course assignments.

select t.teacher_id, t.first_name, t.last_name
from Teacher t
where t.teacher_id NOT IN (
select distinct teacher_id 
from Courses 
where teacher_id is not null
)

--7  Calculate the average age of all students. Use subqueries to calculate the age of each student based on their date of birth

select avg(year(getdate()) - year(s.date_of_birth)) as average_age
from Students s;

--8 Identify courses with no enrollments. Use subqueries to find courses without enrollment records.

select c.Course_ID, c.Course_Name
from Courses c
where c.Course_ID not in (select Course_ID from Enrollments);


-- 9. Calculate the total payments made by each student for each course they are enrolled in. Use subqueries and aggregate functions to sum payments.

--Using subquery--
SELECT s.student_id, s.First_name as Student_Name, c.course_id, c.course_name, 
(SELECT SUM(p.amount) FROM payments p 
where p.student_id = s.student_id) AS total_payment
from students s
join enrollments e on s.student_id = e.student_id
join courses c on e.course_id = c.course_id


--10. Identify students who have made more than one payment. Use subqueries and aggregate functions to count payments per student and filter for those with counts greater than one.

select s.student_id, s.First_name as Student_Name
from students as s
where student_id IN (
select student_id
from payments
group by student_id
having count(payment_id) > 1
)

--11. Write an SQL query to calculate the total payments made by each student. Join the "Students" table with the "Payments" table and use GROUP BY to calculate the sum of payments for each student.

select s.student_id, s.First_name as Student_Name, sum(p.amount) as total_payment
from students s
join payments p on s.student_id = p.student_id
group by s.student_id, s.First_name;

--12. Retrieve a list of course names along with the count of students enrolled in each course. Use JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to count enrollments.

select c.course_id, c.course_name, count(e.student_id) as student_count
from courses c
join enrollments e on c.course_id = e.course_id
group by c.course_id, c.course_name;

--13. Calculate the average payment amount made by students. Use JOIN operations between the "Students" table and the "Payments" table and GROUP BY to calculate the average.

select s.student_id, s.First_name as Student_Name, avg(p.amount) as Average_payment
from students s
join payments p on s.student_id = p.student_id
group by s.student_id, s.First_name;
