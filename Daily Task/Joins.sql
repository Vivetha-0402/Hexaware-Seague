Use marchdb

---JOINS---
--FETCH RECORDS FROM SKILL
select * from Skill
--FETCH RECORDS FROM SKILL
select * from PgTraineee

--INNER JOIN 
select * from Skill
select * from PgTraineee
select * from Skill
inner join
PgTraineee
on Skill.ID = PgTraineee.Skill

--OUTER LEFT JOIN
select * from Skill
select * from PgTraineee
select * from Skill
left join 
PgTraineee
on Skill.ID = PgTraineee.Skill

--RIGHT OUTER JOIN
select * from Skill
select * from PgTraineee
select * from Skill
right join 
PgTraineee
on Skill.ID = PgTraineee.Skill

--WITH ALICE NAME
select s.Name as Course , t.Name as PgTraineee
from Skill as s
right join
PgTraineee as t
on s.ID = t.Skill

where s.ID is not null --not null values

--FULL OUTER JOIN
select s.Name as Course, t.Name as PgTraineee
from Skill as s
full join
PgTraineee as t
on s.ID=t.Skill --Compare values from both table based on PK & FK
where s.Name is not null and t.Name is not null