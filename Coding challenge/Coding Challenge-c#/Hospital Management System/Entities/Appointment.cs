using System;

namespace HospitalManagementSystem.Entities
{
    // Represents an appointment entity
    public class Appointment
    {
        // Auto-implemented properties for Appointment details
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Description { get; set; }  // Make Description nullable
        public string? Remarks { get; set; }  // Nullable property for remarks


        //For Reference 
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }



        // Default constructor
        public Appointment() { }

        // Parameterized constructor
        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string? description)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            Description = description; // Can now be null
        }

        // Override ToString method for easy display of appointment details
        public override string ToString()
        {
            return $"AppointmentId: {AppointmentId}, PatientId: {PatientId}, DoctorId: {DoctorId}, Date: {AppointmentDate}, Description: {Description ?? "No Description"}";
        }
    }
}
