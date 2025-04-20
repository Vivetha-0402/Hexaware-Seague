using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entity
{
    // Represents a teacher in the system
    public class Teacher
    {
        // Unique teacher ID
        public int TeacherId { get; set; }

        // First name of the teacher
        public string FirstName { get; set; }

        // Last name of the teacher
        public string LastName { get; set; }

        // Email address of the teacher
        public string Email { get; set; }

        // List of courses assigned to the teacher
        public List<Course> AssignedCourses { get; set; } = new List<Course>();

        // Constructor to initialize teacher details
        public Teacher(int teacherId, string firstName, string lastName, string email)
        {
            TeacherId = teacherId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Update the teacher's information
        // Note: Expertise field is mentioned in parameters but not used in class
        public void UpdateTeacherInfo(string name, string email, string expertise)
        {
            // Update first and last name from full name input
            FirstName = name.Split(' ')[0];
            LastName = name.Split(' ').Length > 1 ? name.Split(' ')[1] : "";
            Email = email;
        }

        // Display teacher's details
        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"ID: {TeacherId}, Name: {FirstName} {LastName}, Email: {Email}");
        }

        // Get list of courses assigned to the teacher
        public List<Course> GetAssignedCourses() => AssignedCourses;
    }
}
