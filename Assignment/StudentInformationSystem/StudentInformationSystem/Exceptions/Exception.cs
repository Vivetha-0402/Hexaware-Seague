using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    // Exception thrown when a student is already enrolled in the same course
    public class DuplicateEnrollmentException : ApplicationException
    {
        public DuplicateEnrollmentException(string message) : base(message) { }
    }

    // Exception thrown when a course is not found in the database
    public class CourseNotFoundException : ApplicationException
    {
        public CourseNotFoundException(string message) : base(message) { }
    }

    // Exception thrown when a student record is not found
    public class StudentNotFoundException : ApplicationException
    {
        public StudentNotFoundException(string message) : base(message) { }
    }

    // Exception thrown when a teacher record is not found
    public class TeacherNotFoundException : ApplicationException
    {
        public TeacherNotFoundException(string message) : base(message) { }
    }

    // Exception thrown when there is a validation issue with the payment details
    public class PaymentValidationException : ApplicationException
    {
        public PaymentValidationException(string message) : base(message) { }
    }

    // Exception thrown when the student data is invalid or incomplete
    public class InvalidStudentDataException : ApplicationException
    {
        public InvalidStudentDataException(string message) : base(message) { }
    }

    // Exception thrown when the course data is invalid or incomplete
    public class InvalidCourseDataException : ApplicationException
    {
        public InvalidCourseDataException(string message) : base(message) { }
    }

    // Exception thrown when the enrollment data is invalid or inconsistent
    public class InvalidEnrollmentDataException : ApplicationException
    {
        public InvalidEnrollmentDataException(string message) : base(message) { }
    }

    // Exception thrown when the teacher data is invalid or incomplete
    public class InvalidTeacherDataException : ApplicationException
    {
        public InvalidTeacherDataException(string message) : base(message) { }
    }

    // Exception thrown when a student tries to make a payment with insufficient balance
    public class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
