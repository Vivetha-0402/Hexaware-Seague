--String functions--

select upper('trainee')as TraineeInUpper
select lower('TRAINEE')as TraineeInLower
select concat('Vivetha',' ','Harini' )as FullName
select reverse('Vivetha Harini')
select replace ('Vivetha','Harini','S')

--Math functions--

select power(10,2)
select sqrt(25)
select pi()

--Data function--
select SYSDATETIME()

select GETDATE()
select SYSDATETIMEOFFSET()
select ISDATE('4-2-2004')