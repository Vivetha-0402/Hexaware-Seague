using System;

namespace HospitalManagementSystem.MyExceptions
{
    // Custom exception class for handling cases where the patient number does not exist in the database
    public class PatientNumberNotFoundException : Exception
    {
        // Constructor to initialize the exception with a custom error message
        public PatientNumberNotFoundException(string message) : base(message) { }
    }
}
