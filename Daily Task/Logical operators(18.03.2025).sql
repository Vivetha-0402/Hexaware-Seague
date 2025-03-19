-- sort table according to the name
select*from employee order by Emp_name asc

--- select record with id 101 and 102
select * from employee where Emp_Id>=101 and Emp_Id<=103
 -- in operator
select * from employee where Emp_Id in(104,107)
-- between operator
select * from employee where Emp_Id between 102 and 104
--- or operator
select * from employee where Emp_Id =104 or Emp_Id=105
-- not operator
select * from employee where Emp_Id is not null


-- record with starting letter A--

select * from employee where Emp_name like 'A%'

-- record with starting letter s and ending letter i--

select * from employee where Emp_name like 's%a'

-- records for letter ending with i--

select  * from employee where Emp_name like '%i'

-- records for letter at starting second  position--

select  * from employee where Emp_name like '_i%'

-- records for letter at second last position--

select * from employee where Emp_name like '%i_'

select * from employee where Emp_id is not null

-- records with limit--

select * from employee order by Emp_Id asc offset 2 rows fetch next 3 rows only

-- First 3 records--

select Top 3 * from employee