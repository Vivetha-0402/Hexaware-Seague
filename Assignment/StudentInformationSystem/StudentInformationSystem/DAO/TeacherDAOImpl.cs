using StudentInformationSystem.DAO;
using StudentInformationSystem.Entity;
using StudentInformationSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInformationSystem.dao
{
    // Implementation of ITeacherDAO interface
    public class TeacherDaoImpl : ITeacherDAO
    {
        private List<Teacher> teachers = new List<Teacher>();  // List to store teacher data
        private List<Course> courses = new List<Course>();    // List to store course data

        // Add a new teacher to the list (or database if extended)
        public void AddTeacher(Teacher teacher)
        {
            // Validate that teacher email is not empty
            if (string.IsNullOrWhiteSpace(teacher.Email))
                throw new InvalidTeacherDataException("Invalid teacher data.");

            // Check if the teacher already exists in the list by TeacherId
            if (teachers.Any(t => t.TeacherId == teacher.TeacherId))
                throw new TeacherNotFoundException("Teacher already exists.");

            // Add the teacher to the list
            teachers.Add(teacher);
        }

        // Retrieve a teacher by their unique TeacherId
        public Teacher GetTeacherById(int teacherId)  // Ensure parameter is int
        {
            // Find the teacher by TeacherId
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherId);  // Ensure matching types

            // If teacher is not found, throw a custom exception
            if (teacher == null)
                throw new TeacherNotFoundException("Teacher not found.");

            return teacher;  // Return the found teacher
        }

        // Update an existing teacher's details
        public void UpdateTeacher(Teacher teacher)
        {
            // Find the teacher to update by TeacherId
            var existing = teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);

            // If teacher doesn't exist, throw an exception
            if (existing == null)
                throw new TeacherNotFoundException("Teacher does not exist.");

            // Update teacher's information
            existing.FirstName = teacher.FirstName;
            existing.LastName = teacher.LastName;
            existing.Email = teacher.Email;
        }

        // Get a list of all teachers
        public List<Teacher> GetAllTeachers()
        {
            return teachers;  // Simply return the list of all teachers
        }

        // Assign a teacher to a course
        public void AssignTeacherToCourse(int courseId, int teacherId)
        {
            // Find the teacher by TeacherId
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherId);

            // Find the course by CourseId
            var course = courses.FirstOrDefault(c => c.CourseId == courseId);

            // If teacher or course is not found, throw an exception
            if (teacher == null)
                throw new TeacherNotFoundException("Teacher not found.");
            if (course == null)
                throw new CourseNotFoundException("Course not found.");

            // Assign the teacher's full name to the course's instructor field
            course.InstructorName = $"{teacher.FirstName} {teacher.LastName}";  // Concatenate FirstName and LastName
        }
    }
}
