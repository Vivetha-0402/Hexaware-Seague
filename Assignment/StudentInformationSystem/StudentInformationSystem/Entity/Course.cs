using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entity
{
    // Represents a course offered in the student information system
    public class Course
    {
        // Unique identifier for the course
        public int CourseId { get; set; }

        // Name of the course (e.g., Data Structures)
        public string CourseName { get; set; }

        // Unique course code (e.g., CS101)
        public string CourseCode { get; set; }

        // Name of the instructor for the course
        public string InstructorName { get; set; }

        // Teacher assigned to this course (nullable)
        public Teacher? AssignedTeacher { get; set; }

        // List of enrollments for this course
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        // Constructor to initialize a course with required details
        public Course(int courseId, string courseName, string courseCode, string instructorName)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
        }

        // Assigns a teacher to this course and updates the teacher's assigned course list
        public void AssignTeacher(Teacher teacher)
        {
            AssignedTeacher = teacher;
            teacher.AssignedCourses.Add(this);
        }

        // Updates course details such as code, name, and instructor
        public void UpdateCourseInfo(string courseCode, string courseName, string instructor)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            InstructorName = instructor;
        }

        // Displays course information in the console
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"ID: {CourseId}, Name: {CourseName}, Code: {CourseCode}, Instructor: {InstructorName}");
        }

        // Returns the list of enrollments in this course
        public List<Enrollment> GetEnrollments() => Enrollments;

        // Returns the teacher assigned to this course
        public Teacher? GetTeacher() => AssignedTeacher;
    }
}
