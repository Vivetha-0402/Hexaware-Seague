using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Util;
using HospitalManagementSystem.MyExceptions;

namespace HospitalManagementSystem.DAO
{
    public class HospitalServiceImpl : IHospitalService
    {
        private readonly SqlConnection connection;  // Now non-nullable

        // Default constructor: Initializes the connection using the DBConnection class
        public HospitalServiceImpl()
        {
            connection = DBConnection.GetConnection()
                         ?? throw new InvalidOperationException("Database connection failed.");
        }

        // Retrieves an appointment based on appointment ID
        public Appointment GetAppointmentById(int appointmentId)
        {
            if (connection == null)
                throw new InvalidOperationException("Database connection is null.");

            string query = @"
        SELECT a.appointmentid, a.patientid, a.doctorid, a.appointmentdate, a.remarks,
               p.first_name AS patientname, d.first_name AS doctorname
        FROM appointments a
        JOIN patients p ON a.patientid = p.patientid
        JOIN doctors d ON a.doctorid = d.doctorid
        WHERE a.appointmentid = @id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", appointmentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Appointment appointment = new Appointment
                        {
                            AppointmentId = (int)reader["appointmentid"],
                            PatientId = (int)reader["patientid"],
                            DoctorId = (int)reader["doctorid"],
                            AppointmentDate = (DateTime)reader["appointmentdate"],
                            Remarks = reader["remarks"] == DBNull.Value ? null : reader["remarks"].ToString(),
                            PatientName = reader["patientname"].ToString(),
                            DoctorName = reader["doctorname"].ToString()
                        };

                        // Print each on a new line
                        Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                        Console.WriteLine($"Patient ID: {appointment.PatientId}");
                        Console.WriteLine($"Patient Name: {appointment.PatientName}");
                        Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                        Console.WriteLine($"Doctor Name: {appointment.DoctorName}");
                        Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
                        Console.WriteLine($"Remarks: {appointment.Remarks}");

                        return appointment;
                    }
                }
            }

            throw new PatientNumberNotFoundException("Appointment not found for ID: " + appointmentId);
        }

        // Returns a list of appointments for a specific patient
        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = "SELECT * FROM appointments WHERE patientid = @pid";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@pid", patientId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            AppointmentId = (int)reader["appointmentid"],
                            PatientId = (int)reader["patientid"],
                            DoctorId = (int)reader["doctorid"],
                            AppointmentDate = (DateTime)reader["appointmentdate"],
                            Remarks = reader["remarks"] == DBNull.Value ? null : reader["remarks"].ToString()
                        });
                    }
                }
            }

            if (appointments.Count == 0)
                throw new PatientNumberNotFoundException("No appointments found for patient ID: " + patientId);

            return appointments;
        }

        // Returns a list of appointments for a specific doctor
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = "SELECT * FROM appointments WHERE doctorid = @did";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@did", doctorId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            AppointmentId = (int)reader["appointmentid"],
                            PatientId = (int)reader["patientid"],
                            DoctorId = (int)reader["doctorid"],
                            AppointmentDate = (DateTime)reader["appointmentdate"],
                            Remarks = reader["remarks"] == DBNull.Value ? null : reader["remarks"].ToString()
                        });
                    }
                }
            }

            return appointments;
        }

        // Schedules a new appointment
        public bool ScheduleAppointment(Appointment appointment)
        {
            string query = "INSERT INTO appointments (patientid, doctorid, appointmentdate, remarks) " +
                           "VALUES (@pid, @did, @date, @remarks)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@pid", appointment.PatientId);
                cmd.Parameters.AddWithValue("@did", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@date", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@remarks", appointment.Remarks ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Updates details of an existing appointment
        public bool UpdateAppointment(Appointment appointment)
        {
            string query = "UPDATE appointments SET patientid=@pid, doctorid=@did, appointmentdate=@date, remarks=@remarks WHERE appointmentid=@aid";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@aid", appointment.AppointmentId);
                cmd.Parameters.AddWithValue("@pid", appointment.PatientId);
                cmd.Parameters.AddWithValue("@did", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@date", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@remarks", appointment.Remarks ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cancels an appointment by deleting it using appointment ID
        public bool CancelAppointment(int appointmentId)
        {
            string query = "DELETE FROM appointments WHERE appointmentid = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", appointmentId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
