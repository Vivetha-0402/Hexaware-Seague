using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entity
{
    // Represents the enrollment of a student in a course
    public class Enrollment
    {
        // Unique ID for each enrollment
        public int EnrollmentID { get; set; }

        // The student who is enrolled
        public Student Student { get; set; }

        // The course in which the student is enrolled
        public Course Course { get; set; }

        // The date when the enrollment was made
        public DateTime EnrollmentDate { get; set; }

        // Constructor to initialize an enrollment with details
        public Enrollment(int enrollmentID, Student student, Course course, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentID;
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }

        // Returns the student associated with the enrollment
        public Student GetStudent() => Student;

        // Returns the course associated with the enrollment
        public Course GetCourse() => Course;
    }
}
