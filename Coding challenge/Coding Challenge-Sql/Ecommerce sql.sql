--Ecommerce Sql--

--create database Ecomm--

create database Ecommerce

use Ecommerce

--create Customers table--


create table Customers
(
customer_id int identity primary key not null ,
customer_name varchar(50),
email varchar(50),
customer_password varchar(50)
)


create table products
(
product_id int identity primary key not null ,
product_name varchar(50),
product_description varchar(50),
price decimal(10,2),
stock_quantity int

)


create table cart
(
cart_id int identity primary key not null,
customer_id int,
product_id int,
quantity int,
constraint fk_customer foreign key (customer_id) references customers(customer_id),
constraint fk_product foreign key (product_id) references products(product_id)

)


create table orders
(
order_id int identity primary key not null,
customer_id int,
order_date date,
total_price decimal(10,2),
shipping_address varchar(250),
constraint fk_customerorder foreign key (customer_id) references customers(customer_id)
)


create table order_items
(
order_item_id int identity primary key not null,
order_id int,
product_id int,
quantity int,
constraint fk_order foreign key (order_id) references orders(order_id),
constraint fk_productorder foreign key (product_id) references products(product_id)

)


-- insert into products table
insert into products (product_name, product_description, price, stock_quantity) values
('Laptop', 'High-performance laptop', 800.00, 10),  
('Smartphone', 'Latest smartphone', 600.00, 15),  
('Tablet', 'Portable tablet', 300.00, 20),  
('Headphones', 'Noise-canceling', 150.00, 30),  
('TV', '4K smart TV', 900.00, 5),  
('Coffee Maker', 'Automatic coffee maker', 50.00, 25),  
('Refrigerator', 'Energy-efficient', 700.00, 10),  
('Microwave Oven', 'Countertop microwave', 80.00, 15),  
('Blender', 'High-speed blender', 70.00, 20),  
('Vacuum Cleaner', 'Bagless vacuum cleaner', 120.00, 10)


select*from products

-- insert into customers table

insert into customers (customer_name, email, customer_password) values  
('John Doe', 'johndoe@example.com', 'john@123'),  
('Jane Smith', 'janesmith@example.com', 'jane#456'),  
('Robert Johnson', 'robert@example.com', 'robert!789'),  
('Sarah Brown', 'sarah@example.com', 'sarah^13'),  
('David Lee', 'david@example.com', 'david'),  
('Laura Hall', 'laura@example.com', 'laura(123)'),  
('Michael Davis', 'michael@example.com', 'michael'),  
('Emma Wilson', 'emma@example.com', 'emma3'),  
('William Taylor', 'william@example.com', 'william@123'),  
('Olivia Adams', 'olivia@example.com', 'olivia1%23') 


select*from customers

-- insert into orders table
insert into orders (customer_id, order_date, total_price, shipping_address) values
(1, '2023-01-05', 1200.00, '123 main st, city'),
(2, '2023-02-10', 900.00, '456 elm st, town'),
(3, '2023-03-15', 300.00, '789 oak st, village'),
(4, '2023-04-20', 150.00, '101 pine st, suburb'),
(5, '2023-05-25', 1800.00, '234 cedar st, district'),
(6, '2023-06-30', 400.00, '567 birch st, county'),
(7, '2023-07-05', 700.00, '890 maple st, state'),
(8, '2023-08-10', 160.00, '321 redwood st, country'),
(9, '2023-09-15', 140.00, '432 spruce st, province'),
(10, '2023-10-20', 1400.00, '765 fir st, territory')

select* from orders

-- insert into order_items table
insert into order_items (order_id, product_id, quantity) values
(1, 1, 2),
(1, 3, 1),
(2, 2, 3),
(3, 5, 2),
(4, 4, 4),
(4, 6, 1),
(5, 1, 1),
(5, 2, 2),
(6, 10, 2),
(6, 9, 3)

select*from order_items

-- insert into cart table
insert into cart (customer_id, product_id, quantity) values
(1, 1, 2),
(1, 3, 1),
(2, 2, 3),
(3, 4, 4),
(3, 5, 2),
(4, 6, 1),
(5, 1, 1),
(6, 10, 2),
(6, 9, 3),
(7, 7, 2)

select*from cart


--1. Update refrigerator product price to 800.

update products set price=800
where product_name='refrigerator'

select*from products where product_name='refrigerator'

--2. Remove all cart items for a specific customer.--

delete from cart where customer_id=4

select*from cart

--3. Retrieve Products Priced Below $100.

select *from products
where price<100


--4. Find Products with Stock Quantity Greater Than 5.

select*from products
where stock_quantity>5

--5. Retrieve Orders with Total Amount Between $500 and $1000.

select*from orders
where total_price between 500 and 1000


--6. Find Products which name end with letter ‘r’.

select*from products 
where product_name like '%r'

--7. Retrieve Cart Items for Customer 5.

select *from cart
where customer_id=5

--8. Find Customers Who Placed Orders in 2023.

select distinct c.* from customers c
join orders o
on c.customer_id=o.customer_id
where year(o.order_date)=2023


--9. Determine the Minimum Stock Quantity for Each Product Category.

select product_name,min(stock_quantity) as Minimum_stock
from products
group by product_name



--10. Calculate the Total Amount Spent by Each Customer.

select c.customer_id,c.customer_name,sum(o.total_price) as Total_Amount_Spent from customers c
left join orders o
on c.customer_id=o.customer_id
group by c.customer_id,c.customer_name

--11. Find the Average Order Amount for Each Customer.

select c.customer_id,c.customer_name,avg(o.total_price) as Total_Amount_Spent from customers c
left join orders o
on c.customer_id=o.customer_id
group by c.customer_id,c.customer_name

--12. Count the Number of Orders Placed by Each Customer.

select c.customer_id,c.customer_name,count(o.order_id)as Number_Of_Orders 
from customers c
left join orders o
on c.customer_id=o.customer_id
group by c.customer_id,c.customer_name

--13. Find the Maximum Order Amount for Each Customer.

select c.customer_id,c.customer_name,max(o.total_price)as Maximum_Order_Amount
from customers c
left join orders o
on c.customer_id=o.customer_id
group by c.customer_id,c.customer_name

--14. Get Customers Who Placed Orders Totaling Over $1000.

select c.customer_id,c.customer_name,sum(o.total_price)as Total
from customers c
join orders o
on o.customer_id=c.customer_id
group by c.customer_id,c.customer_name
having sum(o.total_price)>1000

--15. Subquery to Find Products Not in the Cart.

select*from products 
where product_id not in (select product_id from cart)

--16. Subquery to Find Customers Who Haven't Placed Orders.

select*from customers 
where customer_id not in (select customer_id from orders)

--17. Subquery to Calculate the Percentage of Total Revenue for a Product.

select p.product_id, p.product_name,sum(oi.quantity * p.price) as product_revenue, 
(sum(oi.quantity * p.price) * 100)/(select sum(oi.quantity * p.price) from order_items oi join products p on oi.product_id = p.product_id) as revenue_percentage
from order_items oi
join products p on oi.product_id = p.product_id
group by p.product_id, p.product_name

--18. Subquery to Find Products with Low Stock.

select*from products 
where stock_quantity < (select avg(stock_quantity) from products)


--19. Subquery to Find Customers Who Placed High-Value Orders.

select*from customers 
where customer_id in (select customer_id from orders where total_price > (select avg(total_price) from orders))

