using System;
using System.Collections.Generic;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.DAO
{
    // Interface for managing course-related data operations
    public interface ICourseDAO
    {
        // Add a new course to the system
        void AddCourse(Course course);

        // Retrieve a course by its unique identifier (CourseId)
        Course GetCourseById(int courseId);

        // Get a list of all courses available in the system
        List<Course> GetAllCourses();

        // Update the details of an existing course
        void UpdateCourse(Course course);
    }
}
