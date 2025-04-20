using System.Collections.Generic;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.DAO
{
    // Interface defining the operations that interact with the hospital database
    public interface IHospitalService
    {
        // Fetch an appointment by its ID
        // Parameters: appointmentId (int)
        // ReturnType: Appointment object
        Appointment GetAppointmentById(int appointmentId);

        // Fetch all appointments for a specific patient
        // Parameters: patientId (int)
        // ReturnType: List of Appointment objects
        List<Appointment> GetAppointmentsForPatient(int patientId);

        // Fetch all appointments for a specific doctor
        // Parameters: doctorId (int)
        // ReturnType: List of Appointment objects
        List<Appointment> GetAppointmentsForDoctor(int doctorId);

        // Schedule a new appointment
        // Parameters: Appointment object
        // ReturnType: Boolean (true if successful, false otherwise)
        bool ScheduleAppointment(Appointment appointment);

        // Update an existing appointment
        // Parameters: Appointment object
        // ReturnType: Boolean (true if successful, false otherwise)
        bool UpdateAppointment(Appointment appointment);

        // Cancel an existing appointment
        // Parameters: appointmentId (int)
        // ReturnType: Boolean (true if successful, false otherwise)
        bool CancelAppointment(int appointmentId);
    }
}
