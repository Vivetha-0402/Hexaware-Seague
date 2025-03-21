use marchdb
create table product(
pid int identity(100,1)primary key not null,
pname varchar(50),
pprice bigint
)

insert into product values('pen',10),('notebook',45),('laptop',65000),('Toys',250)

create table ProductOrder(
orid int identity(200,1)primary key not null,
orderdate Date,
productId int ,
constraint FK_productId foreign key(productId)references product(pid)
)

--subquery within insert--

insert into ProductOrder values(GETDATE(),(select pid from product where pname='pen')),
(GETDATE(),(select pid from product where pname='notebook')),
(GETDATE(),(select pid from product where pname='laptop')),
(GETDATE(),(select pid from product where pname='Toys'))

select *from ProductOrder

--subquery within update--
update ProductOrder set productId=(select pid from product where pname='toys')where orid=205
select*from product
select*from ProductOrder

--subquery within delete--
delete from ProductOrder where productId=103
delete from product where pid not in(select productId from ProductOrder)
select*from product
select*from ProductOrder

--Select query within where clause--

select pname,pprice from(select*from product)as t

select avg(pprice)from product
select pname,pprice from product where pprice>=(select avg(pprice)from product)


select count(pid),pname,pprice from product group by pname,pprice