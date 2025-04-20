CREATE TABLE Students (
    StudentID NVARCHAR(50) PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATE,
    Email NVARCHAR(150),
    PhoneNumber NVARCHAR(15)
);

CREATE TABLE Courses (
    CourseID NVARCHAR(50) PRIMARY KEY,
    CourseName NVARCHAR(100),
    CourseCode NVARCHAR(50),
    InstructorName NVARCHAR(100)
);

CREATE TABLE Teachers (
    TeacherID NVARCHAR(50) PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(150),
    Expertise NVARCHAR(100)
);

CREATE TABLE Enrollments (
    EnrollmentID NVARCHAR(50) PRIMARY KEY,
    StudentID NVARCHAR(50),
    CourseID NVARCHAR(50),
    EnrollmentDate DATE,
    FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Payments (
    PaymentID NVARCHAR(50) PRIMARY KEY,
    StudentID NVARCHAR(50),
    Amount DECIMAL(10,2),
    PaymentDate DATE,
    FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
);
