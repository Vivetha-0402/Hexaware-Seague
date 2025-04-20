using System;
using System.Collections.Generic;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.DAO
{
    // Interface for managing enrollment-related data operations
    public interface IEnrollmentDAO
    {
        // Add a new enrollment for a student in a course
        void AddEnrollment(Enrollment enrollment);

        // Retrieve a list of enrollments for a specific student by their StudentId
        List<Enrollment> GetEnrollmentsByStudentId(int studentId);

        // Retrieve a list of enrollments for a specific course by its CourseId
        List<Enrollment> GetEnrollmentsByCourseId(int courseId);
    }
}
