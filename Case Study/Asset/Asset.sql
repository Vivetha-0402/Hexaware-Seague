create database AssetDB;

use AssetDB;


create table employees (
    employee_id int primary key identity(1,1),
    name varchar(100) not null,
    department varchar(100) not null,
    email varchar(100) unique not null,
    password varchar(100) not null
);

create table assets (
    asset_id int primary key identity(1,1),
    name varchar(100) not null,
    type varchar(50) not null,
    serial_number varchar(100) unique not null,
    purchase_date date not null,
    location varchar(100) not null,
    status varchar(50) not null,
    owner_id int,
    foreign key (owner_id) references employees(employee_id)
);

create table maintenance_records (
    maintenance_id int primary key identity(1,1),
    asset_id int not null,
    maintenance_date date not null,
    description text not null,
    cost decimal(10, 2) not null,
    foreign key (asset_id) references assets(asset_id)
);

create table asset_allocations (
    allocation_id int primary key identity(1,1),
    asset_id int not null,
    employee_id int not null,
    allocation_date date not null,
    return_date date null,
    foreign key (asset_id) references assets(asset_id),
    foreign key (employee_id) references employees(employee_id)
);

create table reservations (
    reservation_id int primary key identity(1,1),
    asset_id int not null,
    employee_id int not null,
    reservation_date date not null,
    start_date date not null,
    end_date date not null,
    status varchar(50) not null,
    foreign key (asset_id) references assets(asset_id),
    foreign key (employee_id) references employees(employee_id)
);



insert into employees (name, department, email, password) values
('Ravi Kumar', 'IT', 'ravi.kumar@example.com', 'pass123'),
('Anjali Singh', 'HR', 'anjali.singh@example.com', 'pass123'),
('Deepak Mehta', 'Finance', 'deepak.mehta@example.com', 'pass123'),
('Sneha Roy', 'Admin', 'sneha.roy@example.com', 'pass123'),
('Amit Verma', 'IT', 'amit.verma@example.com', 'pass123'),
('Pooja Nair', 'Logistics', 'pooja.nair@example.com', 'pass123'),
('Manoj Das', 'HR', 'manoj.das@example.com', 'pass123'),
('Neha Joshi', 'Finance', 'neha.joshi@example.com', 'pass123'),
('Rajesh Sharma', 'IT', 'rajesh.sharma@example.com', 'pass123'),
('Meena Iyer', 'Admin', 'meena.iyer@example.com', 'pass123');



insert into assets (name, type, serial_number, purchase_date, location, status, owner_id) values
('Dell Laptop', 'laptop', 'DL123456', '2022-01-15', 'Chennai', 'in use', 1),
('HP Printer', 'equipment', 'HP987654', '2021-12-10', 'Mumbai', 'under maintenance', 2),
('Toyota Innova', 'vehicle', 'TN10AZ1234', '2020-05-20', 'Bangalore', 'in use', 3),
('MacBook Pro', 'laptop', 'MBP2023X', '2023-02-01', 'Hyderabad', 'in use', 4),
('Epson Scanner', 'equipment', 'EPS5566', '2022-08-11', 'Delhi', 'in use', 5),
('Honda City', 'vehicle', 'MH12XY1122', '2021-09-30', 'Chennai', 'decommissioned', 6),
('HP Elitebook', 'laptop', 'HPEB9000', '2021-04-12', 'Pune', 'in use', 7),
('Brother Printer', 'equipment', 'BP8888', '2022-11-15', 'Mumbai', 'under maintenance', 8),
('Suzuki Ertiga', 'vehicle', 'KA03MM4455', '2023-03-05', 'Bangalore', 'in use', 9),
('Acer Monitor', 'equipment', 'ACM0001', '2023-01-25', 'Hyderabad', 'in use', 10);



insert into maintenance_records (asset_id, maintenance_date, description, cost) values
(2, '2023-03-01', 'Replaced ink cartridge', 1500.00),
(6, '2022-10-10', 'Engine check and servicing', 6500.00),
(8, '2023-01-18', 'Paper jam fix and cleaning', 1200.00),
(1, '2023-04-10', 'Battery replacement', 2500.00),
(3, '2022-07-22', 'Tyre change', 4000.00),
(4, '2023-03-12', 'OS update and cleanup', 500.00),
(5, '2023-05-01', 'Glass replacement', 700.00),
(7, '2023-06-08', 'Keyboard replacement', 900.00),
(9, '2023-07-20', 'AC maintenance', 2000.00),
(10, '2023-02-15', 'Display issue fix', 1100.00);


insert into asset_allocations (asset_id, employee_id, allocation_date, return_date) values
(1, 1, '2023-01-10', null),
(2, 2, '2023-01-15', '2023-04-01'),
(3, 3, '2022-08-01', null),
(4, 4, '2023-02-05', null),
(5, 5, '2023-03-15', null),
(6, 6, '2021-10-01', '2023-01-10'),
(7, 7, '2023-04-20', null),
(8, 8, '2023-05-05', null),
(9, 9, '2023-06-10', null),
(10, 10, '2023-07-01', null);


insert into reservations (asset_id, employee_id, reservation_date, start_date, end_date, status) values
(1, 2, '2023-08-01', '2023-08-10', '2023-08-15', 'approved'),
(2, 3, '2023-08-05', '2023-08-12', '2023-08-18', 'pending'),
(3, 4, '2023-08-08', '2023-08-14', '2023-08-20', 'approved'),
(4, 5, '2023-08-10', '2023-08-16', '2023-08-22', 'canceled'),
(5, 6, '2023-08-11', '2023-08-17', '2023-08-23', 'approved'),
(6, 7, '2023-08-12', '2023-08-18', '2023-08-24', 'pending'),
(7, 8, '2023-08-13', '2023-08-19', '2023-08-25', 'approved'),
(8, 9, '2023-08-14', '2023-08-20', '2023-08-26', 'approved'),
(9, 10, '2023-08-15', '2023-08-21', '2023-08-27', 'pending'),
(10, 1, '2023-08-16', '2023-08-22', '2023-08-28', 'approved');


select*from reservations;
select*from assets;