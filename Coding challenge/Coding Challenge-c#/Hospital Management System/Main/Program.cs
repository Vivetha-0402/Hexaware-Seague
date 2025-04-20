using System;
using System.Collections.Generic;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.DAO;
using HospitalManagementSystem.MyExceptions;

namespace HospitalManagementSystem.MainMod
{
    public class MainModule
    {
        public static void Main(string[] args)
        {
            // Create an instance of IHospitalService to handle appointment-related tasks
            IHospitalService hospitalService = new HospitalServiceImpl();
            bool exitProgram = false;

            // The loop keeps the program running until the user chooses to exit
            while (!exitProgram)
            {
                // Display the menu options for the user
                
                Console.WriteLine("\n----Hospital Management System----");
                Console.WriteLine("1. Get Appointment by ID");
                Console.WriteLine("2. Get Appointments for Patient");
                Console.WriteLine("3. Get Appointments for Doctor");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. Update Appointment");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                // Get user input and validate it as an integer
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue; // If invalid, prompt again
                }

                try
                {
                    // Switch statement based on user choice
                    switch (choice)
                    {
                        case 1:
                            // Option to get appointment details by appointment ID
                            Console.Write("Enter Appointment ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int appointmentId1))
                            {
                                Console.WriteLine("Invalid Appointment ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            Appointment appointment = hospitalService.GetAppointmentById(appointmentId1);
                            Console.WriteLine("Appointment Found: " + appointment); // Display the found appointment
                            break;

                        case 2:
                            // Option to get all appointments for a specific patient using patient ID
                            Console.Write("Enter Patient ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int patientId))
                            {
                                Console.WriteLine("Invalid Patient ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            List<Appointment> patientAppointments = hospitalService.GetAppointmentsForPatient(patientId);
                            Console.WriteLine("Appointments for Patient: ");
                            foreach (var app in patientAppointments)
                            {
                                Console.WriteLine(app); // Display each appointment for the patient
                            }
                            break;

                        case 3:
                            // Option to get all appointments for a specific doctor using doctor ID
                            Console.Write("Enter Doctor ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int doctorId))
                            {
                                Console.WriteLine("Invalid Doctor ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            List<Appointment> doctorAppointments = hospitalService.GetAppointmentsForDoctor(doctorId);
                            Console.WriteLine("Appointments for Doctor: ");
                            foreach (var app in doctorAppointments)
                            {
                                Console.WriteLine(app); // Display each appointment for the doctor
                            }
                            break;

                        case 4:
                            // Option to schedule a new appointment
                            Console.WriteLine("Enter Appointment Details:");
                            Console.Write("Patient ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int newPatientId))
                            {
                                Console.WriteLine("Invalid Patient ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            Console.Write("Doctor ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int newDoctorId))
                            {
                                Console.WriteLine("Invalid Doctor ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            Console.Write("Appointment Date (yyyy-mm-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDate))
                            {
                                Console.WriteLine("Invalid Date.");
                                break; // Exit the case if the date is invalid
                            }
                            Console.Write("Remarks: ");
                            string? remarks = Console.ReadLine();
                            // Create a new appointment object with the provided details
                            Appointment newAppointment = new Appointment(0, newPatientId, newDoctorId, appointmentDate, remarks!);
                            bool scheduled = hospitalService.ScheduleAppointment(newAppointment); // Call service to schedule appointment
                            Console.WriteLine(scheduled ? "Appointment Scheduled Successfully" : "Failed to Schedule Appointment");
                            break;

                        case 5:
                            // Option to update an existing appointment
                            Console.Write("Enter Appointment ID to Update: ");
                            if (!int.TryParse(Console.ReadLine(), out int updateAppointmentId))
                            {
                                Console.WriteLine("Invalid Appointment ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            Appointment existingAppointment = hospitalService.GetAppointmentById(updateAppointmentId); // Retrieve the existing appointment
                            Console.WriteLine("Current Appointment: " + existingAppointment);
                            Console.Write("Enter New Appointment Date (yyyy-mm-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                            {
                                Console.WriteLine("Invalid Date.");
                                break; // Exit the case if the date is invalid
                            }
                            Console.Write("Enter New Remarks: ");
                            string? newRemarks = Console.ReadLine();
                            existingAppointment.AppointmentDate = newDate; // Update the appointment details
                            existingAppointment.Description = newRemarks!;
                            bool updated = hospitalService.UpdateAppointment(existingAppointment); // Call service to update appointment
                            Console.WriteLine(updated ? "Appointment Updated" : "Failed to Update Appointment");
                            break;

                        case 6:
                            // Option to cancel an appointment
                            Console.Write("Enter Appointment ID to Cancel: ");
                            if (!int.TryParse(Console.ReadLine(), out int cancelAppointmentId))
                            {
                                Console.WriteLine("Invalid Appointment ID.");
                                break; // Exit the case if the ID is invalid
                            }
                            bool canceled = hospitalService.CancelAppointment(cancelAppointmentId); // Call service to cancel appointment
                            Console.WriteLine(canceled ? "Appointment Canceled" : "Failed to Cancel Appointment");
                            break;

                        case 7:
                            // Exit the program
                            exitProgram = true;
                            break;

                        default:
                            // Invalid menu option
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                // Catch custom exception for when patient is not found
                catch (PatientNumberNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // Catch any other general exceptions
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            // When exiting the application
            Console.WriteLine("Exiting the application...");
        }
    }
}
