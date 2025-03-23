use marchdb

Use MarchDB
-- sub query within from clause
select pname,pprice from (select * from product) as t


--sub query within where clause with logical operators
select avg(pprice) from product
select pname,pprice from product where pprice >=(select avg(pprice) from product) 

select t.pname,t.pprice from (select * from product) as t

select pname,pprice from product where pprice In(select avg(pprice) from product group by pname)

select avg(pprice),pname from product group by pname

--sub query to find out average price of product and search maximum price greater than average price

select avg(pprice) from product group by pname
select pname,pprice from product where pprice >All(select avg(pprice) from product group by pname)
select * from product

--join query to find out average price of product and search price greater than the average

select avg(pprice) from product group by pname
select p1.pname,p1.pprice from product as p1
join
product as p
on p.pid =p1.pid
where p.pprice >= All(select avg(pprice) from product group by pname)
select * from product

--Any returns true if one of the statement is satisfied
select pname,pprice from product where pprice <= Any(select avg(pprice) from product group by pname)

--All returns true if
select pname,pprice from product where pprice <= All(select avg(pprice) from product group by pname)


--corelated sub queries
select * from product
select * from ProductOrder


select  p.pid,p.pname,
(select count(productid) from ProductOrder where productId= p.pid group by productId )  as Total_Order
from product as p

--using join
select p.pid, p.pname, count(o.productid)as Total_Order
from product as p
inner join 
ProductOrder as o
on p.pid=o.productId
group by p.pname,p.pid

select pid, pname,pprice,(select orderDate from ProductOrder where productid=p.pid) from product as p