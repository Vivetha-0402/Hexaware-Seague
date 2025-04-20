using StudentInformationSystem.DAO;
using StudentInformationSystem.Entity;
using StudentInformationSystem.Exceptions;

namespace StudentInformationSystem.dao
{
    // Implements the IEnrollmentDAO interface to manage student enrollments in courses
    public class EnrollmentDaoImpl : IEnrollmentDAO
    {
        // In-memory list to store enrollments
        private List<Enrollment> enrollments = new List<Enrollment>();

        // Add a new enrollment for a student in a course
        public void AddEnrollment(Enrollment enrollment)
        {
            // Validate if the enrollment data has both student and course information
            if (enrollment.Student == null || enrollment.Course == null)
                throw new InvalidEnrollmentDataException("Missing student or course information.");

            // Check if the student is already enrolled in the same course
            if (enrollments.Any(e => e.Student.StudentId == enrollment.Student.StudentId &&
                                     e.Course.CourseId == enrollment.Course.CourseId))
                throw new DuplicateEnrollmentException("This student is already enrolled in the course.");

            // Add the enrollment to the list
            enrollments.Add(enrollment);
        }

        // Get all enrollments for a specific student by their student ID
        public List<Enrollment> GetEnrollmentsByStudentId(int studentId)
        {
            // Retrieve the list of enrollments for the student
            return enrollments.Where(e => e.Student.StudentId == studentId).ToList();
        }

        // Get all enrollments for a specific course by its course ID
        public List<Enrollment> GetEnrollmentsByCourseId(int courseId)
        {
            // Retrieve the list of enrollments for the course
            return enrollments.Where(e => e.Course.CourseId == courseId).ToList();
        }
    }
}
