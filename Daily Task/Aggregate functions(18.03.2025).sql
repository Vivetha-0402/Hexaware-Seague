use master
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'employee';

alter table employee add salary_id bigint null
select * from employee 
update employee set salary_Id=25000 where Emp_id =102
update employee set salary_Id=26000 where Emp_id =103
update Employee set salary_id=28000 where Emp_id =104
update Employee set salary_id=52000 where Emp_id =105
update Employee set salary_id=65000 where Emp_id =106
update Employee set salary_id=68000 where Emp_id =101
update Employee set salary_id=72000 where Emp_id =107


--Aggregate functions

select count(Emp_id) as No_of_Employees from employee

-- minimum
select min(salary_id) as Minimumm_Salary from employee

-- maximum
select max(salary_id) as Maximum_Salary from employee

--average 

select avg(salary_id) as Average_Salary from employee

-- Total-- 
select SUM(salary_id) as Total_Salary from employee

SELECT Emp_id, salary_id
FROM employee
WHERE salary_id = (SELECT MIN(salary_id) FROM employee);


--Grouping function only works with aggregate function

select * from employee

select count(Emp_name) as No_of_Employees, license from employee group by license

-- count no of employees using same licsnse whose salary is <=10000
select count(Emp_name) as No_of_Employees, 
license, salary_id from employee 
group by license, salary_id having salary_id <=30000


insert into employee values(108,'raji', 3503953535,'ass@gmail.com','2424-11-8','Lic564','pass7891',34000)

select sum(salary_id),license,salary_id
from employee
group by license,salary_id having salary_id<=30000

select sum(salary_id) as total_salary,license ,Emp_name from employee
where Emp_name like 'v%' 
group by license ,salary_id
having salary_id <=30000