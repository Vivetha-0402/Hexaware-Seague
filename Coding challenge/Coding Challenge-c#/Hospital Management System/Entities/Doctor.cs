using System;

namespace HospitalManagementSystem.Entities
{
    // Represents a doctor entity
    public class Doctor
    {
        private int doctorId;
        public required string FirstName { get; set; }  // Required FirstName
        public string? LastName { get; set; }  // Nullable LastName
        public string? Specialization { get; set; } // Nullable Specialization
        public string? ContactNumber { get; set; }  // Nullable ContactNumber

        // Default constructor
        public Doctor() { }

        // Parameterized constructor
        public Doctor(int doctorId, string firstName, string? lastName, string? specialization, string? contactNumber)
        {
            this.doctorId = doctorId;
            this.FirstName = firstName;
            this.LastName = lastName;  // Nullable, can be null
            this.Specialization = specialization;  // Nullable, can be null
            this.ContactNumber = contactNumber;  // Nullable, can be null
        }

        public int DoctorId { get => doctorId; set => doctorId = value; }

        public override string ToString()
        {
            return $"DoctorId: {doctorId}, Name: {FirstName} {LastName}, Specialization: {Specialization}, Contact: {ContactNumber}";
        }
    }
}
