using System;
using System.Collections.Generic;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.DAO
{
    // Interface for managing teacher-related data operations
    public interface ITeacherDAO
    {
        // Add a new teacher record to the system
        void AddTeacher(Teacher teacher);

        // Retrieve a teacher record by their unique TeacherId
        Teacher GetTeacherById(int teacherId);

        // Retrieve a list of all teachers in the system
        List<Teacher> GetAllTeachers();

        // Assign a teacher to a course by specifying course and teacher IDs
        void AssignTeacherToCourse(int courseId, int teacherId);
    }
}
