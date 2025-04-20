using System;
using System.Collections.Generic;
using System.Linq;
using StudentInformationSystem.Entity;
using StudentInformationSystem.Exceptions;
using StudentInformationSystem.DAO;

namespace StudentInformationSystem.dao
{
    // Implements the ICourseDAO interface to manage course data in the system
    public class CourseDaoImpl : ICourseDAO
    {
        // In-memory list to store courses
        private List<Course> courses = new List<Course>();

        // Add a new course to the system
        public void AddCourse(Course course)
        {
            // Validate the course data, especially the course code
            if (string.IsNullOrWhiteSpace(course.CourseCode))
                throw new InvalidCourseDataException("Invalid course data.");

            // Check if the course already exists based on its unique CourseId
            if (courses.Any(c => c.CourseId == course.CourseId))
                throw new CourseNotFoundException("Course already exists.");

            // Add the course to the list
            courses.Add(course);
        }

        // Get a course by its ID (string format)
        public Course GetCourseById(string courseId)
        {
            // Validate and parse the CourseId to integer
            if (!int.TryParse(courseId, out int id))
                throw new InvalidCourseDataException("Invalid Course ID format.");

            // Retrieve the course by its ID
            var course = courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
                throw new CourseNotFoundException("Course not found.");

            return course;
        }

        // Update the details of an existing course
        public void UpdateCourse(Course course)
        {
            // Check if the course exists before updating
            var existing = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (existing == null)
                throw new CourseNotFoundException("Course does not exist.");

            // Update the course details
            existing.CourseCode = course.CourseCode;
            existing.CourseName = course.CourseName;
            existing.InstructorName = course.InstructorName;
        }

        // Get all courses available in the system
        public List<Course> GetAllCourses()
        {
            // Return a copy of the course list to prevent external modification
            return new List<Course>(courses);
        }

        // Get a course by its ID (int format)
        public Course GetCourseById(int courseId)
        {
            // Retrieve the course by its ID
            var course = courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
                throw new CourseNotFoundException("Course not found.");

            return course;
        }
    }
}
