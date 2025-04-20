using StudentInformationSystem.Entity;
using StudentInformationSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.Util;
using SIS.Util;

namespace StudentInformationSystem.DAO
{
    // Implementation of the IStudentDAO interface
    public class StudentDaoImpl : IStudentDAO
    {
        private List<Student> students = new List<Student>();

        // Add a new student to the database
        public void AddStudent(Student student)
        {
            try
            {
                // Validation to check for null or empty values before DB interaction
                if (string.IsNullOrWhiteSpace(student.FirstName) ||
                    string.IsNullOrWhiteSpace(student.LastName) ||
                    string.IsNullOrWhiteSpace(student.Email) ||
                    string.IsNullOrWhiteSpace(student.PhoneNumber))
                {
                    // Throw custom exception if student data is not valid
                    throw new InvalidStudentDataException("Student data is incomplete or invalid.");
                }

                // Get the DB connection string from configuration file
                string connectionString = DBPropertyUtil.GetConnectionString("appsettings.json");

                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    conn.Open();

                    // Parameterized SQL command to avoid SQL injection
                    string query = "INSERT INTO Students (StudentID, FirstName, LastName, DOB, Email, Phone) " +
                                   "VALUES (@StudentID, @FirstName, @LastName, @DOB, @Email, @Phone)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Binding parameters with student data
                        cmd.Parameters.AddWithValue("@StudentID", student.StudentId);
                        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", student.LastName);
                        cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Email", student.Email);
                        cmd.Parameters.AddWithValue("@Phone", student.PhoneNumber);

                        // Execute the insert query
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Catch SQL exceptions like DB connectivity or syntax errors
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                throw;
            }
            catch (InvalidStudentDataException ide)
            {
                // Catch validation-related exceptions and show the error
                Console.WriteLine("Validation Error: " + ide.Message);
                throw;
            }
            catch (Exception ex)
            {
                // Catch all other exceptions
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }



        // Get a student by their unique Student ID
        public Student GetStudentById(int studentId)
        {
            // Look for the student in the list using LINQ
            var student = students.FirstOrDefault(s => s.StudentId == studentId);

            // If student is not found, throw a custom exception
            if (student == null)
                throw new StudentNotFoundException("Student not found.");

            return student;  // Return the found student
        }

        // Retrieve all students from the list
        public List<Student> GetAllStudents()
        {
            return students;  // Return the list of all students
        }
    }
}
