using System;
using System.Collections.Generic;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.DAO
{
    // Interface for managing student-related data operations
    public interface IStudentDAO
    {
        // Add a new student record to the system
        void AddStudent(Student student);

        // Retrieve a student record by their unique StudentId
        Student GetStudentById(int studentId);

        // Retrieve a list of all students in the system
        List<Student> GetAllStudents();
    }
}
