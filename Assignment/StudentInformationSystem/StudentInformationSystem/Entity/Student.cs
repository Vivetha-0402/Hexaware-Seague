using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entity
{
    // Represents a student in the system
    public class Student
    {
        // Unique student ID
        public int StudentId { get; set; }

        // First name of the student
        public string FirstName { get; set; }

        // Last name of the student
        public string LastName { get; set; }

        // Student's date of birth
        public DateTime DateOfBirth { get; set; }

        // Email address of the student
        public string Email { get; set; }

        // Phone number of the student
        public string PhoneNumber { get; set; }

        // List of courses the student is enrolled in
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        // List of payments made by the student
        public List<Payment> Payments { get; set; } = new List<Payment>();

        // Constructor to initialize a student with required details
        public Student(int studentId, string firstName, string lastName, DateTime dob, string email, string phoneNumber)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Enroll the student into a course
        public void EnrollInCourse(Course course)
        {
            var enrollment = new Enrollment(0, this, course, DateTime.Now);
            Enrollments.Add(enrollment);
            course.Enrollments.Add(enrollment);
        }

        // Update the student's personal information
        public void UpdateStudentInfo(string firstName, string lastName, DateTime dob, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Email = email;
            PhoneNumber = phone;
        }

        // Add a payment made by the student
        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            var payment = new Payment(0, this, amount, paymentDate);
            Payments.Add(payment);
        }

        // Display student details in a readable format
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {FirstName} {LastName}, DOB: {DateOfBirth:d}, Email: {Email}, Phone: {PhoneNumber}");
        }

        // Return a list of courses the student is enrolled in
        public List<Course> GetEnrolledCourses()
        {
            return Enrollments.Select(e => e.Course).ToList();
        }

        // Return the payment history of the student
        public List<Payment> GetPaymentHistory()
        {
            return Payments;
        }
    }
}
