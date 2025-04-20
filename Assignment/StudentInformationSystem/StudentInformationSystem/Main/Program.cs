using System;
using StudentInformationSystem.Entity;
using StudentInformationSystem.Exceptions;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.DAO;
using StudentInformationSystem.dao;

namespace StudentInformationSystem.Main
{
    public class SISMain
    {
        static void Main(string[] args)
        {
            // Create instances of DAO interfaces to access database operations
            IStudentDAO studentDAO = new StudentDaoImpl();
            ICourseDAO courseDAO = new CourseDaoImpl();
            ITeacherDAO teacherDAO = new TeacherDaoImpl();
            IEnrollmentDAO enrollmentDAO = new EnrollmentDaoImpl();
            IPaymentDAO paymentDAO = new PaymentDaoImpl();

            // Infinite loop for showing the main menu
            while (true)
            {
                // Display menu options to the user
                Console.WriteLine("\n====== Student Information System ======");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("3. Add Teacher");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Record Payment");
                Console.WriteLine("6. Assign Teacher to Course");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                // Validate numeric choice input
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            // Case 1: Add new student details
                            Console.WriteLine("\n--- Add Student ---");

                            Console.Write("Student ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int studentId))
                                throw new Exception("Invalid Student ID.");

                            Console.Write("First Name: ");
                            string? fname = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string? lname = Console.ReadLine();

                            Console.Write("DOB (yyyy-mm-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
                                throw new Exception("Invalid Date.");

                            Console.Write("Email: ");
                            string? email = Console.ReadLine();

                            Console.Write("Phone Number: ");
                            string? phone = Console.ReadLine();

                            // Check if any required field is empty
                            if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) ||
                                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
                                throw new Exception("Fields cannot be empty.");

                            // Create and save student object
                            var newStudent = new Student(studentId, fname, lname, dob, email, phone);
                            studentDAO.AddStudent(newStudent);
                            Console.WriteLine("Student added successfully.");
                            break;

                        case 2:
                            // Case 2: Add new course
                            Console.WriteLine("\n--- Add Course ---");

                            Console.Write("Course ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int courseId))
                                throw new Exception("Invalid Course ID.");

                            Console.Write("Course Name: ");
                            string? courseName = Console.ReadLine();

                            Console.Write("Course Code: ");
                            string? courseCode = Console.ReadLine();

                            Console.Write("Instructor Name: ");
                            string? instructorName = Console.ReadLine();

                            // Validate required course fields
                            if (string.IsNullOrWhiteSpace(courseName) || string.IsNullOrWhiteSpace(courseCode) ||
                                string.IsNullOrWhiteSpace(instructorName))
                                throw new Exception("Course fields cannot be empty.");

                            // Create and save course object
                            var course = new Course(courseId, courseName, courseCode, instructorName);
                            courseDAO.AddCourse(course);
                            Console.WriteLine("Course added successfully.");
                            break;

                        case 3:
                            // Case 3: Add teacher
                            Console.WriteLine("\n--- Add Teacher ---");

                            Console.Write("Teacher ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int teacherId))
                                throw new Exception("Invalid Teacher ID.");

                            Console.Write("First Name: ");
                            string? tFname = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string? tLname = Console.ReadLine();

                            Console.Write("Email: ");
                            string? tEmail = Console.ReadLine();

                            // Check for required teacher details
                            if (string.IsNullOrWhiteSpace(tFname) || string.IsNullOrWhiteSpace(tLname) ||
                                string.IsNullOrWhiteSpace(tEmail))
                                throw new Exception("Teacher fields cannot be empty.");

                            // Create and save teacher object
                            var teacher = new Teacher(teacherId, tFname, tLname, tEmail);
                            teacherDAO.AddTeacher(teacher);
                            Console.WriteLine("Teacher added successfully.");
                            break;

                        case 4:
                            // Case 4: Enroll student in a course
                            Console.WriteLine("\n--- Enroll Student in Course ---");

                            Console.Write("Enrollment ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int enrollId))
                                throw new Exception("Invalid Enrollment ID.");

                            Console.Write("Student ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int stuId))
                                throw new Exception("Invalid Student ID.");

                            // Fetch student object by ID
                            var enrollStudent = studentDAO.GetStudentById(stuId);
                            if (enrollStudent == null)
                                throw new Exception("Student not found.");

                            Console.Write("Course ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int courId))
                                throw new Exception("Invalid Course ID.");

                            // Fetch course object by ID
                            var enrollCourse = courseDAO.GetCourseById(courId);
                            if (enrollCourse == null)
                                throw new Exception("Course not found.");

                            // Use current date for enrollment
                            DateTime enrollDate = DateTime.Now;

                            // Create and save enrollment
                            var enrollment = new Enrollment(enrollId, enrollStudent, enrollCourse, enrollDate);
                            enrollmentDAO.AddEnrollment(enrollment);
                            Console.WriteLine("Student enrolled in course.");
                            break;

                        case 5:
                            // Case 5: Record payment from student
                            Console.WriteLine("\n--- Record Payment ---");

                            Console.Write("Payment ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int paymentId))
                                throw new Exception("Invalid Payment ID.");

                            Console.Write("Student ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int sid))
                                throw new Exception("Invalid Student ID.");

                            Console.Write("Amount: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                                throw new Exception("Invalid Amount.");

                            Console.Write("Payment Date (yyyy-mm-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime payDate))
                                throw new Exception("Invalid Payment Date.");

                            // Get student object and validate
                            var foundStudent = studentDAO.GetStudentById(sid);
                            if (foundStudent == null)
                                throw new Exception("Student not found.");

                            // Create and save payment
                            var payment = new Payment(paymentId, foundStudent, amount, payDate);
                            paymentDAO.AddPayment(payment);
                            Console.WriteLine("Payment recorded successfully.");
                            break;

                        case 6:
                            // Case 6: Assign teacher to course
                            Console.WriteLine("\n--- Assign Teacher to Course ---");

                            Console.Write("Course ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int assignCourseId))
                                throw new Exception("Invalid Course ID.");

                            Console.Write("Teacher ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int assignTeacherId))
                                throw new Exception("Invalid Teacher ID.");

                            // Perform teacher assignment
                            teacherDAO.AssignTeacherToCourse(assignCourseId, assignTeacherId);
                            Console.WriteLine("Teacher assigned to course.");
                            break;

                        case 0:
                            // Case 0: Exit the application
                            Console.WriteLine("Exiting..");
                            return;

                        default:
                            // Handle invalid menu choice
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Display error if any exception is thrown
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
