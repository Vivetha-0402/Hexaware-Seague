namespace Asset_Management.Entities
{
    // Represents a reservation record for an asset by an employee
    public class Reservation
    {
        // Unique identifier for the reservation
        public int ReservationId { get; set; }

        // ID of the asset being reserved
        public int AssetId { get; set; }

        // ID of the employee who made the reservation
        public int EmployeeId { get; set; }

        // Status of the reservation (e.g., "Active", "Cancelled")
        public string Status { get; set; }  // Non-nullable, always initialized in the constructor

        // Date when the reservation was made
        public string ReservationDate { get; set; }

        // Start date of the reservation period
        public string StartDate { get; set; }

        // End date of the reservation period
        public string EndDate { get; set; }

        // Constructor to initialize all fields of the reservation
        public Reservation(int reservationId, int assetId, int employeeId, string status, string reservationDate, string startDate, string endDate)
        {
            ReservationId = reservationId;
            AssetId = assetId;
            EmployeeId = employeeId;
            Status = status; // Ensures 'Status' is always initialized
            ReservationDate = reservationDate;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
