CREATE DATABASE HospitalDB;

USE HospitalDB;

-- 1. create the 'patients' table
create table patients (
    patientid int primary key identity(1,1), -- auto-increment id
    first_name varchar(100) not null,
    last_name varchar(100) not null,
    dob date not null, -- date of birth
    gender varchar(10) not null,
    contact_number varchar(20),
    email varchar(100)
);

-- 2. create the 'doctors' table
create table doctors (
    doctorid int primary key identity(1,1), -- auto-increment id
    first_name varchar(100) not null,
    last_name varchar(100) not null,
    specialty varchar(100) not null,
    contact_number varchar(20),
    email varchar(100)
);

-- 3. create the 'appointments' table
create table appointments (
    appointmentid int primary key identity(1,1), -- auto-increment id
    patientid int not null, -- foreign key to 'patients' table
    doctorid int not null,  -- foreign key to 'doctors' table
    appointmentdate datetime not null, -- appointment date and time
    remarks varchar(255),  -- remarks for the appointment
    foreign key (patientid) references patients(patientid),
    foreign key (doctorid) references doctors(doctorid)
);

-- 4. insert sample data into 'patients' table
insert into patients (first_name, last_name, dob, gender, contact_number, email)
values 
('Vivetha', 'Harini', '2004-02-04', 'female', '1234567890', 'vive@email.com'),
('Senthil', 'Kumar', '1990-02-25', 'male', '9876543210', 'senthil@email.com'),
('Rajesh', 'Patel', '1985-06-15', 'male', '5432167890', 'rajesh.patel@email.com'), 
('Anjali', 'Kumari', '1992-09-10', 'female', '6789054321', 'anjali.kumari@email.com'), 
('Arvind', 'Rao', '1980-11-25', 'male', '1122334455', 'arvind.rao@email.com'), 
('Madhavi', 'Verma', '2000-03-05', 'female', '6677889900', 'madhavi.verma@email.com'), 
('Karan', 'Patil', '1995-01-30', 'male', '2233445566', 'karan.patil@email.com'), 
('Priya', 'Bhatt', '1998-07-20', 'female', '9988776655', 'priya.bhatt@email.com'), 
('Sandeep', 'Gupta', '1988-12-12', 'male', '3344556677', 'sandeep.gupta@email.com'), 
('Neha', 'Joshi', '1995-04-14', 'female', '4433221100', 'neha.joshi@email.com'); 

-- 5. insert sample data into 'doctors' table
insert into doctors (first_name, last_name, specialty, contact_number, email)
values 
('Dr. Rajesh', 'V', 'cardiology', '555-123-4567', 'Rajesh@hospital.com'),
('Dr. Babu', 'Christopher', 'neurology', '555-987-6543', 'Babu@hospital.com'),
('Dr. Rajesh', 'V', 'cardiology', '555-123-4567', 'rajesh@hospital.com'),
('Dr. Babu', 'Christopher', 'neurology', '555-987-6543', 'babu@hospital.com'),
('Dr. Anita', 'Desai', 'orthopedics', '555-222-3333', 'anita@hospital.com'), 
('Dr. Karthik', 'Shukla', 'pediatrics', '555-444-5555', 'karthik@hospital.com'), 
('Dr. Priya', 'Patel', 'dermatology', '555-666-7777', 'priya@hospital.com'), 
('Dr. Ravi', 'Kumar', 'gastroenterology', '555-888-9999', 'ravi@hospital.com'),
('Dr. Meera', 'Khan', 'gynecology', '555-111-2222', 'meera@hospital.com'), 
('Dr. Rajiv', 'Kapoor', 'general surgery', '555-333-4444', 'rajiv@hospital.com'), 
('Dr. Sangeeta', 'Gupta', 'opthalmology', '555-555-6666', 'sangeeta@hospital.com'), 
('Dr. Arjun', 'Bhat', 'psychiatry', '555-777-8888', 'arjun@hospital.com'); 

-- 6. insert sample data into 'appointments' table
insert into appointments (patientid, doctorid, appointmentdate, remarks)
values 
(1, 1, '2025-05-01 10:00:00', 'follow-up checkup'),
(2, 2, '2025-05-02 14:30:00', 'neurological evaluation'),
(1, 1, '2025-05-01 10:00:00', 'follow-up checkup'), 
(2, 2, '2025-05-02 14:30:00', 'neurological evaluation'), 
(3, 3, '2025-05-03 09:30:00', 'knee pain consultation'),
(4, 4, '2025-05-04 15:00:00', 'routine pediatric checkup'), 
(5, 5, '2025-05-05 11:15:00', 'skin rash consultation'), 
(6, 6, '2025-05-06 12:00:00', 'digestive issues consultation'), 
(7, 7, '2025-05-07 16:30:00', 'annual gynecological checkup'), 
(8, 8, '2025-05-08 13:00:00', 'hernia consultation'), 
(9, 9, '2025-05-09 10:45:00', 'eye checkup'), 
(10, 10, '2025-05-10 14:00:00', 'mental health consultation');

























-- 7. query to retrieve an appointment by id (for example, appointmentid = 1)
select * from appointments where appointmentid = @id;

-- 8. query to retrieve all appointments for a specific patient (for example, patientid = 1)
select * from appointments where patientid = @pid;

-- 9. query to retrieve all appointments for a specific doctor (for example, doctorid = 1)
select * from appointments where doctorid = @did;

-- 10. query to update an appointment's details
update appointments
set patientid = @pid, doctorid = @did, appointmentdate = @date, remarks = @remarks
where appointmentid = @aid;

-- 11. query to delete an appointment by id
delete from appointments where appointmentid = @id;


-- For patients table
SELECT * FROM patients WHERE 1 = 0;

-- For doctors table
SELECT * FROM doctors WHERE 1 = 0;


